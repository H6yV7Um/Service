<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoExam.aspx.cs" Inherits="test_VideoExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/StyleSheet.css" rel="stylesheet" />
 
 
     <style type="text/css">
.container ul, .container li{list-style:none;margin:0;padding:0;}

.num{ position:absolute; right:5px; bottom:5px; font:12px/1.5 tahoma, arial; height:18px;}
.num li{
	float: left;
	color: #d94b01;
	text-align: center;
	line-height: 16px;
	width: 16px;
	height: 16px;
	font-family: Arial;
	font-size: 11px;
	cursor: pointer;
	margin-left: 3px;
	border: 1px solid #f47500;
	background-color: #fcf2cf;
}
.num li.on{
	line-height: 18px;
	width: 18px;
	height: 18px;
	font-size: 14px;
	margin-top:-2px;
	background-color: #ff9415;
	font-weight: bold;
	color:#FFF;
}

.TABLE1 {
margin: 0px auto;

margin-bottom:20px;

border:1px solid #CCEFF5;

background-color: #FAFCFD

}

 

</style>
 
 
<style type="text/css"> 
    .container, .container img{width:946px;
    }
.container img{border:0;vertical-align:top;}
    .style1
    {
        width: 950px;
        height: 36px;
    }
    .style2
    {
        width: 950px;
        height: 206px;
    }
    .style3
    {
        width: 950px;
        height: 85px;
    }
</style>
 
</head>
<body background="images/DBG.jpg" >
    <form id="form1" runat="server">
    <div>
        &nbsp;<table align="center" class="TABLE1">
            <tr>
                <td align="left" class="style3">
                    <div id="idContainer2" class="container">
                        <img src="Images/TBG1.jpg" style="height: 300px" /></div>
                </td>
            </tr>

            <tr>
                <td align="middle" background="Images/TS.jpg" style="height: 37px; width: 950px;">
                  <MARQUEE onmouseover=this.stop() onmouseout=this.start() scrollAmount=4> 
                      <strong><span style="color: #000000; font-family: 楷体; font-size: 15px;">
   欢迎登录考试系统！！！考试已开始，请认真答题！！！！</span></strong></MARQUEE>
                </td>
            </tr>
            <tr>
                <td align="left" class="style2" style="width: 950px">
                    <table style="width: 944px" >
                        <tr>
                            <td style="width: 800px" valign=top>
                                    <table Width="100%">
        <tr>
            <td background="Images/Bg.jpg" align=left style="height: 30px" Width="100%">
                <strong><span style="font-size: 12pt; color: #FFFFFF;">在线测试</span></strong></td>
        </tr>
        <tr>
            <td style="width: 600px; text-align: left;">
                <table align="center" border="1" bordercolordark="#9cc7ef" bordercolorlight="#145aa0"
                    cellpadding="4" cellspacing="0" style="width: 100%">
                    <tr bgcolor="#FF9900">
                        <td colspan="1" style="height: 24px">
                            <div align="center" style="color: #FF9900">
                                <font color="#ffffff"><span><span style="font-family: 仿宋_GB2312;
                                    mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                    mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                    mso-bidi-language: AR-SA"><span style="font-family: 宋体; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'"><span style="color: #ff0000"><span style="font-size: 12pt">
                                            <strong style="color: #000000">一、单选题</strong></span></span></span></span></span></font></div>
                        </td>
                    </tr>
                    <tr>
                        <td  Width="100%">
                           <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="id"    Width="100%" 
                                onrowdatabound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                           
                                            <asp:Label ID="Label27" runat="server">
									                </asp:Label>
                                            <asp:Label ID="Label25" runat="server" Text="">
                                            </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                   
                                            <table id="Table2" align="center" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","{0}") %>'>
									                </asp:Label>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Answer") %>' Visible="False">
									                </asp:Label>
									                  
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>' Visible="False">
									                </asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="35%">
                                                        A:
                                                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Sl" Text='<%# Eval("A") %>' /></td>
                                                    <td width="35%">
                                                        B:
                                                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Sl" Text='<%# Eval("B") %>' /></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 50px" width="35%">
                                                        C:&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" GroupName="Sl" Text='<%# Eval("C") %>' /></td>
                                                    <td style="height: 50px" width="35%">
                                                        D:&nbsp;<asp:RadioButton ID="RadioButton4" runat="server" GroupName="Sl" Text='<%# Eval("D") %>' /></td>
                                                    <td style="height: 50px">
                                                    </td>
                                                </tr>

                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                            </asp:GridView>
                            </td>
                    </tr>
                    <tr bgcolor="#FF9900">
                        <td colspan="1" style="height: 24px">
                            <div align="center" style="color: #FF9900">
                                <font color="#ffffff"><span><span style="font-family: 仿宋_GB2312;
                                    mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                    mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN;
                                    mso-bidi-language: AR-SA"><span style="font-family: 宋体; mso-hansi-font-family: 'Times New Roman';
                                        mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US;
                                        mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-size: 12.0pt;
                                        mso-ascii-font-family: 'Times New Roman'"><span style="color: #ff0000"><span style="font-size: 12pt">
                                            <strong style="color: #000000">二、多选题</strong></span></span></span></span></span></font></div>
                        </td>
                    </tr>
                    <tr>
                        <td Width="100%"> 
                            &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                Width="100%" onrowdatabound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                         
                                            <asp:Label ID="Label28" runat="server">
									                </asp:Label>
                                            <asp:Label ID="Label23" runat="server" Text="">
                                            </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Title","{0}") %>'>
									                </asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Answer") %>' Visible="False">
									                </asp:Label>
									                  
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>' Visible="False">
									                </asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="height: 22px" width="35%">
                                                        A:<asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("A") %>' /></td>
                                                    <td style="height: 22px" width="35%">
                                                        B:<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("B") %>' /></td>
                                                    <td width="35%">
                                                        C:<asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("C") %>' /></td>
                                                </tr>
                                                <tr>
                                                    
                                                    <td width="35%">
                                                        D:<asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("D") %>' /></td>
                                                    <td style="height: 22px">
                                                         E:<asp:CheckBox ID="CheckBox5" runat="server" Text='<%# Eval("E") %>' /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                            </asp:GridView>
                            &nbsp;&nbsp;&nbsp;<br /> 
                            
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="交卷" OnClick="Button1_Click"  OnClientClick="return confirm('确定交卷吗？')" />
                            </div>
                        </td>
                    </tr>
                    <tr bgcolor="#FF9900">
                        <td colspan="1">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
        <br />
        &nbsp;</div>
    </form>
</body>
</html>


