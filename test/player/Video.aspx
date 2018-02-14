<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="test_player_Video" %>

<!doctype html>
<html>
<head>
<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no,minimal-ui" />
<meta name="format-detection" content="telephone=no"/>
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta charset="utf-8">
<title>酷播V4.05跨平台,微信播放器,酷播免费播放器,html5播放器,h5播放器</title>
<meta name="keywords" content="cuplayer,酷播v4,酷播V4.05跨平台,酷播免费播放器,html5播放器,h5播放器,微信播放器">
<meta name="description" content="酷播跨平台点播范例（支持PC和手机/微信等）,微信播放器">
    <script src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<link rel="stylesheet" type="text/css" href="css/common.css"/>
</head>
<body> 
 
<!-- 酷播V4.05跨平台代码/开始 -->
<div class="video" id="CuPlayer">
<script type="text/javascript">
<!--
var vID        = "c1";                   //vID
var vWidth     = "600";                  //宽度设定，配合CSS实现
var vHeight    = "400";                  //高度设定，配合CSS实现
var vFile      = "CuSunV4set.xml";       //配置文件地址:支持五种广告设定
var vPlayer    = "player.swf?v=4.0";     //播放器文件地址
var vPic       = "pic/pic01.jpg";        //视频缩略图
var vCssurl    = "css/videos.min.css";   //CSS文件
var vAutoPlay  = "yes";                  //是否自动播放
var vEndTime   = 0;                      //预览时间(秒数),默认为0
var vLogoPath  = "images/logo.png";      //Logo地址
var vPlayMod   = 0;                      //播放模式优先级,默认=0,html5优先=1,flash优先=2
var vMp4url = "../../upload/movie/2.mp4";//视频文件地址推荐用mp4文件(h264编码)

//视频结束动作
function getNext(pars){
	alert("亲，视频播放结束，将播放下一个视频")
	if( pars == true){
		location.href="demoX4.html";
		}else{
			location.href="demoX4.html";
		}
}
//获取视频状态
function getState(pars) {
    var state = pars;
    document.getElementById("state").innerHTML = "输出当前状态信息：" + state + " ";
}
//获取当前视频时间
function getTimes(pars) {
    var times = pars;
    document.getElementById("time").innerHTML = "输出当前播放时间：" + times + " ";
}
//获取视频总时长
function getTotalTime(pars) {
    var totalTime = pars;
    if (totalTime != null) {
        document.getElementById("totaltime").innerHTML = "输出视频总时长：" + totalTime + " ";
    }
}

var timeIndex = 0;
var url = "";
$(document).ready(function () {
    var regex = /dateTime=(\d+)/;
    var src = location.toString();
    if (src.match(regex)) {
        timeIndex = src.match(regex)[1];
    }
    url = $("#linkTime").attr("href");
    setTime();
    setInterval(setTime, 1000);
});
function setTime() {
    var hour = parseInt(timeIndex / 3600);
    var minutes = parseInt((timeIndex % 3600) / 60);
    var seconds = parseInt(timeIndex % 60);
    hour = hour < 10 ? "0" + hour : hour;
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;
    $("#divTime").text(hour + ":" + minutes + ":" + seconds);
    timeIndex++;
    $("#linkTime").attr("href", url + timeIndex);
}
//-->
</script>
    <div id="divTime"></div>
<a id="linkTime" href="index.html?dateTime=">刷新</a>
    <h1 id="state"></h1>
    <h1 id="time"></h1>
    <h1 id="totaltime"></h1>

<script class="CuPlayerVideo" data-mce-role="CuPlayerVideo" type="text/javascript" src="js/player.min.js"></script>
</div>
<!-- 酷播V4.05跨平台代码/结束 -->




</body>
</html>

