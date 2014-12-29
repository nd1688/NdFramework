
namespace Nd.Framework.Services.Config
{


    /// <summary>
    /// 表示Nd.Framework.Services框架的配置节点
    /// </summary>
    public partial class ServicesConfigSection : global::System.Configuration.ConfigurationSection
    {
        #region Singleton Instance
        /// <summary>
        /// The XML name of the NdFrameworkConfigSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ServicesConfigSectionSectionName = "ndFrameworkServices";

        /// <summary>
        /// Gets the NdFrameworkConfigSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::Nd.Framework.Services.Config.ServicesConfigSection Instance
        {
            get
            {
                return ((global::Nd.Framework.Services.Config.ServicesConfigSection)(global::System.Configuration.ConfigurationManager.GetSection(global::Nd.Framework.Services.Config.ServicesConfigSection.ServicesConfigSectionSectionName)));
            }
        }
        #endregion

        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";

        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServicesConfigSection.XmlnsPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Nd.Framework.Services.Config.ServicesConfigSection.XmlnsPropertyName]));
            }
        }
        #endregion

        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion

        #region Services Property
        /// <summary>
        /// The XML name of the <see cref="Services"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ServicesPropertyName = "services";

        /// <summary>
        /// Gets or sets 服务配置
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("服务配置")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServicesConfigSection.ServicesPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual global::Nd.Framework.Services.Config.ServiceElementCollection Services
        {
            get
            {
                return ((global::Nd.Framework.Services.Config.ServiceElementCollection)(base[global::Nd.Framework.Services.Config.ServicesConfigSection.ServicesPropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServicesConfigSection.ServicesPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Nd.Framework.Services.Config
{
    /// <summary>
    /// 服务配置集合
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Nd.Framework.Services.Config.ServiceElement), CollectionType = global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName = global::Nd.Framework.Services.Config.ServiceElementCollection.ServiceElementPropertyName)]
    public partial class ServiceElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ServiceElementPropertyName = "service";
        #endregion

        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override string ElementName
        {
            get
            {
                return global::Nd.Framework.Services.Config.ServiceElementCollection.ServiceElementPropertyName;
            }
        }

        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Nd.Framework.Services.Config.ServiceElementCollection.ServiceElementPropertyName);
        }

        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Nd.Framework.Services.Config.ServiceElement)(element)).Name;
        }

        /// <summary>
        /// Creates a new <see cref="global::Nd.Framework.Services.Config.ServiceElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Nd.Framework.Services.Config.ServiceElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Nd.Framework.Services.Config.ServiceElement();
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Nd.Framework.Services.Config.ServiceElement this[int index]
        {
            get
            {
                return ((global::Nd.Framework.Services.Config.ServiceElement)(base.BaseGet(index)));
            }
        }

        /// <summary>
        /// Gets the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Nd.Framework.Services.Config.ServiceElement this[object name]
        {
            get
            {
                return ((global::Nd.Framework.Services.Config.ServiceElement)(base.BaseGet(name)));
            }
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="service">The <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Add(global::Nd.Framework.Services.Config.ServiceElement service)
        {
            base.BaseAdd(service);
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="service">The <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Remove(global::Nd.Framework.Services.Config.ServiceElement service)
        {
            base.BaseRemove(this.GetElementKey(service));
        }
        #endregion

        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Nd.Framework.Services.Config.ServiceElement GetItemAt(int index)
        {
            return ((global::Nd.Framework.Services.Config.ServiceElement)(base.BaseGet(index)));
        }

        /// <summary>
        /// Gets the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Nd.Framework.Services.Config.ServiceElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Nd.Framework.Services.Config.ServiceElement GetItemByKey(string name)
        {
            return ((global::Nd.Framework.Services.Config.ServiceElement)(base.BaseGet(((object)(name)))));
        }
        #endregion

        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Nd.Framework.Services.Config
{
    /// <summary>
    /// 具体服务配置
    /// </summary>
    public partial class ServiceElement : global::System.Configuration.ConfigurationElement
    {

        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion

        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string NamePropertyName = "name";

        /// <summary>
        /// Gets or sets 服务名称
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("服务名称")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServiceElement.NamePropertyName, IsRequired = true, IsKey = true, IsDefaultCollection = false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::Nd.Framework.Services.Config.ServiceElement.NamePropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServiceElement.NamePropertyName] = value;
            }
        }
        #endregion

        #region Interval Property
        /// <summary>
        /// The XML name of the <see cref="Interval"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string IntervalPropertyName = "interval";

        /// <summary>
        /// Gets or sets 间隔时间（单位为毫秒），当ServiceRunType为BackgroundWorker时，表示此次运行完延后多少毫秒再运行
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("间隔时间（单位为毫秒），当ServiceRunType为BackgroundWorker时，表示此次运行完延后多少毫秒再运行")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServiceElement.IntervalPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual int Interval
        {
            get
            {
                return ((int)(base[global::Nd.Framework.Services.Config.ServiceElement.IntervalPropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServiceElement.IntervalPropertyName] = value;
            }
        }
        #endregion

        #region RunTimePoint Property
        /// <summary>
        /// The XML name of the <see cref="RunTimePoint"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RunTimePointPropertyName = "runTimePoint";

        /// <summary>
        /// Gets or sets 服务运行指定时间点
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("服务运行指定时间点")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServiceElement.RunTimePointPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string RunTimePoint
        {
            get
            {
                return ((string)(base[global::Nd.Framework.Services.Config.ServiceElement.RunTimePointPropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServiceElement.RunTimePointPropertyName] = value;
            }
        }
        #endregion

        #region RunMode Property
        /// <summary>
        /// The XML name of the <see cref="RunMode"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RunModePropertyName = "runMode";

        /// <summary>
        /// Gets or sets 服务运行模式
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("服务运行模式")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServiceElement.RunModePropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string RunMode
        {
            get
            {
                return ((string)(base[global::Nd.Framework.Services.Config.ServiceElement.RunModePropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServiceElement.RunModePropertyName] = value;
            }
        }
        #endregion

        #region RunStatus Property
        /// <summary>
        /// The XML name of the <see cref="RunStatus"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RunStatusPropertyName = "runStatus";

        /// <summary>
        /// Gets or sets 服务运行状态
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("服务运行状态")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Nd.Framework.Services.Config.ServiceElement.RunStatusPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public virtual string RunStatus
        {
            get
            {
                return ((string)(base[global::Nd.Framework.Services.Config.ServiceElement.RunStatusPropertyName]));
            }
            set
            {
                base[global::Nd.Framework.Services.Config.ServiceElement.RunStatusPropertyName] = value;
            }
        }
        #endregion
    }
}
