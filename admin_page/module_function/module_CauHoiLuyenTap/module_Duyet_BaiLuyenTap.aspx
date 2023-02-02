<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_Duyet_BaiLuyenTap.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_Duyet_BaiLuyenTap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">
      <div class="card card-block">
        <div class="row">
            <div class="col-sm-12">
                <div class="col-sm-10">
                    <asp:Button ID="btnChuyenDuyet" runat="server" CssClass="btn btn-primary" Text="Chuyển duyệt" OnClick="btnChuyenDuyet_Click" />
                    <asp:Button ID="btnXacNhanHoanThanh" runat="server" CssClass="btn btn-primary" Text="Xác nhận hoàn thành" OnClick="btnXacNhanHoanThanh_Click" />
                    <asp:Button ID="btnChiTiet" runat="server" CssClass="btn btn-primary" Text="Xem trước" OnClick="btnChiTiet_ServerClick" />
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="test_id" Width="100%">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                        <DataItemTemplate>
                                            <%#Container.ItemIndex+1 %>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Môn" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Đề" FieldName="dethi_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Kỹ năng" FieldName="baithicate_name" HeaderStyle-HorizontalAlign="Center" Width="25%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="25%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ngày tạo" FieldName="test_createdate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tình trạng" FieldName="test_trangthai" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                </Columns>
                                <SettingsSearchPanel Visible="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                <SettingsLoadingPanel Text="Đang tải..." />
                                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>

