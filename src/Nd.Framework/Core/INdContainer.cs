﻿using System;
using System.Collections.Generic;

namespace Nd.Framework.Core
{
    /// <summary>
    /// IOC服务
    /// </summary>
    public interface INdContainer : IDisposable
    {
        NdLifeStyle DefaultLifeStyle { get; }

        bool HasRegister(string name);
        bool HasRegister<TService>() where TService : class;
        bool HasRegister(Type serviceType);
        void Release(object objInstance);
        INdContainer AddFacility(INdFacility facility);

        #region 组件注册
        void RegisterType(Type serviceType);
        void RegisterType(Type serviceType, string name);
        void RegisterType(Type serviceType, NdLifeStyle lifeStyle);
        void RegisterType(Type serviceType, string name, NdLifeStyle lifeStyle);

        void Register<TService>() where TService : class;
        void Register<TService>(string name) where TService : class;
        void Register<TService>(NdLifeStyle lifeStyle) where TService : class;
        void Register<TService>(string name, NdLifeStyle lifeStyle) where TService : class;

        void Register<TService, TComponent>()
            where TService : class
            where TComponent : class,TService;
        void Register<TService, TComponent>(string name)
            where TService : class
            where TComponent : class,TService;
        void Register<TService, TComponent>(NdLifeStyle lifeStyle)
            where TService : class
            where TComponent : class,TService;
        void Register<TService, TComponent>(string name, NdLifeStyle lifeStyle)
            where TService : class
            where TComponent : class,TService;

        void RegisterInstance<TService>(TService objInstance) where TService : class;
        void RegisterInstance<TService>(TService objInstance, string name) where TService : class;
        void RegisterInstance<TService>(TService objInstance, NdLifeStyle lifeStyle) where TService : class;
        void RegisterInstance<TService>(TService objInstance, string name, NdLifeStyle lifeStyle) where TService : class;
        #endregion

        #region 组件获取
        object Resolve(Type serviceType);
        TService Resolve<TService>() where TService : class;
        TService Resolve<TService>(params object[] args) where TService : class;
        TService Resolve<TService>(IDictionary<string, object> args) where TService : class;
        TService ResolveByName<TService>(string name) where TService : class;
        TService ResolveByName<TService>(string name, params object[] args) where TService : class;
        TService ResolveByName<TService>(string name, IDictionary<string, object> args) where TService : class;
        #endregion
    }
}