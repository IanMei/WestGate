using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Common {

    /// <summary>
    /// �����ڱȽ�2���ַ������ƶ�
    /// </summary>

    public class StringCompute {

        #region ˽�б���
        /// <summary>
        /// �ַ���1
        /// </summary>
        private char[] _ArrChar1;
        /// <summary>
        /// �ַ���2
        /// </summary>
        private char[] _ArrChar2;
        /// <summary>
        /// ͳ�ƽ��
        /// </summary>
        private StringComputeResult _Result;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        private DateTime _BeginTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _EndTime;
        /// <summary>
        /// �������
        /// </summary>
        private int _ComputeTimes;
        /// <summary>
        /// �㷨����
        /// </summary>
        private int[,] _Matrix;
        /// <summary>
        /// ��������
        /// </summary>
        private int _Column;
        /// <summary>
        /// ��������
        /// </summary>
        private int _Row;
        #endregion

        #region ����
        public StringComputeResult ComputeResult
        {
            get { return _Result; }
        }
        #endregion

        #region ���캯��
        public StringCompute(string str1, string str2)
        {
            this.StringComputeInit(str1, str2);
        }
        public StringCompute()
        {
        }
        #endregion

        #region �㷨ʵ��
        /// <summary>
        /// ��ʼ���㷨������Ϣ
        /// </summary>
        /// <param name="str1">�ַ���1</param>
        /// <param name="str2">�ַ���2</param>
        private void StringComputeInit(string str1, string str2)
        {
            _ArrChar1 = str1.ToCharArray();
            _ArrChar2 = str2.ToCharArray();
            _Result = new StringComputeResult();
            _ComputeTimes = 0;
            _Row = _ArrChar1.Length + 1;
            _Column = _ArrChar2.Length + 1;
            _Matrix = new int[_Row, _Column];
        }
        /// <summary>
        /// �������ƶ�
        /// </summary>
        public void Compute()
        {
            //��ʼʱ��
            _BeginTime = DateTime.Now;
            //��ʼ������ĵ�һ�к͵�һ��
            this.InitMatrix();
            int intCost = 0;
            for (int i = 1; i < _Row; i++)
            {
                for (int j = 1; j < _Column; j++)
                {
                    if (_ArrChar1[i - 1] == _ArrChar2[j - 1])
                    {
                        intCost = 0;
                    }
                    else
                    {
                        intCost = 1;
                    }
                    //�ؼ����裬���㵱ǰλ��ֵΪ���+1������+1�����Ͻ�+intCost�е���Сֵ 
                    //ѭ�����������_Matrix[_Row - 1, _Column - 1]��Ϊ�����ַ����ľ���
                    _Matrix[i, j] = this.Minimum(_Matrix[i - 1, j] + 1, _Matrix[i, j - 1] + 1, _Matrix[i - 1, j - 1] + intCost);
                    _ComputeTimes++;
                }
            }
            //����ʱ��
            _EndTime = DateTime.Now;
            //������ �ƶ�����С������ַ������ȵ�20%��ͬһ��
            int intLength = _Row > _Column ? _Row : _Column;

            _Result.Rate = (1 - (decimal)_Matrix[_Row - 1, _Column - 1] / intLength);
            _Result.UseTime = (_EndTime - _BeginTime).ToString();
            _Result.ComputeTimes = _ComputeTimes.ToString();
            _Result.Difference = _Matrix[_Row - 1, _Column - 1];
        }


        /// <summary>
        /// �������ƶȣ�����¼�Ƚ�ʱ�䣩
        /// </summary>
        public void SpeedyCompute()
        {
            //��ʼʱ��
            //_BeginTime = DateTime.Now;
            //��ʼ������ĵ�һ�к͵�һ��
            this.InitMatrix();
            int intCost = 0;
            for (int i = 1; i < _Row; i++)
            {
                for (int j = 1; j < _Column; j++)
                {
                    if (_ArrChar1[i - 1] == _ArrChar2[j - 1])
                    {
                        intCost = 0;
                    }
                    else
                    {
                        intCost = 1;
                    }
                    //�ؼ����裬���㵱ǰλ��ֵΪ���+1������+1�����Ͻ�+intCost�е���Сֵ 
                    //ѭ�����������_Matrix[_Row - 1, _Column - 1]��Ϊ�����ַ����ľ���
                    _Matrix[i, j] = this.Minimum(_Matrix[i - 1, j] + 1, _Matrix[i, j - 1] + 1, _Matrix[i - 1, j - 1] + intCost);
                    _ComputeTimes++;
                }
            }
            //����ʱ��
            //_EndTime = DateTime.Now;
            //������ �ƶ�����С������ַ������ȵ�20%��ͬһ��
            int intLength = _Row > _Column ? _Row : _Column;

            _Result.Rate = (1 - (decimal)_Matrix[_Row - 1, _Column - 1] / intLength);
            // _Result.UseTime = (_EndTime - _BeginTime).ToString();
            _Result.ComputeTimes = _ComputeTimes.ToString();
            _Result.Difference = _Matrix[_Row - 1, _Column - 1];
        }
        /// <summary>
        /// �������ƶ�
        /// </summary>
        /// <param name="str1">�ַ���1</param>
        /// <param name="str2">�ַ���2</param>
        public void Compute(string str1, string str2)
        {
            this.StringComputeInit(str1, str2);
            this.Compute();
        }

        /// <summary>
        /// �������ƶ�
        /// </summary>
        /// <param name="str1">�ַ���1</param>
        /// <param name="str2">�ַ���2</param>
        public void SpeedyCompute(string str1, string str2)
        {
            this.StringComputeInit(str1, str2);
            this.SpeedyCompute();
        }
        /// <summary>
        /// ��ʼ������ĵ�һ�к͵�һ��
        /// </summary>
        private void InitMatrix()
        {
            for (int i = 0; i < _Column; i++)
            {
                _Matrix[0, i] = i;
            }
            for (int i = 0; i < _Row; i++)
            {
                _Matrix[i, 0] = i;
            }
        }
        /// <summary>
        /// ȡ�������е���Сֵ
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        /// <param name="Third"></param>
        /// <returns></returns>
        private int Minimum(int First, int Second, int Third)
        {
            int intMin = First;
            if (Second < intMin)
            {
                intMin = Second;
            }
            if (Third < intMin)
            {
                intMin = Third;
            }
            return intMin;
        }
        #endregion
    }
    /// <summary>
    /// ������
    /// </summary>
    public struct StringComputeResult {
        /// <summary>
        /// ���ƶ�
        /// </summary>
        public decimal Rate;
        /// <summary>
        /// �Աȴ���
        /// </summary>
        public string ComputeTimes;
        /// <summary>
        /// ʹ��ʱ��
        /// </summary>
        public string UseTime;
        /// <summary>
        /// ����
        /// </summary>
        public int Difference;
    }
}
