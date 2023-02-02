<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/web_module/web_TracNghiemSpeaking.aspx.cs" Inherits="web_module_web_TracNghiemSpeaking" %>

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
    <link rel="icon" type="image/png" href="../images/logo_mamnon.png" />
    <!-- Web Font -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet" />
    <!-- Font IcoFont CSS -->
    <link href="/css/icofont.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="/css/font-awesome.min.css" />
    <%--Trắc Nghiệm--%>
    <link href="/css/css_tracnghiem/tracnghiem.css" rel="stylesheet" />
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="https://plus.google.com/js/client:platform.js"></script>
    <script src="/js/jquery-3.5.1.min.js"></script>
    <link href="../css/Loading.css" rel="stylesheet" />

</head>
<style>
    body {
        -moz-user-select: none; /* Firefox */
        -ms-user-select: none; /* Internet Explorer */
        -khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
        -webkit-user-select: none; /* Chrome, Safari, and Opera */
        -webkit-touch-callout: none; /* Disable Android and iOS callouts*/
    }

    .Part {
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
    }

    .tracnghiem__heading {
        font-weight: 900;
    }
</style>
<script>
    function checkValueFinish() {
        // ds id câu hỏi
        var getQuestionID = $("input[name='txtQuestionID']").map(function () {
            return $(this).val();
        }).get();
        document.getElementById('<%=txtIDQuestion1.ClientID%>').value = getQuestionID[0];
        document.getElementById('<%=txtIDQuestion2.ClientID%>').value = getQuestionID[1];
        document.getElementById('<%=txtIDQuestion3.ClientID%>').value = getQuestionID[2];
        document.getElementById('<%=txtIDQuestion4.ClientID%>').value = getQuestionID[3];

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
        var checkNone = document.querySelector(".baitap__content");
        document.querySelector("#check__none").style.display = "none";
        checkNone.classList.add("baitap__show");
        document.getElementById('h_val').value = "00";
        document.getElementById('m_val').value = document.getElementById("<%=txtPhutHiden.ClientID%>").value;
        document.getElementById('s_val').value = "00";
        document.getElementById('title').innerHTML = document.getElementById("<%=txtTitle.ClientID%>").value;
        start();
    }
    function checkCookie() {
        document.getElementById('<%=btnCheckCookie.ClientID%>').click();

    }


    //Timer

    var h = null; // Giờ
    var m = null; // Phút
    var s = null; // Giây

    var timeout = null; // Timeout

    function start() {
        /*BƯỚC 1: LẤY GIÁ TRỊ BAN ĐẦU*/
        if (h === null) {
            h = parseInt(document.getElementById('h_val').value);
            m = parseInt(document.getElementById('m_val').value);
            s = parseInt(document.getElementById('s_val').value);
        }

        /*BƯỚC 1: CHUYỂN ĐỔI DỮ LIỆU*/
        // Nếu số giây = -1 tức là đã chạy ngược hết số giây, lúc này:
        //  - giảm số phút xuống 1 đơn vị
        //  - thiết lập số giây lại 59
        if (s === -1) {
            m -= 1;
            s = 59;
        }

        // Nếu số phút = -1 tức là đã chạy ngược hết số phút, lúc này:
        //  - giảm số giờ xuống 1 đơn vị
        //  - thiết lập số phút lại 59
        if (m === -1) {
            h -= 1;
            m = 59;
        }

        // Nếu số giờ = -1 tức là đã hết giờ, lúc này:
        //  - Dừng chương trình
        if (h == -1) {
            clearTimeout(timeout);
            alert('Time Out');
            checkValueFinish();
            DisplayLoadingIcon();
            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
            xoa.click();
            return false;
        }

        /*BƯỚC 1: HIỂN THỊ ĐỒNG HỒ*/
        document.getElementById('h').innerText = h.toString();
        document.getElementById('m').innerText = m.toString();
        document.getElementById('s').innerText = s.toString();

        /*BƯỚC 1: GIẢM PHÚT XUỐNG 1 GIÂY VÀ GỌI LẠI SAU 1 GIÂY */
        timeout = setTimeout(function () {
            s--;
            start();
        }, 1000);

        /*Ẩn Back*/
        document.getElementById("check_back").style.display = 'none';
    }

    function stop() {
        clearTimeout(timeout);
    }
    //func chọn file uploiad
    function myChooseFile(id) {
        if (id == 1) {
            document.getElementById("<%=FileUpload1.ClientID%>").click();
            //alert("a");
        } else if (id == 2) {
            document.getElementById("<%=FileUpload2.ClientID%>").click();
        } else if (id == 3) {
            document.getElementById("<%=FileUpload3.ClientID%>").click();
        } else if (id == 4) {
            document.getElementById("<%=FileUpload4.ClientID%>").click();
        }

    }
    function showPreview1(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#file_1').attr('src', e.target.result);
                $('#file_1').css('display', 'block');
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }
    function showPreview2(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#file_2').attr('src', e.target.result);
                $('#file_2').css('display', 'block');
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }
    function showPreview3(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#file_3').attr('src', e.target.result);
                $('#file_3').css('display', 'block');
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }
    function showPreview4(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#file_4').attr('src', e.target.result);
                $('#file_4').css('display', 'block');
            }
            filerdr.readAsDataURL(input.files[0]);
        }
    }
