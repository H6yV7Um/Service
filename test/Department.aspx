<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="test_Department" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../scripts/datepicker/WdatePicker.js" type="text/javascript"></script>
    <script src="JSDepartment.js" type="text/javascript"></script>
    <style type="text/css">
        .inputstyle{border-left-width:0px;border-top-width:0px;border-right-width:0px;border-bottom-color:gray; padding-left:10px; width:50px; }
        .table-c{ width:1024px; margin:0 auto;}
        .table-c table{width:1000px;border-right:1px solid #000000;border-bottom:1px solid #000000}
        .table-c table td{border-left:1px solid #000000;border-top:1px solid #000000;}
        .style1 { width: 100%; border: 1px solid #c0c0c0; }
     </style>
     <style media=print type="text/css">
        .noprint{visibility:hidden}
     </style>

     <script type="text/javascript">
         function Score(object) {
             var work1 = $('#tb_work1').val();
             var work2 = $('#tb_work2').val();
             var work3 = $('#tb_work3').val();
             var work4 = $('#tb_work4').val();
             var work5 = $('#tb_work5').val();
             var total = Number(work1) + Number(work2) + Number(work3) + Number(work4) + Number(work5);
             if (total > 100 ) {
                 $(object).val('');
                 alert("对不起，总比例不能超过100！");
                 $(object).focus();   
             }
         }
         function CaculateScore() {
             var work1 = $('#tb_work1').val();
             var work2 = $('#tb_work2').val();
             var work3 = $('#tb_work3').val();
             var work4 = $('#tb_work4').val();
             var work5 = $('#tb_work5').val();
             var total = Number(work1) + Number(work2) + Number(work3) + Number(work4) + Number(work5);
             if (total != 100) {
                 alert("对不起，总比例不等于100");
                 $('#tb_work1').focus();
             }
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-c">
    <h1 align="center">沭阳县中医院岗位说明书</h1>
    <h3>一、基本资料</h3>
    <div style=" overflow:hidden;">
    <table border="0" cellspacing="0" cellpadding="10" align="left">
        <tr>
            <td >
                部门名称</td>
            <td >
                <asp:TextBox ID="tb_department" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
            <td >姓名
                </td>
            <td >
                <asp:TextBox ID="tb_name" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
            <td >编号
                </td>
            <td >
                <asp:TextBox ID="tb_number" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
               技术职称/分层级别</td>
            <td>
               <asp:TextBox ID="tb_tech" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
               </td>
            <td>
                行政职务</td>
            <td>
                <asp:TextBox ID="tb_carrer" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
            <td>
                修订日期</td>
            <td>
                <asp:TextBox ID="tb_revise" runat="server" onfocus="this.blur()" onClick="WdatePicker()" BorderStyle="None" Height="25px"></asp:TextBox>
                </td>
        </tr>
    </table>
    </div>
    
    <h3>二、任用条件</h3>

    
    <div style=" overflow:hidden;">
    <table border="0" cellspacing="0" cellpadding="10" align="left">
        <tr>
            <td rowspan="6">
                学历、经历</td>
            <td>
                <asp:CheckBox ID="cb1" runat="server" />
                博士，经历：
                <asp:CheckBox ID="cb1_bs" runat="server" />是否需要
                <asp:TextBox ID="tb_bs" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历
                </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cb2" runat="server" />
                硕士，经历：
                <asp:CheckBox ID="cb2_ss" runat="server" />是否需要
                <asp:TextBox ID="tb_ss" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历
                </td>
        </tr>
        <tr>
            <td>
                 <asp:CheckBox ID="cb3" runat="server" />
                本科，经历：
                <asp:CheckBox ID="cb3_bk" runat="server" />是否需要
                <asp:TextBox ID="tb_bk" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历</td>
        </tr>
        <tr>
            <td>
                 <asp:CheckBox ID="cb4" runat="server" />
                大专，经历：
                <asp:CheckBox ID="cb4_dz" runat="server" />是否需要
                <asp:TextBox ID="tb_dz" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历</td>
        </tr>
        <tr>
            <td>
                 <asp:CheckBox ID="cb5" runat="server" />
                初、高中，经历：
                <asp:CheckBox ID="cb5_cg" runat="server" />是否需要
                <asp:TextBox ID="tb_cg" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历</td>
        </tr>
        <tr>
            <td>
                 <asp:CheckBox ID="cb6" runat="server" />
                不限制，经历：
                <asp:CheckBox ID="cb6_wu" runat="server" />是否需要
                <asp:TextBox ID="tb_wu" runat="server" 
                    class="inputstyle" Enabled="False"></asp:TextBox>年工作经历</td>
        </tr>
        <tr>
            <td>
                专业</td>
            <td>
                <asp:TextBox ID="tb_profession" runat="server" 
                    BorderStyle="None" Height="25px" Width="400px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td rowspan="4">
                专业证件</td>
            <td>
                职称证书: <asp:CheckBox ID="cb_no" runat="server" />不需要
                 <asp:CheckBox ID="cb_cjzc" runat="server" />初级职称
                  <asp:CheckBox ID="cb_zjzc" runat="server" />中级职称
                   <asp:CheckBox ID="cb_gjzc" runat="server" />高级职称
                </td>
        </tr>
        <tr>
            <td>
                执业执照: <asp:CheckBox ID="cb_zyzz" runat="server" />是否需要
                <asp:TextBox ID="tb_zyzz" runat="server" 
                    class="inputstyle" Enabled="False" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                特殊上岗证:
                 <asp:CheckBox ID="cb_tssgz" runat="server" />是否需要
                <asp:TextBox ID="tb_tssgz" runat="server" 
                    class="inputstyle" Enabled="False" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                其他:<asp:TextBox ID="tb_other" runat="server" BorderStyle="None" Height="25px" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                基本素养</td>
            <td>
                <asp:TextBox ID="tb_jbsy" runat="server" BorderStyle="None"
                    TextMode="MultiLine" Height="60px" Width="400px"></asp:TextBox></td>
        </tr>
    </table>
    </div>
    <h3>三、工作目的(工作概要)</h3>
        <asp:TextBox ID="TextBox1" runat="server" Height="100px" TextMode="MultiLine" 
            Width="1000px" BorderColor="#000000"></asp:TextBox>
     <h3>四、工作职责</h3>  
     <div style=" overflow:hidden;">
        
         <table border="0" cellspacing="0" cellpadding="10" align="left">
             <tr>
                 <td>
                     序号</td>
                 <td>
                     工作内容</td>
                 <td>
                     工作量比例（%）</td>
             </tr>
             <tr>
                 <td>
                     1</td>
                 <td><asp:TextBox ID="tb_content1" runat="server" BorderStyle="None"
                     Height="25px" Width="500px"></asp:TextBox></td>
                 <td>
                    <asp:TextBox ID="tb_work1" runat="server" 
                    BorderStyle="None" Height="25px"  onkeyup="Score('#tb_work1');" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" onafterpaste="if(isNaN(value))execCommand('undo')" MaxLength="3"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>
                     2</td>
                 <td>
                     <asp:TextBox ID="tb_content2" runat="server" BorderStyle="None"
                     Height="25px" Width="500px"></asp:TextBox></td>
                 <td>
                    <asp:TextBox ID="tb_work2" runat="server" 
                    BorderStyle="None" Height="25px" onkeyup="Score('#tb_work2');" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" onafterpaste="if(isNaN(value))execCommand('undo')" MaxLength="3" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td>
                     3</td>
                 <td>
                     <asp:TextBox ID="tb_content3" runat="server" BorderStyle="None"
                     Height="25px" Width="500px"></asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="tb_work3" runat="server" 
                    BorderStyle="None" Height="25px" onkeyup="Score('#tb_work3');" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" onafterpaste="if(isNaN(value))execCommand('undo')" MaxLength="3"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>
                     4</td>
                 <td>
                     <asp:TextBox ID="tb_content4" runat="server" BorderStyle="None"
                     Height="25px" Width="500px"></asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="tb_work4" runat="server" 
                    BorderStyle="None" Height="25px" onkeyup="Score('#tb_work4');" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" onafterpaste="if(isNaN(value))execCommand('undo')" MaxLength="3"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>
                     5</td>
                 <td>
                     <asp:TextBox ID="tb_content5" runat="server" BorderStyle="None"
                     Height="25px" Width="500px"></asp:TextBox></td>
                 <td>
                     <asp:TextBox ID="tb_work5" runat="server" 
                    BorderStyle="None" Height="25px" onkeyup="Score('#tb_work5');" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" onafterpaste="if(isNaN(value))execCommand('undo')" MaxLength="3"></asp:TextBox></td>
             </tr>
         </table>
        
     </div> 
     <p>
        <span>员工签名:</span><span style=" margin-left:500px;">日期:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</span>
     </p> 
     <p>
        <span>直接上级签字:</span><span style=" margin-left:468px;">日期:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日</span>
     </p>  
        
     <p class="noprint"><input id="Button1" type="button" value="打印" onclick="javascript:window.print()" /></p>
     <p class="noprint"><input id="Button2" type="button" value="保存" onclick="CaculateScore()" /></p>
    </div>
    </form>
</body>
</html>
