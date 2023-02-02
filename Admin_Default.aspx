<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function myActive(id) {
            document.getElementById(id).classList.add("active");
        }
        function getChuongHoc(id) {
            document.getElementById('<%=txtChuong_ID.ClientID%>').value = "";
            document.getElementById('<%=txtMon_Id.ClientID%>').value = id;
            document.getElementById('<%=btnGetChuongHoc.ClientID%>').click();
            document.getElementById(id).classList.add("active");
        }
        function getBaiHoc(id) {
            document.getElementById('<%=txtChuong_ID.ClientID%>').value = id;
            document.getElementById('<%=btnGetBaiHoc.ClientID%>').click();
        }
        var ID_khoi;
        var ID_Mon;
        var ID_Chuong;
        //var ID_BaiHoc;
        //func thêm chương cho button Thêm Chương
        function themChuong() {
            // debugger;
            ID_khoi = document.getElementById('<%=txtKhoi_Id.ClientID%>').value;
            ID_Mon = document.getElementById('<%=txtMon_Id.ClientID%>').value;
            if (ID_khoi == "")
                ID_khoi = 0;
            if (ID_Mon == "")
                ID_Mon = 0;
            // alert(ID_khoi + "" + ID_Mon)
            window.location = 'admin-them-chuong-' + ID_khoi + '-' + ID_Mon;
        }
        //func thêm môn học cho khối
        function themMonHoc() {
            ID_khoi = document.getElementById('<%=txtKhoi_Id.ClientID%>').value;
            if (ID_khoi == "")
                ID_khoi = 0;

            window.location = 'admin-them-mon-hoc-' + ID_khoi;
        }
        //func thêm bài học của chương
        function themBaiHoc() {
            ID_Chuong = document.getElementById('<%=txtChuong_ID.ClientID%>').value;
            if (ID_Chuong == "")
                ID_Chuong = 0;

            window.location = 'admin-them-bai-hoc/' + ID_Chuong;
        }
        //func thêm câu hỏi trắc nghiệm cho từng bài học
        function getCauHoiTracNghiem(id) {
            document.getElementById('<%=txtBaiHoc_ID.ClientID%>').value = id;
            ID_khoi = document.getElementById('<%=txtKhoi_Id.ClientID%>').value;
            ID_Mon = document.getElementById('<%=txtMon_Id.ClientID%>').value;
            ID_Chuong = document.getElementById('<%=txtChuong_ID.ClientID%>').value;
            Array.from(document.querySelectorAll('.btnKyNang')).map(x => x.classList.remove('active'));
            document.getElementById("kynang_" + id).classList.add("active");
            //window.location = 'admin-quan-ly-cau-hoi-trac-nghiem-' + ID_khoi + '-' + ID_Mon + '-' + ID_Chuong + '-' + id;
        }


       <%-- function popupShow() {
            document.getElementById('<%=txtMonHoc.ClientID%>').value = "";
            document.getElementById('showPopup').click();
        }--%>
        function popupHide() {
            document.getElementById('btnClosePopup').onclick = function () {
                document.getElementById('btnThemMonBL').style.display = "block";
            };
            document.getElementById('btnClosePopup1').onclick = function () {
                document.getElementById('btnThemChuongBL').style.display = "block";
            };
            document.getElementById('btnClosePopup2').click();
        }
        function popupShow1() {
            document.getElementById('<%=txtChuong.ClientID%>').value = "";
            document.getElementById('showPopup1').click();
        }
        function popupShow2() {
            document.getElementById('<%=txtBaiHoc.ClientID%>').value = "";
            document.getElementById('showPopup2').click();
        }
        //func checknull thêm môn
       <%-- function checkNULLMon() {
            var CityName = document.getElementById('<%= txtMonHoc.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Tên môn học không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }--%>
        //func checknull thêm chương
        function checkNULL() {
            var CityName = document.getElementById('<%= txtChuong.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Tên đề không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
        //func checknull thêm bài học
        function checkNULL2() {
            var CityName = document.getElementById('<%= txtBaiHoc.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Tên kỹ năng không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }

        function confimXoaChuong() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể thay đổi.",
                "warning",
                {
                    buttons: true,
                    successMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnDelChapter.ClientID%>');
                        xoa.click();
                    }
                });
        }
        function confimXoaKyNang() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể thay đổi.",
                "warning",
                {
                    buttons: true,
                    successMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnDelKyNang.ClientID%>');
                        xoa.click();
                    }
                });
        }
        //$(document).ready(function () {
        //    $('.box__note').click(function () {
        //        $('.box__note').toggleClass('note-icon__translate');
        //        $('.note').toggleClass('note__none');
        //    });
        //});

        //$(document).ready(function () {
        //    $('.box__note').click(function () {
        //        $('.sidebar').toggleClass('icon-toggle__none');
        //        $('.app').toggleClass('app__tran');
        //        $('.header').toggleClass('header__tran');
        //        $('.icon-toggle__sidebar').toggleClass('icon__tran');

        //    });
        //});
        $(document).ready(function () {
            $('.icon-toggle__sidebar').click(function () {
                $('.app').toggleClass('padding__unset');


            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        .link__icon {
            position: relative;
        }

        .icon__new {
            background-color: transparent;
            width: 30px;
            height: 30px;
            position: absolute;
            top: -28px;
            right: 13px;
        }

        .new-item {
            width: 35px;
            height: 20px;
            background-color: #fbc531;
            position: absolute;
            z-index: 1;
            top: -28px;
            right: 9px;
            border-top-right-radius: 7px;
            text-align: center;
            color: #fff;
            font-weight: 700;
            font-size: 13px;
        }

            .new-item:before {
                content: "";
                border-width: 10px;
                border-style: solid;
                border-color: #fbc531 transparent #fbc531 transparent;
                position: absolute;
                top: 0;
                left: -11px;
            }

            .new-item:after {
                content: "";
                border-width: 9px;
                border-style: solid;
                border-color: transparent transparent transparent #fbc531;
                position: absolute;
                top: 10px;
                right: -10px;
                z-index: -1 !important;
            }

        .title-h4 {
            margin-top: 6px;
            font-size: 19px;
        }

        .khoi {
            padding: 0.5rem 14.2px;
        }

        .title {
            display: flex;
        }

        .tieude {
            margin: 0;
            margin-top: 15px;
            font-size: 20px;
            padding: 0;
            font-size: 23px;
        }

        .list-monhoc {
            margin-top: 10px;
            margin-left: -25px;
        }

        .img-stt {
            width: 60px;
        }

        .themmoi {
            margin-left: -25px;
            margin-top: 15px;
        }

        .luu-y {
            color: red;
        }

        .title-tieude {
            display: flex;
            justify-content: center;
            font-size: 50px;
            text-transform: uppercase;
        }

        .active {
            background: red !important;
        }


        /*kim - button X close*/
        #main {
            position: relative;
            height: 500px;
        }

        .left, .right, .close {
            position: absolute;
            top: 50%;
        }

        .right {
            right: 0;
        }

        .close {
            position: absolute;
            top: 0;
            right: 0;
            font-size: 1.3rem;
            opacity: 0.8;
            color: red !important;
            padding: 4px;
            text-decoration: none !important;
            border-radius: 4px;
            font-family: monospace;
        }

        .btnClassStudents {
            min-width: 88px;
            margin: 5px;
        }

        .btnSource {
            min-width: 100px;
            font-size: 1.1rem;
            text-transform: capitalize;
            position: relative;
            /*border-radius: 4px !important;*/
            margin-right: 8px;
            padding: 8px 24px 8px 20px;
        }

        .btn.btn-primary {
            border-radius: 4px;
        }
    </style>
    <div class="container" style="display: block">
        <h1 class="title-tieude">Tạo câu hỏi</h1>
        <div class="card card-block">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div style="display: none">
                        <input type="text" name="name" value="" runat="server" id="txtKhoi_Id" placeholder="id khối" />
                        <%--<a href="javascript:void(0)" runat="server" id="btnGetMonHoc" onserverclick="btnGetMonHoc_ServerClick"></a>--%>
                        <input type="text" name="name" value="" runat="server" id="txtMon_Id" placeholder="id môn" />
                        <a href="javascript:void(0)" runat="server" id="btnGetChuongHoc" onserverclick="bntGetChuongHoc_ServerClick"></a>
                        <input type="text" name="name" value="" runat="server" id="txtChuong_ID" placeholder="id chương" />
                        <a href="javascript:void(0)" runat="server" id="btnGetBaiHoc" onserverclick="btnGetBaiHoc_ServerClick"></a>
                        <input type="text" name="name" value="" runat="server" id="txtBaiHoc_ID" placeholder="id bài học" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  Function thêm môn--%>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-1 title">
                            <img src="admin_images/stt.png" alt="" class="img-stt" />
                        </div>
                        <div class="col-lg-11">
                            <h3 class="tieude">Môn học</h3>
                            <em><em class="luu-y">Lưu ý:</em>Chọn môn học trước khi tạo câu hỏi.</em>
                            <div class="col-lg-3 col-md-4 col-sm-6 col-12 list-monhoc">
                                <asp:Repeater runat="server" ID="rpMonHoc">
                                    <ItemTemplate>
                                        <div class="candy btn btnSource btn-primary" id="<%#Eval("monhoc_id") %>" onclick="getChuongHoc(this.id)">
                                            <%#Eval("monhoc_name") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--Xong việc thêm môn --%>
            <hr />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-1 title">
                            <img src="admin_images/stt2.png" alt="" class="img-stt" />
                        </div>
                        <div class="col-lg-11">
                            <h3 class="tieude">Đề</h3>
                            <em><em class="luu-y">Lưu ý:</em>Chọn đề trước khi tạo câu hỏi.</em>
                            <div class="col-lg-3 col-md-4 col-sm-6 col-12 list-monhoc">
                                <asp:Repeater runat="server" ID="rpChuong">
                                    <ItemTemplate>
                                        <div class="candy btn btn-primary btnSource" id="<%#Eval("dethi_id") %>" onclick="getBaiHoc(this.id)">
                                            <%#Eval("dethi_name") %>
                                            <a class="close" href="javascript:void(0)" title="Xóa" onclick="confimXoaChuong()">X</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <a href="javascript:void(0)" id="btnDelChapter" runat="server" onserverclick="btnDelChapter_ServerClick" style="display: none">Xóa chương</a>
                            </div>
                            <br />
                            <div class="col-lg-3 col-md-4 col-sm-6 col-12 themmoi">
                                <button type="button" runat="server" class="btn btn-primary" id="btnThemChuongBL" onclick="popupShow1()">Thêm đề</button>
                                <a href="javascript:void(0)" class="invisible" runat="server" id="btnThemChuong" onserverclick="btnThemChuong_ServerClick">Thêm chương</a>
                            </div>
                        </div>
                        <button id="showPopup1" type="button" class="btn btn-info btn-lg" style="display: none;" data-toggle="modal" data-target="#myModal1">Open Modal</button>
                        <!-- Modal -->
                        <div id="myModal1" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button id="btnClosePopup1" type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Thêm đề</h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group row">
                                                    <label class="col-sm-3 form-control-label text-xs-right  title-h4">Tên đề:</label>
                                                    <div class="col-sm-9">
                                                        <input type="text" class="form-control" runat="server" id="txtChuong" value="" autocomplete="off" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnLuuChuong" runat="server" ClientIDMode="Static" Text="Thêm" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuuChuong_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-1 title">
                            <img src="admin_images/stt3.png" alt="" class="img-stt" />
                        </div>
                        <div class="col-lg-11">
                            <h3 class="tieude">Kỹ năng</h3>
                            <em><em class="luu-y">Lưu ý:</em>Chọn kỹ năng trước khi tạo câu hỏi.</em>
                            <div class="col-lg-3 col-md-4 col-sm-6 col-12 list-monhoc">
                                <asp:Repeater runat="server" ID="rpBaiHoc">
                                    <ItemTemplate>
                                        <div class="btn btn-primary btnSource btnKyNang" id="kynang_<%#Eval("kynang_id") %>" onclick="getCauHoiTracNghiem(<%#Eval("kynang_id") %>)">
                                            <%#Eval("kynang_name") %>
                                            <a class="close" href="javascript:void(0)" title="Xóa" onclick="confimXoaKyNang()">X</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <a href="javascript:void(0)" id="btnDelKyNang" runat="server" onserverclick="btnDelLesson_ServerClick" style="display: none">Xóa kỹ năng</a>

                            </div>
                            <br />
                            <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnThemBaiHoc" onserverclick="btnThemBaiHoc_ServerClick">Thêm kỹ năng</a>
                            <div>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoReading" onserverclick="btnTaoReading_ServerClick">Tạo câu hỏi Reading</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoListening" onserverclick="btnTaoListening_ServerClick">Tạo câu hỏi Listening</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoSpeaking" onserverclick="btnTaoSpeaking_ServerClick">Tạo câu hỏi Speaking</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoWriting" onserverclick="btnTaoWriting_ServerClick">Tạo câu hỏi Writing</a>
                            </div>
                            <%--<div id="div_Button_A2" runat="server">
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoReadingA2" onserverclick="btnTaoReading_ServerClick">Tạo câu hỏi Reading</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoListeningA2" onserverclick="btnTaoListening_ServerClick">Tạo câu hỏi Listening</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoSpeakingA2" onserverclick="btnTaoSpeaking_ServerClick">Tạo câu hỏi Speaking</a>
                                <a href="javascript:void(0)" class="btn btn-primary" runat="server" id="btnTaoWriting" onserverclick="btnTaoWriting_ServerClick">Tạo câu hỏi Writing</a>
                            </div>--%>
                        </div>
                    </div>
                    <button id="showPopup2" type="button" class="btn btn-info btn-lg" style="display: none;" data-toggle="modal" data-target="#myModal2">Open Modal</button>
                    <!-- Modal -->
                    <div id="myModal2" class="modal fade" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button id="btnClosePopup2" type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Thêm kỹ năng</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group row">
                                                <label class="col-sm-3 form-control-label text-xs-right title-h4">Tên kỹ năng:</label>
                                                <div class="col-sm-9">
                                                    <input type="text" class="form-control" runat="server" id="txtBaiHoc" value="" autocomplete="off" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="modal-footer">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnLuuBaiHoc" runat="server" CssClass="btn btn-primary" ClientIDMode="Static" Text="Thêm" OnClientClick="return checkNULL2()" OnClick="btnLuuBaiHoc_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

