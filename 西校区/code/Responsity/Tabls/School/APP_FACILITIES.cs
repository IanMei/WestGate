using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_FACILITIES Table
	/// </summary>
	[Serializable]
	[DataTable("APP_FACILITIES",ResourceKey = "APP_FACILITIES")]
	public class APP_FACILITIES: BaseObject
	{
		public APP_FACILITIES()
		{
		}
		public APP_FACILITIES(DealModel initModel):base(initModel)
		{
		}
		public static APP_FACILITIES Convert(BaseObject from)
		{
			return (APP_FACILITIES)from;
		}
		/// <summary>
		/// The FACILITIES_ID Field of APP_FACILITIES Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.FACILITIES_ID = value; }
			get { return FACILITIES_ID; }
		}

		[RecordIDField("FACILITIES_ID"
			, AliasName = "FACILITIES_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "FACILITIES_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal FACILITIES_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The FACILITIES_TYPE Field of APP_FACILITIES Table
		/// </summary>
		[DataField("FACILITIES_TYPE"
			, AliasName = "FACILITIES_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "FACILITIES_TYPE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FACILITIES_TYPE
		{
			set;
			get;
		}
		/// <summary>
		/// The SCHOOL_NO Field of APP_FACILITIES Table
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
		/// The TITLE Field of APP_FACILITIES Table
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
		/// The TITLE Field of APP_FACILITIES Table
		/// </summary>
		[DataField("TITLE_EN"
			, AliasName = "TITLE_EN"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "TITLE_EN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TITLE_EN
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_FACILITIES Table
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
		/// The REMARK Field of APP_FACILITIES Table
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
		/// The CREATE_TIME Field of APP_FACILITIES Table
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
		/// The UPDATE_TIME Field of APP_FACILITIES Table
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
		/// APP_FACILITIES Table 
		/// </summary>
		public const string TABLE_NAME="APP_FACILITIES";
		public const String FACILITIES_ID_FIELD  ="FACILITIES_ID";
		public const String FACILITIES_TYPE_FIELD  ="FACILITIES_TYPE";
		public const String SCHOOL_NO_FIELD  ="SCHOOL_NO";
		public const String TITLE_FIELD  ="TITLE";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}