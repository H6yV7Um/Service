<%@ Page Language="C#" AutoEventWireup="true" CodeFile="content.aspx.cs" Inherits="manager_content" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>客服中心</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="客服中心">
    <meta name="author" content="hyy">

     <!-- The styles -->
    <link href="../css/bootstrap-cerulean.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/charisma-app.css" rel="stylesheet" type="text/css" />
    
    <link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script src="../scripts/js/layout.js" type="text/javascript"></script>
    <style type="text/css">
        .tip{ color:Red;}
    </style>
<script language="JavaScript">

    function SetUIStyle()
    {
        $('#Button1').val("正在提交...");
         $('#Button1').attr('disabled','true');
         $('#Button1').css('color','gray');
    }
    function alert1()
    {
        alert("fdfff");
    }
    function CheckForm() {
         
         

        if (document.getElementById("title").value == "") {
             
            $.dialog.alert('标题不能为空！');
            return (false);
        }
        if (document.getElementById("details").value == "") {
            $.dialog.alert('请填写问题描述！');
            return (false);
        }
        if (document.getElementById("name").value == "") {
            $.dialog.alert('联系人不能为空！');
            return (false);
        }
        
        if (document.getElementById("tel").value == "") {
            $.dialog.alert('联系电话不能为空！');
            return (false);
        }
        if (document.getElementById("address").value == "") {
            $.dialog.alert('报修地址不能为空！');
            return (false);
        }
        if (document.getElementById("number").value == "") {
            $.dialog.alert('工号不能为空！');
            return (false);
        }
        
        
        if (document.getElementById("type").value == "0") {
            $.dialog.alert('请选择问题类别！');
            return (false);
        }
        
        var $isChecked = $("#IsChecked").is(":checked");
        if ($isChecked) {
              if(document.getElementById("TbAssinger").value == ""){
                    $.dialog.alert('指定人工号不能为空！');
                    return (false);
              }
              
         }
    }
  

    function myFunction()
    {
        if($('#name').val()!="")
        {
            $.ajax({
                url:'../tools/Handler.ashx?action=checkNumber',
                type:'post',
                data:{
                    number:$('#name').val(),
                },
                success:function(data,response,status){
                    if(data!=0){
                        $('#name').val(data);
                    }else{
                        $('#name').focus();
                        alert('医院无此人，请填写职工姓名或工号！');
                        $('#name').val("");
                        //$('#name').val('医院无此人，请填写职工工号！');           
                   }
                },
            });

        }
        
    }
    function myAddressFunction() {
        var f=$('#dp_dress').val();
        if (f == "" || f == "64" || f == "65" || f == "66" || f == "67" || f == "68" || f == "69" || f == "145") {

            alert('请选择相应层数');
            $('#dp_dress').focus();
        }
        else {
            $.ajax({
                url: '../tools/Handler.ashx?action=getFloor',
                type: 'post',
                data: {
                    number: f,
                },
                success: function (data, response, status) {
                    if (data != 0) {
                        $('#address').val(data);
                    } else {
                        $('#address').val("");
                    }
                },
            });
        }

    }
    function myFunction2()
    {
        $.ajax({
                url:'../tools/Handler.ashx?action=getType',
                type:'post',
                data:{
                    number:$('#details').val(),
                },
                success:function(data,response,status){
                    if(data!="0"){
                        $('#type').val(data);  
                    }
                    else
                    {
                        $('#type').val("0");
                    }
                },
            });
    }
    function myFunctionSession()
    {
        $.ajax({
                url:'../tools/Handler.ashx?action=checkSession',
                type:'post',
                data:{
                    number:$('#number').val(),
                },
                success:function(data,response,status){
                    if(data>0){
                        alert('页面已超时，请重新登录！');
                    }
                },
            });
    }

    //全选取消按钮函数
        function checkAll(){ 
        var dd=document.getElementById("Checkbox1").value;
        if(dd="checkAll")
    {
        for(var i=0;i<document.getElementById("CheckBoxList1").getElementsByTagName("input").length;i++) 
        { 
        document.getElementById("CheckBoxList1_"+i).checked=true; 
        
        }
        document.getElementById("selectedAll").checked=false;
    }

} 
function deleteAll()
{
for(var i=0;i<document.getElementById("CheckBoxList1").getElementsByTagName("input").length;i++) 
        { 
        document.getElementById("CheckBoxList1_"+i).checked=false; 
        
        } 
        document.getElementById("Checkbox1").checked=false;
}


