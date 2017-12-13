<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_time_chart.aspx.cs" Inherits="order_order_time_chart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../scripts/Highcharts-4.1.9/js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../scripts/datepicker/WdatePicker.js" type="text/javascript"></script>
		<style type="text/css">
		</style>
		<script type="text/javascript">
		   $(function () {
		        $('#container').highcharts({
		            chart: {
		                type: 'line'
		            },
		            title: {
		                text: '按时间统计与我相关的工单总数'
		            },
		            subtitle: {
		                text: '折线图'
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
		                color: '#FFFFFF',
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
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">近一周数据</asp:ListItem>
            <asp:ListItem Value="1">近一月数据</asp:ListItem>
        </asp:DropDownList>
    </div>
    <script src="../scripts/Highcharts-4.1.9/js/highcharts.js" type="text/javascript"></script>
    <script src="../scripts/Highcharts-4.1.9/js/modules/exporting.js" type="text/javascript"></script>

     <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </form>
</body>
</html>
