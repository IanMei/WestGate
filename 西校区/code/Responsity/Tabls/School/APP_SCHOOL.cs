using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_SCHOOL Table
    /// </summary>
    [Serializable]
    [DataTable("APP_SCHOOL", ResourceKey = "APP_SCHOOL")]
    public class APP_SCHOOL : BaseObject
    {
        public APP_SCHOOL()
        {
        }
        public APP_SCHOOL(DealModel initModel) : base(initModel)
        {
        }
        public static APP_SCHOOL Convert(BaseObject from)
        {
            return (APP_SCHOOL)from;
        }
        /// <summary>
        /// The SCHOOL_ID Field of APP_SCHOOL Table
        /// </summary>
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.SCHOOL_ID = value;
            }
            get { return SCHOOL_ID; }
        }

        [RecordIDField("SCHOOL_ID"
            , AliasName = "SCHOOL_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , ResourceKey = "SCHOOL_ID"
            , GroupFun = "MAX"
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal SCHOOL_ID
        {
            set;
            get;
        }
        /// <summary>
        /// The SCHOOL_NO Field of APP_SCHOOL Table
        /// </summary>
        [KeyField("SCHOOL_NO"
            , AliasName = "SCHOOL_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "SCHOOL_NO"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string SCHOOL_NO
        {
            set;
            get;
        }
        /// <summary>
        /// The SCHOOL_NAME Field of APP_SCHOOL Table
        /// </summary>
        [DataField("SCHOOL_NAME"
            , AliasName = "SCHOOL_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "SCHOOL_NAME"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string SCHOOL_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// The EN_NAME Field of APP_SCHOOL Table
        /// </summary>
        [DataField("EN_NAME"
            , AliasName = "EN_NAME"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , ResourceKey = "EN_NAME"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string EN_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// The NICK_NAME Field of APP_SCHOOL Table
        /// </summary>
        [DataField("NICK_NAME"
            , AliasName = "NICK_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "NICK_NAME"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string NICK_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// The MOBILE Field of APP_SCHOOL Table
        /// </summary>
        [DataField("MOBILE"
            , AliasName = "MOBILE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "MOBILE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string MOBILE
        {
            set;
            get;
        }
        /// <summary>
        /// The USER_PWD Field of APP_SCHOOL Table
        /// </summary>
        [DataField("USER_PWD"
            , AliasName = "USER_PWD"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 120
            , Width = 100
            , ResourceKey = "USER_PWD"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string USER_PWD
        {
            set;
            get;
        }
        /// <summary>
        /// The REFERRER Field of APP_SCHOOL Table
        /// </summary>
        [DataField("REFERRER"
            , AliasName = "REFERRER"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 20
            , Width = 100
            , ResourceKey = "REFERRER"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REFERRER
        {
            set;
            get;
        }
        /// <summary>
        /// The IMAGE_ID Field of APP_SCHOOL Table
        /// </summary>
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
            set;
            get;
        }

        [ForeignField("FILE_PATH"
           , AliasName = "FILE_PATH"
           , DataType = DbType.String
           , IsNullable = false
           , Size = 20
           , Width = 100
           , DisplayInCondition = false
           , DisplayInMaintain = false
           , DisplayInDialog = false
           , ResourceKey = "FILE_PATH"
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
        public string FILE_PATH
        {
            set;
            get;
        }

        /// <summary>
        /// The HEAD_ID Field of APP_SCHOOL Table
        /// </summary>
        [ForeignKeyField("HEAD_ID"
            , AliasName = "HEAD_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "HEAD_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_TEMP.TABLE_NAME
            , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_HEAD"
            , ForeignColumnName = APP_TEMP.FILE_ID_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
        public decimal HEAD_ID
        {
            set;
            get;
        }

        [ForeignField("HEAD_PATH"
          , AliasName = "HEAD_PATH"
          , DataType = DbType.String
          , IsNullable = false
          , Size = 20
          , Width = 100
          , DisplayInCondition = false
          , DisplayInMaintain = false
          , DisplayInDialog = false
          , ResourceKey = "HEAD_PATH"
          , GroupFun = "MAX"
          , AllowEdit = false
          , Frozen = false
          , SelectSequence = 30
          , DialogSequence = -1
          , IsInsertField = false
          , IsUpdateField = false
          , ForeignTableName = APP_TEMP.TABLE_NAME
          , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_HEAD"
          , ForeignColumnName = APP_TEMP.FILE_PATH_FIELD
           )]
        public string HEAD_PATH
        {
            set;
            get;
        }


        /// <summary>
        /// The FILE_ID Field of APP_SCHOOL Table
        /// </summary>
        [ForeignKeyField("FILE_ID"
            , AliasName = "FILE_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "FILE_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_TEMP.TABLE_NAME
            , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_FILE"
            , ForeignColumnName = APP_TEMP.FILE_ID_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
        public decimal FILE_ID
        {
            set;
            get;
        }

        [ForeignField("CERT_PATH"
          , AliasName = "CERT_PATH"
          , DataType = DbType.String
          , IsNullable = false
          , Size = 20
          , Width = 100
          , DisplayInCondition = false
          , DisplayInMaintain = false
          , DisplayInDialog = false
          , ResourceKey = "CERT_PATH"
          , GroupFun = "MAX"
          , AllowEdit = false
          , Frozen = false
          , SelectSequence = 30
          , DialogSequence = -1
          , IsInsertField = false
          , IsUpdateField = false
          , ForeignTableName = APP_TEMP.TABLE_NAME
          , ForeignTableAliasName = APP_TEMP.TABLE_NAME + "_FILE"
          , ForeignColumnName = APP_TEMP.FILE_PATH_FIELD
           )]
        public string CERT_PATH
        {
            set;
            get;
        }
        /// <summary>
        /// The PROVINCE_NO Field of APP_AGENT Table
        /// </summary>
        private string _province_no;
        [ForeignKeyField("PROVINCE_NO"
            , AliasName = "PROVINCE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = BASE_PROVINCE.TABLE_NAME
            , ForeignTableAliasName = BASE_PROVINCE.TABLE_NAME
            , ForeignColumnName = BASE_PROVINCE.PROVINCE_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
        public string PROVINCE_NO
        {
            set { _province_no = value; }
            get { return _province_no; }
        }
        [ForeignField("PROVINCE_NAME"
            , AliasName = "PROVINCE_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_PROVINCE.TABLE_NAME
            , ForeignTableAliasName = BASE_PROVINCE.TABLE_NAME
            , ForeignColumnName = BASE_PROVINCE.PROVINCE_NAME_FIELD
             )]
        public string PROVINCE_NAME
        {
            set;
            get;
        }
        [ExpressionField("(select MAX(a.Pinyin) from APP_CITY a where a.ID = BASE_PROVINCE.PROVINCE_NO)"
          , AliasName = "PROVINCE_PINYIN"
          , DataType = DbType.String
          , IsNullable = false
          , Size = 10
          , Width = 100
          , DisplayInCondition = true
          , DisplayInMaintain = true
          , DisplayInDialog = false
          , ResourceKey = "PROVINCE_PINYIN"
          , GroupFun = "MAX"
          , AllowEdit = false
          , Frozen = false
          , SelectSequence = 20
          , DialogSequence = 0
          , IsInsertField = false
          , IsUpdateField = false
           )]
        public string PROVINCE_PINYIN
        {
            get; set;
        }
        /// <summary>
        /// The CITY_NO Field of APP_AGENT Table
        /// </summary>
        private string _city_no;
        [ForeignKeyField("CITY_NO"
            , AliasName = "CITY_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CITY_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = BASE_CITY.TABLE_NAME
            , ForeignTableAliasName = BASE_CITY.TABLE_NAME
            , ForeignColumnName = BASE_CITY.CITY_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 1
             )]
        public string CITY_NO
        {
            set { _city_no = value; }
            get { return _city_no; }
        }
        [ForeignField("CITY_NAME"
            , AliasName = "CITY_NAME"    
            , DataType = DbType.String      
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CITY_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 33
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_CITY.TABLE_NAME
            , ForeignTableAliasName = BASE_CITY.TABLE_NAME
            , ForeignColumnName = BASE_CITY.CITY_NAME_FIELD
             )]
        public string CITY_NAME
        {
            set;
            get;
        }


        [ExpressionField("(select MAX(a.Pinyin) from APP_CITY a where a.ID = BASE_CITY.CITY_NO)"
            , AliasName = "CITY_PINYIN"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CITY_PINYIN"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 20
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public string CITY_PINYIN
        {
            get; set;
        }
        /// <summary>
        /// The DISYRICT_NO Field of APP_AGENT Table
        /// </summary>
        private string _disyrict_no;
        [ForeignKeyField("DISYRICT_NO"
            , AliasName = "DISYRICT_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "DISYRICT_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = BASE_DISYRICT.TABLE_NAME
            , ForeignTableAliasName = BASE_DISYRICT.TABLE_NAME
            , ForeignColumnName = BASE_DISYRICT.DISYRICT_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 2
             )]
        public string DISYRICT_NO
        {
            set { _disyrict_no = value; }
            get { return _disyrict_no; }
        }
        [ForeignField("DISYRICT_NAME"
            , AliasName = "DISYRICT_NAME"    //����ֶ�
            , DataType = DbType.String      //��������
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "DISYRICT_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_DISYRICT.TABLE_NAME
            , ForeignTableAliasName = BASE_DISYRICT.TABLE_NAME
            , ForeignColumnName = BASE_DISYRICT.DISYRICT_NAME_FIELD
             )]
        public string DISYRICT_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// The ADDRESS Field of APP_SCHOOL Table
        /// </summary>
        [DataField("ADDRESS"
            , AliasName = "ADDRESS"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , ResourceKey = "ADDRESS"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ADDRESS
        {
            set;
            get;
        }
        /// <summary>
        /// The ADDRESS_EN Field of APP_SCHOOL Table
        /// </summary>
        [DataField("ADDRESS_EN"
            , AliasName = "ADDRESS_EN"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , ResourceKey = "ADDRESS_EN"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string ADDRESS_EN
        {
            set;
            get;
        }
        /// <summary>
        /// The HOME_PAGE Field of APP_SCHOOL Table
        /// </summary>
        [DataField("HOME_PAGE"
            , AliasName = "HOME_PAGE"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , ResourceKey = "HOME_PAGE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string HOME_PAGE
        {
            set;
            get;
        }

        /// <summary>
        /// The HOME_PAGE Field of APP_SCHOOL Table
        /// </summary>
        [ForeignKeyField("ESPECIALLY_COURSE"
                , AliasName = "ESPECIALLY_COURSE"
                , DataType = DbType.String
                , IsNullable = false
                , Size = 20
                , Width = 100
                , DisplayInCondition = true
                , DisplayInMaintain = true
                , DisplayInDialog = false
                , ResourceKey = "ESPECIALLY_COURSE"
                , GroupFun = "MAX"
                , AllowEdit = false
                , Frozen = false
                , SelectSequence = 30
                , DialogSequence = -1
                , IsInsertField = true
                , IsUpdateField = true
                , ForeignTableName = BASE_TYPE.TABLE_NAME
                , ForeignTableAliasName = BASE_TYPE.TABLE_NAME + "_05"
                , ForeignColumnName = BASE_TYPE.TYPE_NO_FIELD
                , IsMainTableKey = true
                , ForeignTableJoinType = TableJoinType.LeftOuterJoin
                , TableJoinSequence = 0
                 )]
        public string ESPECIALLY_COURSE
        {
            set;
            get;
        }
        [ForeignField("SYSTEM_COURSE"
           , AliasName = "SYSTEM_COURSE"
           , DataType = DbType.String
           , IsNullable = false
           , Size = 20
           , Width = 100
           , DisplayInCondition = false
           , DisplayInMaintain = false
           , DisplayInDialog = false
           , ResourceKey = "SYSTEM_COURSE"
           , GroupFun = "MAX"
           , AllowEdit = false
           , Frozen = false
           , SelectSequence = 36
           , DialogSequence = -1
           , IsInsertField = false
           , IsUpdateField = false
           , ForeignTableName = BASE_TYPE.TABLE_NAME
           , ForeignTableAliasName = BASE_TYPE.TABLE_NAME + "_05"
           , ForeignColumnName = BASE_TYPE.TYPE_NAME_FIELD
            )]
        public string SYSTEM_COURSE
        {
            set;
            get;
        }
        /// <summary>
        /// The CONTENT Field of APP_SCHOOL Table
        /// </summary>
        [DataField("CONTENT"
            , AliasName = "CONTENT"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 8
            , Width = 100
            , ResourceKey = "CONTENT"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CONTENT
        {
            set;
            get;
        }
        /// <summary>
        /// The STU_QTY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("STU_QTY"
            , AliasName = "STU_QTY"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , ResourceKey = "STU_QTY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32? STU_QTY
        {
            set;
            get;
        }
        /// <summary>
        /// The RECRUIT_QTY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("RECRUIT_QTY"
            , AliasName = "RECRUIT_QTY"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , ResourceKey = "RECRUIT_QTY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32? RECRUIT_QTY
        {
            set;
            get;
        }
        /// <summary>
        /// The TAS_RATE Field of APP_SCHOOL Table
        /// </summary>
        [DataField("TAS_RATE"
            , AliasName = "TAS_RATE"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "TAS_RATE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? TAS_RATE
        {
            set;
            get;
        }
        /// <summary>
        /// The FT_QTY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("FT_QTY"
            , AliasName = "FT_QTY"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 4
            , Width = 100
            , ResourceKey = "FT_QTY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? FT_QTY
        {
            set;
            get;
        }
        /// <summary>
        /// The TS_RATE Field of APP_SCHOOL Table
        /// </summary>
        [DataField("TS_RATE"
            , AliasName = "TS_RATE"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "TS_RATE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? TS_RATE
        {
            set;
            get;
        }
        /// <summary>
        /// The ENROLL_RATE Field of APP_SCHOOL Table
        /// </summary>
        [DataField("ENROLL_RATE"
            , AliasName = "ENROLL_RATE"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "ENROLL_RATE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? ENROLL_RATE
        {
            set;
            get;
        }
        /// <summary>
        /// The ENROLL_QTY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("ENROLL_QTY"
            , AliasName = "ENROLL_QTY"
            , DataType = DbType.Int32
            , IsNullable = true
            , Size = 4
            , Width = 100
            , ResourceKey = "ENROLL_QTY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32? ENROLL_QTY
        {
            set;
            get;
        }
        /// <summary>
        /// The TUITION_CNY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("TUITION_CNY"
            , AliasName = "TUITION_CNY"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "TUITION_CNY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? TUITION_CNY
        {
            set;
            get;
        }
        /// <summary>
        /// The TUITION_USD Field of APP_SCHOOL Table
        /// </summary>
        [DataField("TUITION_USD"
            , AliasName = "TUITION_USD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "TUITION_USD"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? TUITION_USD
        {
            set;
            get;
        }
        /// <summary>
        /// The STAY_CNY Field of APP_SCHOOL Table
        /// </summary>
        [DataField("STAY_CNY"
            , AliasName = "STAY_CNY"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "STAY_CNY"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? STAY_CNY
        {
            set;
            get;
        }
        /// <summary>
        /// The STAY_USD Field of APP_SCHOOL Table
        /// </summary>
        [DataField("STAY_USD"
            , AliasName = "STAY_USD"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "STAY_USD"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? STAY_USD
        {
            set;
            get;
        }
        /// <summary>
        /// The CLIENT_ID Field of APP_SCHOOL Table
        /// </summary>
        [DataField("CLIENT_ID"
            , AliasName = "CLIENT_ID"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 50
            , Width = 100
            , ResourceKey = "CLIENT_ID"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CLIENT_ID
        {
            set;
            get;
        }
        /// <summary>
        /// The POINT Field of APP_SCHOOL Table
        /// </summary>
        [DataField("POINT"
            , AliasName = "POINT"
            , DataType = DbType.Decimal
            , IsNullable = true
            , Size = 10
            , Width = 100
            , ResourceKey = "POINT"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public decimal? POINT
        {
            set;
            get;
        }
        /// <summary>
        /// The RECRUIT_TYPE Field of APP_SCHOOL Table
        /// </summary>
        [ForeignKeyField("RECRUIT_TYPE"
               , AliasName = "RECRUIT_TYPE"
               , DataType = DbType.String
               , IsNullable = false
               , Size = 20
               , Width = 100
               , DisplayInCondition = true
               , DisplayInMaintain = true
               , DisplayInDialog = false
               , ResourceKey = "RECRUIT_TYPE"
               , GroupFun = "MAX"
               , AllowEdit = false
               , Frozen = false
               , SelectSequence = 30
               , DialogSequence = -1
               , IsInsertField = true
               , IsUpdateField = true
               , ForeignTableName = BASE_TYPE.TABLE_NAME
               , ForeignTableAliasName = BASE_TYPE.TABLE_NAME + "_01"
               , ForeignColumnName = BASE_TYPE.TYPE_NO_FIELD
               , IsMainTableKey = true
               , ForeignTableJoinType = TableJoinType.LeftOuterJoin
               , TableJoinSequence = 4
                )]
        public string RECRUIT_TYPE
        {
            set;
            get;
        }

        [ForeignField("RECRUIT_NAME"
            , AliasName = "RECRUIT_NAME"
            , DataType = DbType.String     
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "RECRUIT_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 36
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_TYPE.TABLE_NAME
            , ForeignTableAliasName = BASE_TYPE.TABLE_NAME + "_01"
            , ForeignColumnName = BASE_TYPE.TYPE_NAME_FIELD
             )]
        public string RECRUIT_NAME 
        {
            set;
            get; 
        }
        [ForeignField("RECRUIT_EN"
           , AliasName = "RECRUIT_EN"
           , DataType = DbType.String
           , IsNullable = false
           , Size = 20
           , Width = 100
           , DisplayInCondition = false
           , DisplayInMaintain = false
           , DisplayInDialog = false
           , ResourceKey = "RECRUIT_EN"
           , GroupFun = "MAX"
           , AllowEdit = false
           , Frozen = false
           , SelectSequence = 36
           , DialogSequence = -1
           , IsInsertField = false
           , IsUpdateField = false
           , ForeignTableName = BASE_TYPE.TABLE_NAME
           , ForeignTableAliasName = BASE_TYPE.TABLE_NAME + "_01"
           , ForeignColumnName = BASE_TYPE.REMARK_FIELD
            )]
        public string RECRUIT_EN
        {
            set;
            get;
        }
        /// <summary>
        /// The IS_ENABLED Field of APP_SCHOOL Table
        /// </summary>
        [DataField("IS_ENABLED"
            , AliasName = "IS_ENABLED"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 4
            , Width = 100
            , ResourceKey = "IS_ENABLED"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 IS_ENABLED
        {
            set;
            get;
        }

        /// <summary>
        /// The IS_RECOMMEND Field of APP_SCHOOL Table
        /// </summary>
        [DataField("IS_RECOMMEND"
            , AliasName = "IS_RECOMMEND"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 4
            , Width = 100
            , ResourceKey = "IS_RECOMMEND"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 IS_RECOMMEND
        {
            set;
            get;
        }
        /// <summary>
        /// The REMARK Field of APP_SCHOOL Table
        /// </summary>
        [DataField("REMARK"
            , AliasName = "REMARK"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , ResourceKey = "REMARK"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string REMARK
        {
            set;
            get;
        }
        /// <summary>
        /// The CREATE_TIME Field of APP_SCHOOL Table
        /// </summary>
        [DataField("CREATE_TIME"
            , AliasName = "CREATE_TIME"
            , DataType = DbType.DateTime
            , IsNullable = false
            , Size = 20
            , ResourceKey = "CREATE_TIME"
            , GroupFun = "MAX"
            , SelectSequence = 102
            , IsInsertField = true
            , IsUpdateField = false
            , DefaultValue = "SysDate"
             )]
        public DateTime CREATE_TIME
        {
            set;
            get;
        }
        /// <summary>
        /// The UPDATE_TIME Field of APP_SCHOOL Table
        /// </summary>
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
            set;
            get;
        }
        /// <summary>
        /// APP_SCHOOL Table 
        /// </summary>
        public const string TABLE_NAME = "APP_SCHOOL";
        public const String SCHOOL_ID_FIELD = "SCHOOL_ID";
        public const String SCHOOL_NO_FIELD = "SCHOOL_NO";
        public const String SCHOOL_NAME_FIELD = "SCHOOL_NAME";
        public const String EN_NAME_FIELD = "EN_NAME";
        public const String MOBILE_FIELD = "MOBILE";
        public const String USER_PWD_FIELD = "USER_PWD";
        public const String REFERRER_FIELD = "REFERRER";
        public const String IMAGE_ID_FIELD = "IMAGE_ID";
        public const String PROVINCE_NO_FIELD = "PROVINCE_NO";
        public const String CITY_NO_FIELD = "CITY_NO";
        public const String DISYRICT_NO_FIELD = "DISYRICT_NO";
        public const String ADDRESS_FIELD = "ADDRESS";
        public const String ADDRESS_EN_FIELD = "ADDRESS_EN";
        public const String HOME_PAGE_FIELD = "HOME_PAGE";
        public const String CONTENT_FIELD = "CONTENT";
        public const String STU_QTY_FIELD = "STU_QTY";
        public const String RECRUIT_QTY_FIELD = "RECRUIT_QTY";
        public const String TAS_RATE_FIELD = "TAS_RATE";
        public const String FT_QTY_FIELD = "FT_QTY";
        public const String TS_RATE_FIELD = "TS_RATE";
        public const String ENROLL_RATE_FIELD = "ENROLL_RATE";
        public const String ENROLL_QTY_FIELD = "ENROLL_QTY";
        public const String TUITION_CNY_FIELD = "TUITION_CNY";
        public const String TUITION_USD_FIELD = "TUITION_USD";
        public const String STAY_CNY_FIELD = "STAY_CNY";
        public const String STAY_USD_FIELD = "STAY_USD";
        public const String CLIENT_ID_FIELD = "CLIENT_ID";
        public const String POINT_FIELD = "POINT";
        public const String RECRUIT_TYPE_FIELD = "RECRUIT_TYPE";
        public const String IS_ENABLED_FIELD = "IS_ENABLED";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}