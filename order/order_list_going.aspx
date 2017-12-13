<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_list_going.aspx.cs" Inherits="order_order_list_going" %>
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
<script type="text/javascript">
    $(function () {
        imgLayout();
        $(window).resize(function () {
            imgLayout();
        });
        //图片延迟加载
        $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
        //点击图片链接
        $(".pic img").click(function () {
            //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
            var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
            if (linkUrl != "") {
                location.href = linkUrl; //跳转到修改页面
            }
        });
    });
    //排列图文列表
    function imgLayout() {
        var imgWidth = $(".imglist").width();
        var lineCount = Math.floor(imgWidth / 222);
        var lineNum = imgWidth % 222 / (lineCount - 1);
        $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
        $(".imglist ul li").css("margin-right", parseFloat(lineNum));
    }
    //等比例缩放图片大小
    function AutoResizeImage(e, s) {
        var img = new Image();
        img.src = $(this).attr("src")
        var w = img.width;
        var h = img.height;
        var wRatio = w / h;
        if ((220 / wRatio) >= 165) {
            $(this).width(220); $(this).height(220 / wRatio);
        } else {
            $(this).width(165 * wRatio); $(this).height(165);
        }
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
      <li><asp:LinkButton ID="btnUpdateWC" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack2('btnUpdateWC');" 
              onclick="btnUpdateWC_Click" ><i></i><span>微信端更改状态</span></asp:LinkButton></li>
      <li><asp:LinkButton ID="refresh" runat="server" CssClass="add" 
                onclick="refresh_Click"><i></i><span>刷新</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnUpdate" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btnUpdate');" onclick="btnUpdate_Click"><i></i><span>更改为已完成</span></asp:LinkButton></li>
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
    <th align="left" width="13%">报修地址</th>
    <th align="left" width="5%">接收人</th>
    <th align="left" width="9%">接收时间</th>
    <th align="left" width="6%">联系人</th>
    <th align="left" width="8%">电话</th>
    <th align="left" width="8%">提交人员</th>
    <th align="left" width="9%">提交时间</th>
    <th width="4%">优先级</th>
    <th width="4%">状态</th>
    <th width="5%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center"><%# Eval("id")%></td>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><%# Eval("title")%></td>
    <td><%# Eval("address")%></td>
    <td><%# getUserName(Eval("update_name").ToString())%></td>
    <td><%# Eval("update_time")%></td>
    <td><%# Eval("name")%></td>
    <td><%# Eval("telephone")%></td>
    <td><%# getUserName(Eval("username").ToString())%></td>
    <td><%# Eval("add_time")%></td>
    <td align="center"><%#getPriority(Eval("priority").ToString())%></td>
    <td align="center"><%#Eval("state").ToString().Trim() == "1" ? "处理中" : "完成"%></td>
    <td align="center"><a href="order_edit.aspx?id=<%#Eval("id")%>&url=order_list_going">查看详情</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>


<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>

