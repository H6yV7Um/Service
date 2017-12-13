// vim: set et sw=4 ts=4 sts=4 fdm=marker ff=unix fenc=utf8 nobomb:
/**
 * @date  2011-05-31
 */

jQuery(function($) {
    if (typeof console == "undefined") {
        window.console = {
            info: function() {

            },

            error: function() {

            }
        };
    }

    /**
     * 输入框自动补全
     */
    $("#keyword").autocomplete({
        delay: 300, // 延时 500 毫秒，防止过多请求
        selectFirst: false,
        scroll: false,
        source: function( request, response ) {
            if (request.term.length < 2 || $("#searcher_2").attr('class') == "cur" || $("#searcher_3").attr('class') == "cur" || $("#searcher_6").attr('class') == "cur") {
                return false;
            }
            if($("#searcher_5").attr('class') == "cur") {
                jQuery.getJSON(homeurl+'/autocomplete/data.htm', {
                    limit: 10,
                    type: 2,
                    q: request.term,
                    t: +new Date()
                }, response);
            } else {
                jQuery.getJSON(homeurl+'/autocomplete/data.htm', {
                    limit: 10,
                    type: 0,
                    q: request.term,
                    t: +new Date()
                }, response);
            }
        },
        select: function(event, ui) {
            // 搜索药品时，点击直接进入药品页面
            if ($('#searcher_1').hasClass('cur')) {
                event.preventDefault();
                location.href = 'http://drugs.dxy.cn/drug/' + ui.item.id + '.htm';
            }
        }
    });

    // 锚点动画滚动
    $("#goto-top a").click(function(e) {
        var target = $(this).attr('href'), scrollTop = parseInt($(target).offset().top, 10);
        if (target.match(/^#.+/)) {
            $("html, body").animate({scrollTop:scrollTop}, 500, function() {
                // 动画完成后，改变锚点地址
                location.hash = target;
            });
            return false;
        }
    });

    // 动态调整向上滚动按钮
    var adjustGotoTopEl = function() {
        var goTopEl = $("#goto-top"),
            offsetLeft = $("#page").offset().left + $("#page").width();

        var scrollTop = $(window).scrollTop(), clientHeight = $(window).height();

        goTopEl[(scrollTop < clientHeight/2) ? "hide" : "show"]();
        goTopEl.css('left', offsetLeft);

        if (jQuery.browser.msie < 7) {
            goTopEl.css('position', 'absolute');
            goTopEl.css('top', scrollTop + clientHeight/2);
        }
    };

    $(window).bind('scroll', adjustGotoTopEl);
    $(window).bind('resize', adjustGotoTopEl);

    /*
     *  处理skin
     */

    //获取url参数
    var msn_domain = "drug.health.msn.com.cn";
    var getUrlArgs = function (){
        var args = new Object();
        var query = window.location.search.substring(1);
        var pairs = query.split("&");
        for(var i = 0; i < pairs.length; i++) {
            var pos = pairs[i].indexOf('=');
            if (pos == -1) continue;
            var argname = pairs[i].substring(0,pos);
            var value = pairs[i].substring(pos+1);
            value = decodeURIComponent(value);
            args[argname] = value;
        }
        return args; // 返回此对象
    };

    var urlArgs = getUrlArgs(); //获取当前url的参数值
    if (location.hostname == msn_domain) {
        urlArgs.skin = "msn";
    }

    if(urlArgs.skin) {
        var format_msn_location = function(href) {
            href = href.replace("drugs.dxy.cn", msn_domain);
            href = href.replace("skin=msn", "");

            if (href.match(/\?$/i)) {
                href = href.replace(/(\?)$/, "");
            }

            if (href.match(/\&$/i)) {
                href = href.replace(/(\&)$/, "");
            }

            return href;
        };

        // auto jump to msn page
        /*
        if (urlArgs.skin == "msn" && location.hostname != msn_domain) {
            location.replace(format_msn_location(location.href));
        }
        */

        $("#page,#footer").delegate('a', 'click', function() {
            var target = $(this);
            href = target.attr('href');

            // 判断是否是 http 连接
            if(href.match(/^http/i)) {
                if(href.search("\\?") >= 0){
                    target.attr('href', href + "&skin=" + urlArgs.skin);
                } else if( href != "#" && href != '' ){
                    target.attr('href', href + "?skin=" + urlArgs.skin);
                }
            } else {
                return true;
            }

            if (urlArgs.skin == "msn") {
                var href = target.attr('href');
                target.attr("href", format_msn_location(href));
            }
        });

        //添加form隐藏参数
        $("#topSearchForm").append('<input type="hidden" name="skin" value="' + urlArgs.skin + '">');
    }

    // 判断是否存在 cookie
    jQuery.getScript("http://assets.dxycdn.com/core/jquery/cookie/cookie.js", function() {
        if(urlArgs.skin && location.host.match(".msn.com.cn")) {
            jQuery.cookie("skin", urlArgs.skin, { path: '/', expires: 1 });
        }

        var skin = jQuery.cookie("skin");
        if (typeof skin != "undefined" && skin != null &&  skin.length && !urlArgs.skin) {
            var href = location.href;
            if (href.search("\\?") >= 0){
                href = href + "&skin=" + skin;
            } else {
                href = href + "?skin=" + skin;
            }

            location.replace(href);
        }
    });

    //处理表单提交
    function advanceFormSubmit(){
        if(urlArgs.skin){
            var target = $("form[name='all']"),
                action = target.attr("action");
            target.attr("action", action + "?skin=" + urlArgs.skin);
            target.submit();

        }else{
            $("form[name='all']").submit();
        }
    }

    // 高级搜索的弹出框
    $("#dialog-adv-search").dialog({
        autoOpen: false,
        modal: true,
        width: 430,
        resizable: false,
            buttons: {
                "搜 索": function() {
                    if($("#keyword_all").val() == "请输入搜索内容"){
                        $("#keyword_all").val("");
                    }

                    if($("#keyword_all").val().length == 0){
                        alert("请输入关键词");
                    } else {
                        var flag = 0;
                        $("input[name='fields']").each(function(i){
                            if(this.checked == true)
                                flag++;
                        });
                        if(flag == 0) {
                            alert("请选择搜索项");
                        } else {
                            advanceFormSubmit();
                            $(this).dialog("close");
                        }
                    }
                }
            }
        }
    );

    $("#open-advance").click(function(e){
        $("#dialog-adv-search").dialog("open");
        $("input[name='keyword']").select();
        return false;
    });

    $("#dialog-login").dialog({
        autoOpen: false,
        modal: true,
        width: 300,
        height: 100,
        resizable: false
    });


    /**
     * 评分控件
     */
    ~function() {
        if ( typeof DrugUtils == 'undefined' || !DrugUtils || !DrugUtils.getGrade || !DrugUtils.setGrade ) {
            return false;
        }

        var dialogLoginEl = $("#dialog-login"),
            drugStarRateResultEl = $("#drug-starrate-result"),
            drugStarRateEl = $(".star-rate-form input[type=radio].star");

        function setUIGrade(value) {
            switch(value[0]) {
                case 'login':
                    return dialogLoginEl.dialog("open");
                case 'exist':
                    return alert("您已经为该药品评过分了！");
                case 'identify':
                    return dialogLoginEl.dialog("open");
            }


            if (drugStarRateResultEl.length > 0) {
                if (value[1] == 0) {
                    drugStarRateResultEl.html("<font color='gray'>目前尚无评分</font>");
                } else {
                    drugStarRateResultEl.html("<font color='#8B0000'> " + value[0]
                        + "</font>分 (已有<font color='#8B0000'>" + value[1] + "</font>个医生评分)");
                }
            }


            if (Math.floor(value[0])) {
                drugStarRateEl.rating('select', Math.floor(value[0]) - 1, false);
                drugStarRateEl.rating('readOnly', true);
                return true;
            }
        }

        // 初始化控件
        drugStarRateEl.rating({
            callback: function(value, link){
                DrugUtils.setGrade(curr_drugId, value, function(value) {
                    setUIGrade(value);
                    if (value[0] == 'exist') {
                        drugStarRateEl.rating('readOnly', true);
                    }
                });
            },
            focus: function(value, link){

            },
            blur: function(value, link){

            }
        });

        // 获取得分
        DrugUtils.getGrade(curr_drugId, function(value) {
            setUIGrade(value);
            if (value[2] == 'exist') { // || value[2] == 'identify') {
                drugStarRateEl.rating('readOnly', true);
            }
        });
    }();



    /**
     * 分类显示更多
     */

    $(".sidemenu a.more, .sidebar a.more").click(function(e) {
        if ($(this).attr('href').match(/^http:\/\//)) {
            return true;
        }

        var hideClass = 'hide-more',
            box = $(this).parent(".sidemenu, .sidebar")
                    .find("ul."+hideClass);

        if (box.hasClass(hideClass)) {
            box.removeClass(hideClass);
            $(this).hide();
        } else {
            // ...
        }

        return false;
    });


    /**
     * 搜索框提示语
     */
    $('#J_SearchTab a').click(function(e) {
        var target = $(this), currentClass = "cur",
            placeholder = target.attr('placeholder'),
            action = target.attr('action');

        $('#J_SearchTab a').removeClass(currentClass);
        target.addClass(currentClass);
        if (placeholder) {
            $("#keyword").attr('placeholder', placeholder);
            if (jQuery.browser.msie) {
                $("#keyword").val(placeholder);
            }
        }

        // 更改其他表单属性
        if (action) {
            $('.search_wrap form').attr('action', action);
        }

        return false;
    });
    $('#J_SearchTab a.cur').click(); // 初始化到 Class 定义的条目

    // IE 不支持 placeholder 属性，
    if (jQuery.browser.msie) {
        $('input').focus(function(e) {
            var placeholder = $(this).attr('placeholder'), val = $(this).val();
            if (placeholder && (!val || val == placeholder)) {
                $(this).val("").removeClass('placeholder');
            }
        });

        $('input').blur(function(e) {
            var placeholder = $(this).attr('placeholder'), val = $(this).val();
            if (placeholder && !val) {
                $(this).val(placeholder).addClass('placeholder');
            }
        });

        $('input').each(function(i, s) {
            var placeholder = $(s).attr('placeholder');
            if (placeholder) {
                $(s).val(placeholder).addClass('placeholder');
            }
        });
    }

    // 分享按钮
    /*
    $("#share").bind('mouseenter', function(e) {
        $(this).find('.ShareThis').show();

    });

    $("#share").bind('mouseleave', function(e) {
        $(this).find('.ShareThis').hide();
    });
    */

/*
    // 相互作用的自动补全
    ~function() {
        var keywords = $("#interaction-keywords"), data = $("select[name=drugList] option"), source = [];
        var resultIdEl = $("input[name=interactionId]"), vsName2El = $("input[name=vsName2]"), vsForm2 = $("#interaction-form form");

        // 准备自动补全的数据
        $(data).each(function(i, s) {
            var id = $(s).val(), value = id, label = $(s).html();
            source.push({ id: id, value: value, label: label });
        });

        vsForm2.submit(function() {
            if (!resultIdEl.val() || !vsName2El.val()) {
                return false;
            }
        });

        keywords.autocomplete({
       selectFirst: true,
            scroll: false,
            select: function(e, ui) {
                var id = ui.item.id, vsName2 = ui.item.label;
                resultIdEl.val(id); vsName2El.val(vsName2);
                vsForm2.submit();
            },
            source: source
        });
    }(); */



    try {
    if (typeof window.external.wappGetProperty != "undefined") {
        var html = '<div class="i360 clearfix" id="i360">' +
        '<div class="fl"> <a href="javascript:history.go(-1);">返回</a>' +
        '<a href="http://drugs.dxy.cn/?skin=360">主页</a> </div> ' +
        ' <div class="visited-drugs-list"></div> <div class="fr conx"> ' +
        ' <a href="mailto:app@dxyer.com">联系我们</a> </div> <div class="mask"></div> </div>';

        var i360 = jQuery(html)
        if (jQuery.browser.msie < 7) {
            var adjustToolbar = function() {
                i360.css('top', $(window).scrollTop() + $(window).height() - i360.height() * 2 + 'px');
            }

            $(window).bind('scroll', adjustToolbar);
            $(window).bind('resize', adjustToolbar);
        }

        /*
        if (!$("#header .logo").hasClass("fl")) {
            $("#header").append('<div class="header1 clearfix"></div>');
            $("#header > .clearfix").append($("#header > .logo").addClass("fl"));
            $("#header > .clearfix").append($("#header > .search_wrap").addClass("fl"));
        }

        $('body > #sitenav').hide();
        $('body').css("background-position", "0 -33px");
        */

        $(document.body).append(i360);
    }
    } catch(e) {}


    // 判断是否被 360 桌面嵌入
    var is360 = (typeof window.external != "undefined"
                    && typeof window.external.wappFullScreen != "undefined")
                    || location.host.search('360.cn') != -1;

    if(!is360 && self != top) {
        //alert('请勿嵌套本页面');
        top.location = 'http://drugs.dxy.cn';
    }

    //省市，医院弹框

    if(jQuery.validator){
        jQuery.validator.addMethod("chineseCheck", function(value, element) {
            var chinese =  /^[\u4E00-\u9FA5]+$/;
            return this.optional(element) || chinese.test(value);
        }, "只能中文字");
        jQuery.validator.addMethod("isPhone",function(value,element) {
            var length = value.length;
            var mobile = /^(13|14|15|18)\d{9}$/;
            var tel = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
            return this.optional(element) || (tel.test(value) ||  (length == 11 && mobile.test(value)));
        }, "请正确填写您的联系电话");
    }

    jQuery(function($){
        //表单验证
        $("input[type='reset']").click(function(){
            $('span.error').remove();
        })

        //下拉列表
        $('#iSelct').autoSelect({
            container: "#aiSelct",
            selectVal: $('#selectval'),
            clearTime: 300
        });

        //检测清楚文字
        if($("#dept").val() !== ""){
            $("#cascading_btn").hide();
        }
        if($("#city_val").val() !== ""){
            $("#city_txt").hide();
        }
        $("#toEditSubmit").click(function(){
            $("#edit-submit").trigger('click');
            return false;
        })

        /*
         医院弹窗
         */
        var popShow = $("#popShow").school({
            time:0,
            modal:false,
            data:{
                type:"id",
                value:"popHospital"
            },
            title:"请选择医院",
            align:[],
            draggable:false,
            height:360,
            width:660,
            modal:true
        }).click(function(){
            popShow.display();
            $("#J_hospital .manul").hide();
            $("#J_hospital .hide").hide();
            $("#J_hospital .show").show();
            $("#J_hospital input.q").removeAttr("disabled");
            return false;
        })//.display();

        //设置默认值
        var Gname = '';
        HOSPITAL.callback = function(name,id){
            $("#J_hospital input.q").val(name).removeAttr("style");
            $("#J_hospital input[name='field_company[und][0][value]']").val(name);
            $("input[name='field_company_id[und][0][value]']").val(id);
            $("#J_hospital input[name='hospital_id']").val(id);
            $("#J_hospital .labeltips").hide();
            var opt = $('#popHospital').find('select.rootarea').find('option:selected');
            $('#j_province').val(opt.text());
            Gname = name;

        }

        HOSPITAL.jsonDataSource = "http://i.dxy.cn/pub/assets/hospital/location?callback=?";
        HOSPITAL.dialogClose = popShow.shut;
        HOSPITAL.setDefault(".J_pophospital",0);
        //HOSPITAL.getProvince($('#j_province'));
        $('body').bind('selfChange', function (e, data) {
            if(Gname != data.val)
                $('#j_province').val(data.name);
        })


    });

});
