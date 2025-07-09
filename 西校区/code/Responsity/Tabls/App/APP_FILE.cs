using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables {
    /// <summary>
    /// Object Data Class for APP_FILE Table
    /// </summary>
    [Serializable]
    [DataTable("APP_FILE", ResourceKey = "APP_FILE")]
    public class APP_FILE : BaseObject {
        public APP_FILE()
        {
        }
        public APP_FILE(DealModel initModel) : base(initModel)
        {
        }
        public static APP_FILE Convert(BaseObject from)
        {
            return (APP_FILE)from;
        }
        /// <summary>
        /// The FILE_ID Field of APP_FILE Table
        /// </summary>
        private decimal _file_id;
        public override decimal ID
        {
            set
            {
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
        public decimal FILE_ID
        {
            set { _file_id = value; }
            get { return _file_id; }
        }
        /// <summary>
        /// The REF_NO Field of APP_FILE Table
        /// </summary>
        private string _ref_no;
        [DataField("REF_NO"
            , AliasName = "REF_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "REF_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REF_NO
        {
            set { _ref_no = value; }
            get { return _ref_no; }
        }
        /// <summary>
        /// The FILE_NAME Field of APP_FILE Table
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
        public string FILE_NAME
        {
            set { _file_name = value; }
            get { return _file_name; }
        }
        /// <summary>
        /// The FILE_TYPE Field of APP_FILE Table
        /// </summary>
        private string _file_type;
        [DataField("FILE_TYPE"
            , AliasName = "FILE_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_TYPE
        {
            set { _file_type = value; }
            get { return _file_type; }
        }
        /// <summary>
        /// The SEQ_NO Field of APP_FILE Table
        /// </summary>
        private decimal _seq_no;
        [DataField("SEQ_NO"
            , AliasName = "SEQ_NO"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SEQ_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal SEQ_NO
        {
            set { _seq_no = value; }
            get { return _seq_no; }
        }
        /// <summary>
        /// The FILE_DESC Field of APP_FILE Table
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
        public string FILE_DESC
        {
            set { _file_desc = value; }
            get { return _file_desc; }
        }
        /// <summary>
        /// The IS_ENABLED Field of APP_FILE Table
        /// </summary>
        private Int32 _is_enabled;
        [DataField("IS_ENABLED"
            , AliasName = "IS_ENABLED"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_ENABLED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 IS_ENABLED
        {
            set { _is_enabled = value; }
            get { return _is_enabled; }
        }
        /// <summary>
        /// The REMARK Field of APP_FILE Table
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
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of APP_FILE Table
        /// </summary>
        private DateTime _update_time;
        [DataField("UPDATE_TIME"
            , AliasName = "UPDATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , ResourceKey = "UPDATE_TIME"
            , GroupFun = "MAX"
            , SelectSequence = 104
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "SysDate"
             )]
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// APP_FILE Table 
        /// </summary>
        public const string TABLE_NAME = "APP_FILE";
        public const String FILE_ID_FIELD = "FILE_ID";
        public const String REF_NO_FIELD = "REF_NO";
        public const String IMAGE_ID_FIELD = "IMAGE_ID";
        public const String FILE_TYPE_FIELD = "FILE_TYPE";
        public const String SEQ_NO_FIELD = "SEQ_NO";
        public const String FILE_DESC_FIELD = "FILE_DESC";
        public const String IS_ENABLED_FIELD = "IS_ENABLED";
        public const String REMARK_FIELD = "REMARK";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}