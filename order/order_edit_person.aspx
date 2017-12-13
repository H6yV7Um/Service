<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit_person.aspx.cs" Inherits="order_order_edit_person" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script src="../scripts/js/layout.js" type="text/javascript"></script>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../scripts/css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        $("#Image1").click(function () {
            //alert("fdff");
            //$(this).css("display", "none");
            //$(this).css("width", "1020px");
        });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">查看附件</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    
    <%--<dt>附件</dt>
    
    <dd>
      <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" />
      <span class="Validform_checktip">*点击图片可查看大图</span>
    </dd>
    <dt>问题详情</dt>
    <dd>
        <asp:TextBox ID="details" runat="server"  CssClass="input normal" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
    </dd>
    <br />
    <dt>问题备注</dt>
    <dd>
        <asp:TextBox ID="mark" runat="server"  CssClass="input normal" placeholder="可填写备注" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
    </dd>
    <br />--%>
    <dt>工单处理流程</dt>
    <dd>
        <asp:TextBox ID="flow" runat="server"  CssClass="input normal"  TextMode="MultiLine" Width="500px" Height="370px"></asp:TextBox>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
<!--弹框-->
<div class="cd-popup">
    <div class="cd-popup-container">
        <asp:Image ID="Image2" runat="server"/>
        <a href="#0" class="cd-popup-close">关闭</a>
    </div>
    
</div>

<script type="text/javascript">
    /*弹框JS内容*/
    jQuery(document).ready(function ($) {
        //打开窗口
        $('#Image1').on('click', function (event) {
            event.preventDefault();
            $('.cd-popup').addClass('is-visible');
            //$(".dialog-addquxiao").hide()
        });
        //关闭窗口
        $('.cd-popup').on('click', function (event) {
            if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup')) {
                event.preventDefault();
                $(this).removeClass('is-visible');
            }
        });
        //ESC关闭
        $(document).keyup(function (event) {
            if (event.which == '27') {
                $('.cd-popup').removeClass('is-visible');
            }
        });

        //打开窗口
        $('.cd-popup-trigger1').on('click', function (event) {
            event.preventDefault();
            $('.cd-popup1').addClass('is-visible1');
            //$(".dialog-addquxiao").hide()
        });
        //关闭窗口
        $('.cd-popup1').on('click', function (event) {
            if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup1')) {
                event.preventDefault();
                $(this).removeClass('is-visible1');
            }
        });
        //ESC关闭
        $(document).keyup(function (event) {
            if (event.which == '27') {
                $('.cd-popup1').removeClass('is-visible1');
            }
        });

        //打开窗口
        $('.cd-popup-trigger2').on('click', function (event) {
            event.preventDefault();
            $('.cd-popup2').addClass('is-visible2');
            //$(".dialog-addquxiao").hide()
        });
        //关闭窗口
        $('.cd-popup2').on('click', function (event) {
            if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup2')) {
                event.preventDefault();
                $(this).removeClass('is-visible2');
            }
        });
        //ESC关闭
        $(document).keyup(function (event) {
            if (event.which == '27') {
                $('.cd-popup2').removeClass('is-visible2');
            }
        });

        //打开窗口
        $('.cd-popup-trigger3').on('click', function (event) {
            event.preventDefault();
            $('.cd-popup3').addClass('is-visible3');
            //$(".dialog-addquxiao").hide()
        });
        //关闭窗口
        $('.cd-popup3').on('click', function (event) {
            if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup3')) {
                event.preventDefault();
                $(this).removeClass('is-visible3');
            }
        });
        //ESC关闭
        $(document).keyup(function (event) {
            if (event.which == '27') {
                $('.cd-popup3').removeClass('is-visible3');
            }
        });
    });
</script>
</form>
</body>
</html>



