<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoListMy.aspx.cs" Inherits="test_VideoListMy" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>内容列表</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../scripts/js/layout.js"></script>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../scripts/css/pagination.css" rel="stylesheet" type="text/css" />
<style  type="text/css">
    td:hover{ cursor:pointer;}
</style>
<script type="text/javascript">
    $(function () {
        $("#btnEditAcceptInfo").click(function () { EditAcceptInfo(); }); //修改收货信息
    });

    //修改收货信息
    function EditAcceptInfo() {
        var dialog = $.dialog({
            title: '修改工单信息',
            content: 'url:dialog/dialog_accept.aspx',
            min: false,
            max: false,
            lock: true,
            width: 550,
            height: 320
        });
    }

    //发送AJAX请求
    function sendAjaxUrl(winObj, postData, sendUrl) {
        $.ajax({
            type: "post",
            url: sendUrl,
            data: postData,
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, winObj);
            },
            success: function (data, textStatus) {
                if (data.status == 1) {
                    winObj.close();
                    $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                } else {
                    $.dialog.alert('错误提示：' + data.msg, function () { }, winObj);
                }
            }
        });
    }
    
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
  <div class="l-list">
      <ul class="icon-list">
      <li style="display:none"><asp:LinkButton ID="btnUpdateWC" runat="server" CssClass="save" 
              onclick="btnUpdateWC_Click" ><i></i><span>查看全部课程</span></asp:LinkButton></li>
        <li style="display:none"><asp:LinkButton ID="btnUpdate" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btnUpdate');" onclick="btnUpdate_Click"><i></i><span>更改为处理中</span></asp:LinkButton></li>
                <li style="display:none"><asp:LinkButton ID="btn_Back" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btn_Back');" onclick="btn_Back_Click"><i></i><span>驳回</span></asp:LinkButton></li>
        <li style="display:none"><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li style="display:none"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeHolder="输入关键字查询" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->
<asp:Repeater ID="rptList1" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="5%">选择</th>
    <th align="left" width="10%">工号</th>
    <th align="left" width="20%">姓名</th>
    <th align="left" width="20%">部门名称</th>
    <th align="left" width="20%">现任职称</th>
      <th align="left" width="5%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
     <%--title="<%#getTitle(Eval("id").ToString()) %>"
     --%>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("hrmID")%>' runat="server" />
    </td>
    <td class="tdTitle"><a href="Doctor1.aspx?hrmID=<%#Eval("hrmID")%>&url=order_list"><%# Eval("hrmID")%></a></td>
    <td><%# Eval("name")%></td>
    <td><%# Eval("departname")%></td>
    <td><%# Eval("techlevel")%></td>
    <td><a href="Doctor1.aspx?hrmID=<%#Eval("hrmID")%>&url=order_list">查看医生授权</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<%--<script type="text/javascript">
    $(".ltable tr td:nth-child(2)").nextAll("td").not(":last-child").click(function () {
        //alert($(this).text());
        //alert($(this).find("span").eq(0).text());
        $('#spanAcceptName').text($(this).parent().find(".tdClass").text());
        $('#spanName').text($(this).parent().find(".tdTitle").text());
        EditAcceptInfo();
    });

</script>--%>


<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
<span id="spanAcceptName" style=" display:none"></span>
<span id="spanName" style=" display:none"></span>
</form>
</body>
</html>


