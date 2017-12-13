<%@ Page Language="C#" AutoEventWireup="true" CodeFile="category_list_edit.aspx.cs" Inherits="order_category_list_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
<script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script src="../scripts/js/layout.js" type="text/javascript"></script>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../scripts/css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />
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
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">

    <dl>
    <dt>文件</dt>
    <dd>
            <asp:FileUpload ID="FileUpload1" CssClass="save"  runat="server" onchange="checkSize(this)" />
    </dd>
  </dl>
  <dl>
    <dt>重命名</dt>
    <dd><asp:TextBox ID="txtRename" runat="server" onBlur="change2cn(this.value, this.form.txtCallIndex)" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*可对文件重新命名</span></dd>
  </dl>
  <dl>
    <dt>版本号</dt>
    <dd><asp:TextBox ID="txtVersion" runat="server" onBlur="change2cn(this.value, this.form.txtCallIndex)" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*自定义版本号如（2017-08-29），100字符内</span></dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="上传" CssClass="btn" 
          OnClientClick="SetUIStyle()" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->


</form>
</body>
</html>




