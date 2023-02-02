<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ThongKeKetQuaKiemTraA2_Version2.aspx.cs" Inherits="admin_page_module_function_module_ChamDiem_module_ThongKeKetQuaKiemTraA2_Version2" %>

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
        .myActive {
            background-color: red !important;
            border: none
        }
    </style>
    <div class="card card-block">
        <asp:Repeater ID="rpLop" runat="server">
            <ItemTemplate>
                <a href="#" class="btn btn-primary" id="btnLop_<%#Eval("lop_id")%>" onclick="myLop('<%#Eval("lop_id")%>','<%#Eval("monhoc")%>','<%#Eval("chapter")%>')"><%#Eval("lop_name") %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <div style="display: block">
            id lớp<input type="text" id="txtLop" runat="server" />
            <a href="#" id="btnLop" runat="server" onserverclick="btnLop_ServerClick">Xem</a>
             tổng hs
         <input type="text" id="txtTongHS" runat="server" /> 
            ds hs
         <input type="text" id="txtDSHS" runat="server" />
            ds kỹ năng
         <input type="text" id="txtDSKyNang" runat="server" />
            list Point
        <input type="text" id="txtListPoint" runat="server" />
            <input type="text" id="txtMonHocId" runat="server" />
            <input type="text" id="txtChapterId" runat="server" />
        </div>
        <script>
            //func set active
            function myActiveMon(lop_id) {
                document.getElementById("btnLop_" + lop_id).classList.add("myActive");
            }
            function myLop(id, monhoc, chapter) {
                document.getElementById('<%=txtLop.ClientID%>').value = id;
            document.getElementById('<%=txtMonHocId.ClientID%>').value = monhoc;
            document.getElementById('<%=txtChapterId.ClientID%>').value = chapter;
            document.getElementById('<%=btnLop.ClientID%>').click();
            }
        </script>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

