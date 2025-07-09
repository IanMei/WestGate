using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_QUESTIONNAIRE_JUDGES Table
	/// </summary>
	[Serializable]
	[DataTable("APP_QUESTIONNAIRE_JUDGES", ResourceKey = "APP_QUESTIONNAIRE_JUDGES")]
	public class APP_QUESTIONNAIRE_JUDGES : BaseObject
	{
		public APP_QUESTIONNAIRE_JUDGES()
		{
		}
		public APP_QUESTIONNAIRE_JUDGES(DealModel initModel) : base(initModel)
		{
		}
		public static APP_QUESTIONNAIRE_JUDGES Convert(BaseObject from)
		{
			return (APP_QUESTIONNAIRE_JUDGES)from;
		}
		/// <summary>
		/// The RESULT_ID Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		public override decimal ID
		{
			set
			{
				base.ID = value;
				this.RESULT_ID = value;
			}
			get { return RESULT_ID; }
		}

		[RecordIDField("RESULT_ID"
			, AliasName = "RESULT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "RESULT_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal RESULT_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The QUESTIONNAIRE_NO Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[DataField("QUESTIONNAIRE_NO"
			, AliasName = "QUESTIONNAIRE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "QUESTIONNAIRE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string QUESTIONNAIRE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The JUDGES_NO Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[ForeignKeyField("JUDGES_NO"
		   , AliasName = "JUDGES_NO"
		   , DataType = DbType.String
		   , IsNullable = false
		   , Size = 20
		   , Width = 100
		   , DisplayInCondition = true
		   , DisplayInMaintain = true
		   , DisplayInDialog = false
		   , ResourceKey = "JUDGES_NO"
		   , GroupFun = "MAX"
		   , AllowEdit = false
		   , Frozen = false
		   , SelectSequence = 30
		   , DialogSequence = -1
		   , IsInsertField = true
		   , IsUpdateField = true
		   , ForeignTableName = APP_JUDGES.TABLE_NAME
		   , ForeignTableAliasName = APP_JUDGES.TABLE_NAME
		   , ForeignColumnName = APP_JUDGES.JUDGES_NO_FIELD
		   , IsMainTableKey = true
		   , ForeignTableJoinType = TableJoinType.LeftOuterJoin
		   , TableJoinSequence = 0
			)]
		public string JUDGES_NO
		{
			set;
			get;
		}

		[ForeignField("NICK_NAME"
			, AliasName = "NICK_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "NICK_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
		    , ForeignTableName = APP_JUDGES.TABLE_NAME
		    , ForeignTableAliasName = APP_JUDGES.TABLE_NAME
		    , ForeignColumnName = APP_JUDGES.NICK_NAME_FIELD
			 )]
		public string NICK_NAME
		{
			set;
			get;
		}


		[ForeignField("COMPANY"
			, AliasName = "COMPANY"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "COMPANY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.COMPANY_FIELD
			 )]
		public string COMPANY
		{
			set;
			get;
		}

		[ForeignField("POSITION"
			, AliasName = "POSITION"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "POSITION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.POSITION_FIELD
			 )]
		public string POSITION
		{
			set;
			get;
		}

		[ForeignField("LINK_MAN"
			, AliasName = "LINK_MAN"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "LINK_MAN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.POSITION_FIELD
			 )]
		public string LINK_MAN
		{
			set;
			get;
		}

		[ForeignField("LINK_TEL"
			, AliasName = "LINK_TEL"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "LINK_TEL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.LINK_TEL_FIELD
			 )]
		public string LINK_TEL
		{
			set;
			get;
		}


		[ForeignField("EMAIL"
			, AliasName = "EMAIL"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "EMAIL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.POSITION_FIELD
			 )]
		public string EMAIL
		{
			set;
			get;
		}

		[ForeignField("WECHAT"
			, AliasName = "WECHAT"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "WECHAT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = false
			, IsUpdateField = false
			, ForeignTableName = APP_JUDGES.TABLE_NAME
			, ForeignTableAliasName = APP_JUDGES.TABLE_NAME
			, ForeignColumnName = APP_JUDGES.POSITION_FIELD
			 )]
		public string WECHAT
		{
			set;
			get;
		}


		/// <summary>
		/// The ITEM_ID Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[DataField("ITEM_ID"
			, AliasName = "ITEM_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "ITEM_ID"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal ITEM_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The TITLE Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
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
		/// The SCHOOL_NAME Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[DataField("SCHOOL_NAME"
			, AliasName = "SCHOOL_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
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
		/// The REASON Field of APP_QUESTIONNAIRE_JUDGES Table
		/// </summary>
		[DataField("REASON"
			, AliasName = "REASON"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "REASON"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REASON
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_QUESTIONNAIRE_JUDGES Table
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
		/// The CREATE_TIME Field of APP_QUESTIONNAIRE_JUDGES Table
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
		/// The UPDATE_TIME Field of APP_QUESTIONNAIRE_JUDGES Table
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
		/// APP_QUESTIONNAIRE_JUDGES Table 
		/// </summary>
		public const string TABLE_NAME = "APP_QUESTIONNAIRE_JUDGES";
		public const String RESULT_ID_FIELD = "RESULT_ID";
		public const String QUESTIONNAIRE_NO_FIELD = "QUESTIONNAIRE_NO";
		public const String JUDGES_NO_FIELD = "JUDGES_NO";
		public const String ITEM_ID_FIELD = "ITEM_ID";
		public const String TITLE_FIELD = "TITLE";
		public const String SCHOOL_NAME_FIELD = "SCHOOL_NAME";
		public const String REASON_FIELD = "REASON";
		public const String REMARK_FIELD = "REMARK";
		public const String CREATE_TIME_FIELD = "CREATE_TIME";
		public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
	}
}