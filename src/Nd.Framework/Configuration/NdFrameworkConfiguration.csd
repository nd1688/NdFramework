<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="3275c2b1-34de-404b-9db4-f39a102a756b" namespace="Nd.Framework.Config" xmlSchemaNamespace="urn:Nd.Framework.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="NdFrameworkConfigSection" documentation="表示Nd.Framework框架的配置节点" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="nd_framework">
      <elementProperties>
        <elementProperty name="Services" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="services" isReadOnly="false" documentation="服务配置">
          <type>
            <configurationElementCollectionMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/ServiceElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="ServiceElementCollection" documentation="服务配置集合" xmlItemName="service" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/ServiceElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ServiceElement" documentation="具体服务配置">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="服务名称">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Interval" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="interval" isReadOnly="false" documentation="间隔时间（单位为毫秒），当ServiceRunType为BackgroundWorker时，表示此次运行完延后多少毫秒再运行">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="RunTimePoint" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="run_time_point" isReadOnly="false" documentation="服务运行指定时间点">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="RunMode" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="run_mode" isReadOnly="false" documentation="服务运行模式">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="RunStatus" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="run_status" isReadOnly="false" documentation="服务运行状态">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>