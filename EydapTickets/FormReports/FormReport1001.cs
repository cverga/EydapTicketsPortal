using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for FormReport1001
/// </summary>
public class FormReport1001 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRCheckBox xrCheckBox1;
    private XRCheckBox xrCheckBox2;
    private XRCheckBox xrCheckBox3;
    private XRCheckBox xrCheckBox4;
    private XRCheckBox xrCheckBox5;
    private XRCheckBox xrCheckBox6;
    private XRCheckBox xrCheckBox7;
    private XRCheckBox xrCheckBox8;
    private XRCheckBox xrCheckBox9;
    private XRCheckBox xrCheckBox10;
    private XRCheckBox xrCheckBox11;
    private XRCheckBox xrCheckBox12;
    private XRCheckBox xrCheckBox13;
    private XRCheckBox xrCheckBox14;
    private XRCheckBox xrCheckBox15;
    private XRCheckBox xrCheckBox16;
    private XRCheckBox xrCheckBox17;
    private XRCheckBox xrCheckBox18;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel1;
    private GroupHeaderBand groupHeaderBand1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private GroupHeaderBand groupHeaderBand2;
    private XRPanel xrPanel1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell lbl_Date_Of_Assignment;
    private XRTableCell lbl_Date_Of_Completion;
    private XRTableCell lbl_Status;
    private XRTableCell lbl_TaskId;
    private XRTableCell lbl_Comments;
    private XRTableCell lbl_TaskTypeId;
    private XRTableCell lbl_IncidentId;
    private XRTableCell lbl_Task_Description;
    private XRTableCell lbl_Synergeio_Epemvasis;
    private XRTableCell lbl_Synergeio_Elegxou;
    private XRTableCell lbl_Synergeio_Apomonosis;
    private XRTableCell lbl_Synergeio_Epanaforas;
    private XRTableCell lbl_Control_Date;
    private XRTableCell lbl_Control_Time;
    private XRTableCell lbl_Epemvasi_Vardia_Synergeiou;
    private XRTableCell lbl_Epemvasi_Arithmos_Atomon_Synergeiou;
    private XRTableCell lbl_Porisma;
    private XRTableCell lbl_Energeies;
    private XRTableCell lbl_Position_Of_Geotrisi;
    private XRTableCell lbl_Results_Of_Chemeio;
    private XRTableCell lbl_Remarks;
    private XRTableCell lbl_MAP;
    private XRTableCell lbl_Vana_Diametros;
    private XRTableCell lbl_Agogos_Diametros;
    private XRTableCell lbl_Metritis_Diametros;
    private XRTableCell lbl_Pyrosvestiki_Paroxi_Diametros;
    private XRTableCell lbl_Zoni_Piesis;
    private XRTableCell lbl_Zoni;
    private XRTableCell lbl_Eidopoiisi;
    private XRTableCell lbl_Hmerominia_Apomonosis;
    private XRTableCell lbl_Ora_Apomonosis;
    private XRTableCell lbl_Ekplisi_Termatos;
    private XRTableCell lbl_Pyrosvestikou_Geranou_Diametros;
    private XRTableCell lbl_Apomonosi_Hmerominia_Anaxorisis;
    private XRTableCell lbl_Apomonosi_Ora_Anaxorisis;
    private XRTableCell lbl_Apomonosi_Hmerominia_Afixis;
    private XRTableCell lbl_Apomonosi_Ora_Afixis;
    private XRTableCell lbl_Apomonosi_Hmerominia_Epistrofis;
    private XRTableCell lbl_Apomonosi_Ora_Epistrofis;
    private XRTableCell lbl_Hmerominia_Epanaforas;
    private XRTableCell lbl_Ora_Epanaforas;
    private XRTableCell lbl_Eidos_Epanaforas;
    private XRTableCell lbl_Epanafora_Hmerominia_Anaxorisis;
    private XRTableCell lbl_Epanafora_Ora_Anaxorisis;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRTableCell xrTableCell99;
    private XRTableCell xrTableCell100;
    private XRTableCell xrTableCell101;
    private XRTableCell xrTableCell102;
    private XRTableCell xrTableCell103;
    private XRTableCell xrTableCell104;
    private XRTableCell xrTableCell105;
    private XRTableCell xrTableCell106;
    private XRTableCell xrTableCell107;
    private XRTableCell xrTableCell108;
    private XRTableCell xrTableCell109;
    private XRTableCell xrTableCell110;
    private XRTableCell xrTableCell111;
    private XRTableCell xrTableCell112;
    private XRTableCell xrTableCell113;
    private XRTableCell xrTableCell114;
    private XRTableCell xrTableCell115;
    private XRTableCell xrTableCell116;
    private XRTableCell xrTableCell117;
    private XRTableCell xrTableCell118;
    private XRTableCell xrTableCell119;
    private XRTableCell xrTableCell120;
    private XRTableCell xrTableCell121;
    private XRTableCell xrTableCell122;
    private XRTableCell xrTableCell123;
    private XRTableCell xrTableCell124;
    private XRTableCell xrTableCell125;
    private XRTableCell xrTableCell126;
    private XRTableCell xrTableCell127;
    private XRTableCell xrTableCell128;
    private XRTableCell xrTableCell129;
    private XRTableCell xrTableCell130;
    private XRTableCell xrTableCell131;
    private XRTableCell xrTableCell132;
    private XRTableCell xrTableCell133;
    private XRTableCell xrTableCell134;
    private XRTableCell xrTableCell135;
    private XRTableCell xrTableCell136;
    private XRTableCell xrTableCell137;
    private XRTableCell xrTableCell138;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRTableCell xrTableCell141;
    private XRTableCell xrTableCell142;
    private XRTableCell xrTableCell143;
    private XRTableCell xrTableCell144;
    private XRTableCell xrTableCell145;
    private XRTableCell xrTableCell146;
    private XRTableCell xrTableCell147;
    private XRTableCell xrTableCell148;
    private XRTableCell xrTableCell149;
    private XRTableCell xrTableCell150;
    private XRTableCell xrTableCell151;
    private XRTableCell xrTableCell152;
    private XRTableCell xrTableCell153;
    private XRTableCell xrTableCell154;
    private XRTableCell xrTableCell155;
    private XRTableCell xrTableCell156;
    private XRTableCell xrTableCell157;
    private XRTableCell xrTableCell158;
    private XRTableCell xrTableCell159;
    private XRTableCell xrTableCell160;
    private XRTableCell xrTableCell161;
    private XRTableCell xrTableCell162;
    private XRTableCell xrTableCell163;
    private XRTableCell xrTableCell164;
    private XRTableCell xrTableCell165;
    private XRTableCell xrTableCell166;
    private XRTableCell xrTableCell167;
    private XRTableCell xrTableCell168;
    private XRTableCell xrTableCell169;
    private XRTableCell xrTableCell170;
    private XRTableCell xrTableCell171;
    private XRTableCell xrTableCell172;
    private XRTableCell xrTableCell173;
    private XRTableCell xrTableCell174;
    private XRTableCell xrTableCell175;
    private XRTableCell xrTableCell176;
    private XRTableCell xrTableCell177;
    private XRTableCell xrTableCell178;
    private XRTableCell xrTableCell179;
    private XRTableCell xrTableCell180;
    private XRTableCell xrTableCell181;
    private XRTableCell xrTableCell182;
    private XRTableCell xrTableCell183;
    private XRTableCell xrTableCell184;
    private XRTableCell xrTableCell185;
    private XRTableCell xrTableCell186;
    private GroupFooterBand groupFooterBand1;
    private XRLabel xrLabel2;
    private XRControlStyle Title;
    private XRControlStyle GroupCaption3;
    private XRControlStyle GroupData3;
    private XRControlStyle DetailCaption3;
    private XRControlStyle DetailData3;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle DetailCaptionBackground3;
    private XRControlStyle PageInfo;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel46;
    private XRLabel xrLabel47;
    private XRLabel xrLabel48;
    private XRLabel xrLabel49;
    private XRLabel xrLabel50;
    private XRLabel xrLabel51;
    private XRLabel xrLabel52;
    private XRLabel xrLabel53;
    private XRLabel xrLabel54;
    private XRLabel xrLabel55;
    private XRLabel xrLabel56;
    private XRLabel xrLabel57;
    private XRLabel xrLabel58;
    private XRLabel xrLabel59;
    private XRLabel xrLabel60;
    private XRLabel xrLabel61;
    private XRLabel xrLabel62;
    private XRPanel xrPanel2;
    private XRLabel xrLabel63;
    private XRLabel xrLabel64;
    private XRLabel xrLabel65;
    private XRLabel xrLabel66;
    private XRLabel xrLabel67;
    private XRLabel xrLabel68;
    private XRLabel xrLabel69;
    private XRLabel xrLabel70;
    private XRLabel xrLabel71;
    private XRLabel xrLabel72;
    private XRLabel xrLabel73;
    private XRLabel xrLabel74;
    private XRLabel xrLabel75;
    private XRLabel xrLabel76;
    private XRLabel xrLabel77;
    private XRLabel xrLabel78;
    private XRLabel xrLabel79;
    private XRLabel xrLabel80;
    private XRLabel xrLabel81;
    private XRLabel xrLabel82;
    private XRLabel xrLabel83;
    private XRLabel xrLabel84;
    private XRLabel xrLabel85;
    private XRLabel xrLabel86;
    private XRLabel xrLabel87;
    private XRLabel xrLabel88;
    private XRLabel xrLabel89;
    private XRLabel xrLabel90;
    private XRLabel xrLabel91;
    private XRLabel xrLabel92;
    private XRLabel xrLabel93;
    private XRLabel xrLabel94;
    private XRLabel xrLabel95;
    private XRLabel xrLabel96;
    private XRLabel xrLabel97;
    private XRLabel xrLabel98;
    private XRLabel xrLabel99;
    private XRLabel xrLabel100;
    private XRLabel xrLabel101;
    private XRLabel xrLabel102;
    private XRLabel xrLabel103;
    private XRLabel xrLabel104;
    private XRLabel xrLabel105;
    private XRLabel xrLabel106;
    private XRLabel xrLabel107;
    private XRLabel xrLabel108;
    private XRLabel xrLabel109;
    private XRLabel xrLabel110;
    private XRLabel xrLabel111;
    private XRLabel xrLabel112;
    private XRLabel xrLabel113;
    private XRLabel xrLabel114;
    private XRLabel xrLabel115;
    private XRLabel xrLabel116;
    private XRLabel xrLabel117;
    private XRLabel xrLabel118;
    private XRLabel xrLabel119;
    private XRLabel xrLabel120;
    private XRLabel xrLabel121;
    private XRLabel xrLabel122;
    private XRLabel xrLabel123;
    private XRLabel xrLabel124;
    private XRLabel xrLabel125;
    private XRLabel xrLabel126;
    private XRLabel xrLabel127;
    private XRLabel xrLabel128;
    private XRLabel xrLabel129;
    private XRLabel xrLabel130;
    private XRLabel xrLabel131;
    private XRLabel xrLabel132;
    private XRLabel xrLabel133;
    private XRLabel xrLabel134;
    private XRLabel xrLabel135;
    private XRLabel xrLabel136;
    private XRLabel xrLabel137;
    private XRLabel xrLabel138;
    private XRLabel xrLabel139;
    private XRLabel xrLabel140;
    private XRLabel xrLabel141;
    private XRLabel xrLabel142;
    private XRLabel xrLabel143;
    private XRLabel xrLabel144;
    private XRLabel xrLabel145;
    private XRLabel xrLabel146;
    private XRLabel xrLabel147;
    private XRLabel xrLabel148;
    private XRLabel xrLabel149;
    private XRLabel xrLabel150;
    private XRLabel xrLabel151;
    private XRLabel xrLabel152;
    private XRLabel xrLabel153;
    private XRLabel xrLabel154;
    private XRLabel xrLabel155;
    private XRLabel xrLabel156;
    private XRLabel xrLabel157;
    private XRLabel xrLabel158;
    private XRLabel xrLabel159;
    private XRLabel xrLabel160;
    private XRLabel xrLabel161;
    private XRLabel xrLabel162;
    private XRLabel xrLabel163;
    private XRLabel xrLabel164;
    private XRLabel xrLabel165;
    private XRLabel xrLabel166;
    private XRLabel xrLabel167;
    private XRLabel xrLabel168;
    private XRLabel xrLabel169;
    private XRLabel xrLabel170;
    private XRLabel xrLabel171;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public FormReport1001()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column9 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression9 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column10 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression10 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column12 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression12 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column13 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression13 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column14 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression14 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column15 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression15 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column16 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression16 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column17 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression17 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column18 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression18 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column19 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression19 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column20 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression20 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column21 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression21 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column22 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression22 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column23 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression23 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column24 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression24 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column25 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression25 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column26 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression26 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column27 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression27 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column28 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression28 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column29 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression29 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column30 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression30 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column31 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression31 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column32 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression32 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column33 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression33 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column34 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression34 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column35 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression35 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column36 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression36 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column37 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression37 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column38 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression38 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column39 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression39 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column40 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression40 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column41 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression41 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column42 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression42 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column43 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression43 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column44 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression44 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column45 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression45 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column46 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression46 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column47 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression47 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column48 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression48 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column49 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression49 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column50 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression50 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column51 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression51 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column52 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression52 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column53 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression53 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column54 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression54 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column55 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression55 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column56 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression56 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column57 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression57 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column58 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression58 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column59 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression59 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column60 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression60 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column61 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression61 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column62 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression62 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column63 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression63 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column64 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression64 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column65 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression65 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column66 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression66 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column67 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression67 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column68 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression68 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column69 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression69 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column70 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression70 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column71 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression71 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column72 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression72 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column73 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression73 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column74 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression74 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column75 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression75 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column76 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression76 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column77 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression77 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column78 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression78 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column79 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression79 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column80 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression80 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column81 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression81 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column82 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression82 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column83 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression83 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column84 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression84 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column85 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression85 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column86 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression86 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column87 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression87 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column88 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression88 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column89 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression89 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column90 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression90 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column91 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression91 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column92 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression92 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column93 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression93 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column94 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression94 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column95 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression95 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column96 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression96 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column97 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression97 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column98 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression98 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column99 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression99 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column100 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression100 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column101 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression101 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column102 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression102 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column103 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression103 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column104 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression104 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column105 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression105 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column106 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression106 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column107 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression107 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column108 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression108 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column109 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression109 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column110 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression110 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column111 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression111 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column112 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression112 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column113 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression113 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column114 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression114 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column115 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression115 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column116 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression116 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column117 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression117 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column118 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression118 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column119 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression119 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column120 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression120 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column121 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression121 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column122 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression122 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column123 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression123 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column124 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression124 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column125 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression125 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column126 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression126 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column127 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression127 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column128 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression128 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column129 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression129 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column130 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression130 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column131 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression131 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column132 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression132 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column133 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression133 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column134 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression134 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column135 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression135 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column136 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression136 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column137 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression137 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column138 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression138 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column139 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression139 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column140 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression140 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column141 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression141 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column142 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression142 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column143 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression143 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column144 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression144 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column145 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression145 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column146 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression146 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column147 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression147 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column148 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression148 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column149 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression149 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column150 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression150 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column151 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression151 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column152 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression152 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column153 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression153 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column154 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression154 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column155 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression155 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column156 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression156 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column157 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression157 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column158 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression158 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column159 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression159 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column160 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression160 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column161 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression161 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column162 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression162 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column163 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression163 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column164 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression164 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column165 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression165 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column166 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression166 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column167 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression167 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column168 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression168 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column169 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression169 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column170 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression170 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column171 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression171 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column172 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression172 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column173 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression173 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column174 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression174 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column175 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression175 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column176 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression176 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column177 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression177 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column178 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression178 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column179 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression179 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column180 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression180 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column181 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression181 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column182 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression182 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column183 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression183 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column184 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression184 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column185 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression185 = new DevExpress.DataAccess.Sql.ColumnExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport1001));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrCheckBox14 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox13 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox15 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox7 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox18 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox6 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox16 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox17 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox2 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox8 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox3 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel90 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox4 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox5 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel94 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel95 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel100 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel105 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel106 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel107 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel108 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel109 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel110 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel111 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox9 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox10 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox11 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox12 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel114 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel116 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel117 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel118 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel119 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel120 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel121 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel122 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel123 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel124 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel125 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel126 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel127 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel128 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel129 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel130 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel131 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel132 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel133 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel134 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel135 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel136 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel137 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel138 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel139 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel140 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel141 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel142 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel143 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel144 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel145 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel146 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel147 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel148 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel149 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel150 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel151 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel152 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel153 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel154 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel155 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel156 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel157 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel158 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel159 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel160 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel161 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel162 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel163 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel164 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel165 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel166 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel167 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel168 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel169 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel170 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel171 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lbl_Date_Of_Assignment = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Date_Of_Completion = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Status = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_TaskId = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Comments = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_TaskTypeId = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_IncidentId = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Task_Description = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Synergeio_Epemvasis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Synergeio_Elegxou = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Synergeio_Apomonosis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Synergeio_Epanaforas = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Control_Date = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Control_Time = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Epemvasi_Vardia_Synergeiou = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Porisma = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Energeies = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Position_Of_Geotrisi = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Results_Of_Chemeio = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Remarks = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_MAP = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Vana_Diametros = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Agogos_Diametros = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Metritis_Diametros = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Pyrosvestiki_Paroxi_Diametros = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Zoni_Piesis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Zoni = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Eidopoiisi = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Hmerominia_Apomonosis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Ora_Apomonosis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Ekplisi_Termatos = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Pyrosvestikou_Geranou_Diametros = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Hmerominia_Anaxorisis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Ora_Anaxorisis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Hmerominia_Afixis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Ora_Afixis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Hmerominia_Epistrofis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Apomonosi_Ora_Epistrofis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Hmerominia_Epanaforas = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Ora_Epanaforas = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Eidos_Epanaforas = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Epanafora_Hmerominia_Anaxorisis = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_Epanafora_Ora_Anaxorisis = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell126 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell127 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell128 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell129 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell130 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell131 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell133 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell134 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell135 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell136 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell137 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell138 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell142 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell148 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell149 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell150 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell151 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell152 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell157 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell158 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell159 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell160 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell161 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell162 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell163 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell164 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell165 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell166 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell167 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell168 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell169 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell170 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell171 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell172 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell173 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell174 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell175 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell176 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell177 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell178 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell179 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell180 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell181 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell182 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell183 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell184 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell185 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell186 = new DevExpress.XtraReports.UI.XRTableCell();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrCheckBox9,
            this.xrCheckBox10,
            this.xrCheckBox4,
            this.xrCheckBox11,
            this.xrCheckBox5,
            this.xrCheckBox3,
            this.xrCheckBox12,
            this.xrCheckBox14,
            this.xrCheckBox13,
            this.xrCheckBox15,
            this.xrCheckBox7,
            this.xrCheckBox18,
            this.xrCheckBox6,
            this.xrCheckBox16,
            this.xrCheckBox17,
            this.xrCheckBox2,
            this.xrCheckBox8,
            this.xrCheckBox1,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel40,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel45,
            this.xrLabel46,
            this.xrLabel47,
            this.xrLabel48,
            this.xrLabel49,
            this.xrLabel50,
            this.xrLabel51,
            this.xrLabel52,
            this.xrLabel53,
            this.xrLabel54,
            this.xrLabel55,
            this.xrLabel56,
            this.xrLabel57,
            this.xrLabel58,
            this.xrLabel59,
            this.xrLabel60,
            this.xrLabel61,
            this.xrLabel62,
            this.xrPanel2,
            this.xrLabel63,
            this.xrLabel64,
            this.xrLabel65,
            this.xrLabel66,
            this.xrLabel67,
            this.xrLabel68,
            this.xrLabel69,
            this.xrLabel70,
            this.xrLabel71,
            this.xrLabel72,
            this.xrLabel73,
            this.xrLabel74,
            this.xrLabel75,
            this.xrLabel76,
            this.xrLabel77,
            this.xrLabel78,
            this.xrLabel79,
            this.xrLabel80,
            this.xrLabel81,
            this.xrLabel82,
            this.xrLabel83,
            this.xrLabel84,
            this.xrLabel85,
            this.xrLabel86,
            this.xrLabel87,
            this.xrLabel88,
            this.xrLabel89,
            this.xrLabel90,
            this.xrLabel91,
            this.xrLabel92,
            this.xrLabel93,
            this.xrLabel94,
            this.xrLabel95,
            this.xrLabel96,
            this.xrLabel97,
            this.xrLabel98,
            this.xrLabel99,
            this.xrLabel100,
            this.xrLabel101,
            this.xrLabel102,
            this.xrLabel103,
            this.xrLabel104,
            this.xrLabel105,
            this.xrLabel106,
            this.xrLabel107,
            this.xrLabel108,
            this.xrLabel109,
            this.xrLabel110,
            this.xrLabel111,
            this.xrLabel112,
            this.xrLabel113,
            this.xrLabel114,
            this.xrLabel115,
            this.xrLabel116,
            this.xrLabel117,
            this.xrLabel118,
            this.xrLabel119,
            this.xrLabel120,
            this.xrLabel121,
            this.xrLabel122,
            this.xrLabel123,
            this.xrLabel124,
            this.xrLabel125,
            this.xrLabel126,
            this.xrLabel127,
            this.xrLabel128,
            this.xrLabel129,
            this.xrLabel130,
            this.xrLabel131,
            this.xrLabel132,
            this.xrLabel133,
            this.xrLabel134,
            this.xrLabel135,
            this.xrLabel136,
            this.xrLabel137,
            this.xrLabel138,
            this.xrLabel139,
            this.xrLabel140,
            this.xrLabel141,
            this.xrLabel142,
            this.xrLabel143,
            this.xrLabel144,
            this.xrLabel145,
            this.xrLabel146,
            this.xrLabel147,
            this.xrLabel148,
            this.xrLabel149,
            this.xrLabel150,
            this.xrLabel151,
            this.xrLabel152,
            this.xrLabel153,
            this.xrLabel154,
            this.xrLabel155,
            this.xrLabel156,
            this.xrLabel157,
            this.xrLabel158,
            this.xrLabel159,
            this.xrLabel160,
            this.xrLabel161,
            this.xrLabel162,
            this.xrLabel163,
            this.xrLabel164,
            this.xrLabel165,
            this.xrLabel166,
            this.xrLabel167,
            this.xrLabel168,
            this.xrLabel169,
            this.xrLabel170,
            this.xrLabel171});
            this.Detail.HeightF = 1798.958F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrCheckBox14
            //
            this.xrCheckBox14.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox14.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiApolimantikonMeSwan]")});
            this.xrCheckBox14.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox14.LocationFloat = new DevExpress.Utils.PointFloat(3.453533F, 281.6321F);
            this.xrCheckBox14.Name = "xrCheckBox14";
            this.xrCheckBox14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox14.SizeF = new System.Drawing.SizeF(129.379F, 2F);
            //
            // xrCheckBox13
            //
            this.xrCheckBox13.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox13.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeFotometroLovipond]")});
            this.xrCheckBox13.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox13.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 252.9861F);
            this.xrCheckBox13.Name = "xrCheckBox13";
            this.xrCheckBox13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox13.SizeF = new System.Drawing.SizeF(95.25233F, 2F);
            //
            // xrCheckBox15
            //
            this.xrCheckBox15.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox15.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiApolimantikonMePalintest]")});
            this.xrCheckBox15.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox15.LocationFloat = new DevExpress.Utils.PointFloat(466.4766F, 474.2937F);
            this.xrCheckBox15.Name = "xrCheckBox15";
            this.xrCheckBox15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox15.SizeF = new System.Drawing.SizeF(119.9443F, 2F);
            //
            // xrCheckBox7
            //
            this.xrCheckBox7.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox7.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[KatastasiPRV]")});
            this.xrCheckBox7.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox7.LocationFloat = new DevExpress.Utils.PointFloat(108.6135F, 840.2721F);
            this.xrCheckBox7.Name = "xrCheckBox7";
            this.xrCheckBox7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox7.SizeF = new System.Drawing.SizeF(117.8202F, 2F);
            //
            // xrCheckBox18
            //
            this.xrCheckBox18.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox18.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[Propagated]")});
            this.xrCheckBox18.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox18.LocationFloat = new DevExpress.Utils.PointFloat(314.0958F, 943.8196F);
            this.xrCheckBox18.Name = "xrCheckBox18";
            this.xrCheckBox18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox18.SizeF = new System.Drawing.SizeF(78.84708F, 2F);
            //
            // xrCheckBox6
            //
            this.xrCheckBox6.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox6.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[EidosProblimatos]")});
            this.xrCheckBox6.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox6.LocationFloat = new DevExpress.Utils.PointFloat(399.3455F, 936.3488F);
            this.xrCheckBox6.Name = "xrCheckBox6";
            this.xrCheckBox6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox6.SizeF = new System.Drawing.SizeF(88.38239F, 2F);
            //
            // xrCheckBox16
            //
            this.xrCheckBox16.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox16.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[ElegxosPiesisGiaEidikiParoxi]")});
            this.xrCheckBox16.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox16.LocationFloat = new DevExpress.Utils.PointFloat(312.0644F, 644.6644F);
            this.xrCheckBox16.Name = "xrCheckBox16";
            this.xrCheckBox16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox16.SizeF = new System.Drawing.SizeF(73.04758F, 2F);
            //
            // xrCheckBox17
            //
            this.xrCheckBox17.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox17.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[Reithro]")});
            this.xrCheckBox17.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox17.LocationFloat = new DevExpress.Utils.PointFloat(316.0437F, 1370.369F);
            this.xrCheckBox17.Name = "xrCheckBox17";
            this.xrCheckBox17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox17.SizeF = new System.Drawing.SizeF(149.7246F, 2F);
            //
            // xrCheckBox2
            //
            this.xrCheckBox2.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[KatastasiVanas]")});
            this.xrCheckBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox2.LocationFloat = new DevExpress.Utils.PointFloat(313.9621F, 910.0405F);
            this.xrCheckBox2.Name = "xrCheckBox2";
            this.xrCheckBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox2.SizeF = new System.Drawing.SizeF(130.8244F, 2F);
            //
            // xrCheckBox8
            //
            this.xrCheckBox8.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox8.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[Idiotiko]")});
            this.xrCheckBox8.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox8.LocationFloat = new DevExpress.Utils.PointFloat(318.2712F, 1722.454F);
            this.xrCheckBox8.Name = "xrCheckBox8";
            this.xrCheckBox8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox8.SizeF = new System.Drawing.SizeF(155.6229F, 2F);
            //
            // xrCheckBox1
            //
            this.xrCheckBox1.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[TopothetisiKatagrafikou]")});
            this.xrCheckBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox1.LocationFloat = new DevExpress.Utils.PointFloat(20.20935F, 1758.021F);
            this.xrCheckBox1.Name = "xrCheckBox1";
            this.xrCheckBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox1.SizeF = new System.Drawing.SizeF(159.9942F, 2F);
            //
            // xrLabel6
            //
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateOfAssignment]")});
            this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(466.8726F, 276.3195F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(175.2355F, 21.25F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "fld_Date_Of_Assignment";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel7
            //
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateOfCompletion]")});
            this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(466.8727F, 297.5695F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(151.0766F, 21.77087F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrTableCell188";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel8
            //
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(149.769F, 226.5278F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(109.268F, 26.45833F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrTableCell189";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel9
            //
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Task_Id]")});
            this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(323.3062F, 1660.424F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(126.9973F, 16.04166F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrTableCell190";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel10
            //
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Comments]")});
            this.xrLabel10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(333.1271F, 201.2732F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(107.2552F, 21.25003F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrTableCell191";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel11
            //
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TaskTypeId]")});
            this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(23.36057F, 1698.704F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(219.9777F, 23.74998F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrTableCell192";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel12
            //
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Incident_Id]")});
            this.xrLabel12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(23.36057F, 1630.787F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(203.0731F, 21.24998F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrTableCell193";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel13
            //
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Task_Description]")});
            this.xrLabel13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(440.7084F, 252.9861F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(202.88F, 23.33333F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrTableCell194";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel14
            //
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SynergeioEpemvasis]")});
            this.xrLabel14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(314.9951F, 1259.277F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(261.3142F, 25.41666F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrTableCell195";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel15
            //
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SynergeioElegxou]")});
            this.xrLabel15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(26.36679F, 1450.585F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(236.2742F, 23.33331F);
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrTableCell196";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel16
            //
            this.xrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SynergeioApomonosis]")});
            this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(26.78538F, 1370.817F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(239.0571F, 20.20836F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseForeColor = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrTableCell197";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel17
            //
            this.xrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SynergeioEpanaforas]")});
            this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(23.05512F, 1496.001F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(245.8857F, 20.20834F);
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.StylePriority.UsePadding = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrTableCell198";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel18
            //
            this.xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ControlDate]")});
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(22.9915F, 1611.62F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(207.877F, 19.16666F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseForeColor = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrTableCell199";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel19
            //
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ControlTime]")});
            this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(321.446F, 1706.412F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(249.1365F, 16.04164F);
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "xrTableCell200";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel20
            //
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epemvasi_VardiaSynergeiou]")});
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(23.36057F, 1583.287F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(197.3771F, 22.29167F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "xrTableCell201";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel21
            //
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epemvasi_ArithmosAtomonSynergeiou]")});
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(318.2712F, 981.0996F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(173.8198F, 23.33333F);
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrTableCell202";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel22
            //
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Porisma]")});
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(154.6429F, 201.2732F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(167.1308F, 21.25002F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UsePadding = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "xrTableCell203";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel23
            //
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Energeies]")});
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel23.ForeColor = System.Drawing.Color.Black;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(459.7638F, 219.2825F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(186.3428F, 18.00925F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseForeColor = false;
            this.xrLabel23.StylePriority.UsePadding = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrTableCell204";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel24
            //
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PositionOfGeotrisi]")});
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(322.0977F, 1644.729F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(243.8307F, 15.69444F);
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "xrTableCell205";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel25
            //
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ResultsOfChemeio]")});
            this.xrLabel25.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel25.ForeColor = System.Drawing.Color.Black;
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(466.4765F, 201.2732F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(177.1119F, 18.00926F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseForeColor = false;
            this.xrLabel25.StylePriority.UsePadding = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "xrTableCell206";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel26
            //
            this.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Remarks]")});
            this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel26.ForeColor = System.Drawing.Color.Black;
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(371.9808F, 237.2917F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(274.9223F, 15.69443F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseForeColor = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "xrTableCell207";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel27
            //
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel27.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MAP]")});
            this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel27.ForeColor = System.Drawing.Color.Black;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(314.8826F, 869.0162F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(187.9635F, 18.00925F);
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseForeColor = false;
            this.xrLabel27.StylePriority.UsePadding = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "xrTableCell208";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel28
            //
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel28.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VanaDiametros]")});
            this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel28.ForeColor = System.Drawing.Color.Black;
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(20.91535F, 1722.454F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(266.4329F, 23.79631F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseForeColor = false;
            this.xrLabel28.StylePriority.UsePadding = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "xrTableCell209";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel29
            //
            this.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel29.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgogosDiametros]")});
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(25.09757F, 1352.02F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(240.7449F, 16.85188F);
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseForeColor = false;
            this.xrLabel29.StylePriority.UsePadding = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "xrTableCell210";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel30
            //
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel30.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MetritisDiametros]")});
            this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel30.ForeColor = System.Drawing.Color.Black;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(311.3002F, 1223.015F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(249.8083F, 19.16666F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseForeColor = false;
            this.xrLabel30.StylePriority.UsePadding = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrTableCell211";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel31
            //
            this.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel31.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PyrosvestikiParoxiDiametros]")});
            this.xrLabel31.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel31.ForeColor = System.Drawing.Color.Black;
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(21.1883F, 1005.301F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(160.3805F, 21.48148F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseForeColor = false;
            this.xrLabel31.StylePriority.UsePadding = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrTableCell212";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel32
            //
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ZoniPiesis]")});
            this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel32.ForeColor = System.Drawing.Color.Black;
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(316.5631F, 1111.516F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(144.4281F, 22.29166F);
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseForeColor = false;
            this.xrLabel32.StylePriority.UsePadding = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "xrTableCell213";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel33
            //
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel33.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Zoni]")});
            this.xrLabel33.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel33.ForeColor = System.Drawing.Color.Black;
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(323.3062F, 1608.71F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(54.79297F, 18.00925F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseForeColor = false;
            this.xrLabel33.StylePriority.UsePadding = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "xrTableCell214";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel34
            //
            this.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Eidopoiisi]")});
            this.xrLabel34.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel34.ForeColor = System.Drawing.Color.Black;
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(18.22206F, 1675.371F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(216.4696F, 23.33333F);
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseForeColor = false;
            this.xrLabel34.StylePriority.UsePadding = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "xrTableCell215";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel35
            //
            this.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaApomonosis]")});
            this.xrLabel35.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel35.ForeColor = System.Drawing.Color.Black;
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(25.80563F, 1528.912F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(230.0053F, 19.16663F);
            this.xrLabel35.StylePriority.UseBorders = false;
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseForeColor = false;
            this.xrLabel35.StylePriority.UsePadding = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "xrTableCell216";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel36
            //
            this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraApomonosis]")});
            this.xrLabel36.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel36.ForeColor = System.Drawing.Color.Black;
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(320.9367F, 1584.914F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(243.2791F, 23.7963F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseForeColor = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "xrTableCell217";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel37
            //
            this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel37.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EkplisiTermatos]")});
            this.xrLabel37.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel37.ForeColor = System.Drawing.Color.Black;
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(316.0437F, 784.2477F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(158.118F, 22.63889F);
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseForeColor = false;
            this.xrLabel37.StylePriority.UsePadding = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "xrTableCell218";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel38
            //
            this.xrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PyrosvestikouGeranouDiametros]")});
            this.xrLabel38.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel38.ForeColor = System.Drawing.Color.Black;
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(320.9367F, 1564.59F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(194.0655F, 20.32408F);
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseForeColor = false;
            this.xrLabel38.StylePriority.UsePadding = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "xrTableCell219";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel39
            //
            this.xrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_HmerominiaAnaxorisis]")});
            this.xrLabel39.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel39.ForeColor = System.Drawing.Color.Black;
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(316.0437F, 758.1367F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(217.2523F, 26.11111F);
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseForeColor = false;
            this.xrLabel39.StylePriority.UsePadding = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "xrTableCell220";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel40
            //
            this.xrLabel40.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel40.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_OraAnaxorisis]")});
            this.xrLabel40.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel40.ForeColor = System.Drawing.Color.Black;
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(26.36681F, 1400F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(185.0602F, 16.04166F);
            this.xrLabel40.StylePriority.UseBorders = false;
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseForeColor = false;
            this.xrLabel40.StylePriority.UsePadding = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "xrTableCell221";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel41
            //
            this.xrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_HmerominiaAfixis]")});
            this.xrLabel41.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel41.ForeColor = System.Drawing.Color.Black;
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(22.9915F, 1652.037F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(160.177F, 23.33336F);
            this.xrLabel41.StylePriority.UseBorders = false;
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseForeColor = false;
            this.xrLabel41.StylePriority.UsePadding = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "xrTableCell222";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel42
            //
            this.xrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_OraAfixis]")});
            this.xrLabel42.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel42.ForeColor = System.Drawing.Color.Black;
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(318.2712F, 1133.808F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(190.2317F, 23.33336F);
            this.xrLabel42.StylePriority.UseBorders = false;
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseForeColor = false;
            this.xrLabel42.StylePriority.UsePadding = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "xrTableCell223";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel43
            //
            this.xrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel43.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_HmerominiaEpistrofis]")});
            this.xrLabel43.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel43.ForeColor = System.Drawing.Color.Black;
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(317.4877F, 1676.465F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(295.5139F, 23.33333F);
            this.xrLabel43.StylePriority.UseBorders = false;
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseForeColor = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "xrTableCell224";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel44
            //
            this.xrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel44.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_OraEpistrofis]")});
            this.xrLabel44.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel44.ForeColor = System.Drawing.Color.Black;
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(321.3716F, 1626.719F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(269.0049F, 15.69441F);
            this.xrLabel44.StylePriority.UseBorders = false;
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseForeColor = false;
            this.xrLabel44.StylePriority.UsePadding = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "xrTableCell225";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel45
            //
            this.xrLabel45.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel45.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaEpanaforas]")});
            this.xrLabel45.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel45.ForeColor = System.Drawing.Color.Black;
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(18.22206F, 1298.205F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(257.1725F, 14.53703F);
            this.xrLabel45.StylePriority.UseBorders = false;
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UseForeColor = false;
            this.xrLabel45.StylePriority.UsePadding = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "xrTableCell226";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel46
            //
            this.xrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel46.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraEpanaforas]")});
            this.xrLabel46.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel46.ForeColor = System.Drawing.Color.Black;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(24.28727F, 1473.918F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(183.2778F, 18.00929F);
            this.xrLabel46.StylePriority.UseBorders = false;
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseForeColor = false;
            this.xrLabel46.StylePriority.UsePadding = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "xrTableCell227";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel47
            //
            this.xrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel47.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosEpanaforas]")});
            this.xrLabel47.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel47.ForeColor = System.Drawing.Color.Black;
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(317.6706F, 1051.516F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(277.705F, 20.32407F);
            this.xrLabel47.StylePriority.UseBorders = false;
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseForeColor = false;
            this.xrLabel47.StylePriority.UsePadding = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "xrTableCell228";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel48
            //
            this.xrLabel48.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel48.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_HmerominiaAnaxorisis]")});
            this.xrLabel48.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel48.ForeColor = System.Drawing.Color.Black;
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(22.51542F, 1272.094F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(246.3703F, 20.8333F);
            this.xrLabel48.StylePriority.UseBorders = false;
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UseForeColor = false;
            this.xrLabel48.StylePriority.UsePadding = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "xrTableCell229";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel49
            //
            this.xrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel49.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_OraAnaxorisis]")});
            this.xrLabel49.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel49.ForeColor = System.Drawing.Color.Black;
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(314.9487F, 1071.84F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(199.3877F, 15.69443F);
            this.xrLabel49.StylePriority.UseBorders = false;
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseForeColor = false;
            this.xrLabel49.StylePriority.UsePadding = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "xrTableCell230";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel50
            //
            this.xrLabel50.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel50.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_HmerominiaAfixis]")});
            this.xrLabel50.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel50.ForeColor = System.Drawing.Color.Black;
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(312.9035F, 1519.769F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(222.864F, 23.33331F);
            this.xrLabel50.StylePriority.UseBorders = false;
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseForeColor = false;
            this.xrLabel50.StylePriority.UsePadding = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.Text = "xrTableCell231";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel51
            //
            this.xrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel51.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_OraAfixis]")});
            this.xrLabel51.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel51.ForeColor = System.Drawing.Color.Black;
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(316.5303F, 691.0533F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(183.7512F, 19.16667F);
            this.xrLabel51.StylePriority.UseBorders = false;
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseForeColor = false;
            this.xrLabel51.StylePriority.UsePadding = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "xrTableCell232";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel52
            //
            this.xrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel52.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_HmerominiaEpistrofis]")});
            this.xrLabel52.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel52.ForeColor = System.Drawing.Color.Black;
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(18.89475F, 1251.77F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(216.0255F, 18.00929F);
            this.xrLabel52.StylePriority.UseBorders = false;
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseForeColor = false;
            this.xrLabel52.StylePriority.UsePadding = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "xrTableCell233";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel53
            //
            this.xrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel53.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_OraEpistrofis]")});
            this.xrLabel53.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel53.ForeColor = System.Drawing.Color.Black;
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(20.77468F, 1225.335F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(132.5536F, 16.85184F);
            this.xrLabel53.StylePriority.UseBorders = false;
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseForeColor = false;
            this.xrLabel53.StylePriority.UsePadding = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "xrTableCell234";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel54
            //
            this.xrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel54.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_ArithmosAtomonSynergeiou]")});
            this.xrLabel54.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel54.ForeColor = System.Drawing.Color.Black;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(312.5938F, 1501.76F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(116.8644F, 18.00926F);
            this.xrLabel54.StylePriority.UseBorders = false;
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseForeColor = false;
            this.xrLabel54.StylePriority.UsePadding = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "xrTableCell235";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel55
            //
            this.xrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel55.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_ArithmosAtomonSynergeiou]")});
            this.xrLabel55.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel55.ForeColor = System.Drawing.Color.Black;
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(316.5631F, 1030.266F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(176.8369F, 21.25003F);
            this.xrLabel55.StylePriority.UseBorders = false;
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseForeColor = false;
            this.xrLabel55.StylePriority.UsePadding = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "xrTableCell236";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel56
            //
            this.xrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_VardiaSynergeiou]")});
            this.xrLabel56.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel56.ForeColor = System.Drawing.Color.Black;
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(438.8635F, 1501.76F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(124.1808F, 18.00929F);
            this.xrLabel56.StylePriority.UseBorders = false;
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseForeColor = false;
            this.xrLabel56.StylePriority.UsePadding = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "xrTableCell237";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel57
            //
            this.xrLabel57.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel57.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_VardiaSynergeiou]")});
            this.xrLabel57.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel57.ForeColor = System.Drawing.Color.Black;
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(319.353F, 1766.516F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(200.0277F, 23.33333F);
            this.xrLabel57.StylePriority.UseBorders = false;
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseForeColor = false;
            this.xrLabel57.StylePriority.UsePadding = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "xrTableCell238";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel58
            //
            this.xrLabel58.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel58.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_ArirthosVanonPouXeiristikan]")});
            this.xrLabel58.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel58.ForeColor = System.Drawing.Color.Black;
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(22.3647F, 1548.079F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(235.9797F, 19.16666F);
            this.xrLabel58.StylePriority.UseBorders = false;
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.StylePriority.UseForeColor = false;
            this.xrLabel58.StylePriority.UsePadding = false;
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.Text = "xrTableCell239";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel59
            //
            this.xrLabel59.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel59.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_KatastasiVanonPouXeiristikan]")});
            this.xrLabel59.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel59.ForeColor = System.Drawing.Color.Black;
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(316.0437F, 711.3774F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(147.9056F, 20.32404F);
            this.xrLabel59.StylePriority.UseBorders = false;
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.StylePriority.UseForeColor = false;
            this.xrLabel59.StylePriority.UsePadding = false;
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.Text = "xrTableCell240";
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel60
            //
            this.xrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel60.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Apomonosi_ThesiVanonPouXeiristikan]")});
            this.xrLabel60.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel60.ForeColor = System.Drawing.Color.Black;
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(312.4127F, 1480.927F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(151.9813F, 20.8333F);
            this.xrLabel60.StylePriority.UseBorders = false;
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseForeColor = false;
            this.xrLabel60.StylePriority.UsePadding = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "xrTableCell241";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel61
            //
            this.xrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel61.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SyntetagmenesVlavis]")});
            this.xrLabel61.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel61.ForeColor = System.Drawing.Color.Black;
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(27.07243F, 1430.261F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(159.9942F, 20.32407F);
            this.xrLabel61.StylePriority.UseBorders = false;
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.StylePriority.UseForeColor = false;
            this.xrLabel61.StylePriority.UsePadding = false;
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.Text = "xrTableCell242";
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel62
            //
            this.xrLabel62.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel62.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgogosYliko]")});
            this.xrLabel62.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel62.ForeColor = System.Drawing.Color.Black;
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(313.5058F, 737.8126F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(74.3865F, 20.32408F);
            this.xrLabel62.StylePriority.UseBorders = false;
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseForeColor = false;
            this.xrLabel62.StylePriority.UsePadding = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "xrTableCell243";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrPanel2
            //
            this.xrPanel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPanel2.KeepTogether = false;
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(54.56708F, 28.12497F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrPanel2.SizeF = new System.Drawing.SizeF(451.7204F, 127.5F);
            this.xrPanel2.StylePriority.UseBorders = false;
            this.xrPanel2.StylePriority.UseFont = false;
            this.xrPanel2.StylePriority.UseForeColor = false;
            this.xrPanel2.StylePriority.UsePadding = false;
            this.xrPanel2.StylePriority.UseTextAlignment = false;
            //
            // xrLabel63
            //
            this.xrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel63.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GnomateusiThesi]")});
            this.xrLabel63.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel63.ForeColor = System.Drawing.Color.Black;
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(22.05082F, 1188.963F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(162.6496F, 21.25F);
            this.xrLabel63.StylePriority.UseBorders = false;
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseForeColor = false;
            this.xrLabel63.StylePriority.UsePadding = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "xrTableCell245";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel64
            //
            this.xrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel64.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GnomateusiMikos]")});
            this.xrLabel64.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel64.ForeColor = System.Drawing.Color.Black;
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(321.3032F, 1005.532F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(165.258F, 21.25003F);
            this.xrLabel64.StylePriority.UseBorders = false;
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseForeColor = false;
            this.xrLabel64.StylePriority.UsePadding = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "xrTableCell246";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel65
            //
            this.xrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel65.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GnomateusiDiametros]")});
            this.xrLabel65.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel65.ForeColor = System.Drawing.Color.Black;
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(312.0644F, 1459.156F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(208.9853F, 21.77084F);
            this.xrLabel65.StylePriority.UseBorders = false;
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseForeColor = false;
            this.xrLabel65.StylePriority.UsePadding = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.Text = "xrTableCell247";
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel66
            //
            this.xrLabel66.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel66.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GnomateusiYliko]")});
            this.xrLabel66.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel66.ForeColor = System.Drawing.Color.Black;
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(527.3946F, 1375.765F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(110.6262F, 21.77084F);
            this.xrLabel66.StylePriority.UseBorders = false;
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.StylePriority.UseForeColor = false;
            this.xrLabel66.StylePriority.UsePadding = false;
            this.xrLabel66.StylePriority.UseTextAlignment = false;
            this.xrLabel66.Text = "xrTableCell248";
            this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel67
            //
            this.xrLabel67.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel67.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Attachments]")});
            this.xrLabel67.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel67.ForeColor = System.Drawing.Color.Black;
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(316.0471F, 1416.042F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(184.8525F, 19.16669F);
            this.xrLabel67.StylePriority.UseBorders = false;
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.StylePriority.UseForeColor = false;
            this.xrLabel67.StylePriority.UsePadding = false;
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.Text = "xrTableCell249";
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel68
            //
            this.xrLabel68.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel68.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_ArirthosVanonPouXeiristikan]")});
            this.xrLabel68.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel68.ForeColor = System.Drawing.Color.Black;
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(314.0645F, 1435.209F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(192.2229F, 21.25003F);
            this.xrLabel68.StylePriority.UseBorders = false;
            this.xrLabel68.StylePriority.UseFont = false;
            this.xrLabel68.StylePriority.UseForeColor = false;
            this.xrLabel68.StylePriority.UsePadding = false;
            this.xrLabel68.StylePriority.UseTextAlignment = false;
            this.xrLabel68.Text = "xrTableCell250";
            this.xrLabel68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel69
            //
            this.xrLabel69.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel69.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_KatastasiVanonPouXeiristikan]")});
            this.xrLabel69.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel69.ForeColor = System.Drawing.Color.Black;
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(317.4877F, 1394.792F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(193.2151F, 21.25003F);
            this.xrLabel69.StylePriority.UseBorders = false;
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseForeColor = false;
            this.xrLabel69.StylePriority.UsePadding = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "xrTableCell251";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel70
            //
            this.xrLabel70.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel70.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Epanafora_ThesiVanonPouXeiristikan]")});
            this.xrLabel70.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel70.ForeColor = System.Drawing.Color.Black;
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(319.4669F, 1375.764F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(201.5829F, 15.26041F);
            this.xrLabel70.StylePriority.UseBorders = false;
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseForeColor = false;
            this.xrLabel70.StylePriority.UsePadding = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "xrTableCell252";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel71
            //
            this.xrLabel71.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel71.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Oximata]")});
            this.xrLabel71.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel71.ForeColor = System.Drawing.Color.Black;
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(455.1938F, 1335.898F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(65.8559F, 17.86456F);
            this.xrLabel71.StylePriority.UseBorders = false;
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseForeColor = false;
            this.xrLabel71.StylePriority.UsePadding = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.Text = "xrTableCell253";
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel72
            //
            this.xrLabel72.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel72.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TaskScheduleDate]")});
            this.xrLabel72.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel72.ForeColor = System.Drawing.Color.Black;
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(20.20934F, 1050.59F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(113.0372F, 21.25006F);
            this.xrLabel72.StylePriority.UseBorders = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseForeColor = false;
            this.xrLabel72.StylePriority.UsePadding = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = "xrTableCell254";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel73
            //
            this.xrLabel73.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel73.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaEnarxisErgasion]")});
            this.xrLabel73.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel73.ForeColor = System.Drawing.Color.Black;
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(21.1883F, 1108.523F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(186.3227F, 21.25003F);
            this.xrLabel73.StylePriority.UseBorders = false;
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.StylePriority.UseForeColor = false;
            this.xrLabel73.StylePriority.UsePadding = false;
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            this.xrLabel73.Text = "xrTableCell255";
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel74
            //
            this.xrLabel74.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel74.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraEnarxisErgasion]")});
            this.xrLabel74.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel74.ForeColor = System.Drawing.Color.Black;
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(20.77468F, 1026.782F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(120.8024F, 15.93741F);
            this.xrLabel74.StylePriority.UseBorders = false;
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.StylePriority.UseForeColor = false;
            this.xrLabel74.StylePriority.UsePadding = false;
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            this.xrLabel74.Text = "xrTableCell256";
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel75
            //
            this.xrLabel75.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel75.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaLixisErgasion]")});
            this.xrLabel75.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel75.ForeColor = System.Drawing.Color.Black;
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(124.6573F, 965.1623F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(137.9836F, 15.93738F);
            this.xrLabel75.StylePriority.UseBorders = false;
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.StylePriority.UseForeColor = false;
            this.xrLabel75.StylePriority.UsePadding = false;
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            this.xrLabel75.Text = "xrTableCell257";
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel76
            //
            this.xrLabel76.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel76.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraLixisErgasion]")});
            this.xrLabel76.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel76.ForeColor = System.Drawing.Color.Black;
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(27.59266F, 981.0997F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(112.2613F, 21.04172F);
            this.xrLabel76.StylePriority.UseBorders = false;
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseForeColor = false;
            this.xrLabel76.StylePriority.UsePadding = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            this.xrLabel76.Text = "xrTableCell258";
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel77
            //
            this.xrLabel77.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel77.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OnomaVanas]")});
            this.xrLabel77.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel77.ForeColor = System.Drawing.Color.Black;
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 860.7408F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(88.07544F, 21.77087F);
            this.xrLabel77.StylePriority.UseBorders = false;
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.StylePriority.UseForeColor = false;
            this.xrLabel77.StylePriority.UsePadding = false;
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            this.xrLabel77.Text = "xrTableCell259";
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel78
            //
            this.xrLabel78.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel78.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiVanas]")});
            this.xrLabel78.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel78.ForeColor = System.Drawing.Color.Black;
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(32.33135F, 965.058F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(80.7773F, 15.93741F);
            this.xrLabel78.StylePriority.UseBorders = false;
            this.xrLabel78.StylePriority.UseFont = false;
            this.xrLabel78.StylePriority.UseForeColor = false;
            this.xrLabel78.StylePriority.UsePadding = false;
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.Text = "xrTableCell260";
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel79
            //
            this.xrLabel79.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel79.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[KalymaEidos]")});
            this.xrLabel79.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel79.ForeColor = System.Drawing.Color.Black;
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(16.35242F, 882.5117F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(88.43407F, 21.77087F);
            this.xrLabel79.StylePriority.UseBorders = false;
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.StylePriority.UseForeColor = false;
            this.xrLabel79.StylePriority.UsePadding = false;
            this.xrLabel79.StylePriority.UseTextAlignment = false;
            this.xrLabel79.Text = "xrTableCell262";
            this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel80
            //
            this.xrLabel80.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel80.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[KalymaDiastaseis]")});
            this.xrLabel80.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel80.ForeColor = System.Drawing.Color.Black;
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(23.36741F, 1086.752F);
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(110.8158F, 21.77087F);
            this.xrLabel80.StylePriority.UseBorders = false;
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.StylePriority.UseForeColor = false;
            this.xrLabel80.StylePriority.UsePadding = false;
            this.xrLabel80.StylePriority.UseTextAlignment = false;
            this.xrLabel80.Text = "xrTableCell263";
            this.xrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel81
            //
            this.xrLabel81.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel81.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FreatioEidos]")});
            this.xrLabel81.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel81.ForeColor = System.Drawing.Color.Black;
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(15.47655F, 648.6112F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(85.94474F, 19.1087F);
            this.xrLabel81.StylePriority.UseBorders = false;
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.StylePriority.UseForeColor = false;
            this.xrLabel81.StylePriority.UsePadding = false;
            this.xrLabel81.StylePriority.UseTextAlignment = false;
            this.xrLabel81.Text = "xrTableCell264";
            this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel82
            //
            this.xrLabel82.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel82.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FreatioDiastaseis]")});
            this.xrLabel82.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel82.ForeColor = System.Drawing.Color.Black;
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(22.08928F, 718.3276F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(120.7146F, 20.46873F);
            this.xrLabel82.StylePriority.UseBorders = false;
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.StylePriority.UseForeColor = false;
            this.xrLabel82.StylePriority.UsePadding = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.Text = "xrTableCell265";
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel83
            //
            this.xrLabel83.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel83.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaEpemvasis]")});
            this.xrLabel83.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel83.ForeColor = System.Drawing.Color.Black;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 687.1471F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(128.7689F, 23.07294F);
            this.xrLabel83.StylePriority.UseBorders = false;
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseForeColor = false;
            this.xrLabel83.StylePriority.UsePadding = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "xrTableCell266";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel84
            //
            this.xrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel84.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraEpemvasis]")});
            this.xrLabel84.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel84.ForeColor = System.Drawing.Color.Black;
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 667.72F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(94.86803F, 15.93741F);
            this.xrLabel84.StylePriority.UseBorders = false;
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseForeColor = false;
            this.xrLabel84.StylePriority.UsePadding = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.Text = "xrTableCell267";
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel85
            //
            this.xrLabel85.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel85.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OnomaDexamenis]")});
            this.xrLabel85.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel85.ForeColor = System.Drawing.Color.Black;
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(13.71447F, 628.8774F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(109.6077F, 15.93741F);
            this.xrLabel85.StylePriority.UseBorders = false;
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseForeColor = false;
            this.xrLabel85.StylePriority.UsePadding = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.Text = "xrTableCell268";
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel86
            //
            this.xrLabel86.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel86.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiDexamenis]")});
            this.xrLabel86.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel86.ForeColor = System.Drawing.Color.Black;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(319.353F, 1167.482F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(186.9345F, 19.16667F);
            this.xrLabel86.StylePriority.UseBorders = false;
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.StylePriority.UseForeColor = false;
            this.xrLabel86.StylePriority.UsePadding = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.Text = "xrTableCell269";
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel87
            //
            this.xrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel87.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThalamosDexamenis]")});
            this.xrLabel87.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel87.ForeColor = System.Drawing.Color.Black;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(149.6087F, 910.0405F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(122.6165F, 20.46875F);
            this.xrLabel87.StylePriority.UseBorders = false;
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.StylePriority.UseForeColor = false;
            this.xrLabel87.StylePriority.UsePadding = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.Text = "xrTableCell270";
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel88
            //
            this.xrLabel88.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel88.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SimeioEkkenosis]")});
            this.xrLabel88.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel88.ForeColor = System.Drawing.Color.Black;
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(125.7613F, 799.8553F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(96.38742F, 17.86458F);
            this.xrLabel88.StylePriority.UseBorders = false;
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.StylePriority.UseForeColor = false;
            this.xrLabel88.StylePriority.UsePadding = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.Text = "xrTableCell271";
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel89
            //
            this.xrLabel89.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel89.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosAntlion]")});
            this.xrLabel89.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel89.ForeColor = System.Drawing.Color.Black;
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(434.6845F, 887.0255F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(145.4612F, 20.46875F);
            this.xrLabel89.StylePriority.UseBorders = false;
            this.xrLabel89.StylePriority.UseFont = false;
            this.xrLabel89.StylePriority.UseForeColor = false;
            this.xrLabel89.StylePriority.UsePadding = false;
            this.xrLabel89.StylePriority.UseTextAlignment = false;
            this.xrLabel89.Text = "xrTableCell272";
            this.xrLabel89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrCheckBox3
            //
            this.xrCheckBox3.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox3.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MegaliMikriAntlia]")});
            this.xrCheckBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox3.LocationFloat = new DevExpress.Utils.PointFloat(436.6393F, 559.6586F);
            this.xrCheckBox3.Name = "xrCheckBox3";
            this.xrCheckBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox3.SizeF = new System.Drawing.SizeF(56.63094F, 2F);
            //
            // xrLabel90
            //
            this.xrLabel90.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel90.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosTermatos]")});
            this.xrLabel90.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel90.ForeColor = System.Drawing.Color.Black;
            this.xrLabel90.LocationFloat = new DevExpress.Utils.PointFloat(312.5938F, 500.5903F);
            this.xrLabel90.Name = "xrLabel90";
            this.xrLabel90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel90.SizeF = new System.Drawing.SizeF(103.2218F, 19.16667F);
            this.xrLabel90.StylePriority.UseBorders = false;
            this.xrLabel90.StylePriority.UseFont = false;
            this.xrLabel90.StylePriority.UseForeColor = false;
            this.xrLabel90.StylePriority.UsePadding = false;
            this.xrLabel90.StylePriority.UseTextAlignment = false;
            this.xrLabel90.Text = "xrTableCell274";
            this.xrLabel90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrCheckBox4
            //
            this.xrCheckBox4.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox4.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[PRV_Xeirismos]")});
            this.xrCheckBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox4.LocationFloat = new DevExpress.Utils.PointFloat(126.018F, 630.1677F);
            this.xrCheckBox4.Name = "xrCheckBox4";
            this.xrCheckBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox4.SizeF = new System.Drawing.SizeF(57.1505F, 2F);
            //
            // xrCheckBox5
            //
            this.xrCheckBox5.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox5.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[EparkeiaYlikon]")});
            this.xrCheckBox5.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox5.LocationFloat = new DevExpress.Utils.PointFloat(147.8945F, 784.2477F);
            this.xrCheckBox5.Name = "xrCheckBox5";
            this.xrCheckBox5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox5.SizeF = new System.Drawing.SizeF(72.84317F, 2F);
            //
            // xrLabel91
            //
            this.xrLabel91.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel91.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosEpemvasis]")});
            this.xrLabel91.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel91.ForeColor = System.Drawing.Color.Black;
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(505.3298F, 738.7964F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(96.62364F, 17.08336F);
            this.xrLabel91.StylePriority.UseBorders = false;
            this.xrLabel91.StylePriority.UseFont = false;
            this.xrLabel91.StylePriority.UseForeColor = false;
            this.xrLabel91.StylePriority.UsePadding = false;
            this.xrLabel91.StylePriority.UseTextAlignment = false;
            this.xrLabel91.Text = "xrTableCell278";
            this.xrLabel91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel92
            //
            this.xrLabel92.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel92.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SynergeioPRV]")});
            this.xrLabel92.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel92.ForeColor = System.Drawing.Color.Black;
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(316.0437F, 1298.205F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(237.2042F, 15.93741F);
            this.xrLabel92.StylePriority.UseBorders = false;
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseForeColor = false;
            this.xrLabel92.StylePriority.UsePadding = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            this.xrLabel92.Text = "xrTableCell279";
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel93
            //
            this.xrLabel93.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel93.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OnomaPRV]")});
            this.xrLabel93.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel93.ForeColor = System.Drawing.Color.Black;
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(176.3242F, 542.5753F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(75.63052F, 17.08336F);
            this.xrLabel93.StylePriority.UseBorders = false;
            this.xrLabel93.StylePriority.UseFont = false;
            this.xrLabel93.StylePriority.UseForeColor = false;
            this.xrLabel93.StylePriority.UsePadding = false;
            this.xrLabel93.StylePriority.UseTextAlignment = false;
            this.xrLabel93.Text = "xrTableCell280";
            this.xrLabel93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel94
            //
            this.xrLabel94.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel94.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiPRV]")});
            this.xrLabel94.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel94.ForeColor = System.Drawing.Color.Black;
            this.xrLabel94.LocationFloat = new DevExpress.Utils.PointFloat(177.2015F, 559.6586F);
            this.xrLabel94.Name = "xrLabel94";
            this.xrLabel94.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel94.SizeF = new System.Drawing.SizeF(115.7449F, 22.29166F);
            this.xrLabel94.StylePriority.UseBorders = false;
            this.xrLabel94.StylePriority.UseFont = false;
            this.xrLabel94.StylePriority.UseForeColor = false;
            this.xrLabel94.StylePriority.UsePadding = false;
            this.xrLabel94.StylePriority.UseTextAlignment = false;
            this.xrLabel94.Text = "xrTableCell281";
            this.xrLabel94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel95
            //
            this.xrLabel95.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel95.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DiametrosPRV]")});
            this.xrLabel95.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel95.ForeColor = System.Drawing.Color.Black;
            this.xrLabel95.LocationFloat = new DevExpress.Utils.PointFloat(521.3441F, 601.8983F);
            this.xrLabel95.Name = "xrLabel95";
            this.xrLabel95.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel95.SizeF = new System.Drawing.SizeF(84.95235F, 17.08336F);
            this.xrLabel95.StylePriority.UseBorders = false;
            this.xrLabel95.StylePriority.UseFont = false;
            this.xrLabel95.StylePriority.UseForeColor = false;
            this.xrLabel95.StylePriority.UsePadding = false;
            this.xrLabel95.StylePriority.UseTextAlignment = false;
            this.xrLabel95.Text = "xrTableCell282";
            this.xrLabel95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel96
            //
            this.xrLabel96.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel96.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PRVVardiaSynergeiou]")});
            this.xrLabel96.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel96.ForeColor = System.Drawing.Color.Black;
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(118.3074F, 668.5012F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(115.2078F, 17.08336F);
            this.xrLabel96.StylePriority.UseBorders = false;
            this.xrLabel96.StylePriority.UseFont = false;
            this.xrLabel96.StylePriority.UseForeColor = false;
            this.xrLabel96.StylePriority.UsePadding = false;
            this.xrLabel96.StylePriority.UseTextAlignment = false;
            this.xrLabel96.Text = "xrTableCell284";
            this.xrLabel96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel97
            //
            this.xrLabel97.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel97.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PRVArithmosAtomonSynergeiou]")});
            this.xrLabel97.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel97.ForeColor = System.Drawing.Color.Black;
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(429.5072F, 806.8866F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(143.8446F, 22.29166F);
            this.xrLabel97.StylePriority.UseBorders = false;
            this.xrLabel97.StylePriority.UseFont = false;
            this.xrLabel97.StylePriority.UseForeColor = false;
            this.xrLabel97.StylePriority.UsePadding = false;
            this.xrLabel97.StylePriority.UseTextAlignment = false;
            this.xrLabel97.Text = "xrTableCell285";
            this.xrLabel97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel98
            //
            this.xrLabel98.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel98.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Ergolavia]")});
            this.xrLabel98.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel98.ForeColor = System.Drawing.Color.Black;
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(169.2648F, 585.2429F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(123.6816F, 19.16669F);
            this.xrLabel98.StylePriority.UseBorders = false;
            this.xrLabel98.StylePriority.UseFont = false;
            this.xrLabel98.StylePriority.UseForeColor = false;
            this.xrLabel98.StylePriority.UsePadding = false;
            this.xrLabel98.StylePriority.UseTextAlignment = false;
            this.xrLabel98.Text = "xrTableCell286";
            this.xrLabel98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel99
            //
            this.xrLabel99.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel99.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TroposEntopismou]")});
            this.xrLabel99.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel99.ForeColor = System.Drawing.Color.Black;
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(151.9135F, 718.3276F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(150.5022F, 17.08336F);
            this.xrLabel99.StylePriority.UseBorders = false;
            this.xrLabel99.StylePriority.UseFont = false;
            this.xrLabel99.StylePriority.UseForeColor = false;
            this.xrLabel99.StylePriority.UsePadding = false;
            this.xrLabel99.StylePriority.UseTextAlignment = false;
            this.xrLabel99.Text = "xrTableCell288";
            this.xrLabel99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel100
            //
            this.xrLabel100.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel100.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosVlavis]")});
            this.xrLabel100.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel100.ForeColor = System.Drawing.Color.Black;
            this.xrLabel100.LocationFloat = new DevExpress.Utils.PointFloat(505.3298F, 559.6586F);
            this.xrLabel100.Name = "xrLabel100";
            this.xrLabel100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel100.SizeF = new System.Drawing.SizeF(103.911F, 18.12502F);
            this.xrLabel100.StylePriority.UseBorders = false;
            this.xrLabel100.StylePriority.UseFont = false;
            this.xrLabel100.StylePriority.UseForeColor = false;
            this.xrLabel100.StylePriority.UsePadding = false;
            this.xrLabel100.StylePriority.UseTextAlignment = false;
            this.xrLabel100.Text = "xrTableCell289";
            this.xrLabel100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel101
            //
            this.xrLabel101.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel101.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AitiaVlavis]")});
            this.xrLabel101.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel101.ForeColor = System.Drawing.Color.Black;
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(158.1801F, 607.8879F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(85.47879F, 17.08336F);
            this.xrLabel101.StylePriority.UseBorders = false;
            this.xrLabel101.StylePriority.UseFont = false;
            this.xrLabel101.StylePriority.UseForeColor = false;
            this.xrLabel101.StylePriority.UsePadding = false;
            this.xrLabel101.StylePriority.UseTextAlignment = false;
            this.xrLabel101.Text = "xrTableCell290";
            this.xrLabel101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel102
            //
            this.xrLabel102.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel102.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OnomasiaThesis]")});
            this.xrLabel102.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel102.ForeColor = System.Drawing.Color.Black;
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(483.3087F, 521.8168F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(131.0477F, 20.20833F);
            this.xrLabel102.StylePriority.UseBorders = false;
            this.xrLabel102.StylePriority.UseFont = false;
            this.xrLabel102.StylePriority.UseForeColor = false;
            this.xrLabel102.StylePriority.UsePadding = false;
            this.xrLabel102.StylePriority.UseTextAlignment = false;
            this.xrLabel102.Text = "xrTableCell291";
            this.xrLabel102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel103
            //
            this.xrLabel103.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel103.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Ekkremotites]")});
            this.xrLabel103.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel103.ForeColor = System.Drawing.Color.Black;
            this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(188.605F, 817.9805F);
            this.xrLabel103.Name = "xrLabel103";
            this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel103.SizeF = new System.Drawing.SizeF(86.78957F, 22.29166F);
            this.xrLabel103.StylePriority.UseBorders = false;
            this.xrLabel103.StylePriority.UseFont = false;
            this.xrLabel103.StylePriority.UseForeColor = false;
            this.xrLabel103.StylePriority.UsePadding = false;
            this.xrLabel103.StylePriority.UseTextAlignment = false;
            this.xrLabel103.Text = "xrTableCell292";
            this.xrLabel103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel104
            //
            this.xrLabel104.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel104.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProteinomenoSimeio_Dimos]")});
            this.xrLabel104.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel104.ForeColor = System.Drawing.Color.Black;
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(166.3038F, 502.6736F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(118.2315F, 17.08331F);
            this.xrLabel104.StylePriority.UseBorders = false;
            this.xrLabel104.StylePriority.UseFont = false;
            this.xrLabel104.StylePriority.UseForeColor = false;
            this.xrLabel104.StylePriority.UsePadding = false;
            this.xrLabel104.StylePriority.UseTextAlignment = false;
            this.xrLabel104.Text = "xrTableCell293";
            this.xrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel105
            //
            this.xrLabel105.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel105.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProteinomenoSimeio_Odos]")});
            this.xrLabel105.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel105.ForeColor = System.Drawing.Color.Black;
            this.xrLabel105.LocationFloat = new DevExpress.Utils.PointFloat(17.73911F, 817.7432F);
            this.xrLabel105.Name = "xrLabel105";
            this.xrLabel105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel105.SizeF = new System.Drawing.SizeF(162.4644F, 17.08333F);
            this.xrLabel105.StylePriority.UseBorders = false;
            this.xrLabel105.StylePriority.UseFont = false;
            this.xrLabel105.StylePriority.UseForeColor = false;
            this.xrLabel105.StylePriority.UsePadding = false;
            this.xrLabel105.StylePriority.UseTextAlignment = false;
            this.xrLabel105.Text = "xrTableCell294";
            this.xrLabel105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel106
            //
            this.xrLabel106.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel106.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProteinomenoSimeio_Atihmos]")});
            this.xrLabel106.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel106.ForeColor = System.Drawing.Color.Black;
            this.xrLabel106.LocationFloat = new DevExpress.Utils.PointFloat(151.9135F, 687.1471F);
            this.xrLabel106.Name = "xrLabel106";
            this.xrLabel106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel106.SizeF = new System.Drawing.SizeF(150.5022F, 22.29166F);
            this.xrLabel106.StylePriority.UseBorders = false;
            this.xrLabel106.StylePriority.UseFont = false;
            this.xrLabel106.StylePriority.UseForeColor = false;
            this.xrLabel106.StylePriority.UsePadding = false;
            this.xrLabel106.StylePriority.UseTextAlignment = false;
            this.xrLabel106.Text = "xrTableCell295";
            this.xrLabel106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel107
            //
            this.xrLabel107.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel107.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProteinomenoSimeio_SyntetagmeniX]")});
            this.xrLabel107.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel107.ForeColor = System.Drawing.Color.Black;
            this.xrLabel107.LocationFloat = new DevExpress.Utils.PointFloat(108.0428F, 865.4283F);
            this.xrLabel107.Name = "xrLabel107";
            this.xrLabel107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel107.SizeF = new System.Drawing.SizeF(179.3055F, 17.08333F);
            this.xrLabel107.StylePriority.UseBorders = false;
            this.xrLabel107.StylePriority.UseFont = false;
            this.xrLabel107.StylePriority.UseForeColor = false;
            this.xrLabel107.StylePriority.UsePadding = false;
            this.xrLabel107.StylePriority.UseTextAlignment = false;
            this.xrLabel107.Text = "xrTableCell296";
            this.xrLabel107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel108
            //
            this.xrLabel108.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel108.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProteinomenoSimeio_SyntetagmeniY]")});
            this.xrLabel108.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel108.ForeColor = System.Drawing.Color.Black;
            this.xrLabel108.LocationFloat = new DevExpress.Utils.PointFloat(111.4458F, 647.2511F);
            this.xrLabel108.Name = "xrLabel108";
            this.xrLabel108.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel108.SizeF = new System.Drawing.SizeF(186.9872F, 20.46881F);
            this.xrLabel108.StylePriority.UseBorders = false;
            this.xrLabel108.StylePriority.UseFont = false;
            this.xrLabel108.StylePriority.UseForeColor = false;
            this.xrLabel108.StylePriority.UsePadding = false;
            this.xrLabel108.StylePriority.UseTextAlignment = false;
            this.xrLabel108.Text = "xrTableCell297";
            this.xrLabel108.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel109
            //
            this.xrLabel109.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel109.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OnomasiaAntliostasiou]")});
            this.xrLabel109.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel109.ForeColor = System.Drawing.Color.Black;
            this.xrLabel109.LocationFloat = new DevExpress.Utils.PointFloat(432.6821F, 500.5903F);
            this.xrLabel109.Name = "xrLabel109";
            this.xrLabel109.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel109.SizeF = new System.Drawing.SizeF(142.0301F, 17.08336F);
            this.xrLabel109.StylePriority.UseBorders = false;
            this.xrLabel109.StylePriority.UseFont = false;
            this.xrLabel109.StylePriority.UseForeColor = false;
            this.xrLabel109.StylePriority.UsePadding = false;
            this.xrLabel109.StylePriority.UseTextAlignment = false;
            this.xrLabel109.Text = "xrTableCell298";
            this.xrLabel109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel110
            //
            this.xrLabel110.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel110.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaApokatastasis]")});
            this.xrLabel110.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel110.ForeColor = System.Drawing.Color.Black;
            this.xrLabel110.LocationFloat = new DevExpress.Utils.PointFloat(147.6125F, 760.2778F);
            this.xrLabel110.Name = "xrLabel110";
            this.xrLabel110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel110.SizeF = new System.Drawing.SizeF(145.3338F, 18.12499F);
            this.xrLabel110.StylePriority.UseBorders = false;
            this.xrLabel110.StylePriority.UseFont = false;
            this.xrLabel110.StylePriority.UseForeColor = false;
            this.xrLabel110.StylePriority.UsePadding = false;
            this.xrLabel110.StylePriority.UseTextAlignment = false;
            this.xrLabel110.Text = "xrTableCell299";
            this.xrLabel110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel111
            //
            this.xrLabel111.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel111.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraApokatastasis]")});
            this.xrLabel111.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel111.ForeColor = System.Drawing.Color.Black;
            this.xrLabel111.LocationFloat = new DevExpress.Utils.PointFloat(476.6432F, 712.5348F);
            this.xrLabel111.Name = "xrLabel111";
            this.xrLabel111.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel111.SizeF = new System.Drawing.SizeF(103.3018F, 19.16663F);
            this.xrLabel111.StylePriority.UseBorders = false;
            this.xrLabel111.StylePriority.UseFont = false;
            this.xrLabel111.StylePriority.UseForeColor = false;
            this.xrLabel111.StylePriority.UsePadding = false;
            this.xrLabel111.StylePriority.UseTextAlignment = false;
            this.xrLabel111.Text = "xrTableCell300";
            this.xrLabel111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrCheckBox9
            //
            this.xrCheckBox9.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox9.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[Parapono]")});
            this.xrCheckBox9.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox9.LocationFloat = new DevExpress.Utils.PointFloat(275.9735F, 388.8197F);
            this.xrCheckBox9.Name = "xrCheckBox9";
            this.xrCheckBox9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox9.SizeF = new System.Drawing.SizeF(118.9649F, 2F);
            //
            // xrCheckBox10
            //
            this.xrCheckBox10.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox10.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[EktaktoDeigma]")});
            this.xrCheckBox10.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox10.LocationFloat = new DevExpress.Utils.PointFloat(275.9735F, 366.7884F);
            this.xrCheckBox10.Name = "xrCheckBox10";
            this.xrCheckBox10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox10.SizeF = new System.Drawing.SizeF(121.2316F, 2F);
            //
            // xrCheckBox11
            //
            this.xrCheckBox11.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox11.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeLovipond]")});
            this.xrCheckBox11.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox11.LocationFloat = new DevExpress.Utils.PointFloat(242.3496F, 308.9237F);
            this.xrCheckBox11.Name = "xrCheckBox11";
            this.xrCheckBox11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox11.SizeF = new System.Drawing.SizeF(135.7496F, 2F);
            //
            // xrCheckBox12
            //
            this.xrCheckBox12.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrCheckBox12.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCheckBox12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeSwan]")});
            this.xrCheckBox12.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrCheckBox12.LocationFloat = new DevExpress.Utils.PointFloat(4.876009F, 329.3924F);
            this.xrCheckBox12.Name = "xrCheckBox12";
            this.xrCheckBox12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox12.SizeF = new System.Drawing.SizeF(63.53252F, 2F);
            //
            // xrLabel112
            //
            this.xrLabel112.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel112.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaDeigmatolipsias]")});
            this.xrLabel112.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel112.ForeColor = System.Drawing.Color.Black;
            this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(4.776279F, 222.5232F);
            this.xrLabel112.Name = "xrLabel112";
            this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel112.SizeF = new System.Drawing.SizeF(98.34918F, 20.46875F);
            this.xrLabel112.StylePriority.UseBorders = false;
            this.xrLabel112.StylePriority.UseFont = false;
            this.xrLabel112.StylePriority.UseForeColor = false;
            this.xrLabel112.StylePriority.UsePadding = false;
            this.xrLabel112.StylePriority.UseTextAlignment = false;
            this.xrLabel112.Text = "xrTableCell308";
            this.xrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel113
            //
            this.xrLabel113.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel113.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraDeigmatolipsias]")});
            this.xrLabel113.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel113.ForeColor = System.Drawing.Color.Black;
            this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(148.2822F, 252.9861F);
            this.xrLabel113.Name = "xrLabel113";
            this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel113.SizeF = new System.Drawing.SizeF(140.5314F, 21.77087F);
            this.xrLabel113.StylePriority.UseBorders = false;
            this.xrLabel113.StylePriority.UseFont = false;
            this.xrLabel113.StylePriority.UseForeColor = false;
            this.xrLabel113.StylePriority.UsePadding = false;
            this.xrLabel113.StylePriority.UseTextAlignment = false;
            this.xrLabel113.Text = "xrTableCell309";
            this.xrLabel113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel114
            //
            this.xrLabel114.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel114.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CLPedio]")});
            this.xrLabel114.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel114.ForeColor = System.Drawing.Color.Black;
            this.xrLabel114.LocationFloat = new DevExpress.Utils.PointFloat(4.646103F, 308.9237F);
            this.xrLabel114.Name = "xrLabel114";
            this.xrLabel114.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel114.SizeF = new System.Drawing.SizeF(58.68881F, 20.46875F);
            this.xrLabel114.StylePriority.UseBorders = false;
            this.xrLabel114.StylePriority.UseFont = false;
            this.xrLabel114.StylePriority.UseForeColor = false;
            this.xrLabel114.StylePriority.UsePadding = false;
            this.xrLabel114.StylePriority.UseTextAlignment = false;
            this.xrLabel114.Text = "xrTableCell310";
            this.xrLabel114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel115
            //
            this.xrLabel115.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel115.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CLMetatropi]")});
            this.xrLabel115.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel115.ForeColor = System.Drawing.Color.Black;
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(145.4799F, 281.6321F);
            this.xrLabel115.Name = "xrLabel115";
            this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel115.SizeF = new System.Drawing.SizeF(210.0479F, 15.93732F);
            this.xrLabel115.StylePriority.UseBorders = false;
            this.xrLabel115.StylePriority.UseFont = false;
            this.xrLabel115.StylePriority.UseForeColor = false;
            this.xrLabel115.StylePriority.UsePadding = false;
            this.xrLabel115.StylePriority.UseTextAlignment = false;
            this.xrLabel115.Text = "xrTableCell311";
            this.xrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel116
            //
            this.xrLabel116.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel116.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MetrisiYpolCLPedioA]")});
            this.xrLabel116.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel116.ForeColor = System.Drawing.Color.Black;
            this.xrLabel116.LocationFloat = new DevExpress.Utils.PointFloat(468.5975F, 362.8821F);
            this.xrLabel116.Name = "xrLabel116";
            this.xrLabel116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel116.SizeF = new System.Drawing.SizeF(147.3362F, 21.77087F);
            this.xrLabel116.StylePriority.UseBorders = false;
            this.xrLabel116.StylePriority.UseFont = false;
            this.xrLabel116.StylePriority.UseForeColor = false;
            this.xrLabel116.StylePriority.UsePadding = false;
            this.xrLabel116.StylePriority.UseTextAlignment = false;
            this.xrLabel116.Text = "xrTableCell312";
            this.xrLabel116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel117
            //
            this.xrLabel117.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel117.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DiorthosiCL02PedioB]")});
            this.xrLabel117.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel117.ForeColor = System.Drawing.Color.Black;
            this.xrLabel117.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 203.3565F);
            this.xrLabel117.Name = "xrLabel117";
            this.xrLabel117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel117.SizeF = new System.Drawing.SizeF(132.2695F, 19.16667F);
            this.xrLabel117.StylePriority.UseBorders = false;
            this.xrLabel117.StylePriority.UseFont = false;
            this.xrLabel117.StylePriority.UseForeColor = false;
            this.xrLabel117.StylePriority.UsePadding = false;
            this.xrLabel117.StylePriority.UseTextAlignment = false;
            this.xrLabel117.Text = "xrTableCell313";
            this.xrLabel117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel118
            //
            this.xrLabel118.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel118.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CL_A_B]")});
            this.xrLabel118.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel118.ForeColor = System.Drawing.Color.Black;
            this.xrLabel118.LocationFloat = new DevExpress.Utils.PointFloat(465.9536F, 405.903F);
            this.xrLabel118.Name = "xrLabel118";
            this.xrLabel118.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel118.SizeF = new System.Drawing.SizeF(62.93829F, 21.77087F);
            this.xrLabel118.StylePriority.UseBorders = false;
            this.xrLabel118.StylePriority.UseFont = false;
            this.xrLabel118.StylePriority.UseForeColor = false;
            this.xrLabel118.StylePriority.UsePadding = false;
            this.xrLabel118.StylePriority.UseTextAlignment = false;
            this.xrLabel118.Text = "xrTableCell314";
            this.xrLabel118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel119
            //
            this.xrLabel119.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel119.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CLO2]")});
            this.xrLabel119.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel119.ForeColor = System.Drawing.Color.Black;
            this.xrLabel119.LocationFloat = new DevExpress.Utils.PointFloat(147.8945F, 431.5801F);
            this.xrLabel119.Name = "xrLabel119";
            this.xrLabel119.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel119.SizeF = new System.Drawing.SizeF(50.00124F, 19.16672F);
            this.xrLabel119.StylePriority.UseBorders = false;
            this.xrLabel119.StylePriority.UseFont = false;
            this.xrLabel119.StylePriority.UseForeColor = false;
            this.xrLabel119.StylePriority.UsePadding = false;
            this.xrLabel119.StylePriority.UseTextAlignment = false;
            this.xrLabel119.Text = "xrTableCell315";
            this.xrLabel119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel120
            //
            this.xrLabel120.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel120.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Deigmatoliptis]")});
            this.xrLabel120.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel120.ForeColor = System.Drawing.Color.Black;
            this.xrLabel120.LocationFloat = new DevExpress.Utils.PointFloat(200.3704F, 431.58F);
            this.xrLabel120.Name = "xrLabel120";
            this.xrLabel120.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel120.SizeF = new System.Drawing.SizeF(110.9298F, 20.46875F);
            this.xrLabel120.StylePriority.UseBorders = false;
            this.xrLabel120.StylePriority.UseFont = false;
            this.xrLabel120.StylePriority.UseForeColor = false;
            this.xrLabel120.StylePriority.UsePadding = false;
            this.xrLabel120.StylePriority.UseTextAlignment = false;
            this.xrLabel120.Text = "xrTableCell316";
            this.xrLabel120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel121
            //
            this.xrLabel121.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel121.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosMetriti]")});
            this.xrLabel121.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel121.ForeColor = System.Drawing.Color.Black;
            this.xrLabel121.LocationFloat = new DevExpress.Utils.PointFloat(19.75397F, 1145.711F);
            this.xrLabel121.Name = "xrLabel121";
            this.xrLabel121.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel121.SizeF = new System.Drawing.SizeF(95.36227F, 21.77087F);
            this.xrLabel121.StylePriority.UseBorders = false;
            this.xrLabel121.StylePriority.UseFont = false;
            this.xrLabel121.StylePriority.UseForeColor = false;
            this.xrLabel121.StylePriority.UsePadding = false;
            this.xrLabel121.StylePriority.UseTextAlignment = false;
            this.xrLabel121.Text = "xrTableCell317";
            this.xrLabel121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel122
            //
            this.xrLabel122.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel122.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma1]")});
            this.xrLabel122.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel122.ForeColor = System.Drawing.Color.Black;
            this.xrLabel122.LocationFloat = new DevExpress.Utils.PointFloat(517.5285F, 136.4583F);
            this.xrLabel122.Name = "xrLabel122";
            this.xrLabel122.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel122.SizeF = new System.Drawing.SizeF(114.8475F, 19.16667F);
            this.xrLabel122.StylePriority.UseBorders = false;
            this.xrLabel122.StylePriority.UseFont = false;
            this.xrLabel122.StylePriority.UseForeColor = false;
            this.xrLabel122.StylePriority.UsePadding = false;
            this.xrLabel122.StylePriority.UseTextAlignment = false;
            this.xrLabel122.Text = "xrTableCell318";
            this.xrLabel122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel123
            //
            this.xrLabel123.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel123.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL1]")});
            this.xrLabel123.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel123.ForeColor = System.Drawing.Color.Black;
            this.xrLabel123.LocationFloat = new DevExpress.Utils.PointFloat(532.7075F, 161.6378F);
            this.xrLabel123.Name = "xrLabel123";
            this.xrLabel123.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel123.SizeF = new System.Drawing.SizeF(104.5704F, 19.16667F);
            this.xrLabel123.StylePriority.UseBorders = false;
            this.xrLabel123.StylePriority.UseFont = false;
            this.xrLabel123.StylePriority.UseForeColor = false;
            this.xrLabel123.StylePriority.UsePadding = false;
            this.xrLabel123.StylePriority.UseTextAlignment = false;
            this.xrLabel123.Text = "xrTableCell319";
            this.xrLabel123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrLabel124
            //
            this.xrLabel124.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel124.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma2]")});
            this.xrLabel124.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel124.ForeColor = System.Drawing.Color.Black;
            this.xrLabel124.LocationFloat = new DevExpress.Utils.PointFloat(467.6353F, 427.6738F);
            this.xrLabel124.Name = "xrLabel124";
            this.xrLabel124.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel124.SizeF = new System.Drawing.SizeF(105.0107F, 23.07294F);
            this.xrLabel124.StylePriority.UseBorders = false;
            this.xrLabel124.StylePriority.UseFont = false;
            this.xrLabel124.StylePriority.UseForeColor = false;
            this.xrLabel124.StylePriority.UsePadding = false;
            this.xrLabel124.StylePriority.UseTextAlignment = false;
            this.xrLabel124.Text = "xrTableCell320";
            this.xrLabel124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel125
            //
            this.xrLabel125.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel125.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL2]")});
            this.xrLabel125.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel125.ForeColor = System.Drawing.Color.Black;
            this.xrLabel125.LocationFloat = new DevExpress.Utils.PointFloat(465.5548F, 450.7468F);
            this.xrLabel125.Name = "xrLabel125";
            this.xrLabel125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel125.SizeF = new System.Drawing.SizeF(148.1298F, 23.07291F);
            this.xrLabel125.StylePriority.UseBorders = false;
            this.xrLabel125.StylePriority.UseFont = false;
            this.xrLabel125.StylePriority.UseForeColor = false;
            this.xrLabel125.StylePriority.UsePadding = false;
            this.xrLabel125.StylePriority.UseTextAlignment = false;
            this.xrLabel125.Text = "xrTableCell321";
            this.xrLabel125.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel126
            //
            this.xrLabel126.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel126.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma3]")});
            this.xrLabel126.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel126.ForeColor = System.Drawing.Color.Black;
            this.xrLabel126.LocationFloat = new DevExpress.Utils.PointFloat(468.5975F, 319.3403F);
            this.xrLabel126.Name = "xrLabel126";
            this.xrLabel126.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel126.SizeF = new System.Drawing.SizeF(171.4025F, 21.77087F);
            this.xrLabel126.StylePriority.UseBorders = false;
            this.xrLabel126.StylePriority.UseFont = false;
            this.xrLabel126.StylePriority.UseForeColor = false;
            this.xrLabel126.StylePriority.UsePadding = false;
            this.xrLabel126.StylePriority.UseTextAlignment = false;
            this.xrLabel126.Text = "xrTableCell322";
            this.xrLabel126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel127
            //
            this.xrLabel127.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel127.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL3]")});
            this.xrLabel127.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel127.ForeColor = System.Drawing.Color.Black;
            this.xrLabel127.LocationFloat = new DevExpress.Utils.PointFloat(465.5548F, 384.653F);
            this.xrLabel127.Name = "xrLabel127";
            this.xrLabel127.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel127.SizeF = new System.Drawing.SizeF(78.6492F, 21.25F);
            this.xrLabel127.StylePriority.UseBorders = false;
            this.xrLabel127.StylePriority.UseFont = false;
            this.xrLabel127.StylePriority.UseForeColor = false;
            this.xrLabel127.StylePriority.UsePadding = false;
            this.xrLabel127.StylePriority.UseTextAlignment = false;
            this.xrLabel127.Text = "xrTableCell323";
            this.xrLabel127.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel128
            //
            this.xrLabel128.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel128.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma4]")});
            this.xrLabel128.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel128.ForeColor = System.Drawing.Color.Black;
            this.xrLabel128.LocationFloat = new DevExpress.Utils.PointFloat(470.5716F, 341.1112F);
            this.xrLabel128.Name = "xrLabel128";
            this.xrLabel128.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel128.SizeF = new System.Drawing.SizeF(167.7508F, 21.77087F);
            this.xrLabel128.StylePriority.UseBorders = false;
            this.xrLabel128.StylePriority.UseFont = false;
            this.xrLabel128.StylePriority.UseForeColor = false;
            this.xrLabel128.StylePriority.UsePadding = false;
            this.xrLabel128.StylePriority.UseTextAlignment = false;
            this.xrLabel128.Text = "xrTableCell324";
            this.xrLabel128.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel129
            //
            this.xrLabel129.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel129.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL4]")});
            this.xrLabel129.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel129.ForeColor = System.Drawing.Color.Black;
            this.xrLabel129.LocationFloat = new DevExpress.Utils.PointFloat(149.8525F, 307.6216F);
            this.xrLabel129.Name = "xrLabel129";
            this.xrLabel129.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel129.SizeF = new System.Drawing.SizeF(85.25232F, 21.77087F);
            this.xrLabel129.StylePriority.UseBorders = false;
            this.xrLabel129.StylePriority.UseFont = false;
            this.xrLabel129.StylePriority.UseForeColor = false;
            this.xrLabel129.StylePriority.UsePadding = false;
            this.xrLabel129.StylePriority.UseTextAlignment = false;
            this.xrLabel129.Text = "xrTableCell325";
            this.xrLabel129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel130
            //
            this.xrLabel130.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel130.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RemarksFromTablet]")});
            this.xrLabel130.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel130.ForeColor = System.Drawing.Color.Black;
            this.xrLabel130.LocationFloat = new DevExpress.Utils.PointFloat(23.83002F, 1167.482F);
            this.xrLabel130.Name = "xrLabel130";
            this.xrLabel130.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel130.SizeF = new System.Drawing.SizeF(123.4765F, 15.93741F);
            this.xrLabel130.StylePriority.UseBorders = false;
            this.xrLabel130.StylePriority.UseFont = false;
            this.xrLabel130.StylePriority.UseForeColor = false;
            this.xrLabel130.StylePriority.UsePadding = false;
            this.xrLabel130.StylePriority.UseTextAlignment = false;
            this.xrLabel130.Text = "xrTableCell326";
            this.xrLabel130.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel131
            //
            this.xrLabel131.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel131.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressMunicipality]")});
            this.xrLabel131.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel131.ForeColor = System.Drawing.Color.Black;
            this.xrLabel131.LocationFloat = new DevExpress.Utils.PointFloat(148.2822F, 366.7884F);
            this.xrLabel131.Name = "xrLabel131";
            this.xrLabel131.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel131.SizeF = new System.Drawing.SizeF(118.2703F, 17.86459F);
            this.xrLabel131.StylePriority.UseBorders = false;
            this.xrLabel131.StylePriority.UseFont = false;
            this.xrLabel131.StylePriority.UseForeColor = false;
            this.xrLabel131.StylePriority.UsePadding = false;
            this.xrLabel131.StylePriority.UseTextAlignment = false;
            this.xrLabel131.Text = "xrTableCell327";
            this.xrLabel131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel132
            //
            this.xrLabel132.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel132.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressOdos]")});
            this.xrLabel132.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel132.ForeColor = System.Drawing.Color.Black;
            this.xrLabel132.LocationFloat = new DevExpress.Utils.PointFloat(149.8525F, 341.1112F);
            this.xrLabel132.Name = "xrLabel132";
            this.xrLabel132.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel132.SizeF = new System.Drawing.SizeF(190.0677F, 21.77087F);
            this.xrLabel132.StylePriority.UseBorders = false;
            this.xrLabel132.StylePriority.UseFont = false;
            this.xrLabel132.StylePriority.UseForeColor = false;
            this.xrLabel132.StylePriority.UsePadding = false;
            this.xrLabel132.StylePriority.UseTextAlignment = false;
            this.xrLabel132.Text = "xrTableCell328";
            this.xrLabel132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel133
            //
            this.xrLabel133.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel133.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressArithmos]")});
            this.xrLabel133.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel133.ForeColor = System.Drawing.Color.Black;
            this.xrLabel133.LocationFloat = new DevExpress.Utils.PointFloat(147.8945F, 384.653F);
            this.xrLabel133.Name = "xrLabel133";
            this.xrLabel133.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel133.SizeF = new System.Drawing.SizeF(104.0602F, 21.25F);
            this.xrLabel133.StylePriority.UseBorders = false;
            this.xrLabel133.StylePriority.UseFont = false;
            this.xrLabel133.StylePriority.UseForeColor = false;
            this.xrLabel133.StylePriority.UsePadding = false;
            this.xrLabel133.StylePriority.UseTextAlignment = false;
            this.xrLabel133.Text = "xrTableCell329";
            this.xrLabel133.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel134
            //
            this.xrLabel134.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel134.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiAgogou]")});
            this.xrLabel134.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel134.ForeColor = System.Drawing.Color.Black;
            this.xrLabel134.LocationFloat = new DevExpress.Utils.PointFloat(22.17066F, 1331.158F);
            this.xrLabel134.Name = "xrLabel134";
            this.xrLabel134.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel134.SizeF = new System.Drawing.SizeF(212.7946F, 15.93741F);
            this.xrLabel134.StylePriority.UseBorders = false;
            this.xrLabel134.StylePriority.UseFont = false;
            this.xrLabel134.StylePriority.UseForeColor = false;
            this.xrLabel134.StylePriority.UsePadding = false;
            this.xrLabel134.StylePriority.UseTextAlignment = false;
            this.xrLabel134.Text = "xrTableCell330";
            this.xrLabel134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel135
            //
            this.xrLabel135.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel135.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgogosMikos]")});
            this.xrLabel135.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel135.ForeColor = System.Drawing.Color.Black;
            this.xrLabel135.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 838.9699F);
            this.xrLabel135.Name = "xrLabel135";
            this.xrLabel135.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel135.SizeF = new System.Drawing.SizeF(84.71025F, 21.77087F);
            this.xrLabel135.StylePriority.UseBorders = false;
            this.xrLabel135.StylePriority.UseFont = false;
            this.xrLabel135.StylePriority.UseForeColor = false;
            this.xrLabel135.StylePriority.UsePadding = false;
            this.xrLabel135.StylePriority.UseTextAlignment = false;
            this.xrLabel135.Text = "xrTableCell331";
            this.xrLabel135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel136
            //
            this.xrLabel136.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel136.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosVanon]")});
            this.xrLabel136.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel136.ForeColor = System.Drawing.Color.Black;
            this.xrLabel136.LocationFloat = new DevExpress.Utils.PointFloat(23.83002F, 799.8553F);
            this.xrLabel136.Name = "xrLabel136";
            this.xrLabel136.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel136.SizeF = new System.Drawing.SizeF(94.7845F, 17.86456F);
            this.xrLabel136.StylePriority.UseBorders = false;
            this.xrLabel136.StylePriority.UseFont = false;
            this.xrLabel136.StylePriority.UseForeColor = false;
            this.xrLabel136.StylePriority.UsePadding = false;
            this.xrLabel136.StylePriority.UseTextAlignment = false;
            this.xrLabel136.Text = "xrTableCell332";
            this.xrLabel136.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel137
            //
            this.xrLabel137.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel137.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgogosDiatomi]")});
            this.xrLabel137.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel137.ForeColor = System.Drawing.Color.Black;
            this.xrLabel137.LocationFloat = new DevExpress.Utils.PointFloat(23.36542F, 778.1423F);
            this.xrLabel137.Name = "xrLabel137";
            this.xrLabel137.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel137.SizeF = new System.Drawing.SizeF(103.8193F, 19.16669F);
            this.xrLabel137.StylePriority.UseBorders = false;
            this.xrLabel137.StylePriority.UseFont = false;
            this.xrLabel137.StylePriority.UseForeColor = false;
            this.xrLabel137.StylePriority.UsePadding = false;
            this.xrLabel137.StylePriority.UseTextAlignment = false;
            this.xrLabel137.Text = "xrTableCell334";
            this.xrLabel137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel138
            //
            this.xrLabel138.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel138.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiEidikisParoxis]")});
            this.xrLabel138.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel138.ForeColor = System.Drawing.Color.Black;
            this.xrLabel138.LocationFloat = new DevExpress.Utils.PointFloat(26.24929F, 760.2778F);
            this.xrLabel138.Name = "xrLabel138";
            this.xrLabel138.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel138.SizeF = new System.Drawing.SizeF(112.0202F, 17.86456F);
            this.xrLabel138.StylePriority.UseBorders = false;
            this.xrLabel138.StylePriority.UseFont = false;
            this.xrLabel138.StylePriority.UseForeColor = false;
            this.xrLabel138.StylePriority.UsePadding = false;
            this.xrLabel138.StylePriority.UseTextAlignment = false;
            this.xrLabel138.Text = "xrTableCell335";
            this.xrLabel138.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel139
            //
            this.xrLabel139.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel139.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiKataskeyisNeasParoxis]")});
            this.xrLabel139.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel139.ForeColor = System.Drawing.Color.Black;
            this.xrLabel139.LocationFloat = new DevExpress.Utils.PointFloat(318.3308F, 1093.941F);
            this.xrLabel139.Name = "xrLabel139";
            this.xrLabel139.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel139.SizeF = new System.Drawing.SizeF(224.6162F, 17.57513F);
            this.xrLabel139.StylePriority.UseBorders = false;
            this.xrLabel139.StylePriority.UseFont = false;
            this.xrLabel139.StylePriority.UseForeColor = false;
            this.xrLabel139.StylePriority.UsePadding = false;
            this.xrLabel139.StylePriority.UseTextAlignment = false;
            this.xrLabel139.Text = "xrTableCell336";
            this.xrLabel139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel140
            //
            this.xrLabel140.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel140.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_HmerominiaAnagelias]")});
            this.xrLabel140.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel140.ForeColor = System.Drawing.Color.Black;
            this.xrLabel140.LocationFloat = new DevExpress.Utils.PointFloat(24.73092F, 738.7964F);
            this.xrLabel140.Name = "xrLabel140";
            this.xrLabel140.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel140.SizeF = new System.Drawing.SizeF(181.5087F, 21.25F);
            this.xrLabel140.StylePriority.UseBorders = false;
            this.xrLabel140.StylePriority.UseFont = false;
            this.xrLabel140.StylePriority.UseForeColor = false;
            this.xrLabel140.StylePriority.UsePadding = false;
            this.xrLabel140.StylePriority.UseTextAlignment = false;
            this.xrLabel140.Text = "xrTableCell337";
            this.xrLabel140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel141
            //
            this.xrLabel141.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel141.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_OraAnagelias]")});
            this.xrLabel141.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel141.ForeColor = System.Drawing.Color.Black;
            this.xrLabel141.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 583.1596F);
            this.xrLabel141.Name = "xrLabel141";
            this.xrLabel141.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel141.SizeF = new System.Drawing.SizeF(146.9557F, 21.24994F);
            this.xrLabel141.StylePriority.UseBorders = false;
            this.xrLabel141.StylePriority.UseFont = false;
            this.xrLabel141.StylePriority.UseForeColor = false;
            this.xrLabel141.StylePriority.UsePadding = false;
            this.xrLabel141.StylePriority.UseTextAlignment = false;
            this.xrLabel141.Text = "xrTableCell338";
            this.xrLabel141.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel142
            //
            this.xrLabel142.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel142.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_ArithmosAitimatos]")});
            this.xrLabel142.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel142.ForeColor = System.Drawing.Color.Black;
            this.xrLabel142.LocationFloat = new DevExpress.Utils.PointFloat(12.85664F, 607.1066F);
            this.xrLabel142.Name = "xrLabel142";
            this.xrLabel142.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel142.SizeF = new System.Drawing.SizeF(139.6139F, 17.86456F);
            this.xrLabel142.StylePriority.UseBorders = false;
            this.xrLabel142.StylePriority.UseFont = false;
            this.xrLabel142.StylePriority.UseForeColor = false;
            this.xrLabel142.StylePriority.UsePadding = false;
            this.xrLabel142.StylePriority.UseTextAlignment = false;
            this.xrLabel142.Text = "xrTableCell339";
            this.xrLabel142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel143
            //
            this.xrLabel143.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel143.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_ErgolaviaNeasParoxis]")});
            this.xrLabel143.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel143.ForeColor = System.Drawing.Color.Black;
            this.xrLabel143.LocationFloat = new DevExpress.Utils.PointFloat(18.89475F, 563.9929F);
            this.xrLabel143.Name = "xrLabel143";
            this.xrLabel143.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel143.SizeF = new System.Drawing.SizeF(155.606F, 18.96997F);
            this.xrLabel143.StylePriority.UseBorders = false;
            this.xrLabel143.StylePriority.UseFont = false;
            this.xrLabel143.StylePriority.UseForeColor = false;
            this.xrLabel143.StylePriority.UsePadding = false;
            this.xrLabel143.StylePriority.UseTextAlignment = false;
            this.xrLabel143.Text = "xrTableCell340";
            this.xrLabel143.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel144
            //
            this.xrLabel144.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel144.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_ArithmosEntolisErgolavou]")});
            this.xrLabel144.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel144.ForeColor = System.Drawing.Color.Black;
            this.xrLabel144.LocationFloat = new DevExpress.Utils.PointFloat(19.75397F, 542.2222F);
            this.xrLabel144.Name = "xrLabel144";
            this.xrLabel144.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel144.SizeF = new System.Drawing.SizeF(152.4446F, 21.77075F);
            this.xrLabel144.StylePriority.UseBorders = false;
            this.xrLabel144.StylePriority.UseFont = false;
            this.xrLabel144.StylePriority.UseForeColor = false;
            this.xrLabel144.StylePriority.UsePadding = false;
            this.xrLabel144.StylePriority.UseTextAlignment = false;
            this.xrLabel144.Text = "xrTableCell341";
            this.xrLabel144.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel145
            //
            this.xrLabel145.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel145.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_HmerominiaEntolis]")});
            this.xrLabel145.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel145.ForeColor = System.Drawing.Color.Black;
            this.xrLabel145.LocationFloat = new DevExpress.Utils.PointFloat(16.71104F, 502.2337F);
            this.xrLabel145.Name = "xrLabel145";
            this.xrLabel145.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel145.SizeF = new System.Drawing.SizeF(143.3287F, 17.52332F);
            this.xrLabel145.StylePriority.UseBorders = false;
            this.xrLabel145.StylePriority.UseFont = false;
            this.xrLabel145.StylePriority.UseForeColor = false;
            this.xrLabel145.StylePriority.UsePadding = false;
            this.xrLabel145.StylePriority.UseTextAlignment = false;
            this.xrLabel145.Text = "xrTableCell342";
            this.xrLabel145.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel146
            //
            this.xrLabel146.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel146.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BCC_Remarks]")});
            this.xrLabel146.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel146.ForeColor = System.Drawing.Color.Black;
            this.xrLabel146.LocationFloat = new DevExpress.Utils.PointFloat(14.90176F, 523.7152F);
            this.xrLabel146.Name = "xrLabel146";
            this.xrLabel146.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel146.SizeF = new System.Drawing.SizeF(159.599F, 15.26038F);
            this.xrLabel146.StylePriority.UseBorders = false;
            this.xrLabel146.StylePriority.UseFont = false;
            this.xrLabel146.StylePriority.UseForeColor = false;
            this.xrLabel146.StylePriority.UsePadding = false;
            this.xrLabel146.StylePriority.UseTextAlignment = false;
            this.xrLabel146.Text = "xrTableCell343";
            this.xrLabel146.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel147
            //
            this.xrLabel147.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel147.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpifaneiaSqMtrs]")});
            this.xrLabel147.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel147.ForeColor = System.Drawing.Color.Black;
            this.xrLabel147.LocationFloat = new DevExpress.Utils.PointFloat(17.28499F, 904.2825F);
            this.xrLabel147.Name = "xrLabel147";
            this.xrLabel147.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel147.SizeF = new System.Drawing.SizeF(125.5188F, 27.93994F);
            this.xrLabel147.StylePriority.UseBorders = false;
            this.xrLabel147.StylePriority.UseFont = false;
            this.xrLabel147.StylePriority.UseForeColor = false;
            this.xrLabel147.StylePriority.UsePadding = false;
            this.xrLabel147.StylePriority.UseTextAlignment = false;
            this.xrLabel147.Text = "xrTableCell344";
            this.xrLabel147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel148
            //
            this.xrLabel148.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel148.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosPlakon]")});
            this.xrLabel148.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel148.ForeColor = System.Drawing.Color.Black;
            this.xrLabel148.LocationFloat = new DevExpress.Utils.PointFloat(321.446F, 961.8289F);
            this.xrLabel148.Name = "xrLabel148";
            this.xrLabel148.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel148.SizeF = new System.Drawing.SizeF(220.3192F, 19.16656F);
            this.xrLabel148.StylePriority.UseBorders = false;
            this.xrLabel148.StylePriority.UseFont = false;
            this.xrLabel148.StylePriority.UseForeColor = false;
            this.xrLabel148.StylePriority.UsePadding = false;
            this.xrLabel148.StylePriority.UseTextAlignment = false;
            this.xrLabel148.Text = "xrTableCell345";
            this.xrLabel148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel149
            //
            this.xrLabel149.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel149.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosPlakon]")});
            this.xrLabel149.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel149.ForeColor = System.Drawing.Color.Black;
            this.xrLabel149.LocationFloat = new DevExpress.Utils.PointFloat(429.5072F, 839.4908F);
            this.xrLabel149.Name = "xrLabel149";
            this.xrLabel149.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel149.SizeF = new System.Drawing.SizeF(94.95342F, 21.25003F);
            this.xrLabel149.StylePriority.UseBorders = false;
            this.xrLabel149.StylePriority.UseFont = false;
            this.xrLabel149.StylePriority.UseForeColor = false;
            this.xrLabel149.StylePriority.UsePadding = false;
            this.xrLabel149.StylePriority.UseTextAlignment = false;
            this.xrLabel149.Text = "xrTableCell346";
            this.xrLabel149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel150
            //
            this.xrLabel150.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel150.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosTemaxion]")});
            this.xrLabel150.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel150.ForeColor = System.Drawing.Color.Black;
            this.xrLabel150.LocationFloat = new DevExpress.Utils.PointFloat(314.0958F, 838.9699F);
            this.xrLabel150.Name = "xrLabel150";
            this.xrLabel150.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel150.SizeF = new System.Drawing.SizeF(113.0161F, 17.86459F);
            this.xrLabel150.StylePriority.UseBorders = false;
            this.xrLabel150.StylePriority.UseFont = false;
            this.xrLabel150.StylePriority.UseForeColor = false;
            this.xrLabel150.StylePriority.UsePadding = false;
            this.xrLabel150.StylePriority.UseTextAlignment = false;
            this.xrLabel150.Text = "xrTableCell347";
            this.xrLabel150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel151
            //
            this.xrLabel151.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel151.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosEpemvasisNeasParoxis]")});
            this.xrLabel151.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel151.ForeColor = System.Drawing.Color.Black;
            this.xrLabel151.LocationFloat = new DevExpress.Utils.PointFloat(13.71447F, 474.2937F);
            this.xrLabel151.Name = "xrLabel151";
            this.xrLabel151.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel151.SizeF = new System.Drawing.SizeF(160.7863F, 27.94003F);
            this.xrLabel151.StylePriority.UseBorders = false;
            this.xrLabel151.StylePriority.UseFont = false;
            this.xrLabel151.StylePriority.UseForeColor = false;
            this.xrLabel151.StylePriority.UsePadding = false;
            this.xrLabel151.StylePriority.UseTextAlignment = false;
            this.xrLabel151.Text = "xrTableCell348";
            this.xrLabel151.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel152
            //
            this.xrLabel152.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel152.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProblimaPiesis]")});
            this.xrLabel152.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel152.ForeColor = System.Drawing.Color.Black;
            this.xrLabel152.LocationFloat = new DevExpress.Utils.PointFloat(479.0105F, 786.4178F);
            this.xrLabel152.Name = "xrLabel152";
            this.xrLabel152.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel152.SizeF = new System.Drawing.SizeF(93.94852F, 20.46878F);
            this.xrLabel152.StylePriority.UseBorders = false;
            this.xrLabel152.StylePriority.UseFont = false;
            this.xrLabel152.StylePriority.UseForeColor = false;
            this.xrLabel152.StylePriority.UsePadding = false;
            this.xrLabel152.StylePriority.UseTextAlignment = false;
            this.xrLabel152.Text = "xrTableCell351";
            this.xrLabel152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel153
            //
            this.xrLabel153.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel153.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Orofos]")});
            this.xrLabel153.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel153.ForeColor = System.Drawing.Color.Black;
            this.xrLabel153.LocationFloat = new DevExpress.Utils.PointFloat(312.9035F, 665.9144F);
            this.xrLabel153.Name = "xrLabel153";
            this.xrLabel153.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel153.SizeF = new System.Drawing.SizeF(55.26489F, 17.74298F);
            this.xrLabel153.StylePriority.UseBorders = false;
            this.xrLabel153.StylePriority.UseFont = false;
            this.xrLabel153.StylePriority.UseForeColor = false;
            this.xrLabel153.StylePriority.UsePadding = false;
            this.xrLabel153.StylePriority.UseTextAlignment = false;
            this.xrLabel153.Text = "xrTableCell352";
            this.xrLabel153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel154
            //
            this.xrLabel154.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel154.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaAnagelias]")});
            this.xrLabel154.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel154.ForeColor = System.Drawing.Color.Black;
            this.xrLabel154.LocationFloat = new DevExpress.Utils.PointFloat(316.3516F, 1332.512F);
            this.xrLabel154.Name = "xrLabel154";
            this.xrLabel154.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel154.SizeF = new System.Drawing.SizeF(128.4349F, 21.25006F);
            this.xrLabel154.StylePriority.UseBorders = false;
            this.xrLabel154.StylePriority.UseFont = false;
            this.xrLabel154.StylePriority.UseForeColor = false;
            this.xrLabel154.StylePriority.UsePadding = false;
            this.xrLabel154.StylePriority.UseTextAlignment = false;
            this.xrLabel154.Text = "xrTableCell353";
            this.xrLabel154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel155
            //
            this.xrLabel155.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel155.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraAnagelias]")});
            this.xrLabel155.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel155.ForeColor = System.Drawing.Color.Black;
            this.xrLabel155.LocationFloat = new DevExpress.Utils.PointFloat(377.2068F, 667.72F);
            this.xrLabel155.Name = "xrLabel155";
            this.xrLabel155.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel155.SizeF = new System.Drawing.SizeF(89.66589F, 17.86462F);
            this.xrLabel155.StylePriority.UseBorders = false;
            this.xrLabel155.StylePriority.UseFont = false;
            this.xrLabel155.StylePriority.UseForeColor = false;
            this.xrLabel155.StylePriority.UsePadding = false;
            this.xrLabel155.StylePriority.UseTextAlignment = false;
            this.xrLabel155.Text = "xrTableCell354";
            this.xrLabel155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel156
            //
            this.xrLabel156.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel156.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EnergeiesProblimatosPiesis]")});
            this.xrLabel156.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel156.ForeColor = System.Drawing.Color.Black;
            this.xrLabel156.LocationFloat = new DevExpress.Utils.PointFloat(32.33135F, 941.7247F);
            this.xrLabel156.Name = "xrLabel156";
            this.xrLabel156.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel156.SizeF = new System.Drawing.SizeF(158.6295F, 15.93741F);
            this.xrLabel156.StylePriority.UseBorders = false;
            this.xrLabel156.StylePriority.UseFont = false;
            this.xrLabel156.StylePriority.UseForeColor = false;
            this.xrLabel156.StylePriority.UsePadding = false;
            this.xrLabel156.StylePriority.UseTextAlignment = false;
            this.xrLabel156.Text = "xrTableCell355";
            this.xrLabel156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel157
            //
            this.xrLabel157.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel157.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AitioProblimatosId]")});
            this.xrLabel157.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel157.ForeColor = System.Drawing.Color.Black;
            this.xrLabel157.LocationFloat = new DevExpress.Utils.PointFloat(396.7121F, 737.668F);
            this.xrLabel157.Name = "xrLabel157";
            this.xrLabel157.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel157.SizeF = new System.Drawing.SizeF(104.1876F, 20.46863F);
            this.xrLabel157.StylePriority.UseBorders = false;
            this.xrLabel157.StylePriority.UseFont = false;
            this.xrLabel157.StylePriority.UseForeColor = false;
            this.xrLabel157.StylePriority.UsePadding = false;
            this.xrLabel157.StylePriority.UseTextAlignment = false;
            this.xrLabel157.Text = "xrTableCell356";
            this.xrLabel157.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel158
            //
            this.xrLabel158.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel158.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosAitimatos]")});
            this.xrLabel158.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel158.ForeColor = System.Drawing.Color.Black;
            this.xrLabel158.LocationFloat = new DevExpress.Utils.PointFloat(314.8826F, 806.8865F);
            this.xrLabel158.Name = "xrLabel158";
            this.xrLabel158.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel158.SizeF = new System.Drawing.SizeF(106.8211F, 27.94003F);
            this.xrLabel158.StylePriority.UseBorders = false;
            this.xrLabel158.StylePriority.UseFont = false;
            this.xrLabel158.StylePriority.UseForeColor = false;
            this.xrLabel158.StylePriority.UsePadding = false;
            this.xrLabel158.StylePriority.UseTextAlignment = false;
            this.xrLabel158.Text = "xrTableCell357";
            this.xrLabel158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel159
            //
            this.xrLabel159.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel159.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ThesiTermatos]")});
            this.xrLabel159.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel159.ForeColor = System.Drawing.Color.Black;
            this.xrLabel159.LocationFloat = new DevExpress.Utils.PointFloat(388.6097F, 642.8414F);
            this.xrLabel159.Name = "xrLabel159";
            this.xrLabel159.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel159.SizeF = new System.Drawing.SizeF(95.94321F, 23.07294F);
            this.xrLabel159.StylePriority.UseBorders = false;
            this.xrLabel159.StylePriority.UseFont = false;
            this.xrLabel159.StylePriority.UseForeColor = false;
            this.xrLabel159.StylePriority.UsePadding = false;
            this.xrLabel159.StylePriority.UseTextAlignment = false;
            this.xrLabel159.Text = "xrTableCell358";
            this.xrLabel159.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel160
            //
            this.xrLabel160.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel160.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BackEndTabletId]")});
            this.xrLabel160.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel160.ForeColor = System.Drawing.Color.Black;
            this.xrLabel160.LocationFloat = new DevExpress.Utils.PointFloat(312.0644F, 887.0255F);
            this.xrLabel160.Name = "xrLabel160";
            this.xrLabel160.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel160.SizeF = new System.Drawing.SizeF(109.7736F, 18.00919F);
            this.xrLabel160.StylePriority.UseBorders = false;
            this.xrLabel160.StylePriority.UseFont = false;
            this.xrLabel160.StylePriority.UseForeColor = false;
            this.xrLabel160.StylePriority.UsePadding = false;
            this.xrLabel160.StylePriority.UseTextAlignment = false;
            this.xrLabel160.Text = "xrTableCell359";
            this.xrLabel160.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel161
            //
            this.xrLabel161.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel161.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpilegmeniApomonosi]")});
            this.xrLabel161.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel161.ForeColor = System.Drawing.Color.Black;
            this.xrLabel161.LocationFloat = new DevExpress.Utils.PointFloat(495.6375F, 648.3911F);
            this.xrLabel161.Name = "xrLabel161";
            this.xrLabel161.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel161.SizeF = new System.Drawing.SizeF(126.5862F, 17.52332F);
            this.xrLabel161.StylePriority.UseBorders = false;
            this.xrLabel161.StylePriority.UseFont = false;
            this.xrLabel161.StylePriority.UseForeColor = false;
            this.xrLabel161.StylePriority.UsePadding = false;
            this.xrLabel161.StylePriority.UseTextAlignment = false;
            this.xrLabel161.Text = "xrTableCell360";
            this.xrLabel161.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel162
            //
            this.xrLabel162.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel162.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IDApomonosis]")});
            this.xrLabel162.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel162.ForeColor = System.Drawing.Color.Black;
            this.xrLabel162.LocationFloat = new DevExpress.Utils.PointFloat(488.5552F, 671.3306F);
            this.xrLabel162.Name = "xrLabel162";
            this.xrLabel162.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel162.SizeF = new System.Drawing.SizeF(153.5529F, 12.32678F);
            this.xrLabel162.StylePriority.UseBorders = false;
            this.xrLabel162.StylePriority.UseFont = false;
            this.xrLabel162.StylePriority.UseForeColor = false;
            this.xrLabel162.StylePriority.UsePadding = false;
            this.xrLabel162.StylePriority.UseTextAlignment = false;
            this.xrLabel162.Text = "xrTableCell361";
            this.xrLabel162.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel163
            //
            this.xrLabel163.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel163.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DiametrosPyrosvestikouKrounouParoxis]")});
            this.xrLabel163.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel163.ForeColor = System.Drawing.Color.Black;
            this.xrLabel163.LocationFloat = new DevExpress.Utils.PointFloat(314.9951F, 624.9768F);
            this.xrLabel163.Name = "xrLabel163";
            this.xrLabel163.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel163.SizeF = new System.Drawing.SizeF(222.5211F, 17.86459F);
            this.xrLabel163.StylePriority.UseBorders = false;
            this.xrLabel163.StylePriority.UseFont = false;
            this.xrLabel163.StylePriority.UseForeColor = false;
            this.xrLabel163.StylePriority.UsePadding = false;
            this.xrLabel163.StylePriority.UseTextAlignment = false;
            this.xrLabel163.Text = "xrTableCell362";
            this.xrLabel163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel164
            //
            this.xrLabel164.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel164.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OximataEpanaforas]")});
            this.xrLabel164.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel164.ForeColor = System.Drawing.Color.Black;
            this.xrLabel164.LocationFloat = new DevExpress.Utils.PointFloat(311.3003F, 581.5395F);
            this.xrLabel164.Name = "xrLabel164";
            this.xrLabel164.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel164.SizeF = new System.Drawing.SizeF(118.158F, 20.35876F);
            this.xrLabel164.StylePriority.UseBorders = false;
            this.xrLabel164.StylePriority.UseFont = false;
            this.xrLabel164.StylePriority.UseForeColor = false;
            this.xrLabel164.StylePriority.UsePadding = false;
            this.xrLabel164.StylePriority.UseTextAlignment = false;
            this.xrLabel164.Text = "xrTableCell363";
            this.xrLabel164.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel165
            //
            this.xrLabel165.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel165.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpanaforaOdostromatosType]")});
            this.xrLabel165.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel165.ForeColor = System.Drawing.Color.Black;
            this.xrLabel165.LocationFloat = new DevExpress.Utils.PointFloat(309.9888F, 601.8983F);
            this.xrLabel165.Name = "xrLabel165";
            this.xrLabel165.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel165.SizeF = new System.Drawing.SizeF(197.2455F, 23.07294F);
            this.xrLabel165.StylePriority.UseBorders = false;
            this.xrLabel165.StylePriority.UseFont = false;
            this.xrLabel165.StylePriority.UseForeColor = false;
            this.xrLabel165.StylePriority.UsePadding = false;
            this.xrLabel165.StylePriority.UseTextAlignment = false;
            this.xrLabel165.Text = "xrTableCell364";
            this.xrLabel165.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel166
            //
            this.xrLabel166.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel166.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpanaforaPezodromiouType]")});
            this.xrLabel166.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel166.ForeColor = System.Drawing.Color.Black;
            this.xrLabel166.LocationFloat = new DevExpress.Utils.PointFloat(312.5938F, 558.4666F);
            this.xrLabel166.Name = "xrLabel166";
            this.xrLabel166.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel166.SizeF = new System.Drawing.SizeF(118.6064F, 23.07294F);
            this.xrLabel166.StylePriority.UseBorders = false;
            this.xrLabel166.StylePriority.UseFont = false;
            this.xrLabel166.StylePriority.UseForeColor = false;
            this.xrLabel166.StylePriority.UsePadding = false;
            this.xrLabel166.StylePriority.UseTextAlignment = false;
            this.xrLabel166.Text = "xrTableCell365";
            this.xrLabel166.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel167
            //
            this.xrLabel167.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel167.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DiktyoParoxi]")});
            this.xrLabel167.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel167.ForeColor = System.Drawing.Color.Black;
            this.xrLabel167.LocationFloat = new DevExpress.Utils.PointFloat(436.7043F, 578.8253F);
            this.xrLabel167.Name = "xrLabel167";
            this.xrLabel167.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel167.SizeF = new System.Drawing.SizeF(132.5717F, 23.07294F);
            this.xrLabel167.StylePriority.UseBorders = false;
            this.xrLabel167.StylePriority.UseFont = false;
            this.xrLabel167.StylePriority.UseForeColor = false;
            this.xrLabel167.StylePriority.UsePadding = false;
            this.xrLabel167.StylePriority.UseTextAlignment = false;
            this.xrLabel167.Text = "xrTableCell366";
            this.xrLabel167.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel168
            //
            this.xrLabel168.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel168.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProblemCategory]")});
            this.xrLabel168.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel168.ForeColor = System.Drawing.Color.Black;
            this.xrLabel168.LocationFloat = new DevExpress.Utils.PointFloat(314.9951F, 542.2221F);
            this.xrLabel168.Name = "xrLabel168";
            this.xrLabel168.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel168.SizeF = new System.Drawing.SizeF(209.4654F, 11.0246F);
            this.xrLabel168.StylePriority.UseBorders = false;
            this.xrLabel168.StylePriority.UseFont = false;
            this.xrLabel168.StylePriority.UseForeColor = false;
            this.xrLabel168.StylePriority.UsePadding = false;
            this.xrLabel168.StylePriority.UseTextAlignment = false;
            this.xrLabel168.Text = "xrTableCell367";
            this.xrLabel168.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel169
            //
            this.xrLabel169.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel169.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosProblematos]")});
            this.xrLabel169.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel169.ForeColor = System.Drawing.Color.Black;
            this.xrLabel169.LocationFloat = new DevExpress.Utils.PointFloat(311.7832F, 521.8168F);
            this.xrLabel169.Name = "xrLabel169";
            this.xrLabel169.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel169.SizeF = new System.Drawing.SizeF(158.7885F, 17.15884F);
            this.xrLabel169.StylePriority.UseBorders = false;
            this.xrLabel169.StylePriority.UseFont = false;
            this.xrLabel169.StylePriority.UseForeColor = false;
            this.xrLabel169.StylePriority.UsePadding = false;
            this.xrLabel169.StylePriority.UseTextAlignment = false;
            this.xrLabel169.Text = "xrTableCell368";
            this.xrLabel169.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel170
            //
            this.xrLabel170.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel170.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diagnosi]")});
            this.xrLabel170.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel170.ForeColor = System.Drawing.Color.Black;
            this.xrLabel170.LocationFloat = new DevExpress.Utils.PointFloat(554.4592F, 180.8044F);
            this.xrLabel170.Name = "xrLabel170";
            this.xrLabel170.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel170.SizeF = new System.Drawing.SizeF(87.12921F, 20.46875F);
            this.xrLabel170.StylePriority.UseBorders = false;
            this.xrLabel170.StylePriority.UseFont = false;
            this.xrLabel170.StylePriority.UseForeColor = false;
            this.xrLabel170.StylePriority.UsePadding = false;
            this.xrLabel170.StylePriority.UseTextAlignment = false;
            this.xrLabel170.Text = "xrTableCell369";
            this.xrLabel170.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLabel171
            //
            this.xrLabel171.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel171.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Symperasma]")});
            this.xrLabel171.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrLabel171.ForeColor = System.Drawing.Color.Black;
            this.xrLabel171.LocationFloat = new DevExpress.Utils.PointFloat(148.2822F, 411.1113F);
            this.xrLabel171.Name = "xrLabel171";
            this.xrLabel171.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel171.SizeF = new System.Drawing.SizeF(176.2433F, 16.5625F);
            this.xrLabel171.StylePriority.UseBorders = false;
            this.xrLabel171.StylePriority.UseFont = false;
            this.xrLabel171.StylePriority.UseForeColor = false;
            this.xrLabel171.StylePriority.UsePadding = false;
            this.xrLabel171.StylePriority.UseTextAlignment = false;
            this.xrLabel171.Text = "xrTableCell370";
            this.xrLabel171.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // TopMargin
            //
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.TopMargin.HeightF = 104.125F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrLabel5
            //
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.776287F, 61.99999F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel5.StyleName = "Title";
            this.xrLabel5.Text = "PORTAL ΥΔΡΕΥΣΗΣ";
            //
            // xrLabel4
            //
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(4.876009F, 36F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel4.StyleName = "Title";
            this.xrLabel4.Text = "ΔΙΕΥΘΥΝΣΗ ΔΙΚΤΥΟΥ ΥΔΡΕΥΣΗΣ";
            //
            // xrLabel3
            //
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.875946F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel3.StyleName = "Title";
            this.xrLabel3.Text = "ΕΥΔΑΠ Α.Ε.";
            //
            // BottomMargin
            //
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.HeightF = 34.87498F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrPageInfo1
            //
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StyleName = "PageInfo";
            //
            // xrPageInfo2
            //
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(331F, 6F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo2.TextFormatString = "Page {0} of {1}";
            //
            // sqlDataSource1
            //
            this.sqlDataSource1.ConnectionName = "sql";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "AssignmentId";
            table1.Name = "Visits";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "DateOfAssignment";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "DateOfCompletion";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "Status";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "Task_Id";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "Comments";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "TaskTypeId";
            columnExpression7.Table = table1;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "Incident_Id";
            columnExpression8.Table = table1;
            column8.Expression = columnExpression8;
            columnExpression9.ColumnName = "Task_Description";
            columnExpression9.Table = table1;
            column9.Expression = columnExpression9;
            columnExpression10.ColumnName = "SynergeioEpemvasis";
            columnExpression10.Table = table1;
            column10.Expression = columnExpression10;
            columnExpression11.ColumnName = "SynergeioElegxou";
            columnExpression11.Table = table1;
            column11.Expression = columnExpression11;
            columnExpression12.ColumnName = "SynergeioApomonosis";
            columnExpression12.Table = table1;
            column12.Expression = columnExpression12;
            columnExpression13.ColumnName = "SynergeioEpanaforas";
            columnExpression13.Table = table1;
            column13.Expression = columnExpression13;
            columnExpression14.ColumnName = "ControlDate";
            columnExpression14.Table = table1;
            column14.Expression = columnExpression14;
            columnExpression15.ColumnName = "ControlTime";
            columnExpression15.Table = table1;
            column15.Expression = columnExpression15;
            columnExpression16.ColumnName = "Epemvasi_VardiaSynergeiou";
            columnExpression16.Table = table1;
            column16.Expression = columnExpression16;
            columnExpression17.ColumnName = "Epemvasi_ArithmosAtomonSynergeiou";
            columnExpression17.Table = table1;
            column17.Expression = columnExpression17;
            columnExpression18.ColumnName = "Porisma";
            columnExpression18.Table = table1;
            column18.Expression = columnExpression18;
            columnExpression19.ColumnName = "Energeies";
            columnExpression19.Table = table1;
            column19.Expression = columnExpression19;
            columnExpression20.ColumnName = "PositionOfGeotrisi";
            columnExpression20.Table = table1;
            column20.Expression = columnExpression20;
            columnExpression21.ColumnName = "ResultsOfChemeio";
            columnExpression21.Table = table1;
            column21.Expression = columnExpression21;
            columnExpression22.ColumnName = "Remarks";
            columnExpression22.Table = table1;
            column22.Expression = columnExpression22;
            columnExpression23.ColumnName = "MAP";
            columnExpression23.Table = table1;
            column23.Expression = columnExpression23;
            columnExpression24.ColumnName = "VanaDiametros";
            columnExpression24.Table = table1;
            column24.Expression = columnExpression24;
            columnExpression25.ColumnName = "AgogosDiametros";
            columnExpression25.Table = table1;
            column25.Expression = columnExpression25;
            columnExpression26.ColumnName = "MetritisDiametros";
            columnExpression26.Table = table1;
            column26.Expression = columnExpression26;
            columnExpression27.ColumnName = "PyrosvestikiParoxiDiametros";
            columnExpression27.Table = table1;
            column27.Expression = columnExpression27;
            columnExpression28.ColumnName = "ZoniPiesis";
            columnExpression28.Table = table1;
            column28.Expression = columnExpression28;
            columnExpression29.ColumnName = "Zoni";
            columnExpression29.Table = table1;
            column29.Expression = columnExpression29;
            columnExpression30.ColumnName = "Eidopoiisi";
            columnExpression30.Table = table1;
            column30.Expression = columnExpression30;
            columnExpression31.ColumnName = "HmerominiaApomonosis";
            columnExpression31.Table = table1;
            column31.Expression = columnExpression31;
            columnExpression32.ColumnName = "OraApomonosis";
            columnExpression32.Table = table1;
            column32.Expression = columnExpression32;
            columnExpression33.ColumnName = "EkplisiTermatos";
            columnExpression33.Table = table1;
            column33.Expression = columnExpression33;
            columnExpression34.ColumnName = "PyrosvestikouGeranouDiametros";
            columnExpression34.Table = table1;
            column34.Expression = columnExpression34;
            columnExpression35.ColumnName = "Apomonosi_HmerominiaAnaxorisis";
            columnExpression35.Table = table1;
            column35.Expression = columnExpression35;
            columnExpression36.ColumnName = "Apomonosi_OraAnaxorisis";
            columnExpression36.Table = table1;
            column36.Expression = columnExpression36;
            columnExpression37.ColumnName = "Apomonosi_HmerominiaAfixis";
            columnExpression37.Table = table1;
            column37.Expression = columnExpression37;
            columnExpression38.ColumnName = "Apomonosi_OraAfixis";
            columnExpression38.Table = table1;
            column38.Expression = columnExpression38;
            columnExpression39.ColumnName = "Apomonosi_HmerominiaEpistrofis";
            columnExpression39.Table = table1;
            column39.Expression = columnExpression39;
            columnExpression40.ColumnName = "Apomonosi_OraEpistrofis";
            columnExpression40.Table = table1;
            column40.Expression = columnExpression40;
            columnExpression41.ColumnName = "HmerominiaEpanaforas";
            columnExpression41.Table = table1;
            column41.Expression = columnExpression41;
            columnExpression42.ColumnName = "OraEpanaforas";
            columnExpression42.Table = table1;
            column42.Expression = columnExpression42;
            columnExpression43.ColumnName = "EidosEpanaforas";
            columnExpression43.Table = table1;
            column43.Expression = columnExpression43;
            columnExpression44.ColumnName = "Epanafora_HmerominiaAnaxorisis";
            columnExpression44.Table = table1;
            column44.Expression = columnExpression44;
            columnExpression45.ColumnName = "Epanafora_OraAnaxorisis";
            columnExpression45.Table = table1;
            column45.Expression = columnExpression45;
            columnExpression46.ColumnName = "Epanafora_HmerominiaAfixis";
            columnExpression46.Table = table1;
            column46.Expression = columnExpression46;
            columnExpression47.ColumnName = "Epanafora_OraAfixis";
            columnExpression47.Table = table1;
            column47.Expression = columnExpression47;
            columnExpression48.ColumnName = "Epanafora_HmerominiaEpistrofis";
            columnExpression48.Table = table1;
            column48.Expression = columnExpression48;
            columnExpression49.ColumnName = "Epanafora_OraEpistrofis";
            columnExpression49.Table = table1;
            column49.Expression = columnExpression49;
            columnExpression50.ColumnName = "Apomonosi_ArithmosAtomonSynergeiou";
            columnExpression50.Table = table1;
            column50.Expression = columnExpression50;
            columnExpression51.ColumnName = "Epanafora_ArithmosAtomonSynergeiou";
            columnExpression51.Table = table1;
            column51.Expression = columnExpression51;
            columnExpression52.ColumnName = "Apomonosi_VardiaSynergeiou";
            columnExpression52.Table = table1;
            column52.Expression = columnExpression52;
            columnExpression53.ColumnName = "Epanafora_VardiaSynergeiou";
            columnExpression53.Table = table1;
            column53.Expression = columnExpression53;
            columnExpression54.ColumnName = "Apomonosi_ArirthosVanonPouXeiristikan";
            columnExpression54.Table = table1;
            column54.Expression = columnExpression54;
            columnExpression55.ColumnName = "Apomonosi_KatastasiVanonPouXeiristikan";
            columnExpression55.Table = table1;
            column55.Expression = columnExpression55;
            columnExpression56.ColumnName = "Apomonosi_ThesiVanonPouXeiristikan";
            columnExpression56.Table = table1;
            column56.Expression = columnExpression56;
            columnExpression57.ColumnName = "SyntetagmenesVlavis";
            columnExpression57.Table = table1;
            column57.Expression = columnExpression57;
            columnExpression58.ColumnName = "AgogosYliko";
            columnExpression58.Table = table1;
            column58.Expression = columnExpression58;
            columnExpression59.ColumnName = "TopothetisiKatagrafikou";
            columnExpression59.Table = table1;
            column59.Expression = columnExpression59;
            columnExpression60.ColumnName = "GnomateusiThesi";
            columnExpression60.Table = table1;
            column60.Expression = columnExpression60;
            columnExpression61.ColumnName = "GnomateusiMikos";
            columnExpression61.Table = table1;
            column61.Expression = columnExpression61;
            columnExpression62.ColumnName = "GnomateusiDiametros";
            columnExpression62.Table = table1;
            column62.Expression = columnExpression62;
            columnExpression63.ColumnName = "GnomateusiYliko";
            columnExpression63.Table = table1;
            column63.Expression = columnExpression63;
            columnExpression64.ColumnName = "Attachments";
            columnExpression64.Table = table1;
            column64.Expression = columnExpression64;
            columnExpression65.ColumnName = "Epanafora_ArirthosVanonPouXeiristikan";
            columnExpression65.Table = table1;
            column65.Expression = columnExpression65;
            columnExpression66.ColumnName = "Epanafora_KatastasiVanonPouXeiristikan";
            columnExpression66.Table = table1;
            column66.Expression = columnExpression66;
            columnExpression67.ColumnName = "Epanafora_ThesiVanonPouXeiristikan";
            columnExpression67.Table = table1;
            column67.Expression = columnExpression67;
            columnExpression68.ColumnName = "Oximata";
            columnExpression68.Table = table1;
            column68.Expression = columnExpression68;
            columnExpression69.ColumnName = "TaskScheduleDate";
            columnExpression69.Table = table1;
            column69.Expression = columnExpression69;
            columnExpression70.ColumnName = "HmerominiaEnarxisErgasion";
            columnExpression70.Table = table1;
            column70.Expression = columnExpression70;
            columnExpression71.ColumnName = "OraEnarxisErgasion";
            columnExpression71.Table = table1;
            column71.Expression = columnExpression71;
            columnExpression72.ColumnName = "HmerominiaLixisErgasion";
            columnExpression72.Table = table1;
            column72.Expression = columnExpression72;
            columnExpression73.ColumnName = "OraLixisErgasion";
            columnExpression73.Table = table1;
            column73.Expression = columnExpression73;
            columnExpression74.ColumnName = "OnomaVanas";
            columnExpression74.Table = table1;
            column74.Expression = columnExpression74;
            columnExpression75.ColumnName = "ThesiVanas";
            columnExpression75.Table = table1;
            column75.Expression = columnExpression75;
            columnExpression76.ColumnName = "KatastasiVanas";
            columnExpression76.Table = table1;
            column76.Expression = columnExpression76;
            columnExpression77.ColumnName = "KalymaEidos";
            columnExpression77.Table = table1;
            column77.Expression = columnExpression77;
            columnExpression78.ColumnName = "KalymaDiastaseis";
            columnExpression78.Table = table1;
            column78.Expression = columnExpression78;
            columnExpression79.ColumnName = "FreatioEidos";
            columnExpression79.Table = table1;
            column79.Expression = columnExpression79;
            columnExpression80.ColumnName = "FreatioDiastaseis";
            columnExpression80.Table = table1;
            column80.Expression = columnExpression80;
            columnExpression81.ColumnName = "HmerominiaEpemvasis";
            columnExpression81.Table = table1;
            column81.Expression = columnExpression81;
            columnExpression82.ColumnName = "OraEpemvasis";
            columnExpression82.Table = table1;
            column82.Expression = columnExpression82;
            columnExpression83.ColumnName = "OnomaDexamenis";
            columnExpression83.Table = table1;
            column83.Expression = columnExpression83;
            columnExpression84.ColumnName = "ThesiDexamenis";
            columnExpression84.Table = table1;
            column84.Expression = columnExpression84;
            columnExpression85.ColumnName = "ThalamosDexamenis";
            columnExpression85.Table = table1;
            column85.Expression = columnExpression85;
            columnExpression86.ColumnName = "SimeioEkkenosis";
            columnExpression86.Table = table1;
            column86.Expression = columnExpression86;
            columnExpression87.ColumnName = "ArithmosAntlion";
            columnExpression87.Table = table1;
            column87.Expression = columnExpression87;
            columnExpression88.ColumnName = "MegaliMikriAntlia";
            columnExpression88.Table = table1;
            column88.Expression = columnExpression88;
            columnExpression89.ColumnName = "EidosTermatos";
            columnExpression89.Table = table1;
            column89.Expression = columnExpression89;
            columnExpression90.ColumnName = "PRV_Xeirismos";
            columnExpression90.Table = table1;
            column90.Expression = columnExpression90;
            columnExpression91.ColumnName = "EparkeiaYlikon";
            columnExpression91.Table = table1;
            column91.Expression = columnExpression91;
            columnExpression92.ColumnName = "EidosProblimatos";
            columnExpression92.Table = table1;
            column92.Expression = columnExpression92;
            columnExpression93.ColumnName = "EidosEpemvasis";
            columnExpression93.Table = table1;
            column93.Expression = columnExpression93;
            columnExpression94.ColumnName = "SynergeioPRV";
            columnExpression94.Table = table1;
            column94.Expression = columnExpression94;
            columnExpression95.ColumnName = "OnomaPRV";
            columnExpression95.Table = table1;
            column95.Expression = columnExpression95;
            columnExpression96.ColumnName = "ThesiPRV";
            columnExpression96.Table = table1;
            column96.Expression = columnExpression96;
            columnExpression97.ColumnName = "DiametrosPRV";
            columnExpression97.Table = table1;
            column97.Expression = columnExpression97;
            columnExpression98.ColumnName = "KatastasiPRV";
            columnExpression98.Table = table1;
            column98.Expression = columnExpression98;
            columnExpression99.ColumnName = "PRVVardiaSynergeiou";
            columnExpression99.Table = table1;
            column99.Expression = columnExpression99;
            columnExpression100.ColumnName = "PRVArithmosAtomonSynergeiou";
            columnExpression100.Table = table1;
            column100.Expression = columnExpression100;
            columnExpression101.ColumnName = "Ergolavia";
            columnExpression101.Table = table1;
            column101.Expression = columnExpression101;
            columnExpression102.ColumnName = "Idiotiko";
            columnExpression102.Table = table1;
            column102.Expression = columnExpression102;
            columnExpression103.ColumnName = "TroposEntopismou";
            columnExpression103.Table = table1;
            column103.Expression = columnExpression103;
            columnExpression104.ColumnName = "EidosVlavis";
            columnExpression104.Table = table1;
            column104.Expression = columnExpression104;
            columnExpression105.ColumnName = "AitiaVlavis";
            columnExpression105.Table = table1;
            column105.Expression = columnExpression105;
            columnExpression106.ColumnName = "OnomasiaThesis";
            columnExpression106.Table = table1;
            column106.Expression = columnExpression106;
            columnExpression107.ColumnName = "Ekkremotites";
            columnExpression107.Table = table1;
            column107.Expression = columnExpression107;
            columnExpression108.ColumnName = "ProteinomenoSimeio_Dimos";
            columnExpression108.Table = table1;
            column108.Expression = columnExpression108;
            columnExpression109.ColumnName = "ProteinomenoSimeio_Odos";
            columnExpression109.Table = table1;
            column109.Expression = columnExpression109;
            columnExpression110.ColumnName = "ProteinomenoSimeio_Atihmos";
            columnExpression110.Table = table1;
            column110.Expression = columnExpression110;
            columnExpression111.ColumnName = "ProteinomenoSimeio_SyntetagmeniX";
            columnExpression111.Table = table1;
            column111.Expression = columnExpression111;
            columnExpression112.ColumnName = "ProteinomenoSimeio_SyntetagmeniY";
            columnExpression112.Table = table1;
            column112.Expression = columnExpression112;
            columnExpression113.ColumnName = "OnomasiaAntliostasiou";
            columnExpression113.Table = table1;
            column113.Expression = columnExpression113;
            columnExpression114.ColumnName = "HmerominiaApokatastasis";
            columnExpression114.Table = table1;
            column114.Expression = columnExpression114;
            columnExpression115.ColumnName = "OraApokatastasis";
            columnExpression115.Table = table1;
            column115.Expression = columnExpression115;
            columnExpression116.ColumnName = "Parapono";
            columnExpression116.Table = table1;
            column116.Expression = columnExpression116;
            columnExpression117.ColumnName = "EktaktoDeigma";
            columnExpression117.Table = table1;
            column117.Expression = columnExpression117;
            columnExpression118.ColumnName = "MetrisiCLMeLovipond";
            columnExpression118.Table = table1;
            column118.Expression = columnExpression118;
            columnExpression119.ColumnName = "MetrisiCLMeSwan";
            columnExpression119.Table = table1;
            column119.Expression = columnExpression119;
            columnExpression120.ColumnName = "MetrisiCLMeFotometroLovipond";
            columnExpression120.Table = table1;
            column120.Expression = columnExpression120;
            columnExpression121.ColumnName = "MetrisiApolimantikonMeSwan";
            columnExpression121.Table = table1;
            column121.Expression = columnExpression121;
            columnExpression122.ColumnName = "MetrisiApolimantikonMePalintest";
            columnExpression122.Table = table1;
            column122.Expression = columnExpression122;
            columnExpression123.ColumnName = "HmerominiaDeigmatolipsias";
            columnExpression123.Table = table1;
            column123.Expression = columnExpression123;
            columnExpression124.ColumnName = "OraDeigmatolipsias";
            columnExpression124.Table = table1;
            column124.Expression = columnExpression124;
            columnExpression125.ColumnName = "CLPedio";
            columnExpression125.Table = table1;
            column125.Expression = columnExpression125;
            columnExpression126.ColumnName = "CLMetatropi";
            columnExpression126.Table = table1;
            column126.Expression = columnExpression126;
            columnExpression127.ColumnName = "MetrisiYpolCLPedioA";
            columnExpression127.Table = table1;
            column127.Expression = columnExpression127;
            columnExpression128.ColumnName = "DiorthosiCL02PedioB";
            columnExpression128.Table = table1;
            column128.Expression = columnExpression128;
            columnExpression129.ColumnName = "CL_A_B";
            columnExpression129.Table = table1;
            column129.Expression = columnExpression129;
            columnExpression130.ColumnName = "CLO2";
            columnExpression130.Table = table1;
            column130.Expression = columnExpression130;
            columnExpression131.ColumnName = "Deigmatoliptis";
            columnExpression131.Table = table1;
            column131.Expression = columnExpression131;
            columnExpression132.ColumnName = "ArithmosMetriti";
            columnExpression132.Table = table1;
            column132.Expression = columnExpression132;
            columnExpression133.ColumnName = "EpipleonDeigma1";
            columnExpression133.Table = table1;
            column133.Expression = columnExpression133;
            columnExpression134.ColumnName = "EpipleonCL1";
            columnExpression134.Table = table1;
            column134.Expression = columnExpression134;
            columnExpression135.ColumnName = "EpipleonDeigma2";
            columnExpression135.Table = table1;
            column135.Expression = columnExpression135;
            columnExpression136.ColumnName = "EpipleonCL2";
            columnExpression136.Table = table1;
            column136.Expression = columnExpression136;
            columnExpression137.ColumnName = "EpipleonDeigma3";
            columnExpression137.Table = table1;
            column137.Expression = columnExpression137;
            columnExpression138.ColumnName = "EpipleonCL3";
            columnExpression138.Table = table1;
            column138.Expression = columnExpression138;
            columnExpression139.ColumnName = "EpipleonDeigma4";
            columnExpression139.Table = table1;
            column139.Expression = columnExpression139;
            columnExpression140.ColumnName = "EpipleonCL4";
            columnExpression140.Table = table1;
            column140.Expression = columnExpression140;
            columnExpression141.ColumnName = "RemarksFromTablet";
            columnExpression141.Table = table1;
            column141.Expression = columnExpression141;
            columnExpression142.ColumnName = "AddressMunicipality";
            columnExpression142.Table = table1;
            column142.Expression = columnExpression142;
            columnExpression143.ColumnName = "AddressOdos";
            columnExpression143.Table = table1;
            column143.Expression = columnExpression143;
            columnExpression144.ColumnName = "AddressArithmos";
            columnExpression144.Table = table1;
            column144.Expression = columnExpression144;
            columnExpression145.ColumnName = "ThesiAgogou";
            columnExpression145.Table = table1;
            column145.Expression = columnExpression145;
            columnExpression146.ColumnName = "AgogosMikos";
            columnExpression146.Table = table1;
            column146.Expression = columnExpression146;
            columnExpression147.ColumnName = "ArithmosVanon";
            columnExpression147.Table = table1;
            column147.Expression = columnExpression147;
            columnExpression148.ColumnName = "ElegxosPiesisGiaEidikiParoxi";
            columnExpression148.Table = table1;
            column148.Expression = columnExpression148;
            columnExpression149.ColumnName = "AgogosDiatomi";
            columnExpression149.Table = table1;
            column149.Expression = columnExpression149;
            columnExpression150.ColumnName = "ThesiEidikisParoxis";
            columnExpression150.Table = table1;
            column150.Expression = columnExpression150;
            columnExpression151.ColumnName = "ThesiKataskeyisNeasParoxis";
            columnExpression151.Table = table1;
            column151.Expression = columnExpression151;
            columnExpression152.ColumnName = "BCC_HmerominiaAnagelias";
            columnExpression152.Table = table1;
            column152.Expression = columnExpression152;
            columnExpression153.ColumnName = "BCC_OraAnagelias";
            columnExpression153.Table = table1;
            column153.Expression = columnExpression153;
            columnExpression154.ColumnName = "BCC_ArithmosAitimatos";
            columnExpression154.Table = table1;
            column154.Expression = columnExpression154;
            columnExpression155.ColumnName = "BCC_ErgolaviaNeasParoxis";
            columnExpression155.Table = table1;
            column155.Expression = columnExpression155;
            columnExpression156.ColumnName = "BCC_ArithmosEntolisErgolavou";
            columnExpression156.Table = table1;
            column156.Expression = columnExpression156;
            columnExpression157.ColumnName = "BCC_HmerominiaEntolis";
            columnExpression157.Table = table1;
            column157.Expression = columnExpression157;
            columnExpression158.ColumnName = "BCC_Remarks";
            columnExpression158.Table = table1;
            column158.Expression = columnExpression158;
            columnExpression159.ColumnName = "EpifaneiaSqMtrs";
            columnExpression159.Table = table1;
            column159.Expression = columnExpression159;
            columnExpression160.ColumnName = "EidosPlakon";
            columnExpression160.Table = table1;
            column160.Expression = columnExpression160;
            columnExpression161.ColumnName = "ArithmosPlakon";
            columnExpression161.Table = table1;
            column161.Expression = columnExpression161;
            columnExpression162.ColumnName = "ArithmosTemaxion";
            columnExpression162.Table = table1;
            column162.Expression = columnExpression162;
            columnExpression163.ColumnName = "EidosEpemvasisNeasParoxis";
            columnExpression163.Table = table1;
            column163.Expression = columnExpression163;
            columnExpression164.ColumnName = "Reithro";
            columnExpression164.Table = table1;
            column164.Expression = columnExpression164;
            columnExpression165.ColumnName = "Propagated";
            columnExpression165.Table = table1;
            column165.Expression = columnExpression165;
            columnExpression166.ColumnName = "ProblimaPiesis";
            columnExpression166.Table = table1;
            column166.Expression = columnExpression166;
            columnExpression167.ColumnName = "Orofos";
            columnExpression167.Table = table1;
            column167.Expression = columnExpression167;
            columnExpression168.ColumnName = "HmerominiaAnagelias";
            columnExpression168.Table = table1;
            column168.Expression = columnExpression168;
            columnExpression169.ColumnName = "OraAnagelias";
            columnExpression169.Table = table1;
            column169.Expression = columnExpression169;
            columnExpression170.ColumnName = "EnergeiesProblimatosPiesis";
            columnExpression170.Table = table1;
            column170.Expression = columnExpression170;
            columnExpression171.ColumnName = "AitioProblimatosId";
            columnExpression171.Table = table1;
            column171.Expression = columnExpression171;
            columnExpression172.ColumnName = "ArithmosAitimatos";
            columnExpression172.Table = table1;
            column172.Expression = columnExpression172;
            columnExpression173.ColumnName = "ThesiTermatos";
            columnExpression173.Table = table1;
            column173.Expression = columnExpression173;
            columnExpression174.ColumnName = "BackEndTabletId";
            columnExpression174.Table = table1;
            column174.Expression = columnExpression174;
            columnExpression175.ColumnName = "EpilegmeniApomonosi";
            columnExpression175.Table = table1;
            column175.Expression = columnExpression175;
            columnExpression176.ColumnName = "IDApomonosis";
            columnExpression176.Table = table1;
            column176.Expression = columnExpression176;
            columnExpression177.ColumnName = "DiametrosPyrosvestikouKrounouParoxis";
            columnExpression177.Table = table1;
            column177.Expression = columnExpression177;
            columnExpression178.ColumnName = "OximataEpanaforas";
            columnExpression178.Table = table1;
            column178.Expression = columnExpression178;
            columnExpression179.ColumnName = "EpanaforaOdostromatosType";
            columnExpression179.Table = table1;
            column179.Expression = columnExpression179;
            columnExpression180.ColumnName = "EpanaforaPezodromiouType";
            columnExpression180.Table = table1;
            column180.Expression = columnExpression180;
            columnExpression181.ColumnName = "DiktyoParoxi";
            columnExpression181.Table = table1;
            column181.Expression = columnExpression181;
            columnExpression182.ColumnName = "ProblemCategory";
            columnExpression182.Table = table1;
            column182.Expression = columnExpression182;
            columnExpression183.ColumnName = "EidosProblematos";
            columnExpression183.Table = table1;
            column183.Expression = columnExpression183;
            columnExpression184.ColumnName = "Diagnosi";
            columnExpression184.Table = table1;
            column184.Expression = columnExpression184;
            columnExpression185.ColumnName = "Symperasma";
            columnExpression185.Table = table1;
            column185.Expression = columnExpression185;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Columns.Add(column7);
            selectQuery1.Columns.Add(column8);
            selectQuery1.Columns.Add(column9);
            selectQuery1.Columns.Add(column10);
            selectQuery1.Columns.Add(column11);
            selectQuery1.Columns.Add(column12);
            selectQuery1.Columns.Add(column13);
            selectQuery1.Columns.Add(column14);
            selectQuery1.Columns.Add(column15);
            selectQuery1.Columns.Add(column16);
            selectQuery1.Columns.Add(column17);
            selectQuery1.Columns.Add(column18);
            selectQuery1.Columns.Add(column19);
            selectQuery1.Columns.Add(column20);
            selectQuery1.Columns.Add(column21);
            selectQuery1.Columns.Add(column22);
            selectQuery1.Columns.Add(column23);
            selectQuery1.Columns.Add(column24);
            selectQuery1.Columns.Add(column25);
            selectQuery1.Columns.Add(column26);
            selectQuery1.Columns.Add(column27);
            selectQuery1.Columns.Add(column28);
            selectQuery1.Columns.Add(column29);
            selectQuery1.Columns.Add(column30);
            selectQuery1.Columns.Add(column31);
            selectQuery1.Columns.Add(column32);
            selectQuery1.Columns.Add(column33);
            selectQuery1.Columns.Add(column34);
            selectQuery1.Columns.Add(column35);
            selectQuery1.Columns.Add(column36);
            selectQuery1.Columns.Add(column37);
            selectQuery1.Columns.Add(column38);
            selectQuery1.Columns.Add(column39);
            selectQuery1.Columns.Add(column40);
            selectQuery1.Columns.Add(column41);
            selectQuery1.Columns.Add(column42);
            selectQuery1.Columns.Add(column43);
            selectQuery1.Columns.Add(column44);
            selectQuery1.Columns.Add(column45);
            selectQuery1.Columns.Add(column46);
            selectQuery1.Columns.Add(column47);
            selectQuery1.Columns.Add(column48);
            selectQuery1.Columns.Add(column49);
            selectQuery1.Columns.Add(column50);
            selectQuery1.Columns.Add(column51);
            selectQuery1.Columns.Add(column52);
            selectQuery1.Columns.Add(column53);
            selectQuery1.Columns.Add(column54);
            selectQuery1.Columns.Add(column55);
            selectQuery1.Columns.Add(column56);
            selectQuery1.Columns.Add(column57);
            selectQuery1.Columns.Add(column58);
            selectQuery1.Columns.Add(column59);
            selectQuery1.Columns.Add(column60);
            selectQuery1.Columns.Add(column61);
            selectQuery1.Columns.Add(column62);
            selectQuery1.Columns.Add(column63);
            selectQuery1.Columns.Add(column64);
            selectQuery1.Columns.Add(column65);
            selectQuery1.Columns.Add(column66);
            selectQuery1.Columns.Add(column67);
            selectQuery1.Columns.Add(column68);
            selectQuery1.Columns.Add(column69);
            selectQuery1.Columns.Add(column70);
            selectQuery1.Columns.Add(column71);
            selectQuery1.Columns.Add(column72);
            selectQuery1.Columns.Add(column73);
            selectQuery1.Columns.Add(column74);
            selectQuery1.Columns.Add(column75);
            selectQuery1.Columns.Add(column76);
            selectQuery1.Columns.Add(column77);
            selectQuery1.Columns.Add(column78);
            selectQuery1.Columns.Add(column79);
            selectQuery1.Columns.Add(column80);
            selectQuery1.Columns.Add(column81);
            selectQuery1.Columns.Add(column82);
            selectQuery1.Columns.Add(column83);
            selectQuery1.Columns.Add(column84);
            selectQuery1.Columns.Add(column85);
            selectQuery1.Columns.Add(column86);
            selectQuery1.Columns.Add(column87);
            selectQuery1.Columns.Add(column88);
            selectQuery1.Columns.Add(column89);
            selectQuery1.Columns.Add(column90);
            selectQuery1.Columns.Add(column91);
            selectQuery1.Columns.Add(column92);
            selectQuery1.Columns.Add(column93);
            selectQuery1.Columns.Add(column94);
            selectQuery1.Columns.Add(column95);
            selectQuery1.Columns.Add(column96);
            selectQuery1.Columns.Add(column97);
            selectQuery1.Columns.Add(column98);
            selectQuery1.Columns.Add(column99);
            selectQuery1.Columns.Add(column100);
            selectQuery1.Columns.Add(column101);
            selectQuery1.Columns.Add(column102);
            selectQuery1.Columns.Add(column103);
            selectQuery1.Columns.Add(column104);
            selectQuery1.Columns.Add(column105);
            selectQuery1.Columns.Add(column106);
            selectQuery1.Columns.Add(column107);
            selectQuery1.Columns.Add(column108);
            selectQuery1.Columns.Add(column109);
            selectQuery1.Columns.Add(column110);
            selectQuery1.Columns.Add(column111);
            selectQuery1.Columns.Add(column112);
            selectQuery1.Columns.Add(column113);
            selectQuery1.Columns.Add(column114);
            selectQuery1.Columns.Add(column115);
            selectQuery1.Columns.Add(column116);
            selectQuery1.Columns.Add(column117);
            selectQuery1.Columns.Add(column118);
            selectQuery1.Columns.Add(column119);
            selectQuery1.Columns.Add(column120);
            selectQuery1.Columns.Add(column121);
            selectQuery1.Columns.Add(column122);
            selectQuery1.Columns.Add(column123);
            selectQuery1.Columns.Add(column124);
            selectQuery1.Columns.Add(column125);
            selectQuery1.Columns.Add(column126);
            selectQuery1.Columns.Add(column127);
            selectQuery1.Columns.Add(column128);
            selectQuery1.Columns.Add(column129);
            selectQuery1.Columns.Add(column130);
            selectQuery1.Columns.Add(column131);
            selectQuery1.Columns.Add(column132);
            selectQuery1.Columns.Add(column133);
            selectQuery1.Columns.Add(column134);
            selectQuery1.Columns.Add(column135);
            selectQuery1.Columns.Add(column136);
            selectQuery1.Columns.Add(column137);
            selectQuery1.Columns.Add(column138);
            selectQuery1.Columns.Add(column139);
            selectQuery1.Columns.Add(column140);
            selectQuery1.Columns.Add(column141);
            selectQuery1.Columns.Add(column142);
            selectQuery1.Columns.Add(column143);
            selectQuery1.Columns.Add(column144);
            selectQuery1.Columns.Add(column145);
            selectQuery1.Columns.Add(column146);
            selectQuery1.Columns.Add(column147);
            selectQuery1.Columns.Add(column148);
            selectQuery1.Columns.Add(column149);
            selectQuery1.Columns.Add(column150);
            selectQuery1.Columns.Add(column151);
            selectQuery1.Columns.Add(column152);
            selectQuery1.Columns.Add(column153);
            selectQuery1.Columns.Add(column154);
            selectQuery1.Columns.Add(column155);
            selectQuery1.Columns.Add(column156);
            selectQuery1.Columns.Add(column157);
            selectQuery1.Columns.Add(column158);
            selectQuery1.Columns.Add(column159);
            selectQuery1.Columns.Add(column160);
            selectQuery1.Columns.Add(column161);
            selectQuery1.Columns.Add(column162);
            selectQuery1.Columns.Add(column163);
            selectQuery1.Columns.Add(column164);
            selectQuery1.Columns.Add(column165);
            selectQuery1.Columns.Add(column166);
            selectQuery1.Columns.Add(column167);
            selectQuery1.Columns.Add(column168);
            selectQuery1.Columns.Add(column169);
            selectQuery1.Columns.Add(column170);
            selectQuery1.Columns.Add(column171);
            selectQuery1.Columns.Add(column172);
            selectQuery1.Columns.Add(column173);
            selectQuery1.Columns.Add(column174);
            selectQuery1.Columns.Add(column175);
            selectQuery1.Columns.Add(column176);
            selectQuery1.Columns.Add(column177);
            selectQuery1.Columns.Add(column178);
            selectQuery1.Columns.Add(column179);
            selectQuery1.Columns.Add(column180);
            selectQuery1.Columns.Add(column181);
            selectQuery1.Columns.Add(column182);
            selectQuery1.Columns.Add(column183);
            selectQuery1.Columns.Add(column184);
            selectQuery1.Columns.Add(column185);
            selectQuery1.Name = "Visits";
            selectQuery1.Tables.Add(table1);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            //
            // reportHeaderBand1
            //
            this.reportHeaderBand1.HeightF = 0.6250064F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            //
            // xrLabel1
            //
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(6.00001F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel1.StyleName = "Title";
            this.xrLabel1.Text = "ΦΟΡΜΑ ΑΝΑΘΕΣΗΣ";
            //
            // groupHeaderBand1
            //
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AssignmentId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.groupHeaderBand1.HeightF = 25F;
            this.groupHeaderBand1.Level = 1;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            //
            // xrTable1
            //
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(650F, 25F);
            //
            // xrTableRow1
            //
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            //
            // xrTableCell1
            //
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.StyleName = "GroupCaption3";
            this.xrTableCell1.Text = "ASSIGNMENT ID";
            this.xrTableCell1.Weight = 0.15692307692307692D;
            //
            // xrTableCell2
            //
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AssignmentId]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.StyleName = "GroupData3";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 0.84307692307692306D;
            //
            // groupHeaderBand2
            //
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.groupHeaderBand2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.groupHeaderBand2.HeightF = 48F;
            this.groupHeaderBand2.Level = 2;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            //
            // xrPanel1
            //
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(650F, 48F);
            this.xrPanel1.StyleName = "DetailCaptionBackground3";
            //
            // xrTable2
            //
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 20F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(650F, 28F);
            //
            // xrTableRow2
            //
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lbl_Date_Of_Assignment,
            this.lbl_Date_Of_Completion,
            this.lbl_Status,
            this.lbl_TaskId,
            this.lbl_Comments,
            this.lbl_TaskTypeId,
            this.lbl_IncidentId,
            this.lbl_Task_Description,
            this.lbl_Synergeio_Epemvasis,
            this.lbl_Synergeio_Elegxou,
            this.lbl_Synergeio_Apomonosis,
            this.lbl_Synergeio_Epanaforas,
            this.lbl_Control_Date,
            this.lbl_Control_Time,
            this.lbl_Epemvasi_Vardia_Synergeiou,
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou,
            this.lbl_Porisma,
            this.lbl_Energeies,
            this.lbl_Position_Of_Geotrisi,
            this.lbl_Results_Of_Chemeio,
            this.lbl_Remarks,
            this.lbl_MAP,
            this.lbl_Vana_Diametros,
            this.lbl_Agogos_Diametros,
            this.lbl_Metritis_Diametros,
            this.lbl_Pyrosvestiki_Paroxi_Diametros,
            this.lbl_Zoni_Piesis,
            this.lbl_Zoni,
            this.lbl_Eidopoiisi,
            this.lbl_Hmerominia_Apomonosis,
            this.lbl_Ora_Apomonosis,
            this.lbl_Ekplisi_Termatos,
            this.lbl_Pyrosvestikou_Geranou_Diametros,
            this.lbl_Apomonosi_Hmerominia_Anaxorisis,
            this.lbl_Apomonosi_Ora_Anaxorisis,
            this.lbl_Apomonosi_Hmerominia_Afixis,
            this.lbl_Apomonosi_Ora_Afixis,
            this.lbl_Apomonosi_Hmerominia_Epistrofis,
            this.lbl_Apomonosi_Ora_Epistrofis,
            this.lbl_Hmerominia_Epanaforas,
            this.lbl_Ora_Epanaforas,
            this.lbl_Eidos_Epanaforas,
            this.lbl_Epanafora_Hmerominia_Anaxorisis,
            this.lbl_Epanafora_Ora_Anaxorisis,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52,
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56,
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrTableCell60,
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell63,
            this.xrTableCell64,
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69,
            this.xrTableCell70,
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell75,
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78,
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell81,
            this.xrTableCell82,
            this.xrTableCell83,
            this.xrTableCell84,
            this.xrTableCell85,
            this.xrTableCell86,
            this.xrTableCell87,
            this.xrTableCell88,
            this.xrTableCell89,
            this.xrTableCell90,
            this.xrTableCell91,
            this.xrTableCell92,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell95,
            this.xrTableCell96,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell99,
            this.xrTableCell100,
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell103,
            this.xrTableCell104,
            this.xrTableCell105,
            this.xrTableCell106,
            this.xrTableCell107,
            this.xrTableCell108,
            this.xrTableCell109,
            this.xrTableCell110,
            this.xrTableCell111,
            this.xrTableCell112,
            this.xrTableCell113,
            this.xrTableCell114,
            this.xrTableCell115,
            this.xrTableCell116,
            this.xrTableCell117,
            this.xrTableCell118,
            this.xrTableCell119,
            this.xrTableCell120,
            this.xrTableCell121,
            this.xrTableCell122,
            this.xrTableCell123,
            this.xrTableCell124,
            this.xrTableCell125,
            this.xrTableCell126,
            this.xrTableCell127,
            this.xrTableCell128,
            this.xrTableCell129,
            this.xrTableCell130,
            this.xrTableCell131,
            this.xrTableCell132,
            this.xrTableCell133,
            this.xrTableCell134,
            this.xrTableCell135,
            this.xrTableCell136,
            this.xrTableCell137,
            this.xrTableCell138,
            this.xrTableCell139,
            this.xrTableCell140,
            this.xrTableCell141,
            this.xrTableCell142,
            this.xrTableCell143,
            this.xrTableCell144,
            this.xrTableCell145,
            this.xrTableCell146,
            this.xrTableCell147,
            this.xrTableCell148,
            this.xrTableCell149,
            this.xrTableCell150,
            this.xrTableCell151,
            this.xrTableCell152,
            this.xrTableCell153,
            this.xrTableCell154,
            this.xrTableCell155,
            this.xrTableCell156,
            this.xrTableCell157,
            this.xrTableCell158,
            this.xrTableCell159,
            this.xrTableCell160,
            this.xrTableCell161,
            this.xrTableCell162,
            this.xrTableCell163,
            this.xrTableCell164,
            this.xrTableCell165,
            this.xrTableCell166,
            this.xrTableCell167,
            this.xrTableCell168,
            this.xrTableCell169,
            this.xrTableCell170,
            this.xrTableCell171,
            this.xrTableCell172,
            this.xrTableCell173,
            this.xrTableCell174,
            this.xrTableCell175,
            this.xrTableCell176,
            this.xrTableCell177,
            this.xrTableCell178,
            this.xrTableCell179,
            this.xrTableCell180,
            this.xrTableCell181,
            this.xrTableCell182,
            this.xrTableCell183,
            this.xrTableCell184,
            this.xrTableCell185,
            this.xrTableCell186});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            //
            // lbl_Date_Of_Assignment
            //
            this.lbl_Date_Of_Assignment.Name = "lbl_Date_Of_Assignment";
            this.lbl_Date_Of_Assignment.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Date_Of_Assignment.StyleName = "DetailCaption3";
            this.lbl_Date_Of_Assignment.Text = "Ημερομηνία Ανάθεσης";
            this.lbl_Date_Of_Assignment.Weight = 0.0053803095450768107D;
            //
            // lbl_Date_Of_Completion
            //
            this.lbl_Date_Of_Completion.Name = "lbl_Date_Of_Completion";
            this.lbl_Date_Of_Completion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Date_Of_Completion.StyleName = "DetailCaption3";
            this.lbl_Date_Of_Completion.Text = "Ημερομηνία Ολοκλήρωσης";
            this.lbl_Date_Of_Completion.Weight = 0.0052935303174532376D;
            //
            // lbl_Status
            //
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Status.StyleName = "DetailCaption3";
            this.lbl_Status.Text = "Κατάσταση";
            this.lbl_Status.Weight = 0.0030769230769230769D;
            //
            // lbl_TaskId
            //
            this.lbl_TaskId.Name = "lbl_TaskId";
            this.lbl_TaskId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_TaskId.StyleName = "DetailCaption3";
            this.lbl_TaskId.Text = "Task Id";
            this.lbl_TaskId.Visible = false;
            this.lbl_TaskId.Weight = 0.0030769230769230769D;
            //
            // lbl_Comments
            //
            this.lbl_Comments.Name = "lbl_Comments";
            this.lbl_Comments.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Comments.StyleName = "DetailCaption3";
            this.lbl_Comments.Text = "Παρατηρήσεις";
            this.lbl_Comments.Weight = 0.0031240507272573617D;
            //
            // lbl_TaskTypeId
            //
            this.lbl_TaskTypeId.Name = "lbl_TaskTypeId";
            this.lbl_TaskTypeId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_TaskTypeId.StyleName = "DetailCaption3";
            this.lbl_TaskTypeId.StylePriority.UseTextAlignment = false;
            this.lbl_TaskTypeId.Text = "TaskTypeId";
            this.lbl_TaskTypeId.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_TaskTypeId.Visible = false;
            this.lbl_TaskTypeId.Weight = 0.003644725726200984D;
            //
            // lbl_IncidentId
            //
            this.lbl_IncidentId.Name = "lbl_IncidentId";
            this.lbl_IncidentId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_IncidentId.StyleName = "DetailCaption3";
            this.lbl_IncidentId.Text = "Incident Id";
            this.lbl_IncidentId.Visible = false;
            this.lbl_IncidentId.Weight = 0.003254219568692721D;
            //
            // lbl_Task_Description
            //
            this.lbl_Task_Description.Name = "lbl_Task_Description";
            this.lbl_Task_Description.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Task_Description.StyleName = "DetailCaption3";
            this.lbl_Task_Description.Text = "Περιγραφή Εργασίας";
            this.lbl_Task_Description.Weight = 0.0045559072494506837D;
            //
            // lbl_Synergeio_Epemvasis
            //
            this.lbl_Synergeio_Epemvasis.Name = "lbl_Synergeio_Epemvasis";
            this.lbl_Synergeio_Epemvasis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Synergeio_Epemvasis.StyleName = "DetailCaption3";
            this.lbl_Synergeio_Epemvasis.Text = "Συνεργείο Επέμβασης";
            this.lbl_Synergeio_Epemvasis.Weight = 0.0056406472279475284D;
            //
            // lbl_Synergeio_Elegxou
            //
            this.lbl_Synergeio_Elegxou.Name = "lbl_Synergeio_Elegxou";
            this.lbl_Synergeio_Elegxou.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Synergeio_Elegxou.StyleName = "DetailCaption3";
            this.lbl_Synergeio_Elegxou.Text = "Συνεργείο Ελέγχου";
            this.lbl_Synergeio_Elegxou.Weight = 0.0050331930013803334D;
            //
            // lbl_Synergeio_Apomonosis
            //
            this.lbl_Synergeio_Apomonosis.Name = "lbl_Synergeio_Apomonosis";
            this.lbl_Synergeio_Apomonosis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Synergeio_Apomonosis.StyleName = "DetailCaption3";
            this.lbl_Synergeio_Apomonosis.Text = "Συνεργείο Απομόνωσης";
            this.lbl_Synergeio_Apomonosis.Weight = 0.0060311533854557915D;
            //
            // lbl_Synergeio_Epanaforas
            //
            this.lbl_Synergeio_Epanaforas.Name = "lbl_Synergeio_Epanaforas";
            this.lbl_Synergeio_Epanaforas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Synergeio_Epanaforas.StyleName = "DetailCaption3";
            this.lbl_Synergeio_Epanaforas.Text = "Συνεργείο Επαναφοράς";
            this.lbl_Synergeio_Epanaforas.Weight = 0.0058142056831946738D;
            //
            // lbl_Control_Date
            //
            this.lbl_Control_Date.Name = "lbl_Control_Date";
            this.lbl_Control_Date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Control_Date.StyleName = "DetailCaption3";
            this.lbl_Control_Date.Text = "Ημερομηνία Ελέγχου";
            this.lbl_Control_Date.Weight = 0.0036013361123891979D;
            //
            // lbl_Control_Time
            //
            this.lbl_Control_Time.Name = "lbl_Control_Time";
            this.lbl_Control_Time.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Control_Time.StyleName = "DetailCaption3";
            this.lbl_Control_Time.Text = "Ωρα Ελέγχου";
            this.lbl_Control_Time.Weight = 0.003644725726200984D;
            //
            // lbl_Epemvasi_Vardia_Synergeiou
            //
            this.lbl_Epemvasi_Vardia_Synergeiou.Name = "lbl_Epemvasi_Vardia_Synergeiou";
            this.lbl_Epemvasi_Vardia_Synergeiou.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Epemvasi_Vardia_Synergeiou.StyleName = "DetailCaption3";
            this.lbl_Epemvasi_Vardia_Synergeiou.Text = "Επέμβαση Βάρδια Συνεργείου";
            this.lbl_Epemvasi_Vardia_Synergeiou.Weight = 0.0074196206606351412D;
            //
            // lbl_Epemvasi_Arithmos_Atomon_Synergeiou
            //
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.Name = "lbl_Epemvasi_Arithmos_Atomon_Synergeiou";
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.StyleName = "DetailCaption3";
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.StylePriority.UseTextAlignment = false;
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.Text = "Επέμβαση Αριθμός Ατόμων Συνεργείου";
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Epemvasi_Arithmos_Atomon_Synergeiou.Weight = 0.01010977524977464D;
            //
            // lbl_Porisma
            //
            this.lbl_Porisma.Name = "lbl_Porisma";
            this.lbl_Porisma.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Porisma.StyleName = "DetailCaption3";
            this.lbl_Porisma.Text = "Πόρισμα";
            this.lbl_Porisma.Weight = 0.0030769230769230769D;
            //
            // lbl_Energeies
            //
            this.lbl_Energeies.Name = "lbl_Energeies";
            this.lbl_Energeies.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Energeies.StyleName = "DetailCaption3";
            this.lbl_Energeies.Text = "Ενέργειες";
            this.lbl_Energeies.Weight = 0.0030769230769230769D;
            //
            // lbl_Position_Of_Geotrisi
            //
            this.lbl_Position_Of_Geotrisi.Name = "lbl_Position_Of_Geotrisi";
            this.lbl_Position_Of_Geotrisi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Position_Of_Geotrisi.StyleName = "DetailCaption3";
            this.lbl_Position_Of_Geotrisi.Text = "Θέση Γεώτρησης";
            this.lbl_Position_Of_Geotrisi.Weight = 0.005250140703641451D;
            //
            // lbl_Results_Of_Chemeio
            //
            this.lbl_Results_Of_Chemeio.Name = "lbl_Results_Of_Chemeio";
            this.lbl_Results_Of_Chemeio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Results_Of_Chemeio.StyleName = "DetailCaption3";
            this.lbl_Results_Of_Chemeio.Text = "Αποτελέσματα Χημείου";
            this.lbl_Results_Of_Chemeio.Weight = 0.0052935303174532376D;
            //
            // lbl_Remarks
            //
            this.lbl_Remarks.Name = "lbl_Remarks";
            this.lbl_Remarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Remarks.StyleName = "DetailCaption3";
            this.lbl_Remarks.Text = "Σχόλια";
            this.lbl_Remarks.Weight = 0.0030769230769230769D;
            //
            // lbl_MAP
            //
            this.lbl_MAP.Name = "lbl_MAP";
            this.lbl_MAP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_MAP.StyleName = "DetailCaption3";
            this.lbl_MAP.Text = "ΜΑΠ";
            this.lbl_MAP.Weight = 0.0030769230769230769D;
            //
            // lbl_Vana_Diametros
            //
            this.lbl_Vana_Diametros.Name = "lbl_Vana_Diametros";
            this.lbl_Vana_Diametros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Vana_Diametros.StyleName = "DetailCaption3";
            this.lbl_Vana_Diametros.StylePriority.UseTextAlignment = false;
            this.lbl_Vana_Diametros.Text = "Διάμετρος Βάνας";
            this.lbl_Vana_Diametros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Vana_Diametros.Weight = 0.0043823487942035383D;
            //
            // lbl_Agogos_Diametros
            //
            this.lbl_Agogos_Diametros.Name = "lbl_Agogos_Diametros";
            this.lbl_Agogos_Diametros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Agogos_Diametros.StyleName = "DetailCaption3";
            this.lbl_Agogos_Diametros.StylePriority.UseTextAlignment = false;
            this.lbl_Agogos_Diametros.Text = "Διάμετρος Αγωγού";
            this.lbl_Agogos_Diametros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Agogos_Diametros.Weight = 0.0049464137737567611D;
            //
            // lbl_Metritis_Diametros
            //
            this.lbl_Metritis_Diametros.Name = "lbl_Metritis_Diametros";
            this.lbl_Metritis_Diametros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Metritis_Diametros.StyleName = "DetailCaption3";
            this.lbl_Metritis_Diametros.StylePriority.UseTextAlignment = false;
            this.lbl_Metritis_Diametros.Text = "Διάμετρος Μετρητή";
            this.lbl_Metritis_Diametros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Metritis_Diametros.Weight = 0.0050331930013803334D;
            //
            // lbl_Pyrosvestiki_Paroxi_Diametros
            //
            this.lbl_Pyrosvestiki_Paroxi_Diametros.Name = "lbl_Pyrosvestiki_Paroxi_Diametros";
            this.lbl_Pyrosvestiki_Paroxi_Diametros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Pyrosvestiki_Paroxi_Diametros.StyleName = "DetailCaption3";
            this.lbl_Pyrosvestiki_Paroxi_Diametros.StylePriority.UseTextAlignment = false;
            this.lbl_Pyrosvestiki_Paroxi_Diametros.Text = "Διάμετρος Πυροσβεστικής Παροχής";
            this.lbl_Pyrosvestiki_Paroxi_Diametros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Pyrosvestiki_Paroxi_Diametros.Weight = 0.0078101268181434043D;
            //
            // lbl_Zoni_Piesis
            //
            this.lbl_Zoni_Piesis.Name = "lbl_Zoni_Piesis";
            this.lbl_Zoni_Piesis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Zoni_Piesis.StyleName = "DetailCaption3";
            this.lbl_Zoni_Piesis.Text = "Ζώνη Πίεσης";
            this.lbl_Zoni_Piesis.Weight = 0.0031240507272573617D;
            //
            // lbl_Zoni
            //
            this.lbl_Zoni.Name = "lbl_Zoni";
            this.lbl_Zoni.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Zoni.StyleName = "DetailCaption3";
            this.lbl_Zoni.Text = "Ζώνη";
            this.lbl_Zoni.Weight = 0.0030769230769230769D;
            //
            // lbl_Eidopoiisi
            //
            this.lbl_Eidopoiisi.Name = "lbl_Eidopoiisi";
            this.lbl_Eidopoiisi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Eidopoiisi.StyleName = "DetailCaption3";
            this.lbl_Eidopoiisi.Text = "Ειδοποίηση";
            this.lbl_Eidopoiisi.Weight = 0.0030769230769230769D;
            //
            // lbl_Hmerominia_Apomonosis
            //
            this.lbl_Hmerominia_Apomonosis.Name = "lbl_Hmerominia_Apomonosis";
            this.lbl_Hmerominia_Apomonosis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Hmerominia_Apomonosis.StyleName = "DetailCaption3";
            this.lbl_Hmerominia_Apomonosis.Text = "Ημερομηνία Απομόνωσης";
            this.lbl_Hmerominia_Apomonosis.Weight = 0.0065952183650090142D;
            //
            // lbl_Ora_Apomonosis
            //
            this.lbl_Ora_Apomonosis.Name = "lbl_Ora_Apomonosis";
            this.lbl_Ora_Apomonosis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Ora_Apomonosis.StyleName = "DetailCaption3";
            this.lbl_Ora_Apomonosis.Text = "Ωρα Απομόνωσης";
            this.lbl_Ora_Apomonosis.Weight = 0.0044691280218271106D;
            //
            // lbl_Ekplisi_Termatos
            //
            this.lbl_Ekplisi_Termatos.Name = "lbl_Ekplisi_Termatos";
            this.lbl_Ekplisi_Termatos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Ekplisi_Termatos.StyleName = "DetailCaption3";
            this.lbl_Ekplisi_Termatos.Text = "Εκπλυση Τέρματος";
            this.lbl_Ekplisi_Termatos.Weight = 0.0045559072494506837D;
            //
            // lbl_Pyrosvestikou_Geranou_Diametros
            //
            this.lbl_Pyrosvestikou_Geranou_Diametros.Name = "lbl_Pyrosvestikou_Geranou_Diametros";
            this.lbl_Pyrosvestikou_Geranou_Diametros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Pyrosvestikou_Geranou_Diametros.StyleName = "DetailCaption3";
            this.lbl_Pyrosvestikou_Geranou_Diametros.StylePriority.UseTextAlignment = false;
            this.lbl_Pyrosvestikou_Geranou_Diametros.Text = "Διάμετρος Πυροσβεστικού Γερανού";
            this.lbl_Pyrosvestikou_Geranou_Diametros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbl_Pyrosvestikou_Geranou_Diametros.Weight = 0.0088080875690166767D;
            //
            // lbl_Apomonosi_Hmerominia_Anaxorisis
            //
            this.lbl_Apomonosi_Hmerominia_Anaxorisis.Name = "lbl_Apomonosi_Hmerominia_Anaxorisis";
            this.lbl_Apomonosi_Hmerominia_Anaxorisis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Hmerominia_Anaxorisis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Hmerominia_Anaxorisis.Text = "Απομόνωση Ημερομηνία Αναχώρησης";
            this.lbl_Apomonosi_Hmerominia_Anaxorisis.Weight = 0.008981646024263823D;
            //
            // lbl_Apomonosi_Ora_Anaxorisis
            //
            this.lbl_Apomonosi_Ora_Anaxorisis.Name = "lbl_Apomonosi_Ora_Anaxorisis";
            this.lbl_Apomonosi_Ora_Anaxorisis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Ora_Anaxorisis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Ora_Anaxorisis.Text = "Απομόνωση Ωρα Αναχώρησης";
            this.lbl_Apomonosi_Ora_Anaxorisis.Weight = 0.006898945294893705D;
            //
            // lbl_Apomonosi_Hmerominia_Afixis
            //
            this.lbl_Apomonosi_Hmerominia_Afixis.Name = "lbl_Apomonosi_Hmerominia_Afixis";
            this.lbl_Apomonosi_Hmerominia_Afixis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Hmerominia_Afixis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Hmerominia_Afixis.Text = "Απομόνωση Ημερομηνία Αφιξης";
            this.lbl_Apomonosi_Hmerominia_Afixis.Weight = 0.0078101268181434043D;
            //
            // lbl_Apomonosi_Ora_Afixis
            //
            this.lbl_Apomonosi_Ora_Afixis.Name = "lbl_Apomonosi_Ora_Afixis";
            this.lbl_Apomonosi_Ora_Afixis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Ora_Afixis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Ora_Afixis.Text = "Απομόνωση Ωρα Άφιξης";
            this.lbl_Apomonosi_Ora_Afixis.Weight = 0.0057274264555711015D;
            //
            // lbl_Apomonosi_Hmerominia_Epistrofis
            //
            this.lbl_Apomonosi_Hmerominia_Epistrofis.Name = "lbl_Apomonosi_Hmerominia_Epistrofis";
            this.lbl_Apomonosi_Hmerominia_Epistrofis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Hmerominia_Epistrofis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Hmerominia_Epistrofis.Text = "Απομόνωση Ημερομηνία Επιστροφής";
            this.lbl_Apomonosi_Hmerominia_Epistrofis.Weight = 0.0087646975884070766D;
            //
            // lbl_Apomonosi_Ora_Epistrofis
            //
            this.lbl_Apomonosi_Ora_Epistrofis.Name = "lbl_Apomonosi_Ora_Epistrofis";
            this.lbl_Apomonosi_Ora_Epistrofis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Apomonosi_Ora_Epistrofis.StyleName = "DetailCaption3";
            this.lbl_Apomonosi_Ora_Epistrofis.Text = "Απομόνωση Ωρα Επιστροφής";
            this.lbl_Apomonosi_Ora_Epistrofis.Weight = 0.0066386076120229865D;
            //
            // lbl_Hmerominia_Epanaforas
            //
            this.lbl_Hmerominia_Epanaforas.Name = "lbl_Hmerominia_Epanaforas";
            this.lbl_Hmerominia_Epanaforas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Hmerominia_Epanaforas.StyleName = "DetailCaption3";
            this.lbl_Hmerominia_Epanaforas.Text = "Ημερομηνία Επαναφοράς";
            this.lbl_Hmerominia_Epanaforas.Weight = 0.0063782699291522688D;
            //
            // lbl_Ora_Epanaforas
            //
            this.lbl_Ora_Epanaforas.Name = "lbl_Ora_Epanaforas";
            this.lbl_Ora_Epanaforas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Ora_Epanaforas.StyleName = "DetailCaption3";
            this.lbl_Ora_Epanaforas.Text = "Ωρα Επαναφοράς";
            this.lbl_Ora_Epanaforas.Weight = 0.004252180319565993D;
            //
            // lbl_Eidos_Epanaforas
            //
            this.lbl_Eidos_Epanaforas.Name = "lbl_Eidos_Epanaforas";
            this.lbl_Eidos_Epanaforas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Eidos_Epanaforas.StyleName = "DetailCaption3";
            this.lbl_Eidos_Epanaforas.Text = "Είδος Επαναφοράς";
            this.lbl_Eidos_Epanaforas.Weight = 0.0046860760908860426D;
            //
            // lbl_Epanafora_Hmerominia_Anaxorisis
            //
            this.lbl_Epanafora_Hmerominia_Anaxorisis.Name = "lbl_Epanafora_Hmerominia_Anaxorisis";
            this.lbl_Epanafora_Hmerominia_Anaxorisis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Epanafora_Hmerominia_Anaxorisis.StyleName = "DetailCaption3";
            this.lbl_Epanafora_Hmerominia_Anaxorisis.Text = "Epanafora Hmerominia Anaxorisis";
            this.lbl_Epanafora_Hmerominia_Anaxorisis.Weight = 0.0087646975884070766D;
            //
            // lbl_Epanafora_Ora_Anaxorisis
            //
            this.lbl_Epanafora_Ora_Anaxorisis.Name = "lbl_Epanafora_Ora_Anaxorisis";
            this.lbl_Epanafora_Ora_Anaxorisis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Epanafora_Ora_Anaxorisis.StyleName = "DetailCaption3";
            this.lbl_Epanafora_Ora_Anaxorisis.Text = "Επαναφορά Ωρα Αναχώρησης";
            this.lbl_Epanafora_Ora_Anaxorisis.Weight = 0.0066819975926325874D;
            //
            // xrTableCell47
            //
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell47.StyleName = "DetailCaption3";
            this.xrTableCell47.Text = "Epanafora Hmerominia Afixis";
            this.xrTableCell47.Weight = 0.0075931791158822867D;
            //
            // xrTableCell48
            //
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell48.StyleName = "DetailCaption3";
            this.xrTableCell48.Text = "Epanafora Ora Afixis";
            this.xrTableCell48.Weight = 0.00551047838651217D;
            //
            // xrTableCell49
            //
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell49.StyleName = "DetailCaption3";
            this.xrTableCell49.Text = "Epanafora Hmerominia Epistrofis";
            this.xrTableCell49.Weight = 0.008547749886145959D;
            //
            // xrTableCell50
            //
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell50.StyleName = "DetailCaption3";
            this.xrTableCell50.Text = "Epanafora Ora Epistrofis";
            this.xrTableCell50.Weight = 0.0064216599097618688D;
            //
            // xrTableCell51
            //
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell51.StyleName = "DetailCaption3";
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "Apomonosi Arithmos Atomon Synergeiou";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell51.Weight = 0.010456892160268931D;
            //
            // xrTableCell52
            //
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell52.StyleName = "DetailCaption3";
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.Text = "Epanafora Arithmos Atomon Synergeiou";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell52.Weight = 0.010239944458007813D;
            //
            // xrTableCell53
            //
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell53.StyleName = "DetailCaption3";
            this.xrTableCell53.Text = "Apomonosi Vardia Synergeiou";
            this.xrTableCell53.Weight = 0.0078101268181434043D;
            //
            // xrTableCell54
            //
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell54.StyleName = "DetailCaption3";
            this.xrTableCell54.Text = "Epanafora Vardia Synergeiou";
            this.xrTableCell54.Weight = 0.0075931791158822867D;
            //
            // xrTableCell55
            //
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell55.StyleName = "DetailCaption3";
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            this.xrTableCell55.Text = "Apomonosi Arirthos Vanon Pou Xeiristikan";
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell55.Weight = 0.010804009070763222D;
            //
            // xrTableCell56
            //
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell56.StyleName = "DetailCaption3";
            this.xrTableCell56.Text = "Apomonosi Katastasi Vanon Pou Xeiristikan";
            this.xrTableCell56.Weight = 0.011107736000647912D;
            //
            // xrTableCell57
            //
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell57.StyleName = "DetailCaption3";
            this.xrTableCell57.Text = "Apomonosi Thesi Vanon Pou Xeiristikan";
            this.xrTableCell57.Weight = 0.01010977524977464D;
            //
            // xrTableCell58
            //
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell58.StyleName = "DetailCaption3";
            this.xrTableCell58.Text = "Syntetagmenes Vlavis";
            this.xrTableCell58.Weight = 0.00585759529700646D;
            //
            // xrTableCell59
            //
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell59.StyleName = "DetailCaption3";
            this.xrTableCell59.Text = "Agogos Yliko";
            this.xrTableCell59.Weight = 0.003644725726200984D;
            //
            // xrTableCell60
            //
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell60.StyleName = "DetailCaption3";
            this.xrTableCell60.StylePriority.UseTextAlignment = false;
            this.xrTableCell60.Text = "Topothetisi Katagrafikou";
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell60.Weight = 0.0065518283843994142D;
            //
            // xrTableCell61
            //
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell61.StyleName = "DetailCaption3";
            this.xrTableCell61.Text = "Gnomateusi Thesi";
            this.xrTableCell61.Weight = 0.004859634546133188D;
            //
            // xrTableCell62
            //
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell62.StyleName = "DetailCaption3";
            this.xrTableCell62.StylePriority.UseTextAlignment = false;
            this.xrTableCell62.Text = "Gnomateusi Mikos";
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell62.Weight = 0.0049898033875685468D;
            //
            // xrTableCell63
            //
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell63.StyleName = "DetailCaption3";
            this.xrTableCell63.StylePriority.UseTextAlignment = false;
            this.xrTableCell63.Text = "Gnomateusi Diametros";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell63.Weight = 0.006074542999267578D;
            //
            // xrTableCell64
            //
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell64.StyleName = "DetailCaption3";
            this.xrTableCell64.Text = "Gnomateusi Yliko";
            this.xrTableCell64.Weight = 0.0047728553185096157D;
            //
            // xrTableCell65
            //
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell65.StyleName = "DetailCaption3";
            this.xrTableCell65.Text = "File Attatchments";
            this.xrTableCell65.Weight = 0.0048162449323214014D;
            //
            // xrTableCell66
            //
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell66.StyleName = "DetailCaption3";
            this.xrTableCell66.StylePriority.UseTextAlignment = false;
            this.xrTableCell66.Text = "Epanafora Arirthos Vanon Pou Xeiristikan";
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell66.Weight = 0.010587060634906475D;
            //
            // xrTableCell67
            //
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell67.StyleName = "DetailCaption3";
            this.xrTableCell67.Text = "Epanafora Katastasi Vanon Pou Xeiristikan";
            this.xrTableCell67.Weight = 0.010847398317777193D;
            //
            // xrTableCell68
            //
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell68.StyleName = "DetailCaption3";
            this.xrTableCell68.Text = "Epanafora Thesi Vanon Pou Xeiristikan";
            this.xrTableCell68.Weight = 0.0098928275475135222D;
            //
            // xrTableCell69
            //
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell69.StyleName = "DetailCaption3";
            this.xrTableCell69.Text = "Oximata";
            this.xrTableCell69.Weight = 0.0030769230769230769D;
            //
            // xrTableCell70
            //
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell70.StyleName = "DetailCaption3";
            this.xrTableCell70.Text = "Task Schedule Date";
            this.xrTableCell70.Weight = 0.0052935303174532376D;
            //
            // xrTableCell71
            //
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell71.StyleName = "DetailCaption3";
            this.xrTableCell71.Text = "Hmerominia Enarxis Ergasion";
            this.xrTableCell71.Weight = 0.00767995834350586D;
            //
            // xrTableCell72
            //
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell72.StyleName = "DetailCaption3";
            this.xrTableCell72.Text = "Ora Enarxis Ergasion";
            this.xrTableCell72.Weight = 0.0055972576141357418D;
            //
            // xrTableCell73
            //
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell73.StyleName = "DetailCaption3";
            this.xrTableCell73.Text = "Hmerominia Lixis Ergasion";
            this.xrTableCell73.Weight = 0.0069857245225172773D;
            //
            // xrTableCell74
            //
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell74.StyleName = "DetailCaption3";
            this.xrTableCell74.Text = "Ora Lixis Ergasion";
            this.xrTableCell74.Weight = 0.0049030241599449746D;
            //
            // xrTableCell75
            //
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell75.StyleName = "DetailCaption3";
            this.xrTableCell75.Text = "Onoma Vanas";
            this.xrTableCell75.Weight = 0.003861673795259916D;
            //
            // xrTableCell76
            //
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell76.StyleName = "DetailCaption3";
            this.xrTableCell76.Text = "Thesi Vanas";
            this.xrTableCell76.Weight = 0.0034277780239398664D;
            //
            // xrTableCell77
            //
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell77.StyleName = "DetailCaption3";
            this.xrTableCell77.StylePriority.UseTextAlignment = false;
            this.xrTableCell77.Text = "Katastasi Vanas";
            this.xrTableCell77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell77.Weight = 0.0043823487942035383D;
            //
            // xrTableCell78
            //
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell78.StyleName = "DetailCaption3";
            this.xrTableCell78.Text = "Kalyma Eidos";
            this.xrTableCell78.Weight = 0.0037748945676363433D;
            //
            // xrTableCell79
            //
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell79.StyleName = "DetailCaption3";
            this.xrTableCell79.Text = "Kalyma Diastaseis";
            this.xrTableCell79.Weight = 0.0049464137737567611D;
            //
            // xrTableCell80
            //
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell80.StyleName = "DetailCaption3";
            this.xrTableCell80.Text = "Freatio Eidos";
            this.xrTableCell80.Weight = 0.0036881153400127706D;
            //
            // xrTableCell81
            //
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell81.StyleName = "DetailCaption3";
            this.xrTableCell81.Text = "Freatio Diastaseis";
            this.xrTableCell81.Weight = 0.004859634546133188D;
            //
            // xrTableCell82
            //
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell82.StyleName = "DetailCaption3";
            this.xrTableCell82.Text = "Hmerominia Epemvasis";
            this.xrTableCell82.Weight = 0.0062047122075007512D;
            //
            // xrTableCell83
            //
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell83.StyleName = "DetailCaption3";
            this.xrTableCell83.Text = "Ora Epemvasis";
            this.xrTableCell83.Weight = 0.0041220114781306341D;
            //
            // xrTableCell84
            //
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell84.StyleName = "DetailCaption3";
            this.xrTableCell84.Text = "Onoma Dexamenis";
            this.xrTableCell84.Weight = 0.00507658261519212D;
            //
            // xrTableCell85
            //
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell85.StyleName = "DetailCaption3";
            this.xrTableCell85.Text = "Thesi Dexamenis";
            this.xrTableCell85.Weight = 0.004642686477074256D;
            //
            // xrTableCell86
            //
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell86.StyleName = "DetailCaption3";
            this.xrTableCell86.Text = "Thalamos Dexamenis";
            this.xrTableCell86.Weight = 0.005684036841759315D;
            //
            // xrTableCell87
            //
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell87.StyleName = "DetailCaption3";
            this.xrTableCell87.Text = "Simeio Ekkenosis";
            this.xrTableCell87.Weight = 0.0047294657046978291D;
            //
            // xrTableCell88
            //
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell88.StyleName = "DetailCaption3";
            this.xrTableCell88.StylePriority.UseTextAlignment = false;
            this.xrTableCell88.Text = "Arithmos Antlion";
            this.xrTableCell88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell88.Weight = 0.00459929686326247D;
            //
            // xrTableCell89
            //
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell89.StyleName = "DetailCaption3";
            this.xrTableCell89.StylePriority.UseTextAlignment = false;
            this.xrTableCell89.Text = "Megali Mikri Antlia";
            this.xrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell89.Weight = 0.00507658261519212D;
            //
            // xrTableCell90
            //
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell90.StyleName = "DetailCaption3";
            this.xrTableCell90.Text = "Eidos Termatos";
            this.xrTableCell90.Weight = 0.004252180319565993D;
            //
            // xrTableCell91
            //
            this.xrTableCell91.Name = "xrTableCell91";
            this.xrTableCell91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell91.StyleName = "DetailCaption3";
            this.xrTableCell91.StylePriority.UseTextAlignment = false;
            this.xrTableCell91.Text = "PRV Xeirismos";
            this.xrTableCell91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell91.Weight = 0.004035232250507061D;
            //
            // xrTableCell92
            //
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell92.StyleName = "DetailCaption3";
            this.xrTableCell92.StylePriority.UseTextAlignment = false;
            this.xrTableCell92.Text = "Eparkeia Ylikon";
            this.xrTableCell92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell92.Weight = 0.0042955699333777795D;
            //
            // xrTableCell93
            //
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell93.StyleName = "DetailCaption3";
            this.xrTableCell93.StylePriority.UseTextAlignment = false;
            this.xrTableCell93.Text = "Eidos Problimatos";
            this.xrTableCell93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell93.Weight = 0.0049030241599449746D;
            //
            // xrTableCell94
            //
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell94.StyleName = "DetailCaption3";
            this.xrTableCell94.Text = "Eidos Epemvasis";
            this.xrTableCell94.Weight = 0.0045125176356388972D;
            //
            // xrTableCell95
            //
            this.xrTableCell95.Name = "xrTableCell95";
            this.xrTableCell95.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell95.StyleName = "DetailCaption3";
            this.xrTableCell95.Text = "Synergeio PRV";
            this.xrTableCell95.Weight = 0.0040786218643188476D;
            //
            // xrTableCell96
            //
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell96.StyleName = "DetailCaption3";
            this.xrTableCell96.Text = "Onoma PRV";
            this.xrTableCell96.Weight = 0.00338438841012808D;
            //
            // xrTableCell97
            //
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell97.StyleName = "DetailCaption3";
            this.xrTableCell97.Text = "Thesi PRV";
            this.xrTableCell97.Weight = 0.0030769230769230769D;
            //
            // xrTableCell98
            //
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell98.StyleName = "DetailCaption3";
            this.xrTableCell98.StylePriority.UseTextAlignment = false;
            this.xrTableCell98.Text = "Diametros PRV";
            this.xrTableCell98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell98.Weight = 0.0041654010919424207D;
            //
            // xrTableCell99
            //
            this.xrTableCell99.Name = "xrTableCell99";
            this.xrTableCell99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell99.StyleName = "DetailCaption3";
            this.xrTableCell99.StylePriority.UseTextAlignment = false;
            this.xrTableCell99.Text = "Katastasi PRV";
            this.xrTableCell99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell99.Weight = 0.0039050634090717021D;
            //
            // xrTableCell100
            //
            this.xrTableCell100.Name = "xrTableCell100";
            this.xrTableCell100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell100.StyleName = "DetailCaption3";
            this.xrTableCell100.Text = "PRVVardia Synergeiou";
            this.xrTableCell100.Weight = 0.0059443745246300327D;
            //
            // xrTableCell101
            //
            this.xrTableCell101.Name = "xrTableCell101";
            this.xrTableCell101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell101.StyleName = "DetailCaption3";
            this.xrTableCell101.StylePriority.UseTextAlignment = false;
            this.xrTableCell101.Text = "PRVArithmos Atomon Synergeiou";
            this.xrTableCell101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell101.Weight = 0.00863452911376953D;
            //
            // xrTableCell102
            //
            this.xrTableCell102.Name = "xrTableCell102";
            this.xrTableCell102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell102.StyleName = "DetailCaption3";
            this.xrTableCell102.Text = "Ergolavia";
            this.xrTableCell102.Weight = 0.0030769230769230769D;
            //
            // xrTableCell103
            //
            this.xrTableCell103.Name = "xrTableCell103";
            this.xrTableCell103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell103.StyleName = "DetailCaption3";
            this.xrTableCell103.StylePriority.UseTextAlignment = false;
            this.xrTableCell103.Text = "Idiotiko";
            this.xrTableCell103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell103.Weight = 0.0030769230769230769D;
            //
            // xrTableCell104
            //
            this.xrTableCell104.Name = "xrTableCell104";
            this.xrTableCell104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell104.StyleName = "DetailCaption3";
            this.xrTableCell104.Text = "Tropos Entopismou";
            this.xrTableCell104.Weight = 0.0052067510898296653D;
            //
            // xrTableCell105
            //
            this.xrTableCell105.Name = "xrTableCell105";
            this.xrTableCell105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell105.StyleName = "DetailCaption3";
            this.xrTableCell105.Text = "Eidos Vlavis";
            this.xrTableCell105.Weight = 0.0034277780239398664D;
            //
            // xrTableCell106
            //
            this.xrTableCell106.Name = "xrTableCell106";
            this.xrTableCell106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell106.StyleName = "DetailCaption3";
            this.xrTableCell106.Text = "Aitia Vlavis";
            this.xrTableCell106.Weight = 0.0032108299548809344D;
            //
            // xrTableCell107
            //
            this.xrTableCell107.Name = "xrTableCell107";
            this.xrTableCell107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell107.StyleName = "DetailCaption3";
            this.xrTableCell107.Text = "Onomasia Thesis";
            this.xrTableCell107.Weight = 0.004642686477074256D;
            //
            // xrTableCell108
            //
            this.xrTableCell108.Name = "xrTableCell108";
            this.xrTableCell108.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell108.StyleName = "DetailCaption3";
            this.xrTableCell108.Text = "Ekkremotites";
            this.xrTableCell108.Weight = 0.0037315049538245567D;
            //
            // xrTableCell109
            //
            this.xrTableCell109.Name = "xrTableCell109";
            this.xrTableCell109.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell109.StyleName = "DetailCaption3";
            this.xrTableCell109.Text = "Proteinomeno Simeio Dimos";
            this.xrTableCell109.Weight = 0.0073762306800255412D;
            //
            // xrTableCell110
            //
            this.xrTableCell110.Name = "xrTableCell110";
            this.xrTableCell110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell110.StyleName = "DetailCaption3";
            this.xrTableCell110.Text = "Proteinomeno Simeio Odos";
            this.xrTableCell110.Weight = 0.0071158937307504505D;
            //
            // xrTableCell111
            //
            this.xrTableCell111.Name = "xrTableCell111";
            this.xrTableCell111.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell111.StyleName = "DetailCaption3";
            this.xrTableCell111.Text = "Proteinomeno Simeio Atihmos";
            this.xrTableCell111.Weight = 0.0078535167987530043D;
            //
            // xrTableCell112
            //
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell112.StyleName = "DetailCaption3";
            this.xrTableCell112.StylePriority.UseTextAlignment = false;
            this.xrTableCell112.Text = "Proteinomeno Simeio Syntetagmeni X";
            this.xrTableCell112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell112.Weight = 0.009719269092266376D;
            //
            // xrTableCell113
            //
            this.xrTableCell113.Name = "xrTableCell113";
            this.xrTableCell113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell113.StyleName = "DetailCaption3";
            this.xrTableCell113.StylePriority.UseTextAlignment = false;
            this.xrTableCell113.Text = "Proteinomeno Simeio Syntetagmeni Y";
            this.xrTableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell113.Weight = 0.009719269092266376D;
            //
            // xrTableCell114
            //
            this.xrTableCell114.Name = "xrTableCell114";
            this.xrTableCell114.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell114.StyleName = "DetailCaption3";
            this.xrTableCell114.Text = "Onomasia Antliostasiou";
            this.xrTableCell114.Weight = 0.0062481014545147234D;
            //
            // xrTableCell115
            //
            this.xrTableCell115.Name = "xrTableCell115";
            this.xrTableCell115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell115.StyleName = "DetailCaption3";
            this.xrTableCell115.Text = "Hmerominia Apokatastasis";
            this.xrTableCell115.Weight = 0.0070291145031268782D;
            //
            // xrTableCell116
            //
            this.xrTableCell116.Name = "xrTableCell116";
            this.xrTableCell116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell116.StyleName = "DetailCaption3";
            this.xrTableCell116.Text = "Ora Apokatastasis";
            this.xrTableCell116.Weight = 0.0049464137737567611D;
            //
            // xrTableCell117
            //
            this.xrTableCell117.Name = "xrTableCell117";
            this.xrTableCell117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell117.StyleName = "DetailCaption3";
            this.xrTableCell117.StylePriority.UseTextAlignment = false;
            this.xrTableCell117.Text = "Parapono";
            this.xrTableCell117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell117.Weight = 0.0030769230769230769D;
            //
            // xrTableCell118
            //
            this.xrTableCell118.Name = "xrTableCell118";
            this.xrTableCell118.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell118.StyleName = "DetailCaption3";
            this.xrTableCell118.StylePriority.UseTextAlignment = false;
            this.xrTableCell118.Text = "Ektakto Deigma";
            this.xrTableCell118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell118.Weight = 0.0043823487942035383D;
            //
            // xrTableCell119
            //
            this.xrTableCell119.Name = "xrTableCell119";
            this.xrTableCell119.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell119.StyleName = "DetailCaption3";
            this.xrTableCell119.StylePriority.UseTextAlignment = false;
            this.xrTableCell119.Text = "Metrisi CLMe Lovipond";
            this.xrTableCell119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell119.Weight = 0.0060311533854557915D;
            //
            // xrTableCell120
            //
            this.xrTableCell120.Name = "xrTableCell120";
            this.xrTableCell120.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell120.StyleName = "DetailCaption3";
            this.xrTableCell120.StylePriority.UseTextAlignment = false;
            this.xrTableCell120.Text = "Metrisi CLMe Swan";
            this.xrTableCell120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell120.Weight = 0.0051199722290039065D;
            //
            // xrTableCell121
            //
            this.xrTableCell121.Name = "xrTableCell121";
            this.xrTableCell121.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell121.StyleName = "DetailCaption3";
            this.xrTableCell121.StylePriority.UseTextAlignment = false;
            this.xrTableCell121.Text = "Metrisi CLMe Fotometro Lovipond";
            this.xrTableCell121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell121.Weight = 0.0086779190943791322D;
            //
            // xrTableCell122
            //
            this.xrTableCell122.Name = "xrTableCell122";
            this.xrTableCell122.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell122.StyleName = "DetailCaption3";
            this.xrTableCell122.StylePriority.UseTextAlignment = false;
            this.xrTableCell122.Text = "Metrisi Apolimantikon Me Swan";
            this.xrTableCell122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell122.Weight = 0.0082006329756516682D;
            //
            // xrTableCell123
            //
            this.xrTableCell123.Name = "xrTableCell123";
            this.xrTableCell123.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell123.StyleName = "DetailCaption3";
            this.xrTableCell123.StylePriority.UseTextAlignment = false;
            this.xrTableCell123.Text = "Metrisi Apolimantikon Me Palintest";
            this.xrTableCell123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell123.Weight = 0.0090250352712777943D;
            //
            // xrTableCell124
            //
            this.xrTableCell124.Name = "xrTableCell124";
            this.xrTableCell124.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell124.StyleName = "DetailCaption3";
            this.xrTableCell124.Text = "Hmerominia Deigmatolipsias";
            this.xrTableCell124.Weight = 0.0075063998882587135D;
            //
            // xrTableCell125
            //
            this.xrTableCell125.Name = "xrTableCell125";
            this.xrTableCell125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell125.StyleName = "DetailCaption3";
            this.xrTableCell125.Text = "Ora Deigmatolipsias";
            this.xrTableCell125.Weight = 0.0054236991588885964D;
            //
            // xrTableCell126
            //
            this.xrTableCell126.Name = "xrTableCell126";
            this.xrTableCell126.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell126.StyleName = "DetailCaption3";
            this.xrTableCell126.StylePriority.UseTextAlignment = false;
            this.xrTableCell126.Text = "CLPedio";
            this.xrTableCell126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell126.Weight = 0.0030769230769230769D;
            //
            // xrTableCell127
            //
            this.xrTableCell127.Name = "xrTableCell127";
            this.xrTableCell127.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell127.StyleName = "DetailCaption3";
            this.xrTableCell127.StylePriority.UseTextAlignment = false;
            this.xrTableCell127.Text = "CLMetatropi";
            this.xrTableCell127.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell127.Weight = 0.0035145572515634391D;
            //
            // xrTableCell128
            //
            this.xrTableCell128.Name = "xrTableCell128";
            this.xrTableCell128.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell128.StyleName = "DetailCaption3";
            this.xrTableCell128.StylePriority.UseTextAlignment = false;
            this.xrTableCell128.Text = "Metrisi Ypol CLPedio A";
            this.xrTableCell128.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell128.Weight = 0.0059877637716440058D;
            //
            // xrTableCell129
            //
            this.xrTableCell129.Name = "xrTableCell129";
            this.xrTableCell129.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell129.StyleName = "DetailCaption3";
            this.xrTableCell129.StylePriority.UseTextAlignment = false;
            this.xrTableCell129.Text = "Diorthosi CL02Pedio B";
            this.xrTableCell129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell129.Weight = 0.0059443745246300327D;
            //
            // xrTableCell130
            //
            this.xrTableCell130.Name = "xrTableCell130";
            this.xrTableCell130.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell130.StyleName = "DetailCaption3";
            this.xrTableCell130.StylePriority.UseTextAlignment = false;
            this.xrTableCell130.Text = "CL A B";
            this.xrTableCell130.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell130.Weight = 0.0030769230769230769D;
            //
            // xrTableCell131
            //
            this.xrTableCell131.Name = "xrTableCell131";
            this.xrTableCell131.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell131.StyleName = "DetailCaption3";
            this.xrTableCell131.StylePriority.UseTextAlignment = false;
            this.xrTableCell131.Text = "CLO2";
            this.xrTableCell131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell131.Weight = 0.0030769230769230769D;
            //
            // xrTableCell132
            //
            this.xrTableCell132.Name = "xrTableCell132";
            this.xrTableCell132.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell132.StyleName = "DetailCaption3";
            this.xrTableCell132.Text = "Deigmatoliptis";
            this.xrTableCell132.Weight = 0.0040786218643188476D;
            //
            // xrTableCell133
            //
            this.xrTableCell133.Name = "xrTableCell133";
            this.xrTableCell133.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell133.StyleName = "DetailCaption3";
            this.xrTableCell133.Text = "Arithmos Metriti";
            this.xrTableCell133.Weight = 0.0045125176356388972D;
            //
            // xrTableCell134
            //
            this.xrTableCell134.Name = "xrTableCell134";
            this.xrTableCell134.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell134.StyleName = "DetailCaption3";
            this.xrTableCell134.Text = "Epipleon Deigma1";
            this.xrTableCell134.Weight = 0.0049464137737567611D;
            //
            // xrTableCell135
            //
            this.xrTableCell135.Name = "xrTableCell135";
            this.xrTableCell135.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell135.StyleName = "DetailCaption3";
            this.xrTableCell135.StylePriority.UseTextAlignment = false;
            this.xrTableCell135.Text = "Epipleon CL1";
            this.xrTableCell135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell135.Weight = 0.0036881153400127706D;
            //
            // xrTableCell136
            //
            this.xrTableCell136.Name = "xrTableCell136";
            this.xrTableCell136.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell136.StyleName = "DetailCaption3";
            this.xrTableCell136.Text = "Epipleon Deigma2";
            this.xrTableCell136.Weight = 0.0049464137737567611D;
            //
            // xrTableCell137
            //
            this.xrTableCell137.Name = "xrTableCell137";
            this.xrTableCell137.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell137.StyleName = "DetailCaption3";
            this.xrTableCell137.StylePriority.UseTextAlignment = false;
            this.xrTableCell137.Text = "Epipleon CL2";
            this.xrTableCell137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell137.Weight = 0.0036881153400127706D;
            //
            // xrTableCell138
            //
            this.xrTableCell138.Name = "xrTableCell138";
            this.xrTableCell138.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell138.StyleName = "DetailCaption3";
            this.xrTableCell138.Text = "Epipleon Deigma3";
            this.xrTableCell138.Weight = 0.0049464137737567611D;
            //
            // xrTableCell139
            //
            this.xrTableCell139.Name = "xrTableCell139";
            this.xrTableCell139.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell139.StyleName = "DetailCaption3";
            this.xrTableCell139.StylePriority.UseTextAlignment = false;
            this.xrTableCell139.Text = "Epipleon CL3";
            this.xrTableCell139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell139.Weight = 0.0036881153400127706D;
            //
            // xrTableCell140
            //
            this.xrTableCell140.Name = "xrTableCell140";
            this.xrTableCell140.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell140.StyleName = "DetailCaption3";
            this.xrTableCell140.Text = "Epipleon Deigma4";
            this.xrTableCell140.Weight = 0.0049464137737567611D;
            //
            // xrTableCell141
            //
            this.xrTableCell141.Name = "xrTableCell141";
            this.xrTableCell141.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell141.StyleName = "DetailCaption3";
            this.xrTableCell141.StylePriority.UseTextAlignment = false;
            this.xrTableCell141.Text = "Epipleon CL4";
            this.xrTableCell141.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell141.Weight = 0.0036881153400127706D;
            //
            // xrTableCell142
            //
            this.xrTableCell142.Name = "xrTableCell142";
            this.xrTableCell142.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell142.StyleName = "DetailCaption3";
            this.xrTableCell142.Text = "Remarks From Tablet";
            this.xrTableCell142.Weight = 0.0057274264555711015D;
            //
            // xrTableCell143
            //
            this.xrTableCell143.Name = "xrTableCell143";
            this.xrTableCell143.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell143.StyleName = "DetailCaption3";
            this.xrTableCell143.Text = "Address Municipality";
            this.xrTableCell143.Weight = 0.0055538680003239561D;
            //
            // xrTableCell144
            //
            this.xrTableCell144.Name = "xrTableCell144";
            this.xrTableCell144.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell144.StyleName = "DetailCaption3";
            this.xrTableCell144.Text = "Address Odos";
            this.xrTableCell144.Weight = 0.0038182841814481294D;
            //
            // xrTableCell145
            //
            this.xrTableCell145.Name = "xrTableCell145";
            this.xrTableCell145.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell145.StyleName = "DetailCaption3";
            this.xrTableCell145.Text = "Address Arithmos";
            this.xrTableCell145.Weight = 0.0048162449323214014D;
            //
            // xrTableCell146
            //
            this.xrTableCell146.Name = "xrTableCell146";
            this.xrTableCell146.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell146.StyleName = "DetailCaption3";
            this.xrTableCell146.Text = "Thesi Agogou";
            this.xrTableCell146.Weight = 0.0038182841814481294D;
            //
            // xrTableCell147
            //
            this.xrTableCell147.Name = "xrTableCell147";
            this.xrTableCell147.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell147.StyleName = "DetailCaption3";
            this.xrTableCell147.StylePriority.UseTextAlignment = false;
            this.xrTableCell147.Text = "Agogos Mikos";
            this.xrTableCell147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell147.Weight = 0.003861673795259916D;
            //
            // xrTableCell148
            //
            this.xrTableCell148.Name = "xrTableCell148";
            this.xrTableCell148.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell148.StyleName = "DetailCaption3";
            this.xrTableCell148.StylePriority.UseTextAlignment = false;
            this.xrTableCell148.Text = "Arithmos Vanon";
            this.xrTableCell148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell148.Weight = 0.0044257384080153249D;
            //
            // xrTableCell149
            //
            this.xrTableCell149.Name = "xrTableCell149";
            this.xrTableCell149.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell149.StyleName = "DetailCaption3";
            this.xrTableCell149.StylePriority.UseTextAlignment = false;
            this.xrTableCell149.Text = "Elegxos Piesis Gia Eidiki Paroxi";
            this.xrTableCell149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell149.Weight = 0.0080270745204045219D;
            //
            // xrTableCell150
            //
            this.xrTableCell150.Name = "xrTableCell150";
            this.xrTableCell150.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell150.StyleName = "DetailCaption3";
            this.xrTableCell150.StylePriority.UseTextAlignment = false;
            this.xrTableCell150.Text = "Agogos Diatomi";
            this.xrTableCell150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell150.Weight = 0.0043823487942035383D;
            //
            // xrTableCell151
            //
            this.xrTableCell151.Name = "xrTableCell151";
            this.xrTableCell151.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell151.StyleName = "DetailCaption3";
            this.xrTableCell151.Text = "Thesi Eidikis Paroxis";
            this.xrTableCell151.Weight = 0.005467088772700383D;
            //
            // xrTableCell152
            //
            this.xrTableCell152.Name = "xrTableCell152";
            this.xrTableCell152.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell152.StyleName = "DetailCaption3";
            this.xrTableCell152.Text = "Thesi Kataskeyis Neas Paroxis";
            this.xrTableCell152.Weight = 0.0078535167987530043D;
            //
            // xrTableCell153
            //
            this.xrTableCell153.Name = "xrTableCell153";
            this.xrTableCell153.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell153.StyleName = "DetailCaption3";
            this.xrTableCell153.Text = "BCC Hmerominia Anagelias";
            this.xrTableCell153.Weight = 0.0071158937307504505D;
            //
            // xrTableCell154
            //
            this.xrTableCell154.Name = "xrTableCell154";
            this.xrTableCell154.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell154.StyleName = "DetailCaption3";
            this.xrTableCell154.Text = "BCC Ora Anagelias";
            this.xrTableCell154.Weight = 0.0050331930013803334D;
            //
            // xrTableCell155
            //
            this.xrTableCell155.Name = "xrTableCell155";
            this.xrTableCell155.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell155.StyleName = "DetailCaption3";
            this.xrTableCell155.Text = "BCC Arithmos Aitimatos";
            this.xrTableCell155.Weight = 0.0063348806821382966D;
            //
            // xrTableCell156
            //
            this.xrTableCell156.Name = "xrTableCell156";
            this.xrTableCell156.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell156.StyleName = "DetailCaption3";
            this.xrTableCell156.Text = "BCC Ergolavia Neas Paroxis";
            this.xrTableCell156.Weight = 0.0072026722247783958D;
            //
            // xrTableCell157
            //
            this.xrTableCell157.Name = "xrTableCell157";
            this.xrTableCell157.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell157.StyleName = "DetailCaption3";
            this.xrTableCell157.Text = "BCC Arithmos Entolis Ergolavou";
            this.xrTableCell157.Weight = 0.0082006329756516682D;
            //
            // xrTableCell158
            //
            this.xrTableCell158.Name = "xrTableCell158";
            this.xrTableCell158.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell158.StyleName = "DetailCaption3";
            this.xrTableCell158.Text = "BCC Hmerominia Entolis";
            this.xrTableCell158.Weight = 0.0064216599097618688D;
            //
            // xrTableCell159
            //
            this.xrTableCell159.Name = "xrTableCell159";
            this.xrTableCell159.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell159.StyleName = "DetailCaption3";
            this.xrTableCell159.Text = "BCC Remarks";
            this.xrTableCell159.Weight = 0.0037748945676363433D;
            //
            // xrTableCell160
            //
            this.xrTableCell160.Name = "xrTableCell160";
            this.xrTableCell160.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell160.StyleName = "DetailCaption3";
            this.xrTableCell160.StylePriority.UseTextAlignment = false;
            this.xrTableCell160.Text = "Epifaneia Sq Mtrs";
            this.xrTableCell160.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell160.Weight = 0.0047728553185096157D;
            //
            // xrTableCell161
            //
            this.xrTableCell161.Name = "xrTableCell161";
            this.xrTableCell161.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell161.StyleName = "DetailCaption3";
            this.xrTableCell161.Text = "Eidos Plakon";
            this.xrTableCell161.Weight = 0.0036013361123891979D;
            //
            // xrTableCell162
            //
            this.xrTableCell162.Name = "xrTableCell162";
            this.xrTableCell162.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell162.StyleName = "DetailCaption3";
            this.xrTableCell162.StylePriority.UseTextAlignment = false;
            this.xrTableCell162.Text = "Arithmos Plakon";
            this.xrTableCell162.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell162.Weight = 0.0045125176356388972D;
            //
            // xrTableCell163
            //
            this.xrTableCell163.Name = "xrTableCell163";
            this.xrTableCell163.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell163.StyleName = "DetailCaption3";
            this.xrTableCell163.StylePriority.UseTextAlignment = false;
            this.xrTableCell163.Text = "Arithmos Temaxion";
            this.xrTableCell163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell163.Weight = 0.005250140703641451D;
            //
            // xrTableCell164
            //
            this.xrTableCell164.Name = "xrTableCell164";
            this.xrTableCell164.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell164.StyleName = "DetailCaption3";
            this.xrTableCell164.Text = "Eidos Epemvasis Neas Paroxis";
            this.xrTableCell164.Weight = 0.0078101268181434043D;
            //
            // xrTableCell165
            //
            this.xrTableCell165.Name = "xrTableCell165";
            this.xrTableCell165.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell165.StyleName = "DetailCaption3";
            this.xrTableCell165.StylePriority.UseTextAlignment = false;
            this.xrTableCell165.Text = "Reithro";
            this.xrTableCell165.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell165.Weight = 0.0030769230769230769D;
            //
            // xrTableCell166
            //
            this.xrTableCell166.Name = "xrTableCell166";
            this.xrTableCell166.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell166.StyleName = "DetailCaption3";
            this.xrTableCell166.StylePriority.UseTextAlignment = false;
            this.xrTableCell166.Text = "Propagated";
            this.xrTableCell166.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell166.Weight = 0.0033409987963162937D;
            //
            // xrTableCell167
            //
            this.xrTableCell167.Name = "xrTableCell167";
            this.xrTableCell167.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell167.StyleName = "DetailCaption3";
            this.xrTableCell167.Text = "Problima Piesis";
            this.xrTableCell167.Weight = 0.004252180319565993D;
            //
            // xrTableCell168
            //
            this.xrTableCell168.Name = "xrTableCell168";
            this.xrTableCell168.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell168.StyleName = "DetailCaption3";
            this.xrTableCell168.StylePriority.UseTextAlignment = false;
            this.xrTableCell168.Text = "Orofos";
            this.xrTableCell168.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell168.Weight = 0.0030769230769230769D;
            //
            // xrTableCell169
            //
            this.xrTableCell169.Name = "xrTableCell169";
            this.xrTableCell169.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell169.StyleName = "DetailCaption3";
            this.xrTableCell169.Text = "Hmerominia Anagelias";
            this.xrTableCell169.Weight = 0.0059877637716440058D;
            //
            // xrTableCell170
            //
            this.xrTableCell170.Name = "xrTableCell170";
            this.xrTableCell170.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell170.StyleName = "DetailCaption3";
            this.xrTableCell170.Text = "Ora Anagelias";
            this.xrTableCell170.Weight = 0.0039050634090717021D;
            //
            // xrTableCell171
            //
            this.xrTableCell171.Name = "xrTableCell171";
            this.xrTableCell171.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell171.StyleName = "DetailCaption3";
            this.xrTableCell171.Text = "Energeies Problimatos Piesis";
            this.xrTableCell171.Weight = 0.0075063998882587135D;
            //
            // xrTableCell172
            //
            this.xrTableCell172.Name = "xrTableCell172";
            this.xrTableCell172.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell172.StyleName = "DetailCaption3";
            this.xrTableCell172.StylePriority.UseTextAlignment = false;
            this.xrTableCell172.Text = "Aitio Problimatos Id";
            this.xrTableCell172.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell172.Weight = 0.0053803095450768107D;
            //
            // xrTableCell173
            //
            this.xrTableCell173.Name = "xrTableCell173";
            this.xrTableCell173.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell173.StyleName = "DetailCaption3";
            this.xrTableCell173.Text = "Arithmos Aitimatos";
            this.xrTableCell173.Weight = 0.0052067510898296653D;
            //
            // xrTableCell174
            //
            this.xrTableCell174.Name = "xrTableCell174";
            this.xrTableCell174.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell174.StyleName = "DetailCaption3";
            this.xrTableCell174.Text = "Thesi Termatos";
            this.xrTableCell174.Weight = 0.004252180319565993D;
            //
            // xrTableCell175
            //
            this.xrTableCell175.Name = "xrTableCell175";
            this.xrTableCell175.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell175.StyleName = "DetailCaption3";
            this.xrTableCell175.Text = "Back End Tablet Id";
            this.xrTableCell175.Weight = 0.00507658261519212D;
            //
            // xrTableCell176
            //
            this.xrTableCell176.Name = "xrTableCell176";
            this.xrTableCell176.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell176.StyleName = "DetailCaption3";
            this.xrTableCell176.Text = "Epilegmeni Apomonosi";
            this.xrTableCell176.Weight = 0.0060311533854557915D;
            //
            // xrTableCell177
            //
            this.xrTableCell177.Name = "xrTableCell177";
            this.xrTableCell177.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell177.StyleName = "DetailCaption3";
            this.xrTableCell177.Text = "IDApomonosis";
            this.xrTableCell177.Weight = 0.0040786218643188476D;
            //
            // xrTableCell178
            //
            this.xrTableCell178.Name = "xrTableCell178";
            this.xrTableCell178.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell178.StyleName = "DetailCaption3";
            this.xrTableCell178.StylePriority.UseTextAlignment = false;
            this.xrTableCell178.Text = "Diametros Pyrosvestikou Krounou Paroxis";
            this.xrTableCell178.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell178.Weight = 0.010717229843139648D;
            //
            // xrTableCell179
            //
            this.xrTableCell179.Name = "xrTableCell179";
            this.xrTableCell179.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell179.StyleName = "DetailCaption3";
            this.xrTableCell179.Text = "Oximata Epanaforas";
            this.xrTableCell179.Weight = 0.0054236991588885964D;
            //
            // xrTableCell180
            //
            this.xrTableCell180.Name = "xrTableCell180";
            this.xrTableCell180.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell180.StyleName = "DetailCaption3";
            this.xrTableCell180.Text = "Epanafora Odostromatos Type";
            this.xrTableCell180.Weight = 0.0078535167987530043D;
            //
            // xrTableCell181
            //
            this.xrTableCell181.Name = "xrTableCell181";
            this.xrTableCell181.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell181.StyleName = "DetailCaption3";
            this.xrTableCell181.Text = "Epanafora Pezodromiou Type";
            this.xrTableCell181.Weight = 0.0076365683628962589D;
            //
            // xrTableCell182
            //
            this.xrTableCell182.Name = "xrTableCell182";
            this.xrTableCell182.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell182.StyleName = "DetailCaption3";
            this.xrTableCell182.Text = "Diktyo Paroxi";
            this.xrTableCell182.Weight = 0.0038182841814481294D;
            //
            // xrTableCell183
            //
            this.xrTableCell183.Name = "xrTableCell183";
            this.xrTableCell183.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell183.StyleName = "DetailCaption3";
            this.xrTableCell183.StylePriority.UseTextAlignment = false;
            this.xrTableCell183.Text = "Problem Category";
            this.xrTableCell183.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell183.Weight = 0.0049030241599449746D;
            //
            // xrTableCell184
            //
            this.xrTableCell184.Name = "xrTableCell184";
            this.xrTableCell184.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell184.StyleName = "DetailCaption3";
            this.xrTableCell184.StylePriority.UseTextAlignment = false;
            this.xrTableCell184.Text = "Eidos Problematos";
            this.xrTableCell184.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell184.Weight = 0.0050331930013803334D;
            //
            // xrTableCell185
            //
            this.xrTableCell185.Name = "xrTableCell185";
            this.xrTableCell185.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell185.StyleName = "DetailCaption3";
            this.xrTableCell185.Text = "Diagnosi";
            this.xrTableCell185.Weight = 0.0030769230769230769D;
            //
            // xrTableCell186
            //
            this.xrTableCell186.Name = "xrTableCell186";
            this.xrTableCell186.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell186.StyleName = "DetailCaption3";
            this.xrTableCell186.Text = "Symperasma";
            this.xrTableCell186.Weight = 0.0036883970407339244D;
            //
            // groupFooterBand1
            //
            this.groupFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2});
            this.groupFooterBand1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.groupFooterBand1.HeightF = 6F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            //
            // xrLabel2
            //
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(650F, 2.08F);
            this.xrLabel2.StyleName = "GroupCaption3";
            this.xrLabel2.StylePriority.UseBorders = false;
            //
            // Title
            //
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            //
            // GroupCaption3
            //
            this.GroupCaption3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GroupCaption3.BorderColor = System.Drawing.Color.White;
            this.GroupCaption3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupCaption3.BorderWidth = 2F;
            this.GroupCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.GroupCaption3.Name = "GroupCaption3";
            this.GroupCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100F);
            this.GroupCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // GroupData3
            //
            this.GroupData3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GroupData3.BorderColor = System.Drawing.Color.White;
            this.GroupData3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupData3.BorderWidth = 2F;
            this.GroupData3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupData3.ForeColor = System.Drawing.Color.White;
            this.GroupData3.Name = "GroupData3";
            this.GroupData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100F);
            this.GroupData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // DetailCaption3
            //
            this.DetailCaption3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.BorderColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DetailCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption3.Name = "DetailCaption3";
            this.DetailCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // DetailData3
            //
            this.DetailData3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3.ForeColor = System.Drawing.Color.Black;
            this.DetailData3.Name = "DetailData3";
            this.DetailData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // DetailData3_Odd
            //
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // DetailCaptionBackground3
            //
            this.DetailCaptionBackground3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaptionBackground3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.DetailCaptionBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.DetailCaptionBackground3.BorderWidth = 2F;
            this.DetailCaptionBackground3.Name = "DetailCaptionBackground3";
            //
            // PageInfo
            //
            this.PageInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            //
            // PageHeader
            //
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.PageHeader.HeightF = 39.58333F;
            this.PageHeader.Name = "PageHeader";
            //
            // FormReport1001
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.reportHeaderBand1,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupFooterBand1,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Visits";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 104, 35);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.GroupCaption3,
            this.GroupData3,
            this.DetailCaption3,
            this.DetailData3,
            this.DetailData3_Odd,
            this.DetailCaptionBackground3,
            this.PageInfo});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
