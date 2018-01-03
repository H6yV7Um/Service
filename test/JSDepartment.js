$(function () {

    $('#cb1').click(function () {
        var $cb1isChecked = $("#cb1").is(":checked");
        if ($cb1isChecked) {
            $('#cb2').attr("disabled", true);
            $('#cb3').attr("disabled", true);
            $('#cb4').attr("disabled", true);
            $('#cb5').attr("disabled", true);
            $('#cb6').attr("disabled", true);
            //是否需要
            $('#cb2_ss').attr("disabled", true);
            $('#cb3_bk').attr("disabled", true);
            $('#cb4_dz').attr("disabled", true);
            $('#cb5_cg').attr("disabled", true);
            $('#cb6_wu').attr("disabled", true);

        } else {
            $('#cb2').attr("disabled", false);
            $('#cb3').attr("disabled", false);
            $('#cb4').attr("disabled", false);
            $('#cb5').attr("disabled", false);
            $('#cb6').attr("disabled", false);
            //是否需要
            $('#cb2_ss').attr("disabled", false);
            $('#cb3_bk').attr("disabled", false);
            $('#cb4_dz').attr("disabled", false);
            $('#cb5_cg').attr("disabled", false);
            $('#cb6_wu').attr("disabled", false);
        }
    });
    $('#cb2').click(function () {
        var $cb2isChecked = $("#cb2").is(":checked");
        if ($cb2isChecked) {
            $('#cb1').attr("disabled", true);
            $('#cb3').attr("disabled", true);
            $('#cb4').attr("disabled", true);
            $('#cb5').attr("disabled", true);
            $('#cb6').attr("disabled", true);
            //是否需要
            $('#cb1_bs').attr("disabled", true);
            $('#cb3_bk').attr("disabled", true);
            $('#cb4_dz').attr("disabled", true);
            $('#cb5_cg').attr("disabled", true);
            $('#cb6_wu').attr("disabled", true);

        } else {
            $('#cb1').attr("disabled", false);
            $('#cb3').attr("disabled", false);
            $('#cb4').attr("disabled", false);
            $('#cb5').attr("disabled", false);
            $('#cb6').attr("disabled", false);
            //是否需要
            $('#cb1_bs').attr("disabled", false);
            $('#cb3_bk').attr("disabled", false);
            $('#cb4_dz').attr("disabled", false);
            $('#cb5_cg').attr("disabled", false);
            $('#cb6_wu').attr("disabled", false);
        }
    });
    $('#cb3').click(function () {
        var $cb3isChecked = $("#cb3").is(":checked");
        if ($cb3isChecked) {
            $('#cb2').attr("disabled", true);
            $('#cb1').attr("disabled", true);
            $('#cb4').attr("disabled", true);
            $('#cb5').attr("disabled", true);
            $('#cb6').attr("disabled", true);
            //是否需要
            $('#cb2_ss').attr("disabled", true);
            $('#cb1_bs').attr("disabled", true);
            $('#cb4_dz').attr("disabled", true);
            $('#cb5_cg').attr("disabled", true);
            $('#cb6_wu').attr("disabled", true);

        } else {
            $('#cb2').attr("disabled", false);
            $('#cb1').attr("disabled", false);
            $('#cb4').attr("disabled", false);
            $('#cb5').attr("disabled", false);
            $('#cb6').attr("disabled", false);
            //是否需要
            $('#cb2_ss').attr("disabled", false);
            $('#cb1_bs').attr("disabled", false);
            $('#cb4_dz').attr("disabled", false);
            $('#cb5_cg').attr("disabled", false);
            $('#cb6_wu').attr("disabled", false);
        }
    });
    $('#cb4').click(function () {
        var $cb4isChecked = $("#cb4").is(":checked");
        if ($cb4isChecked) {
            $('#cb2').attr("disabled", true);
            $('#cb3').attr("disabled", true);
            $('#cb1').attr("disabled", true);
            $('#cb5').attr("disabled", true);
            $('#cb6').attr("disabled", true);
            //是否需要
            $('#cb2_ss').attr("disabled", true);
            $('#cb3_bk').attr("disabled", true);
            $('#cb1_bs').attr("disabled", true);
            $('#cb5_cg').attr("disabled", true);
            $('#cb6_wu').attr("disabled", true);

        } else {
            $('#cb2').attr("disabled", false);
            $('#cb3').attr("disabled", false);
            $('#cb1').attr("disabled", false);
            $('#cb5').attr("disabled", false);
            $('#cb6').attr("disabled", false);
            //是否需要
            $('#cb2_ss').attr("disabled", false);
            $('#cb3_bk').attr("disabled", false);
            $('#cb1_bs').attr("disabled", false);
            $('#cb5_cg').attr("disabled", false);
            $('#cb6_wu').attr("disabled", false);
        }
    });
    $('#cb5').click(function () {
        var $cb5isChecked = $("#cb5").is(":checked");
        if ($cb5isChecked) {
            $('#cb2').attr("disabled", true);
            $('#cb3').attr("disabled", true);
            $('#cb4').attr("disabled", true);
            $('#cb1').attr("disabled", true);
            $('#cb6').attr("disabled", true);
            //是否需要
            $('#cb2_ss').attr("disabled", true);
            $('#cb3_bk').attr("disabled", true);
            $('#cb4_dz').attr("disabled", true);
            $('#cb1_bs').attr("disabled", true);
            $('#cb6_wu').attr("disabled", true);

        } else {
            $('#cb2').attr("disabled", false);
            $('#cb3').attr("disabled", false);
            $('#cb4').attr("disabled", false);
            $('#cb1').attr("disabled", false);
            $('#cb6').attr("disabled", false);
            //是否需要
            $('#cb2_ss').attr("disabled", false);
            $('#cb3_bk').attr("disabled", false);
            $('#cb4_dz').attr("disabled", false);
            $('#cb1_bs').attr("disabled", false);
            $('#cb6_wu').attr("disabled", false);
        }
    });
    $('#cb6').click(function () {
        var $cb6isChecked = $("#cb6").is(":checked");
        if ($cb6isChecked) {
            $('#cb2').attr("disabled", true);
            $('#cb3').attr("disabled", true);
            $('#cb4').attr("disabled", true);
            $('#cb5').attr("disabled", true);
            $('#cb1').attr("disabled", true);
            //是否需要
            $('#cb2_ss').attr("disabled", true);
            $('#cb3_bk').attr("disabled", true);
            $('#cb4_dz').attr("disabled", true);
            $('#cb5_cg').attr("disabled", true);
            $('#cb1_bs').attr("disabled", true);

        } else {
            $('#cb2').attr("disabled", false);
            $('#cb3').attr("disabled", false);
            $('#cb4').attr("disabled", false);
            $('#cb5').attr("disabled", false);
            $('#cb1').attr("disabled", false);
            //是否需要
            $('#cb2_ss').attr("disabled", false);
            $('#cb3_bk').attr("disabled", false);
            $('#cb4_dz').attr("disabled", false);
            $('#cb5_cg').attr("disabled", false);
            $('#cb1_bs').attr("disabled", false);
        }
    });
    $('#cb1_bs').click(function () {
        var $isChecked = $("#cb1_bs").is(":checked");
        if ($isChecked) {
            $('#tb_bs').attr("disabled", false);
        } else {
            $('#tb_bs').attr("disabled", true);
            $('#tb_bs').focus();
        }
    });
    $('#cb2_ss').click(function () {
        var $isChecked = $("#cb2_ss").is(":checked");
        if ($isChecked) {
            $('#tb_ss').attr("disabled", false);
        } else {
            $('#tb_ss').attr("disabled", true);
            $('#tb_ss').focus();
        }
    });
    $('#cb3_bk').click(function () {
        var $isChecked = $("#cb3_bk").is(":checked");
        if ($isChecked) {
            $('#tb_bk').attr("disabled", false);
        } else {
            $('#tb_bk').attr("disabled", true);
            $('#tb_bk').focus();
        }
    });
    $('#cb4_dz').click(function () {
        var $isChecked = $("#cb4_dz").is(":checked");
        if ($isChecked) {
            $('#tb_dz').attr("disabled", false);
        } else {
            $('#tb_dz').attr("disabled", true);
            $('#tb_dz').focus();
        }
    });
    $('#cb5_cg').click(function () {
        var $isChecked = $("#cb5_cg").is(":checked");
        if ($isChecked) {
            $('#tb_cg').attr("disabled", false);
        } else {
            $('#tb_cg').attr("disabled", true);
            $('#tb_cg').focus();
        }
    });
    $('#cb6_wu').click(function () {
        var $isChecked = $("#cb6_wu").is(":checked");
        if ($isChecked) {
            $('#tb_wu').attr("disabled", false);
        } else {
            $('#tb_wu').attr("disabled", true);
            $('#tb_wu').focus();
        }
    });

    //职称
    $('#cb_no').click(function () {
        var $isChecked = $(this).is(":checked");
        if ($isChecked) {
            $(this).siblings().attr("checked", false);
        }
    });
    $('#cb_cjzc').click(function () {
        var $isChecked = $(this).is(":checked");
        if ($isChecked) {
            $(this).siblings().attr("checked", false);
        }
    });
    $('#cb_zjzc').click(function () {
        var $isChecked = $(this).is(":checked");
        if ($isChecked) {
            $(this).siblings().attr("checked", false);
        }
    });
    $('#cb_gjzc').click(function () {
        var $isChecked = $(this).is(":checked");
        if ($isChecked) {
            $(this).siblings().attr("checked", false);
        }
    });
    //执业执照
    $('#cb_zyzz').click(function () {
        var $isChecked = $("#cb_zyzz").is(":checked");
        if ($isChecked) {
            $('#tb_zyzz').attr("disabled", false);
        } else {
            $('#tb_zyzz').attr("disabled", true);
            $('#tb_zyzz').focus();
        }
    });
    $('#cb_tssgz').click(function () {
        var $isChecked = $("#cb_tssgz").is(":checked");
        if ($isChecked) {
            $('#tb_tssgz').attr("disabled", false);
        } else {
            $('#tb_tssgz').attr("disabled", true);
            $('#tb_tssgz').focus();
        }
    });
});