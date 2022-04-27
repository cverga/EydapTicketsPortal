using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Helpers
{
    public class DataRowAdapter : IDataRecord
    {
        private DataRow _Row;

        public DataRow Row => _Row;


        public DataRowAdapter(DataRow row)
        {
            _Row = row;
        }

        public object this[string name] => _Row[name];

        public object this[int i] => _Row[i];

        public int FieldCount => _Row.Table.Columns.Count;

        public bool GetBoolean(int i)
        {
            return Convert.ToBoolean(_Row[i]);
        }

        public byte GetByte(int i)
        {
            return Convert.ToByte(_Row[i]);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException(string.Format("{0} is not supported.", nameof(GetBytes)));
        }

        public char GetChar(int i)
        {
            return Convert.ToChar(_Row[i]);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException(string.Format("{0} is not supported.", nameof(GetChars)));
        }

        public IDataReader GetData(int i)
        {
            throw new NotSupportedException(string.Format("{0} is not supported.", nameof(GetData)));
        }

        public string GetDataTypeName(int i)
        {
            return _Row[i].GetType().Name;
        }

        public DateTime GetDateTime(int i)
        {
            return Convert.ToDateTime(_Row[i]);
        }

        public decimal GetDecimal(int i)
        {
            return Convert.ToDecimal(_Row[i]);
        }

        public double GetDouble(int i)
        {
            return Convert.ToDouble(_Row[i]);
        }

        public Type GetFieldType(int i)
        {
            return _Row[i].GetType();
        }

        public float GetFloat(int i)
        {
            return Convert.ToSingle(_Row[i]);
        }

        public Guid GetGuid(int i)
        {
            return (Guid)_Row[i];
        }

        public short GetInt16(int i)
        {
            return Convert.ToInt16(_Row[i]);
        }

        public int GetInt32(int i)
        {
            return Convert.ToInt32(_Row[i]);
        }

        public long GetInt64(int i)
        {
            return Convert.ToInt64(_Row[i]);
        }

        public string GetName(int i)
        {
            return _Row.Table.Columns[i].ColumnName;
        }

        public int GetOrdinal(string name)
        {
            return _Row.Table.Columns.IndexOf(name);
        }

        public string GetString(int i)
        {
            return _Row[i].ToString();
        }

        public object GetValue(int i)
        {
            return _Row[i];
        }

        public int GetValues(object[] values)
        {
            int fieldCount = FieldCount;
            int fieldIndex;
            for(fieldIndex=0; fieldIndex < values.Length && fieldIndex < fieldCount; fieldIndex++)
            {
                values[fieldIndex] = _Row[fieldIndex];
            }
            return fieldIndex + 1;
        }

        public bool IsDBNull(int i)
        {
            return Convert.IsDBNull(_Row[i]);
        }
    }
}
