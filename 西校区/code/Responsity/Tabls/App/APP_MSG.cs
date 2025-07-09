using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_MSG Table
	/// </summary>
	[Serializable]
	[DataTable("APP_MSG", ResourceKey = "APP_MSG")]
	public class APP_MSG : BaseObject
	{
		public APP_MSG()
		{
		}
		public APP_MSG(DealModel initModel) : base(initModel)
		{
		}
		public static APP_MSG Convert(BaseObject from)
		{
			return (APP_MSG)from;
		}
		/// <summary>
		/// The MSG_ID Field of APP_MSG Table
		/// </summary>
		public override decimal ID
		{
			set
			{
				base.ID = value;
				this.MSG_ID = value;
			}
			get { return MSG_ID; }
		}

		[RecordIDField("MSG_ID"
			, AliasName = "MSG_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "MSG_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal MSG_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The MSG_NO Field of APP_MSG Table
		/// </summary>
		[KeyField("MSG_NO"
			, AliasName = "MSG_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "MSG_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string MSG_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The MSG_TYPE Field of APP_MSG Table
		/// </summary>
		[DataField("MSG_TYPE"
			, AliasName = "MSG_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "MSG_TYPE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MSG_TYPE
		{
			set;
			get;
		}
		/// <summary>
		/// The TITLE Field of APP_MSG Table
		/// </summary>
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
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
		/// The DATE_PUBLISH Field of APP_MSG Table
		/// </summary>
		[DataField("DATE_PUBLISH"
			, AliasName = "DATE_PUBLISH"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "DATE_PUBLISH"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_PUBLISH
		{
			set;
			get;
		}
		/// <summary>
		/// The LINK_MAN Field of APP_MSG Table
		/// </summary>
		[DataField("LINK_MAN"
			, AliasName = "LINK_MAN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "LINK_MAN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_MAN
		{
			set;
			get;
		}
		/// <summary>
		/// The LINK_TEL Field of APP_MSG Table
		/// </summary>
		[DataField("LINK_TEL"
			, AliasName = "LINK_TEL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "LINK_TEL"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_TEL
		{
			set;
			get;
		}
		/// <summary>
		/// The MESSAGE Field of APP_MSG Table
		/// </summary>
		[DataField("MESSAGE"
			, AliasName = "MESSAGE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 1000
			, Width = 100
			, ResourceKey = "MESSAGE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MESSAGE
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_MSG Table
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
		/// The REMARK Field of APP_MSG Table
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
		/// The CREATE_TIME Field of APP_MSG Table
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
		/// The UPDATE_TIME Field of APP_MSG Table
		/// </summary>
		[DataField("UPDATE_TIME"
			, AliasName = "UPDATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			, SelectSequence = 104
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set;
			get;
		}
		/// <summary>
		/// APP_MSG Table 
		/// </summary>
		public const string TABLE_NAME = "APP_MSG";
		public const String MSG_ID_FIELD = "MSG_ID";
		public const String MSG_NO_FIELD = "MSG_NO";
		public const String MSG_TYPE_FIELD = "MSG_TYPE";
		public const String TITLE_FIELD = "TITLE";
		public const String DATE_PUBLISH_FIELD = "DATE_PUBLISH";
		public const String LINK_MAN_FIELD = "LINK_MAN";
		public const String LINK_TEL_FIELD = "LINK_TEL";
		public const String MESSAGE_FIELD = "MESSAGE";
		public const String IS_ENABLED_FIELD = "IS_ENABLED";
		public const String REMARK_FIELD = "REMARK";
		public const String CREATE_TIME_FIELD = "CREATE_TIME";
		public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
	}
}