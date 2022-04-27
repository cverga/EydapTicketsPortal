//
// Source name  : NeaParoxiDAL.cs
// CreationDate : 19.09.2017
// Created by   : Andreas Kasapleris
// Purpose      : Data Access Layer to Oracle
// Last Changed : 19.09.2017
// Reason       : initial creation
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;                  // C#, ADO.NET class definitions, added, Andreas Kasapleris, 19.09.2017

//using System.Data.OracleClient;   // References > Add Reference, added, Andreas Kasapleris, 19.09.2017
using Oracle.DataAccess.Client;     // C#, Oracle's Oracle provider, V 4.112.3.0
using Oracle.DataAccess.Types;      // C#, Oracle data types for parameters

using System.Data.Common;       // added, Andreas Kasapleris, 19.09.2017
using System.Configuration;     // added, Andreas Kasapleris, 19.09.2017

namespace EydapTickets.Models
{
    public class NeaParoxiDAL
    {
        public NeaParoxiDAL()
        {
            // constructor commands
        }

        public static IEnumerable<object> GetNeaParoxiRequestIds(string filterParameters)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };

            string searchMunicipality = "";
            string searchOdos = "";

            if (!String.IsNullOrEmpty(filterParameters))
            {
                string[] filters = filterParameters.Split(delimiterChars);
                searchMunicipality = filters[0].Substring(0, filters[0].Length / 2 + 1);
                //searchMunicipality = filters[0];
                searchOdos = filters[1];
            }

            // if Municipality or Odos search criteria is empty
            // return an empty object
            if (String.IsNullOrEmpty(searchMunicipality) || String.IsNullOrEmpty(searchOdos))
            {
                return new List<object>();
            }

