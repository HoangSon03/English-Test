<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_XemLuyenTap_Reading_A2.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_XemLuyenTap_Reading_A2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Meta -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="keywords" content="SITE KEYWORDS HERE" />
    <meta name="description" content="" />
    <meta name='copyright' content='' />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Title -->
    <title>Trắc nghiệm Online</title>
    <!-- Favicon -->
    <link rel="icon" type="image/png" href="../../../images/logo_mamnon.png" />
    <!-- Web Font -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet" />
    <!-- Font IcoFont CSS -->
    <link href="/css/icofont.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="/css/font-awesome.min.css" />
    <!-- Fancy Box CSS -->
    <!-- Owl Carousel CSS -->
    <link rel="stylesheet" href="/css/owl.carousel.min.css" />
    <link rel="stylesheet" href="/css/owl.theme.default.min.css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="/css/animate.min.css" />
    <!-- Slick Nav CSS -->
    <link rel="stylesheet" href="/css/slicknav.min.css" />
    <!-- Magnific Popup -->
    <%--Trắc Nghiệm--%>
    <script src="../../../js/jquery-3.5.1.min.js"></script>
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <link href="/css/css_tracnghiem/tracnghiem.css" rel="stylesheet" />
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="/js/jquery-3.5.1.min.js"></script>
    <link href="../../css/Loading.css" rel="stylesheet" />


