<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInfo.aspx.cs" Inherits="OrderInfo" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>工单信息</title>
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<link href="js/v5/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="css/v5/skin/icon/iconfont.css" rel="stylesheet" type="text/css" />
<link href="css/v5/skin/default/style.css" rel="stylesheet" type="text/css" />
<script src="js/v5/jquery/jquery-1.11.2.min.js" charset="utf-8" type="text/javascript"></script>
<script src="js/v5/jquery/Validform_v5.3.2_min.js" charset="utf-8" type="text/javascript"></script>
<script src="js/v5/artdialog/dialog-plus-min.js" charset="utf-8" type="text/javascript"></script>
<script src="js/v5/common.js" charset="utf-8" type="text/javascript"></script>
<script src="js/v5/laymain.js" charset="utf-8" type="text/javascript"></script>
<script type="text/javascript">

    
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="#"><i class="iconfont icon-home"></i><span>首页</span></a>
  <i class="arrow iconfont icon-arrow-right"></i>
  <span>工单信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this,'#ifr','order/order_list.aspx');" class="selected">待处理</a></li>
        <li><a href="javascript:;" onclick="tabs(this,'#Iframe2','order/order_list_going.aspx');">处理中</a></li>
        <li><a href="javascript:;" onclick="tabs(this,'#Iframe3','order/order_list_back.aspx');">驳回报修</a></li>
        <li><a href="javascript:;" onclick="tabs(this,'#Iframe4','order/order_list_going_confirm.aspx');">待确认<asp:Label ID="Label1" runat="server" Text=""></asp:Label></a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
<iframe id="ifr" src="order/order_list.aspx" scrolling="yes" frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>



<div class="tab-content" style="display:none">
 <iframe id="Iframe2" src="order/order_list_going.aspx" scrolling="yes" frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>

<div class="tab-content" style="display:none">
<iframe id="Iframe3" src="order/order_list_back.aspx" scrolling="yes" frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>
<div class="tab-content" style="display:none">
<iframe id="Iframe4" src="order/order_list_going_confirm.aspx" scrolling="yes"  frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>

<div class="tab-content" style="display:none">
<iframe id="Iframe1" src="order/order_list_ok.aspx" scrolling="yes"  frameborder="0" width="100%" height="650px"  name="mainFrame">
 </iframe>
</div>

<!--/内容-->


</form>
</body>
</html>
