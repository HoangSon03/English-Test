<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_TaoCauHoi_Reading_A2.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoi_Reading_A2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator</title>
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link href="../../../admin_css/app-blue.css" rel="stylesheet" />
    <link href="../../../admin_css/vendor.css" rel="stylesheet" />
    <link href="../../../admin_css/admin_style.css" rel="stylesheet" />
    <link href="../../../admin_css/datepicker.min.css" rel="stylesheet" />
    <script src="../../../admin_js/js_base/jquery-1.9.1.js"></script>
</head>
<body>
    <script>
        function myPart1(part) {
            document.getElementById('form_part3').style.display = "none";
            document.getElementById('form_tracnghiem').style.display = "block";
            document.getElementById('form_tuluan').style.display = "none";
            document.getElementById('<%=txtPart.ClientID%>').value = part;
        }
        function myPart2(part) {
            document.getElementById('form_part3').style.display = "block";
            document.getElementById('form_tracnghiem').style.display = "none";
            document.getElementById('form_tuluan').style.display = "none";
            document.getElementById('<%=txtPart.ClientID%>').value = part;
        }
        function myPart3(part) {
            document.getElementById('form_part3').style.display = "none";
            document.getElementById('form_tracnghiem').style.display = "none";
            document.getElementById('form_tuluan').style.display = "block";
            document.getElementById('<%=txtPart.ClientID%>').value = part;
        }
        //function myPart4() {
        //    document.getElementById('form_part3').style.display = "none";
        //    document.getElementById('form_tracnghiem').style.display = "none";
        //    document.getElementById('form_tuluan').style.display = "block";
        //}
        //function myPart5() {
        //    document.getElementById('form_part3').style.display = "block";
        //    document.getElementById('form_tracnghiem').style.display = "none";
        //    document.getElementById('form_tuluan').style.display = "none";
        //}
        //function myPart6() {
        //    document.getElementById('form_part3').style.display = "none";
        //    document.getElementById('form_tracnghiem').style.display = "none";
        //    document.getElementById('form_tuluan').style.display = "block";
        //}
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
        }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <div class="card card-block">
            <div class="row">
                <asp:UpdatePanel ID="udButton2" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-8">
                            <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary btnFunction" OnClick="btnChiTiet_Click" />
                            <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                            <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                            <asp:Button ID="btnTaiLaiTrang" Text="Tải lại trang" CssClass="btn btn-primary btnFunction" runat="server" OnClick="btnTaiLaiTrang_Click" />
                        </div>
                        <div class="col-sm-4" style="text-align: right">
                            <a href="/admin-home" class="btn btn-primary ">Quay lại</a>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                        <dx:GridViewDataColumn Caption="Kỹ năng" FieldName="kynang_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="englishquestion_content" HeaderStyle-HorizontalAlign="Center" Width="30%" Settings-AllowEllipsisInText="true">
                                            <DataItemTemplate>
                                                <div>
                                                    <%#Eval("englishquestion_content") %>
                                                </div>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Giáo viên" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    </Columns>
                                    <%--<ClientSideEvents RowDblClick="btnChiTiet" />--%>
                                    <SettingsSearchPanel Visible="true" />
                                    <SettingsBehavior AllowFocusedRow="true" />
                                    <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                    <SettingsLoadingPanel Text="Đang tải..." />
                                    <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                                </dx:ASPxGridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <h1 class="title_them_question">Thêm câu hỏi</h1>
                </div>
                <%--part 1 là nhập kiểu trắc nghiệm
            part 2, part 4, part 6 nhập img + gõ đáp án đúng
            part 3, part 5 nhập img + form trắc nghiệm--%>
                <div class="col-sm-12" id="div_Part">
                    <a href="javascript:void(0)" class="btn btn-primary" onclick="myPart1('1')">Part 1</a>
                    <a href="javascript:void(0)" class="btn btn-primary" onclick="myPart2('2')">Part 2</a>
                    <a href="javascript:void(0)" class="btn btn-primary" onclick="myPart2('3')">Part 3</a>
                    <a href="javascript:void(0)" class="btn btn-primary" onclick="myPart2('4')">Part 4</a>
                    <a href="javascript:void(0)" class="btn btn-primary" onclick="myPart3('5')">Part 5</a>
                </div>
                <div class="row">
                    <div class="col-sm-12 widthContent" id="form_tracnghiem" style="display: none">
                        <span class="textContent">Lưu ý: Bạn cần nhập nội dung đáp án theo thứ tự A,B,...</span>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="col-sm-4">
                                    <div id="dvnoidungcauhoi">
                                        <h2 class="title_h2_c">Nội dung câu hỏi:</h2>
                                        <dx:ASPxHtmlEditor ID="edtContent" ClientInstanceName="edtContent" runat="server" Width="100%" Height="350px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>
                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                        <%--<textarea runat="server" id="txtcontent" name="w3review" rows="2" class="form-control"></textarea>--%>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu A:
                    <input type="checkbox" id="DaA" runat="server" />
                                            </h2>
                                            <dx:ASPxHtmlEditor ID="edtDapAnA" ClientInstanceName="edtDapAnA" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>

                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu B:
                    <input type="checkbox" id="DaB" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDapAnB" ClientInstanceName="edtDapAnB" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu C:
                    <input type="checkbox" id="DaC" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDapAnC" ClientInstanceName="edtDapAnC" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu D:
                    <input type="checkbox" id="DaD" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDapAnD" ClientInstanceName="edtDapAnD" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row mt-2">
                            <div class="col-sm-5">
                            </div>
                            <div class="col-sm-7">
                                <asp:Button ID="btnLuuCauHoi" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuuCauHoi_Click" />
                                <asp:Button ID="btnLuuVaThemmoi" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuVaThemmoi_Click" />
                            </div>
                        </div>
                    </div>

                    <%--nhập câu hỏi + hình ảnh--%>
                    <div class="col-sm-12 widthContent" id="form_part3" style="display: none">
                        <div class="col-sm-12">
                            <h2 class="title_h2_c">Nội dung đề:</h2>
                            <dx:ASPxHtmlEditor ID="edtNoiDungDe" ClientInstanceName="edtNoiDungDe" runat="server" Width="100%" Height="350px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                <Toolbars>
                                    <dx:HtmlEditorToolbar>
                                        <Items>
                                            <dx:ToolbarFontSizeEdit>
                                                <Items>
                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                </Items>
                                            </dx:ToolbarFontSizeEdit>
                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                            <dx:ToolbarItalicButton />
                                            <dx:ToolbarUnderlineButton />
                                            <dx:ToolbarStrikethroughButton />
                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                            <dx:ToolbarJustifyCenterButton />
                                            <dx:ToolbarJustifyRightButton />
                                            <dx:ToolbarJustifyFullButton />
                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                            <dx:ToolbarFontColorButton />
                                        </Items>
                                    </dx:HtmlEditorToolbar>
                                </Toolbars>
                            </dx:ASPxHtmlEditor>
                        </div>
                        <span class="textContent">Lưu ý: Bạn cần nhập nội dung đáp án theo thứ tự A,B,...</span>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="col-sm-4">
                                    <div>
                                        <h2 class="title_h2_c">Nội dung câu hỏi:</h2>
                                        <dx:ASPxHtmlEditor ID="edtContentCauHoi" ClientInstanceName="edtContentCauHoi" runat="server" Width="100%" Height="350px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>
                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                        <%--<textarea runat="server" id="txtcontent" name="w3review" rows="2" class="form-control"></textarea>--%>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu A:
                    <input type="checkbox" id="ckDA_A" runat="server" />
                                            </h2>
                                            <dx:ASPxHtmlEditor ID="edtDA_A" ClientInstanceName="edtDA_A" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>

                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu B:
                    <input type="checkbox" id="ckDA_B" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDA_B" ClientInstanceName="edtDA_B" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu C:
                    <input type="checkbox" id="ckDA_C" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDA_C" ClientInstanceName="edtDA_C" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                        <div class="col-sm-6">
                                            <h2 class="title_h2_c">Câu D:
                    <input type="checkbox" id="ckDA_D" runat="server" /></h2>
                                            <dx:ASPxHtmlEditor ID="edtDA_D" ClientInstanceName="edtDA_D" runat="server" Width="100%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                                <SettingsHtmlEditing EnablePasteOptions="true" />
                                                <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                                <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                                <Toolbars>
                                                    <dx:HtmlEditorToolbar>
                                                        <Items>
                                                            <dx:ToolbarFontSizeEdit>
                                                                <Items>
                                                                    <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                    <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                                </Items>
                                                            </dx:ToolbarFontSizeEdit>
                                                            <dx:ToolbarBoldButton BeginGroup="True" />
                                                            <dx:ToolbarItalicButton />
                                                            <dx:ToolbarUnderlineButton />
                                                            <dx:ToolbarStrikethroughButton />
                                                            <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                            <dx:ToolbarJustifyCenterButton />
                                                            <dx:ToolbarJustifyRightButton />
                                                            <dx:ToolbarJustifyFullButton />
                                                            <dx:ToolbarBackColorButton BeginGroup="True" />
                                                            <dx:ToolbarFontColorButton />
                                                        </Items>
                                                    </dx:HtmlEditorToolbar>
                                                </Toolbars>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row mt-2">
                            <div class="col-sm-5">
                                <input type="text" id="txtPart" runat="server" />
                            </div>
                            <div class="col-sm-7">
                                <asp:Button ID="btnLuuKieu2" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuuKieu2_Click" />
                                <asp:Button ID="btnLuuVaThemMoiKieu2" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuVaThemMoiKieu2_Click" />
                            </div>
                        </div>
                    </div>
                    <%--nhập câu hỏi part--%>
                    <div class="col-sm-12 widthContent" id="form_tuluan" style="display: none">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="col-sm-6">
                                    <h2 class="title_h2_c">Nội dung câu hỏi:</h2>
                                    <dx:ASPxHtmlEditor ID="edtNoiDungPart5" ClientInstanceName="edtNoiDungPart5" runat="server" Width="100%" Height="350px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                        <SettingsHtmlEditing EnablePasteOptions="true" />
                                        <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                        <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                        <Toolbars>
                                            <dx:HtmlEditorToolbar>
                                                <Items>
                                                    <dx:ToolbarFontSizeEdit>
                                                        <Items>
                                                            <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                        </Items>
                                                    </dx:ToolbarFontSizeEdit>
                                                    <dx:ToolbarBoldButton BeginGroup="True" />
                                                    <dx:ToolbarItalicButton />
                                                    <dx:ToolbarUnderlineButton />
                                                    <dx:ToolbarStrikethroughButton />
                                                    <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                    <dx:ToolbarJustifyCenterButton />
                                                    <dx:ToolbarJustifyRightButton />
                                                    <dx:ToolbarJustifyFullButton />
                                                    <dx:ToolbarBackColorButton BeginGroup="True" />
                                                    <dx:ToolbarFontColorButton />
                                                </Items>
                                            </dx:HtmlEditorToolbar>
                                        </Toolbars>
                                    </dx:ASPxHtmlEditor>
                                </div>
                                <div class="col-sm-6">
                                    <table class="table" style="width: 300px">
                                        <thead>
                                            <tr>
                                                <th scope="col">STT câu hỏi</th>
                                                <th scope="col">Đáp án</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau1" runat="server" value="25" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn1" runat="server" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau2" runat="server" value="26" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn2" runat="server" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau3" runat="server" value="27" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn3" runat="server" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau4" runat="server" value="28" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn4" runat="server" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau5" runat="server" value="29" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn5" runat="server" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <input type="text" id="txtCau6" runat="server" value="30" readonly />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDapAn6" runat="server" />
                                                </th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row mt-2">
                            <div class="col-sm-5">
                            </div>
                            <div class="col-sm-7">
                                <asp:Button ID="btnLuuPart5" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuuPart5_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
