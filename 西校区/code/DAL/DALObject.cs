using CMS.Core.Common;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace CMS.Core.DAL {

    /// <summary>
    /// ���ɲ������ݱ�����Ҫ�����
    /// </summary>
    [Serializable]
    public class DALObject : IDisposable {

        private static Dictionary<string, DALObject> CacheDictionary = new Dictionary<string, DALObject>();

        /// <summary>
        /// ���ɲ�����һ��DALObject���ʶ���
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static DALObject Get(Type dataType)
        {
            string _key = dataType.ToString();
            if (CacheDictionary.ContainsKey(_key))
            {
                return CacheDictionary[_key] as DALObject;
            }
            else
            {
                DALObject dal = new DALObject(dataType);
                CacheHelper.Add(_key, dal);
                return dal;
            }
            //var dalContext = CacheHelper.Get<DALObject>(dataType.ToString());
            //if (dalContext != null)
            //{
            //    try
            //    {
            //        return dalContext;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.Log("Cache", ex);
            //        DALObject dal = new DALObject(dataType);
            //        CacheHelper.Add(dataType.ToString(), dal);
            //        return dal;
            //    }
            //}
            //else
            //{
            //    DALObject dal = new DALObject(dataType);
            //    CacheHelper.Add(dataType.ToString(), dal);
            //    return dal;
            //}
        }

        #region member

        protected string _SelectCMD;
        protected string _SelectPageCountCMD;
        protected string _SelectDialogCMD;
        protected string _InsertCMD;
        protected string _UpdateCMD;
        protected string _DeleteCMD;

        protected Type _dataType = null;
        protected string _tableName;
        protected string _tableAliasName;
        protected string _SQLSelect = "";
        protected string _SQLDialog = "";
        protected string _SQLGroup = "";

        protected ArrayList _RecordIDFields = new ArrayList();
        protected ArrayList _KeyFields = new ArrayList();
        protected ArrayList _ForeignKeyFields = new ArrayList();
        protected ArrayList _ForeignFields = new ArrayList();
        protected ArrayList _DataFields = new ArrayList();
        protected ArrayList _SelectFields = new ArrayList();
        protected ArrayList _DialogFields = new ArrayList();
        protected ArrayList _InsertFields = new ArrayList();
        protected ArrayList _UpdateFields = new ArrayList();
        protected string _RecordIDFieldName = "";
        protected string _ForeignKeyRelations = "";
        protected object[] selectPara = null;
        protected object[] dialogPara = null;


        private List<PropertyInfo> selectPropertyInfo = new List<PropertyInfo>();

        private string _errMsg = "";
        //private string _errMsgInsertFailed = "";
        //private string _errMsgUpdateFailed = "";
        //private string _errMsgDeleteFailed = "";

        #endregion member

        #region Constructor and dispose
        static DALObject()
        {

        }

        public DALObject()
        {
        }

        public DALObject(Type dataType)
        {
            _dataType = dataType;
            Init();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return; // we're being collected, so let the GC take care of this object
        }

        #endregion Constructor and dispose

        #region ����������Ϣ

        /// <summary>
        /// ��ʼ�������͵�DALBase
        /// </summary>
        private void Init()
        {
            GetDataInfo();
            InitInsertCommand();
            InitUpdateCommand();
            InitDeleteCommand();
            InitSelectCommand();
            InitDialogSelectCommand();
            InitSelectPageCountCommand();
        }


        /// <summary>
        /// ��ȡ���ֶ���Ϣ
        /// </summary>
        private void GetDataInfo()
        {
            // ��ȡ�������Ϣ
            DataTableAttribute[] tableAttributes = (DataTableAttribute[])_dataType.GetCustomAttributes(typeof(DataTableAttribute), false);
            if (tableAttributes.Length > 0)
            {
                _tableName = tableAttributes[0].TableName;
                _tableAliasName = tableAttributes[0].TableAliasName;
            }

            // ��ȡ�ֶ������Ϣ
            RecordIDFieldAttribute recordIDField;
            KeyFieldAttribute keyField;
            ForeignKeyFieldAttribute foreignKeyField;
            ForeignFieldAttribute foreignField;
            DataFieldAttribute dataField;

            //FieldInfo[] fields = _dataType.GetFields();
            PropertyInfo[] fields = _dataType.GetProperties();

            #region �ֶ���������
            foreach (PropertyInfo field in fields)
            {

                BaseFieldAttribute[] baseFieldAttributes = (BaseFieldAttribute[])field.GetCustomAttributes(typeof(BaseFieldAttribute), true);
                if (baseFieldAttributes.Length > 0)
                {
                    foreach (BaseFieldAttribute baseField in baseFieldAttributes)
                    {
                        if (baseField is RecordIDFieldAttribute)
                        {
                            recordIDField = (RecordIDFieldAttribute)baseField;
                            _RecordIDFields.Add(recordIDField);
                            if (baseField is KeyFieldAttribute)
                            {
                                keyField = (KeyFieldAttribute)baseField;
                                _KeyFields.Add(keyField);
                            }
                        }
                        else if (baseField is ForeignKeyFieldAttribute)
                        {
                            foreignKeyField = (ForeignKeyFieldAttribute)baseField;
                            _ForeignKeyFields.Add(foreignKeyField);
                            if (baseField is KeyFieldAttribute)
                            {
                                keyField = (KeyFieldAttribute)baseField;
                                _KeyFields.Add(keyField);
                            }
                        }
                        else if (baseField is KeyFieldAttribute)
                        {
                            keyField = (KeyFieldAttribute)baseField;
                            _KeyFields.Add(keyField);
                        }
                        else if (baseField is ForeignFieldAttribute)
                        {
                            foreignField = (ForeignFieldAttribute)baseField;
                            _ForeignFields.Add(foreignField);
                        }
                        else if (baseField is DataFieldAttribute)
                        {
                            dataField = (DataFieldAttribute)baseField;
                            _DataFields.Add(dataField);
                        }
                        else
                        {
                        }

                        // Get Select Fields
                        if (baseField.SelectSequence >= 0)
                        {
                            _SelectFields.Add(baseField);
                            //selectPropertyInfo.Add(field);
                        }
                        // Get Dialog Fields
                        if (baseField.DialogSequence >= 0)
                        {
                            _DialogFields.Add(baseField);
                        }
                        // Get Insert Fields
                        if (baseField.IsInsertField)
                        {
                            _InsertFields.Add(baseField);
                        }
                        // Get Update Fields
                        if (baseField.IsUpdateField)
                        {
                            _UpdateFields.Add(baseField);
                        }
                    }
                }

            }

            #endregion


            // ��ȡID�ֶ���
            if (_RecordIDFields.Count > 0)
            {
                _RecordIDFields.Sort(RecordIDFieldAttribute.SortBySelectSequence);
                _RecordIDFieldName = ((RecordIDFieldAttribute)_RecordIDFields[0]).ColumnName;
            }

            #region  ��ȡ����ֶμ���������
            if (_ForeignKeyFields.Count > 0)
            {
                StringBuilder sbForeignKeyRelations = new StringBuilder();
                string strTable = "";
                //sort ArrayList
                _ForeignKeyFields.Sort(ForeignKeyFieldAttribute.SortByTableJoinSequence);
                foreach (ForeignKeyFieldAttribute foreignKey in _ForeignKeyFields)
                {
                    // Foreign Table
                    strTable = foreignKey.ForeignTableName + " " + foreignKey.ForeignTableAliasName;
                    if (sbForeignKeyRelations.ToString().IndexOf(strTable) >= 0)
                    {
                        sbForeignKeyRelations.Append(" AND ");

                        if (foreignKey.RelationExpression.Trim() != "")
                        {
                            sbForeignKeyRelations.Append(" " + foreignKey.RelationExpression.Trim() + " ");
                            continue;
                        }
                        if (foreignKey.TableName == "" && foreignKey.TableAliasName == "")
                        {
                            sbForeignKeyRelations.Append(_tableAliasName);	//as a main table column
                        }
                        else
                        {
                            sbForeignKeyRelations.Append(foreignKey.TableAliasName);
                        }
                        sbForeignKeyRelations.Append(".");
                        sbForeignKeyRelations.Append(foreignKey.ColumnName);
                        sbForeignKeyRelations.Append(" = ");
                        sbForeignKeyRelations.Append(foreignKey.ForeignTableAliasName);
                        sbForeignKeyRelations.Append(".");
                        sbForeignKeyRelations.Append(foreignKey.ForeignColumnName);
                    }
                    else
                    {
                        if (foreignKey.ForeignTableJoinType != TableJoinType.None)
                        {
                            switch (foreignKey.ForeignTableJoinType)
                            {
                                case TableJoinType.InnerJoin:
                                    sbForeignKeyRelations.Append(" INNER JOIN ");
                                    break;
                                case TableJoinType.LeftOuterJoin:
                                    sbForeignKeyRelations.Append(" LEFT JOIN ");
                                    break;
                                case TableJoinType.RightOuterJoin:
                                    sbForeignKeyRelations.Append(" RIGHT JOIN ");
                                    break;
                                case TableJoinType.FullOuterJoin:
                                    sbForeignKeyRelations.Append(" FULL OUTER JOIN ");
                                    break;
                            }
                            sbForeignKeyRelations.Append(strTable);
                            sbForeignKeyRelations.Append(" ON ");

                            if (foreignKey.RelationExpression.Trim() != "")
                            {
                                sbForeignKeyRelations.Append(" " + foreignKey.RelationExpression.Trim() + " ");
                                continue;
                            }

                            if (foreignKey.TableName == "" && foreignKey.TableAliasName == "")
                            {
                                sbForeignKeyRelations.Append(_tableAliasName);	//as a main table column
                            }
                            else
                            {
                                sbForeignKeyRelations.Append(foreignKey.TableAliasName);
                            }
                            sbForeignKeyRelations.Append(".");
                            sbForeignKeyRelations.Append(foreignKey.ColumnName);
                            sbForeignKeyRelations.Append(" = ");
                            sbForeignKeyRelations.Append(foreignKey.ForeignTableAliasName);
                            sbForeignKeyRelations.Append(".");
                            sbForeignKeyRelations.Append(foreignKey.ForeignColumnName);
                        }
                    }
                }
                _ForeignKeyRelations = sbForeignKeyRelations.ToString();
                sbForeignKeyRelations = null;
            }

            #endregion

            #region ���ɲ�ѯ���
            if (_SelectFields.Count > 0)
            {
                List<Object> _paraList = new List<Object>();
                StringBuilder sbSelectFields = new StringBuilder();
                StringBuilder sbGroupFields = new StringBuilder();
                ForeignFieldAttribute refField;
                // sort ArrayList
                _SelectFields.Sort(BaseFieldAttribute.SortBySelectSequence);
                foreach (BaseFieldAttribute baseField in _SelectFields)
                {
                    sbGroupFields.Append(baseField.GroupFun + "(");
                    if (baseField is ForeignFieldAttribute)
                    {
                        refField = (ForeignFieldAttribute)baseField;
                        sbSelectFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + " AS " + baseField.AliasName);
                        sbGroupFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + ") AS " + baseField.AliasName);
                    }
                    else if (baseField is ExpressionFieldAttribute)
                    {
                        sbSelectFields.Append(baseField.ColumnName + " AS " + baseField.AliasName);
                        sbGroupFields.Append(baseField.ColumnName + ") AS " + baseField.AliasName);
                    }
                    else
                    {
                        if (baseField.TableName == "" && baseField.TableAliasName == "")
                        {
                            sbSelectFields.Append(_tableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                            sbGroupFields.Append(_tableAliasName + "." + baseField.ColumnName + ") AS " + baseField.AliasName);
                        }
                        else
                        {
                            sbSelectFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                            sbGroupFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + ") AS " + baseField.AliasName);
                        }
                    }
                    if (baseField.ParaDefaultValue != null)
                    {
                        for (int i = 0; i < baseField.ParaDefaultValue.Length; i++)
                        {
                            _paraList.Add(baseField.ParaDefaultValue[i]);
                        }
                    }
                    sbSelectFields.Append(",");
                    sbGroupFields.Append(",");
                }
                selectPara = _paraList.ToArray();
                // Select Fields  
                sbSelectFields.Remove(sbSelectFields.Length - 1, 1);
                sbGroupFields.Remove(sbGroupFields.Length - 1, 1);
                _SQLSelect = sbSelectFields.ToString();
                _SQLGroup = sbGroupFields.ToString();
                sbSelectFields = null;
                sbGroupFields = null;
            }

            #endregion

            #region ���ɶԻ������
            if (_DialogFields.Count > 0)
            {
                List<Object> _paraList = new List<Object>();
                StringBuilder sbSelectFields = new StringBuilder();
                ForeignFieldAttribute refField;
                // sort ArrayList
                _DialogFields.Sort(BaseFieldAttribute.SortBySelectSequence);
                foreach (BaseFieldAttribute baseField in _DialogFields)
                {
                    if (baseField is ForeignFieldAttribute)
                    {
                        refField = (ForeignFieldAttribute)baseField;
                        sbSelectFields.Append(refField.ForeignTableAliasName + "." + refField.ForeignColumnName + " AS " + baseField.AliasName);
                    }
                    else if (baseField is ExpressionFieldAttribute)
                    {
                        sbSelectFields.Append(baseField.ColumnName + " AS " + baseField.AliasName);
                    }
                    else
                    {
                        if (baseField.TableName == "" && baseField.TableAliasName == "")
                        {
                            sbSelectFields.Append(_tableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                        }
                        else
                        {
                            sbSelectFields.Append(baseField.TableAliasName + "." + baseField.ColumnName + " AS " + baseField.AliasName);
                        }
                    }
                    if (baseField.ParaDefaultValue != null)
                    {
                        for (int i = 0; i < baseField.ParaDefaultValue.Length; i++)
                        {
                            _paraList.Add(baseField.ParaDefaultValue[i]);
                        }
                    }
                    sbSelectFields.Append(",");
                }
                dialogPara = _paraList.ToArray();
                // Dialog Fields
                sbSelectFields.Remove(sbSelectFields.Length - 1, 1);
                _SQLDialog = sbSelectFields.ToString();
                sbSelectFields = null;
            }

            #endregion
        }
        /// <summary>
        /// ���ɻ���Select���
        /// </summary>
        private void InitSelectCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            _SelectCMD = strSQL.ToString();
        }
        /// <summary>
        /// ���ɻ���Select���,����ҳ�������
        /// </summary>
        private void InitSelectPageCountCommand()
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("SELECT * FROM ");

            strSQL.Append("(SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(",ROW_NUMBER() OVER({1}) AS ROW_NUM ");//order by
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" {2} ");//where
            strSQL.Append(" ) ");
            strSQL.Append(" AS ");
            strSQL.Append(_tableAliasName + "1");
            strSQL.Append(" WHERE ROW_NUM BETWEEN {3} AND {4} ");

            _SelectPageCountCMD = strSQL.ToString();
        }
        /// <summary>
        /// ����Group by���
        /// </summary>
        /// <returns></returns>
        public string GetGroupCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLGroup);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }
        /// <summary>
        /// ���ز�ѯ�����
        /// </summary>
        /// <returns></returns>
        private string GetCountCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT count(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }

        /// <summary>
        /// ���ز�ѯ�����
        /// </summary>
        /// <returns></returns>
        private string GetSumCommand(string sumField)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.AppendFormat("SELECT SUM({0}) FROM ", sumField);
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }
        /// <summary>
        /// ����Dialog��ѯ���
        /// </summary>
        private void InitDialogSelectCommand()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            _SelectDialogCMD = strSQL.ToString();
        }
        /// <summary>
        /// ����ǰN����¼�Ĳ�ѯ���
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string InitTopSelectCommand(Int16 count)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT TOP " + count + " ");
            if (_SelectFields.Count > 0)
            {
                strSQL.Append(_SQLSelect);
            }
            else
            {
                strSQL.Append(_tableAliasName + ".* ");
            }
            strSQL.Append(" FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" ");
            strSQL.Append(_tableAliasName);

            if (_ForeignKeyRelations != "")
            {
                strSQL.Append(_ForeignKeyRelations);
            }
            strSQL.Append(" ");

            return strSQL.ToString();
        }
        /// <summary>
        /// ���ɲ�������Insert���
        /// </summary>
        private void InitInsertCommand()
        {
            StringBuilder sbInsertField = new StringBuilder();
            StringBuilder sbInsertValue = new StringBuilder();

            _InsertFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbInsertField.Append("INSERT INTO " + _tableName + "(");
            sbInsertValue.Append(" VALUES(");

            foreach (BaseFieldAttribute baseField in _InsertFields)
            {
                sbInsertField.Append(baseField.ColumnName + ",");
                sbInsertValue.Append("@" + baseField.ColumnName + ",");
            }

            sbInsertField.Remove(sbInsertField.Length - 1, 1);
            sbInsertField.Append(")");

            sbInsertValue.Remove(sbInsertValue.Length - 1, 1);
            sbInsertValue.Append(")");

            sbInsertField.Append(sbInsertValue.ToString());

            sbInsertField.Append("; Select @@IDENTITY;");

            _InsertCMD = sbInsertField.ToString();
        }
        /// <summary>
        /// ���ɴ������ĸ������
        /// </summary>
        private void InitUpdateCommand()
        {
            StringBuilder sbUpdateSQL = new StringBuilder();
            _UpdateFields.Sort(BaseFieldAttribute.SortBySelectSequence);
            sbUpdateSQL.Append("UPDATE " + _tableName + " SET ");
            foreach (BaseFieldAttribute baseField in _UpdateFields)
            {
                sbUpdateSQL.Append(baseField.ColumnName + " = @" + baseField.ColumnName + ",");
            }
            sbUpdateSQL.Remove(sbUpdateSQL.Length - 1, 1);
            sbUpdateSQL.Append(" WHERE ");
            sbUpdateSQL.Append(_RecordIDFieldName);
            sbUpdateSQL.Append(" = @" + _RecordIDFieldName);
            _UpdateCMD = sbUpdateSQL.ToString();
        }
        /// <summary>
        /// ���ɴ�������ɾ�����
        /// </summary>
        private void InitDeleteCommand()
        {
            StringBuilder sbDeleteSQL = new StringBuilder();
            if (KeyFields.Count > 0)
            {
                sbDeleteSQL.Append("DELETE FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=@" + _RecordIDFieldName);
            }
            _DeleteCMD = sbDeleteSQL.ToString();
        }

        #endregion

        #region ��ȡ�ֶμ������б�

        /// <summary>
        /// ����
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string TableAliasName
        {
            get { return _tableAliasName; }
        }

        /// <summary>
        /// ��ȡ���Զ������ֶ�����
        /// </summary>
        public string RecordIDFieldName
        {
            get { return _RecordIDFieldName; }
        }

        /// <summary>
        /// ��ȡAuto ID�ֶ�
        /// </summary>
        public ArrayList RecordIDFields
        {
            get { return _RecordIDFields; }
        }

        /// <summary>
        /// ��ȡKey Code�ֶ��б�
        /// </summary>
        public ArrayList KeyFields
        {
            get { return _KeyFields; }
        }

        /// <summary>
        /// ��ȡ����ֶ��б�
        /// </summary>
        public ArrayList ForeignKeyFields
        {
            get { return _ForeignKeyFields; }
        }

        /// <summary>
        /// ��ȡ�������е��ֶ��б�
        /// </summary>
        public ArrayList ForeignFields
        {
            get { return _ForeignFields; }
        }

        /// <summary>
        /// ��ȡ��ͨ�ֶ��б�
        /// </summary>
        public ArrayList DataFields
        {
            get { return _DataFields; }
        }

        /// <summary>
        /// ��ȡSelect����е��ֶ��б�
        /// </summary>
        public ArrayList SelectFields
        {
            get { return _SelectFields; }
        }

        /// <summary>
        /// ����ѡ�񴰿ڲ�ѯ�б�
        /// </summary>
        public ArrayList DialogFields
        {
            get { return _DialogFields; }
        }

        #endregion ��ȡ�ֶμ������б�

        #region Find\GetID\GetKeyCode\GetKeyCodes
        /// <summary>
        /// ��ѯָ��IDֵ�ļ�¼�Ƿ����
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" = " + recordID);

            return DbHelperSQL.Exists(strSQL.ToString());
        }

        /// <summary>
        /// ���ݵ�һ��Key Codeֵ��ѯ��¼�Ƿ����
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(object keyCode)
        {
            CheckDataType();
            CheckKeyFields();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ��������KeyCode��ѯ��¼�Ƿ����
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual bool Find(Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///ֵ�����������������
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT COUNT(1) FROM " + _tableName);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ����ָ��ID���KeyCode�Ƿ����
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, object keyCode)
        {
            CheckDataType();
            CheckKeyFields();
            CheckRecordIDField();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);
            strSQL.Append(" AND ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ����ָ��ID��ķ�KeyCode�Ƿ����
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, string Field, object Value)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT COUNT(1) FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);
            strSQL.Append(" AND ");
            strSQL.Append(Field);
            strSQL.Append(" = @" + Field);

            DbType DataType = DbType.Object;
            if (Value is String)
                DataType = DbType.String;
            else if (Value is DateTime)
                DataType = DbType.DateTime;
            else if (Value is decimal)
                DataType = DbType.Decimal;

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + Field, DataType, Value) };

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ����ָ��ID���KeyCodes�Ƿ����
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual bool Find(decimal recordID, Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///ֵ�����������������
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT COUNT(1) FROM " + _tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" !=" + recordID);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                strSQL.Append(" AND ");
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.Exists(strSQL.ToString(), parameters);
        }


        /// <summary>
        /// ����KeyCode��ѯ��Ӧ��ID
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual decimal GetID(Object keyCode)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + _RecordIDFieldName + " FROM " + _tableName + " WHERE ");
            strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.GetID(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ����KeyCodesȡ��ID
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual decimal GetID(Object[] keyCodes)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT " + _RecordIDFieldName + " FROM " + _tableName);
            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];

            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);
                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.GetID(strSQL.ToString(), parameters);
        }


        /// <summary>
        /// ����KeyCode��ѯָ����λ��ֵ
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(Object keyCode, string fieldName)
        {
            CheckDataType();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName + " WHERE ");
            strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };

            return DbHelperSQL.GetSingle(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ��������KeyCodes��ѯ����ָ����λ��ֵ
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(Object[] keyCodes, string fieldName)
        {
            CheckDataType();
            CheckKeyFields();

            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];

            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);
                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }

            return DbHelperSQL.GetSingle(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ���ݲ�ѯ��������ָ����λ��ֵ
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(ParamCollection _paramCollection, string fieldName)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(""));

            return DbHelperSQL.GetSingle(strSQL.ToString(), GetParams(_paramCollection));
        }

        /// <summary>
        /// ���ݲ�ѯ��������ָ����λ��ֵ
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual object GetFieldValue(ParamCollection _paramCollection, string fieldName, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT " + fieldName + " FROM " + _tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));

            return DbHelperSQL.GetSingle(strSQL.ToString(), GetParams(_paramCollection));
        }

        /// <summary>
        /// ����ID����KeyCodeֵ
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual Object GetCode(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append("SELECT " + keyField.ColumnName + " FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=" + recordID.ToString());

            return DbHelperSQL.GetSingle(strSQL.ToString());
        }

        /// <summary>
        /// ����ID����KeyCodes
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual Object[] GetCodes(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckKeyFields();

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("SELECT ");
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                strSQL.Append(keyField.ColumnName);
                strSQL.Append(",");
            }
            strSQL.Remove(strSQL.Length - 1, 1);
            strSQL.Append(" FROM " + _tableName + " WHERE " + _RecordIDFieldName + "=" + recordID.ToString());

            Object[] codes = new object[_KeyFields.Count];
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL.ToString()))
            {

                if (reader.Read())
                {
                    for (int i = 0; i < _KeyFields.Count; i++)
                    {
                        keyField = (KeyFieldAttribute)_KeyFields[i];
                        codes[i] = reader[keyField.ColumnName];
                    }
                }
                reader.Close();
            }

            return codes;

        }

        #endregion Find

        #region ����\�޸�\ɾ��

        /// <summary>
        /// ���ɲ�������Insert���
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected string GetInsertSQL(BaseObject data)
        {
            StringBuilder sbInsertField = new StringBuilder();
            StringBuilder sbInsertValue = new StringBuilder();

            _InsertFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbInsertField.Append("INSERT INTO " + _tableName + "(");
            sbInsertValue.Append(" VALUES(");

            foreach (BaseFieldAttribute baseField in _InsertFields)
            {
                sbInsertField.Append(baseField.ColumnName);
                sbInsertField.Append(",");
                //PropertyInfo propertyInfo = data.GetType().GetProperty(baseField.ColumnName);
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                //if (baseField.DefaultValue.ToUpper() == "USERID")
                //{
                //    sbInsertValue.Append(CacheHelper.getServerLoginUser().USER_ID.ToString());
                //    sbInsertValue.Append(",");
                //    continue;
                //}
                //if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                //{
                //    sbInsertValue.Append(getFieldDateFormat(DbHelperSQL.GetDBSystemDatetime(), true));
                //    sbInsertValue.Append(",");
                //    continue;
                //}
                //if (dataRow[baseField.AliasName].ToString() == "")
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        sbInsertValue.Append(baseField.DefaultValue);
                    }
                    else
                    {
                        sbInsertValue.Append("null");
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.String)
                    {
                        sbInsertValue.Append("'");
                        string strField = value.ToString();
                        strField = strField.Replace("'", "''");
                        sbInsertValue.Append(strField);
                        sbInsertValue.Append("'");
                    }
                    else if (baseField.DataType == DbType.Date)
                    {
                        //if (value ==DateTime.)
                        //{
                        //    sbInsertValue.Append("null");
                        //}
                        //else
                        //{
                        sbInsertValue.Append(getFieldDateFormat((DateTime)value, false));
                        //}

                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        //if (value is DateTime.MinValue)
                        //{
                        //    sbInsertValue.Append("null");
                        //}
                        //else
                        //{
                        sbInsertValue.Append(getFieldDateFormat((DateTime)value, true));
                        //}
                    }
                    else
                    {
                        sbInsertValue.Append(value.ToString());
                    }
                }
                sbInsertValue.Append(",");
            }
            //Field
            sbInsertField.Remove(sbInsertField.Length - 1, 1);
            sbInsertField.Append(")");
            //Value
            sbInsertValue.Remove(sbInsertValue.Length - 1, 1);
            sbInsertValue.Append(");");

            //Insert SQL Statement
            sbInsertField.Append(sbInsertValue.ToString());

            sbInsertField.Append("Select @@IDENTITY;");//ִ�к󷵻�IDֵ
            return sbInsertField.ToString();
        }


        private decimal getUser()
        {

            decimal uid = 0;

            var token = CacheHelper.GetLoginToken();

            if (!string.IsNullOrEmpty(token)) {

                var cmd = string.Format("SELECT a.USER_ID FROM USER_DEVICE a WHERE a.TOKEN = '{0}'", token);
                var rs = DbHelperSQL.GetSingle(cmd);
                if (rs != null)
                {
                    uid = (decimal)rs;
                }
            }

            return uid;

        }

        /// <summary>
        /// ����Insert���Ĳ���
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected SqlParameter[] GetInsertParams(BaseObject data)
        {
            SqlParameter[] parameters = new SqlParameter[_InsertFields.Count];
            for (int i = 0; i < _InsertFields.Count; i++)
            {
                BaseFieldAttribute baseField = (BaseFieldAttribute)_InsertFields[i];
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + baseField.ColumnName, baseField.DataType);
                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    parameter.Value = getUser();
                    parameters[i] = parameter;
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    parameter.Value = DbHelperSQL.GetDBSystemDatetime();
                    parameters[i] = parameter;
                    continue;
                }
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        parameter.Value = baseField.DefaultValue;
                    }
                    else
                    {
                        parameter.Value = System.DBNull.Value;
                    }
                }
                else
                {
                    parameter.Value = value;
                    if (baseField.DataType == DbType.Date || baseField.DataType == DbType.DateTime)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = System.DBNull.Value;
                            }
                        }
                        catch { parameter.Value = System.DBNull.Value; }
                    }
                }

                parameters[i] = parameter;
            }
            return parameters;
        }

        /// <summary>
        /// ���ɲ���������Update���
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected virtual string GetUpdateSQL(BaseObject data)
        {
            StringBuilder sbUpdateSQL = new StringBuilder();

            _UpdateFields.Sort(BaseFieldAttribute.SortBySelectSequence);

            sbUpdateSQL.Append("UPDATE " + _tableName + " SET ");

            foreach (BaseFieldAttribute baseField in _UpdateFields)
            {
                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);


                sbUpdateSQL.Append(baseField.ColumnName);
                sbUpdateSQL.Append(" = ");

                //if (baseField.DefaultValue.ToUpper() == "USERID")
                //{
                //    sbUpdateSQL.Append(CacheHelper.getServerLoginUser().USER_ID.ToString());
                //    sbUpdateSQL.Append(",");
                //    continue;
                //}
                //if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                //{
                //    sbUpdateSQL.Append(getFieldDateFormat(DbHelperSQL.GetDBSystemDatetime(), true));
                //    sbUpdateSQL.Append(",");
                //    continue;
                //}
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        sbUpdateSQL.Append(baseField.DefaultValue);
                    }
                    else
                    {
                        sbUpdateSQL.Append("null");
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.String)
                    {
                        sbUpdateSQL.Append("'");
                        string strField = value.ToString();
                        strField = strField.Replace("'", "''");
                        sbUpdateSQL.Append(strField);
                        sbUpdateSQL.Append("'");
                    }
                    else if (baseField.DataType == DbType.Date)
                    {
                        //if (value == DateTime.MinValue)
                        //{
                        //    sbUpdateSQL.Append("null");
                        //}
                        //else
                        //{
                        sbUpdateSQL.Append(getFieldDateFormat((DateTime)value, false));
                        //}

                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        //if (value == DateTime.MinValue)
                        //{
                        //    sbUpdateSQL.Append("null");
                        //}
                        //else
                        //{
                        sbUpdateSQL.Append(getFieldDateFormat((DateTime)value, true));
                        //}
                    }
                    else
                    {
                        sbUpdateSQL.Append(value.ToString());
                    }
                }
                sbUpdateSQL.Append(",");
            }
            sbUpdateSQL.Remove(sbUpdateSQL.Length - 1, 1);
            sbUpdateSQL.Append(" WHERE ");
            sbUpdateSQL.Append(_RecordIDFieldName);
            sbUpdateSQL.Append(" = ");
            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);
            sbUpdateSQL.Append(idvalue.ToString());

            return sbUpdateSQL.ToString();
        }


        /// <summary>
        /// ����Update���Ĳ���
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected SqlParameter[] GetUpdateParams(BaseObject data)
        {
            SqlParameter[] parameters = new SqlParameter[_UpdateFields.Count + 1];
            for (int i = 0; i < _UpdateFields.Count; i++)
            {
                BaseFieldAttribute baseField = (BaseFieldAttribute)_UpdateFields[i];

                PropertyInfo propertyInfo = _dataType.GetProperty(baseField.ColumnName);
                object value = propertyInfo.GetValue(data, null);

                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + baseField.ColumnName, baseField.DataType);
                if (baseField.DefaultValue.ToUpper() == "USERID")
                {
                    parameter.Value = getUser();
                    parameters[i] = parameter;
                    continue;
                }
                if (baseField.DefaultValue.ToUpper() == "SYSDATE")
                {
                    parameter.Value = DbHelperSQL.GetDBSystemDatetime();
                    parameters[i] = parameter;
                    continue;
                }
                if (value == null)
                {
                    if (baseField.DefaultValue != "")
                    {
                        parameter.Value = baseField.DefaultValue;
                    }
                    else
                    {
                        parameter.Value = System.DBNull.Value;
                    }
                }
                else
                {
                    if (baseField.DataType == DbType.Date)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                            {
                                parameter.Value = value;
                            }

                        }
                        catch { parameter.Value = DBNull.Value; }
                    }
                    else if (baseField.DataType == DbType.DateTime)
                    {
                        try
                        {
                            if ((DateTime)value == DateTime.MinValue)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                            {
                                parameter.Value = value;
                            }
                        }
                        catch { parameter.Value = DBNull.Value; }
                    }
                    else
                    {
                        parameter.Value = value;
                    }

                }
                parameters[i] = parameter;
            }
            ///ָ��ID��Param
            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);

            SqlParameter paramId = DbHelperSQL.CreateDataParameter("@" + _RecordIDFieldName, DbType.Decimal);
            paramId.Value = idvalue;
            parameters[_UpdateFields.Count] = paramId;

            return parameters;
        }

        /// <summary>
        /// ����Delete���
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        protected virtual string GetDeleteSQL(BaseObject data)
        {
            StringBuilder sbDeleteSQL = new StringBuilder();
            sbDeleteSQL.Append("DELETE FROM ");
            sbDeleteSQL.Append(_tableName);
            sbDeleteSQL.Append(" WHERE ");
            sbDeleteSQL.Append(_RecordIDFieldName);
            sbDeleteSQL.Append(" = ");

            PropertyInfo idpropertyInfo = _dataType.GetProperty(_RecordIDFieldName);
            object idvalue = idpropertyInfo.GetValue(data, null);
            sbDeleteSQL.Append(idvalue.ToString());

            //sbDeleteSQL.Append(dataRow[_RecordIDFieldName, DataRowVersion.Original].ToString());
            return sbDeleteSQL.ToString();
        }


        /// <summary>
        /// ʹ�ò����ķ�ʽ�������ݼ�
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool UpdateAllByParams(BaseList masterData)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            var SQLCmds = new List<SqlCommondItem>();
            foreach (BaseObject instance in masterData)
            {
                if (instance.CurModel == DealModel.Delete)
                {
                    var sqlStr = GetDeleteSQL(instance);
                    SQLCmds.Add(new SqlCommondItem { Cmd = sqlStr });
                }
                else if (instance.CurModel == DealModel.Modify)
                {
                    SqlParameter[] parms = GetUpdateParams(instance);
                    SQLCmds.Add(new SqlCommondItem { Cmd = _UpdateCMD, Params = parms });
                }
                else if (instance.CurModel == DealModel.New)
                {
                    SqlParameter[] parms = GetInsertParams(instance);
                    SQLCmds.Add(new SqlCommondItem { Cmd = _InsertCMD, Params = parms }); ;
                }
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }

        /// <summary>
        /// ʹ��SQL���ķ�ʽ�������ݼ�
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool UpdateAllBySQL(BaseList masterData)
        {
            var SQLCmds = new ArrayList();
            foreach (BaseObject instance in masterData)
            {

                if (instance.CurModel == DealModel.Delete)
                {
                    var sqlStr = GetDeleteSQL(instance);
                    SQLCmds.Add(sqlStr);
                }
                else if (instance.CurModel == DealModel.Modify)
                {
                    string sqlStr = GetUpdateSQL(instance);
                    SQLCmds.Add(sqlStr);
                }
                else if (instance.CurModel == DealModel.New)
                {
                    string sqlStr = GetInsertSQL(instance);
                    SQLCmds.Add(sqlStr);
                }
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }

        /// <summary>
        /// �ò�����ʽ��������
        /// </summary>
        /// <param name="masterData">���ݼ���</param>
        /// <returns></returns>
        public virtual bool InsertByParams(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckInsertFields();
            BaseObject instance;
            var SQLCmds = new List<SqlCommondItem>();
            for (int i = 0; i < masterData.Count; i++)
            {
                instance = masterData[i];
                SqlParameter[] parms = GetInsertParams(instance);
                SQLCmds.Add(new SqlCommondItem { Cmd = _InsertCMD, Params = parms }); ;
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }


        /// <summary>
        /// �������ӱ�
        /// </summary>
        /// <param name="masterData">���ݼ���</param>
        /// <returns></returns>
        public virtual bool UpdateMasterDetail(BaseObject masterRow, params BaseList[] detaiList)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckInsertFields();

            if (masterRow == null)
                return false;

            var SQLCmds = new List<SqlCommondItem>();
            if (masterRow.CurModel == DealModel.New)
            {
                SqlParameter[] parms = GetInsertParams(masterRow);
                SQLCmds.Add(new SqlCommondItem { Cmd = _InsertCMD, Params = parms }); ;
            }
            else if (masterRow.CurModel == DealModel.Modify)
            {
                SqlParameter[] parms = GetUpdateParams(masterRow);
                SQLCmds.Add(new SqlCommondItem { Cmd = _UpdateCMD, Params = parms });
            }

            if (detaiList != null && detaiList.Length > 0)
            {
                foreach (var table in detaiList)
                {

                    if (table != null && table.Count > 0)
                    {
                        var dataType = table[0].GetType();
                        var dal = DALObject.Get(dataType);
                        foreach (var row in table)
                        {
                            if (row.CurModel == DealModel.New)
                            {
                                var cmd = dal._InsertCMD;
                                var ps = dal.GetInsertParams(row);

                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd, Params = ps });
                            }
                            else if (row.CurModel == DealModel.Modify)
                            {
                                var cmd = dal._UpdateCMD;
                                var ps = dal.GetUpdateParams(row);

                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd, Params = ps });
                            }
                            else if (row.CurModel == DealModel.Delete)
                            {
                                var cmd = dal.GetDeleteSQL(row);
                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd });
                            }
                        }
                    }
                }

            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }


        /// <summary>
        /// �������ӱ�
        /// </summary>
        /// <param name="masterData">���ݼ���</param>
        /// <returns></returns>
        public static bool UpdateMultiData(params BaseList[] detaiList)
        {
            var SQLCmds = new List<SqlCommondItem>();


            if (detaiList != null && detaiList.Length > 0)
            {
                foreach (var table in detaiList)
                {

                    if (table != null && table.Count > 0)
                    {
                        var dataType = table[0].GetType();
                        var dal = DALObject.Get(dataType);
                        foreach (var row in table)
                        {
                            if (row.CurModel == DealModel.New)
                            {
                                var cmd = dal._InsertCMD;
                                var ps = dal.GetInsertParams(row);

                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd, Params = ps });
                            }
                            else if (row.CurModel == DealModel.Modify)
                            {
                                var cmd = dal._UpdateCMD;
                                var ps = dal.GetUpdateParams(row);

                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd, Params = ps });
                            }
                            else if (row.CurModel == DealModel.Delete)
                            {
                                var cmd = dal.GetDeleteSQL(row);
                                SQLCmds.Add(new SqlCommondItem { Cmd = cmd });
                            }
                        }
                    }
                }

            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }



        /// <summary>
        /// ����һ��ʵ�����ݣ�������AUTO_ID
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual decimal AddInstanceByParam(BaseObject _data)
        {
            try
            {
                SqlParameter[] parms = GetInsertParams(_data);
                _data.ID = DbHelperSQL.ExecuteInsert(_InsertCMD, parms);

                return _data.ID;
            }
            catch (Exception e) { LogHelper.Log("ERROR  MODIFY(DALObject) : " + e.Message); return -1; }
        }

        /// <summary>
        /// ��SQL��䷽ʽ��������
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool InsertBySQL(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckInsertFields();

            BaseObject instance;
            var SQLCmds = new ArrayList();
            for (int i = 0; i < masterData.Count; i++)
            {
                instance = masterData[i];
                string sqlStr = GetInsertSQL(instance);
                SQLCmds.Add(sqlStr);
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds); ;
        }

        /// <summary>
        /// ��SQL��䷽ʽ�������ݣ�����AUTO_ID
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual decimal AddInstanceBySQL(BaseObject _data)
        {
            string sqlStr = GetInsertSQL(_data);

            //return DbHelperSQL.ExecuteInsert(sqlStr);
            _data.ID = DbHelperSQL.ExecuteInsert(sqlStr);
            return _data.ID;
        }

        /// <summary>
        /// ʹ�ò�����ʽ��������
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool UpdateByParams(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckUpdateFields();

            var SQLCmds = new List<SqlCommondItem>();
            for (int i = 0; i < masterData.Count; i++)
            {
                var instance = masterData[i];
                SqlParameter[] parms = GetInsertParams(instance);
                SQLCmds.Add(new SqlCommondItem { Cmd = _UpdateCMD, Params = parms }); ;
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }

        /// <summary>
        /// ��������ʽ�޸�ʵ������
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual int UpdateInstanceByParam(BaseObject _data)
        {
            try
            {
                SqlParameter[] parms = GetUpdateParams(_data);

                return DbHelperSQL.ExecuteSql(_UpdateCMD, parms);
            }
            catch (Exception e) { LogHelper.Log("ERROR  ADD(DALObject) : " + e.Message); return -1; }
        }

        /// <summary>
        /// ʹ��SQL��䷽ʽ��������
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool UpdateBySQL(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            CheckUpdateFields();
            BaseObject instance;
            var SQLCmds = new ArrayList();
            for (int i = 0; i < masterData.Count; i++)
            {
                instance = masterData[i];
                string sqlStr = GetUpdateSQL(instance);
                SQLCmds.Add(sqlStr);
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }

        /// <summary>
        /// ��SQL���ķ�ʽ�޸�ʵ������
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public virtual int UpdateInstanceBySQL(BaseObject _data)
        {
            string sqlStr = GetUpdateSQL(_data);

            return DbHelperSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// ɾ��ָ������
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        public virtual bool Delete(BaseList masterData)
        {
            CheckDataType();
            CheckRecordIDField();
            var SQLCmds = new ArrayList();
            for (int i = 0; i < masterData.Count; i++)
            {
                string sqlStr = GetDeleteSQL(masterData[i]);
                SQLCmds.Add(sqlStr);
            }
            return DbHelperSQL.ExecuteSqlTran(SQLCmds);
        }
        /// <summary>
        /// ɾ��ʵ������
        /// </summary>
        /// <param name="_data"></param>
        public virtual int DeleteInstance(BaseObject _data)
        {
            string sqlStr = GetDeleteSQL(_data);
            return DbHelperSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// ͨ��IDɾ����¼
        /// </summary>
        /// <param name="recordID"></param>
        public virtual int Delete(decimal recordID)
        {
            CheckDataType();
            CheckRecordIDField();

            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(_RecordIDFieldName);
            strSQL.Append(" = ");
            strSQL.Append(recordID.ToString());
            return DbHelperSQL.ExecuteSql(strSQL.ToString());
        }

        /// <summary>
        /// ���ݵ�һ��Key Codeֵɾ����¼
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public virtual int Delete(object keyCode)
        {
            CheckDataType();
            CheckKeyFields();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            strSQL.Append(" WHERE ");
            strSQL.Append(keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCode, keyField.IsNullable) };
            return DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
        }



        /// <summary>
        /// ��������KeyCodeֵɾ����¼
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        public virtual int Delete(Object[] keyCodes)
        {
            CheckDataType();
            CheckKeyFields();

            ///ֵ�����������������
            if (keyCodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();
            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField;

            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keyCodes[i], keyField.IsNullable);

            }
            return DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
        }

        /// <summary>
        /// ������ɾ������
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <returns></returns>
        public virtual int Delete(ParamCollection _paramCollection)
        {
            CheckDataType();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM ");
            strSQL.Append(_tableName);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);

            return DbHelperSQL.ExecuteSql(strSQL.ToString(), GetParams(_paramCollection)); ;
        }




        #endregion ����\�޸�\ɾ��

        #region ��ѯ������ǿ�������ݼ�

        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        public virtual BaseList Select()
        {
            ParamCollection criteria = new ParamCollection();
            return this.Select(criteria, "");
        }

        /// <summary>
        /// ����������ѯ����
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection criteria)
        {
            return this.Select(criteria, "");
        }

        /// <summary>
        /// ����ID��ѯ��¼��
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        public virtual BaseList Select(decimal recordID)
        {
            return this.Select(recordID, _tableAliasName + "." + _RecordIDFieldName);
        }

        /// <summary>
        /// ����ID��ѯ��¼��
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(decimal recordID, string sort)
        {
            ParamCollection criteria = new ParamCollection();
            criteria.Clause = _tableAliasName + "." + _RecordIDFieldName + "=" + recordID.ToString();
            return this.Select(criteria, sort);
        }


        /// <summary>
        /// ���ز�ѯ�����
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual Int32 GetCount(ParamCollection _paramCollection)
        {
            CheckDataType();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(GetCountCommand());
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }


            return DbHelperSQL.GetCount(sqlstr, GetParams(_paramCollection));
        }

        /// <summary>
        /// ���ز�ѯ�����
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual decimal GetSum(ParamCollection _paramCollection, string sumField)
        {
            CheckDataType();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(GetSumCommand(sumField));
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }


            return DbHelperSQL.GetSum(sqlstr, GetParams(_paramCollection));
        }


        /// <summary>
        /// ��ȡ�����ѯ�����ļ�¼���ŵ���¼��
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort)
        {
            try
            {
                CheckDataType();
                CheckRecordIDField();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append(_SelectCMD);
                string whereClause = _paramCollection.Clause;
                if (whereClause != "")
                {
                    whereClause = " WHERE " + whereClause;
                }
                strSQL.Append(whereClause);

                strSQL.Append(getSortClause(sort));

                string sqlstr = strSQL.ToString();

                if (_paramCollection.ParaData == null)
                {
                    _paramCollection.ParaData = selectPara;
                }
                else if (_paramCollection.ParaData.Length < selectPara.Length)
                {
                    _paramCollection.ParaData = selectPara;
                }

                if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
                {
                    sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
                }

                return getDataList(sqlstr, GetParams(_paramCollection));
            }
            catch (Exception e) { LogHelper.Log("ERROR   SELECT(DAL) : " + e.TargetSite.ToString() + " " + e.Message); return new BaseList(); }
        }

        /// <summary>
        /// ��ȡ�����ѯ�����ļ�¼���ŵ���¼��
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort, int indexStart, int indexEnd)
        {
            try
            {

                CheckDataType();
                CheckRecordIDField();
                StringBuilder strSQL = new StringBuilder();
                string sqlstr = "";
                string whereClause = _paramCollection.Clause;
                if (whereClause != "")
                {
                    whereClause = " WHERE " + whereClause;
                }
                strSQL.Append(_SelectPageCountCMD);

                int i = selectPara.Length;

                if (_paramCollection.ParaData == null)
                {
                    _paramCollection.ParaData = selectPara;
                }
                else if (_paramCollection.ParaData.Length != selectPara.Length)
                {
                    _paramCollection.ParaData = selectPara;
                }
                if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
                {
                    sqlstr = String.Format(strSQL.ToString(), _paramCollection.ParaData[0].ToString(), getSortClause(sort), whereClause, indexStart, indexEnd);
                }
                else
                {
                    sqlstr = String.Format(strSQL.ToString(), 0, getSortClause(sort), whereClause, indexStart, indexEnd);
                }
                return getDataList(sqlstr, GetParams(_paramCollection));
            }
            catch (Exception e) { LogHelper.Log("ERROR   SELECT(DAL) : " + e.TargetSite.ToString() + " " + e.Message); return new BaseList(); }
        }


        /// <summary>
        /// ����GROUP BY���Ĳ�ѯ���
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="grouby"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList SelectGroup(ParamCollection _paramCollection, string grouby, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(GetGroupCommand());
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(" GROUP BY " + grouby);
            strSQL.Append(getSortClause(sort));

            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }

            return getDataList(sqlstr, GetParams(_paramCollection));
        }

        /// <summary>
        /// ���ظ���Dialog�ֶ���������
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList SelectDialog(ParamCollection _paramCollection, string sort)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(_SelectDialogCMD);
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = dialogPara;
            }
            else if (_paramCollection.ParaData.Length != dialogPara.Length)
            {
                _paramCollection.ParaData = dialogPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }
            return getDataListforDialog(sqlstr, GetParams(_paramCollection));
        }



        /// <summary>
        /// ����ǰN����¼
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public virtual BaseList Select(ParamCollection _paramCollection, string sort, Int16 topCount)
        {
            CheckDataType();
            CheckRecordIDField();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(InitTopSelectCommand(topCount));
            string whereClause = _paramCollection.Clause;
            if (whereClause != "")
            {
                whereClause = " WHERE " + whereClause;
            }
            strSQL.Append(whereClause);
            strSQL.Append(getSortClause(sort));
            string sqlstr = strSQL.ToString();
            if (_paramCollection.ParaData == null)
            {
                _paramCollection.ParaData = selectPara;
            }
            else if (_paramCollection.ParaData.Length != selectPara.Length)
            {
                _paramCollection.ParaData = selectPara;
            }

            if (_paramCollection.ParaData != null && _paramCollection.ParaData.Length > 0)
            {
                sqlstr = String.Format(sqlstr, _paramCollection.ParaData);
            }
            return getDataList(sqlstr, GetParams(_paramCollection));
        }

        /// <summary>
        /// ���ط��͵ļ���
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public BaseList getDataList(string sql, params SqlParameter[] cmdParms)
        {
            BaseList dataList = new BaseList();
            StringBuilder builder = new StringBuilder();
            using (IDataReader dataReader = DbHelperSQL.getReader(sql, cmdParms))
            {
                while (dataReader.Read())
                {
                    BaseObject data = Activator.CreateInstance(_dataType) as BaseObject;
                    int M = data.CHECK_CODE;
                    data.CurModel = DealModel.None;
                    for (int i = 0; i < _SelectFields.Count; i++)
                    {
                        BaseFieldAttribute baseField = (BaseFieldAttribute)_SelectFields[i];
                        PropertyInfo propertyInfo = _dataType.GetProperty(baseField.AliasName);
                        if (dataReader[baseField.AliasName] != System.DBNull.Value)
                        {
                            try
                            {
                                propertyInfo.SetValue(data, dataReader[baseField.AliasName], null);
                            }
                            catch (Exception e)
                            {
                                builder.AppendLine("ERROR getDataList(DAL) : " + baseField.AliasName + "  " + e.Message);
                            }
                        }
                    }
                    dataList.Add(data);
                }
            }
            if (builder.Length > 0)
            {
                LogHelper.Log(builder.ToString());
            }
            return dataList;
        }

        /// <summary>
        /// ���ظ���Dialog�ֶ����õ�Datalist
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public BaseList getDataListforDialog(string sql, params SqlParameter[] cmdParms)
        {
            BaseList dataList = new BaseList();

            using (IDataReader dataReader = DbHelperSQL.getReader(sql, cmdParms))
            {
                while (dataReader.Read())
                {
                    BaseObject data = Activator.CreateInstance(_dataType) as BaseObject;
                    data.CurModel = DealModel.None;
                    for (int i = 0; i < _DialogFields.Count; i++)
                    {
                        BaseFieldAttribute baseField = (BaseFieldAttribute)_DialogFields[i];
                        PropertyInfo propertyInfo = _dataType.GetProperty(baseField.AliasName);
                        if (dataReader[baseField.AliasName] != System.DBNull.Value)
                        {
                            propertyInfo.SetValue(data, dataReader[baseField.AliasName], null);
                        }

                    }
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        /// <summary>
        /// ����KeyCodeֵ��ѯ�����
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public virtual BaseList Select(object keycode)
        {
            return this.Select(keycode, "");
        }

        /// <summary>
        /// ����KeyCodeֵ��ѯ�����
        /// </summary>
        /// <param name="keycode"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(object keycode, string sort)
        {
            CheckDataType();
            CheckKeyFields();
            StringBuilder strSQL = new StringBuilder();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append(_SelectCMD);
            strSQL.Append(" WHERE ");
            strSQL.Append(_tableAliasName + "." + keyField.ColumnName);
            strSQL.Append(" = @" + keyField.ColumnName);

            SqlParameter[] parameters = { DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keycode, keyField.IsNullable) };

            string sqlstr = strSQL.ToString();
            if (selectPara != null && selectPara.Length > 0)
            {
                sqlstr = String.Format(sqlstr, selectPara);
            }

            return getDataList(sqlstr, parameters);

        }

        /// <summary>
        /// ����KeyCodeֵ��ѯ�����
        /// </summary>
        /// <param name="keycodes"></param>
        /// <returns></returns>
        public virtual BaseList Select(object[] keycodes)
        {
            return this.Select(keycodes, "");
        }

        /// <summary>
        /// ����KeyCodeֵ��ѯ�����
        /// </summary>
        /// <param name="keycodes"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual BaseList Select(object[] keycodes, string sort)
        {
            CheckDataType();
            CheckKeyFields();

            ///ֵ�����������������
            if (keycodes.Length != _KeyFields.Count)
                throw new Exception(_errMsg);

            StringBuilder strSQL = new StringBuilder();

            _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
            KeyFieldAttribute keyField = (KeyFieldAttribute)_KeyFields[0];

            strSQL.Append(_SelectCMD);

            SqlParameter[] parameters = new SqlParameter[_KeyFields.Count];
            for (int i = 0; i < _KeyFields.Count; i++)
            {
                keyField = (KeyFieldAttribute)_KeyFields[i];
                if (i == 0)
                {
                    strSQL.Append(" WHERE ");
                }
                else
                {
                    strSQL.Append(" AND ");
                }
                strSQL.Append(_tableAliasName + "." + keyField.ColumnName + "=@" + keyField.ColumnName);

                parameters[i] = DbHelperSQL.CreateDataParameter("@" + keyField.ColumnName, keyField.DataType, keycodes[i], keyField.IsNullable);

            }

            //BaseData dsData = Activator.CreateInstance(_dataType) as BaseData;
            //DbHelperSQL.Fill(strSQL.ToString(), dsData, _tableAliasName, parameters);
            string sqlstr = strSQL.ToString();
            if (selectPara != null && selectPara.Length > 0)
            {
                sqlstr = String.Format(sqlstr, selectPara);
            }
            return getDataList(sqlstr, parameters);

        }

        #endregion ��ѯ������ǿ�������ݼ�

        #region Utility

        /// <summary>
        /// ������������Ƿ�ΪNULL
        /// </summary>
        protected void CheckDataType()
        {
            if (_dataType == null)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// ���Record ID�ֶ��Ƿ����
        /// </summary>
        protected void CheckRecordIDField()
        {
            if (_RecordIDFieldName == "")
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// ���Key Fields�ֶ��Ƿ����
        /// </summary>
        protected void CheckKeyFields()
        {
            if (_KeyFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// ����Ƿ���������ֶ�
        /// </summary>
        protected void CheckInsertFields()
        {
            if (_InsertFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// ����Ƿ���ڸ����ֶ�
        /// </summary>
        protected void CheckUpdateFields()
        {
            if (_UpdateFields.Count <= 0)
                throw new Exception(_errMsg);
        }

        /// <summary>
        /// ��ȡ�����Ӿ�
        /// </summary>
        /// <param name="sord"></param>
        /// <returns></returns>
        private string getSortClause(string sort)
        {
            StringBuilder sortSQL = new StringBuilder();
            sortSQL.Append(" ORDER BY ");
            if (sort == "" || sort == null)
            {
                if (_KeyFields.Count > 0)//�������KeyCode����KeyCode����
                {
                    _KeyFields.Sort(KeyFieldAttribute.SortByKeySequence);
                    KeyFieldAttribute keyField;
                    for (int i = 0; i < _KeyFields.Count; i++)
                    {
                        keyField = (KeyFieldAttribute)_KeyFields[i];
                        sortSQL.Append(_tableAliasName + "." + keyField.ColumnName);
                        sortSQL.Append(",");
                    }
                    sortSQL.Remove(sortSQL.Length - 1, 1);
                }
                else
                {
                    sortSQL.Append(_tableAliasName + "." + _RecordIDFieldName);
                }
            }
            else
            {
                sortSQL.Append(sort);
            }
            sortSQL.Append("    ");
            return sortSQL.ToString();
        }

        private string getRowNumClause(int indexStart, int indexEnd)
        {
            StringBuilder ClauesSQL = new StringBuilder();
            ClauesSQL.Append("AND ");
            ClauesSQL.Append(_tableName);
            ClauesSQL.Append(".ROW_NUM ");
            ClauesSQL.Append(" BETWEEN ");
            ClauesSQL.Append(" {0} ");
            ClauesSQL.Append(" AND ");
            ClauesSQL.Append(" {1} ");
            return String.Format(ClauesSQL.ToString(), indexStart, indexEnd);
        }

        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="_ParamCollection"></param>
        /// <returns></returns>
        public SqlParameter[] GetParams(ParamCollection _ParamCollection)
        {
            SqlParameter[] parameters = new SqlParameter[_ParamCollection.Count];
            for (int i = 0; i < _ParamCollection.Count; i++)
            {
                SqlParameter parameter = DbHelperSQL.CreateDataParameter("@" + _ParamCollection[i].ParamName, _ParamCollection[i].DataType, _ParamCollection[i].Value);
                parameters[i] = parameter;
            }
            return parameters;
        }

        /// <summary>
        /// ���ظ�ʽ��֮�����ڲ������ݿ������ʱ���ַ���
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="isTime"></param>
        /// <returns></returns>
        public static string getFieldDateFormat(DateTime datetime, bool isTime)
        {
            string dateFormate = "";
            if (isTime)
            {
                dateFormate = datetime.ToString("'" + Const.datetimeFormat + "'");
            }
            else
            {
                dateFormate = datetime.ToString("'" + Const.dateFormat + "'");
            }
            return dateFormate;
        }

        #endregion

    }
}
