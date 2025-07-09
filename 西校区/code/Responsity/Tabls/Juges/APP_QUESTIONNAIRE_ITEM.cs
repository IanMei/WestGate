using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_QUESTIONNAIRE_ITEM Table
	/// </summary>
	[Serializable]
	[DataTable("APP_QUESTIONNAIRE_ITEM",ResourceKey = "APP_QUESTIONNAIRE_ITEM")]
	public class APP_QUESTIONNAIRE_ITEM: BaseObject
	{
		public APP_QUESTIONNAIRE_ITEM()
		{
		}
		public APP_QUESTIONNAIRE_ITEM(DealModel initModel):base(initModel)
		{
		}
		public static APP_QUESTIONNAIRE_ITEM Convert(BaseObject from)
		{
			return (APP_QUESTIONNAIRE_ITEM)from;
		}
		/// <summary>
		/// The ITEM_ID Field of APP_QUESTIONNAIRE_ITEM Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ITEM_ID = value; }
			get { return ITEM_ID; }
		}

		[RecordIDField("ITEM_ID"
			, AliasName = "ITEM_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "ITEM_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ITEM_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The QUESTIONNAIRE_NO Field of APP_QUESTIONNAIRE_ITEM Table
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
		/// The TITLE Field of APP_QUESTIONNAIRE_ITEM Table
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
		/// The RESULT_MAX Field of APP_QUESTIONNAIRE_ITEM Table
		/// </summary>
		[DataField("RESULT_MAX"
			, AliasName = "RESULT_MAX"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "RESULT_MAX"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 RESULT_MAX
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_QUESTIONNAIRE_ITEM Table
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
		/// The CREATE_TIME Field of APP_QUESTIONNAIRE_ITEM Table
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
		/// The UPDATE_TIME Field of APP_QUESTIONNAIRE_ITEM Table
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
		/// APP_QUESTIONNAIRE_ITEM Table 
		/// </summary>
		public const string TABLE_NAME="APP_QUESTIONNAIRE_ITEM";
		public const String ITEM_ID_FIELD  ="ITEM_ID";
		public const String QUESTIONNAIRE_NO_FIELD  ="QUESTIONNAIRE_NO";
		public const String TITLE_FIELD  ="TITLE";
		public const String RESULT_MAX_FIELD  ="RESULT_MAX";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}