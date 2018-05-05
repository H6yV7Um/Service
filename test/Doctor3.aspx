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
                <td colspan="2">名称：胸腹腔镜联合食管癌根治术</td>
            </tr>
            <tr>
                <td>部门名称：胸心外科</td>
                <td>员工姓名：郁松</td>
                <td colspan="2">专业技术任职年限：18年</td>
            </tr>
            <tr>
                <td>现任职称：主任医师</td>
                <td>员工编号：220</td>
                <td colspan="2">到职日期：2016.03.20</td>
            </tr>
            <tr>
                <td>评核项目</td>
                <td>评核标准</td>
                <td>个人资料</td>
                <td>评核结果</td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="2">Ⅰ.基本条件：取得并通过首次一般项目授权的资格</td>
                <td class="auto-style2">通过：是</td>
                <td class="auto-style2" rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="100px">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style2" rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="100px">
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
                <td rowspan="2">个人:30例</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="100px">
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
                <td rowspan="3">个人:12例</td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="100px">
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
                <td rowspan="2">证书名称:</td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="100px">
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
                <td>证书编号:</td>
            </tr>
            <tr>
                <td rowspan="2">Ⅲ.知识：</td>
                <td>通过:各单项分数等级皆≧6分</td>
                <td>≧6分:6项</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:任一单项分数等级≦5分</td>
                <td>≦5分:0 项</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4">1.了解胸腹腔镜联合食管癌根治术的适应症及禁忌症：<br />
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal">
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
                <td class="auto-style3" colspan="4">2.理解胸腹腔镜联合食管癌根治术的正确步骤：<br />
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal">
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
                <td class="auto-style3" colspan="4">3.能正确地诠释异常情况：：<br />
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal">
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
                <td class="auto-style3" colspan="4">4.能根据异常情况判断下一步该如何处理：<br />
                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal">
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
                <td class="auto-style3" colspan="4">5.熟知并发症并能避免它，且一旦发生时有应对能力：<br />
                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal">
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
                <td class="auto-style3" colspan="4">6.能做好胸腹腔镜联合食管癌根治术的术前评估与术后管理：<br />
                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal">
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
                    <asp:RadioButtonList ID="RadioButtonList18" runat="server" Width="100px">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>指导者（评估者)：李统虎</td>
                <td colspan="3">日期：</td>
            </tr>
            </table>
    <p>参考依据</p>
        <p><asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="50px" Width="1000px"></asp:TextBox></p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" /></p>
    </div>
    </form>
</body>
</html>
