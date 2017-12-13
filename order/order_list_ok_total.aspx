<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_list_ok_total.aspx.cs" Inherits="order_order_list_ok_total" %>

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
<script src="../scripts/datepicker/WdatePicker.js" type="text/javascript"></script>
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

    function SetUIStyle() {
        //$.dialog.alert('正在导出，请耐心等待！');
        $.dialog.tips('正在导出，请耐心等待！', '5',"32X32/hits.png");
        //jsprint('正在导出，请耐心等待！', '20','d','');
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
      <li><asp:LinkButton ID="btnExcel" runat="server" CssClass="save" 
                onclick="btnExcel_Click" OnClientClick="SetUIStyle()" ><i></i><span>导出到Excel</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnUpdate" runat="server" CssClass="save" 
                OnClientClick="return ExePostBack1('btnUpdate');" onclick="btnUpdate_Click" Visible="False"><i></i><span>撤销为处理中</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click" Visible="False"><i></i><span>删除</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnComment" runat="server" CssClass="save" OnClientClick="return ExePostBack2('btnComment');"
                onclick="btnComment_Click" Visible="False"><i></i><span>评价</span></asp:LinkButton></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlCategoryId_SelectedIndexChanged" ></asp:DropDownList>
        </div>
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlState_SelectedIndexChanged"  ></asp:DropDownList>
        </div>
      </div>
    </div>
    <div class="r-list">
    <asp:TextBox ID="beginTime" runat="server" CssClass="keyword" onfocus="this.blur()" onClick="WdatePicker()" placeHolder="开始时间" />
     <asp:TextBox ID="endTime" runat="server" CssClass="keyword" onfocus="this.blur()" onClick="WdatePicker()" placeHolder="结束时间" />
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeHolder="标题或接收人工号" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->
<asp:Repeater ID="rptList1" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="2%"></th>
    <th align="left" width="15%">标题</th>
    <th align="left" width="15%">地址</th>
    <th align="left" width="5%">联系人</th>
    <th align="left" width="6%">电话</th>
    <th align="left" width="5%">提交人</th>
    <th align="left" width="12%">提交时间</th>
    <th align="left" width="5%">接收人</th>
    <th align="left" width="12%">接收时间</th>
    <th align="left" width="5%">状态</th>
    <th align="left" width="8%">问题类别</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td></td>
    <td><%# Eval("title")%></td>
    <td><%# Eval("address")%></td>
    <td><%# Eval("name")%></td>
    <td><%# Eval("telephone")%></td>
    <td><%# getUserName(Eval("username").ToString())%></td>
    <td><%# Eval("add_time")%></td>
    <td><%# getUserName(Eval("update_name").ToString())%></td>
    <td><%# Eval("update_time")%></td>
    <td><%#getState(Eval("state").ToString().Trim())%></td>
    <td><%#getGroupName(Eval("type").ToString())%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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




