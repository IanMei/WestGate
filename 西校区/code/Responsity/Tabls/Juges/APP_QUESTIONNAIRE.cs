using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_QUESTIONNAIRE Table
	/// </summary>
	[Serializable]
	[DataTable("APP_QUESTIONNAIRE",ResourceKey = "APP_QUESTIONNAIRE")]
	public class APP_QUESTIONNAIRE: BaseObject
	{
		public APP_QUESTIONNAIRE()
		{
		}
		public APP_QUESTIONNAIRE(DealModel initModel):base(initModel)
		{
		}
		public static APP_QUESTIONNAIRE Convert(BaseObject from)
		{
			return (APP_QUESTIONNAIRE)from;
		}
		/// <summary>
		/// The QUESTIONNAIRE_ID Field of APP_QUESTIONNAIRE Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.QUESTIONNAIRE_ID = value; }
			get { return QUESTIONNAIRE_ID; }
		}

		[RecordIDField("QUESTIONNAIRE_ID"
			, AliasName = "QUESTIONNAIRE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "QUESTIONNAIRE_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal QUESTIONNAIRE_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The QUESTIONNAIRE_NO Field of APP_QUESTIONNAIRE Table
		/// </summary>
		[KeyField("QUESTIONNAIRE_NO"
			, AliasName = "QUESTIONNAIRE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, ResourceKey = "QUESTIONNAIRE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string QUESTIONNAIRE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The QUESTIONNAIRE_TITLE Field of APP_QUESTIONNAIRE Table
		/// </summary>
		[DataField("QUESTIONNAIRE_TITLE"
			, AliasName = "QUESTIONNAIRE_TITLE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
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
		/// The QUESTIONNAIRE_CONTENT Field of APP_QUESTIONNAIRE Table
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
		/// The QUESTIONNAIRE_START Field of APP_QUESTIONNAIRE Table
		/// </summary>
		[DataField("QUESTIONNAIRE_START"
			, AliasName = "QUESTIONNAIRE_START"
			, DataType = DbType.DateTime
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "QUESTIONNAIRE_START"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime? QUESTIONNAIRE_START
		{
			set;
			get;
		}
		/// <summary>
		/// The QUESTIONNAIRE_END Field of APP_QUESTIONNAIRE Table
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
		/// The IS_ENABLED Field of APP_QUESTIONNAIRE Table
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
		/// The REMARK Field of APP_QUESTIONNAIRE Table
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
		/// The CREATE_TIME Field of APP_QUESTIONNAIRE Table
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
		/// The UPDATE_TIME Field of APP_QUESTIONNAIRE Table
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
		/// APP_QUESTIONNAIRE Table 
		/// </summary>
		public const string TABLE_NAME="APP_QUESTIONNAIRE";
		public const String QUESTIONNAIRE_ID_FIELD  ="QUESTIONNAIRE_ID";
		public const String QUESTIONNAIRE_NO_FIELD  ="QUESTIONNAIRE_NO";
		public const String QUESTIONNAIRE_TITLE_FIELD  ="QUESTIONNAIRE_TITLE";
		public const String QUESTIONNAIRE_CONTENT_FIELD  ="QUESTIONNAIRE_CONTENT";
		public const String QUESTIONNAIRE_START_FIELD  ="QUESTIONNAIRE_START";
		public const String QUESTIONNAIRE_END_FIELD  ="QUESTIONNAIRE_END";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}