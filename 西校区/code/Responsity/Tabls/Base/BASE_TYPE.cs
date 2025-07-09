using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for BASE_TYPE Table
	/// </summary>
	[Serializable]
	[DataTable("BASE_TYPE",ResourceKey = "BASE_TYPE")]
	public class BASE_TYPE: BaseObject
	{
		public BASE_TYPE()
		{
		}
		public BASE_TYPE(DealModel initModel):base(initModel)
		{
		}
		public static BASE_TYPE Convert(BaseObject from)
		{
			return (BASE_TYPE)from;
		}
		/// <summary>
		/// The TYPE_ID Field of BASE_TYPE Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.TYPE_ID = value; }
			get { return TYPE_ID; }
		}

		[RecordIDField("TYPE_ID"
			, AliasName = "TYPE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "TYPE_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal TYPE_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The TYPE_NO Field of BASE_TYPE Table
		/// </summary>
		[KeyField("TYPE_NO"
			, AliasName = "TYPE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 32
			, Width =100
			, ResourceKey = "TYPE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string TYPE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The CLASS_NO Field of BASE_TYPE Table
		/// </summary>
		[DataField("CLASS_NO"
			, AliasName = "CLASS_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 32
			, Width = 100
			, ResourceKey = "CLASS_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CLASS_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The TYPE_NAME Field of BASE_TYPE Table
		/// </summary>
		[DataField("TYPE_NAME"
			, AliasName = "TYPE_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "TYPE_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TYPE_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of BASE_TYPE Table
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
		/// The REMARK Field of BASE_TYPE Table
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
		/// The CREATE_BY Field of BASE_TYPE Table
		/// </summary>
		[DataField("CREATE_BY"
			, AliasName = "CREATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, ResourceKey = "CREATE_BY"
			, GroupFun = "MAX"
			, SelectSequence = 101
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "UserID"
			 )]
		public decimal CREATE_BY
		{
			set;
			get;
		}
		/// <summary>
		/// The CREATE_TIME Field of BASE_TYPE Table
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
		/// The UPDATE_BY Field of BASE_TYPE Table
		/// </summary>
		[DataField("UPDATE_BY"
			, AliasName = "UPDATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, ResourceKey = "UPDATE_BY"
			, GroupFun = "MAX"
			, SelectSequence = 103
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "UserID"
			 )]
		public decimal UPDATE_BY
		{
			set;
			get;
		}
		/// <summary>
		/// The UPDATE_TIME Field of BASE_TYPE Table
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
		/// BASE_TYPE Table 
		/// </summary>
		public const string TABLE_NAME="BASE_TYPE";
		public const String TYPE_ID_FIELD  ="TYPE_ID";
		public const String TYPE_NO_FIELD  ="TYPE_NO";
		public const String CLASS_NO_FIELD  ="CLASS_NO";
		public const String TYPE_NAME_FIELD  ="TYPE_NAME";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}