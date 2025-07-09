using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_HONOR Table
	/// </summary>
	[Serializable]
	[DataTable("APP_HONOR",ResourceKey = "APP_HONOR")]
	public class APP_HONOR: BaseObject
	{
		public APP_HONOR()
		{
		}
		public APP_HONOR(DealModel initModel):base(initModel)
		{
		}
		public static APP_HONOR Convert(BaseObject from)
		{
			return (APP_HONOR)from;
		}
		/// <summary>
		/// The HONOR_ID Field of APP_HONOR Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.HONOR_ID = value; }
			get { return HONOR_ID; }
		}

		[RecordIDField("HONOR_ID"
			, AliasName = "HONOR_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "HONOR_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal HONOR_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The SCHOOL_NO Field of APP_HONOR Table
		/// </summary>
		[DataField("SCHOOL_NO"
			, AliasName = "SCHOOL_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "SCHOOL_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SCHOOL_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The HONOR_YEAR Field of APP_HONOR Table
		/// </summary>
		[DataField("HONOR_YEAR"
			, AliasName = "HONOR_YEAR"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "HONOR_YEAR"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HONOR_YEAR
		{
			set;
			get;
		}
		/// <summary>
		/// The HONOR_DESC Field of APP_HONOR Table
		/// </summary>
		[DataField("HONOR_DESC"
			, AliasName = "HONOR_DESC"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 200
			, Width = 100
			, ResourceKey = "HONOR_DESC"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HONOR_DESC
		{
			set;
			get;
		}

		/// <summary>
		/// The HONOR_DESC Field of APP_HONOR Table
		/// </summary>
		[DataField("HONOR_EN"
			, AliasName = "HONOR_EN"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 200
			, Width = 100
			, ResourceKey = "HONOR_EN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HONOR_EN
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_HONOR Table
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
		/// The CREATE_TIME Field of APP_HONOR Table
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
		/// The UPDATE_TIME Field of APP_HONOR Table
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
		/// APP_HONOR Table 
		/// </summary>
		public const string TABLE_NAME="APP_HONOR";
		public const String HONOR_ID_FIELD  ="HONOR_ID";
		public const String SCHOOL_NO_FIELD  ="SCHOOL_NO";
		public const String HONOR_YEAR_FIELD  ="HONOR_YEAR";
		public const String HONOR_DESC_FIELD  ="HONOR_DESC";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}