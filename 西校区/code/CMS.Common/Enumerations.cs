using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMS.Core.Common
{
    /// <summary>
    /// UI�н���ؼ���ֵ�Ƿ��������Լ���Ӧ����ɫ�趨
    /// </summary>
    [Serializable]
    public enum FieldInputType
    {
        /// <summary>
        /// ��
        /// </summary>
        None = 0,
        /// <summary>
        /// �ؼ�����λ
        /// </summary>
        KeyField = 1,
        /// <summary>
        /// ������λ
        /// </summary>
        Required = 2,
        /// <summary>
        /// ��ѡ��λ
        /// </summary>
        Option = 3,
        /// <summary>
        /// ֻ����λ
        /// </summary>
        ReadOnly = 4,
        /// <summary>
        /// ֻ������Ҫ�ǿ�	
        /// </summary>
        ReadRequired = 5,
        /// <summary>
        /// �û��Զ�����λ��ɫ
        /// </summary>
        UserOption1 = 6,
        /// <summary>
        /// �û��Զ�����λ��ɫ
        /// </summary>
        UserOption2 = 7,

        /// <summary>
        /// ������λ��ǩ��ɫ
        /// </summary>
        Search = 8
    }

    /// <summary>
    /// Field�������������
    /// </summary>
    [Serializable]
    public enum TableJoinType
    {
        /// <summary>
        /// ������
        /// </summary>
        None = 0,
        /// <summary>
        /// INNER JOIN
        /// </summary>
        InnerJoin = 1,
        /// <summary>
        /// LEFT OUT JOIN
        /// </summary>
        LeftOuterJoin = 2,
        /// <summary>
        /// RIGHT OUT JOIN
        /// </summary>
        RightOuterJoin = 3,
        /// <summary>
        /// FULL OUT JOIN
        /// </summary>
        FullOuterJoin = 4
    }

    /// <summary>
    /// UI�����пؼ���ֵ��Ҫ������֤���
    /// </summary>
    [Serializable]
    public enum FieldRegType
    {
        /// <summary>
        /// ������֤
        /// </summary>
        None = 0,
        /// <summary>
        /// ��Ч��ֵ��֤
        /// </summary>
        DecimalReg = 1,
        /// <summary>
        /// ��������ֵ
        /// </summary>
        DecimalSignReg = 2,
        /// <summary>
        /// ��������֤
        /// </summary>
        NumberReg = 3,
        /// <summary>
        /// ����������
        /// </summary>
        NumberSignReg = 4,
        /// <summary>
        /// �ʼ���ַ��֤
        /// </summary>
        EmailReg = 5,
        /// <summary>
        /// ����ʱ��ֵ
        /// </summary>
        DateTimeReg = 6,
        /// <summary>
        /// �绰����ֵ
        /// </summary>
        PhoneReg = 7,
        /// <summary>
        /// ���ֵ֤
        /// </summary>
        IdCardReg = 8
    }

    /// <summary>
    /// �������ģʽ
    /// </summary>
    [Serializable]
    public enum DealModel
    {
        /// <summary>
        /// ��ѯ
        /// </summary>
        Search = 0,
        /// <summary>
        /// ����
        /// </summary>
        New = 1,
        /// <summary>
        /// �޸�
        /// </summary>
        Modify = 2,
        /// <summary>
        /// ɾ��
        /// </summary>
        Delete = 3,
        /// <summary>
        /// �Զ���
        /// </summary>
        None = 4
    }

    /// <summary>
    /// �Ӵ���Ļ�������
    /// </summary>
    [Serializable]
    public enum TabPageType
    {
        /// <summary>
        /// Master����ά��
        /// </summary>
        MasterPage = 0,
        /// <summary>
        /// Detail����ά��
        /// </summary>
        DetailPage = 1,
        /// <summary>
        /// ���ϵ������
        /// </summary>
        ImportPage = 2,
        /// <summary>
        /// �������
        /// </summary>
        ReportPage = 3,
        /// <summary>
        /// �û��Զ���
        /// </summary>
        None = 4
    }

    /// <summary>
    /// Ԥ��Ȩ��
    /// </summary>
    [Serializable]
    public class Operation
    {
        /// <summary>
        /// Ŀ¼Ȩ��
        /// </summary>
        public const decimal Cate = 10;
        /// <summary>
        /// ģ��Ȩ��
        /// </summary>
        public const decimal Module = 20;
        /// <summary>
        /// ��ѯ
        /// </summary>
        public const decimal Search = 30;
        /// <summary>
        /// ����
        /// </summary>
        public const decimal Add = 31;
        /// <summary>
        /// �޸�
        /// </summary>
        public const decimal Modify = 32;
        /// <summary>
        /// ɾ��
        /// </summary>
        public const decimal Delete = 33;
        /// <summary>
        /// ����
        /// </summary>
        public const decimal Save = 34;
        /// <summary>
        /// ִ��
        /// </summary>
        public const decimal Execute = 35;
        /// <summary>
        /// ����
        /// </summary>
        public const decimal Import = 40;
        /// <summary>
        /// ����
        /// </summary>
        public const decimal Export = 41;
        /// <summary>
        /// ��ӡ
        /// </summary>
        public const decimal Print = 50;
        /// <summary>
        /// Ԥ������1
        /// </summary>
        public const decimal Operation1 = 60;
        /// <summary>
        /// Ԥ������2
        /// </summary>
        public const decimal Operation2 = 61;
        /// <summary>
        /// Ԥ������3
        /// </summary>
        public const decimal Operation3 = 62;
        /// <summary>
        /// Ԥ������4
        /// </summary>
        public const decimal Operation4 = 63;
    }

    /// <summary>
    /// json ״̬��
    /// </summary>
    public class JsonCodes
    {
        /// <summary>
        /// �ɹ�
        /// </summary>
        public static readonly int SUCCESS = 1;

        /// <summary>
        /// ʧ��
        /// </summary>
        public static readonly int FAIL = 0;

        /// <summary>
        /// ��Ȩ����
        /// </summary>
        public static readonly int TOKEN_TIMEOUT = 1000;

        /// <summary>
        /// û��Ȩ��
        /// </summary>
        public static readonly int NON_AUTHORITY = 2000;
    }

    /// <summary>
    /// ��ʾ�ӿڷ���״̬���ܵ�ö��
    /// ��������10001-19999 
    /// �û�����20001-29999
    /// ҵ�����30001-39999
    /// ϵͳ����40001-49999
    /// ���ݴ���50001-599999
    /// �ӿڴ���60001-69999
    /// Ȩ�޴���70001-79999
    /// </summary>
    public enum StatusType
    {
        [Text("�����ɹ���")]
        Success = 200,
        [Text("����ʧ�ܡ�")]
        Error = -1,
        [Text("����������")]
        ServerError = 1000,
        [Text("������Ч")]
        ParameterInvalid = 10001,
        [Text("����Ϊ��")]
        ParameterNull = 10002,
        [Text("�������ʹ���")]
        ParameterTypeError = 10003,
        [Text("����ȱʧ")]
        ParameterMiss = 10004,
        [Text("�û�δ��¼")]
        UserNotLogin = 20001,
        [Text("�˺Ų����ڻ��������")]
        AccountError = 20002,
        [Text("�˺��ѱ�����")]
        UserDisabled = 20003,
        [Text("�û�������")]
        UserNotExits = 20004,
        [Text("�û��Ѵ���")]
        UserExits = 20005,
        [Text("ĳҵ���������")]
        BusinessProblems = 30001,
        [Text("ϵͳ��æ, ���Ժ�����")]
        SystemBusy = 40001,
        [Text("����δ�ҵ�")]
        DataNotFound = 50001,
        [Text("��������")]
        DataError = 50002,
        [Text("�����Ѵ���")]
        DataExits = 50003,
        [Text("��ѯ����")]
        QueryError = 50004,
        [Text("�ڲ�ϵͳ�ӿڵ����쳣")]
        InternalInvokeException = 60001,
        [Text("�ⲿϵͳ�ӿڵ����쳣")]
        ExternalInvokeException = 60002,
        [Text("�ýӿڽ�ֹ����")]
        BlockingAccess = 60003,
        [Text("�ӿڵ�ַ��Ч")]
        URLExpireError = 60004,
        [Text("�ӿ�����ʱ")]
        RequestTimeout = 60005,
        [Text("�ӿڸ��ع���")]
        ExcessiveInterfaceLoad = 60006,
        [Text("��Ȩ�޷���")]
        UnauthorizedAccess = 70001
    }
}
