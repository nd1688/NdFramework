using Nd.Framework.Core;
using System.Data;
using System.Data.Common;

namespace Nd.Framework.Repositories
{
    public interface IDAL : INdDisposable
    {
        /// <summary>
        /// 获取连接字符串Key。
        /// </summary>
        string ConnKey
        {
            get;
        }
        /// <summary>
        /// FillData方法后，存放数据的DataTable.
        /// </summary>
        DataTable Result
        {
            get;
        }
        /// <summary>
        /// 获取连接对象。
        /// </summary>
        /// <returns>连接对象</returns>
        DbConnection GetConnection();

        /// <summary>
        /// 打开连接对象。
        /// 如果使用ExecSql方法，需要显示调用此方法。
        /// 如果使用FillData方法，可以调用此方法，也可不调用。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        bool ConnectionOpen();

        /// <summary>
        /// 关闭连接对象。
        /// 如果没有事务，则需要显式调用此方法来关闭连接。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        bool ConnectionClose();
        /// <summary>
        /// 初始化参数里列表。
        /// 调用AddInParam,AddOutParam,SetParamValue方法前，需要调用此方法。
        /// </summary>
        void InitParmas();
        /// <summary>
        /// 往Sql命令里面添加输入参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="objValue">参数值</param>
        void AddInParam(string strParamName, DbType dbType, object objValue);
        /// <summary>
        /// 往Sql命令里面添加输入参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="iSize">参数数据的大小</param>
        /// <param name="objValue">参数值</param>
        void AddInParam(string strParamName, DbType dbType, int iSize, object objValue);
        /// <summary>
        /// 往Sql命令里面添加输出参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        void AddOutParam(string strParamName, DbType dbType);
        /// <summary>
        /// 往Sql命令里面添加输出参数定义。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="iSize">参数数据的大小</param>
        void AddOutParam(string strParamName, DbType dbType, int iSize);
        /// <summary>
        /// 获取strParamName参数值，通常是输出参数的值。
        /// </summary>
        /// <param name="strParamName">参数名称</param>
        /// <returns>返回strParamName参数值。</returns>
        object GetParamValue(string strParamName);
        T GetParamValue<T>(string strParamName);
        /// <summary>
        /// 执行一个查询，进行填充数据。
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文。</param>
        /// <returns>返回影响的行数。</returns>
        int FillData(string strSql);
        /// <summary>
        /// 执行一个查询，进行填充数据。(可以是sql文或是存储过程)
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回影响的行数。</returns>
        int FillData(string strSql, CommandType cmdType);
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <returns>返回查询的结果object对象</returns>
        object ExecScalar(string strSql);
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <typeparam name="T">返回的数据类型，建议是可以为空的类型</typeparam>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <returns>>返回查询的结果T类型对象</returns>
        T ExecScalar<T>(string strSql);
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回查询的结果object对象</returns>
        object ExecScalar(string strSql, CommandType cmdType);
        /// <summary>
        /// 执行一个查询语句，返回一个object数据,而不是一个表。
        /// 例如：SELECT COUNT(*) FORM TALBE1
        /// </summary>
        /// <typeparam name="T">返回的数据类型，建议是可以为空的类型</typeparam>
        /// <param name="strSql">要查询的Select Sql文</param>
        /// <param name="cmdType">sql命令的类型</param>
        /// <returns>返回查询的结果object对象</returns>
        T ExecScalar<T>(string strSql, CommandType cmdType);
        /// <summary>
        /// 执行strSql文，通常用于Insert,Update,Delete等错作。
        /// </summary>
        /// <param name="strSql">需要执行Sql文</param>
        /// <returns>影响的行数</returns>
        int ExecSql(string strSql);
        int ExecSql(string strSql, CommandType cmdType);
        /// <summary>
        /// 开始一个事务。
        /// </summary>
        /// <returns>返回是否成功</returns>
        bool BeginTransaction();
        /// <summary>
        /// 提交事务。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        bool Commit();
        /// <summary>
        /// 回滚事务。
        /// </summary>
        /// <returns>成功返回true,否则false</returns>
        bool RollBack();
    }
}