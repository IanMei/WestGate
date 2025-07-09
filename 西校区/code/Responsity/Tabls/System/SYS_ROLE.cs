using CMS.Core.Common;
using System;
using System.Data;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for SYS_ROLE Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_ROLE", ResourceKey = "SYS_ROLE")]
    public class SYS_ROLE : BaseObject
    {
        public SYS_ROLE()
        {
        }
        public SYS_ROLE(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_ROLE Convert(BaseObject from)
        {
            return (SYS_ROLE)from;
        }
        /// <summary>
        /// The ROLE_ID Field of SYS_ROLE Table
        /// </summary>
        private decimal _role_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.ROLE_ID = value;
            }
            get { return ROLE_ID; }
        }

        [RecordIDField("ROLE_ID"
            , AliasName = "ROLE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "ROLE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal ROLE_ID
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// The ROLE_NO Field of SYS_ROLE Table
        /// </summary>
        private string _role_no;
        public override string CODE {
            set {
                base.CODE = value;
                this.ROLE_NO = value;
            }
            get { return ROLE_NO; }
        }
        [KeyField("ROLE_NO"
            , AliasName = "ROLE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = true
            , ResourceKey = "ROLE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 6
            , DialogSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string ROLE_NO
        {
            set { _role_no = value; }
            get { return _role_no; }
        }

        /// <summary>
        /// The ROLE_TYPE Field of SYS_ROLE Table
        /// </summary>
        private string _role_type;
        [DataField("ROLE_TYPE"
            , AliasName = "ROLE_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 10
            , Width = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "ROLE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ROLE_TYPE
        {
            set { _role_type = value; }
            get { return _role_type; }
        }

        /// <summary>
        /// The ROLE_NAME Field of SYS_ROLE Table
        /// </summary>
        private string _role_name;
        [DataField("ROLE_NAME"
            , AliasName = "ROLE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "ROLE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ROLE_NAME
        {
            set { _role_name = value; }
            get { return _role_name; }
        }

        private int _is_admin;
        [DataField("IS_ADMIN"
            , AliasName = "IS_ADMIN"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 9
            , Width = 20
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "IS_ADMIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "0"
             )]
        public int IS_ADMIN
        {
            set { _is_admin = value; }
            get { return _is_admin; }
        }

        /// <summary>
        /// The IS_ENABLED Field of SYS_ROLE Table
        /// </summary>
        private int _is_enabled;
        [DataField("IS_ENABLED"
            , AliasName = "IS_ENABLED"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 9
            , Width = 20
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_ENABLED"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "1"
             )]
        public int IS_ENABLED
        {
            set { _is_enabled = value; }
            get { return _is_enabled; }
        }
 
        /// <summary>
        /// The REMARK Field of SYS_ROLE Table
        /// </summary>
        private string _remark;
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 20
            , DisplayInCondition = false
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
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// The CREATE_BY Field of SYS_ROLE Table
        /// </summary>
        private decimal _create_by;
        [DataField("CREATE_BY"
            , AliasName = "CREATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CREATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 101
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "UserID"
             )]
        public decimal CREATE_BY
        {
            set { _create_by = value; }
            get { return _create_by; }
        }
        /// <summary>
        /// The CREATE_TIME Field of SYS_ROLE Table
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
        public DateTime CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// The UPDATE_BY Field of SYS_ROLE Table
        /// </summary>
        private decimal _update_by;
        [DataField("UPDATE_BY"
            , AliasName = "UPDATE_BY"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 9
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "UPDATE_BY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 103
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "UserID"
             )]
        public decimal UPDATE_BY
        {
            set { _update_by = value; }
            get { return _update_by; }
        }
        /// <summary>
        /// The UPDATE_TIME Field of SYS_ROLE Table
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
        public DateTime UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// SYS_ROLE Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_ROLE";
        public const String ROLE_ID_FIELD = "ROLE_ID";
        public const String ROLE_NO_FIELD = "ROLE_NO";
        public const String ROLE_TYPE_FIELD = "ROLE_TYPE";
        public const String ROLE_NAME_FIELD = "ROLE_NAME";
        public const String IS_ENABLED_FIELD = "IS_ENABLED";
        public const String IS_ADMIN_FIELD = "IS_ADMIN";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}