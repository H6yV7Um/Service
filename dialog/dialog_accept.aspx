<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_accept.aspx.cs" Inherits="dialog_dialog_accept" %>

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
            submitForm();
            return false;
        }
    }, {
        name: '取消'
    });

    //页面加载完成执行
    $(function () {
        $("#txtAcceptName").val($("#spanAcceptName", W.document).text());
        $("#txtAddress").val($("#spanName", W.document).text());
        $("#txtPostCode").val($("#spanPostCode", W.document).text());
        $("#txtMobile").val($("#spanMobile", W.document).text());
        $("#txtTelphone").val($("#spanTelphone", W.document).text());
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        
        if ($("#txtDetails").val() == "") {
            W.$.dialog.alert('请填写工单描述！', function () { $("#txtDetails").focus(); }, api);
            return false;
        }
        if ($("#ddlRoleId").val() == "") {
            W.$.dialog.alert('请选择人员！', function () { $("#ddlRoleId").focus(); }, api);
            return false;
        }
        //下一步，AJAX提交表单
        var postData = {
            "order_no": $("#spanAcceptName", W.document).text(),
            "order_details": $("#txtDetails").val(),
            "order_ddlRoleId": $("#ddlRoleId").val()
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
    <%--<dl>
      <dt>工单ID</dt>
      <dd><input type="text" id="txtAcceptName" class="input txt" /> <span class="Validform_checktip">*</span></dd>
    </dl>--%>
    <dl>
      <dt>工单标题</dt>
      <dd><input type="text" id="txtAddress" class="input normal" /> <span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
      <dt>工单描述</dt>
      <dd>
          <textarea id="txtDetails" class="input" cols="20" rows="2"></textarea></dd>
    </dl>
    <dl>
      <dt>指派人</dt>
      <dd>
          <asp:DropDownList ID="ddlRoleId" runat="server">
          </asp:DropDownList> </dd>
    </dl>
</div>
</form>
</body>
</html>
