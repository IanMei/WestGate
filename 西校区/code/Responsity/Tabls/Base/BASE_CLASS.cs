using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for BASE_CLASS Table
	/// </summary>
	[Serializable]
	[DataTable("BASE_CLASS",ResourceKey = "BASE_CLASS")]
	public class BASE_CLASS: BaseObject
	{
		public BASE_CLASS()
		{
		}
		public BASE_CLASS(DealModel initModel):base(initModel)
		{
		}
		public static BASE_CLASS Convert(BaseObject from)
		{
			return (BASE_CLASS)from;
		}
		/// <summary>
		/// The CLASS_ID Field of BASE_CLASS Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.CLASS_ID = value; }
			get { return CLASS_ID; }
		}

		[RecordIDField("CLASS_ID"
			, AliasName = "CLASS_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "CLASS_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal CLASS_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The CLASS_NO Field of BASE_CLASS Table
		/// </summary>
		[KeyField("CLASS_NO"
			, AliasName = "CLASS_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 32
			, Width =100
			, ResourceKey = "CLASS_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string CLASS_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The CLASS_NAME Field of BASE_CLASS Table
		/// </summary>
		[DataField("CLASS_NAME"
			, AliasName = "CLASS_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "CLASS_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CLASS_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of BASE_CLASS Table
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
		/// The REMARK Field of BASE_CLASS Table
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
		/// The CREATE_BY Field of BASE_CLASS Table
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
		/// The CREATE_TIME Field of BASE_CLASS Table
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
		/// The UPDATE_BY Field of BASE_CLASS Table
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
		/// The UPDATE_TIME Field of BASE_CLASS Table
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
		/// BASE_CLASS Table 
		/// </summary>
		public const string TABLE_NAME="BASE_CLASS";
		public const String CLASS_ID_FIELD  ="CLASS_ID";
		public const String CLASS_NO_FIELD  ="CLASS_NO";
		public const String CLASS_NAME_FIELD  ="CLASS_NAME";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}