<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_QuanLyCauHoiSpeaking.aspx.cs" Inherits="admin_page_module_function_module_TracNghiem_Test_Speaking" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator</title>
    <link rel="stylesheet" href="/admin_css/vendor.css" />
    <link rel="stylesheet" href="/admin_css/app-blue.css" />
    <link href="/admin_css/admin_style.css" rel="stylesheet" />
    <link href="/admin_css/datepicker.min.css" rel="stylesheet" />
    <script src="/admin_js/sweetalert.min.js"></script>
    <script src="/admin_js/js_base/jquery-1.9.1.js"></script>
</head>
<body>
    <style>
        .header_header {
            height: 70px;
            border-bottom: 1px solid gray;
        }

        .radio_text_type {
            margin-right: 3px;
            margin-left: 20px;
        }

        .question_radio {
            margin-top: 10px;
            font-size: 16px;
            display: -webkit-inline-box;
        }

        .file {
            margin-top: 40px;
        }

        .title_h2 {
            font-size: 19px;
            margin-bottom: 0;
        }

        .title_h2_c {
            margin-top: 10px;
            font-size: 19px;
            margin-bottom: 0;
        }

        .title_them_question {
            text-align: center;
        }

        .button_quaylai them_chuong {
            float: right;
        }

        .button_quaylai {
            float: right;
        }

        .tracnghiem-answer__image {
            max-width: 100%;
            height: 217px;
            width: auto;
            display: block;
            margin: 0 auto;
            margin-bottom: 21px;
            border-radius: 10px;
            border: 1px solid #ccc;
            box-shadow: 0 7px 10px rgba(0,0,0,0.3);
        }

        .content_image {
            white-space: break-spaces;
        }

        .invisible {
            position: absolute;
        }

        .btnFunction {
            margin-right: 8px;
        }

        .widthContent {
            /*max-width: 980px;
            display: flex;*/
        }

        #ctl10 {
            position: relative;
        }

        .textContent {
            /*position: absolute;*/
            /* bottom: -28px; */
            /*    top: -48px;
            left: 16px;*/
            font-size: 1.2rem;
            color: red;
        }

        #edtContent_DesignIFrame {
            width: 400px !important;
            height: 377px !important;
        }

        .title_h2_c {
            margin: 12px 0;
        }

        .marginFooter {
            margin: 8px 15px;
            max-width: 980px;
        }

        .title_h2_c-active {
            color: red;
            font-size: 1.6rem;
            font-weight: 500;
        }

        .btn-primary:focus {
            outline: none;
        }

        /*css drop file*/
        .drop-zone {
            max-width: 800px;
            height: 500px;
            padding: 25px;
            display: flex;
            align-items: center;
            justify-content: center;
            text-align: center;
            font-family: "Quicksand", sans-serif;
            font-weight: 500;
            font-size: 20px;
            cursor: pointer;
            color: #cccccc;
            border: 4px dashed #009578;
            border-radius: 10px;
            margin: auto
        }

        .drop-zone--over {
            border-style: solid;
        }

        .drop-zone__input {
            display: none;
        }

        .drop-zone__thumb {
            width: 100%;
            height: 100%;
            border-radius: 10px;
            overflow: hidden;
            background-color: #cccccc;
            background-size: cover;
            position: relative;
        }

            .drop-zone__thumb::after {
                content: attr(data-label);
                position: absolute;
                bottom: 0;
                left: 0;
                width: 100%;
                padding: 5px 0;
                color: #ffffff;
                background: rgba(0, 0, 0, 0.75);
                font-size: 14px;
                text-align: center;
            }

        .mt-2 {
            text-align: center !important;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smScriptManager" runat="server"></asp:ScriptManager>
        <script>
            function btnChiTiet() {
                document.getElementById('<%=btnChiTiet.ClientID%>').click();
            }
            function setForm() {
                var a = document.querySelector('input[name="kieucauhoi"]:checked').value;
                document.getElementById("<%=txtKieuCauHoi.ClientID%>").value = a;
                if (a == 2) {
                    document.getElementById("dvnoidungcauhoi").style.display = "none";
                }
                else {
                    document.getElementById("dvnoidungcauhoi").style.display = "block";
                }
                console.log(a);
            }
            $(document).ready(function () {
                setForm();
                getquestion();
            });
            function getquestion() {
                var a = document.querySelector('input[name="loaicauhoi"]:checked').value;
                document.getElementById("<%=txtLoaiCauHoi.ClientID%>").value = a;
                console.log(a);
            }
            function setCheckedDCH() {
                var value = document.getElementById("<%=txtKieuCauHoi.ClientID%>").value;
                $("input[name=kieucauhoi][value=" + value + "]").attr('checked', 'checked');
                console.log(value)
            }
            function setChecked() {
                var value = document.getElementById("<%=txtLoaiCauHoi.ClientID%>").value;
                $("input[name=loaicauhoi][value=" + value + "]").attr('checked', 'checked');
                console.log(value)
            }
            function confirmDel() {
                swal("Bạn có thực sự muốn xóa?",
                    "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                    "warning",
                    {
                        buttons: true,
                        dangerMode: true
                    }).then(function (value) {
                        if (value == true) {
                            var xoa = document.getElementById('<%=btnXoa.ClientID%>');
                            xoa.click();
                        }
                    });
            }
            function clickavatar1() {
                $("#up1 input[type=file]").click();
            }
            function showPreview1(input) {

                if (input.files && input.files[0]) {

                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {

                        $('#imgPreview1').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);

                }
            }
            function showImg1_1(img) {
                $('#imgPreview1').attr('src', img);
                $('#imgPreview2').attr('src', img);
                $("input[type=checkbox]").css("display", "block");
            }
            function lockImg() {
                $('#imgPreview1').css("display", "none");
                $('#audio').css("display", "block");
            }
            function lockAudio() {
                $('#audio').css("display", "none");
                $('#imgPreview1').css("display", "block");
            }
            function lockDCH() {
                $('#DangCauHoi_').css("position", "absolute");
                $('#DangCauHoi_').css("top", "45%");
                $('#DangCauHoi_').css("left", "0");
            }
        </script>
        <div class="card card-block">
            <div class="form-group row">
                <asp:UpdatePanel ID="udButton2" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-8">
                            <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary btnFunction" OnClick="btnChiTiet_Click" />
                            <input type="submit" class="btn btn-primary Xoa btnFunction" value="Xóa" onclick="confirmDel()" />
                            <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click"  />
                            <asp:Button ID="btnTaiLaiTrang" Text="Tải lại trang" CssClass="btn btn-primary btnFunction" runat="server" OnClick="btnTaiLaiTrang_Click" />
                        </div>
                        <div class="col-sm-4" style="text-align: right">
                            <%--<a href="/admin-home" class="btn btn-primary ">Quay lại</a>--%>
                            <asp:Button ID="btnQuayLai" Text="Quay lại" CssClass="btn btn-primary" runat="server" OnClick="btnQuayLai_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group table-responsive">
                                <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="englishquestion_id">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="7%">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                            <DataItemTemplate>
                                                <%#Container.ItemIndex+1 %>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Bài học" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="englishquestion_content" HeaderStyle-HorizontalAlign="Center" Width="30%" Settings-AllowEllipsisInText="true">
                                            <DataItemTemplate>
                                                <div>
                                                    <%#Eval("englishquestion_content") %>
                                                </div>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Giáo viên" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    </Columns>
                                    <ClientSideEvents RowDblClick="btnChiTiet" />
                                    <SettingsSearchPanel Visible="true" />
                                    <SettingsBehavior AllowFocusedRow="true" />
                                    <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                    <SettingsLoadingPanel Text="Đang tải..." />
                                    <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                                </dx:ASPxGridView>
                            </div>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                    <%--<asp:GridView ID="grvList" runat="server" OnSelectedIndexChanged="grvList_SelectedIndexChanged">
                    </asp:GridView>--%>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-12">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                           <div style="display: none">
                            <div style="display: none">
                                <input type="text" id="txtKieuCauHoi" runat="server" />
                            </div>
                            <div class="col-sm-12">
                                <h1 class="title_them_question">Thêm câu hỏi Speaking</h1>
                            </div>
                            <%-- <input type="text" value="" runat="server" id="txtDangCauHoi" placeholder="Dạng câu hỏi" />--%>
                            <input hidden="hidden" type="text" value="" runat="server" id="txtLoaiCauHoi" placeholder="loại câu hỏi" />
                            <div class="row">
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 widthContent">
                    <div class="drop-zone">
                        <span class="drop-zone__prompt">Drop file here or click to upload</span>
                         <asp:FileUpload type="file" name="myFile" id="FileUpload1" runat="server" class="drop-zone__input" accept="image/png, image/jpeg,.mp3,audio,image/jpg"/>
                    </div>
                    <div class="row mt-2">
                        <div class="col-sm-7" style="width: 100%";>
                            <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuu_Click" />
                            <%--<asp:Button ID="btnLuuvaThemmoi" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuvaThemmoi_Click1" />--%>
                        </div>
                    </div>
                </div>
            </div>

            <%-- <div class="row mt-2">
                <div class="col-sm-5">
                </div>
                <div class="col-sm-7">
                    <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuu_Click" />
                    <asp:Button ID="btnLuuvaThemmoi" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuvaThemmoi_Click1" />
                </div>
            </div>--%>
        </div>
    </form>
</body>
<script src="./src/main.js"></script>
<script>
    document.querySelectorAll(".drop-zone__input").forEach((inputElement) => {
        const dropZoneElement = inputElement.closest(".drop-zone");

        dropZoneElement.addEventListener("click", (e) => {
            inputElement.click();
        });

        inputElement.addEventListener("change", (e) => {
            if (inputElement.files.length) {
                updateThumbnail(dropZoneElement, inputElement.files[0]);
            }
        });

        dropZoneElement.addEventListener("dragover", (e) => {
            e.preventDefault();
            dropZoneElement.classList.add("drop-zone--over");
        });

        ["dragleave", "dragend"].forEach((type) => {
            dropZoneElement.addEventListener(type, (e) => {
                dropZoneElement.classList.remove("drop-zone--over");
            });
        });

        dropZoneElement.addEventListener("drop", (e) => {
            e.preventDefault();

            if (e.dataTransfer.files.length) {
                inputElement.files = e.dataTransfer.files;
                updateThumbnail(dropZoneElement, e.dataTransfer.files[0]);
            }

            dropZoneElement.classList.remove("drop-zone--over");
        });
    });

    /**
     * Updates the thumbnail on a drop zone element.
     *
     * @param {HTMLElement} dropZoneElement
     * @param {File} file
     */
    function updateThumbnail(dropZoneElement, file) {
        let thumbnailElement = dropZoneElement.querySelector(".drop-zone__thumb");

        // First time - remove the prompt
        if (dropZoneElement.querySelector(".drop-zone__prompt")) {
            dropZoneElement.querySelector(".drop-zone__prompt").remove();
        }

        // First time - there is no thumbnail element, so lets create it
        if (!thumbnailElement) {
            thumbnailElement = document.createElement("div");
            thumbnailElement.classList.add("drop-zone__thumb");
            dropZoneElement.appendChild(thumbnailElement);
        }

        thumbnailElement.dataset.label = file.name;

        // Show thumbnail for image files
        if (file.type.startsWith("image/")) {
            const reader = new FileReader();

            reader.readAsDataURL(file);
            reader.onload = () => {
                thumbnailElement.style.backgroundImage = `url('${reader.result}')`;
            };
        } else {
            thumbnailElement.style.backgroundImage = null;
        }
    }

</script>
</html>
