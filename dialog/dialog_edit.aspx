<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_edit.aspx.cs" Inherits="dialog_dialog_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>修改信息窗口</title>
<script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script src="../scripts/js/layout.js" type="text/javascript"></script>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            //submitForm();
            //return false;
        }
    }, {
        name: '取消'
    });

    //页面加载完成执行
    $(function () {
        $("#txtAcceptName").val($("#orderDetails", W.document).text());
        var areaArr = $("#orderDetails", W.document).text().split(",");
        var s = "";
        for (var i = 0; i < areaArr.length; i++) {
            s+=areaArr[i] + "\n\n";
        }
        $("#txtAcceptName").val(s);
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        //下一步，AJAX提交表单
        var postData = {
            "order_no": $("#orderID", W.document).text()
        };
        //发送AJAX请求
        W.sendAjaxUrl(api, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
        return false;
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="div-content">
    <dl>
      <dt>流程</dt>
      <dd>
          <asp:TextBox ID="txtAcceptName" CssClass="input" TextMode="MultiLine" Width="300px" Height="270px" runat="server"></asp:TextBox></dd>
    </dl>
</div>
</form>
</body>
</html>

