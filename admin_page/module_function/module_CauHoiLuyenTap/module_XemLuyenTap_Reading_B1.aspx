<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_XemLuyenTap_Reading_B1.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_XemLuyenTap_Reading_B1" %>

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
    <title>Trắc nghiệm Tiếng Anh</title>
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
    <!-- Owl Carousel CSS -->
    <link rel="stylesheet" href="/css/owl.carousel.min.css" />
    <link rel="stylesheet" href="/css/owl.theme.default.min.css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="/css/animate.min.css" />
    <!-- Slick Nav CSS -->
    <link rel="stylesheet" href="/css/slicknav.min.css" />
    <%--Trắc Nghiệm--%>
    <script src="../../../js/jquery-3.5.1.min.js"></script>
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <link href="/css/css_tracnghiem/tracnghiem.css" rel="stylesheet" />
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="/js/jquery-3.5.1.min.js"></script>
    <style>
        body {
            -moz-user-select: none !important; /* Firefox */
            -ms-user-select: none !important; /* Internet Explorer */
            -khtml-user-select: none !important; /* KHTML browsers (e.g. Konqueror) */
            -webkit-user-select: none !important; /* Chrome, Safari, and Opera */
            -webkit-touch-callout: none !important; /* Disable Android and iOS callouts*/
            user-select: none !important;
        }

        .body {
            background-image: url("../images/English/reading/backtest.png") !important;
        }

        .Part1, .Part3, .Part4, .Part5, .Part6, .Part7 {
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

        /* .tracnghiem__content {
        width: 100%;
    }*/

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

        /*.Part1 .content_image img {
            width: 90% !important;
        }*/
        .content_image, .tracnghiem__content-box {
            text-align: inherit;
        }

        .Part1 .tracnghiem-title__answer {
            width: 85% !important;
            margin: 2.5% 8% !important;
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

        .Answer-input {
            text-align: center;
        }

        .content_cauhoilon {
            text-align: center;
        }

        .tracnghiem__question > *, .tracnghiem__question > * > * {
            font-size: 20px !important;
            font-family: Arial, sans-serif !important;
        }

        label.tracnghiem-title__answer > *, label.tracnghiem-title__answer > * > *, label.tracnghiem-title__answer > * > * > * {
            font-size: 18px !important;
            font-family: Arial, sans-serif !important;
            color: black !important;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <script>
            function checkShow() {
                var checkNone = document.querySelector(".baitap__content");
                document.querySelector("#check__none").style.display = "none";
                checkNone.classList.add("baitap__show");
                document.getElementById("check_back").style.display = 'none';
            }
            function checkCookie() {
                document.getElementById('<%=btnCheckCookie.ClientID%>').click();
            }
            //func chọn đáp án trắc nghiệm
            function checkValue(ques_id, value, id_check) {
                $("input[name='value_" + ques_id + "']").val(value);
                $("input[name='ID_" + ques_id + "']").val(id_check);
            }
           <%-- function confirmDel() {
                swal("Do you really want to submit your answer ?",
                    "If you agree, the answer will not be changed.",
                    "warning",
                    {
                        buttons: ["Cancel", "Yes"],
                        successMode: true,
                    }).then(function (value) {
                        if (value == true) {
                            checkValueFinish();
                            DisplayLoadingIcon();
                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                        }
                    });
            }--%>
            var count = 0;
            //Check đáp án part1, part3, part5 (trắc nghiệm lựa chọn)
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
            //check part2, part4 (kết quả nhập phải đúng chữ hoa chữ thường)
            function checkPart2_4() {
                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                //let arrDung = [];
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan");
                    var giatrinhapvap = getValues[index].val();
                    if (dapandung == giatrinhapvap) {
                        count++;
                        getValues[index].css({
                            "color": "green"
                        });
                        //arrDung.push("true");
                    } else {
                        getValues[index].css({
                            "color": "red"
                        });
                        //arrDung.push("false");
                    }
                }
                let arr_id = $("input[name*='dapan_']").map(function () {
                    return $(this).data("id");
                }).get();
                let arr_value = $("input[name*='dapan_']").map(function () {
                    return $(this).val();
                }).get();
                document.getElementById('<%=txtValueInput.ClientID%>').value = arr_value.toString();
                document.getElementById('<%=txtCauHoiPart2_4.ClientID%>').value = arr_id.toString();
                console.log(count);
            }
            //func check đáp án part6
            function checkPart6() {
                var getDapAn = $("input[name*='part6_']").map(function () {
                    return $(this);
                }).get();
                let arrDung = [];
                for (var index = 0; index < getDapAn.length; index++) {
                    var dapandung = getDapAn[index].data("dapan").toUpperCase().split('/ ');;
                    var giatrinhapvao = getDapAn[index].val().trim().toUpperCase();
                    if (dapandung.includes(giatrinhapvao) == true) {
                        count++;
                        getDapAn[index].css({
                            "color": "green"
                        });
                        arrDung.push("true");
                    } else {
                        getDapAn[index].css({
                            "color": "red"
                        });
                        arrDung.push("false");
                    }
                }
                var getValues = $("input[name*='part6_']").map(function () {
                    return $(this).val();
                }).get();
                let arr_id = $("input[name*='part6_']").map(function () {
                    return $(this).data("id");
                }).get();
                document.getElementById('<%=txtValuePart6.ClientID%>').value = getValues.toString();
                document.getElementById('<%=txtDungSai.ClientID%>').value = arrDung.toString();
                document.getElementById('<%=txtCauHoiPart6.ClientID%>').value = arr_id.toString();
                console.log(count);
            }
            function checkValueFinish() {
                checkTracNghiem();
                checkPart2_4();
                checkPart6();
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
            }
            $(document).ready(function () {
                $(".popup__times").click(function () {
                    document.getElementById("<%=btnClose.ClientID%>").click();
                });
            });
            //fun hiển thị popup
            function showPopUp() {
                $(".popup__content").toggleClass("popup__show");
                $(".popupPoint").toggleClass("popup__show");
                //$('.ten-countdown').css("display", "none")
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
        <a class="button pink--md serif round glass btn__pre" id="btnBack" runat="server" onserverclick="btnBack_ServerClick">Back</a>
        <div class="main__tracnghiem" id="popupBlur">
            <%--<a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Start</a>--%>
            <%--popup--%>
            <div class="popupPoint" id="popupPoint">
                <div class="popup__content">
                    <div class="popup__heading">
                        <div class="popup__point">
                            <div class="point">
                                <span id="pointStart"></span><span id="pointFinish"></span>&nbsp;
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
                        </div>
                        <div class="container">
                            <div style="display: none">
                                <input type="text" value="" id="txtSoCauDung" runat="server" placeholder="số câu đúng" />
                                <input type="text" name="txtChecked" value="" id="txtChecked" runat="server" placeholder="checked" />
                                <input type="text" value="" id="txtIDQuestion" runat="server" placeholder="id c^^au hỏi" />
                                <input type="text" name="txtValue" value="" id="txtValueChecked" runat="server" placeholder="value" />
                                giá trị input nhập vào part 2 & 4 :
                                <input type="text" value="" id="txtValueInput" runat="server" placeholder="checked" />
                                giá trị id câu hỏi part 2 & 4 :
                                <input type="text" value="" id="txtCauHoiPart2_4" runat="server" placeholder="checked" />
                                giá trị input nhập vào part 6
                                <input type="text" value="" id="txtValuePart6" runat="server" placeholder="checked" />
                                giá trị đúng sai part 6
                                <input type="text" value="" id="txtDungSai" runat="server" placeholder="checked" />
                                giá trị id câu hỏi part 6
                                <input type="text" value="" id="txtCauHoiPart6" runat="server" placeholder="checked" />
                            </div>
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading" id="title"></h3>
                                </div>
                            </div>
                            <%--part 1--%>
                            <div class="Part1">
                                <p class="Part_header">Part 1:</p>
                                <asp:Repeater runat="server" ID="rpCauHoiPart1" OnItemDataBound="rpPart1_ItemDataBound">
                                    <ItemTemplate>
                                        <fieldset class="tracnghiem__content">
                                            <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                            <div class="tracnghiem__content-box">
                                                <h4 class="tracnghiem__question col-3"><%#Eval("noidungcauhoi") %>
                                                </h4>
                                                <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                <div class="tracnghiem__answer col-9">
                                                    <div class="tracnghiem__box">
                                                        <asp:Repeater ID="rpCauTraLoiPart1" runat="server">
                                                            <ItemTemplate>
                                                                <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="display: none">
                                                <input type="text" name="value_<%#Eval("question_id") %>" />
                                                <input type="text" name="ID_<%#Eval("question_id") %>" />
                                            </div>
                                        </fieldset>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <%--end part 1--%>
                            <%--part 2--%>
                            <fieldset class="tracnghiem__content">
                                <h3 class="Part_header">Part 2:</h3>
                                <div class="content_cauhoilon">
                                    <asp:Repeater ID="rpCauHoiLonPart2" runat="server">
                                        <ItemTemplate>
                                            <%#Eval("QuestionBig_content") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="Answer">
                                    <asp:Repeater ID="rpCauHoiPart2" runat="server" OnItemDataBound="rpCauHoiPart2_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <%#Eval("noidungcauhoi") %>:
                            <asp:Repeater ID="rpCauTraLoiPart2" runat="server">
                                <ItemTemplate>
                                    <input data-dapan="<%#Eval("answer_content") %>" data-id="<%#Eval("question_id") %>" class="Answer-input" type="text" name="dapan_<%=count++%>" autocomplete="off" />
                                </ItemTemplate>
                            </asp:Repeater>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </fieldset>
                            <%--end part 2--%>
                            <%--part 3--%>
                            <div class="Part3">
                                <p class="Part_header">Part 3:</p>
                                <div class="tracnghiem__content-box">
                                    <div class="content_cauhoilon">
                                        <asp:Repeater runat="server" ID="rpCauHoiLonPart3">
                                            <ItemTemplate>
                                                <img src=" <%#Eval("QuestionBig_content") %>" alt="Alternate Text" />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <asp:Repeater runat="server" ID="rpCauHoiPart3" OnItemDataBound="rpCauHoiPart3_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="tracnghiem__content-box">
                                                <h4 class="tracnghiem__question"><%=STT_Part3++ %>: <%#Eval("noidungcauhoi") %>
                                                </h4>
                                                <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                <div class="tracnghiem__answer">
                                                    <div class="tracnghiem__box">
                                                        <asp:Repeater ID="rpCauTraLoiPart3" runat="server">
                                                            <ItemTemplate>
                                                                <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
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
                                </div>
                            </div>
                            <%--end part 3--%>
                            <%--part 4--%>
                            <fieldset class="tracnghiem__content">
                                <h3 class="Part_header">Part 4:</h3>
                                <div class="content_cauhoilon">
                                    <asp:Repeater ID="rpCauHoiLonPart4" runat="server">
                                        <ItemTemplate>
                                            <%#Eval("QuestionBig_content") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="Answer">
                                    <asp:Repeater ID="rpCauHoiPart4" runat="server" OnItemDataBound="rpCauHoiPart4_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <%#Eval("noidungcauhoi") %>:
                            <asp:Repeater ID="rpCauTraLoiPart4" runat="server">
                                <ItemTemplate>
                                    <input data-dapan="<%#Eval("answer_content") %>" data-id="<%#Eval("question_id") %>" class="Answer-input" type="text" name="dapan_<%=count++%>" autocomplete="off" />
                                </ItemTemplate>
                            </asp:Repeater>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </fieldset>
                            <%--end part 4--%>
                            <%--part 5--%>
                            <div class="Part5">
                                <p class="Part_header">Part 5:</p>
                                <div class="tracnghiem__content-box">
                                    <div class="content_cauhoilon">
                                        <asp:Repeater runat="server" ID="rpCauHoiLonPart5">
                                            <ItemTemplate>
                                                <img src=" <%#Eval("QuestionBig_content") %>" alt="Alternate Text" />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <asp:Repeater runat="server" ID="rpCauHoiPart5" OnItemDataBound="rpCauHoiPart5_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="tracnghiem__content-box">
                                                <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>:
                                                </h4>
                                                <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                <div class="tracnghiem__answer">
                                                    <div class="tracnghiem__box">
                                                        <asp:Repeater ID="rpCauTraLoiPart5" runat="server">
                                                            <ItemTemplate>
                                                                <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
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
                                </div>
                            </div>
                            <%--end part 6--%>
                            <%--part 6--%>
                            <fieldset class="tracnghiem__content">
                                <h3 class="Part_header">Part 6:</h3>
                                <div class="content_cauhoilon">
                                    <asp:Repeater ID="rpCauHoiLonPart6" runat="server">
                                        <ItemTemplate>
                                            <%#Eval("QuestionBig_content") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="Answer">
                                    <asp:Repeater ID="rpCauHoiPart6" runat="server" OnItemDataBound="rpCauHoiPart6_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <%#Eval("noidungcauhoi") %>:
                                                <asp:Repeater ID="rpCauTraLoiPart6" runat="server">
                                                    <ItemTemplate>
                                                        <input data-dapan="<%#Eval("answer_content") %>" data-id="<%#Eval("question_id") %>" class="Answer-input" type="text" name="part6_<%=stt_part6++%>" autocomplete="off" />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </fieldset>
                            <%--end part 6--%>
                            <a href="javascript:void(0)" id="btnChuyenDuyet" runat="server" onserverclick="btnChuyenDuyet_ServerClick" class="btn btn-success">Chuyển lên duyệt</a>
                            <a href="javascript:void(0)" id="btnXacnhanhoanthanh" runat="server" onserverclick="btnXacnhanhoanthanh_ServerClick" class="btn btn-success">Xác nhận hoàn thành</a>
                        </div>
                        <div class="tracnghiem__button">
                            <a href="javascript:void(0)" id="btnFinish" onclick="checkValueFinish();" class="button pink__finish serif round glass popup__finish">Finish</a> <%--return confirmDel()--%>
                            <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                            <br />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
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
</html>
