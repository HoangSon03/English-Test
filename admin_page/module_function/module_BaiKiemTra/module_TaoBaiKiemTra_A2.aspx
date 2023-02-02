<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoBaiKiemTra_A2.aspx.cs" Inherits="admin_page_module_function_module_BaiKiemTra_module_TaoBaiKiemTra_A2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
     <script type="text/javascript">
        function CloseGridLookup() {
            lkKyNang.ConfirmCurrentSelection();
            lkKyNang.HideDropDown();
            lkKyNang.Focus();
        }

        function None() {
            var clickNone = document.querySelector('.note');
            clickNone.classList.toggle('note__none');
            var clickIcon = document.querySelector('.box__note');
            clickIcon.classList.toggle('note-icon__translate');

        }

     </script>
    <style>
        .header_header {
            /* height: 70px;
            border-bottom: 1px solid gray;*/
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">
    <script>
        function displayButton() {
            document.getElementById("txtLuu").style.display = "block"
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        };
       <%-- function checkNULL() {
            var CityName = document.getElementById('<%= txtTenBai.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Tên bài kiểm tra không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }--%>
        function confirmDel() {
           <%-- var CityName = document.getElementById('<%= txtSoCauHoi.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Vui lòng nhập số câu hỏi có trong bài kiểm tra!', '', 'warning').then(function () { CityName.focus(); });
            }
            else--%>
            {
                swal("Bạn có thực sự muốn tạo bài kiểm tra này?",
                    "Nếu đồng ý, dữ liệu sẽ không được thay đổi",
                    "warning",
                    {
                        buttons: true,
                        successMode: true
                    }).then(function (value) {
                        if (value == true) {
                            document.getElementById('<%=btnLuu.ClientID%>').click();
                        }
                    });
            }
        }
        function play(url) {
            var audio = new Audio(url);
            audio.play();
        }

    </script>

    <div class="card card-block">
        <div class="row header_header">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                   <%-- <div class="col-12">
                        <label class="col-3 col-form-label">Bài kiểm tra:</label>
                        <div class="col-4">
                            <input type="text" class="form-control" id="txtTenBai" runat="server" />
                        </div>
                    </div>--%>
                    <div class="col-12">
                        <label class="col-3 col-form-label">Thời gian làm bài (Phút):</label>
                        <div class="col-4">
                            <input type="text" class="form-control" id="txtThoiGianHoanThanh" runat="server" />
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlDeThi" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlDeThi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <dx:ASPxGridLookup ID="lkKyNang" runat="server" SelectionMode="Multiple" ClientInstanceName="lkKyNang"
                                KeyFieldName="lesson_id" Width="300px" TextFormatString="{0}" MultiTextSeparator=", " Caption="Chương">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                    <dx:GridViewDataColumn  FieldName="lesson_name" Caption="Kỹ năng" Width="250px" />
                                    <dx:GridViewDataColumn FieldName="lesson_id" Settings-AllowAutoFilter="false" Visible="false" />
                                </Columns>
                                <GridViewProperties>
                                    <Templates>
                                        <StatusBar>
                                            <table class="OptionsTable" style="float: right">
                                                <tr>
                                                    <td>
                                                        <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Chọn" ClientSideEvents-Click="CloseGridLookup" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </StatusBar>
                                    </Templates>
                                    <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                    <SettingsPager PageSize="10" EnableAdaptivity="true" />
                                </GridViewProperties>
                            </dx:ASPxGridLookup>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="form-group table-responsive">
                    <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="englishquestion_id" Width="100%">
                        <Columns>
                            <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                <DataItemTemplate>
                                    Câu:&nbsp<%#Container.ItemIndex+1 %>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" Width="2%"></dx:GridViewCommandColumn>
                             <dx:GridViewDataColumn Caption="Kỹ năng" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="englishquestion_content" HeaderStyle-HorizontalAlign="Center" Width="20%">
                                <DataItemTemplate>
                                    <div>
                                        <%#Eval("englishquestion_content") %>
                                    </div>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                        </Columns>
                        <SettingsSearchPanel Visible="true" />
                        <SettingsBehavior AllowFocusedRow="true" />
                        <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                        <SettingsLoadingPanel Text="Đang tải..." />
                        <SettingsPager PageSize="50" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                    </dx:ASPxGridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btnLuu_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>

