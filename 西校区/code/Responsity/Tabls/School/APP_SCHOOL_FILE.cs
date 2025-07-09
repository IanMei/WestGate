using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_SCHOOL_FILE Table
    /// </summary>
    [Serializable]
    [DataTable("APP_SCHOOL_FILE", ResourceKey = "APP_SCHOOL_FILE")]
    public class APP_SCHOOL_FILE : BaseObject
    {
        public APP_SCHOOL_FILE()
        {
        }
        public APP_SCHOOL_FILE(DealModel initModel) : base(initModel)
        {
        }
        public static APP_SCHOOL_FILE Convert(BaseObject from)
        {
            return (APP_SCHOOL_FILE)from;
        }
        /// <summary>
        /// The FILE_ID Field of APP_SCHOOL_FILE Table
        /// </summary>
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
            , ResourceKey = "FILE_ID"
            , GroupFun = "MAX"
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal FILE_ID
        {
            set;
            get;
        }
        /// <summary>
        /// The FILE_TYPE Field of APP_SCHOOL_FILE Table
        /// </summary>
        [DataField("FILE_TYPE"
            , AliasName = "FILE_TYPE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "FILE_TYPE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string FILE_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// The SCHOOL_NO Field of APP_AGENT Table
        /// </summary>
        [ForeignKeyField("SCHOOL_NO"
            , AliasName = "SCHOOL_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "SCHOOL_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = APP_SCHOOL.TABLE_NAME
            , ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
            , ForeignColumnName = APP_SCHOOL.SCHOOL_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
        public string SCHOOL_NO
        {
            get; set;
        }
        [ForeignField("SCHOOL_NAME"
            , AliasName = "SCHOOL_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "SCHOOL_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 30
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = APP_SCHOOL.TABLE_NAME
            , ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
            , ForeignColumnName = APP_SCHOOL.SCHOOL_NAME_FIELD
             )]
        public string SCHOOL_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// The TITLE Field of APP_SCHOOL_FILE Table
        /// </summary>
        [DataField("TITLE"
            , AliasName = "TITLE"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , ResourceKey = "TITLE"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string TITLE
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
        /// The VIDEO_URL Field of APP_SCHOOL_FILE Table
        /// </summary>
        [DataField("VIDEO_URL"
            , AliasName = "VIDEO_URL"
            , DataType = DbType.String
            , IsNullable = true
            , Size = 200
            , Width = 100
            , ResourceKey = "VIDEO_URL"
            , GroupFun = "MAX"
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string VIDEO_URL
        {
            set;
            get;
        }
        /// <summary>
        /// The REMARK Field of APP_SCHOOL_FILE Table
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
        /// The CREATE_TIME Field of APP_SCHOOL_FILE Table
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
        /// The UPDATE_TIME Field of APP_SCHOOL_FILE Table
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
        /// APP_SCHOOL_FILE Table 
        /// </summary>
        public const string TABLE_NAME = "APP_SCHOOL_FILE";
        public const String FILE_ID_FIELD = "FILE_ID";
        public const String FILE_TYPE_FIELD = "FILE_TYPE";
        public const String SCHOOL_NO_FIELD = "SCHOOL_NO";
        public const String TITLE_FIELD = "TITLE";
        public const String IMAGE_ID_FIELD = "IMAGE_ID";
        public const String VIDEO_URL_FIELD = "VIDEO_URL";
        public const String REMARK_FIELD = "REMARK";
        public const String CREATE_TIME_FIELD = "CREATE_TIME";
        public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
    }
}