<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestImage.aspx.cs" Inherits="test_TestImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>                                                                                                                                                                                                                                                                                                                                                                    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
        <asp:Image ID="Image1" runat="server" Height="76px" Width="97px" />
    </form>
</body>
</html>
