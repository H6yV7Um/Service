<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonHeart.aspx.cs" Inherits="test_PersonHeart" %>

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
       
     p.MsoNormal
	{margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:10.5pt;
	font-family:"Times New Roman","serif";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
        .auto-style1 {
            height: 49px;
        }
       
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-c">
    
         <table border="0" cellspacing="0" cellpadding="10" align="left">
            <tr>
                <td colspan="2">
                    <p align="center" class="MsoNormal" style="text-align:center;mso-line-height-alt:
12.0pt;mso-layout-grid-align:none">
                        <b style="mso-bidi-font-weight:normal"><span style="font-size:20.0pt;font-family:宋体;mso-bidi-font-family:宋体">员工心理测试量表<span lang="EN-US">GAD</span>—<span lang="EN-US">7</span></span></b><b style="mso-bidi-font-weight:
normal"><span lang="EN-US" style="font-size:16.0pt;font-family:宋体;mso-bidi-font-family:
宋体"><o:p></o:p></span></b></p>
                </td>
            </tr>
            <tr>
                <td colspan="2"><b><span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:EN-US;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">在过去的两周内，有多少时候您收到以下任何问题困扰？</span></b></td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">1. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">感觉紧张，焦虑或急切</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">2. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">不能够停止或控制担忧</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">3. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">对各种各样的事情担忧过多</span></b></td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">4. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">很难放松下来</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">5. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">由于不安而无法静坐</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">6. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">变得容易烦恼或急躁</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">7. </span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">感到似乎将有可怕的事情发生而害怕</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <p align="center" class="MsoNormal" style="text-align:center;mso-line-height-alt:
12.0pt;mso-layout-grid-align:none">
                        <b style="mso-bidi-font-weight:normal"><span style="font-size:20.0pt;font-family:宋体;mso-bidi-font-family:宋体">员工心理测试量表PHQ—9</span></b><b style="mso-bidi-font-weight:
normal"><span lang="EN-US" style="font-size:16.0pt;font-family:宋体;mso-bidi-font-family:
宋体"><o:p></o:p></span></b></p>
                </td>
            </tr>
            <tr>
                <td colspan="2"><b><span style="font-size:11.0pt;font-family:宋体;
mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:EN-US;
mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">在过去的两周内，以下情况烦扰您有多频繁？</span></b></td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">1.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">做事时提不起劲或没有兴趣</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">2.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">感到心情低落，沮丧或绝望</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">3.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">入睡困难，睡不安稳或睡眠过多</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">4.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">感觉疲倦或没有活力</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">5.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">食欲不振或吃太多</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">6.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">觉得自己很糟或觉得自己很失败，或让自己或家人失望</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">7.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">对事物专注有困难，例如阅读报纸或看电视时</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">8.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">动作或说话速度缓慢到别人已经察觉？或正好相反<span lang="EN-US">--</span>烦躁或坐立不安、动来动去的情况更胜于平常</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td><b><span lang="EN-US" style="font-size:11.0pt;
font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">9.</span><span style="font-size:11.0pt;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:
1.0pt;mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:
AR-SA">有不如死掉或用某种方式伤害自己的念头</span></b></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList16" runat="server" RepeatDirection="Horizontal" Width="400px">
                        <asp:ListItem Value="0">完全不会</asp:ListItem>
                        <asp:ListItem Value="1">几天</asp:ListItem>
                        <asp:ListItem Value="2">一半以上的日子</asp:ListItem>
                        <asp:ListItem Value="3">几乎每天</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    <p>
        <asp:Button ID="Button1" runat="server" Text="保存" Height="35px" OnClick="Button1_Click" Width="81px" />
    </p>
    </div>
        
    </form>
</body>
</html>
