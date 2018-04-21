<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit.aspx.cs" Inherits="order_order_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
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

    $(function () {
        $("#btnProgram").click(function () { EditAcceptInfo(); }); //修改收货信息
    });

    //修改收货信息
    function EditAcceptInfo() {
        var dialog = $.dialog({
            title: '工单处理流程',
            content: 'url:dialog/dialog_edit.aspx',
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
<style type="text/css">
#orderID,#orderDetails{ display:none;}
</style>
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
        <dt>附件</dt>
        <dd>
            <asp:Image ID="Image1" runat="server" Width="20%" Height="100px" />
            <span class="Validform_checktip">*点击图片可查看大图</span>
        </dd>
        <dt>所属类别</dt>
        <dd>
            <div class="rule-single-select">
                <asp:DropDownList ID="type" runat="server">
                </asp:DropDownList>
            </div>
        </dd>
    </dl>
    <dl>
        <dt>问题详情</dt>
        <dd style="margin-top: 5px;">
            <asp:TextBox ID="details" runat="server" CssClass="input normal" TextMode="MultiLine"
                Width="60%" Height="70px"></asp:TextBox>
        </dd>
        <dt>问题备注</dt>
        <dd style="margin-top: 5px;">
            <asp:TextBox ID="mark" runat="server" CssClass="input normal" placeholder="可填写备注"
                TextMode="MultiLine" Width="60%" Height="70px"></asp:TextBox>
        </dd>
        <dt>固定资产号</dt>
        <dd style="margin-top: 5px;">
            <asp:TextBox ID="assets" runat="server" CssClass="input normal"  ></asp:TextBox><a href="http://www.healthyperson.cn/Page/AutoRun/searchbarcode.aspx?id=<%=id%>" target="_blank">(微信扫一扫)</a>
        </dd>
        <dt>满意度</dt>
        <dd>
            <asp:Image ID="star1" runat="server" ImageUrl="~/img/star-on.png" Visible="False" />
            <asp:Image ID="star2" runat="server" ImageUrl="~/img/star-on.png" Visible="False"/>
            <asp:Image ID="star3" runat="server" ImageUrl="~/img/star-on.png" Visible="False"/>
            <asp:Image ID="star4" runat="server" ImageUrl="~/img/star-on.png" Visible="False"/>
            <asp:Image ID="star5" runat="server" ImageUrl="~/img/star-on.png" Visible="False"/>
            <asp:Label ID="LbStar" runat="server" Text="暂无评分"></asp:Label>
        </dd>
        <%--<dt>处理流程</dt>
    <dd style=" margin-top:5px;">
        <input id="btnProgram" type="button" value="查看处理流程" />
    </dd>--%>
    </dl>
</div>
<!--/内容-->
<asp:Label ID="orderID" runat="server" Text=""></asp:Label>
<asp:Label ID="orderDetails" runat="server" Text=""></asp:Label>
<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
<!--弹框-->
<div class="cd-popup">
    <div class="cd-popup-container">
        <asp:Image ID="Image2" Width="495" Height="495" runat="server"/>
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


