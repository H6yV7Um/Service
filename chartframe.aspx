﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chartframe.aspx.cs" Inherits="chartframe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑信息</title>
<script type="text/javascript" src="scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" charset="utf-8" src="editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="scripts/js/layout.js"></script>
<link href="scripts/skin/default/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">
    function iFrameHeight() {
        var ifm = document.getElementById("iframepage");
        var subWeb = document.frames ? document.frames["iframepage"].document : ifm.contentDocument;
        if (ifm != null && subWeb != null) {
            ifm.height = subWeb.body.scrollHeight;
            ifm.width = subWeb.body.scrollWidth;
        }
    }   
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="#" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="#"><span>柱形图统计</span></a>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">柱形图（人员）</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">类别统计</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
<iframe id="ifr" src="order/order_people_chart.aspx"  frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>
<div class="tab-content" style="display:none">
<iframe id="Iframe1" src="order/order_list_ok_total.aspx"  frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>
<!--/内容-->

</form>
</body>
</html>



