using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_ACTIVITY_ENROLL Table
	/// </summary>
	[Serializable]
	[DataTable("APP_ACTIVITY_ENROLL",ResourceKey = "APP_ACTIVITY_ENROLL")]
	public class APP_ACTIVITY_ENROLL: BaseObject
	{
		public APP_ACTIVITY_ENROLL()
		{
		}
		public APP_ACTIVITY_ENROLL(DealModel initModel):base(initModel)
		{
		}
		public static APP_ACTIVITY_ENROLL Convert(BaseObject from)
		{
			return (APP_ACTIVITY_ENROLL)from;
		}
		/// <summary>
		/// The ENROLL_ID Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ENROLL_ID = value; }
			get { return ENROLL_ID; }
		}

		[RecordIDField("ENROLL_ID"
			, AliasName = "ENROLL_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "ENROLL_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ENROLL_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_NO Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		[ForeignKeyField("ACTIVITY_NO"
		   , AliasName = "ACTIVITY_NO"
		   , DataType = DbType.String
		   , IsNullable = false
		   , Size = 20
		   , Width = 100
		   , DisplayInCondition = true
		   , DisplayInMaintain = true
		   , DisplayInDialog = false
		   , ResourceKey = "ACTIVITY_NO"
		   , GroupFun = "MAX"
		   , AllowEdit = false
		   , Frozen = false
		   , SelectSequence = 30
		   , DialogSequence = -1
		   , IsInsertField = true
		   , IsUpdateField = true
		   , ForeignTableName = APP_ACTIVITY.TABLE_NAME
		   , ForeignTableAliasName = APP_ACTIVITY.TABLE_NAME
		   , ForeignColumnName = APP_ACTIVITY.ACTIVITY_NO_FIELD
		   , IsMainTableKey = true
		   , ForeignTableJoinType = TableJoinType.LeftOuterJoin
		   , TableJoinSequence = 0
			)]
		public string ACTIVITY_NO
		{
			set;
			get;
		}

		[ForeignField("ACTIVITY_NAME"
		   , AliasName = "ACTIVITY_NAME"
		   , DataType = DbType.String
		   , IsNullable = false
		   , Size = 20
		   , Width = 100
		   , DisplayInCondition = false
		   , DisplayInMaintain = false
		   , DisplayInDialog = false
		   , ResourceKey = "ACTIVITY_NAME"
		   , GroupFun = "MAX"
		   , AllowEdit = false
		   , Frozen = false
		   , SelectSequence = 30
		   , DialogSequence = -1
		   , IsInsertField = false
		   , IsUpdateField = false
		   , ForeignTableName = APP_ACTIVITY.TABLE_NAME
		   , ForeignTableAliasName = APP_ACTIVITY.TABLE_NAME
		   , ForeignColumnName = APP_ACTIVITY.ACTIVITY_NAME_FIELD
			)]
		public string ACTIVITY_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The USER_NAME Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		[DataField("USER_NAME"
			, AliasName = "USER_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "USER_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The COMPANY Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		[DataField("COMPANY"
			, AliasName = "COMPANY"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 100
			, ResourceKey = "COMPANY"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COMPANY
		{
			set;
			get;
		}
		/// <summary>
		/// The POSITION Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		[DataField("POSITION"
			, AliasName = "POSITION"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "POSITION"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string POSITION
		{
			set;
			get;
		}
		/// <summary>
		/// The MOBILE Field of APP_ACTIVITY_ENROLL Table
		/// </summary>
		[DataField("MOBILE"
			, AliasName = "MOBILE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 11
			, Width = 100
			, ResourceKey = "MOBILE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MOBILE
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_ACTIVITY_ENROLL Table
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
		/// The CREATE_TIME Field of APP_ACTIVITY_ENROLL Table
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
		/// The UPDATE_TIME Field of APP_ACTIVITY_ENROLL Table
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
		/// APP_ACTIVITY_ENROLL Table 
		/// </summary>
		public const string TABLE_NAME="APP_ACTIVITY_ENROLL";
		public const String ENROLL_ID_FIELD  ="ENROLL_ID";
		public const String ACTIVITY_NO_FIELD  ="ACTIVITY_NO";
		public const String USER_NAME_FIELD  ="USER_NAME";
		public const String COMPANY_FIELD  ="COMPANY";
		public const String POSITION_FIELD  ="POSITION";
		public const String MOBILE_FIELD  ="MOBILE";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}