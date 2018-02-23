<%@ Page Language="C#" AutoEventWireup="true" CodeFile="video.aspx.cs" Inherits="test_video" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="ckplayer/ckplayer/ckplayer.js" charset="UTF-8"></script>
    <script type="text/javascript">
        $(function () {
           
        });
    </script>
		<style type="text/css">
			body {
				margin: 0;
				padding: 0px;
				font-family: "Microsoft YaHei", YaHei, "微软雅黑", SimHei, "黑体";
				font-size: 14px
			}
		</style>
</head>
<body>
    <form id="form1" runat="server">
        <p style="display:none;">
        <input id="Text1" type="text" value="<%=movieID%>" />
        <input id="Text2" type="text" value="<%=username%>" />
            </p>
        <%--movieID: <%=movieID%>,
			            username:<%=username%>,
			            state:0,
                        record_time:<%=add_time%>,--%>
    <div id="video" style="width: 600px; height: 400px; ">

    </div>
        <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
		<script type="text/javascript">
			var videoObject = {
				//playerID:'ckplayer01',//播放器ID，第一个字符不能是数字，用来在使用多个播放器时监听到的函数将在所有参数最后添加一个参数用来获取播放器的内容
				container: '#video', //容器的ID或className
				variable: 'player', //播放函数名称
				loaded: 'loadedHandler', //当播放器加载后执行的函数
				//loop: true, //播放结束是否循环播放
				//autoplay: true, //是否自动播放
				//duration: 500, //设置视频总时间
				cktrack: 'ckplayer/material/srt.srt', //字幕文件
				//poster: 'ckplayer/material/poster.jpg', //封面图片
				//preview: { //预览图片
				//    file: ['ckplayer/material/mydream_en1800_1010_01.png', 'ckplayer/material/mydream_en1800_1010_02.png'],
				//	scale: 2
				//},
				config: '', //指定配置函数
				debug: false, //是否开启调试模式
				//flashplayer: true, //强制使用flashplayer
				drag: 'start', //拖动的属性
				seek: 0, //默认跳转的时间
				playbackrate:-1,//默认速度的编号，只对html5有效,设置成-1则不显示倍速
				//advertisements:'website:ad.json',
				//front:'frontFun',//上一集的操作函数
			    //next:'nextFun',//下一集的操作函数
			    
				
				video: [
			        ['<%=url%>', 'video/mp4', '中文标清', 0]
			        //['../upload/movie/VID_20180203_193014.mp4', 'video/mp4', '中文高清', 0]
			        //['http://img.ksbbs.com/asset/Mon_1703/eb048d7839442d0.mp4', 'video/mp4', '英文高清', 10],
			        //['http://img.ksbbs.com/asset/Mon_1703/d30e02a5626c066.mp4', 'video/mp4', '英文超清', 0]
				]
                 
			};
			var player = new ckplayer(videoObject);
			
			function loadedHandler() {
				player.addListener('error', errorHandler); //监听视频加载出错
				player.addListener('loadedmetadata', loadedMetaDataHandler); //监听元数据
				player.addListener('duration', durationHandler); //监听播放时间
				player.addListener('time', timeHandler); //监听播放时间
				player.addListener('play', playHandler); //监听暂停播放
				player.addListener('pause', pauseHandler); //监听暂停播放
				player.addListener('buffer', bufferHandler); //监听缓冲状态
				player.addListener('seek', seekHandler); //监听跳转播放完成
				player.addListener('seekTime', seekTimeHandler); //监听跳转播放完成
				player.addListener('volume', volumeChangeHandler); //监听音量改变
				player.addListener('full', fullHandler); //监听全屏/非全屏切换
				player.addListener('ended', endedHandler); //监听播放结束
				player.addListener('screenshot', screenshotHandler); //监听截图功能
				player.addListener('mouse', mouseHandler); //监听鼠标坐标
				player.addListener('frontAd', frontAdHandler); //监听前置广告的动作
				player.addListener('wheel', wheelHandler); //监听视频放大缩小
				player.addListener('controlBar', controlBarHandler); //监听控制栏显示隐藏事件
				player.addListener('clickEvent', clickEventHandler); //监听点击事件
				player.addListener('definitionChange', definitionChangeHandler); //监听清晰度切换事件
				player.addListener('speed', speedHandler); //监听加载速度
			}
			function errorHandler() {
				console.log('出错')
				changeText('.playerstate', '状态：视频加载错误，停止执行其它动作，等待其它操作');
			}

			function loadedMetaDataHandler() {
                 
				var metaData = player.getMetaDate();
				//console.log(metaData)
				var html = ''
				//console.log(metaData);
				if(parseInt(metaData['videoWidth']) > 0) {
					changeText('.playerstate', '状态：获取到元数据信息，如果数据错误，可以使用延迟获取');
					html += '总时间：' + metaData['duration'] + '秒，';
					html += '音量：' + metaData['volume'] + '（范围0-1），';
					html += '播放器的宽度：' + metaData['width'] + 'px，';
					html += '播放器的高度：' + metaData['height'] + 'px，';
					html += '视频宽度：' + metaData['videoWidth'] + 'px，';
					html += '视频高度：' + metaData['videoHeight'] + 'px，';
					html += '视频原始宽度：' + metaData['streamWidth'] + 'px，';
					html += '视频原始高度：' + metaData['streamHeight'] + 'px，';
					html += '是否暂停状态：' + metaData['paused'];
				} else {
					changeText('.playerstate', '状态：未正确获取到元数据信息');
					html = '没有获取到元数据';
				}
				changeText('.metadata', html);
			}
			function playHandler() {
				//player.animateResume();//继续播放所有弹幕
				changeText('.playstate', getHtml('.playstate') + ' 播放');
				window.setTimeout(function() {
					loadedMetaDataHandler();
				}, 1000);
				loadedMetaDataHandler();
			}

			function pauseHandler() {
				//player.animatePause();//暂停所有弹幕
			    changeText('.playstate', getHtml('.playstate') + ' 暂停');
			    //alert("暂停");
			    <%-- <%pauseHandler(username,movieID,add_time,0);%>--%>
			    //$.ajax({
			    //    url:'../tools/Handler.ashx?action=checkNumber',
			    //    type:'post',
			    //    data:{
			    //        number:$('#name').val(),
			    //    },
			    //    success:function(data,response,status){
			    //        if(data!=0){
			    //            $('#name').val(data);
			    //        }else{
			    //            $('#name').focus();
			    //            alert('医院无此人，请填写职工姓名或工号！');
			    //            $('#name').val("");
			    //            //$('#name').val('医院无此人，请填写职工工号！');           
			    //        }
			    //    },
			    //});
			    $.ajax({
			        url: '../tools/Handler.ashx?action=record',
			        type: 'post',
			        data: {
			            <%--movieID: <%=movieID%>,
			            username:<%=username%>,
			            state:0,
                        record_time:<%=add_time%>,--%>
			            movieID: $('#Text1').val(),
			            username: $("#Text2").val(),
			            currenttimestate: $(".currenttimestate").text(),
			            state:0,
			        },
			        success: function (data, response, status) {
			            if (data != 0) {
			                //alert("成功");
			            } else {
         
			            }
			        }
			    });

				loadedMetaDataHandler();
			}
			

			function timeHandler(time) {
				changeText('.currenttimestate', time);
			}

			function durationHandler(duration) {
				changeText('.duration', '总时间（秒）：' + duration);
			}

			function seekHandler(state) {
				changeText('.seekstate', getHtml('.seekstate') + ' ' + state);
			}

			function seekTimeHandler(time) {
				changeText('.seekstate', getHtml('.seekstate') + ' seekTime:' + time);
			}

			function bufferHandler(buffer) {
				//console.log(buffer);
				changeText('.bufferstate', '缓冲：' + buffer);
			}

			function volumeChangeHandler(vol) {
				changeText('.volumechangestate', '当前音量：' + vol);
			}
			function speedHandler(n) {
				changeText('.speed', '当前加载速率：' + n);
			}
			function screenshotHandler(obj) {
				changeText('.screenshot', '图片名称：' + obj['name'] + ',截图对象：' + obj['object'] + ',是否用户保存：' + obj['save'] + ',图片：<img src="' + obj['base64'] + '">');
			}

			function fullHandler(b) {
				if(b) {
					html = ' 全屏';
				} else {
					html = ' 否';
				}
				changeText('.fullstate', getHtml('.fullstate') + html);
				
			}

			function endedHandler() {
			    changeText('.endedstate', '播放结束');
			    alert("播放结束了，单击“确定”请开始答题！");
			    
                $.ajax({
			        url: '../tools/Handler.ashx?action=record',
			        type: 'post',
			        data: {
			            <%--movieID: <%=movieID%>,
			            username:<%=username%>,
			            state:0,
                        record_time:<%=add_time%>,--%>
			            movieID: $('#Text1').val(),
			            username: $("#Text2").val(),
			            currenttimestate: $(".currenttimestate").text(),
			            state:1,
			        },
			        success: function (data, response, status) {
			            if (data != 0) {
			                //alert("成功");
			            } else {
         
			            }
			        }
                });
			    window.location.href = 'VideoExam.aspx';
			}

			function mouseHandler(obj) {
				changeText('.mouse', '鼠标位置，x：' + obj['x'] + '，y：' + obj['y']);
			}

			function frontAdHandler(status) {
				changeText('.frontad', getHtml('.frontad') + ' ' + status);
			}
			var zoomNow = 1;

			function wheelHandler(n) {
				if(n > 0) {
					if(zoomNow < 5) {
						zoomNow += 0.1;
					}
				} else {
					if(zoomNow > 0) {
						zoomNow -= 0.1;
					}
				}
				player.videoZoom(zoomNow);//支持鼠标滚轮控制放大缩小
			}
			function controlBarHandler(show){
				if(show) {
					html = ' 显示';
				} else {
					html = ' 隐藏';
				}
				changeText('.controlBar', getHtml('.controlBar') + html);
			}
			function clickEventHandler(eve){
				changeText('.clickEvent', getHtml('.clickEvent') + ' '+eve);
			}
			function definitionChangeHandler(num){
				changeText('.definitionChange', getHtml('.definitionChange') + ',切换清晰度编号'+num);
			}
			var videoChangeNum = 0;

			function seekTime() {
				var time = parseInt(player.getByElement('.seektime').value);
				var metaData = player.getMetaDate();
				var duration = metaData['duration'];
				if(time < 0) {
					alert('请填写大于0的数字');
					return;
				}
				if(time > duration) {
					alert('请填写小于' + duration + '的数字');
					return;
				}
				player.videoSeek(time);
			}



			function changeSize() {
				player.changeSize(w, h)
			}


			function newVideo() {
				var videoUrl = player.getByElement('.videourl').value;
				changeVideo(videoUrl);
			}

			function newVideo2() {
				var videoUrl = player.getByElement('.videourl2').value;
				changeVideo(videoUrl);
			}

			function changeVideo(videoUrl) {
				if(player == null) {
					return;
				}

				var newVideoObject = {
					container: '#video', //容器的ID
					variable: 'player',
					autoplay: true, //是否自动播放
					loaded: 'loadedHandler', //当播放器加载后执行的函数
					video: videoUrl
				}
				//判断是需要重新加载播放器还是直接换新地址

				if(player.playerType == 'html5video') {
					if(player.getFileExt(videoUrl) == '.flv' || player.getFileExt(videoUrl) == '.m3u8' || player.getFileExt(videoUrl) == '.f4v' || videoUrl.substr(0, 4) == 'rtmp') {
						player.removeChild();

						player = null;
						player = new ckplayer();
						player.embed(newVideoObject);
					} else {
						player.newVideo(newVideoObject);
					}
				} else {
					if(player.getFileExt(videoUrl) == '.mp4' || player.getFileExt(videoUrl) == '.webm' || player.getFileExt(videoUrl) == '.ogg') {
						player = null;
						player = new ckplayer();
						player.embed(newVideoObject);
					} else {
						player.newVideo(newVideoObject);
					}
				}
			}
			var elementTemp = null; //保存元件

			function deleteElement() {
				if(elementTemp != null) {
					player.deleteElement(elementTemp);
					elementTemp = null;
				} else {
					alert('演示删除元件需要先添加');
				}
			}


			function deleteChild(ele) {
				if(player) {
					player.deleteElement(ele);
				}
			}

			function changeText(div, text) {
				player.getByElement(div).innerHTML = text;
			}

			function getHtml(div) {
				return player.getByElement(div).innerHTML;
			}
			var zoom = 1;
		</script>
		
		<p>
			<button id="btn_normal" runat="server" type="button" onclick="player.changeConfig('config','timeScheduleAdjust',1)">正常拖动</button>
			<%--<button type="button" onclick="player.changeConfig('config','timeScheduleAdjust',0)">不能拖动</button>
			<button type="button" onclick="player.changeConfig('config','timeScheduleAdjust',2)">只能前进（向右拖动）</button>
			<button type="button" onclick="player.changeConfig('config','timeScheduleAdjust',3)">只能后退</button>
			<button type="button" onclick="player.changeConfig('config','timeScheduleAdjust',4)">能回到第一次拖动时的位置</button>
			<button type="button" onclick="player.changeConfig('config','timeScheduleAdjust',5)">看过的地方可以随意拖动</button>--%>
		</p>
		
		<p class="handler" style="display:none;">
			<span class="duration"></span><br />
			<span class="playstate">播放状态：</span><br />
			<span class="seekstate">跳转状态:无</span><br />
			<span class="bufferstate">缓冲:100</span><br />
			<span class="speed">加载速率：0</span><br />
			<span class="volumechangestate">当前音量：0.8</span><br />
			<span class="fullstate">是否全屏：否</span><br />
			<span class="controlBar">控制栏：显示</span><br />
			<span class="endedstate">还未结束</span><br />
			<span class="currenttimestate">当前播放时间（秒）：0</span><br />
			<span class="frontad">前置广告状态：</span><br />
			<span class="mouse">鼠标位置</span><br />
			<span class="definitionChange">切换清晰度：</span><br />
			<span class="clickEvent">点击监听：</span><br />
			<span class="screenshot">监听截图功能（截图功能需要视频权限）</span>
          
		</p>
       <%-- <a href="../upload/movie/1.mp4">观看1</a>
        <a href="../upload/movie/11.mp4">观看11</a>
        <a href="../upload/movie/2.mp4">观看2</a>
        <a href="../upload/movie/3.mp4">观看3</a>--%>
    </form>
</body>
</html>
