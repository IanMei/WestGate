using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for BASE_CITY Table
    /// </summary>
    [Serializable]
    [DataTable("BASE_CITY", ResourceKey = "BASE_CITY")]
    public class BASE_CITY : BaseObject
    {
        public BASE_CITY()
        {
        }
        public BASE_CITY(DealModel initModel) : base(initModel)
        {
        }
        public static BASE_CITY Convert(BaseObject from)
        {
            return (BASE_CITY)from;
        }
        /// <summary>
        /// The CITY_ID Field of BASE_CITY Table
        /// </summary>
        private decimal _city_id;
        public override decimal ID
        {
            set
            {
                base.ID = value;
                this.CITY_ID = value;
            }
            get { return CITY_ID; }
        }

        [RecordIDField("CITY_ID"
            , AliasName = "CITY_ID"
            , DataType = DbType.Decimal
            , IsNullable = false
            , Size = 10
            , Width = 100
            , DisplayInCondition = false
            , DisplayInMaintain = false
            , DisplayInDialog = false
            , ResourceKey = "CITY_ID"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 0
            , DialogSequence = 0
            , IsInsertField = false
            , IsUpdateField = false
             )]
        public decimal CITY_ID
        {
            set { _city_id = value; }
            get { return _city_id; }
        }
        /// <summary>
        /// The CITY_NO Field of BASE_CITY Table
        /// </summary>
        private string _city_no;
        [KeyField("CITY_NO"
            , AliasName = "CITY_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = true
            , ResourceKey = "CITY_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = true
            , SelectSequence = 3
            , DialogSequence = 3
            , IsInsertField = true
            , IsUpdateField = true
            , KeySequence = 0
             )]
        public string CITY_NO
        {
            set { _city_no = value; }
            get { return _city_no; }
        }


        [ExpressionField("(select MAX(a.Pinyin) from APP_CITY a where a.ID = BASE_CITY.CITY_NO)"
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
        /// The CITY_NAME Field of BASE_CITY Table
        /// </summary>
        private string _city_name;
        [DataField("CITY_NAME"
            , AliasName = "CITY_NAME"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "CITY_NAME"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 6
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string CITY_NAME
        {
            set { _city_name = value; }
            get { return _city_name; }
        }
        /// <summary>
        /// The PROVINCE_NO Field of BASE_CITY Table
        /// </summary>
        private string _province_no;
        [DataField("PROVINCE_NO"
            , AliasName = "PROVINCE_NO"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 20
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "PROVINCE_NO"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 9
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string PROVINCE_NO
        {
            set { _province_no = value; }
            get { return _province_no; }
        }
        /// <summary>
        /// The INITIALS Field of BASE_CITY Table
        /// </summary>
        private string _initials;
        [DataField("INITIALS"
            , AliasName = "INITIALS"
            , DataType = DbType.String
            , IsNullable = false
            , Size = 2
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "INITIALS"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 12
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public string INITIALS
        {
            set { _initials = value; }
            get { return _initials; }
        }
        /// <summary>
        /// The IS_HOT Field of BASE_CITY Table
        /// </summary>
        private Int32 _is_hot;
        [DataField("IS_HOT"
            , AliasName = "IS_HOT"
            , DataType = DbType.Int32
            , IsNullable = false
            , Size = 4
            , Width = 100
            , DisplayInCondition = true
            , DisplayInMaintain = true
            , DisplayInDialog = false
            , ResourceKey = "IS_HOT"
            , GroupFun = "MAX"
            , AllowEdit = false
            , Frozen = false
            , SelectSequence = 15
            , DialogSequence = -1
            , IsInsertField = true
            , IsUpdateField = true
             )]
        public Int32 IS_HOT
        {
            set { _is_hot = value; }
            get { return _is_hot; }
        }
        /// <summary>
        /// The IS_ENABLED Field of BASE_CITY Table
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
            , SelectSequence = 18
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
        /// The REMARK Field of BASE_CITY Table
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
            , SelectSequence = 21
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
        /// BASE_CITY Table 
        /// </summary>
        public const string TABLE_NAME = "BASE_CITY";
        public const String CITY_ID_FIELD = "CITY_ID";
        public const String CITY_NO_FIELD = "CITY_NO";
        public const String CITY_NAME_FIELD = "CITY_NAME";
        public const String PROVINCE_NO_FIELD = "PROVINCE_NO";
        public const String INITIALS_FIELD = "INITIALS";
        public const String IS_HOT_FIELD = "IS_HOT";
        public const String IS_ENABLED_FIELD = "IS_ENABLED";
        public const String REMARK_FIELD = "REMARK";
    }
}