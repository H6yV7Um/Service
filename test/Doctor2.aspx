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
         .auto-style6 {
             height: 53px;
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
                <td>部门名称：<asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>员工姓名：<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td colspan="2">专业技术任职年限：<asp:Label ID="Label3" runat="server"></asp:Label>
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
                <td rowspan="2">毕业学校及专业:<asp:TextBox ID="TB1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB1" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:无</td>
            </tr>
            <tr>
                <td rowspan="2">医师资格证书</td>
                <td>通过:有效期内</td>
                <td>证书编号:<asp:TextBox ID="TB21" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB2" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">不通过:超过有效期</td>
                <td class="auto-style6">有效期:<asp:TextBox ID="TB22" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td rowspan="3">上岗证书</td>
                <td>通过:有效期内</td>
                <td>证书名称:<asp:TextBox ID="TB31" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RB3" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不需要</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td rowspan="2">不通过:超过有效期</td>
                <td>证书编号:<asp:TextBox ID="TB32" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>有效期:<asp:TextBox ID="TB33" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td rowspan="2">BLS证书</td>
                <td>通过:有效期内</td>
                <td>证书编号:<asp:TextBox ID="TB41" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB4" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:超过有效期</td>
                <td>有效期:<asp:TextBox ID="TB42" runat="server"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td rowspan="3">ACLS证书</td>
                <td>通过:有效期内</td>
                <td>证书名称:<asp:TextBox ID="TB51" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                <td rowspan="2">不通过:超过有效期</td>
                <td>证书编号:<asp:TextBox ID="TB52" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>有效期:<asp:TextBox ID="TB53" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td rowspan="3">PALS证书</td>
                <td>通过:有效期内</td>
                <td>证书名称:<asp:TextBox ID="TB61" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RB6" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不需要</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td rowspan="2">不通过:超过有效期</td>
                <td>证书编号:<asp:TextBox ID="TB62" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>有效期:<asp:TextBox ID="TB63" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td rowspan="3">NRP证书</td>
                <td>通过:有效期内</td>
                <td>证书名称:<asp:TextBox ID="TB71" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td rowspan="3">
                    <asp:RadioButtonList ID="RB7" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                        <asp:ListItem>不需要</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td rowspan="2">不通过:超过有效期</td>
                <td>证书编号:<asp:TextBox ID="TB72" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>有效期:<asp:TextBox ID="TB73" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style4">Ⅱ.临床能力-新聘任及新晋升之医师需填妥下列资料</td>
            </tr>
            <tr>
                <td rowspan="2">一、由任一具指导医师资格者给予完成的专业评估</td>
                <td class="auto-style5">通过:各单项分数等级皆≧6分</td>
                <td class="auto-style5">≧6分:<asp:TextBox ID="TB81" runat="server"></asp:TextBox>
                    项</td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB8" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:任一单项分数等级≦5分</td>
                <td>≦5分:<asp:TextBox ID="TB82" runat="server"></asp:TextBox>
                    项</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4"><asp:TextBox ID="TB10" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB10" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB11" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB11" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB12" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB12" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB13" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB13" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB14" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB14" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB15" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB15" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB16" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB16" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB17" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RB17" runat="server" RepeatDirection="Horizontal">
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
                <td colspan="4"><asp:TextBox ID="TB18" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
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
                <td colspan="4"><asp:TextBox ID="TB19" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
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
                <td colspan="4">二、需完成的例数</td>
            </tr>
            <tr>
                <td rowspan="2"><asp:TextBox ID="TB20" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>通过:&gt;= 70例</td>
                <td rowspan="2">个人:<asp:TextBox ID="TB30" runat="server"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB20" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:&lt;70例</td>
            </tr>
            <tr>
                <td rowspan="2"><asp:TextBox ID="TBS1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>通过:&gt;= 250例</td>
                <td rowspan="2">个人:<asp:TextBox ID="TBS2" runat="server"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB30" runat="server" Width="100px">
                        <asp:ListItem>通过</asp:ListItem>
                        <asp:ListItem>不通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>不通过:&lt;250例</td>
            </tr>
            <tr>
                <td rowspan="2"><asp:TextBox ID="TBS3" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>通过:&gt;= 40次</td>
                <td rowspan="2">个人:<asp:TextBox ID="TBS4" runat="server"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RadioButtonList ID="RB40" runat="server" Width="100px">
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
                    <asp:RadioButtonList ID="RB50" runat="server" Width="100px">
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
        <p> <a href="javascript:history.back(-1);"><i></i><span>返回</span></a>
            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" /></p>
    </div>
    </form>
</body>
</html>
