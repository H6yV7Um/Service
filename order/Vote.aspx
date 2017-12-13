<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vote.aspx.cs" Inherits="order_Vote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .table-c table{border-right:1px solid gray;border-bottom:1px solid gray}
        .table-c table td{border-left:1px solid gray;border-top:1px solid gray}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-c">
    <h2>病人安全文化调查问卷</h2>
    <p>您好：
为了解医院病人安全文化现状，本部门根据美国德州大学医院安全态度量表设计出适合本院实际情况的调查表，现面向全院职工进行不记名问卷调查，请各位独立填写，不要抄写或代填，确保调查结果真实有效，以利于医院下一步工作的开展，谢谢！
质管办
2017年09月13日制
</p>
<h4>第一部分:您的工作区域/科室</h4>
<p>请依您在我院最主要的工作区域或科室“择一”作答</p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal" >
            <asp:ListItem Value="1">1.重症监护病房</asp:ListItem>
            <asp:ListItem Value="2">2.手术麻醉科</asp:ListItem>
            <asp:ListItem Value="3">3.急诊</asp:ListItem>
            <asp:ListItem Value="4">4.心血管内科</asp:ListItem>
            <asp:ListItem Value="5">5.呼吸内科</asp:ListItem>
            <asp:ListItem Value="6">6.肾内科/血液净化中心</asp:ListItem>
            <asp:ListItem Value="7">7.消化内科/消化内镜中心</asp:ListItem>
            <asp:ListItem Value="8">8.神经内科</asp:ListItem>
            <asp:ListItem Value="9">9.血液内科</asp:ListItem>
            <asp:ListItem Value="10">10.内分泌科</asp:ListItem>
            <asp:ListItem Value="11">11.儿科/新生儿</asp:ListItem>
            <asp:ListItem Value="12">12.整形外科</asp:ListItem>
            <asp:ListItem Value="13">13.胸心外科</asp:ListItem>
            <asp:ListItem Value="14">14.胃肠外科/肛肠外科</asp:ListItem>
            <asp:ListItem Value="15">15.骨病外科/关节外科</asp:ListItem>
            <asp:ListItem Value="16">16.脊柱外科/修复重建外科</asp:ListItem>
            <asp:ListItem Value="17">17.乳甲胰腺外科/肝胆外科</asp:ListItem>
            <asp:ListItem Value="18">18.泌尿外科</asp:ListItem>
            <asp:ListItem Value="19">19.神经外科</asp:ListItem>
            <asp:ListItem Value="20">20.老年病科</asp:ListItem>
            <asp:ListItem Value="21">21.耳鼻咽喉科</asp:ListItem>
            <asp:ListItem Value="22">22.康复科</asp:ListItem>
            <asp:ListItem Value="23">23.药学</asp:ListItem>
            <asp:ListItem Value="24">24.妇产科</asp:ListItem>
            <asp:ListItem Value="25">25.感染科</asp:ListItem>
            <asp:ListItem Value="26">26.体检中心</asp:ListItem>
            <asp:ListItem Value="27">27.放射科/超声科</asp:ListItem>
            <asp:ListItem Value="28">28.眼科</asp:ListItem>
            <asp:ListItem Value="29">29.输血科/检验科/病理科</asp:ListItem>
            <asp:ListItem Value="30">30.口腔</asp:ListItem>
            <asp:ListItem Value="31">31.其它</asp:ListItem>
        </asp:RadioButtonList>
    <h4>第二部分：您的认同程度</h4>
    <p>请依您对问题认同的程度，在右列选项□中打勾，共计42题。若您的科室可能并不适合或无法回答该题，请您填写“不适用”。 A团队合作B安全风气C工作满意D压力认知E管理感受F工作状况G整体医安风气。</p>
        <table style="width:100%;" border="0" cellspacing="0" cellpadding="0">

        <tr>
            <td>
               項目</td>
            <td>
                操作</td>
        </tr>
        <tr>
            <td>
               A1、本科室能充分接受同仁意见。</td>
            <td>
                <asp:RadioButtonList ID="A1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>

        </tr>
        <tr>
            <td>
               A2、在本科室当我发现病人照护问题时，会主动提出。</td>
            <td>
                <asp:RadioButtonList ID="A2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>

        </tr>
        <tr>
            <td>A3、在本科室意见分歧时，可得到妥善解决。</td>
            <td>
                <asp:RadioButtonList ID="A3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>A4、当我照护病人需要其他同仁支援时，我可以获得支持。</td>
            <td>
                <asp:RadioButtonList ID="A4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>A5、在本科室工作人员有不明确的地方，可以安心提问。</td>
            <td>
                <asp:RadioButtonList ID="A5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>A6、在本科室医师与护理人员是一个同心协力的工作团队。</td>
            <td>
                <asp:RadioButtonList ID="A6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B1、如果我是病人在这里接受治疗，我会觉得安全。</td>
            <td>
                <asp:RadioButtonList ID="B1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B2、本科室能够妥善处理医疗错误。</td>
            <td>
                <asp:RadioButtonList ID="B2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B3、在本科室我知道如何运用适当的渠道反映病人安全的问题。</td>
            <td>
                <asp:RadioButtonList ID="B3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B4、我的工作表现会得到合理的反馈。</td>
            <td>
                <asp:RadioButtonList ID="B4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B5、在本科室可以讨论错误。</td>
            <td>
                <asp:RadioButtonList ID="B5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B6、同事会鼓励我去反应与病人安全相关的疑虑。</td>
            <td>
                <asp:RadioButtonList ID="B6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>B7、本科室的文化激励我从别人的错误汲取教训。</td>
            <td>
                <asp:RadioButtonList ID="B7" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>C1、我喜欢我的工作。</td>
            <td>
                <asp:RadioButtonList ID="C1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>C2、在科室工作就像是大家庭中的一份子。</td>
            <td>
                <asp:RadioButtonList ID="C2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>C3、医院是个好的工作场所。</td>
            <td>
                <asp:RadioButtonList ID="C3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>C4、我以在本科室工作为荣。</td>
            <td>
                <asp:RadioButtonList ID="C4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>C5、本科室的士气高。</td>
            <td>
                <asp:RadioButtonList ID="C5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D1、本科室管理层支持我日常工作。</td>
            <td>
                <asp:RadioButtonList ID="D1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D2、本科室管理层重视病人安全。</td>
            <td>
                <asp:RadioButtonList ID="D2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D3、本科室人员编制足以处理病人工作量。</td>
            <td>
                <asp:RadioButtonList ID="D3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D4、对于会影响我工作的事件，本科室管理层及时提供充分的讯息。</td>
            <td>
                <asp:RadioButtonList ID="D4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D5、本科室管理层做得好。</td>
            <td>
                <asp:RadioButtonList ID="D5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D6、医院管理层支持我日常工作。</td>
            <td>
                <asp:RadioButtonList ID="D6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D7、医院管理层重视病人安全。</td>
            <td>
                <asp:RadioButtonList ID="D7" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D8、医院人员编制足以应付患者的数量。</td>
            <td>
                <asp:RadioButtonList ID="D8" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D9、对于会影响我工作的事件，医院管理层会及时提供充分的讯息。</td>
            <td>
                <asp:RadioButtonList ID="D9" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>D10、医院管理层做得好。</td>
            <td>
                <asp:RadioButtonList ID="D10" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>E1、医院以建设性的态度处理有问题的员工。</td>
            <td>
                <asp:RadioButtonList ID="E1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>E2、我容易取得诊断和治疗所必要的资料。</td>
            <td>
                <asp:RadioButtonList ID="E2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>E3、在我的专业领域，受训人员都受到适当的监督。</td>
            <td>
                <asp:RadioButtonList ID="E3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>E4、医院有好的新进人员培训计划并执行。</td>
            <td>
                <asp:RadioButtonList ID="E4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>F1、疲劳削弱我在紧急状况下的表现（如抢救、病人抽搐）。</td>
            <td>
                <asp:RadioButtonList ID="F1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>F2、当我工作负荷过重时，我的工作表现会有负面影响。</td>
            <td>
                <asp:RadioButtonList ID="F2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>F3、我疲劳时，工作效率减低。</td>
            <td>
                <asp:RadioButtonList ID="F3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>F4、在紧张或敌对的情况下，我较会犯错。</td>
            <td>
                <asp:RadioButtonList ID="F4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G1、医院通常在不良事件发生前，管理层就已经重视病人安全。</td>
            <td>
                <asp:RadioButtonList ID="G1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G2、与其他部门合作，通常很愉快。</td>
            <td>
                <asp:RadioButtonList ID="G2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G3、病人转科流程顺畅。</td>
            <td>
                <asp:RadioButtonList ID="G3" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G4、重要病人照护资讯，通常在交接班时不会遗漏。</td>
            <td>
                <asp:RadioButtonList ID="G4" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G5、在部门间交换资讯过程中，不会发生问题。</td>
            <td>
                <asp:RadioButtonList ID="G5" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G6、护理与我合作很好。</td>
            <td>
                <asp:RadioButtonList ID="G6" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G7、医生与我合作很好。</td>
            <td>
                <asp:RadioButtonList ID="G7" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G8、药师与我合作很好。</td>
            <td>
                <asp:RadioButtonList ID="G8" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G9、整体而言，在医院接受治疗，患者是安全的。</td>
            <td>
                <asp:RadioButtonList ID="G9" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>G10、整体而言，在医院工作我感到安全。</td>
            <td>
                <asp:RadioButtonList ID="G10" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">非常不同意</asp:ListItem>
                    <asp:ListItem Value="1">不同意</asp:ListItem>
                    <asp:ListItem Value="2">普通</asp:ListItem>
                    <asp:ListItem Value="3">同意</asp:ListItem>
                    <asp:ListItem Value="4">非常同意</asp:ListItem>
                    <asp:ListItem Value="5">无法判断</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
    </table>
    <p>二、员工疲劳状况调查，无正确答案，请依您实际的情况作答。</p>
    <p>1、过去一周您是否有以下状况（可复选）： (多选题 *必答)</p>
    <p>
        <asp:CheckBoxList ID="week" runat="server">
            <asp:ListItem Value="0">因为工作而有一餐没吃？</asp:ListItem>
            <asp:ListItem Value="1">吃了一顿不均衡的膳食？</asp:ListItem>
            <asp:ListItem Value="2">上班时，没有任何休息？</asp:ListItem>
            <asp:ListItem Value="3">因为工作而改变个人/家庭计划？</asp:ListItem>
            <asp:ListItem Value="4">因为工作而晚归？</asp:ListItem>
            <asp:ListItem Value="5">喝太多咖啡/其他提神的饮料？</asp:ListItem>
        </asp:CheckBoxList>
    </p>
    <p>2、今天刚开始上班时，请评估自己的精神如何？ (单选题 *必答)</p>
    <p>
        <asp:RadioButtonList ID="mind" runat="server">
            <asp:ListItem Value="0">完全清醒和警觉</asp:ListItem>
            <asp:ListItem Value="1">非常活跃</asp:ListItem>
            <asp:ListItem Value="2">还好</asp:ListItem>
            <asp:ListItem Value="3">有点累</asp:ListItem>
            <asp:ListItem Value="4">中等累，松懈下来 </asp:ListItem>
            <asp:ListItem Value="5">极度疲倦，非常难以专注 </asp:ListItem>
            <asp:ListItem Value="6">无法有效率的执勤时，您是否仍直接接触病人？</asp:ListItem>
        </asp:RadioButtonList>
        </p>
    <p>3、您上次上班，排班表安排您上几小时的班？ (单选题 *必答)</p>
    <p>
        <asp:RadioButtonList ID="hour1" runat="server">
            <asp:ListItem Value="0"><10小时； </asp:ListItem>
            <asp:ListItem Value="1">10-12小时；</asp:ListItem>
            <asp:ListItem Value="2">>12-16小时； </asp:ListItem>
            <asp:ListItem Value="3">>16小时 </asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>4、您上次上班，您实际上几小时？ (单选题 *必答)</p>
    <p><asp:RadioButtonList ID="hour2" runat="server">
            <asp:ListItem Value="0"><10小时； </asp:ListItem>
            <asp:ListItem Value="1">10-12小时；</asp:ListItem>
            <asp:ListItem Value="2">>12-16小时； </asp:ListItem>
            <asp:ListItem Value="3">>16小时 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>5、上周，排班表安排您连续两班之间（从下班到下一次上班）最短间隔几小时？ (单选题 *必答)</p>
    <p><asp:RadioButtonList ID="hour3" runat="server">
            <asp:ListItem Value="0">>12小时；  </asp:ListItem>
            <asp:ListItem Value="1">10-12小时； </asp:ListItem>
            <asp:ListItem Value="2">8-<10小时； </asp:ListItem>
            <asp:ListItem Value="3"><8小时 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>6、上周，实际上您连续两班之间（从下班到下一次上班）最短间隔几小时？ (单选题 *必答)</p>
    <p><asp:RadioButtonList ID="hour4" runat="server">
            <asp:ListItem Value="0">>12小时；  </asp:ListItem>
            <asp:ListItem Value="1">10-12小时； </asp:ListItem>
            <asp:ListItem Value="2">8-<10小时； </asp:ListItem>
            <asp:ListItem Value="3"><8小时 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>7、从今天上班往前24小时，您实际睡了几小时？ (单选题 *必答)</p>
    <p><asp:RadioButtonList ID="hour5" runat="server">
            <asp:ListItem Value="0">>7小时；  </asp:ListItem>
            <asp:ListItem Value="1">6-7小时；  </asp:ListItem>
            <asp:ListItem Value="2">5-<6小时；  </asp:ListItem>
            <asp:ListItem Value="3"><5小时  </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>8、从今天上班往前48小时，您实际睡了几小时？ (单选题 *必答)</p>
     <p><asp:RadioButtonList ID="hour6" runat="server">
            <asp:ListItem Value="0">>12小时；  </asp:ListItem>
            <asp:ListItem Value="1">12-14小时； </asp:ListItem>
            <asp:ListItem Value="2">>14-16小时；  </asp:ListItem>
            <asp:ListItem Value="3">>16小时 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>9、从今天起床（醒）直到下班，您会一直清醒几小时？ (单选题 *必答)</p>
    <p><asp:RadioButtonList ID="hour7" runat="server">
            <asp:ListItem Value="0">>12小时；  </asp:ListItem>
            <asp:ListItem Value="1">12-14小时； </asp:ListItem>
            <asp:ListItem Value="2">>14-16小时；  </asp:ListItem>
            <asp:ListItem Value="3">>16小时 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>10、您觉得之家医院最需改善病人安全到议题是什么？ (填空题 *必答)</p>
    <p>
        <asp:TextBox ID="safe" runat="server"  Height="46px" TextMode="MultiLine" 
            Width="321px"></asp:TextBox></p>
        <h4>第三部分:您的背景资料</h4>
        <p>请依您的实际状况，针对以下问题择一作答。</p>
    <p>1. 性别：</p>
    <p><asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">男 </asp:ListItem>
            <asp:ListItem Value="1">女 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>2. 年龄：</p>
    <p><asp:RadioButtonList ID="ages" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1. 20 岁以下</asp:ListItem>
            <asp:ListItem Value="2">2. 21 至30 岁</asp:ListItem>
            <asp:ListItem Value="3">3. 31 至40 岁 </asp:ListItem>
            <asp:ListItem Value="4">4. 41 至50 岁</asp:ListItem>
            <asp:ListItem Value="5">5. 51 至60 岁 </asp:ListItem>
            <asp:ListItem Value="6">6. 61 岁以上</asp:ListItem>
        </asp:RadioButtonList></p>
    <p>3.是否担任主任/副主任/护士长：</p>
    <p><asp:RadioButtonList ID="leader" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">是 </asp:ListItem>
            <asp:ListItem Value="1">否 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>4.在过去12 个月，您填写并提交多少件事件通报单：</p>
    <p><asp:RadioButtonList ID="dan" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.无</asp:ListItem>
            <asp:ListItem Value="2">2. 1-5 件</asp:ListItem>
            <asp:ListItem Value="3">3. 6-10 件 </asp:ListItem>
            <asp:ListItem Value="4">4. 11-15 件 </asp:ListItem>
            <asp:ListItem Value="5">5. 16 件以上 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>5. 职务类别：</p>
    <p><asp:RadioButtonList ID="type" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.医师</asp:ListItem>
            <asp:ListItem Value="2">2.护理人员</asp:ListItem>
            <asp:ListItem Value="3">3.医技人员 </asp:ListItem>
            <asp:ListItem Value="4">4.药剂人员 </asp:ListItem>
            <asp:ListItem Value="5">5.行政人员 </asp:ListItem>
            <asp:ListItem Value="5">6.康复治疗师 </asp:ListItem>
            <asp:ListItem Value="5">7.其他 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>6. 受雇类别：</p>
    <p><asp:RadioButtonList ID="employee" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.正式</asp:ListItem>
            <asp:ListItem Value="2">2.合同</asp:ListItem>
            <asp:ListItem Value="3">3.兼职 </asp:ListItem>
            <asp:ListItem Value="4">4.按时计酬 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>7. 本院工作年限：</p>
    <p><asp:RadioButtonList ID="workages" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1. 6 个月以内</asp:ListItem>
            <asp:ListItem Value="2">2. 6 至11 个月</asp:ListItem>
            <asp:ListItem Value="3">3. 1 至2 年 </asp:ListItem>
            <asp:ListItem Value="4">4. 3 至4 年 </asp:ListItem>
            <asp:ListItem Value="5">5. 5 至10 年 </asp:ListItem>
            <asp:ListItem Value="5">6. 11 至20 年 </asp:ListItem>
            <asp:ListItem Value="5">7. 21 年以上</asp:ListItem>
        </asp:RadioButtonList></p>
    <p>8. 本科室工作年限：</p>
    <p><asp:RadioButtonList ID="workagesSelf" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1. 6 个月以内</asp:ListItem>
            <asp:ListItem Value="2">2. 6 至11 个月</asp:ListItem>
            <asp:ListItem Value="3">3. 1 至2 年 </asp:ListItem>
            <asp:ListItem Value="4">4. 3 至4 年 </asp:ListItem>
            <asp:ListItem Value="5">5. 5 至10 年 </asp:ListItem>
            <asp:ListItem Value="5">6. 11 至20 年 </asp:ListItem>
            <asp:ListItem Value="5">7. 21 年以上</asp:ListItem>
        </asp:RadioButtonList></p>
    <p>9.教育程度：</p>
    <p><asp:RadioButtonList ID="education" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.初中及以下</asp:ListItem>
            <asp:ListItem Value="2">2.高中/职</asp:ListItem>
            <asp:ListItem Value="3">3.专科/大学  </asp:ListItem>
            <asp:ListItem Value="4">4.研究生及以上 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>10.是否直接接触病人：</p>
    <p><asp:RadioButtonList ID="patient" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.没有</asp:ListItem>
            <asp:ListItem Value="2">2.偶尔 </asp:ListItem>
            <asp:ListItem Value="3">3.经常  </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>11. 整体而言您觉得填答这份问卷：</p>
    <p><asp:RadioButtonList ID="hard" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem Value="1">1.非常容易</asp:ListItem>
            <asp:ListItem Value="2">2.容易</asp:ListItem>
            <asp:ListItem Value="3">3.难易适中  </asp:ListItem>
            <asp:ListItem Value="4">4.困难 </asp:ListItem>
            <asp:ListItem Value="5">5.非常困难 </asp:ListItem>
        </asp:RadioButtonList></p>
    <p>12. 为了提升病人安全，请就您的工作场所提出最需要改进的建议：</p>
    <p>
        <asp:TextBox ID="advise" runat="server" Height="46px" TextMode="MultiLine" 
            Width="321px"></asp:TextBox>
    </p>
        <asp:Button ID="Button1" runat="server" Text="点击提交" Height="48px" 
            Width="173px" onclick="Button1_Click" OnClientClick="return confirm('确认提交吗？');" />
         &nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" Text="重置" Height="48px" 
            Width="173px" onclick="Button2_Click" Visible="False" />
    <h2>问卷结束，请确认所有题目都回答完毕，感谢您百忙之中对我们工作的支持，谢谢！</h2>
    </div>
    </form>
    
</body>
</html>
