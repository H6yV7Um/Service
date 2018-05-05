<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doctor2.aspx.cs" Inherits="test_Doctor2" %>

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
            text-align: center;
             font-size: x-large;
         }
         .auto-style2 {
             height: 37px;
             background-color: #CCCCCC;
         }
         .auto-style3 {
         }
         .auto-style4 {
             background-color: #CCCCCC;
         }
         .auto-style5 {
             height: 37px;
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
                <td class="auto-style1" colspan="4"><strong>主任医师医疗授权评核表-首次一般项目授权</strong></td>
            </tr>
            <tr>
                <td>部门名称：</td>
                <td>员工姓名：</td>
                <td colspan="2">专业技术任职年限：19年</td>
            </tr>
            <tr>
                <td>现任职称：</td>
                <td>员工编号：</td>
                <td colspan="2">到职日期：2016.03.20</td>
            </tr>
            <tr>
                <td class="auto-style2">评核项目</td>
                <td class="auto-style2">评核标准</td>
                <td class="auto-style2">个人资料</td>
                <td class="auto-style2">评核结果</td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style4">Ⅰ.证书</td>
            </tr>
            <tr>
                <td rowspan="2">毕业证书</td>
                <td>通过:有</td>
                <td>毕业学校及专业:徐州医学院</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:无</td>
                <td>临床医学</td>
            </tr>
            <tr>
                <td rowspan="2">医师资格证书</td>
                <td>通过:有效期内</td>
                <td>证书编号:199932110320823197207030212</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:超过有效期</td>
                <td>有效期:永久有效</td>
            </tr>
            <tr>
                <td rowspan="3">上岗证书</td>
                <td>通过:有效期内</td>
                <td>证书名称:</td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不需要</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:超过有效期</td>
                <td>证书编号:</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>有效期:</td>
            </tr>
            <tr>
                <td rowspan="2">BLS证书</td>
                <td>通过:有效期内</td>
                <td>证书编号:无</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:超过有效期</td>
                <td>有效期:2020年01月</td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style4">Ⅱ.临床能力-新聘任及新晋升之医师需填妥下列资料</td>
            </tr>
            <tr>
                <td rowspan="2">一、由任一具指导医师资格者给予完成的专业评估</td>
                <td class="auto-style5">通过:各单项分数等级皆≧6分</td>
                <td class="auto-style5">≧6分:9项</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:任一单项分数等级≦5分</td>
                <td>≦5分:0项</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4">1.熟悉胸心外科疾病的出入院标准：<br />
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4">2.掌握胸心外科常见病及疑难病的诊疗规范：<br />
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4">3.熟知胸心外科门诊诊疗的一般流程：<br />
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
                <td colspan="4">4.能协助院内疑难危重病人的诊治，并熟知会诊流程：<br />
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
                <td colspan="4">5.熟知胸心外科腔镜手术的适应症及禁忌症：<br />
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
                <td colspan="4">6.熟知胸心外科腔镜手术的正确步骤：<br />
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
                <td colspan="4">7.熟知胸心外科腔镜手术的并发症并能避免它，且一旦发生时有应对能力：<br />
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
                <td colspan="4">8.能做好胸心外科腔镜手术的术前评估与术后管理：<br />
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
                <td colspan="4">9.熟悉岗位职责，了解医学核心制度：<br />
                    <asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4">二、需完成的例数</td>
            </tr>
            <tr>
                <td rowspan="2">胸心外科疑难病诊疗</td>
                <td>通过:&gt;= 70例</td>
                <td rowspan="2">个人:100例</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList15" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:&lt;70例</td>
            </tr>
            <tr>
                <td rowspan="2">胸心外科三、四级手术</td>
                <td>通过:&gt;= 250例</td>
                <td rowspan="2">个人:300例</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList16" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:&lt;250例</td>
            </tr>
            <tr>
                <td rowspan="2">胸心外科专科门诊</td>
                <td>通过:&gt;= 40次</td>
                <td rowspan="2">个人:100例</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RadioButtonList17" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:&lt;40次</td>
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
            <asp:Button ID="Button1" runat="server" Text="保存" /></p>
    </div>
    </form>
</body>
</html>
