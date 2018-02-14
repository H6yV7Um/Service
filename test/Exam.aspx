<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="test_Exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="panel" runat="server">
    <p>一、单项选择题</p>
        <%--1.继续护理学教育是：
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="a">终身性护理学教育</asp:ListItem>
            <asp:ListItem Value="b">护理学历教育</asp:ListItem>
            <asp:ListItem Value="c">规范化专业培训</asp:ListItem>
            <asp:ListItem Value="d">护理知识培训</asp:ListItem>
        </asp:RadioButtonList>--%>
    </div>
        <div id="panel2" runat="server">
            <p>二、多项选择</p>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>

</html>
