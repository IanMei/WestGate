using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_INTERVIEW Table
	/// </summary>
	[Serializable]
	[DataTable("APP_INTERVIEW",ResourceKey = "APP_INTERVIEW")]
	public class APP_INTERVIEW: BaseObject
	{
		public APP_INTERVIEW()
		{
		}
		public APP_INTERVIEW(DealModel initModel):base(initModel)
		{
		}
		public static APP_INTERVIEW Convert(BaseObject from)
		{
			return (APP_INTERVIEW)from;
		}
		/// <summary>
		/// The INTERVIEW_ID Field of APP_INTERVIEW Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.INTERVIEW_ID = value; }
			get { return INTERVIEW_ID; }
		}

		[RecordIDField("INTERVIEW_ID"
			, AliasName = "INTERVIEW_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "INTERVIEW_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal INTERVIEW_ID
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

		[ForeignField("EN_NAME"
			, AliasName = "EN_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "EN_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.EN_NAME_FIELD
			 )]
		public string EN_NAME
		{
			set;
			get;
		}

		[ForeignField("ADDRESS"
			, AliasName = "ADDRESS"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ADDRESS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.ADDRESS_FIELD
			 )]
		public string ADDRESS
		{
			set;
			get;
		}

		[ForeignField("RECRUIT_QTY"
			, AliasName = "RECRUIT_QTY"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "RECRUIT_QTY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.RECRUIT_QTY_FIELD
			 )]
		public int RECRUIT_QTY
		{
			set;
			get;
		}


		[ForeignField("TUITION_CNY"
			, AliasName = "TUITION_CNY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "TUITION_CNY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.TUITION_CNY_FIELD
			 )]
		public decimal TUITION_CNY
		{
			set;
			get;
		}

		[ForeignField("SCHOOL_ID"
			, AliasName = "SCHOOL_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SCHOOL_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.SCHOOL_ID_FIELD
			 )]
		public decimal SCHOOL_ID
		{
			set;
			get;
		}

		[ForeignField("TUITION_USD"
			, AliasName = "TUITION_USD"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "TUITION_USD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.TUITION_USD_FIELD
			 )]
		public decimal TUITION_USD
		{
			set;
			get;
		}


		[ForeignField("STAY_CNY"
			, AliasName = "STAY_CNY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "STAY_CNY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.STAY_CNY_FIELD
			 )]
		public decimal STAY_CNY
		{
			set;
			get;
		}

		[ForeignField("STAY_USD"
			, AliasName = "STAY_USD"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "STAY_USD"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.STAY_USD_FIELD
			 )]
		public decimal STAY_USD
		{
			set;
			get;
		}


		[ForeignField("POINT"
			, AliasName = "POINT"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "POINT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_SCHOOL.TABLE_NAME
			, ForeignTableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignColumnName = APP_SCHOOL.POINT_FIELD
			 )]
		public decimal POINT
		{
			set;
			get;
		}


		/// <summary>
		/// The SCHOOL_NO Field of APP_AGENT Table
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
			, IsInsertField = false
			, IsUpdateField = false
			, TableName = APP_SCHOOL.TABLE_NAME
			, TableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignTableName = BASE_TYPE.TABLE_NAME
			, ForeignTableAliasName = BASE_TYPE.TABLE_NAME
			, ForeignColumnName = BASE_TYPE.TYPE_NO_FIELD
			, IsMainTableKey = true
			, ForeignTableJoinType = TableJoinType.LeftOuterJoin
			, TableJoinSequence = 0
			 )]
		public string RECRUIT_TYPE
		{
			get; set;
		}


		[ForeignField("TYPE_NAME"
			, AliasName = "TYPE_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "TYPE_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = BASE_TYPE.TABLE_NAME
			, ForeignTableAliasName = BASE_TYPE.TABLE_NAME
			, ForeignColumnName = BASE_TYPE.TYPE_NAME_FIELD
			 )]
		public string TYPE_NAME
		{
			set;
			get;
		}




		/// <summary>
		/// The SCHOOL_NO Field of APP_AGENT Table
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
			, IsInsertField = false
			, IsUpdateField = false
			, TableName = APP_SCHOOL.TABLE_NAME
			, TableAliasName = APP_SCHOOL.TABLE_NAME
			, ForeignTableName = APP_TEMP.TABLE_NAME
			, ForeignTableAliasName = APP_TEMP.TABLE_NAME
			, ForeignColumnName = APP_TEMP.FILE_ID_FIELD
			, IsMainTableKey = true
			, ForeignTableJoinType = TableJoinType.LeftOuterJoin
			, TableJoinSequence = 0
			 )]
		public decimal HEAD_ID
		{
			get; set;
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
		/// The TITLE Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
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
		/// The DATE_PUBLISH Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("DATE_PUBLISH"
			, AliasName = "DATE_PUBLISH"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "DATE_PUBLISH"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_PUBLISH
		{
			set;
			get;
		}
		/// <summary>
		/// The SEQ_NO Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("SEQ_NO"
			, AliasName = "SEQ_NO"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "SEQ_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal SEQ_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The SOURCE Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("SOURCE"
			, AliasName = "SOURCE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "SOURCE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE
		{
			set;
			get;
		}
		/// <summary>
		/// The PICTURE_MINI Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("PICTURE_MINI"
			, AliasName = "PICTURE_MINI"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, ResourceKey = "PICTURE_MINI"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 PICTURE_MINI
		{
			set;
			get;
		}
		/// <summary>
		/// The PICTURE_NAME Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("PICTURE_NAME"
			, AliasName = "PICTURE_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, ResourceKey = "PICTURE_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PICTURE_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The KEYLIST Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("KEYLIST"
			, AliasName = "KEYLIST"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "KEYLIST"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string KEYLIST
		{
			set;
			get;
		}
		/// <summary>
		/// The DESCRIPTION Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("DESCRIPTION"
			, AliasName = "DESCRIPTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "DESCRIPTION"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DESCRIPTION
		{
			set;
			get;
		}
		/// <summary>
		/// The CONTENT Field of APP_INTERVIEW Table
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
		/// The READ_TMES Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("READ_TMES"
			, AliasName = "READ_TMES"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "READ_TMES"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal READ_TMES
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_INTERVIEW Table
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
		/// The REMARK Field of APP_INTERVIEW Table
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
		/// The CREATE_TIME Field of APP_INTERVIEW Table
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
		/// The UPDATE_TIME Field of APP_INTERVIEW Table
		/// </summary>
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,ResourceKey = "UPDATE_TIME"
			,GroupFun = "MAX"
			,SelectSequence = 104
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set;
			get;
		}
		/// <summary>
		/// APP_INTERVIEW Table 
		/// </summary>
		public const string TABLE_NAME="APP_INTERVIEW";
		public const String INTERVIEW_ID_FIELD  ="INTERVIEW_ID";
		public const String SCHOOL_NO_FIELD  ="SCHOOL_NO";
		public const String TITLE_FIELD  ="TITLE";
		public const String DATE_PUBLISH_FIELD  ="DATE_PUBLISH";
		public const String SEQ_NO_FIELD  ="SEQ_NO";
		public const String SOURCE_FIELD  ="SOURCE";
		public const String PICTURE_MINI_FIELD  ="PICTURE_MINI";
		public const String PICTURE_NAME_FIELD  ="PICTURE_NAME";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String DESCRIPTION_FIELD  ="DESCRIPTION";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String READ_TMES_FIELD  ="READ_TMES";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}