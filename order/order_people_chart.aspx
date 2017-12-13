<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_people_chart.aspx.cs" Inherits="order_order_people_chart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人员统计</title>
<link href="../scripts/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Highcharts-4.1.9/js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../scripts/datepicker/WdatePicker.js" type="text/javascript"></script>

		<script type="text/javascript">
		    $(function () {
		        $('#container').highcharts({
		            chart: {
		                type: 'column'
		            },
		            title: {
		                text: '按人员工单统计（已完成）'
		            },
		            subtitle: {
		                text: '柱形图'
		            },
		            xAxis: {
		                type: 'category',
		                labels: {
		                    rotation: -45,
		                    style: {
                                
		                        fontSize: '13px',
		                        fontFamily: 'Verdana, sans-serif'
		                    }
		                }
		            },
		            yAxis: {
		                min: 0,
		                title: {
		                    text: '工单数量'
		                }
		            },
		            legend: {
		                enabled: false
		            },
		            tooltip: {
		                pointFormat: '{series.name}: <b>{point.y}</b><br/>'
		            },
		            series: <%= returnValue %>,
		            dataLabels: {
		                enabled: true,
		                rotation: 0,
		                color: '#000000',
		                align: 'center',
		                format: '{point.y}', // one decimal
		                y: 10, // 10 pixels down from the top
		                style: {
		                    fontSize: '13px',
		                    fontFamily: 'Verdana, sans-serif'
		                }
		            }
		        }]
		    });
            });
		   

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

        function CheckForm() {
            var _s = $(":checked", "#CheckBoxList1").val();
            if (_s == null) {
                alert("请选择人员进行查询！");
                return false;
            }
         }
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <!--工具栏-->
<div class="toolbar-wrap" style=" margin-left:30px; margin-right:15px;">
  <div id="floatHead" class="toolbar">
  <div class="l-list">
      <div class="menu-list">
        <div class="rule-single-select">
        <a href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </div>
      </div>
    </div>
    <div class="r-list">
    <asp:TextBox ID="beginTime" runat="server" CssClass="keyword" onfocus="this.blur()" onClick="WdatePicker()" placeHolder="完成开始时间" />
     <asp:TextBox ID="endTime" runat="server" CssClass="keyword" onfocus="this.blur()" onClick="WdatePicker()" placeHolder="完成结束时间" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" 
            onclick="lbtnSearch_Click" OnClientClick="return CheckForm();" >查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->
    <script src="../scripts/Highcharts-4.1.9/js/highcharts.js" type="text/javascript"></script>
    <script src="../scripts/Highcharts-4.1.9/js/modules/exporting.js" type="text/javascript"></script>

     <div id="container" style="min-width: 300px; height: 400px; margin: 0 auto"></div>
    </form>
</body>
</html>

