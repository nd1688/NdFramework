<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="3275c2b1-34de-404b-9db4-f39a102a756b" namespace="Nd.Framework.Configuration" xmlSchemaNamespace="urn:Nd.Framework.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
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
        <elementProperty name="Logging" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logging" isReadOnly="false" documentation="日志记录">
          <type>
            <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/LoggingElement" />
          </type>
        </elementProperty>
        <elementProperty name="ObjectContainer" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="objectContainer" isReadOnly="false" documentation="IOC">
          <type>
            <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/ObjectContainersElement" />
          </type>
        </elementProperty>
        <elementProperty name="Bus" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="bus" isReadOnly="false" documentation="消息总线">
          <type>
            <configurationElementCollectionMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/TopicElementCollection" />
          </type>
        </elementProperty>
        <elementProperty name="WebAPI" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="webAPI" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/WebAPIElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="LoggingElement" documentation="The logging element">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false" documentation="日志记录器提供者">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="ErrorLogger" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="errorLogger" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="InfoLogger" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="infoLogger" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="ObjectContainersElement">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false" documentation="IOC服务提供者">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="HasInterceptor" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="hasInterceptor" isReadOnly="false" documentation="存在拦截器">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="DefaultLifeStyle" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultLifeStyle" isReadOnly="false" documentation="默认生命周期">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="TopicElementCollection" documentation="主题集合" xmlItemName="topic" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false" documentation="消息总线服务提供者">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="IsAvailable" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="isAvailable" isReadOnly="false" documentation="是否可用">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="Path" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="path" isReadOnly="false" documentation="主机路径">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <itemType>
        <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/TopicElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="TopicElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="主题名称">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="QueueNumber" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="queueNumber" isReadOnly="false" documentation="队列数量">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MessageType" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="messageType" isReadOnly="false" documentation="消息类型">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="WebAPIElement">
      <attributeProperties>
        <attributeProperty name="IsNeedMethodAttribute" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="isNeedMethodAttribute" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="CurrentAppHostUrl" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="currentAppHostUrl" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="DbConnectionKey" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dbConnectionKey" isReadOnly="false">
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