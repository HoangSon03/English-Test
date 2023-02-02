<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoCauHoiLuyenTap_Version2.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiLuyenTap_Version2" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <%-- <script>
        function checkNULLBai() {
            var CityName = document.getElementById('<%= txtTenBai.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Tên bài học không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="card card-block">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row header_header">
                    <%-- <div class="col-12">
                        <label class="col-2 col-form-label">&nbsp;&nbsp;&nbsp;Link video:</label>
                        <div class="col-8">
                            <input type="text" class="form-control" id="txtLink" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="col-12">
                        <label class="col-2 col-form-label">&nbsp;&nbsp;&nbsp;Tên bài:</label>
                        <div class="col-8">
                            <input type="text" class="form-control" id="txtTenBai" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />--%>
                    <div class="col-sm-12">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlDe" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlDe_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlKyNang" runat="server" CssClass="btn btn-primary" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div id="divTracNghiem" runat="server">
                        <%--<div class="col-12">
                            <label class="col-3 col-form-label">I) Phần trắc nghiệm:</label>
                        </div>--%>
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="englishquestion_id" Width="100%">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" Width="2%"></dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="2%">
                                        <DataItemTemplate>
                                            <%#Container.ItemIndex+1 %>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Kỹ năng" FieldName="kynang_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Part" FieldName="englishquestion_part" HeaderStyle-HorizontalAlign="Center" Width="5%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="question_content" HeaderStyle-HorizontalAlign="Center" Width="50%">
                                        <DataItemTemplate>
                                            <div>
                                                <%#Eval("question_content") %>
                                            </div>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsSearchPanel Visible="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                <SettingsLoadingPanel Text="Đang tải..." />
                                <SettingsPager PageSize="15" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <asp:Button Text="Tạo bài luyện tập" CssClass="btn btn-primary" runat="server" ID="btnLuu" OnClick="btnLuu_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