<style>
    body {
        -moz-user-select: none; /* Firefox */
        -ms-user-select: none; /* Internet Explorer */
        -khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
        -webkit-user-select: none; /* Chrome, Safari, and Opera */
        -webkit-touch-callout: none; /* Disable Android and iOS callouts*/
    }

    .body {
        background-image: url("../images/English/reading/backtest.png") !important;
    }

    .khung {
        background: white;
        /* text-align: center; */
        border: 3px solid #b51a1a;
        padding: 20px;
        border-radius: 17px;
        box-shadow: 0 7px 10px rgb(0 0 0 / 30%);
        width: 97%;
        background: #fff;
        margin: 0 0 21px 0;
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

    .tracnghiem__content {
        width: 100%;
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

    .Answer {
        width: 100%;
        display: flex;
        margin: 1% 0% 1% 0%;
    }

    .content_image, .tracnghiem__content-box {
        text-align: center;
    }

    .tracnghiem-title__answer {
        text-align: left;
    }

    .tracnghiem__question {
        text-align: left;
    }

    label.tracnghiem-title__answer {
        margin: 0px 0px 0px 0px;
    }

    .tracnghiem__answer {
        text-align: left;
        margin-top: 2%;
    }
    /*Update*/
    .Part1 .tracnghiem__content-box {
        display: flex;
    }

    .Part1 .tracnghiem__question {
        width: 62%;
    }

    .Part1 .content_image {
        width: 100%;
    }

    .Part5 .tracnghiem__question {
        text-align: center;
    }

    /*.Part1 .content_image img {
            width: 90% !important;
        }*/
    .content_image, .tracnghiem__content-box {
        text-align: inherit;
    }

    .Part1 .tracnghiem-title__answer {
        width: 85% !important;
        margin: 3.5% 8% !important;
    }

    .Part4 .content_image, .Part4 .tracnghiem__content-box,
    .Part6 .content_image, .Part6 .tracnghiem__content-box {
        text-align: center;
    }

    .Part4 .tracnghiem__box,
    .Part6 .tracnghiem__box {
        text-align: center;
    }

    .Part6 .tracnghiem__content-box img {
        width: 75%;
    }

    .part2-img {
        /*display:flex;*/
    }

    .part2-img2 {
        width: 73%;
    }

    .tracnghiem__heading {
        font-weight: 900;
    }

    .Part_question {
        width: 100%;
        display: grid;
    }

    .Part_img {
        margin: auto;
    }

    .text-answer {
        text-align: center;
        font-weight: 700;
        color: #b51a1a;
        font-size: 130%;
    }

    .form-control {
        border: 4px solid #ced4da;
    }

    .Answer-input {
        text-align: center;
    }

    .tracnghiem__question > *, .tracnghiem__question > * > * {
        font-size: 20px !important;
    }

    label.tracnghiem-title__answer > *, label.tracnghiem-title__answer > * > * {
        font-size: 18px !important;
    }

    .content_cauhoilon {
        text-align: center;
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
            //func check đáp án trắc nghiệm
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
                //debugger;
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
            //func check đáp án tự luận
            function checkTuLuan() {
                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                let arrDung = [];
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan").toUpperCase().split('/ ');
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
                console.log(count);
                var getGiaTriNhapVao = $("input[name*='dapan_']").map(function () {
                    return $(this).val();
                }).get();
                var getArr_ID = $("input[name*='dapan_']").map(function () {
                    return $(this).data('id');
                }).get();
                document.getElementById('<%=txtValueInput.ClientID%>').value = getGiaTriNhapVao.toString();
                document.getElementById('<%=txtDanAnInput.ClientID%>').value = arrDung.toString();
                document.getElementById('<%=txtDanhSachID.ClientID%>').value = getArr_ID.toString();
            }
            //func check writing
            function chekWriting() {
                var getQuestionID = $("input[name='txtWritingID']").map(function () {
                    return $(this).val();
                }).get();
                //var getContent = $("input[name='txtWriting']").map(function () {
                //    return $(this).val();
                //}).get();
                //console.log(getContent)
                var content = "";
                for (var i = 0; i < getQuestionID.length; i++) {
                    var _content = document.getElementById("txtnoidung_" + getQuestionID[i]).value;
                    if (content == "")
                        content = _content;
                    else
                        content = content + "|" + _content;
                    //console.log(document.getElementById("txtnoidung_" + getQuestionID[i]).value)

                }
                document.getElementById('<%=txtContentWriting.ClientID%>').value = content;
                document.getElementById('<%=txtIDWriting.ClientID%>').value = getQuestionID.toString();
                //document.getElementById("txtnoidung_" + getQuestionID[0]).value;
            }
            function checkValueFinish() {
                checkTracNghiem();
                checkTuLuan();
                chekWriting();
                chekWriting();
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
            }

            <%--function confirmDel() {
                swal("Do you really want to submit your answer ?",
                    "If you agree, the answer will not be changed.",
                    "warning",
                    {
                        buttons: true,
                        successMode: true
                    }).then(function (value) {
                        if (value == true) {
                            //debugger;
                            checkValueFinish();
                            DisplayLoadingIcon();
                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                            //$(document).ready(function () {
                            //    $(".popup__content").toggleClass("popup__show");
                            //    $(".popupPoint").toggleClass("popup__show");
                            //    $('.ten-countdown').css("display", "none")
                            //});
                        }
                    });
               
            }--%>
           
        </script>

        <%--quy--%>
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
        <a class="button pink--md serif round glass btn__pre" id="btnBack" runat="server" onserverclick="btnBack_ServerClick">Back</a>
        <div class="main__tracnghiem" id="popupBlur">
            <%--<a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Start</a>--%>
            <div class="popupPoint" id="popupPoint">
                <div class="popup__content">
                    <div class="popup__heading">
                        <div class="popup__point">
                            <div class="point">
                                <%-- <span id="pointStart"></span><span id="pointFinish"></span>&nbsp;--%>
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
            <div class="baitap__content baitap__show">
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
                                giá trị đáp án đúng:
                                <input type="text" value="" id="txtDanAnInput" runat="server" placeholder="checked" />
                                giá trị id câu hỏi:
                                <input type="text" value="" id="txtDanhSachID" runat="server" placeholder="checked" />
                                <%--phần trả lời writing--%>
                                <input type="text" value="" id="txtIDWriting" runat="server" placeholder="id c^^au hỏi" />
                                <textarea id="txtContentWriting" runat="server"></textarea>
                                <input type="text" value="" placeholder="id c^^au hỏi" />
                                <%--<input type="text" value="" id="txtIDQuestion3" runat="server" placeholder="id c^^au hỏi" />--%>
                                <%--  <textarea id="txtDapAn1" runat="server"></textarea>
                                <textarea id="txtDapAn2" runat="server"></textarea>
                                <textarea id="txtDapAn3" runat="server"></textarea>--%>
                            </div>
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading" id="title"></h3>
                                </div>
                            </div>
                            <%--part 11--%>
                            <div class="khung">
                                <div class="Part1 content">
                                    <p class="Part_header">Part 1:</p>
                                    <asp:Repeater runat="server" ID="rpCauHoiPart1" OnItemDataBound="rpCauHoiPart1_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question col-3"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer col-9">
                                                        <div class="tracnghiem__box">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div style="display: none;">
                                                    <input type="text" name="value_<%#Eval("question_id") %>" />
                                                    <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                </div>
                                            </fieldset>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <%--part2, 3, 4--%>
                                <div class="content">
                                    <asp:Repeater ID="rpCauHoiLon" runat="server" OnItemDataBound="rpCauHoiLon_ItemDataBound">
                                        <ItemTemplate>
                                            <p class="Part_header">Part <%=_part++ %>:</p>
                                            <div class="content_cauhoilon">
                                                <%#Eval("QuestionBig_content") %>
                                            </div>
                                            <asp:Repeater runat="server" ID="rpCauHoiPart2" OnItemDataBound="rpCauHoiPart2_ItemDataBound">
                                                <ItemTemplate>
                                                    <fieldset class="tracnghiem__content">
                                                        <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                        <div class="tracnghiem__content-box">
                                                            <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %></h4>
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
                                                        <div style="display: none;">
                                                            <input type="text" name="value_<%#Eval("question_id") %>" />
                                                            <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                        </div>
                                                    </fieldset>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <%--part 5--%>
                                <div class="content">
                                    <p class="Part_header">Part 5:</p>
                                    <div class="content_cauhoilon">
                                        <asp:Repeater ID="rpCauHoiLonPart5" runat="server">
                                            <ItemTemplate>
                                                <%#Eval("QuestionBig_content") %>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="Answer">
                                        <asp:Repeater ID="rpCauHoiPart5" runat="server" OnItemDataBound="rpCauHoiPart5_ItemDataBound">
                                            <ItemTemplate>
                                                <div>
                                                    <span><%#Eval("noidungcauhoi") %>:</span>
                                                    <asp:Repeater ID="rpCauTraLoiPart5" runat="server">
                                                        <ItemTemplate>
                                                            <input data-dapan="<%#Eval("answer_content") %>" data-id="<%#Eval("question_id") %>" class="Answer-input" type="text" name="dapan_<%=count++%>" autocomplete="off" />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <%--part 6--%>
                                <div class="content">
                                    <asp:Repeater runat="server" ID="rpCauHoiPart67">
                                        <ItemTemplate>
                                            <p class="Part_header">Part <%=P++ %>:</p>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=S++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %> </h4>
                                                    <input type="text" name="txtWritingID" value="<%#Eval("question_id") %>" hidden />
                                                </div>
                                                <div class="text-answer">Answer:</div>
                                                <textarea class="form-control" rows="7" name="txtWriting" id="txtnoidung_<%#Eval("question_id") %>"></textarea>
                                            </fieldset>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%--part 7--%>
                            <a href="javascript:void(0)" id="btnChuyenDuyet" runat="server" onserverclick="btnChuyenDuyet_ServerClick" class="btn btn-success">Chuyển lên duyệt</a>
                            <a href="javascript:void(0)" id="btnXacnhanhoanthanh" runat="server" onserverclick="btnXacnhanhoanthanh_ServerClick" class="btn btn-success">Xác nhận hoàn thành</a>
                            <div class="tracnghiem__button">
                                <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="checkValueFinish()" class="button pink__finish serif round glass popup__finish">Finish</a>
                                <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                                <br />
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
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
