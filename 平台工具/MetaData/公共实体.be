<EntityProj namespace="IWEHAVE.ERP.CommonBE" Guid="8b7def67-8cd9-433a-98de-d125df1c8c92" Name="公共实体">
  <EntityList>
    <Entity Guid="46555b52-7bbf-4667-81a7-6d0b11681400" Code="BizEntity" Name="业务实体公共基类" Table="T_BIZENTITY" ViewRange="0" OrgFilter="0">
      <Attributes>
        <Attribute Guid="ece595a1-0c85-40db-9399-7655be534d6c" Code="Creator" Name="创建人" DataType="CommonType" Type="long" IsNull="0" />
        <Attribute Guid="ae2a144b-062f-433d-8aa0-6eb265347ff8" Code="Orgnization" Name="所属根组织" DataType="CommonType" Type="long" IsNull="0" IsViewer="0" IsBizKey="1" />
        <Attribute Guid="9fcd16ad-c843-41f3-b57a-610bff54fc7d" Code="CreateDate" Name="创建日期" DataType="CommonType" Type="DateTime" IsNull="1" />
        <Attribute Guid="2c7be805-618e-4948-9ea0-54103691bc54" Code="ModifyDate" Name="修改日期" DataType="CommonType" Type="DateTime" IsNull="1" />
        <Attribute Guid="b395b9c1-cb19-4420-9eb6-c2c36daf61e9" Code="OrgnizationC" Name="所属子组织" DataType="CommonType" Type="long" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="1d9694f8-740a-4bb9-bfa0-d0a055873ced" Code="BizTreeEntity" Name="树组件公共基类" Table="T_BIZTREEENTITY" InhertGuid="46555b52-7bbf-4667-81a7-6d0b11681400" ViewRange="0" OrgFilter="0">
      <Attributes>
        <Attribute Guid="4cd95f3b-3a46-4f6b-9a2d-5c41ffbc0e60" Code="PID" Name="父节点ID" DataType="CommonType" Type="long" IsNull="1" IsViewer="0" IsBizKey="1" />
        <Attribute Guid="0edb72c7-2dc1-44d1-b08c-780001ef2079" Code="Name" Name="节点名称" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="1" />
        <Attribute Guid="984de839-3920-41f7-a769-4279080eb443" Code="FullName" Name="节点全路径" DataType="CommonType" Type="string" Length="1000" IsNull="0" />
        <Attribute Guid="7bea0a9f-6616-476b-9fbe-31678535b7a7" Code="Level" Name="节点层级" DataType="CommonType" Type="int" IsNull="0" IsViewer="0" IsBizKey="1" />
        <Attribute Guid="a2c5d1c7-e7ef-43c0-baba-b343087a3d56" Code="OrderNo" Name="同级顺序号" DataType="CommonType" Type="int" IsNull="0" />
        <Attribute Guid="15eaec4f-a1b4-404f-b896-75315b33507b" Code="Leaf" Name="是否叶节点" DataType="CommonType" Type="bool" IsNull="0" />
        <Attribute Guid="65b5d339-0c91-4b76-9ef5-da84273ce0a5" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="1" />
      </Attributes>
    </Entity>
  </EntityList>
  <RefrenceList>
    <Refrence Guid="ba878ef1-0266-4603-a60e-3fdfe3d7117f" RefProjName="公共实体.be" RefrenceType="BEEntity" />
    <Refrence Guid="9ffdc98f-a0c7-4228-ade2-9025632273cc" RefProjName="公共实体.be" RefrenceType="Deploy" />
  </RefrenceList>
  <DTOList>
    <DTO Guid="d17c2f10-aaa3-4107-b89c-35887a9e82bf" Code="FieldDTO" Name="列数据DTO">
      <Attributes>
        <Attribute Guid="642f766d-0bbd-4e31-a563-36a2acea9aaa" Type="string" Code="FieldKey" Name="列标识" DataType="CommonType" IsNull="0" />
        <Attribute Guid="72c010e8-4fd2-4a24-83a0-1413aa08b545" Type="object" Code="FieldValue" Name="列值" DataType="CommonType" IsNull="0" />
        <Attribute Guid="22fae467-d606-4b95-96fa-8bc587fd8814" Type="string" Code="FieldType" Name="列类型" DataType="CommonType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="55881f06-1e60-431d-a3f9-6784d7afe17a" Code="EntityExDTO" Name="实体返回数据DTO">
      <Attributes>
        <Attribute Guid="e82701a1-6276-419b-b67e-61ce122a3c55" Type="string" Code="EntityClass" Name="实体类名称" DataType="CommonType" IsNull="0" />
        <Attribute Guid="08fd8ef4-8e5f-44c4-a4a4-255cda75dc49" Type="long" Code="EntityKey" Name="实体ID" DataType="CommonType" IsNull="0" />
        <Attribute Guid="9bd60cc7-6459-44c3-b6b4-b8900a86acce" RefGuid="d17c2f10-aaa3-4107-b89c-35887a9e82bf" Code="Fields" Name="实体列数据" DataType="CompositionType" IsNull="0" />
      </Attributes>
    </DTO>
    <DTO Guid="63a2948a-a7ab-4d19-8b7b-0bb962115ca2" Code="CommonEntityDTO" Name="公共实体DTO">
      <Attributes>
        <Attribute Guid="784488fb-febc-431d-bd3b-0669fa2798dc" Type="string" Code="ColumnName" Name="名称" DataType="CompositionType" IsNull="0" IsViewer="0" />
        <Attribute Guid="7e33a77a-4f41-48f3-b31a-efcda10c81b8" Code="ColumnValue" Name="值" DataType="CompositionType" IsNull="0" IsViewer="0" Type="object" />
        <Attribute Guid="9c92c5a2-3278-41e1-927c-cc096d1e9659" Type="string" Code="ColumnCode" Name="编码" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="fa22434e-4459-45aa-b3ce-7f192ab45ac7" Code="CommonEntityExDTO" Name="公共实体扩展DTO">
      <Attributes>
        <Attribute Guid="fdb374a1-0473-4c5f-8fb0-9f5e7a479884" Type="int" Code="ListCount" Name="数据量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="c9ccb904-f4b8-4145-ab7e-b8d1ba8b21b9" RefGuid="63a2948a-a7ab-4d19-8b7b-0bb962115ca2" Code="ListData" Name="数据" DataType="RefreceType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
  </DTOList>
</EntityProj>