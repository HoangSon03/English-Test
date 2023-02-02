<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_TaoCauHoi_Speaking.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiSpeaking" %>

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
    <form id="form1" runat="server">
        <script>
            function btnChiTiet() {
                document.getElementById('<%=btnChiTiet.ClientID%>').click();
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
        </script>
        <asp:ScriptManager runat="server" />
        <div class="card card-block">
            <div class="col-sm-12">
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
            <div class="row">
                <div class="col-sm-12 widthContent">
                    <div id="dvnoidungcauhoi">
                        <h2 class="title_h2_c">Nội dung câu hỏi:</h2>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <dx:ASPxHtmlEditor ID="edtContent" ClientInstanceName="edtContent" runat="server" Width="60%" Height="250px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="row mt-2">
                        <div class="col-sm-7" style="width: 100%">
                            <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuu_Click" />
                            <asp:Button ID="btnLuuvaThemmoi" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuvaThemmoi_Click" />
                        </div>
                    </div>
                </div>
                <%--  <div class="form-group">
                <div class="col-6">
                    <span>Hình ảnh: </span>
                    <div id="up1" class="">
                        <asp:FileUpload CssClass="hidden-xs-up" ID="FileUpload1" runat="server" onchange="showPreview1(this)" accept=".png,.jpg,.mp3" />
                        <button type="button" class="btn-chang" onclick="clickavatar1()">
                            <img id="imgPreview1" src="/admin_images/up-img.png" style="max-width: 100%;" />
                        </button>
                    </div>
                </div>
                <asp:Button ID="btnLuuPart3" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuuPart3_Click" />
            </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
