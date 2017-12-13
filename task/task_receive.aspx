<%@ Page Language="C#" AutoEventWireup="true" CodeFile="task_receive.aspx.cs" Inherits="task_task_receive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Task_style.css" rel="stylesheet" type="text/css" />
    <link href="js/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <script src="js/easyui/jquery.min.js" type="text/javascript"></script>
    <script src="js/easyui/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_list" runat="server">
    </div>
    <asp:Button ID="Button1" runat="server" Text="一键接收" onclick="Button1_Click" />
    </form>
</body>
</html>
