using Nd.Framework.Config;
using System;

namespace Nd.Framework.Services
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public abstract class ServiceBase : IService
    {
        #region 私有字段
        /// <summary>
        /// 服务唯一编号
        /// </summary>
        private Guid _id = Guid.NewGuid();
        /// <summary>
        /// 间隔时间（单位为毫秒）
        /// 当ServiceRunType为BackgroundWorker时，表示此次运行完延后多少毫秒再运行
        /// </summary>
        private int _interval = 1000;
        private ServiceRunTimePoint _serviceRunTimePoint = ServiceRunTimePoint.H24 | ServiceRunTimePoint.H12;
        private ServiceRunMode _serviceRunMode = ServiceRunMode.BackgroundWorker;
        private ServiceRunStatus _serviceRunStatus = ServiceRunStatus.Run;

        private IConfigSource _configSource;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>ServiceBase</c>实例
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public ServiceBase(string serviceName)
        {
            _configSource = new AppConfigSource();

            if (_configSource.Config == null)
                return;

            if (_configSource.Config.Services == null)
                return;

            ServiceElement serviceElement = _configSource.Config.Services[serviceName];
            if (serviceElement == null)
                return;

            if (serviceElement.Interval > 0)
                _interval = serviceElement.Interval;

            if (!string.IsNullOrEmpty(serviceElement.RunMode))
                _serviceRunMode = Util.GetEnumValue<ServiceRunMode>(serviceElement.RunMode, _serviceRunMode);

            if (!string.IsNullOrEmpty(serviceElement.RunStatus))
                _serviceRunStatus = Util.GetEnumValue<ServiceRunStatus>(serviceElement.RunStatus, _serviceRunStatus);

            if (!string.IsNullOrEmpty(serviceElement.RunTimePoint))
            {
                string[] arrTimePoint = serviceElement.RunTimePoint.Split(new char[] { '|' });
                foreach (string timePoint in arrTimePoint)
                {
                    _serviceRunTimePoint |= Util.GetEnumValue<ServiceRunTimePoint>(timePoint, ServiceRunTimePoint.None);
                }
            }
        }
        #endregion

        #region IService 成员
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                value = _id;
            }
        }

        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                value = _interval;
            }
        }

        public ServiceRunTimePoint ServiceRunTimePoint
        {
            get
            {
                return _serviceRunTimePoint;
            }
            set
            {
                value = _serviceRunTimePoint;
            }
        }

        public ServiceRunMode ServiceRunMode
        {
            get
            {
                return _serviceRunMode;
            }
            set
            {
                value = _serviceRunMode;
            }
        }

        public ServiceRunStatus ServiceRunStatus
        {
            get
            {
                return _serviceRunStatus;
            }
            set
            {
                value = _serviceRunStatus;
            }
        }
        #endregion
    }
}