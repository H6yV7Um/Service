<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelToData.aspx.cs" Inherits="order_ExcelToData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function IdCard(UUserCard, num) {
            if (num == 1) {
                //获取出生日期
                birth = UUserCard.substring(6, 10) + "-" + UUserCard.substring(10, 12) + "-" + UUserCard.substring(12, 14);
                return birth;
            }
            if (num == 2) {
                //获取性别
                if (parseInt(UUserCard.substr(16, 1)) % 2 == 1) {
                    //男
                    return "男";
                } else {
                    //女
                    return "女";
                }
            }
            if (num == 3) {
                //获取年龄
                var myDate = new Date();
                var month = myDate.getMonth() + 1;
                var day = myDate.getDate();
                var age = myDate.getFullYear() - UUserCard.substring(6, 10) - 1;
                if (UUserCard.substring(10, 12) < month || UUserCard.substring(10, 12) == month && UUserCard.substring(12, 14) <= day) {
                    age++;
                }
                return age;
            }
        }
//        $(function () {
//            alert(IdCard('142223198503226111', 3));
//            alert(IdCard('142223198503226111', 2));
//            alert(IdCard('142223198503226111', 1));
//        });
        function Calculate() {
            var id = document.getElementById("IDNumber").value;
            var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
            if (reg.test(id) === false) {
                alert("身份证输入不合法");
                return false;
            } else {
                var ID = $('#IDNumber').val();
                alert("年龄：" + IdCard(ID, 3) + ",  性别：" + IdCard(ID, 2) + "，  出生日期：" + IdCard(ID, 1));
                return true;
            }
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="IDNumber" type="text" />
        <input id="Button2" type="button" value="计算" onclick="return Calculate();" /><br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="批量导入" onclick="Button1_Click" />
        <p><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">下载样本示例</asp:LinkButton></p>
    </div>
    </form>
</body>
</html>
