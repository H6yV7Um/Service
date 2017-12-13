<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchDetail.aspx.cs" Inherits="order_SearchDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="google-site-verification" content="unVaqXQVedYf_e1nCic6sLqi8t64WibcEVwxAS8Z-QI">
    <title>药品说明书 </title>
    <link href="style/webapp.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .alert { background: #EEF6FE none repeat scroll 0%; color: red; margin: 0pt 2px; padding: 2px 4px; }
        .style { font-size: 14px; }
        .h4{margin-left:15px;}
    </style>
</head>
<body  style=" background-color:#3D6399;">
<form id="form1" runat="server">
    <div id="page">
        <div id="header">
            <div class="logo">
                <a href="#"></a>
            </div>
            <div class="search_wrap">
                <div class="search_tab" id="J_SearchTab">
                    <a id="searcher_1" style="font-size: xx-large; text-decoration: none;" class="cur">药品查询</a>
                </div>
                <div class="search_bd clearfix">
                    <div class="form">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:TextBox ID="TextBox1" runat="server" class="kewword fl ui-autocomplete-input"
                        placeholder="如：阿司匹林"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="搜 索" class="search_btn fl" OnClick="Button1_Click" />
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1"
                        MinimumPrefixLength="1" ServiceMethod="GetCompleteDepart" ServicePath="~/WebService.asmx"
                        CompletionListCssClass="style">
                    </ajaxToolkit:AutoCompleteExtender>
                    </div>
                </div>
            </div>
        </div>
        <div id="container" runat="server">
            <div class="corner_top">
            </div>
            <div class="common_hd clearfix">
                <div class="fl">
                    <asp:Label ID="Label1" runat="server" Text="药品详情"></asp:Label>
                </div>
            </div>
            <div class="common_bd clearfix">
                <%--<div class="common_mainwrap fr">
                    <div class="common_main ml279">
                        <ul>
                        <li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li>
                        <li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li><li>fdfdf</li>
                    </ul>
                    </div>
                    </div>--%>
                <div class="common_mainwrap mr-243">
                    <div class="sidemenu">
                        <ul id="ul" runat="server">
                            <%--<h2>布洛芬混悬滴剂</h2>
                            <h4>适应症:</h4>
                            <p>用于婴幼儿的退热，缓解由于感冒流感等引起的轻度头痛、咽痛及牙痛等。用于婴幼儿的退热，缓解由于感冒流感等引起的轻度头痛、咽痛及牙痛等。</p>--%>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="corner_btm">
            </div>
        </div>
    </div>
</form>            

</body>
</html>