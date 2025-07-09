using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_SETUP Table
    /// </summary>
    [Serializable]
    [DataTable("APP_SETUP", ResourceKey = "APP_SETUP")]
    public class APP_SETUP : BaseObject
    {
        public APP_SETUP()
        {
        }
        public APP_SETUP(DealModel initModel) : base(initModel)
        {
        }
        public static APP_SETUP Convert(BaseObject from)
        {
            return (APP_SETUP)from;
        }
        /// <summary>
        /// The SETUP_ID Field of APP_SETUP Table
        /// </summary>
        private decimal _setup_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.SETUP_ID = value;
            }
            get { return SETUP_ID; }
        }

        [RecordIDField("SETUP_ID"
            , AliasName = "SETUP_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "SETUP_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal SETUP_ID
        {
            set { _setup_id = value; }
            get { return _setup_id; }
        }
        /// <summary>
        /// The SETUP_NAME Field of APP_SETUP Table
        /// </summary>
        private string _setup_name;
        [DataField("SETUP_NAME"
            , AliasName = "SETUP_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SETUP_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 3
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SETUP_NAME
        {
            set { _setup_name = value; }
            get { return _setup_name; }
        }
        /// <summary>
        /// The KEYWORDS Field of APP_SETUP Table
        /// </summary>
        private string _keywords;
        [DataField("KEYWORDS"
            , AliasName = "KEYWORDS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "KEYWORDS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string KEYWORDS
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// The DESCRIPTION Field of APP_SETUP Table
        /// </summary>
        private string _description;
        [DataField("DESCRIPTION"
            , AliasName = "DESCRIPTION"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DESCRIPTION"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// The LINK_MAN Field of APP_SETUP Table
        /// </summary>
        private string _link_man;
        [DataField("LINK_MAN"
            , AliasName = "LINK_MAN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LINK_MAN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LINK_MAN
        {
            set { _link_man = value; }
            get { return _link_man; }
        }
        /// <summary>
        /// The LINK_TEL Field of APP_SETUP Table
        /// </summary>
        private string _link_tel;
        [DataField("LINK_TEL"
            , AliasName = "LINK_TEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "LINK_TEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string LINK_TEL
        {
            set { _link_tel = value; }
            get { return _link_tel; }
        }

        /// <summary>
        /// The EMAIL Field of APP_SETUP Table
        /// </summary>
        private string email;
        [DataField("EMAIL"
            , AliasName = "EMAIL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "EMAIL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EMAIL
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// The IMAGE_ID Field of APP_BANNER Table
        /// </summary>
        private decimal _image_id;
        [ForeignKeyField("IMAGE_ID"
             , AliasName = "IMAGE_ID"
             , DataType = DbType.Decimal
             , IsNullable = false
             , Size = 20
             , Width = 100
             , DisplayInCondition = true
             , DisplayInMaintain = true
             , DisplayInDialog = false
             , ResourceKey = "IMAGE_ID"
             , GroupFun = "MAX"
             , AllowEdit = false
             , Frozen = false
             , SelectSequence = 30
             , DialogSequence = -1
             , IsInsertField = true
             , IsUpdateField = true
             , ForeignTableName = APP_TEMP.TABLE_NAME
             , ForeignTableAliasName = APP_TEMP.TABLE_NAME
             , ForeignColumnName = APP_TEMP.FILE_ID_FIELD
             , IsMainTableKey = true
             , ForeignTableJoinType = TableJoinType.LeftOuterJoin
             , TableJoinSequence = 0
              )]
        public decimal IMAGE_ID
        {
            set { _image_id = value; }
            get { return _image_id; }
        }

        [ForeignField("FILE_LOGO"
            , AliasName = "FILE_LOGO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FILE_LOGO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_TEMP.TABLE_NAME
            , ForeignTableAliasName = APP_TEMP.TABLE_NAME
            , ForeignColumnName = APP_TEMP.FILE_PATH_FIELD
             )]
        public string FILE_LOGO
        {
            set;
            get;
        }
        /// <summary>
        /// The IMAGE_ID1 Field of APP_SETUP Table
        /// </summary>
        private decimal _image_id1;
        [DataField("IMAGE_ID1"
            , AliasName = "IMAGE_ID1"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IMAGE_ID1"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 21
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal IMAGE_ID1
        {
            set { _image_id1 = value; }
            get { return _image_id1; }
        }
        /// <summary>
        /// The SERVICE_TEL Field of APP_SETUP Table
        /// </summary>
        private string _service_tel;
        [DataField("SERVICE_TEL"
            , AliasName = "SERVICE_TEL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SERVICE_TEL"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 24
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SERVICE_TEL
        {
            set { _service_tel = value; }
            get { return _service_tel; }
        }
        /// <summary>
        /// The COMPANY Field of APP_SETUP Table
        /// </summary>
        private string _company;
        [DataField("COMPANY"
            , AliasName = "COMPANY"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COMPANY"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 27
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COMPANY
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
		/// The IMAGE_ID Field of APP_BANNER Table
		/// </summary>
        [ForeignKeyField("QR_ID"
             , AliasName = "QR_ID"
             , DataType = DbType.Decimal
             , IsNullable = false
             , Size = 20
             , Width = 100
             , DisplayInCondition = true
             , DisplayInMaintain = true
             , DisplayInDialog = false
             , ResourceKey = "QR_ID"
             , GroupFun = "MAX"
             , AllowEdit = false
             , Frozen = false
             , SelectSequence = 30
             , DialogSequence = -1
             , IsInsertField = true
             , IsUpdateField = true
             , ForeignTableName = APP_TEMP.TABLE_NAME
             , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_QR"
             , ForeignColumnName = APP_TEMP.FILE_ID_FIELD
             , IsMainTableKey = true
             , ForeignTableJoinType = TableJoinType.LeftOuterJoin
             , TableJoinSequence = 0
              )]
        public decimal QR_ID
        {
            get;set;
        }

        [ForeignField("FILE_QR"
            , AliasName = "FILE_QR"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "FILE_QR"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_TEMP.TABLE_NAME
            , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_QR"
            , ForeignColumnName = APP_TEMP.FILE_PATH_FIELD
             )]
        public string FILE_QR
        {
            set;
            get;
        }
        /// <summary>
        /// The COPYRIGHT Field of APP_SETUP Table
        /// </summary>
        private string _copyright;
        [DataField("COPYRIGHT"
            , AliasName = "COPYRIGHT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "COPYRIGHT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string COPYRIGHT
        {
            set { _copyright = value; }
            get { return _copyright; }
        }
        /// <summary>
        /// The RECORD Field of APP_SETUP Table
        /// </summary>
        private string _record;
        [DataField("RECORD"
            , AliasName = "RECORD"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "RECORD"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string RECORD
        {
            set { _record = value; }
            get { return _record; }
        }
        /// <summary>
        /// The REMARK Field of APP_SETUP Table
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
            , SelectSequence = 39
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
        /// The IS_OPEN_QUESTIONNAIRE Field of APP_SETUP Table
        /// </summary>
        [DataField("IS_OPEN_QUESTIONNAIRE"
            , AliasName = "IS_OPEN_QUESTIONNAIRE"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , ResourceKey = "IS_OPEN_QUESTIONNAIRE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 IS_OPEN_QUESTIONNAIRE
        {
            set;
            get;
        }
        /// <summary>
        /// The QUESTIONNAIRE_TITLE Field of APP_SETUP Table
        /// </summary>
        [DataField("QUESTIONNAIRE_TITLE"
            , AliasName = "QUESTIONNAIRE_TITLE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , ResourceKey = "QUESTIONNAIRE_TITLE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string QUESTIONNAIRE_TITLE
        {
            set;
            get;
        }
        /// <summary>
        /// The QUESTIONNAIRE_CONTENT Field of APP_SETUP Table
        /// </summary>
        [DataField("QUESTIONNAIRE_CONTENT"
            , AliasName = "QUESTIONNAIRE_CONTENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 8
            , Width = 100
            , ResourceKey = "QUESTIONNAIRE_CONTENT"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string QUESTIONNAIRE_CONTENT
        {
            set;
            get;
        }

        /// <summary>
		/// The QUESTIONNAIRE_END Field of APP_SETUP Table
		/// </summary>
		[DataField("QUESTIONNAIRE_END"
            , AliasName = "QUESTIONNAIRE_END"
            , DataType = DbType.DateTime
            , IsNullable = true
            , Size = 20
            , Width = 100
            , ResourceKey = "QUESTIONNAIRE_END"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public DateTime? QUESTIONNAIRE_END
        {
            set;
            get;
        }

        /// <summary>
        /// The CREATE_TIME Field of APP_SETUP Table
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
        /// The UPDATE_TIME Field of APP_SETUP Table
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
        /// The HOT_SEARCH Field of APP_SETUP Table
        /// </summary>
        private string _hot_search;
        [DataField("HOT_SEARCH"
            , AliasName = "HOT_SEARCH"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HOT_SEARCH"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HOT_SEARCH
        {
            set { _hot_search = value; }
            get { return _hot_search; }
        }


        /// <summary>
        /// The SERVICE_CLAUSE Field of APP_SETUP Table
        /// </summary>
        private string service_clause;
        [DataField("SERVICE_CLAUSE"
            , AliasName = "SERVICE_CLAUSE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 100
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SERVICE_CLAUSE"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SERVICE_CLAUSE
        {
            set { service_clause = value; }
            get { return service_clause; }
        }
        /// <summary>
        /// APP_SETUP Table 
        /// </summary>
        public const string TABLE_NAME = "APP_SETUP";
        public const String SETUP_ID_FIELD = "SETUP_ID";
        public const String SETUP_NAME_FIELD = "SETUP_NAME";
        public const String KEYWORDS_FIELD = "KEYWORDS";
        public const String DESCRIPTION_FIELD = "DESCRIPTION";
        public const String LINK_MAN_FIELD = "LINK_MAN";
        public const String LINK_TEL_FIELD = "LINK_TEL";
        public const String IMAGE_ID_FIELD = "IMAGE_ID";
        public const String IMAGE_ID1_FIELD = "IMAGE_ID1";
        public const String SERVICE_TEL_FIELD = "SERVICE_TEL";
        public const String COMPANY_FIELD = "COMPANY";
        public const String QR_ID_FIELD = "QR_ID";
        public const String COPYRIGHT_FIELD = "COPYRIGHT";
        public const String RECORD_FIELD = "RECORD";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
        public const String HOT_SEARCH_FIELD = "HOT_SEARCH";
    }
}