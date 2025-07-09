using CMS.Core.Common;
using System;
using System.Data;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for SYS_PERM Table
    /// </summary>
    [Serializable]
    [DataTable("SYS_PERM", ResourceKey = "SYS_PERM")]
    public class SYS_PERM : BaseObject
    {
        public SYS_PERM()
        {
        }
        public SYS_PERM(DealModel initModel)
            : base(initModel)
        {
        }
        public static SYS_PERM Convert(BaseObject from)
        {
            return (SYS_PERM)from;
        }

        /// <summary>
        /// The PERM_ID Field of SYS_PERM Table
        /// </summary>
        private decimal _perm_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.PERM_ID = value;
            }
            get { return PERM_ID; }
        }


        /// <summary>
        /// ¸²¸ÇCODEµÄÖµ
        /// </summary>
        public override string CODE
        {
            set
            {
                base.CODE = value;
                this.FUNCTION_ID = value;
            }
            get { return FUNCTION_ID; }
        }



        [RecordIDField("PERM_ID"
            , AliasName = "PERM_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 18
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PERM_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal PERM_ID
        {
            set { _perm_id = value; }
            get { return _perm_id; }
        }

        private decimal _user_id;
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        private string _role_no;
        [KeyField("ROLE_NO"
            , AliasName = "ROLE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "ROLE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        [ForeignKeyField("ROLE_NO"
          , AliasName = "ROLE_NO"
          , DataType = DbType.String
          , IsNullable = false
          , Size = 100
          , Width = 100
          , DisplayInCondition = false
          , DisplayInMaintain = false
          , DisplayInDialog = false
          , ResourceKey = "ROLE_NO"
          , GroupFun = ""
          , AllowEdit = false
          , Frozen = false
          , SelectSequence = -1
          , DialogSequence = -1
          , IsInsertField = false
          , IsUpdateField = false
          , ForeignTableName = SYS_ROLE.TABLE_NAME
          , ForeignTableAliasName = SYS_ROLE.TABLE_NAME
          , ForeignColumnName = SYS_ROLE.ROLE_NO_FIELD
          , IsMainTableKey = true
          , ForeignTableJoinType = TableJoinType.LeftOuterJoin
          , TableJoinSequence = 0
       )]
        public string ROLE_NO
        {
            set { _role_no = value; }
            get { return _role_no; }
        }

        /// <summary>
        /// The FUNCTION_ID Field of SYS_PERM Table
        /// </summary>
        private string _function_id;
        [KeyField("FUNCTION_ID"
            , AliasName = "FUNCTION_ID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "FUNCTION_ID"
            , GroupFun = ""
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 6
            , DialogSequence = 6
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 1
             )]
        [ForeignKeyField("FUNCTION_ID"
            , AliasName = "FUNCTION_ID"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_ID"
            , GroupFun = ""
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = -1
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = SYS_FUNCTION.TABLE_NAME
            , ForeignColumnName = SYS_FUNCTION.FUNCTION_ID_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
         )]
        public string FUNCTION_ID
        {
            set { _function_id = value; }
            get { return _function_id; }
        }

        /// <summary>
        /// The MODULE_NAME Field of SYS_MODULE Table
        /// </summary>
        private decimal _function_code;
        [ForeignField("FUNCTION_CODE"
            , AliasName = "FUNCTION_CODE"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 30
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = SYS_FUNCTION.TABLE_NAME
            , ForeignColumnName = SYS_FUNCTION.FUNCTION_CODE_FIELD
             )]
        public decimal FUNCTION_CODE
        {
            set { _function_code = value; }
            get { return _function_code; }
        }

        /// <summary>
        /// The MODULE_NAME Field of SYS_MODULE Table
        /// </summary>
        private string _function_name;
        [ForeignField("FUNCTION_NAME"
            , AliasName = "FUNCTION_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 30
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FUNCTION_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_FUNCTION.TABLE_NAME
            , ForeignTableAliasName = SYS_FUNCTION.TABLE_NAME
            , ForeignColumnName = SYS_FUNCTION.FUNCTION_NAME_FIELD
             )]
        public string FUNCTION_NAME
        {
            set { _function_name = value; }
            get { return _function_name; }
        }


        private string _module_code;
        [ForeignKeyField("MODULE_CODE"
            , AliasName = "MODULE_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "MODULE_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , TableName = SYS_FUNCTION.TABLE_NAME
            , TableAliasName = SYS_FUNCTION.TABLE_NAME
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODULE_CODE_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
         )]
        public string MODULE_CODE
        {
            set { _module_code = value; }
            get { return _module_code; }
        }



        /// <summary>
        /// The MODULE_NAME Field of SYS_MODULE Table
        /// </summary>
        private string _module_name;
        [ForeignField("MODULE_NAME"
            , AliasName = "MODULE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 30
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 4
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODULE_NAME_FIELD
             )]
        public string MODULE_NAME
        {
            set { _module_name = value; }
            get { return _module_name; }
        }


        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _parent_code;
        [ForeignField("PARENT_CODE"
            , AliasName = "PARENT_CODE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PARENT_CODE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
          , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.PARENT_CODE_FIELD
             )]
        public string PARENT_CODE
        {
            set { _parent_code = value; }
            get { return _parent_code; }
        }



        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _assembly_name;
        [ForeignField("MODULE_URL"
            , AliasName = "MODULE_URL"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_URL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODULE_URL_FIELD
             )]
        public string MODULE_URL
        {
            set { _assembly_name = value; }
            get { return _assembly_name; }
        }
        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _form_name = "-1";
        [ForeignField("MODULE_FILE"
            , AliasName = "MODULE_FILE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODULE_FILE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODULE_FILE_FIELD
             )]
        public string MODULE_FILE
        {
            set { _form_name = value; }
            get { return _form_name; }
        }


        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _modify_file = "-1";
        [ForeignField("MODIFY_FILE"
            , AliasName = "MODIFY_FILE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "MODIFY_FILE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.MODIFY_FILE_FIELD
             )]
        public string MODIFY_FILE
        {
            set { _modify_file = value; }
            get { return _modify_file; }
        }

        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private string _pic_name = "-1";
        [ForeignField("PICTURE_NAME"
            , AliasName = "PICTURE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PICTURE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
            , ForeignColumnName = "PICTURE_NAME"
             )]
        public string PICTURE_NAME
        {
            set { _pic_name = value; }
            get { return _pic_name; }
        }

        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private int _is_group;
        [ForeignField("IS_GROUP"
            , AliasName = "IS_GROUP"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_GROUP"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.IS_GROUP_FIELD
             )]
        public int IS_GROUP
        {
            set { _is_group = value; }
            get { return _is_group; }
        }

        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private int _is_available;
        [ForeignField("IS_AVAILABLE"
            , AliasName = "IS_AVAILABLE"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_AVAILABLE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
           , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
           , ForeignColumnName = SYS_WEB_MODULE.IS_AVAILABLE_FIELD
             )]
        public int IS_AVAILABLE
        {
            set { _is_available = value; }
            get { return _is_available; }
        }


        /// <summary>
        /// The PARENT_CODE Field of SYS_MODULE Table
        /// </summary>
        private decimal _sort_no;
        [ForeignField("SORT_NO"
            , AliasName = "SORT_NO"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SORT_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 5
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = SYS_WEB_MODULE.TABLE_NAME
            , ForeignTableAliasName = SYS_WEB_MODULE.TABLE_NAME
            , ForeignColumnName = SYS_WEB_MODULE.SORT_NO_FIELD
             )]
        public decimal SORT_NO
        {
            set { _sort_no = value; }
            get { return _sort_no; }
        }

        /// <summary>
        /// The CREATE_BY Field of SYS_PERM Table
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
        /// The CREATE_TIME Field of SYS_PERM Table
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
        /// The UPDATE_BY Field of SYS_PERM Table
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
        /// The UPDATE_TIME Field of SYS_PERM Table
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
        /// SYS_PERM Table 
        /// </summary>
        public const string TABLE_NAME = "SYS_PERM";
        public const String CHECK_CODE_FIELD = "CHECK_CODE";
        public const String PERM_ID_FIELD = "PERM_ID";
        public const String ROLE_NO_FIELD = "ROLE_NO";
        public const String FUNCTION_ID_FIELD = "FUNCTION_ID";
        public const String CREATE_BY_FIELD = "CREATE_BY";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_BY_FIELD = "UPDATE_BY";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}