<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doctor1.aspx.cs" Inherits="test_Doctor1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .inputstyle{border-left-width:0px;border-top-width:0px;border-right-width:0px;border-bottom-color:gray; padding-left:10px; width:50px; }
        .table-c{ width:1024px; margin:0 auto;}
        .table-c table{width:1000px;border-right:1px solid #000000;border-bottom:1px solid #000000}
        .table-c table td{border-left:1px solid #000000;border-top:1px solid #000000;}
        .style1 { width: 100%; border: 1px solid #c0c0c0; }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            width: 81px;
        }
        .auto-style5 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style6 {
            width: 81px;
            background-color: #CCCCCC;
        }
        .auto-style7 {
            background-color: #CCCCCC;
        }
        .auto-style8 {
            text-align: center;
            background-color: #CCCCCC;
        }
     </style>
     <style media="print" type="text/css">
        .noprint{visibility:hidden}
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-c">
    
         <table border="0" cellspacing="0" cellpadding="10" align="left">
            <tr>
                <td class="auto-style5" colspan="8"><strong>主任医师首次医疗授权项目表</strong></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">部门名称：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style2" colspan="2">员工姓名：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style2" colspan="4">专业技术任职年限：<asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">现任职称：<asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style2" colspan="2">员工编号：<asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style2" colspan="4">到职日期：<asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="4">一般项目</td>
                <td class="auto-style8" colspan="4">特殊项目</td>
            </tr>
            <tr>
                <td class="auto-style7">授权项目</td>
                <td class="auto-style7">申请</td>
                <td class="auto-style7">授权</td>
                <td class="auto-style7">拒绝授权</td>
                <td class="auto-style7">授权项目</td>
                <td class="auto-style7">申请</td>
                <td class="auto-style7">授权</td>
                <td class="auto-style6">拒绝授权</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS1" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ1" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB1" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB11" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS2" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ2" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB2" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB12" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ3" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS3" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ3" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB3" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB3" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB13" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS4" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ4" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB4" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB14" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS5" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ5" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB5" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB15" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ6" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS6" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ6" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB6" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB6" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB16" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ7" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS7" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ7" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB7" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB7" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB17" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ8" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS8" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ8" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB8" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB8" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB18" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ9" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS9" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ9" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB9" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB9" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB19" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="SQ10" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBS10" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CBQ10" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TB10" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CB10" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="CB20" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="8">其他授权</td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Value="非限制性抗菌药物使用">非限制性抗菌药物使用</asp:ListItem>
                        <asp:ListItem>限制性抗菌药物使用</asp:ListItem>
                        <asp:ListItem>特殊抗菌药物使用</asp:ListItem>
                        <asp:ListItem>输血（需经『输血管理委员会』审查合格）</asp:ListItem>
                        <asp:ListItem>化疗处方（需经『药事管理与药物治疗学委员会』审查合格）</asp:ListItem>
                        <asp:ListItem>镇静药物  （需通过ACLS、PALS或NRP培训）</asp:ListItem>
                        <asp:ListItem>麻醉药品、第一类精神药品处方（须经『药事管理与药物治疗学委员会』审查合格）</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
             
            </table>
        
        <p>
            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" OnClientClick="return confirm('注意，一般项目授权涉及到明细，填好不要随意修改！')" />
            <asp:Button ID="Button2" runat="server" Text="维护一般项目明细" OnClick="Button2_Click" />
        </p>
    </div>
    </form>
</body>
</html>
