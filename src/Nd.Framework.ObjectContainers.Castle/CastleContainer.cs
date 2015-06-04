using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nd.Framework.Configuration;
using Nd.Framework.Core;
using System;
using System.Collections.Generic;

namespace Nd.Framework.ObjectContainers.Castle
{
    public class CastleContainer : INdContainer
    {
        #region 私有字段
        private readonly IConfigSource configSource;
        private readonly CastleInterceptorFacility interceptorFacility = new CastleInterceptorFacility();
        private readonly WindsorContainer container = new WindsorContainer(new DefaultConfigurationStore());

        private string defaultLifeStyle;
        #endregion

        #region 构造函数
        public CastleContainer(IConfigSource configSource)
        {
            this.configSource = configSource;
            this.defaultLifeStyle = configSource.Config.ObjectContainer.DefaultLifeStyle;
            if (this.configSource.Config.ObjectContainer.HasInterceptor)
            {
                this.AddFacility(interceptorFacility);
                this.RegisterType(typeof(CastleInterceptor), NdLifeStyle.Singleton);
            }
        }
        #endregion

        #region INdContainer 成员
        public NdLifeStyle DefaultLifeStyle
        {
            get { return (NdLifeStyle)(Enum.Parse(typeof(NdLifeStyle), this.defaultLifeStyle)); }
        }

        public bool HasRegister(string name)
        {
            return this.container.Kernel.HasComponent(name);
        }

        public bool HasRegister<TService>() where TService : class
        {
            return this.HasRegister(typeof(TService));
        }

        public bool HasRegister(Type serviceType)
        {
            return this.container.Kernel.HasComponent(serviceType);
        }

        public void Release(object objInstance)
        {
            this.container.Release(objInstance);
        }

        public INdContainer AddFacility(INdFacility facility)
        {
            this.container.AddFacility((ICastleFacility)facility);
            return this;
        }

        public void RegisterType(Type serviceType)
        {
            this.container.Register(Component.For(serviceType));
        }

        public void RegisterType(Type serviceType, string name)
        {
            this.container.Register(Component.For(serviceType).Named(name));
        }

        public void RegisterType(Type serviceType, NdLifeStyle lifeStyle)
        {
            this.container.Register(Component.For(serviceType).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void RegisterType(Type serviceType, string name, NdLifeStyle lifeStyle)
        {
            this.container.Register(Component.For(serviceType).Named(name).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void Register<TService>() where TService : class
        {
            this.Register<TService>(o => o.LifeStyle.Is(this.WindsorLifestyleTypeGet(this.DefaultLifeStyle)));
        }

        public void Register<TService>(string name) where TService : class
        {
            this.Register<TService>(o => o.Named(name));
        }

        public void Register<TService>(NdLifeStyle lifeStyle) where TService : class
        {
            this.Register<TService>(o => o.LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void Register<TService>(string name, NdLifeStyle lifeStyle) where TService : class
        {
            this.Register<TService>(o => o.Named(name).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void Register<TService, TComponent>()
            where TService : class
            where TComponent : class, TService
        {
            this.Register<TService>(o => o.ImplementedBy<TComponent>());
        }

        public void Register<TService, TComponent>(string name)
            where TService : class
            where TComponent : class, TService
        {
            this.Register<TService>(o => o.ImplementedBy<TComponent>().Named(name));
        }

        public void Register<TService, TComponent>(NdLifeStyle lifeStyle)
            where TService : class
            where TComponent : class, TService
        {
            this.Register<TService>(o => o.ImplementedBy<TComponent>().LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void Register<TService, TComponent>(string name, NdLifeStyle lifeStyle)
            where TService : class
            where TComponent : class, TService
        {
            this.Register<TService>(o => o.ImplementedBy<TComponent>().Named(name).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void RegisterInstance<TService>(TService objInstance) where TService : class
        {
            this.Register<TService>(o => o.Instance(objInstance));
        }

        public void RegisterInstance<TService>(TService objInstance, string name) where TService : class
        {
            this.Register<TService>(o => o.Instance(objInstance).Named(name));
        }

        public void RegisterInstance<TService>(TService objInstance, NdLifeStyle lifeStyle) where TService : class
        {
            this.Register<TService>(o => o.Instance(objInstance).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public void RegisterInstance<TService>(TService objInstance, string name, NdLifeStyle lifeStyle) where TService : class
        {
            this.Register<TService>(o => o.Instance(objInstance).Named(name).LifeStyle.Is(this.WindsorLifestyleTypeGet(lifeStyle)));
        }

        public object Resolve(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public TService Resolve<TService>() where TService : class
        {
            return this.container.Resolve<TService>();
        }

        public TService Resolve<TService>(params object[] args) where TService : class
        {
            return this.container.Resolve<TService>(args);
        }

        public TService Resolve<TService>(IDictionary<string, object> args) where TService : class
        {
            return this.container.Resolve<TService>(args);
        }

        public TService ResolveByName<TService>(string name) where TService : class
        {
            return this.container.Resolve<TService>(name);
        }

        public TService ResolveByName<TService>(string name, params object[] args) where TService : class
        {
            return this.container.Resolve<TService>(name, args);
        }

        public TService ResolveByName<TService>(string name, IDictionary<string, object> args) where TService : class
        {
            return this.container.Resolve<TService>(name, args);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
        #endregion

        #region 私有方法
        private LifestyleType WindsorLifestyleTypeGet(NdLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case NdLifeStyle.Pooled: return LifestyleType.Pooled;
                case NdLifeStyle.Scoped: return LifestyleType.Scoped;
                case NdLifeStyle.Thread: return LifestyleType.Thread;
                case NdLifeStyle.Transient: return LifestyleType.Transient;
                case NdLifeStyle.Singleton: return LifestyleType.Singleton;
                default: return LifestyleType.Transient;
            }
        }
        private void Register<TService>(Action<ComponentRegistration<TService>> registerHandler) where TService : class
        {
            ComponentRegistration<TService> register = new ComponentRegistration<TService>();
            registerHandler(register.LifeStyle.Is(this.WindsorLifestyleTypeGet(this.DefaultLifeStyle)));
            if (!HasRegister<TService>())
                this.container.Register(register);
        }
        #endregion
    }
}