//全选取消按钮函数
function checkAll(chkobj) {
    if ($(chkobj).text() == "全选") {
        $(chkobj).children("span").text("取消");
        for(var i=0;i<document.getElementById("CheckBoxList1").getElementsByTagName("input").length;i++) 
        { 
        document.getElementById("CheckBoxList1_"+i).checked=true; 
        
        }
    } else {
        $(chkobj).children("span").text("全选");
        for(var i=0;i<document.getElementById("CheckBoxList1").getElementsByTagName("input").length;i++) 
        { 
        document.getElementById("CheckBoxList1_"+i).checked=false; 
        
        }
        //$(".checkall input:enabled").prop("checked", false);
    }
}

function SetUIStyle() {
        $.dialog.alert('提交失败，请填写完整！');
}
function SetUIStyle2() {
        //$.dialog.tips('提交成功！', '2')
        jsdialog('提示', "提交成功！","manager/content.aspx", "Success");
        //alert("提交成功！");
}
function SetUIStyle3() {
        $.dialog.alert('服务器出错，请稍后再试！');
        
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
                <h2>信息录入</h2>

                <div class="box-icon">
                    <%--<a href="#" class="btn btn-setting btn-round btn-default"><i
                            class="glyphicon glyphicon-cog"></i></a>
                    <a href="#" class="btn btn-minimize btn-round btn-default"><i
                            class="glyphicon glyphicon-chevron-up"></i></a><a href="http://www.healthyperson.cn/test.aspx" target="_blank">(微信扫一扫)</a>
                    <a href="#" class="btn btn-close btn-round btn-default"><i
                            class="glyphicon glyphicon-remove"></i></a>--%>
                </div>
            </div>
            <div class="box-content">
            <form id="Form1" role="form" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="control-group">
                
                <label class="control-label" for="selectError">固定资产号</label>
                    <div class="controls">
                        <asp:TextBox ID="assets" runat="server" class="form-control" placeholder="选填" ></asp:TextBox>
                    </div>
                <div class="form-group">
                        <label for="exampleInputPassword1">标题<span class="tip">*</span></label>
                        <asp:TextBox ID="title" runat="server" class="form-control" placeholder="请填写简要描述，例如“电脑无法开机”"  onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <%--<p class="help-block">标题很重要，写的很随意会导致工作人员无法第一时间处理问题！</p>--%>
                </div>
                    <label for="exampleInputPassword1">问题描述<span class="tip">*</span></label>
                    <div class="controls">
                    <asp:TextBox ID="details" runat="server" class="form-control" placeholder="请输入问题描述，例如“电脑，点击开机键没反应，电脑黑屏”" TextMode="MultiLine" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                    </div>
                    <label for="exampleInputPassword1">工号</label>
                    <div class="controls">
                    <asp:TextBox ID="number" runat="server" class="form-control" placeholder="请输入报修人工号，如果对方没有提供填自己的工号,自己没有工号填0"  ></asp:TextBox>
                    </div>
                    <label class="control-label" for="selectError">优先级</label>
                    <div class="controls">
                        <asp:DropDownList ID="dp_priority" runat="server"  class="form-control">
                            <asp:ListItem Value="0">普通</asp:ListItem>
                            <asp:ListItem Value="1">重要</asp:ListItem>
                            <asp:ListItem Value="2">紧急</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <label class="control-label" for="selectError">报修人<span class="tip">*</span></label>
                    <div class="controls">
                        <asp:TextBox ID="name" runat="server" class="form-control" placeholder="请输入报修人姓名或工号" onblur="myFunction()" ></asp:TextBox>
                    </div>
                    <label class="control-label" for="selectError">报修电话<span class="tip">*</span></label>
                    <div class="controls">
                        <asp:TextBox ID="tel" runat="server" class="form-control" placeholder="请输入报修电话" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                    </div>
                    <label class="control-label" for="selectError">报修地址<span class="tip">*</span></label>
                    <div class="controls">
                        <asp:DropDownList ID="dp_dress" runat="server"  class="form-control">
                        </asp:DropDownList>
                        <asp:TextBox ID="address" runat="server" class="form-control" placeholder="请输入报修地址" onkeydown="if(event.keyCode==32) return false" onfocus="myAddressFunction()"></asp:TextBox>
                    </div>
                    <label for="exampleInputEmail1">故障图片</label>
                <div class="controls">
                        
                        <%--<input type="file" name="Filedata" class="layui-upload-file">
                        <asp:Image ID="imgID" runat="server" Width="40px" Height="40px" style=" display:none" />--%>
                        <%--<div class="upload-box upload-img"></div>--%>
                        <%--<asp:HiddenField ID="HiddenField1" runat="server" />--%>
                        <%--<asp:TextBox ID="txtImgUrl" runat="server" onfocus="this.blur()" CssClass="form-control upload-path"  />--%>
                        <%--<input type="file" name="file" class="layui-upload-file">--%>
                        
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <p class="help-block">您可选择故障照片上传</p>
                        <asp:CheckBox ID="IsChecked" runat="server" />是否指定处理人：
                        <asp:TextBox ID="TbAssinger"  runat="server" placeholder="请输入处理人工号" Enabled="False"></asp:TextBox>
                </div>

                <%--<script>OnClientClick="return CheckForm();"
                    layui.use('upload', function () {
                        layui.upload({
                            url: '../tools/Handler.ashx',
                            success: function (res) {
                                var OldPath = res.path;
                                var NewPath = "../" + OldPath.substring(2);
                                $('#HiddenField1').val(OldPath);
                                $("#imgID").attr({ src: NewPath, alt: "Test Image" });
                                $("#imgID").show();
                                //alert(NewPath); //上传成功返回值，必须为json格式
                            }
                        });
                    });
                
    </script>--%>

                <label class="control-label" for="selectError">问题类别<span class="tip">*必选项</span></label>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="controls">
                        <asp:DropDownList ID="type" runat="server"
                            AutoPostBack="True" onselectedindexchanged="type_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        <%--<a href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a><input type="checkbox" id="Checkbox1" name="Checkbox1" onclick="checkAll()" value="checkAll"/>全选
                    <input type="checkbox" id="selectedAll" name="selectedAll" onclick="deleteAll()" value="checkAll"/>全不选--%>
                    <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>--%>
                    <asp:DropDownList ID="ddp_item" runat="server" Visible="False" 
                            onselectedindexchanged="ddp_item_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddp_item_child" runat="server" Visible="False" >
                    </asp:DropDownList>
                    
                </div>
                </ContentTemplate>
                </asp:UpdatePanel>
                
                <%--<div class="control-group">
                    <label class="control-label" for="selectError1">选择号码</label>

                    <div class="controls">
                        <asp:DropDownList ID="dd_name" runat="server" multiple class="form-control" 
                            data-rel="chosen" Width="250px" ClientIDMode="Static">
                            <asp:ListItem>111</asp:ListItem>
                            <asp:ListItem>2222</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>

                <script type="text/javascript">
                    $('#IsChecked').click(function () {
                        var $isChecked = $("#IsChecked").is(":checked");
                        if ($isChecked) {
                            $('#TbAssinger').attr("disabled", false);
                        } else {
                            $('#TbAssinger').attr("disabled", true);
                            $('#TbAssinger').focus();
                        }
                        //alert($isChecked);
                    });

                </script>
                
              </div>
                    

                    <asp:Button ID="Button1" runat="server" class="btn btn-default" 
                Text="提交" onclick="Button1_Click"   />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="btn btn-default" 
                Text="提交并发短信通知"  onclick="Button2_Click"  Visible="False" />
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


