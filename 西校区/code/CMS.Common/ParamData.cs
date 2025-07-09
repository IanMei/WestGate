using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CMS.Core.Common {
    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    public class ParamData
    {
        private string _paramName;
        private DbType _dataType = DbType.String;
        private object _value = null;
        public ParamData()
        {
        }

        /// <summary>
        /// ����һ����������
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        public ParamData(string paramName,DbType dataType,object value)
        {
            _paramName = paramName;
            _dataType = dataType;
            _value = value;
        }

        /// <summary>
        /// ������
        /// </summary>
        public string ParamName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DbType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        /// <summary>
        /// ����ֵ
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    /// <summary>
    /// ��ѯ�������
    /// </summary>
    [Serializable]
    public class ParamCollection : List<ParamData>
    {
        
        private string _clause = "";
        public ParamCollection()
        {
        }

        /// <summary>
        /// ��ѯ�Ӿ�
        /// (ex. name=@name) AND (sendDate BETWEEN @SENDDATE1 AND @SENDDATE2) OR (ID IN (@ID1,@ID2,@ID3))
        /// </summary>
        public string Clause
        {
            get { return _clause; }
            set { _clause = value; }
        }

        private object[] _para = new object[] { };
        public object[] ParaData
        {
            get { return _para; }
            set { _para = value; }
        }
    }
}
