<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doctor3.aspx.cs" Inherits="test_Doctor3" %>

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
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style2 {}
        .auto-style3 {
            height: 37px;
        }
        .auto-style4 {
            height: 37px;
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
                <td class="auto-style1" colspan="4"><strong>主任医师医疗授权评核表-首次特殊项目授权</strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="特殊项目" />
                </td>
                <td colspan="2">名称：<asp:TextBox ID="TB1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">部门名称：<asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">员工姓名：<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td colspan="2" class="auto-style3">专业技术任职年限：<asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>现任职称：<asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td>员工编号：<asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td colspan="2">到职日期：<asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">评核项目</td>
                <td class="auto-style4">评核标准</td>
                <td class="auto-style4">个人资料</td>
                <td class="auto-style4">评核结果</td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="2">Ⅰ.基本条件：取得并通过首次一般项目授权的资格</td>
                <td class="auto-style2">通过：是</td>
                <td class="auto-style2" rowspan="2">
                    <asp:RadioButtonList ID="RB1" runat="server" Width="100px">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style2" rowspan="2">
                    <asp:RadioButtonList ID="RB2" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过：否</td>
            </tr>
            <tr>
                <td colspan="4">Ⅱ.技能</td>
            </tr>
            <tr>
                <td rowspan="2">见习例数</td>
                <td>通过:≧20例</td>
                <td rowspan="2">个人:<asp:TextBox ID="TB2" runat="server"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB3" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:﹤20例</td>
            </tr>
            <tr>
                <td rowspan="3">实做例数</td>
                <td>通过:≧10 例</td>
                <td rowspan="3">个人:<asp:TextBox ID="TB3" runat="server"></asp:TextBox>
                </td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RB4" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不适用</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:﹤10 例</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>新项目</td>
                <td colspan="3">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="100px" RepeatDirection="Horizontal">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td rowspan="3">上岗证书或进修培训合格证</td>
                <td>通过:有</td>
                <td rowspan="2">证书名称:<asp:TextBox ID="TB4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RB5" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不需要</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:无</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>证书编号:<asp:TextBox ID="TB5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td rowspan="2">Ⅲ.知识：</td>
                <td>通过:各单项分数等级皆≧6分</td>
                <td>≧6分:<asp:TextBox ID="TB6" runat="server"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB6" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:任一单项分数等级≦5分</td>
                <td>≦5分:<asp:TextBox ID="TB7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB18" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB18" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB19" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB19" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB20" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB20" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB21" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB21" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB22" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB22" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB23" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB23" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="4">评语：该医师充分了解上述医疗项目的相关内容。</td>
            </tr>
            <tr>
                <td colspan="3">上述评核结果已由受评医师确认无误：</td>
                <td>
                    <asp:RadioButtonList ID="RB24" runat="server" Width="100px">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>指导者（评估者)：</td>
                <td colspan="3">日期：</td>
            </tr>
            </table>
    <p>参考依据</p>
        <p><asp:TextBox ID="mark" runat="server" TextMode="MultiLine" Height="50px" Width="1000px"></asp:TextBox></p>
        <p>
            <a href="javascript:history.back(-1);"><i></i><span>返回</span></a>
            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" /></p>
    </div>
    </form>
</body>
</html>
