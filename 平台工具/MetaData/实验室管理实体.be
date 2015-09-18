<EntityProj namespace="THU.LabSystemBE" Guid="41e190f9-fa28-4f06-bb77-e31a477848aa" Name="实验室管理实体">
  <EntityList>
    <Entity Guid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="User" Name="用户信息" Table="T_LAB_USER" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="f82e5044-4a23-4100-9274-0f56728425ec" Code="SN" Name="学号" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="1cef4a71-e27b-421a-8dc0-6c94c8f06c95" Code="Name" Name="姓名" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="4bd63169-50fb-4b36-a390-748aafcc7211" Code="Tel" Name="电话" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="fa57c5b5-5769-428f-8b25-a429d5829a41" Code="Password" Name="密码" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="1d5ff821-98a3-45cd-adab-b3e71e5f1939" Code="Degree" Name="学历" DataType="RefreceType" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" />
        <Attribute Guid="11dd174e-2df9-4c6f-ab15-6a0822718b66" Code="Status" Name="身份" DataType="RefreceType" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" />
        <Attribute Guid="fcf7c495-a83f-4779-be93-fb54fa6edbbd" RefGuid="129db180-ef51-45a2-a825-bfb2ed030d0b" Code="Type" Name="用户类别" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="3caf15e2-ea72-406b-a0bc-e062becf83a1" Code="Email" Name="邮件" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="b757cc23-23ca-4cf4-80c4-619604854dec" Code="Code" Name="登录名" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="9c79ff65-35cc-4e0d-b7b0-06141988b3e7" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="9ba91696-9fff-4be4-a71c-51e5bf7f2bae" Code="BeginTime" Name="启用时间" DataType="CommonType" Type="DateTime" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="2fc387c6-8e25-44f1-b497-e8afcb765a3e" Code="EndTime" Name="停用时间" DataType="CommonType" Type="DateTime" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="11acd3ba-335c-496b-8217-a67e28229a32" RefGuid="66daf590-39cf-4f27-b265-a9f3f122a3e9" Code="Teacher" Name="导师" DataType="RefreceType" IsNull="1" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="CommonEnum" Name="通用枚举" Table="T_LAB_COMMON_ENUM" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="f7362f8b-e977-4b17-ac74-a4c9ee6942c9" Code="Name" Name="枚举名称" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="0b2acad1-e475-424a-8bbb-e603d0a21835" Code="Type" Name="类别" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" RefGuid="8e375056-7df3-4cf5-85ef-7d0238460e29" />
        <Attribute Guid="54eea3ca-efc7-4c4e-bfb4-4501bef9daae" Code="Code" Name="编码" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="e870edc3-ad36-470e-b4aa-7726ba778eb6" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="66daf590-39cf-4f27-b265-a9f3f122a3e9" Code="Teacher" Name="导师信息" Table="T_LAB_TEACHER" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="7725b606-53a6-45f7-bb97-3edf1a34cc49" Code="Name" Name="姓名" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="9852905f-cc42-435f-ab25-b38f440764c4" RefGuid="afc6184e-71e8-4290-b72f-fc73de2f67b7" Code="Sex" Name="性别" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="6d67f5ad-bf68-4de0-959e-4b960fe2a2c3" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="Position" Name="职位" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="7dcab59b-ef6b-4e8c-9402-ded56f4f356f" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="Department" Name="所属院系" DataType="RefreceType" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="d8c46134-8f28-4d42-898c-99a2faa7adec" Code="Tag" Name="搜索码" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="3b6af57d-dd34-470f-a0ab-fdd36261e292" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="3c5ffb16-361e-462e-b884-52b998b03d3e" Code="DeviceMap" Name="设备地图" Table="T_LAB_DEVICE_MAP" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="8a055b68-28f1-4f66-af18-9a73233e21c6" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="House" Name="房间" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="901d5499-c0de-4456-b784-8d0022d93f6b" Code="SN" Name="设备号" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="cfc8b3b8-8aee-4d6b-9c88-6ab628b6e1bd" RefGuid="236369ec-7ec8-4b64-89fd-f16e1e3dcda4" Code="DeviceStatus" Name="设备状态" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="8e74cba2-354c-4b68-84d8-da72a3da0814" RefGuid="1830de43-d11d-4875-b198-1d459071af53" Code="UseStatus" Name="使用状态" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="f905e9f5-f2de-4567-a830-be91d93be9a8" Code="Price" Name="设备单价" DataType="CommonType" Type="decimal" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="040a0e9b-e96d-4388-8ab4-b3a09d7fa192" Code="Expression" Name="计算公式" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="0f700b75-0bd2-4939-aadf-48d8d3784833" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="d48a34b9-83e9-4c05-8811-c46cfdfbdea6" RefGuid="ed7be607-7e7b-4976-b1bf-3f18efe5b9df" Code="Device" Name="关联设备" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="574aa9bc-55a0-464b-9507-0f66c4207a9d" Code="DeviceUseRecord" Name="设备使用记录" Table="T_LAB_DEVICE_USE_RECORD" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="e49ed16b-5c6c-49ab-b19f-c0f32b0563a3" RefGuid="3c5ffb16-361e-462e-b884-52b998b03d3e" Code="Device" Name="关联设备" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="b043d132-7f1f-4de1-895a-86e75f31e439" Code="BeginTime" Name="开始时间" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="18fe2bb9-4a52-4df2-a71a-34e798dba3f0" Code="EndTime" Name="结束时间" DataType="CommonType" Type="DateTime" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="3363e9fd-5b18-4f1f-bdb2-e535b0f6f589" Code="Fee" Name="使用费用" DataType="CommonType" Type="decimal" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="f926c67e-2365-4f4f-80d0-02751f5bfae7" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="User" Name="使用者" DataType="RefreceType" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="72e1c52d-e515-49a7-8f81-416173e573f2" Code="IsAppoint" Name="是否预约" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="c530b447-bfff-487a-be2b-41d151b5543a" RefGuid="66daf590-39cf-4f27-b265-a9f3f122a3e9" Code="Teacher" Name="关联导师" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="aa86bbd6-e2ad-4c15-9174-d6a3bb9d906b" Code="IsCompleted" Name="是否完成" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="d70d57e6-67a4-4924-8747-76ef9859a04e" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="House" Name="所属房间" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="d1134ec4-364c-4c1e-ab18-1814ec598f74" Code="IsUsing" Name="是否正在使用" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="8c5a5bc3-83bf-4fcc-b4f3-2356faa81a7a" Code="Price" Name="单价" DataType="CommonType" Type="decimal" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="3bfe76a8-dd7e-472f-9847-210d4be7878a" Code="TotalTime" Name="使用时间" DataType="CommonType" Type="double" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="ed7be607-7e7b-4976-b1bf-3f18efe5b9df" Code="Device" Name="设备信息" Table="T_LAB_DEVICE" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="ff4d0d9c-095b-4ee4-88ca-e412d30ff08f" Code="Name" Name="设备名称" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="66af661a-8e34-4c3e-81de-58f9379aa354" RefGuid="2d8fd942-c980-4b37-b18c-59fff1dd778f" Code="Type" Name="设备类型" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="e20e88ca-43d8-4f96-8231-381bdcff6573" Code="Expression" Name="计费方式" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="bc706696-5efe-4e16-82ee-24718d4988d6" Code="Tag" Name="搜索码" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="a3720b15-c9c1-4ae5-80f9-a08b2289967c" Code="Price" Name="设备价格" DataType="CommonType" Type="decimal" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="92be1f18-87a0-4793-9f7c-f8b45522ae85" Code="IsDelete" Name="是否删除" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="ee4d1161-0b79-4a92-b66a-1f677b15bd8c" Code="LoginLogger" Name="登陆日志" Table="T_LAB_LOGIN_LOGGER" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="c38a7917-b538-4c03-9544-70f961a1e4d1" Code="User" Name="登陆用户" DataType="CommonType" Type="long" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="8d1bf08e-ffd5-4ae5-a68e-b4361baf3666" Code="Name" Name="姓名" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="c4ad0543-0de5-42a1-bcbd-2ec6b13a46f9" Code="IP" Name="登陆IP" DataType="CommonType" Type="string" Length="100" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="7a147ce4-7abe-4a52-966a-9d4bb7db4272" Code="Success" Name="是否成功" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="0f30c932-5882-4946-9f24-ba5c898475d5" Code="ErrorMsg" Name="错误原因" DataType="CommonType" Type="string" Length="200" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="7475484c-bd66-4a46-9316-8d8378b69fc6" Code="LoginDate" Name="登录时间" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="de992b7d-abd9-4215-b486-c36f49458b97" Code="DeviceRepairRecord" Name="设备维修记录" Table="T_LAB_DEVICE_REPAIR_RECORD" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="e18118e1-a158-4686-9c3a-0bc09b33900c" RefGuid="3c5ffb16-361e-462e-b884-52b998b03d3e" Code="Device" Name="设备" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="67cac3a9-c3d7-4db1-946d-89d929873af0" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="User" Name="报修人" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="a32fd133-8777-4b8e-88e7-d7fec765df89" RefGuid="66daf590-39cf-4f27-b265-a9f3f122a3e9" Code="Teacher" Name="导师" DataType="RefreceType" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="6fdecad7-cee7-41f4-9c20-540dcaddb30e" Code="ReportDate" Name="报告日期" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="8d4f6370-cd79-41eb-9d46-cff1d765486c" Code="IsCompleted" Name="是否已经处理" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="452af41e-3644-40e8-a3c4-908da0474525" Code="CompleteDate" Name="完成时间" DataType="CommonType" Type="DateTime" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="402b86b9-d6ae-4a76-8fba-102dac34edbc" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="CompleteUser" Name="处理人" DataType="RefreceType" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="d1e6001a-cc77-42a9-8d99-6429779b30cd" Code="Fee" Name="维修费用" DataType="CommonType" Type="decimal" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="0afb9519-b89a-4d03-ab88-b9aa3919de89" Code="ReportMemo" Name="报修原因" DataType="CommonType" Type="string" Length="200" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="8b28f511-0258-4bda-9be7-69ec3823d83e" Code="RepairDate" Name="维修时间" DataType="CommonType" Type="DateTime" IsNull="1" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="3961ce6c-f0ae-4c2d-b587-43592a398d64" Code="AlarmUser" Name="提示用户" DataType="CommonType" Type="bool" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="67e8ec3b-5ed0-4447-b808-6596a2ac14fc" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="House" Name="所属房间" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="046e7e6d-0a87-4978-8110-a9d609b094ed" Code="RepairMemo" Name="维修方式" DataType="CommonType" Type="string" Length="100" IsNull="1" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="e0c346db-c277-445e-82cd-c26df5879cb0" Code="DeviceLog" Name="设备操作日志" Table="T_LAB_DEVICE_LOG" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="ce0afee6-3e28-4a59-aa06-230bb95c9f43" RefGuid="3c5ffb16-361e-462e-b884-52b998b03d3e" Code="Device" Name="关联设备" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="ed605720-e660-419b-90d8-86c0a41db17a" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="Operator" Name="操作人" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="4fbdfb73-08d5-4f10-9157-2264df058948" RefGuid="236369ec-7ec8-4b64-89fd-f16e1e3dcda4" Code="Status" Name="设备状态" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="b09a277a-377d-4150-aa71-a55e191b64e2" Code="BizDate" Name="业务日期" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
    <Entity Guid="84843ca3-f7d1-4ae2-8edd-4899f717670e" Code="ForbidUser" Name="禁止用户明细" Table="T_LAB_FORBID_USER" ViewRange="2" OrgFilter="1">
      <Attributes>
        <Attribute Guid="d424363e-8ae9-4ff2-b0dc-633ec6cbb108" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="User" Name="用户" DataType="RefreceType" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="49d64021-0582-4299-b2c7-f75c068adc87" Code="StartTime" Name="开始时间" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
        <Attribute Guid="158922c7-a155-4c51-bca1-58289d0f776d" Code="EndTime" Name="结束时间" DataType="CommonType" Type="DateTime" IsNull="0" IsViewer="0" IsBizKey="0" />
      </Attributes>
    </Entity>
  </EntityList>
  <RefrenceList>
    <Refrence Guid="cbe7e33b-bb39-4b73-b79b-da003462493f" RefProjName="实验室管理实体.be" RefrenceType="BEEntity" />
    <Refrence Guid="120a79ab-47f7-4f2b-b6dc-9e7b5b2d0326" RefProjName="实验室管理实体.be" RefrenceType="Deploy" />
  </RefrenceList>
  <EnumList>
    <Enum Guid="8e375056-7df3-4cf5-85ef-7d0238460e29" Code="TypeEnum" Name="类别枚举">
      <Attributes>
        <Attribute Guid="9e16d103-601b-4307-8fbe-c9eca803ca4d" Value="1" Code="Degree" Name="学历" />
        <Attribute Guid="aa1ea17a-c69b-463b-93b5-20be4a2cdb7d" Value="2" Code="Status" Name="身份" />
        <Attribute Guid="1d36fee4-bf72-4e5d-a684-f3ce88dd9de5" Value="3" Code="Position" Name="职位" />
        <Attribute Guid="44656337-ef71-4e5d-9102-0de42e922224" Value="4" Code="Department" Name="部门" />
        <Attribute Guid="86ba9bb8-f26c-4dfd-b4f2-558090251bd2" Value="5" Code="House" Name="房间" />
      </Attributes>
    </Enum>
    <Enum Guid="129db180-ef51-45a2-a825-bfb2ed030d0b" Code="UserTypeEnum" Name="用户类别枚举">
      <Attributes>
        <Attribute Guid="2566f9df-dbdb-4326-a73e-f9b374cd332b" Value="1" Code="User" Name="使用者" />
        <Attribute Guid="0769a85f-8b09-4971-bb54-7823fded1678" Value="2" Code="Admin" Name="管理员" />
        <Attribute Guid="80118081-23a5-4251-91f0-1b0fd6472c04" Value="3" Code="Super" Name="超级管理员" />
      </Attributes>
    </Enum>
    <Enum Guid="2d8fd942-c980-4b37-b18c-59fff1dd778f" Code="DeviceTypeEnum" Name="设备类型枚举">
      <Attributes>
        <Attribute Guid="a71c7723-c54b-45f0-a02a-e3523f28e21d" Value="1" Code="Single" Name="单用户" />
        <Attribute Guid="856fd374-c9de-4517-be35-a65a2a2d8244" Value="2" Code="Multiple" Name="多用户" />
      </Attributes>
    </Enum>
    <Enum Guid="236369ec-7ec8-4b64-89fd-f16e1e3dcda4" Code="DeviceStatusEnum" Name="设备状态">
      <Attributes>
        <Attribute Guid="7ce2d09e-3d00-4ddc-ba9e-c6aea9d0ca78" Value="1" Code="Normal" Name="正常" />
        <Attribute Guid="e16e3b7c-665d-4a79-967c-dfde0795c489" Value="2" Code="Fault" Name="故障" />
        <Attribute Guid="02d75e4e-9fb6-472c-8cd2-ba0ff4ee7156" Value="3" Code="Maintain" Name="维护" />
        <Attribute Guid="1b336024-7883-4338-aa45-86945b969ef5" Value="4" Code="Discard" Name="报废" />
      </Attributes>
    </Enum>
    <Enum Guid="1830de43-d11d-4875-b198-1d459071af53" Code="UseStatusEnum" Name="设备使用状态">
      <Attributes>
        <Attribute Guid="bd9e8a8b-aae7-400a-9803-a515ddcece98" Value="1" Code="Use" Name="使用中" />
        <Attribute Guid="49d99b52-9779-4698-85c5-3f12c082408b" Value="2" Code="Idle" Name="未使用" />
      </Attributes>
    </Enum>
    <Enum Guid="afc6184e-71e8-4290-b72f-fc73de2f67b7" Code="SexEnum" Name="性别枚举">
      <Attributes>
        <Attribute Guid="cf44f6d6-cbc0-4de9-8c7c-8a13f5933db2" Value="1" Code="Male" Name="男" />
        <Attribute Guid="f0b1a920-a43d-4e7f-9fe3-759e32be14ba" Value="2" Code="Female" Name="女" />
      </Attributes>
    </Enum>
  </EnumList>
  <Floder Guid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf" Name="DTO" />
  <DTOList>
    <DTO Guid="b9e90cf2-043a-4af8-8b23-e42a6d1e6ed9" Code="UserExDTO" Name="用户分页扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="1c8021a2-ddc7-40c9-bbfe-c979031fef63" RefGuid="4c47c367-5698-4cae-81b0-eab071ce87ab" Code="ListData" Name="用户数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
        <Attribute Guid="9f7b3fba-5369-41ea-90e6-6f0f6350986d" Type="int" Code="ListCount" Name="用户数量" DataType="CommonType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="69f4f088-32c0-4c77-a1c4-a585f6c71501" Code="GroupEnumDTO" Name="分组枚举" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="4205c8b6-16c2-4327-aa1c-ee917fe97b9c" Type="int" Code="Type" Name="枚举类别" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="9d9efdc6-4da1-465b-8961-4f018e9ff351" RefGuid="aa161d3b-4801-48f6-90b4-20f8ae57f853" Code="EnumList" Name="枚举列表" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="0b7fe778-0c41-4e95-a175-9c11ab940304" Code="DeviceExDTO" Name="设备分页扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="6470f935-bb84-49a5-b44e-cfae023b00c7" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="e17d7dbf-8f19-41db-9c44-dc3ae5e95de9" RefGuid="ed7be607-7e7b-4976-b1bf-3f18efe5b9df" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="6fae3273-bb8a-425f-8ac7-2b39e6fe6aa7" Code="LoggerExDTO" Name="登陆日志扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="fdbe00dd-d05a-46cc-9122-1a354b37e5f1" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="84a079e2-d5ec-414f-b6d2-5b60585791b4" RefGuid="ee4d1161-0b79-4a92-b66a-1f677b15bd8c" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="aeae937d-9a2f-4ff3-91dc-8e12094b1b40" Code="DeviceMapExDTO" Name="设备地图扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="e11f69b4-9394-44a6-8c54-2edf804c3728" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="9c9ea7b5-3534-4ccd-916c-a32f3f5f61fe" RefGuid="3c5ffb16-361e-462e-b884-52b998b03d3e" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="92369905-cf63-4553-b880-22b29bd87118" Code="DeviceRepairExDTO" Name="设备维修记录扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="aa6eeb8b-ada2-4bc2-ae06-8ed6d88bee55" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="c6a46ee8-742d-4006-b055-1f21c0b872ef" RefGuid="de992b7d-abd9-4215-b486-c36f49458b97" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="54546552-e50c-4f57-b0d5-006d80d26c2a" Code="DeviceUseExDTO" Name="设备使用记录扩展" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="cb405c2d-cda2-4a04-b49f-0576ac5bdcac" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="7284783c-6d8d-44da-b25b-9b1713b1429c" RefGuid="574aa9bc-55a0-464b-9507-0f66c4207a9d" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="e4971d76-53e3-4b0b-9f08-d4830049b2c9" Code="DeviceUseReportDTO" Name="设备使用报表DTO" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="f4f87d21-ba96-4c31-a984-4a47de0fd2ac" Type="string" Code="DeviceName" Name="设备名称" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="1cc59478-2a17-4bbc-b4a1-a9568f6b26e8" Type="string" Code="SN" Name="设备编码" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="484fa9c9-4a3c-4d9f-b0bb-4e3c4f963c2e" Type="DateTime" Code="StartTime" Name="开始时间" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="02797ea5-f83f-46c6-a1d7-cff72b991a78" Type="DateTime" Code="EndTime" Name="结束时间" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="114ba6a7-aa1f-49fd-ac92-e9b67185780c" Type="decimal" Code="Fee" Name="使用费用" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="ef1c2833-745d-476b-adbb-c07d446b0bec" Type="string" Code="UserName" Name="使用人" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="aa7851f4-c8af-4e1f-82d7-3f7c666289de" Type="string" Code="TeacherName" Name="导师名称" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="15dfe36f-6941-45ad-8c3d-b3e365c1f8e1" Type="long" Code="TeacherKey" Name="教师key" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="c2a0146f-8f12-4538-afcf-65ef8cb67b19" Type="string" Code="HouseName" Name="房间名称" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="cd2bf7f5-c8e3-47d6-abc2-0942f93f8aad" Type="decimal" Code="Price" Name="单价" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="e12f5e47-8459-461c-86f2-333263d03e38" Type="double" Code="Hours" Name="时长" DataType="CommonType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="7a6ddc86-fd9a-4690-b55c-216d634153de" Code="DeviceRepairReportDTO" Name="设备维修报表DTO" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="1403617e-0900-4815-a343-4002d54e4b90" Type="string" Code="DeviceName" Name="设备名称" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="5e0f694c-9bd9-42ff-9024-a8e0d9389cec" Type="string" Code="HouseName" Name="所属房间" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="aea2273e-a8ea-420c-8768-d81b37e97a3d" Type="string" Code="SN" Name="设备编码" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="190dc906-313e-4def-b19d-3ed844fe1806" Type="string" Code="StartTime" Name="操作时间" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="fca6005d-dd38-4ba2-84ba-031b1fc4bb82" Type="decimal" Code="Fee" Name="费用" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="17c21502-ede4-4b62-a4be-f042e9edd50d" Type="string" Code="Memo" Name="备注" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="41147fd7-2caf-49a3-86c3-3bd5e7b83267" Type="int" Code="Number" Name="次数" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="b820f1db-1099-494b-9c27-a7d153e95aa3" Type="long" Code="DeviceKey" Name="设备KEY" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="bc875667-2a7e-4b95-93df-79813974c9af" Type="string" Code="RepairMemo" Name="维修备注" DataType="CommonType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="82eccfd7-ffcb-447e-8fb1-848ca1df6eff" Code="DeviceUseReportExDTO" Name="设备使用报表扩展DTO" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="cae1184e-55b9-4ab0-8bfa-020e362e98cb" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="d6657339-e650-4aeb-bf20-d4a02053cbaf" RefGuid="e4971d76-53e3-4b0b-9f08-d4830049b2c9" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="d9836c4e-86dd-4c32-8e52-19f6fd6c1bb2" Code="DeviceRepairReportExDTO" Name="设备维修报表扩展DTO" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="e5aa7ac6-00ed-4fdf-ba5f-77ad7b41a3d6" Type="int" Code="ListCount" Name="数量" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="4a482c9c-d3e3-4635-b9da-36b6044eeab1" RefGuid="7a6ddc86-fd9a-4690-b55c-216d634153de" Code="ListData" Name="数据" DataType="CompositionType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
    <DTO Guid="91380dab-c473-4522-8db3-9a7d758de5e7" Code="DeviceUseDiagramDTO" Name="设备使用图形DTO" FloderGuid="ef287939-24b7-4bc1-8ddd-badf0d1b1daf">
      <Attributes>
        <Attribute Guid="f8d47226-71a7-40d9-b437-1306c36c6476" Type="string" Code="Date" Name="日期" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="79da3dc5-4a54-4d31-982c-172eaf924bb6" Type="decimal" Code="TotalHours" Name="总时间" DataType="CommonType" IsNull="0" IsViewer="0" />
        <Attribute Guid="9f37cd38-e4f9-4ca5-8b0d-58fe36898112" RefGuid="574aa9bc-55a0-464b-9507-0f66c4207a9d" Code="ListData" Name="数据明细" DataType="CompositionType" IsNull="0" IsViewer="0" />
        <Attribute Guid="227bfcbb-e4c1-49e4-853e-2838cfdbd255" Type="decimal" Code="TotalFee" Name="总费用" DataType="CommonType" IsNull="0" IsViewer="0" />
      </Attributes>
    </DTO>
  </DTOList>
</EntityProj>