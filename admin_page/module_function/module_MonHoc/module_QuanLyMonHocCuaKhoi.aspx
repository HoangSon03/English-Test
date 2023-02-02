<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_QuanLyMonHocCuaKhoi.aspx.cs" Inherits="admin_page_module_function_module_MonHoc_module_QuanLyMonHocCuaKhoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        .title_monhoc{
            margin:0;
            margin-top:20px;
            font-size:22px;
        }
        .header_header{
            height: 60px;
            border-bottom:1px solid black;
        }
    </style>
    <script>
        function confirmDel() {
            swal("Bạn có thực sự muốn lưu?",
                "",
                "warning",
                {
                    buttons: true,
                    successMode: true
                }).then(function (value) {
                    if (value == true) {
                        var luu = document.getElementById('<%=btnLuu.ClientID%>');
                        luu.click();
                    }
                });
        }
        function confirmDelXoa() {
            swal("Bạn có thực sự muốn xóa?",
                "",
                "warning",
                {
                    buttons: true,
                    successMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnXoa.ClientID%>');
                        xoa.click();
                    }
                });
        }
    </script>
    <div class="card card-block">
        <div class="row header_header">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlkhoi" runat="server" CssClass="form-control" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-sm-12">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-sm-6">
                        <input type="submit" class="btn btn-primary" value="Lưu" onclick="confirmDel()" />
                        <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="invisible" OnClick="btnLuu_Click" />
                    </div>
                    <div class="col-sm-6">
                        <input type="submit" value="Xóa" class="btn btn-primary" onclick="confirmDelXoa()" />
                        <asp:Button ID="btnXoa" type="btnXoa" runat="server" Text="Xóa" CssClass="invisible" OnClick="btnXoa_Click" />
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

