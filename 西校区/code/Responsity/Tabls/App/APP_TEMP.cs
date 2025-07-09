using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_TEMP Table
    /// </summary>
    [Serializable]
    [DataTable("APP_TEMP", ResourceKey = "APP_TEMP")]
    public class APP_TEMP : BaseObject
    {
        public APP_TEMP()
        {
        }
        public APP_TEMP(DealModel initModel) : base(initModel)
        {
        }
        public static APP_TEMP Convert(BaseObject from)
        {
            return (APP_TEMP)from;
        }
        /// <summary>
        /// The FILE_ID Field of APP_TEMP Table
        /// </summary>
        private decimal _file_id;
        public override decimal ID {
            set {
                base.ID = value;
                this.FILE_ID = value;
            }
            get { return FILE_ID; }
        }

        [RecordIDField("FILE_ID"
            , AliasName = "FILE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FILE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal FILE_ID {
            set { _file_id = value; }
            get { return _file_id; }
        }
        /// <summary>
        /// The FILE_TYPE Field of APP_TEMP Table
        /// </summary>
        private string _file_type;
        [DataField("FILE_TYPE"
            , AliasName = "FILE_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "01"
             )]
        public string FILE_TYPE {
            set { _file_type = value; }
            get { return _file_type; }
        }
        /// <summary>
        /// The FILE_NAME Field of APP_TEMP Table
        /// </summary>
        private string _file_name;
        [DataField("FILE_NAME"
            , AliasName = "FILE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_NAME {
            set { _file_name = value; }
            get { return _file_name; }
        }
        /// <summary>
        /// The FILE_PATH Field of APP_TEMP Table
        /// </summary>
        private string _file_path;
        [DataField("FILE_PATH"
            , AliasName = "FILE_PATH"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_PATH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_PATH {
            set { _file_path = value; }
            get { return _file_path; }
        }
        /// <summary>
        /// The FILE_DESC Field of APP_TEMP Table
        /// </summary>
        private string _file_desc;
        [DataField("FILE_DESC"
            , AliasName = "FILE_DESC"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_DESC"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_DESC {
            set { _file_desc = value; }
            get { return _file_desc; }
        }
        /// <summary>
        /// The REMARK Field of APP_TEMP Table
        /// </summary>
        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REMARK {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// The CREATE_TIME Field of APP_TEMP Table
        /// </summary>
        private DateTime _create_time;
        [DataField("CREATE_TIME"
            , AliasName = "CREATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 102
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "SysDate"
             )]
        public DateTime CREATE_TIME {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of APP_TEMP Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , SelectSequence = 104
            , DialogSequence = -1
            , Frozen = false
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// APP_TEMP Table 
        /// </summary>
        public const string TABLE_NAME = "APP_TEMP";
        public const String FILE_ID_FIELD = "FILE_ID";
        public const String FILE_TYPE_FIELD = "FILE_TYPE";
        public const String FILE_NAME_FIELD = "FILE_NAME";
        public const String FILE_PATH_FIELD = "FILE_PATH";
        public const String FILE_DESC_FIELD = "FILE_DESC";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}