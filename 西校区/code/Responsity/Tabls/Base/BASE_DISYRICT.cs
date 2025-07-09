using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for BASE_DISYRICT Table
	/// </summary>
	[Serializable]
	[DataTable("BASE_DISYRICT",ResourceKey = "BASE_DISYRICT")]
	public class BASE_DISYRICT: BaseObject
	{
		public BASE_DISYRICT()
		{
		}
		public BASE_DISYRICT(DealModel initModel):base(initModel)
		{
		}
		public static BASE_DISYRICT Convert(BaseObject from)
		{
			return (BASE_DISYRICT)from;
		}
		/// <summary>
		/// The DISYRICT_ID Field of BASE_DISYRICT Table
		/// </summary>
		private decimal _disyrict_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.DISYRICT_ID = value; }
			get { return DISYRICT_ID; }
		}

		[RecordIDField("DISYRICT_ID"
			, AliasName = "DISYRICT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "DISYRICT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal DISYRICT_ID
		{
			set { _disyrict_id = value; }
			get { return _disyrict_id; }
		}
		/// <summary>
		/// The DISYRICT_NO Field of BASE_DISYRICT Table
		/// </summary>
		private string _disyrict_no;
		[KeyField("DISYRICT_NO"
			, AliasName = "DISYRICT_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "DISYRICT_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string DISYRICT_NO
		{
			set { _disyrict_no = value; }
			get { return _disyrict_no; }
		}
		/// <summary>
		/// The DISYRICT_NAME Field of BASE_DISYRICT Table
		/// </summary>
		private string _disyrict_name;
		[DataField("DISYRICT_NAME"
			, AliasName = "DISYRICT_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DISYRICT_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DISYRICT_NAME
		{
			set { _disyrict_name = value; }
			get { return _disyrict_name; }
		}
        /// <summary>
		/// The CITY_NO Field of BASE_DISYRICT Table
		/// </summary>
		private string _city_no;
        [ForeignKeyField("CITY_NO"
            , AliasName = "CITY_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CITY_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
            , ForeignTableName = BASE_CITY.TABLE_NAME
            , ForeignTableAliasName = BASE_CITY.TABLE_NAME
            , ForeignColumnName = BASE_CITY.CITY_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 0
             )]
        public string CITY_NO {
            set { _city_no = value; }
            get { return _city_no; }
        }
        [ForeignField("CITY_NAME"
            , AliasName = "CITY_NAME"    //外键字段
            , DataType = DbType.String      //数据类型
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CITY_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_CITY.TABLE_NAME
            , ForeignTableAliasName = BASE_CITY.TABLE_NAME
            , ForeignColumnName = BASE_CITY.CITY_NAME_FIELD
             )]
        public string CITY_NAME {
            set;
            get;
        }
        [ForeignField("PROVINCE_NO"
            , AliasName = "PROVINCE_NO"    //外键字段
            , DataType = DbType.String      //数据类型
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_CITY.TABLE_NAME
            , ForeignTableAliasName = BASE_CITY.TABLE_NAME
            , ForeignColumnName = BASE_CITY.PROVINCE_NO_FIELD
             )]
        [ForeignKeyField("PROVINCE_NO"
            , AliasName = "PROVINCE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , TableName = BASE_CITY.TABLE_NAME
            , TableAliasName = BASE_CITY.TABLE_NAME
            , ForeignTableName = BASE_PROVINCE.TABLE_NAME
            , ForeignTableAliasName = BASE_PROVINCE.TABLE_NAME
            , ForeignColumnName = BASE_PROVINCE.PROVINCE_NO_FIELD
            , IsMainTableKey = true
            , ForeignTableJoinType = TableJoinType.LeftOuterJoin
            , TableJoinSequence = 1
        )]
        public string PROVINCE_NO {
            set;
            get;
        }
        [ForeignField("PROVINCE_NAME"
            , AliasName = "PROVINCE_NAME"    //外键字段
            , DataType = DbType.String      //数据类型
            , IsNullable = false
            , Size = 100
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = false
            , IsUpdateField = false
            , ForeignTableName = BASE_PROVINCE.TABLE_NAME
            , ForeignTableAliasName = BASE_PROVINCE.TABLE_NAME
            , ForeignColumnName = BASE_PROVINCE.PROVINCE_NAME_FIELD
             )]
        public string PROVINCE_NAME {
            set;
            get;
        }
        /// <summary>
        /// The IS_ENABLED Field of BASE_DISYRICT Table
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
			, SelectSequence = 12
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
		/// The REMARK Field of BASE_DISYRICT Table
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
			, SelectSequence = 15
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
		/// BASE_DISYRICT Table 
		/// </summary>
		public const string TABLE_NAME="BASE_DISYRICT";
		public const String DISYRICT_ID_FIELD  ="DISYRICT_ID";
		public const String DISYRICT_NO_FIELD  ="DISYRICT_NO";
		public const String DISYRICT_NAME_FIELD  ="DISYRICT_NAME";
		public const String CITY_NO_FIELD  ="CITY_NO";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
	}
}