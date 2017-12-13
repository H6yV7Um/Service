<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sms.aspx.cs" Inherits="sms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#FileUpload1').val("");
        });
        function checkSize(obj_file) {
            var _size = obj_file.files[0].size;
            if (_size > 8000000) {
                alert("文件大于8M！" + obj_file);
                $(obj_file).focus();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" OnClientClick="return confirm('确定吗？')" />


    </div>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" onchange="checkSize(this)" /> 
        <asp:Button ID="Button3" runat="server" Text="Button" />
    </p>
    </form>
</body>
</html>
