using Nd.Framework.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nd.Framework.Repositories.DAL
{
    /// <summary>
    /// 数据库访问类，包含了数据库的各种操作。
    /// </summary>
    public class MSSqlDAL : NdDisposable, IDAL
    {
        #region 常量
        private const string ResultName = "Data";
        #endregion

        #region 私有字段
        private string strConnKey;
        private SqlConnection sqlConn = null;
        private DataTable dtResult = null;
        private SqlTransaction tran = null;
        private SqlCommand objCmd = null;
        private SqlDataAdapter objAdapter = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取连接字符串Key。
        /// </summary>
        public string ConnKey
        {
            get
            {
                return this.strConnKey;
            }
        }
        /// <summary>
        /// FillData方法后，存放数据的DataTable.
        /// </summary>
        public DataTable Result
        {
            get
            {
                if (this.dtResult != null)
                {
                    return this.dtResult;
                }
                return null;
            }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法。
        /// </summary>
        public MSSqlDAL()
        {
        }
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="strConnString">连接串</param>
        public MSSqlDAL(string strConnKey)
        {
            this.Initialize(strConnKey);
        }
        #endregion 构造方法

        #region 成员方法
        /// <summary>
        /// 初始化连接对象。
        /// </summary>
        /// <param name="strConnKey">连接字符串Key</param>
        public MSSqlDAL Initialize(string strConnKey)
        {
            this.strConnKey = strConnKey;
            this.sqlConn = new SqlConnection(Util.GetConnString(strConnKey));
            return this;
        }
        /// <summary>
        /// 获取连接对象。
        /// </summary>
        /// <returns>连接对象</returns>
        public SqlConnection GetConnection()
        {
            return this.sqlConn;
        }
        /// <summary>
        /// 打开连接对象。
        /// 如果使用ExecSql方法，需要显示调用此方法。
        /// 如果使用FillData方法，可以调用此方法，也可不调用。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        public bool ConnectionOpen()
        {
            if (this.sqlConn != null)
            {
                if (this.sqlConn.State != ConnectionState.Connecting
                    && this.sqlConn.State != ConnectionState.Open)
                {
                    this.sqlConn.Open();
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 关闭连接对象。
        /// 如果没有事务，则需要显式调用此方法来关闭连接。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        public bool ConnectionClose()
        {
            if (this.sqlConn != null)
            {
                if (this.sqlConn.State != ConnectionState.Closed)
                {
                    this.sqlConn.Close();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 初始化参数里列表。
        /// 调用AddInParam,AddOutParam,SetParamValue方法前，需要调用此方法。
        /// </summary>
        public void InitParmas()
        {
            Util.Fail(this.sqlConn == null, "请先调用Initialize方法来初始化实例");
            this.objCmd = new SqlCommand();
            this.objCmd.Connection = this.sqlConn;
        }
        /// <summary>
        /// 往Sql命令里面添加输入参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="objValue">参数值</param>
        public void AddInParam(string strParamName, SqlDbType dbType, object objValue)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.SqlDbType = dbType;
                param.Value = (objValue == null ? DBNull.Value : objValue);
                param.Direction = ParameterDirection.Input;
                this.objCmd.Parameters.Add(param);
            }
        }
        /// <summary>
        /// 往Sql命令里面添加输入参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="iSize">参数数据的大小</param>
        /// <param name="objValue">参数值</param>
        public void AddInParam(string strParamName, SqlDbType dbType, int iSize, object objValue)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.SqlDbType = dbType;
                param.Size = iSize;
                param.Value = (objValue == null ? DBNull.Value : objValue);
                param.Direction = ParameterDirection.Input;
                this.objCmd.Parameters.Add(param);
            }
        }
        /// <summary>
        /// 往Sql命令里面添加输出参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        public void AddOutParam(string strParamName, SqlDbType dbType)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.SqlDbType = dbType;
                param.Direction = ParameterDirection.Output;
                this.objCmd.Parameters.Add(param);
            }
        }
        /// <summary>
        /// 往Sql命令里面添加输出参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="iSize">参数数据的大小</param>
        public void AddOutParam(string strParamName, SqlDbType dbType, int iSize)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.SqlDbType = dbType;
                param.Size = iSize;
                param.Direction = ParameterDirection.Output;
                this.objCmd.Parameters.Add(param);
            }
        }
        /// <summary>
        /// 获取strParamName参数值，通常是输出参数的值。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <returns>返回strParamName参数值。</returns>
        public object GetParamValue(string strParamName)
        {
            if (this.objCmd != null)
            {
                return this.objCmd.Parameters[strParamName].Value;
            }
            return DBNull.Value;
        }
        public T GetParamValue<T>(string strParamName)
        {
            if (this.objCmd != null)
            {
                return Util.ConvertTo<T>(this.objCmd.Parameters[strParamName].Value);
            }
            return default(T);
        }
        /// <summary>
        /// 执行一个查询，进行填充数据。
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文。</param>
        /// <returns>返回影响的行数。</returns>
        public int FillData(string strSql)
        {
            return this.FillData(strSql, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询，进行填充数据。(可以是sql文或是存储过程)
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回影响的行数。</returns>
        public int FillData(string strSql, CommandType cmdType)
        {
            Util.Fail(this.objCmd == null, "请先调用InitParmas方法来初始化参数");
            this.objCmd.CommandText = strSql;
            this.objCmd.CommandType = cmdType;
            if (this.tran != null)
            {
                this.objCmd.Transaction = this.tran;
            }
            this.LogInfo(strSql);
            this.objAdapter = new SqlDataAdapter(this.objCmd);
            this.dtResult = new DataTable(MSSqlDAL.ResultName);
            return this.objAdapter.Fill(this.dtResult);
        }
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <returns>返回查询的结果object对象</returns>
        public object ExecScalar(string strSql)
        {
            return this.ExecScalar(strSql, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <typeparam name="T">返回的数据类型，建议是可以为空的类型</typeparam>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <returns>>返回查询的结果T类型对象</returns>
        public T ExecScalar<T>(string strSql)
        {
            return this.ExecScalar<T>(strSql, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回查询的结果object对象</returns>
        public object ExecScalar(string strSql, CommandType cmdType)
        {
            Util.Fail(this.objCmd == null, "请先调用InitParmas方法来初始化参数");
            this.objCmd.CommandText = strSql;
            this.objCmd.CommandType = cmdType;
            if (this.tran != null)
            {
                this.objCmd.Transaction = this.tran;
            }
            this.LogInfo(strSql);
            this.ConnectionOpen();
            return this.objCmd.ExecuteScalar();
        }
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <typeparam name="T">返回的数据类型，建议是可以为空的类型</typeparam>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回查询的结果object对象</returns>
        public T ExecScalar<T>(string strSql, CommandType cmdType)
        {
            object objResult = this.ExecScalar(strSql, cmdType);
            return Util.ConvertTo<T>(objResult);
        }
        /// <summary>
        /// 执行strSql文，通常用于Insert,Update,Delete等错作。
        /// </summary>
        /// <param name="strSql">需要执行Sql文</param>
        /// <returns>影响的行数</returns>
        public int ExecSql(string strSql)
        {
            return this.ExecSql(strSql, CommandType.Text);
        }
        public int ExecSql(string strSql, CommandType cmdType)
        {
            Util.Fail(this.objCmd == null, "请先调用InitParmas方法来初始化参数");
            this.objCmd.CommandText = strSql;
            this.objCmd.CommandType = cmdType;
            if (this.tran != null)
            {
                objCmd.Transaction = this.tran;
            }
            this.LogInfo(strSql);
            this.ConnectionOpen();
            return this.objCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 开始一个事务。
        /// </summary>
        /// <returns>返回是否成功</returns>
        public bool BeginTransaction()
        {
            if (this.sqlConn != null)
            {
                this.ConnectionOpen();
                this.tran = this.sqlConn.BeginTransaction();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 提交事务。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        public bool Commit()
        {
            if (this.tran == null)
            {
                return false;
            }
            this.tran.Commit();
            return true;
        }
        /// <summary>
        /// 回滚事务。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        public bool RollBack()
        {
            if (this.tran == null)
            {
                return false;
            }
            this.tran.Rollback();
            return true;
        }
        /// <summary>
        /// 批量插入数据库数据，独立执行
        /// </summary>
        /// <param name="iCount"></param>
        /// <param name="strTableName"></param>
        /// <param name="objData"></param>
        public void CreateBulk(int iCount, string strTableName, DataTable objData, SqlBulkCopyOptions iOption)
        {
            string strConn = Util.GetConnString(this.ConnKey);
            using (SqlBulkCopy objBulk = new SqlBulkCopy(strConn, iOption))
            {
                objBulk.BatchSize = iCount;
                objBulk.BulkCopyTimeout = 60;
                objBulk.DestinationTableName = strTableName;
                objBulk.WriteToServer(objData);
            }
        }
        public void CreateBulk(int iCount, string strTableName, DataRow[] objRows, SqlBulkCopyOptions iOption)
        {
            string strConn = Util.GetConnString(this.ConnKey);
            using (SqlBulkCopy objBulk = new SqlBulkCopy(strConn, iOption))
            {
                objBulk.BatchSize = iCount;
                objBulk.BulkCopyTimeout = 60;
                objBulk.DestinationTableName = strTableName;
                objBulk.WriteToServer(objRows);
            }
        }
        #endregion

        #region IDbDAL接口方法
        protected override void Dispose(bool bDisposing)
        {
            if (bDisposing)
            {
                if (this.dtResult != null)
                {
                    this.dtResult.Dispose();
                }
                if (this.objAdapter != null)
                {
                    this.objAdapter.Dispose();
                }
                if (this.objCmd != null)
                {
                    this.objCmd.Dispose();
                }
                if (this.tran != null)
                {
                    this.tran.Dispose();
                }
                if (this.sqlConn != null)
                {
                    this.ConnectionClose();
                    this.sqlConn.Dispose();
                }
            }
            base.Dispose(bDisposing);
        }
        DbConnection IDAL.GetConnection()
        {
            return this.GetConnection();
        }
        public void AddInParam(string strParamName, DbType dbType, object objValue)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.DbType = dbType;
                param.Value = (objValue == null ? DBNull.Value : objValue);
                param.Direction = ParameterDirection.Input;
                this.objCmd.Parameters.Add(param);
            }
        }
        public void AddInParam(string strParamName, DbType dbType, int iSize, object objValue)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.DbType = dbType;
                param.Size = iSize;
                param.Value = (objValue == null ? DBNull.Value : objValue);
                param.Direction = ParameterDirection.Input;
                this.objCmd.Parameters.Add(param);
            }
        }
        public void AddOutParam(string strParamName, DbType dbType)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.DbType = dbType;
                param.Direction = ParameterDirection.Output;
                this.objCmd.Parameters.Add(param);
            }
        }
        public void AddOutParam(string strParamName, DbType dbType, int iSize)
        {
            if (this.objCmd != null)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = strParamName;
                param.DbType = dbType;
                param.Size = iSize;
                param.Direction = ParameterDirection.Output;
                this.objCmd.Parameters.Add(param);
            }
        }
        #endregion

        #region 记录SQL
        private void LogInfo(string strSql)
        {
            StringBuilder objBuilder = new StringBuilder();
            objBuilder.AppendFormat("SQL:{0},Parameters:", strSql);
            if (this.objCmd != null && this.objCmd.Parameters.Count > 0)
            {
                for (int i = 0; i < this.objCmd.Parameters.Count; i++)
                {
                    if (i > 0)
                    {
                        objBuilder.Append(",");
                    }
                    SqlParameter objParam = this.objCmd.Parameters[i];
                    objBuilder.AppendFormat("{0}={1}", objParam.ParameterName, objParam.Value);
                }
            }
            AppRuntime.Current.Logger.Info(objBuilder.ToString());
        }
        #endregion
    }
}