<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_list_type.aspx.cs" Inherits="order_list_type" %>
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
        <li><asp:LinkButton ID="btnUpdate" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btnUpdate');" onclick="btnUpdate_Click"><i></i><span>更改为处理中</span></asp:LinkButton></li>
                <li><asp:LinkButton ID="btn_Back" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btn_Back');" onclick="btn_Back_Click"><i></i><span>驳回</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeHolder="输入标题或工号查询" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->
<asp:Repeater ID="rptList1" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="2%">序号</th>
    <th width="5%">选择</th>
    <th align="left" width="12%">标题</th>
    <th align="left" width="18%">问题详情</th>
    <th align="left" width="13%">报修地址</th>
    <th align="left" width="5%">联系人</th>
    <th align="left" width="8%">电话</th>
    <th align="left" width="8%">提交人员</th>
    <th align="left" width="13%">提交时间</th>
    <th width="5%">优先级</th>
    <th width="5%">状态</th>
    <th width="5%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
     <%--title="<%#getTitle(Eval("id").ToString()) %>"
     --%>
  <tr>
    <td align="center" class="tdClass" ><%#Eval("id").ToString()%></td>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td class="tdTitle"><%# Eval("title")%></td>
    <td><%# Eval("details").ToString().Length > 20 ? Eval("details").ToString().Substring(0, 20)+"..." : Eval("details").ToString()%></td>
    <td><%# Eval("address")%></td>
    <td><%# Eval("name")%></td>
    <td><%# Eval("telephone")%></td>
    <td><%# getUserName(Eval("username").ToString())%></td>
    <td><%# Eval("add_time")%></td>
    <td align="center"><%#getPriority(Eval("priority").ToString())%></td>
    <td align="center"><%#Eval("state").ToString().Trim() == "0" ? "待处理" : "完成"%></td>
    <td align="center"><a href="order_edit.aspx?id=<%#Eval("id")%>&url=order_list">查看详情</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
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


