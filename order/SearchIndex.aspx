<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchIndex.aspx.cs" Inherits="order_SearchIndex" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
			<meta name="google-site-verification" content="unVaqXQVedYf_e1nCic6sLqi8t64WibcEVwxAS8Z-QI">
		<title>药品说明书 </title>
    <link href="style/jquery.ui.all.css" rel="stylesheet" type="text/css" />

    <link href="style/webapp.css" rel="stylesheet" type="text/css" />

<style>
.alert {
    background:#EEF6FE none repeat scroll 0%;
    color:red;
    margin:0pt 2px;
    padding:2px 4px;
}

</style>					
</head>
<body  style=" background-color:#3D6399;">





            <div id="page">
                <div id="header">
                    <div class="logo">
                        <a href="http://drugs.dxy.cn/index.htm">丁香园</a>
                    </div>
                    <div class="search_wrap">
                        <div class="search_tab" id="J_SearchTab">
                            <a id="searcher_1" style=" font-size:xx-large; text-decoration:none; " class="cur" placeholder="如：阿司匹林或ASPL" action="#"
                                href="#">药品查询</a>
                        </div>
                        <div class="search_bd clearfix">
                            <form id="form1" runat="server">
                            <asp:TextBox ID="TextBox1" runat="server" class="kewword fl ui-autocomplete-input" placeholder="如：阿司匹林">
                            </asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="搜 索" class="search_btn fl" 
                                onclick="Button1_Click" />
                            <%--<input type="text" value="" id="keyword" name="keyword" autocomplete="off" class="kewword fl ui-autocomplete-input"
                                placeholder="如：阿司匹林" role="textbox" aria-autocomplete="list" aria-haspopup="true">
                            <input type="submit" value="搜 索" class="search_btn fl">--%>
                            </form>
                        </div>
                    </div>
                </div>


            </div>


<ul class="ui-autocomplete ui-menu ui-widget ui-widget-content ui-corner-all" role="listbox" aria-activedescendant="ui-active-menuitem" style="z-index: 1; top: 0px; left: 0px; display: none;"></ul><div class="ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable" tabindex="-1" role="dialog" aria-labelledby="ui-dialog-title-dialog-adv-search" style="display: none; z-index: 1000; outline: 0px;"><div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"><span class="ui-dialog-title" id="ui-dialog-title-dialog-adv-search">高级搜索</span><a href="http://drugs.dxy.cn/#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="ui-icon ui-icon-closethick">close</span></a></div><div id="dialog-adv-search" class="ui-dialog-content ui-widget-content">

</div><div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix"><div class="ui-dialog-buttonset"><button type="button">搜 索</button></div></div></div>
</body>
</html>
