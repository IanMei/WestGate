using CMS.Core.Common;
using System;
using System.Data;

namespace CMS.Core.Responsity.Tables {
    /// <summary>
    /// Object Data Class for SYS_USER Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_USER", ResourceKey = "SYS_USER")]
    public class SYS_USER : BaseObject
    {
        public SYS_USER()
        {

        }
        public SYS_USER(DealModel initModel)
            : base(initModel)
        {

        }
        public static SYS_USER Convert(BaseObject from)
        {
            return (SYS_USER)from;
        }
        /// <summary>
        /// The USER_ID Field of SYS_USER Table
        /// </summary>
        private decimal _user_id = -1;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.USER_ID = value;
            }
            get { return USER_ID; }
        }

        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.USER_CODE = value;
            }
            get { return USER_CODE; }
        }

        [RecordIDField("USER_ID"
            , AliasName = "USER_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "USER_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// The USER_CODE Field of SYS_USER Table
        /// </summary>
        private string _user_code;
        [KeyField("USER_CODE"
            , AliasName = "USER_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "USER_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string USER_CODE
        {
            set { _user_code = value; }
            get { return _user_code; }
        }

        /// <summary>
        /// The USER_PWD Field of SYS_USER Table
        /// </summary>
        private string _user_pwd;
        [DataField("USER_PWD"
            , AliasName = "USER_PWD"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 120
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_PWD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USER_PWD
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// The USER_NAME Field of SYS_USER Table
        /// </summary>
        private string _user_name;
        [DataField("USER_NAME"
            , AliasName = "USER_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "USER_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }

        /// <summary>
        /// The USER_NAME Field of SYS_USER Table
        /// </summary>
        private string organ_code;
        [DataField("ORGAN_CODE"
            , AliasName = "ORGAN_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ORGAN_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ORGAN_CODE
        {
            set { organ_code = value; }
            get { return organ_code; }
        }
        /// <summary>
        /// The ROLE_TYPE Field of SYS_USER Table
        /// </summary>
        private string _role_type;
        [DataField("ROLE_TYPE"
            , AliasName = "ROLE_TYPE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 2
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "ROLE_TYPE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "02"
             )]
        public string ROLE_TYPE
        {
            set { _role_type = value; }
            get { return _role_type; }
        }

        /// <summary>
        /// The EMAIL Field of SYS_USER Table
        /// </summary>
        private string _email;
        [DataField("EMAIL"
            , AliasName = "EMAIL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EMAIL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// The MOBILE Field of SYS_USER Table
        /// </summary>
        private string _mobile;
        [DataField("MOBILE"
            , AliasName = "MOBILE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MOBILE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 18
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MOBILE
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// The IS_AVAILABLE Field of SYS_USER Table
        /// </summary>
        private int _is_available;
        [DataField("IS_AVAILABLE"
            , AliasName = "IS_AVAILABLE"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_AVAILABLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public int IS_AVAILABLE
        {
            set { _is_available = value; }
            get { return _is_available; }
        }
        /// <summary>
        /// The IS_AVAILABLE Field of SYS_USER Table
        /// </summary>
        private int _is_admin;
        [DataField("IS_ADMIN"
            , AliasName = "IS_ADMIN"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 1
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_ADMIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 23
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , DefaultValue = "N"
             )]
        public int IS_ADMIN
        {
            set { _is_admin = value; }
            get { return _is_admin; }
        }
        /// <summary>
        /// The REMARK Field of SYS_USER Table
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
            , SelectSequence = 24
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
        /// The CREATE_BY Field of SYS_USER Table
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
        /// The CREATE_TIME Field of SYS_USER Table
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
        /// The UPDATE_BY Field of SYS_USER Table
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
        /// The UPDATE_TIME Field of SYS_USER Table
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
        /// 登录标记
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// 登录是否成功
        /// </summary>
        public bool IS_Login
        {
            get;
            set;
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string ErrMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 角色权限
        /// </summary>
        private string _role_permission;
        [ExpressionField("(SELECT [dbo].[FN_RolePermissionDetailGetStrName] (SYS_USER.USER_ID,SYS_USER.ROLE_TYPE))"
            , AliasName = "RolePermission"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 50
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "RolePermission"
            , GroupFun = "MAX"
            , AllowEdit = true
            , Frozen = true
            , SelectSequence = 101
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public string RolePermission
        {
            set { _role_permission = value; }
            get { return _role_permission; }
        }

        public const string TABLE_NAME = "SYS_USER";
        public const String USER_ID_FIELD = "USER_ID";
        public const String USER_CODE_FIELD = "USER_CODE";
        public const String USER_PWD_FIELD = "USER_PWD";
        public const String USER_NAME_FIELD = "USER_NAME";
        public const String ORGAN_CODE_FIELD = "ORGAN_CODE";
        public const String ROLE_TYPE_FIELD = "ROLE_TYPE";
        public const String EMAIL_FIELD = "EMAIL";
        public const String MOBILE_FIELD = "MOBILE";
        public const String IS_AVAILABLE_FIELD = "IS_AVAILABLE";
        public const String IS_ADMIN_FIELD = "IS_ADMIN";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}