            OracleConnection mConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["neaparoxi"].ToString());
            string sqlSelect = " SELECT rrp_request.rrp_req_id || '-' || rrp_request.rrp_build_address || '-' || rrp_request.rrp_build_add_num AS RRP_REQID_RESULT " +
                               "   FROM rrp_request, rnp_provision, rnd_provision_dtl " +
                               "  WHERE rrp_request.RRP_BUILD_MUNICIPALITY LIKE :srchMunicipality || '%' " +
                               "    AND rrp_request.RRP_BUILD_ADDRESS = :srchOdos " +
                               "    AND rrp_request.RRP_IS_ACTIVE = 'TRUE' " +
                               "    AND rrp_request.rrp_id = rnp_provision.rnp_rrp_id " +
                               "    AND rnp_provision.rnp_id = rnd_provision_dtl.rnd_rnp_id " +
                               "    AND ( ( TO_NUMBER(rnd_provision_dtl.rnd_phase_flg) >= 200 AND TO_NUMBER(rnd_provision_dtl.rnd_status_flg) >= 30) " +
                               "     OR   ( TO_NUMBER(rnd_provision_dtl.rnd_phase_flg) >  200) ) " +
                               "    AND rnd_id IN " +
                               "          (SELECT NVL(MAX(rnd_provision_dtl.rnd_id), -1) " +
                               "             FROM rnd_provision_dtl " +
                               "            WHERE rnd_provision_dtl.rnd_rnp_id = rnp_provision.rnp_id " +
                               "         GROUP BY rnd_rnp_id) ";

            OracleCommand mCommand = new OracleCommand();
            mCommand.Connection = mConnection;
            mCommand.CommandText = sqlSelect;

            // add query search parameters
            mCommand.Parameters.Add(new OracleParameter("srchMunicipality", searchMunicipality));
            mCommand.Parameters.Add(new OracleParameter("srchOdos", searchOdos));

            DataTable mDataTable = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mCommand.ExecuteReader());
                mConnection.Close();
            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
            }

            var d = from c in mDataTable.AsEnumerable()
                    select new
                    {
                        Id = c.Field<System.String>("RRP_REQID_RESULT"),
                        Name = c.Field<System.String>("RRP_REQID_RESULT")
                    };
            return d;
        }

        public static ProvisionDetails GetNeaParoxiDetails(string aParameter)
        {
            OracleConnection mConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["neaparoxi"].ToString());
            string sqlSelect = "SELECT RAM_MANUFACTURE.RAM_ID, RAM_MANUFACTURE.RAM_PROVISION_DT, RAM_MANUFACTURE.RAM_EXCAV_TYPE_HT, " +
                               "       RAM_MANUFACTURE.RAM_RESTORATION_TAR_DT, RAM_MANUFACTURE.RAM_RESTORATION_SIDEWALK_DT, RAM_MANUFACTURE.RAM_RESTORATION_DEBRIS_DT " +
                               "  FROM RRP_REQUEST, RNP_PROVISION, RND_PROVISION_DTL, RCN_CONTRACT, RAM_MANUFACTURE " +
                               " WHERE rrp_request.rrp_req_id    = :parameter " +
                               "   AND rrp_request.rrp_is_active = 'TRUE' " +
                               "   AND rrp_request.rrp_id        = rnp_provision.rnp_rrp_id " +
                               "   AND rnp_provision.rnp_id      = rnd_provision_dtl.rnd_rnp_id " +
                               "   AND ((TO_NUMBER(rnd_provision_dtl.rnd_phase_flg) >= 200 AND TO_NUMBER(rnd_provision_dtl.rnd_status_flg) >= 30) " +
                               "    OR  (TO_NUMBER(rnd_provision_dtl.rnd_phase_flg) >  200) ) " +
                               "   AND rnd_provision_dtl.rnd_id IN " +
                               "       (SELECT NVL(MAX(rnd_provision_dtl.rnd_id), -1) " +
                               "          FROM rnd_provision_dtl " +
                               "         WHERE rnd_provision_dtl.rnd_rnp_id = rnp_provision.rnp_id " +
                               "      GROUP BY rnd_provision_dtl.rnd_rnp_id) " +
                               "   AND rcn_contract.rcn_id = " +
                               "       (SELECT NVL(MAX(rcn_id), -1) " +
                               "          FROM rcn_contract " +
                               "         WHERE rcn_contract.rcn_rnp_id = rnp_provision.rnp_id " +
                               "      GROUP BY rcn_contract.rcn_rnp_id) " +
                               "   AND ram_manufacture.ram_id = " +
                               "       (SELECT NVL(MAX(ram_id), -1) " +
                               "          FROM ram_manufacture " +
                               "         WHERE ram_manufacture.ram_rnp_id = rnp_provision.rnp_id " +
                               "      GROUP BY ram_manufacture.ram_rnp_id) ";

            OracleCommand mCommand = new OracleCommand();
            mCommand.Connection = mConnection;
            mCommand.CommandText = sqlSelect;
            mCommand.Parameters.Add(new OracleParameter("parameter", aParameter));
            DataTable mDataTable = new DataTable();

            string sqlSelect2 = "SELECT MVX_ID, MVX_RAM_ID FROM MVX_RAM_DTL WHERE MVX_RAM_ID = :parameter";
            OracleCommand mCommand1 = new OracleCommand();
            mCommand1.Connection = mConnection;
            mCommand1.CommandText = sqlSelect2;
            //mCommand1.Parameters.Add(new OracleParameter("parameter", aParameter));
            DataTable mDataTable1 = new DataTable();
            try
            {
                mConnection.Open();
                mDataTable.Load(mCommand.ExecuteReader());
                if (mDataTable.Rows.Count != 0)
                {
                    mCommand1.Parameters.Add(new OracleParameter("parameter", mDataTable.Rows[0]["RAM_ID"]));
                    mDataTable1.Load(mCommand1.ExecuteReader());
                }
                mConnection.Close();
            }
            catch (Exception /* exception */)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
            }

            if (mDataTable.Rows.Count != 0)
            {

                DataRow mRow = mDataTable.Rows[0];
                //SELECT RAM_MANUFACTURE.RAM_ID, RAM_MANUFACTURE.RAM_PROVISION_DT, RAM_MANUFACTURE.RAM_EXCAV_TYPE_HT,
                //RAM_MANUFACTURE.RAM_RESTORATION_TAR_DT, RAM_MANUFACTURE.RAM_RESTORATION_SIDEWALK_DT, RAM_MANUFACTURE.RAM_RESTORATION_DEBRIS_DT

                ProvisionDetails mProvisionDetails = new ProvisionDetails();
                mProvisionDetails.RAMID = Convert.ToInt32(mRow["RAM_ID"]);
                mProvisionDetails.ProvisionDate = mRow["RAM_PROVISION_DT"] == System.DBNull.Value ? null : (DateTime?)Convert.ToDateTime(mRow["RAM_PROVISION_DT"]);
                mProvisionDetails.ApokomidiBazaDate = mRow["RAM_RESTORATION_DEBRIS_DT"] == System.DBNull.Value ? null : (DateTime?)Convert.ToDateTime(mRow["RAM_RESTORATION_DEBRIS_DT"]);
                mProvisionDetails.EpanaforaAsphatosDate = mRow["RAM_RESTORATION_TAR_DT"] == System.DBNull.Value ? null : (DateTime?)Convert.ToDateTime(mRow["RAM_RESTORATION_TAR_DT"]);
                mProvisionDetails.EpanaforaPezodromiouDate = mRow["RAM_RESTORATION_SIDEWALK_DT"] == System.DBNull.Value ? null : (DateTime?)Convert.ToDateTime(mRow["RAM_RESTORATION_SIDEWALK_DT"]);

                if (mDataTable1.Rows.Count != 0)
                {
                    for (int n = 0; n < mDataTable1.Rows.Count; n++)
                    {
                        switch (mDataTable1.Rows[n]["MVX_ID"].ToString())
                        {
                            case "1":
                                mProvisionDetails.Asphaltos = true;
                                break;
                            case "2":
                                mProvisionDetails.Mpeton = true;
                                break;
                            case "3":
                                mProvisionDetails.Plakes = true;
                                break;
                            case "4":
                                mProvisionDetails.Kraspedorithro = true;
                                break;
                            case "5":
                                mProvisionDetails.Xoma = true;
                                break;
                        }
                    }

                }
                return mProvisionDetails;
            }
            return new ProvisionDetails();
        }


        public static ProvisionDetails UpdateNeaParoxiDetails(ProvisionDetails aProvisionDetails)
        {
            OracleConnection mConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["neaparoxi"].ToString());
            //string sqlSelect = "SELECT RAM_MANUFACTURE.RAM_ID, RAM_MANUFACTURE.RAM_PROVISION_DT, RAM_MANUFACTURE.RAM_EXCAV_TYPE_HT, " +
            //    " RAM_MANUFACTURE.RAM_RESTORATION_TAR_DT, RAM_MANUFACTURE.RAM_RESTORATION_SIDEWALK_DT, RAM_MANUFACTURE.RAM_RESTORATION_DEBRIS_DT " +
            //    " FROM RRP_REQUEST, RNP_PROVISION, RND_PROVISION_DTL, RCN_CONTRACT, RAM_MANUFACTURE WHERE rrp_request.rrp_req_id    = :parameter " +
            //    " AND rrp_request.rrp_is_active = 'TRUE' AND rrp_request.rrp_id        = rnp_provision.rnp_rrp_id " +
            //    " AND rnp_provision.rnp_id      = rnd_provision_dtl.rnd_rnp_id AND rnp_provision.rnp_id      = rcn_contract.rcn_rnp_id " +
            //    " AND rnp_provision.rnp_id      = ram_manufacture.ram_rnp_id AND rnd_provision_dtl.rnd_phase_flg = '200' " +
            //    " AND rnd_provision_dtl.rnd_status_flg = '30' AND rnd_id IN " +
            //    " (SELECT MAX (rnd_id) FROM rnd_provision_dtl WHERE rnd_provision_dtl.rnd_rnp_id = rnp_provision.rnp_id GROUP BY rnd_rnp_id)" +
            //    " AND rcn_contract.rcn_id = (SELECT NVL (MAX (rcn_id), -1) FROM rcn_contract  WHERE rnp_provision.rnp_id = rcn_contract.rcn_rnp_id) " +
            //    " AND NVL (rcn_contract.rcn_contractor, -1) = NVL (ram_manufacture.ram_contractor, -1) " +
            //    " AND ram_manufacture.ram_id = DECODE(RAM_SHIFT,'YES',  (SELECT max(ram_id) FROM ram_manufacture WHERE ram_manufacture.ram_rnp_id = rnp_provision.rnp_id),ram_id )";


            string updatecommand = "UPDATE RAM_MANUFACTURE set RAM_PROVISION_DT = :provisionDT, RAM_RESTORATION_TAR_DT = :restorationtarDT, RAM_RESTORATION_SIDEWALK_DT = :restorationsidewalkDT, RAM_RESTORATION_DEBRIS_DT = :restorationdebrisDT " +
                " where RAM_ID = " + aProvisionDetails.RAMID.ToString();
            //RAM_MANUFACTURE.RAM_PROVISION_DT,

            //RAM_MANUFACTURE.RAM_EXCAV_TYPE_HT,

            //RAM_MANUFACTURE.RAM_RESTORATION_TAR_DT,

            //RAM_MANUFACTURE.RAM_RESTORATION_SIDEWALK_DT,

            //RAM_MANUFACTURE.RAM_RESTORATION_DEBRIS_DT

            //WHERE RAM_MANUFACTURE.RAM_ID = XXXXXXXXXXXXXXXXX;


            OracleCommand mCommand = new OracleCommand();
            mCommand.Connection = mConnection;
            mCommand.CommandText = updatecommand;
            mCommand.Parameters.Add(new OracleParameter("provisionDT", aProvisionDetails.ProvisionDate));
            mCommand.Parameters.Add(new OracleParameter("restorationtarDT", aProvisionDetails.EpanaforaAsphatosDate));
            mCommand.Parameters.Add(new OracleParameter("restorationsidewalkDT", aProvisionDetails.EpanaforaPezodromiouDate));
            mCommand.Parameters.Add(new OracleParameter("restorationdebrisDT", aProvisionDetails.ApokomidiBazaDate));

            OracleCommand mCommand1 = null;
            OracleCommand mCommand2 = null;
            OracleCommand mCommand3 = null;
            OracleCommand mCommand4 = null;
            OracleCommand mCommand5 = null;
            OracleCommand deleteCommand = new OracleCommand();
            deleteCommand.Connection = mConnection;
            deleteCommand.CommandText = "delete MVX_RAM_DTL WHERE MVX_RAM_ID = " + aProvisionDetails.RAMID.ToString();


            if (aProvisionDetails.Kraspedorithro)
            {
                mCommand1 = new OracleCommand();
                mCommand1.Connection = mConnection;
                mCommand1.CommandText = "insert into MVX_RAM_DTL   VALUES (4, " + aProvisionDetails.RAMID.ToString() + " )";

            }

            if (aProvisionDetails.Asphaltos)
            {
                mCommand2 = new OracleCommand();
                mCommand2.Connection = mConnection;
                mCommand2.CommandText = "insert into MVX_RAM_DTL  VALUES (1 ," + aProvisionDetails.RAMID.ToString() + ")";

            }

            if (aProvisionDetails.Mpeton)
            {
                mCommand3 = new OracleCommand();
                mCommand3.Connection = mConnection;
                mCommand3.CommandText = "insert into MVX_RAM_DTL  VALUES (2 ," + aProvisionDetails.RAMID.ToString() + ")";

            }

            if (aProvisionDetails.Plakes)
            {
                mCommand4 = new OracleCommand();
                mCommand4.Connection = mConnection;
                mCommand4.CommandText = "insert into MVX_RAM_DTL  VALUES (3 ," + aProvisionDetails.RAMID.ToString() + ")";
            }

            if (aProvisionDetails.Xoma)
            {
                mCommand5 = new OracleCommand();
                mCommand5.Connection = mConnection;
                mCommand5.CommandText = "insert into MVX_RAM_DTL VALUES (5 ," + aProvisionDetails.RAMID.ToString() + ")";
            }

            try
            {
                mConnection.Open();
                mCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
                if (mCommand5 != null)
                {
                    mCommand5.ExecuteNonQuery();
                }
                if (mCommand4 != null)
                {
                    mCommand4.ExecuteNonQuery();
                }
                if (mCommand3 != null)
                {
                    mCommand3.ExecuteNonQuery();
                }
                if (mCommand2 != null)
                {
                    mCommand2.ExecuteNonQuery();
                }
                if (mCommand1 != null)
                {
                    mCommand1.ExecuteNonQuery();
                }
                //mDataTable1.Load(mCommand1.ExecuteReader());
                mConnection.Close();
            }
            catch (Exception e)
            {
                if (mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                throw e;
            }
            return aProvisionDetails;
        }
    }
}