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
        <elementProperty name="Logging" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logging" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/LoggingElement" />
          </type>
        </elementProperty>
        <elementProperty name="ObjectContainers" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="objectContainers" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/ObjectContainersElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="LoggingElement" documentation="The logging element">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false">
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
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="HasAOP" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="hasAOP" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/3275c2b1-34de-404b-9db4-f39a102a756b/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="DefaultLifeStyle" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultLifeStyle" isReadOnly="false">
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