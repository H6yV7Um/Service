﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="category_list_item.aspx.cs" Inherits="order_category_list_item" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>内容列表</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script src="../scripts/jquery/jquery.media.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../scripts/js/layout.js"></script>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../scripts/css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $('#FileUpload1').val("");
    });
    function checkSize(obj_file) {
        var _size = obj_file.files[0].size;
        if (_size > 1073741824) {
            alert("文件大于1G了！");
            $(obj_file).focus();
            $('#FileUpload1').val("");
        }
    }
    function SetUIStyle() {
        if ($('#FileUpload1').val() != "") {
            $.dialog.alert('正在上传，请耐心等待！');
        }
        
        //$.dialog.tips('正在导出，请耐心等待！', '5', "32X32/hits.png");
        //jsprint('正在导出，请耐心等待！', '20','d','');
    }
    </script>

 
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="category_list.aspx" class="back"><i></i><span>返回上一页</span></a>
  <%--<i class="arrow"></i>--%>
  <span><asp:FileUpload ID="FileUpload1" CssClass="save"  runat="server" onchange="checkSize(this)" Visible="False" /></span>
</div>
<!--/导航栏-->
<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
  <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="category_list_edit.aspx?id=<%= this.id %>"><i></i><span>上传</span></a></li>
        <li><asp:LinkButton ID="btnUpdate" runat="server" CssClass="add" OnClientClick="SetUIStyle()"  onclick="btnUpdate_Click" Visible="False"><i></i><span>上传</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeHolder="输入关键字" />
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
    <th align="left" width="20%">文件名</th>
    <th align="left" width="10%">大小</th>
    <th align="left" width="10%">上传人</th>
    <th align="left" width="10%">上传时间</th>
    <th align="left" width="10%">责任人</th>
    <th align="left" width="10%">查验时间</th>
    <th align="left" width="10%">校期时间</th>
    <th width="20%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
     <%--title="<%#getTitle(Eval("id").ToString()) %>"
     --%>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><a href="../<%# Eval("filePath").ToString().Substring(2) %>" target="_blank"><%# Eval("fileName")%></a></td>
    <%--<td><a href="../upload/201709/19/烽火MAS2.0数据库接口文档.pdf">PDF File</a> </td>--%>
    <td><%# HumanReadableFilesize(Convert.ToDouble(Eval("fileSize")))%></td>
    <td><%# getUserName(Eval("username").ToString())%></td>
    <td><%# Eval("add_time")%></td>
    <%--<td><a href="category_list_item_version.aspx?id=<%#Eval("fileVersion")%>"><%# getVersion(Eval("fileVersion").ToString())%></a></td>--%>
    <td><%# Eval("name")%></td>
    <td><%# Eval("revise_time")%></td>
    <td><%# Eval("long_time")%></td>
    <td align="center"><a href="download.aspx?id=<%#Eval("id")%>">下载</a>
        <a href="category_list_edit.aspx?id=<%#Eval("id")%>&typeid=<%=DTRequest.GetQueryInt("id")%>">编辑</a>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>



<!--内容底部-->
<%--<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>--%>
<!--/内容底部-->
</form>
</body>
</html>


