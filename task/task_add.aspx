<%@ Page Language="C#" AutoEventWireup="true" CodeFile="task_add.aspx.cs" Inherits="task_task_add" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <!--
        ===
        This comment should NOT be removed.

        Charisma v2.0.0

        Copyright 2012-2014 Muhammad Usman
        Licensed under the Apache License v2.0
        http://www.apache.org/licenses/LICENSE-2.0

        http://usman.it
        http://twitter.com/halalit_usman
        ===
    -->
    <meta charset="utf-8">
    <title>任务指派</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Charisma, a fully featured, responsive, HTML5, Bootstrap admin template.">
    <meta name="author" content="Muhammad Usman">

     <!-- The styles -->
    <link href="../css/bootstrap-cerulean.min.css" rel="stylesheet" type="text/css" />

    <link href="../css/charisma-app.css" rel="stylesheet">
    <link href='../bower_components/fullcalendar/dist/fullcalendar.css' rel='stylesheet'>
    <link href='../bower_components/fullcalendar/dist/fullcalendar.print.css' rel='stylesheet' media='print'>
    <link href='../bower_components/chosen/chosen.min.css' rel='stylesheet'>
    <link href='../bower_components/colorbox/example3/colorbox.css' rel='stylesheet'>
    <link href='../bower_components/responsive-tables/responsive-tables.css' rel='stylesheet'>
    <link href='../bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css' rel='stylesheet'>
    <link href='../css/jquery.noty.css' rel='stylesheet'>
    <link href='../css/noty_theme_default.css' rel='stylesheet'>
    <link href='../css/elfinder.min.css' rel='stylesheet'>
    <link href='../css/elfinder.theme.css' rel='stylesheet'>
    <link href='../css/jquery.iphone.toggle.css' rel='stylesheet'>
    <link href='../css/uploadify.css' rel='stylesheet'>
    <link href='../css/animate.min.css' rel='stylesheet'>

    <!-- jQuery -->
    <script src="../bower_components/jquery/jquery.min.js"></script>
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


<script language="JavaScript">
    function CheckForm() {



        if (document.getElementById("task_title").value == "") {
             
            $.dialog.alert('标题不能为空！');
            return (false);
        }
        if (document.getElementById("task_content").value == "") {
            $.dialog.alert('请填写问题描述！');
            return (false);
        }
        if (document.getElementById("task_start").value == "") {
            $.dialog.alert('开始时间不能为空！');
            return (false);
        }
        if (document.getElementById("tast_end").value == "") {
            $.dialog.alert('结束时间不能为空！');
            return (false);
        }



        if (document.getElementById("dp_pp").value == "0") {
            $.dialog.alert('请选择人员！');
            return (false);
        }
        
    }

        
		</script>

</head>

<body>

<div class="ch-container">

        <div id="content" class="col-lg-10 col-sm-10">
            <!-- content starts -->


<div class="row" >
    <div class="box col-md-12">
        <div class="box-inner">
            <div class="box-header well" data-original-title="">
                <h2>任务录入</h2>
            </div>
            <div class="box-content">
            <form id="Form1" role="form" runat="server">
            <div class="control-group">
                <div class="form-group">
                        <label for="exampleInputPassword1">任务标题</label>
                        <asp:TextBox ID="task_title" runat="server" class="form-control" placeholder="请填写简要描述，例如“电脑无法开机”" onblur="myFunctionSession()" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <p class="help-block">标题很重要，写的很随意会导致工作人员无法第一时间处理问题！</p>
                </div>
                <div class="form-group">
                        <label for="exampleInputPassword1">任务描述</label>
                        <asp:TextBox ID="task_content" runat="server" class="form-control" placeholder="请输入问题描述，例如“电脑，点击开机键没反应，电脑黑屏”" TextMode="MultiLine" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                </div>
                    <label class="control-label" for="selectError">开始时间：</label>
                    <div class="controls">
                        <asp:TextBox ID="task_start" onClick="WdatePicker()" runat="server" class="form-control" ></asp:TextBox>
                    </div>
                    <label class="control-label" for="selectError">结束时间：</label>
                    <div class="controls">
                        <asp:TextBox ID="tast_end" onClick="WdatePicker()" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <label class="control-label" for="selectError">指派人</label>
                    <div class="controls">
                        <asp:DropDownList ID="dp_pp" runat="server"  data-rel="chosen" >
                        </asp:DropDownList>
                    </div>
                
              </div>
                    

                    <asp:Button ID="Button1" runat="server" class="btn btn-default" 
                Text="提交"  OnClientClick="return CheckForm();" onclick="Button1_Click" />
                </form>

            </div>
        </div>
    </div>
    <!--/span-->

</div><!--/row-->

    <!-- content ends -->
    </div><!--/#content.col-md-0-->



</div><!--/.fluid-container-->


</body>
</html>


