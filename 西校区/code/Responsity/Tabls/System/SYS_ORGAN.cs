using CMS.Core.Common;
using System;
using System.Data;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for SYS_ORGAN Table
	/// </summary>
	[Serializable]
	[DataTable("SYS_ORGAN",ResourceKey = "SYS_ORGAN")]
	public class SYS_ORGAN: BaseObject
	{
		public SYS_ORGAN()
		{
		}
		public SYS_ORGAN(DealModel initModel):base(initModel)
		{
		}
		public static SYS_ORGAN Convert(BaseObject from)
		{
			return (SYS_ORGAN)from;
		}
		/// <summary>
		/// The ORGAN_ID Field of SYS_ORGAN Table
		/// </summary>
		private decimal _organ_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ORGAN_ID = value; }
			get { return ORGAN_ID; }
		}

		[RecordIDField("ORGAN_ID"
			, AliasName = "ORGAN_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "ORGAN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ORGAN_ID
		{
			set { _organ_id = value; }
			get { return _organ_id; }
		}
		/// <summary>
		/// The ORGAN_CODE Field of SYS_ORGAN Table
		/// </summary>
		private string _organ_code;
		[KeyField("ORGAN_CODE"
			, AliasName = "ORGAN_CODE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "ORGAN_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string ORGAN_CODE
		{
			set { _organ_code = value; }
			get { return _organ_code; }
		}
		/// <summary>
		/// The ORGAN_NAME Field of SYS_ORGAN Table
		/// </summary>
		private string _organ_name;
		[DataField("ORGAN_NAME"
			, AliasName = "ORGAN_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ORGAN_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ORGAN_NAME
		{
			set { _organ_name = value; }
			get { return _organ_name; }
		}
		/// <summary>
		/// The PARENT_CODE Field of SYS_ORGAN Table
		/// </summary>
		private string _parent_code;
		[DataField("PARENT_CODE"
			, AliasName = "PARENT_CODE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PARENT_CODE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PARENT_CODE
		{
			set { _parent_code = value; }
			get { return _parent_code; }
		}
		/// <summary>
		/// The PARENT_PATH Field of SYS_ORGAN Table
		/// </summary>
		private string _parent_path;
		[DataField("PARENT_PATH"
			, AliasName = "PARENT_PATH"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 4000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PARENT_PATH"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PARENT_PATH
		{
			set { _parent_path = value; }
			get { return _parent_path; }
		}
		/// <summary>
		/// The IS_ENABLED Field of SYS_ORGAN Table
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
			, SelectSequence = 15
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
		/// The REMARK Field of SYS_ORGAN Table
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
			, SelectSequence = 18
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
		/// The CREATE_BY Field of SYS_ORGAN Table
		/// </summary>
		private decimal _create_by;
		[DataField("CREATE_BY"
			, AliasName = "CREATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 101
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "UserID"
			 )]
		public decimal CREATE_BY
		{
			set { _create_by = value; }
			get { return _create_by; }
		}
		/// <summary>
		/// The CREATE_TIME Field of SYS_ORGAN Table
		/// </summary>
		private DateTime _create_time;
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 102
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set { _create_time = value; }
			get { return _create_time; }
		}
		/// <summary>
		/// The UPDATE_BY Field of SYS_ORGAN Table
		/// </summary>
		private decimal _update_by;
		[DataField("UPDATE_BY"
			, AliasName = "UPDATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "UPDATE_BY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 103
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "UserID"
			 )]
		public decimal UPDATE_BY
		{
			set { _update_by = value; }
			get { return _update_by; }
		}
		/// <summary>
		/// The UPDATE_TIME Field of SYS_ORGAN Table
		/// </summary>
		private DateTime _update_time;
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,DisplayInCondition = false
			,DisplayInMaintain = false
			, DisplayInDialog = false
			,ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			,AllowEdit = false
			,SelectSequence = 104
			, DialogSequence = -1
			,Frozen = false
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set { _update_time = value; }
			get { return _update_time; }
		}
		/// <summary>
		/// SYS_ORGAN Table 
		/// </summary>
		public const string TABLE_NAME="SYS_ORGAN";
		public const String ORGAN_ID_FIELD  ="ORGAN_ID";
		public const String ORGAN_CODE_FIELD  ="ORGAN_CODE";
		public const String ORGAN_NAME_FIELD  ="ORGAN_NAME";
		public const String PARENT_CODE_FIELD  ="PARENT_CODE";
		public const String PARENT_PATH_FIELD  ="PARENT_PATH";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}