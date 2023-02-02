<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoBaiKiemTra.aspx.cs" Inherits="admin_page_module_function_module_TaoBaiKiemTra_module_TaoBaiKiemTra" %>


<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script type="text/javascript">
        function CloseGridLookup() {
            lkChuong.ConfirmCurrentSelection();
            lkChuong.HideDropDown();
            lkChuong.Focus();
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
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
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
        function checkNULL() {
            var CityName = document.getElementById('<%= txtTenBai.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Tên bài kiểm tra không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
        function confirmDel() {
            document.getElementById('<%=btnLuu.ClientID%>').click();
           <%-- var CityName = document.getElementById('<%= txtSoCauHoi.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Vui lòng nhập số câu hỏi có trong bài kiểm tra!', '', 'warning').then(function () { CityName.focus(); });
            }
            else {
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
            }--%>
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
                    <div class="col-12">
                        <label class="col-3 col-form-label">Bài kiểm tra:</label>
                        <div class="col-4">
                            <input type="text" class="form-control" id="txtTenBai" runat="server" />
                        </div>
                    </div>
                    <div class="col-12">
                        <label class="col-3 col-form-label">Thời gian làm bài (Phút):</label>
                        <div class="col-4">
                            <input type="text" class="form-control" id="txtThoiGianHoanThanh" runat="server" />
                        </div>
                    </div>
                    <div class="col-12">
                        <label class="col-3 col-form-label">Số câu hỏi:</label>
                        <div class="col-4">
                            <input type="text" class="form-control" id="txtSoCauHoi" runat="server" placeholder="nhập số câu hỏi" onkeypress="return isNumberKey(event)" />
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList CssClass="btn btn-primary" ID="ddlChuong" OnSelectedIndexChanged="ddlChuong_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList CssClass="btn btn-primary" ID="ddlChude" OnSelectedIndexChanged="ddlChude_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <%--<dx:ASPxGridView ID="grvListChuong" runat="server" ClientInstanceName="grvList" KeyFieldName="lesson_id" Width="100%">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" Width="2%"></dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="Tên bài" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                </Columns>
                                <SettingsSearchPanel Visible="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                <SettingsLoadingPanel Text="Đang tải..." />
                                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                            </dx:ASPxGridView>--%>
                            <dx:ASPxGridLookup ID="grvListChuong" runat="server" SelectionMode="Multiple" ClientInstanceName="lkChuong"
                                KeyFieldName="lesson_id" Width="300px" TextFormatString="{0}" MultiTextSeparator=", " Caption="Chương">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                    <dx:GridViewDataColumn FieldName="lesson_name" Caption="Chương" Width="250px" />
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
        <div class="row mt-2">
            <%--<asp:UpdatePanel ID="udButton" runat="server">
                <ContentTemplate>
                    <div runat="server" id="dvButton">
                        
                        <div class="form-group row" style="margin-left: 0">
                            <div class="col-6">
                                <asp:DropDownList runat="server" ID="ddlLoaiBaiKiemTra" CssClass="btn btn-primary" Style="border: 1px solid gray" AutoPostBack="true"></asp:DropDownList>
                            </div>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row" style="margin: 0">
                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="form-group table-responsive">
                    <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="englishquestion_id" Width="100%">
                        <Columns>
                            <%--<dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                <DataItemTemplate>
                                    <%#Container.ItemIndex+1 %>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" Width="2%"></dx:GridViewCommandColumn>
                            <dx:GridViewDataColumn Caption="Chương" FieldName="chapter_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Tên bài" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Tên bài" FieldName="englishquestion_content" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>

                            <%--<dx:GridViewDataColumn Caption="Loại câu hỏi" FieldName="question_type" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <%--<dx:GridViewDataColumn Caption="#" HeaderStyle-HorizontalAlign="Center" Width="10%">
                                <DataItemTemplate>
                                    <a href="javascript:void(0)" id="<%#Eval("question_id") %>" onclick="funcSelectQues(this.id)" class="btn btn-primary">Chọn</a>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                        </Columns>
                        <SettingsSearchPanel Visible="true" />
                        <SettingsBehavior AllowFocusedRow="true" />
                        <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                        <SettingsLoadingPanel Text="Đang tải..." />
                        <SettingsPager PageSize="1000" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                    </dx:ASPxGridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
        <input type="text" value="" runat="server" id="txtLink" placeholder="link bài kiểm tra..." hidden="hidden" />
        <%-- <input type="submit" id="txtLuu" class="btn btn-primary" value="Lưu" onclick="confirmDel()" />--%>
        <a href="#" id="btnLuu" runat="server" class="btn btn-primary" onserverclick="btnLuu_Click">Lưu</a>
        <%--  <asp:Button ID="btnLuu" runat="server" CssClass="invisible" OnClick="btnLuu_Click" />--%>
        <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
