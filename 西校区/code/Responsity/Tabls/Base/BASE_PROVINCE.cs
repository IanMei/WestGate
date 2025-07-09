using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for BASE_PROVINCE Table
	/// </summary>
	[Serializable]
	[DataTable("BASE_PROVINCE",ResourceKey = "BASE_PROVINCE")]
	public class BASE_PROVINCE: BaseObject
	{
		public BASE_PROVINCE()
		{
		}
		public BASE_PROVINCE(DealModel initModel):base(initModel)
		{
		}
		public static BASE_PROVINCE Convert(BaseObject from)
		{
			return (BASE_PROVINCE)from;
		}
		/// <summary>
		/// The PROVINCE_ID Field of BASE_PROVINCE Table
		/// </summary>
		private decimal _province_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.PROVINCE_ID = value; }
			get { return PROVINCE_ID; }
		}

		[RecordIDField("PROVINCE_ID"
			, AliasName = "PROVINCE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "PROVINCE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal PROVINCE_ID
		{
			set { _province_id = value; }
			get { return _province_id; }
		}
		/// <summary>
		/// The PROVINCE_NO Field of BASE_PROVINCE Table
		/// </summary>
		private string _province_no;
		[KeyField("PROVINCE_NO"
			, AliasName = "PROVINCE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "PROVINCE_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string PROVINCE_NO
		{
			set { _province_no = value; }
			get { return _province_no; }
		}
		[ExpressionField("(select MAX(a.Pinyin) from APP_CITY a where a.ID = BASE_PROVINCE.PROVINCE_NO)"
		  , AliasName = "PINYIN"
		  , DataType = DbType.String
		  , IsNullable = false
		  , Size = 10
		  , Width = 100
		  , DisplayInCondition = true
		  , DisplayInMaintain = true
		  , DisplayInDialog = false
		  , ResourceKey = "PINYIN"
		  , GroupFun = "MAX"
		  , AllowEdit = false
		  , Frozen = false
		  , SelectSequence = 20
		  , DialogSequence = 0
		  , IsInsertField = false
		  , IsUpdateField = false
		   )]
		public string PINYIN
		{
			get; set;
		}
		/// <summary>
		/// The PROVINCE_NAME Field of BASE_PROVINCE Table
		/// </summary>
		private string _province_name;
		[DataField("PROVINCE_NAME"
			, AliasName = "PROVINCE_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PROVINCE_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PROVINCE_NAME
		{
			set { _province_name = value; }
			get { return _province_name; }
		}
		/// <summary>
		/// The IS_ENABLED Field of BASE_PROVINCE Table
		/// </summary>
		private Int32 _is_enabled;
		[DataField("IS_ENABLED"
			, AliasName = "IS_ENABLED"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IS_ENABLED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_ENABLED
		{
			set { _is_enabled = value; }
			get { return _is_enabled; }
		}
		/// <summary>
		/// The REMARK Field of BASE_PROVINCE Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REMARK
		{
			set { _remark = value; }
			get { return _remark; }
		}
		/// <summary>
		/// BASE_PROVINCE Table 
		/// </summary>
		public const string TABLE_NAME="BASE_PROVINCE";
		public const String PROVINCE_ID_FIELD  ="PROVINCE_ID";
		public const String PROVINCE_NO_FIELD  ="PROVINCE_NO";
		public const String PROVINCE_NAME_FIELD  ="PROVINCE_NAME";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
	}
}