</script>
<body>
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
    <form id="form1" runat="server">
        <input type="text" id="txtPhutHiden" runat="server" hidden="hidden" />
        <input type="text" id="txtTitle" runat="server" hidden="hidden" />
        <a href="#" hidden="hidden" runat="server" id="btnCheckCookie" onserverclick="btnCheckCookie_ServerClick">check</a>
        <a href="#" hidden="hidden" runat="server" id="btnClose" onserverclick="btnClose_ServerClick">Close</a>
        <asp:ScriptManager runat="server" />
        <a runat="server" class="button pink--md serif round glass btn__pre" id="check_back" onserverclick="check_back_ServerClick">Back</a>
        <div class="main__tracnghiem" id="popupBlur">
            <a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Start</a>
            <div class="popupPoint" id="popupPoint">
                <div class="popup__content">
                    <div class="popup__heading">
                        <div class="popup__point">
                            <div class="point">
                                <%--<span id="pointStart">0</span>/<span id="pointFinish">32</span>&nbsp;câu đúng--%>
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
                <div style="display: none">
                    <input type="text" value="" id="txtIDQuestion1" runat="server" placeholder="id c^^au hỏi" />
                    <input type="text" value="" id="txtIDQuestion2" runat="server" placeholder="id c^^au hỏi" />
                    <input type="text" value="" id="txtIDQuestion3" runat="server" placeholder="id c^^au hỏi" />
                    <input type="text" value="" id="txtIDQuestion4" runat="server" placeholder="id c^^au hỏi" />
                </div>
                <div class="container">
                    <div class="tracnghiem__heading-box">
                        <div class="content__heading">
                            <h3 class="tracnghiem__heading" id="title"></h3>
                        </div>
                    </div>
                    <asp:Repeater runat="server" ID="rpCauHoiDetals">
                        <ItemTemplate>
                            <fieldset class="tracnghiem__content">
                                <legend class="tracnghiem__legend">Part <%=STT++ %></legend>
                                <div class="tracnghiem__content-box">
                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %></h4>
                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden />
                                    <%-- <div class="tracnghiem__answer">
                                        <div class="tracnghiem__box">
                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                <ItemTemplate>
                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                    <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>--%>
                                </div>
                                Answer:
                                    <a href="javascript:void(0)" onclick="myChooseFile(<%#Container.ItemIndex+1 %>)" class="btn">Choose file</a>
                                <audio controls="controls" id="file_<%#Container.ItemIndex+1 %>" style="display: none">
                                </audio>
                            </fieldset>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="display: none">
                        <asp:FileUpload type="file" ID="FileUpload1" runat="server" accept=".mp3" onchange="showPreview1(this)" />
                        <asp:FileUpload type="file" ID="FileUpload2" runat="server" accept=".mp3" onchange="showPreview2(this)" />
                        <asp:FileUpload type="file" ID="FileUpload3" runat="server" accept=".mp3" onchange="showPreview3(this)" />
                        <asp:FileUpload type="file" ID="FileUpload4" runat="server" accept=".mp3" onchange="showPreview4(this)" />
                    </div>
                    <div class="tracnghiem__button">
                        <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="return confirmDel()" class="button pink__finish serif round glass popup__finish">Finish</a>
                        <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                        <br />
                    </div>
                </div>
                <div class="ten-countdown">
                    <%-- <strong>Thời Gian:
                    <br />
                    </strong>--%>
                    <input type="text" id="h_val" placeholder="Giờ" value="" hidden="hidden" />
                    <input type="text" id="m_val" placeholder="Phút" value="" hidden="hidden" />
                    <input type="text" id="s_val" placeholder="Giây" value="" hidden="hidden" />
                    <%--<input type="button" value="Start" onclick="start()" />
                <input type="button" value="Stop" onclick="stop()" />--%>
                    <div>
                        <span id="h" hidden="hidden">Giờ</span>
                        <span id="m">Minutes</span> :
                        <span id="s">Second</span>
                    </div>
                </div>
            </div>
            <%--<div id="ten-countdown"></div>--%>
        </div>
    </form>
</body>
<script src="/js/jquery-3.5.1.min.js"></script>
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
