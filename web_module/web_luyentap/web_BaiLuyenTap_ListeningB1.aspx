<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_BaiLuyenTap_ListeningB1.aspx.cs" Inherits="web_module_web_luyentap_web_BaiLuyenTap_ListeningB1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Meta -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="keywords" content="SITE KEYWORDS HERE" />
    <meta name="description" content="" />
    <meta name='copyright' content='' />
    <%-- <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Title -->
    <title>Trắc nghiệm Online</title>
    <!-- Favicon -->
    <link rel="icon" type="image/png" href="../../images/logo_mamnon.png" />
    <!-- Web Font -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet" />
    <!-- Font IcoFont CSS -->
    <link href="/css/icofont.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="/css/font-awesome.min.css" />
    <!-- Fancy Box CSS -->
    <link rel="stylesheet" href="/css/jquery.fancybox.min.css" />
    <!-- Owl Carousel CSS -->
    <link rel="stylesheet" href="/css/owl.carousel.min.css" />
    <link rel="stylesheet" href="/css/owl.theme.default.min.css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="/css/animate.min.css" />
    <!-- Slick Nav CSS -->
    <link rel="stylesheet" href="/css/slicknav.min.css" />
    <!-- Magnific Popup -->
    <link rel="stylesheet" href="/css/magnific-popup.css" />
    <%--Trắc Nghiệm--%>
    <link href="/css/css_tracnghiem/tracnghiem.css" rel="stylesheet" />
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <!-- Learedu Stylesheet -->
    <%--<link href="css/css_trangchu/trangchu.css" rel="stylesheet" />--%>
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="/js/jquery-3.5.1.min.js"></script>
    <link href="../../css/Loading.css" rel="stylesheet" />

    <style>
        .tracnghiem__heading {
            font-weight: 900;
        }

        .Answer-input {
            text-align: center;
        }

        body {
            -moz-user-select: none; /* Firefox */
            -ms-user-select: none; /* Internet Explorer */
            -khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
            -webkit-user-select: none; /* Chrome, Safari, and Opera */
            -webkit-touch-callout: none; /* Disable Android and iOS callouts*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            function checkValue(ques_id, value, id_check) {
                //var getValue = $("input[name='check_" + ques_id + "']:checked").val();
                $("input[name='value_" + ques_id + "']").val(value);
                $("input[name='ID_" + ques_id + "']").val(id_check);
            }

            var count = 0;
            //Check đáp án part1, part2, part4 (trắc nghiệm lựa chọn)
            function checkTracNghiem() {
                var getValues = $("input[name*='value_']").map(function () {
                    return $(this).val();
                }).get();
                var getId = $("input[name*='ID_']").map(function () {
                    return $(this).val();
                }).get();

                var getQuestionID = $("input[name='txtQuestionID']").map(function () {
                    return $(this).val();
                }).get();
                document.getElementById('<%=txtChecked.ClientID%>').value = getId;
                document.getElementById('<%=txtIDQuestion.ClientID%>').value = getQuestionID;
                document.getElementById('<%=txtValueChecked.ClientID%>').value = getValues;

                for (var index = 0; index < getValues.length; index++) {
                    if (getValues[index] == "True") {
                        count++;
                    }
                }
                console.log(count);
                //hiển thị lại đáp án đúng/sai của các câu checked
                var getValue = document.getElementById('<%=txtValueChecked.ClientID%>').value.split(',');
                var getId = document.getElementById('<%=txtChecked.ClientID%>').value.split(',');
                for (var index = 0; index < getId.length; index++) {
                    $("#test" + getId[index] + "").attr('checked', 'checked');

                    if (getValue[index] == "True") {
                        $("#test" + getId[index] + "").next().css("color", "green");
                        $("#test" + getId[index] + "").next().toggleClass('checked__rdoo');

                    } else {
                        $("#test" + getId[index] + "").next().css("color", "red");
                        $("#test" + getId[index] + "").next().toggleClass('checked__rdo');
                    }
                }
            }
            //fun check đáp án tự luận part3
            function checkTuLuan() {
                let arrDung = [];
                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan").toUpperCase().split('/');
                    var giatrinhapvao = getValues[index].val().trim().toUpperCase();
                    if (dapandung.includes(giatrinhapvao) == true) {
                        count++;
                        getValues[index].css({
                            "color": "green"
                        });
                        arrDung.push("true");
                    } else {
                        getValues[index].css({
                            "color": "red"
                        });
                        arrDung.push("false");
                    }
                }
                var getGiaTriNhapVao = $("input[name*='dapan_']").map(function () {
                    return $(this).val();
                }).get();
                var arr_id = $("input[name*='dapan_']").map(function () {
                    return $(this).data('id');
                }).get();
                console.log(count);
                document.getElementById('<%=txtValueInput.ClientID%>').value = getGiaTriNhapVao.toString();
                document.getElementById('<%=txtIdCauHoi.ClientID%>').value = arr_id.toString();
                document.getElementById('<%=txtDapAnDung.ClientID%>').value = arrDung.toString();
            }
            function checkValueFinish() {
                checkTracNghiem();
                checkTuLuan();
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
                //debugger;
                <%--var getValues = $("input[name*='value_']").map(function () {
                    return $(this).val();
                }).get();
                var getId = $("input[name*='ID_']").map(function () {
                    return $(this).val();
                }).get();

                var getQuestionID = $("input[name='txtQuestionID']").map(function () {
                    return $(this).val();
                }).get();
                document.getElementById('<%=txtChecked.ClientID%>').value = getId;
                document.getElementById('<%=txtIDQuestion.ClientID%>').value = getQuestionID;
                document.getElementById('<%=txtValueChecked.ClientID%>').value = getValues;
                var count = 0;
                for (var index = 0; index < getValues.length; index++) {
                    if (getValues[index] == "True") {
                        count++;
                    }
                }
                let arrDung = [];
                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan").toUpperCase().split('/');
                    var giatrinhapvao = getValues[index].val().trim().toUpperCase();

                    console.log(dapandung, giatrinhapvao)
                    if (dapandung.includes(giatrinhapvao) == true) {
                        count++;
                        getValues[index].css({
                            "color": "green"
                        });
                        arrDung.push("true");
                    } else {
                        getValues[index].css({
                            "color": "red"
                        });
                        arrDung.push("false");
                    }
                }
                var getGiaTriNhapVao = $("input[name*='dapan_']").map(function () {
                    return $(this).val();
                }).get();
                var getDapAnDung = $("input[name*='dapan_']").map(function () {
                    return $(this).data('dapan');
                }).get();
                document.getElementById('<%=txtValueInput.ClientID%>').value = getGiaTriNhapVao.toString();
                document.getElementById('<%=txtDanAnInput.ClientID%>').value = getDapAnDung.toString();
                console.log(arrDung);
                document.getElementById('<%=txtArr.ClientID%>').value = arrDung.toString();
                //document.getElementById("pointStart").innerHTML = count;
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;--%>
                //var changeImage = document.querySelector(".point__img");
                //changeImage.src = "";


                //if (count >= 9) {
                //    changeImage.src = "../../../../images/point-right.gif";
                //} else {
                //    changeImage.src = "../../../../images/point-left.gif";
                //}
            }

            function confirmDel() {
                swal("Do you really want to submit your answer ?",
                    "If you agree, the answer will not be changed.",
                    "warning",
                    {
                        buttons: true,
                        successMode: true
                    }).then(function (value) {
                        if (value == true) {
                            checkValueFinish();
                            DisplayLoadingIcon();
                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                        }
                    });
            }
            //close popup
            $(document).ready(function () {
                $(".popup__times").click(function () {
                    document.getElementById("<%=btnClose.ClientID%>").click();
                });
            });
            //fun hiển thị popup
            function showPopUp() {
                $(".popup__content").toggleClass("popup__show");
                $(".popupPoint").toggleClass("popup__show");
                $('.ten-countdown').css("display", "none")
            }
            function checkShow() {
                //debugger;
                var checkNone = document.querySelector(".baitap__content");
                var time = document.getElementById("<%=txtPhutHiden.ClientID%>").value;
                document.querySelector("#check__none").style.display = "none";
                checkNone.classList.add("baitap__show");
              <%--  document.getElementById('h_val').value = "00";
                document.getElementById('m_val').value = document.getElementById("<%=txtPhutHiden.ClientID%>").value;
                document.getElementById('s_val').value = "00";
                document.getElementById('title').innerHTML = document.getElementById("<%=txtTitle.ClientID%>").value;
                start();--%>
                document.getElementById("check_back").style.display = 'none';
            }
            function checkCookie() {
                document.getElementById('<%=btnCheckCookie.ClientID%>').click();

            }
            function stop() {
                clearTimeout(timeout);
            }
        </script>
        <script>
            function DisplayLoadingIcon() {
                $("#img-loading-icon").show();
            }
            function HiddenLoadingIcon() {
                $("#img-loading-icon").hide();
            }
        </script>
        <div class="loading" id="img-loading-icon" style="display: none">
            <div class="loading">Loading&#8230;</div>
        </div>
        <input type="text" id="txtPhutHiden" runat="server" hidden="hidden" />
        <input type="text" id="txtTitle" runat="server" hidden="hidden" />
        <a href="#" hidden="hidden" runat="server" id="btnCheckCookie" onserverclick="btnCheckCookie_ServerClick">check</a>
        <a href="#" hidden="hidden" runat="server" id="btnClose" onserverclick="btnClose_ServerClick">Close</a>
        <asp:ScriptManager runat="server" />
        <a runat="server" id="check_back" class="button pink--md serif round glass btn__pre" onserverclick="check_back_ServerClick">Back</a>
        <div class="main__tracnghiem" id="popupBlur">
            <a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Start</a>
            <div class="popupPoint" id="popupPoint">
                <div class="popup__content">
                    <div class="popup__heading">
                        <div class="popup__point">
                            <div class="point">
                            </div>
                            <div class="popup__times">
                            </div>
                            <i class="fa fa-times popup__times" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div class="popup__body">
                        <div class="popup__inner">
                            <img class="point__img" src="/images/English/list/success.png" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="baitap__content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container">
                            <div style="display: none">
                                <input type="text" value="" id="txtSoCauDung" runat="server" placeholder="số câu đúng" />
                                <input type="text" name="txtChecked" value="" id="txtChecked" runat="server" placeholder="checked" />
                                <input type="text" value="" id="txtIDQuestion" runat="server" placeholder="id c^^au hỏi" />
                                <input type="text" name="txtValue" value="" id="txtValueChecked" runat="server" placeholder="value" />
                                giá trị input nhập vào:
                                <input type="text" value="" id="txtValueInput" runat="server" placeholder="checked" />
                                ds id câu hỏi:
                                <input type="text" value="" id="txtIdCauHoi" runat="server" placeholder="checked" />
                                giá trị đúng sai
                                <input type="text" value="" id="txtDapAnDung" runat="server" placeholder="checked" />
                            </div>
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading" id="title"></h3>
                                </div>
                            </div>

                            <div class="Part">
                                <%--part 1 - 2--%>
                                <asp:Repeater ID="rpCauHoiLon" runat="server" OnItemDataBound="rpCauHoiLon_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <p class="Part_header">Part <%=STT_Part++ %>:</p>
                                            <p>For each question, choose the correct answer.</p>
                                            <div>
                                                <audio src="<%#Eval("questionbig_mp3") %>" controls="controls" />
                                            </div>
                                        </div>
                                        <asp:Repeater ID="rpCauHoi" runat="server" OnItemDataBound="rpCauHoi_ItemDataBound">
                                            <ItemTemplate>
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box col-12 row">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer col-4" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="display: none">
                                                    <input type="text" name="value_<%#Eval("question_id") %>" />
                                                    <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--end part 1 - 2--%>
                                <%--part3--%>
                                <p class="Part_header">Part 3:</p>
                                <div id="div_Part3_De1" runat="server">
                                    <asp:Repeater ID="rpCauHoiLonPart3" runat="server">
                                        <ItemTemplate>
                                            <audio src="<%#Eval("questionbig_mp3") %>" controls="controls"></audio>
                                            <br />
                                            <img src="<%#Eval("QuestionBig_content") %>" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div class="Answer col-12 row">
                                        <asp:Repeater ID="rpCauHoiPart3" runat="server" OnItemDataBound="rpCauHoiPart3_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="col-2">
                                                    <span><%#Eval("noidungcauhoi") %>:</span>
                                                    <asp:Repeater ID="rpCauTraLoiPart3" runat="server">
                                                        <ItemTemplate>
                                                            <input data-dapan="<%#Eval("answer_content") %>" data-id="<%#Eval("question_id") %>" class="form-control" type="text" name="dapan_<%=count++%>" autocomplete="off" />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <%--end part3--%>
                                <%--part4--%>
                                <asp:Repeater ID="rpCauHoiLonPart4" runat="server" OnItemDataBound="rpCauHoiLonPart4_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <p class="Part_header">Part 4:</p>
                                            <p>For each question, choose the correct answer.</p>
                                            <div>
                                                <audio src="<%#Eval("questionbig_mp3") %>" controls="controls" />
                                            </div>
                                        </div>
                                        <asp:Repeater ID="rpCauHoiPart4" runat="server" OnItemDataBound="rpCauHoi_ItemDataBound">
                                            <ItemTemplate>
                                                <legend class="tracnghiem__legend">Câu <%=STT_Part4++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box col-12 row">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer col-4" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="display: none">
                                                    <input type="text" name="value_<%#Eval("question_id") %>" />
                                                    <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--end part4--%>
                            </div>
                            <div class="tracnghiem__button">
                                <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="return confirmDel()" class="button pink__finish serif round glass popup__finish">Finish</a>
                                <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                                <br />
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <script src="/js/jquery-3.5.1.min.js"></script>
    <script src="/js/jquery-migrate.min.js"></script>
    <!-- Popper JS-->
    <script src="/js/popper.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="/js/bootstrap.min.js"></script>
    <!-- Colors JS-->
    <script src="/js/colors.js"></script>
    <!-- Jquery Steller JS -->
    <script src="/js/jquery.stellar.min.js"></script>
    <!-- Particle JS -->
    <script src="/js/particles.min.js"></script>
    <!-- Fancy Box JS-->
    <script src="/js/facnybox.min.js"></script>
    <!-- Magnific Popup JS-->
    <script src="/js/jquery.magnific-popup.min.js"></script>
    <!-- Masonry JS-->
    <script src="/js/masonry.pkgd.min.js"></script>
    <!-- Circle Progress JS -->
    <script src="/js/circle-progress.min.js"></script>
    <!-- Owl Carousel JS-->
    <script src="/js/owl.carousel.min.js"></script>
    <!-- Waypoints JS-->
    <script src="/js/waypoints.min.js"></script>
    <!-- Slick Nav JS-->
    <script src="/js/slicknav.min.js"></script>
    <!-- Counter Up JS -->
    <script src="/js/jquery.counterup.min.js"></script>
    <!-- Easing JS-->
    <script src="/js/easing.min.js"></script>
    <!-- Wow Min JS-->
    <script src="/js/wow.min.js"></script>
    <!-- Scroll Up JS-->
    <script src="/js/jquery.scrollUp.min.js"></script>
    <!-- Main JS-->
    <script src="/js/main.js"></script>
    <style>
        .Part {
            BACKGROUND: white;
            /*text-align: center;*/
            border: 3px solid #b51a1a;
            padding: 20px;
            border-radius: 17px;
            box-shadow: 0 7px 10px rgb(0 0 0 / 30%);
            width: 97%;
            background: #fff;
            margin: 0 0 21px 0;
        }

        .Part1 {
            BACKGROUND: white;
            /* text-align: center; */
            border: 3px solid #b51a1a;
            padding: 20px;
            border-radius: 17px;
            box-shadow: 0 7px 10px rgb(0 0 0 / 30%);
            width: 97%;
            background: #fff;
            margin: 0 0 21px 0;
        }

        .Part2 {
            width: 100%;
            border: 4px solid #b51a1a;
            border-radius: 12px;
            text-align: center;
        }

            .Part2 img {
                border-radius: 17px;
                margin-left: auto;
                margin-right: auto;
            }

            .Part2 p {
                font-size: 20px;
                font-weight: 600;
                padding: 0% 0% 0% 2%;
            }

        spea

        .Answer {
            width: 100%;
            display: flex;
            margin: 1% 0% 1% 0%;
        }

        .Part_header {
            text-align: center;
            font-weight: 900;
            background: linear-gradient(to right, #ed213a, #93291e);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            margin: 0;
            padding: 0 7px;
            font-size: 30px;
        }
    </style>
    <script type='text/javascript'>
        <%-- Chống chuột phải --%>
        var message = "NoRightClicking"; function defeatIE() { if (document.all) { (message); return false; } } function defeatNS(e) { if (document.layers || (document.getElementById && !document.all)) { if (e.which == 2 || e.which == 3) { (message); return false; } } } if (document.layers) { document.captureEvents(Event.MOUSEDOWN); document.onmousedown = defeatNS; } else { document.onmouseup = defeatNS; document.oncontextmenu = defeatIE; } document.oncontextmenu = new Function("return false")
        <%-- Chống copy paste --%>
        $('body').bind('copy paste', function (e) {
            e.preventDefault(); return false;
        });

        //ngăn dùng F12, ctr-shift-i .... để inspect html
        document.onkeydown = function (e) {
            if (event.keyCode == 123) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)) {
                return false;
            }
        }

        /*hàm ngăn copy paste test*/
        document.addEventListener("contextmenu", function (evt) {
            evt.preventDefault();
        });

        document.addEventListener("copy", function (evt) {
            evt.clipboardData.setData("text/plain", "");
            evt.preventDefault();
        });
    </script>
</body>
</html>
