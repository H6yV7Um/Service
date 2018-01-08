<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personal.aspx.cs" Inherits="test_Personal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        .inputstyle{border-left-width:0px;border-top-width:0px;border-right-width:0px;border-bottom-color:gray; padding-left:10px; width:50px; }
        .table-c{ width:1024px; margin:0 auto;}
        .table-c table{width:1000px;border-right:1px solid #000000;border-bottom:1px solid #000000}
        .table-c table td{border-left:1px solid #000000;border-top:1px solid #000000;}
        
     </style>
     <style media="print" type="text/css">
        .noprint{visibility:hidden}
     </style>
     <script type="text/javascript">
         $(function () {
             $('#cb_zyzs_yes').click(function () {
                 var $isChecked = $(this).is(":checked");
                 if ($isChecked) {
                     $(this).siblings().attr("checked", false);
                 }
             });
             $('#cb_zyzs_no').click(function () {
                 var $isChecked = $(this).is(":checked");
                 if ($isChecked) {
                     $(this).siblings().attr("checked", false);
                 }
             });
         });
         
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1 align="center">个人信息表</h1>
    <div class="table-c">
    
        <table border="0" cellspacing="0" cellpadding="10" align="left">
            <tr>
                <td>
                    姓名</td>
                <td>
                    <asp:TextBox ID="tb_department" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
                <td>
                    编号</td>
                <td>
                    <asp:TextBox ID="tb_department0" runat="server" BorderStyle="None" 
                        Height="25px" ></asp:TextBox>
                </td>
                <td colspan="3" rowspan="6" align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/upload/201703/mypic.jpg" 
                        Width="200px" Height="300px" />
                </td>
            </tr>
            <tr>
                <td>
                    身份证号码</td>
                <td>
                    <asp:TextBox ID="tb_department1" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
                <td>
                    科室</td>
                <td>
                    <asp:TextBox ID="tb_department2" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    性别</td>
                <td>
                    <asp:TextBox ID="tb_department3" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
                <td>
                    政治面貌</td>
                <td>
                    <asp:TextBox ID="tb_department4" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    户籍地址</td>
                <td>
                    <asp:TextBox ID="tb_department6" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
                <td>
                    婚姻状况</td>
                <td>
                    <asp:TextBox ID="tb_department5" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    居住地址</td>
                <td>
                    <asp:TextBox ID="tb_department7" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
                <td>
                    联系电话</td>
                <td>
                    <asp:TextBox ID="tb_department9" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    籍贯</td>
                <td>
                    <asp:TextBox ID="tb_department8" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
                <td>
                    集团短号</td>
                <td>
                    <asp:TextBox ID="tb_department10" runat="server" BorderStyle="None" 
                        Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    执业证书</td>
                <td>
                    <asp:CheckBox ID="cb_zyzs_yes" runat="server" />有
                    <asp:CheckBox ID="cb_zyzs_no" runat="server" />无
                </td>
                <td>
                    取得时间</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    最高职称</td>
                <td>
                    &nbsp;</td>
                <td>
                    取得时间</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    语言特长</td>
                <td>
                    &nbsp;</td>
                <td>
                    业余爱好</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td rowspan="7" align="center">
                    教<br />
                    <br />
                    育<br />
                    <br />
                    经<br />
                    <br />
                    历</td>
                <td align="center">
                    毕业时间</td>
                <td align="center">
                    学历、学位</td>
                <td align="center">
                    专业</td>
                <td align="center">
                    毕业时间</td>
                <td align="center">
                    证明人</td>
                <td align="center">
                    联系电话</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    ※最高学历查验</td>
                <td colspan="2">
                    询问对象：</td>
                <td colspan="2">
                    查验人：</td>
                <td colspan="2">
                    日期：</td>
            </tr>
            <tr>
                <td rowspan="6" align="center">
                    工<br />
                    <br />
                    作<br />
                    <br />
                    经<br />
                    <br />
                    历</td>
                <td align="center">
                    起止时间<br />
                    （由远至近填写）</td>
                <td colspan="2" align="center">
                    服务单位</td>
                <td align="center">
                    职务</td>
                <td align="center">
                    证明人</td>
                <td align="center">
                    单位联系电话</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    ※前一工作经历查验</td>
                <td colspan="2">
                    询问对象：</td>
                <td colspan="2">
                    查验人：</td>
                <td colspan="2">
                    日期：</td>
            </tr>
            <tr>
                <td rowspan="6" align="center">
                    家<br />
                    <br />
                    庭<br />
                    <br />
                    情<br />
                    <br />
                    况</td>
                <td align="center">
                    关系</td>
                <td align="center">
                    姓名</td>
                <td align="center">
                    出生年月</td>
                <td align="center">
                    服务单位</td>
                <td align="center">
                    职务</td>
                <td align="center">
                    联系电话</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
                    以上所填事项全部属实，同意核查，若有失实之处，本人愿按自动离职处理，并不要求医院给予任何赔偿。<br />
                    <br />
                    <br />
                    <span style=" float:right;">员工签名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 日期：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> </td>
            </tr>
            </table>
            <p>注：此表打印好后由本人手工签名和填写日期。表中标示【※】处由人资部填写</p>
    
    </div>
    </form>
</body>
</html>
