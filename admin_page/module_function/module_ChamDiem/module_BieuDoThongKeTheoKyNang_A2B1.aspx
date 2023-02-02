<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_BieuDoThongKeTheoKyNang_A2B1.aspx.cs" Inherits="admin_page_module_function_module_ChamDiem_module_BieuDoThongKeTheoKyNang_A2B1" %>

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

        .tracnghiem-answer__image img {
            width: 100%;
        }

        .table_baogiang th, .table_baogiang td {
            /*text-align: center;*/
            border: 1px solid #2d3846;
        }
    </style>
    <script>
        //func chọn môn học
        function myMonHoc(monhoc_id) {
            document.getElementById("<%=txtMonHocId.ClientID%>").value = monhoc_id;
            document.getElementById("<%=btnMonHoc.ClientID%>").click();
        }
        //func chọn đề
        function btnKyNang(chapter_id) {
            document.getElementById("<%=txtKyNang.ClientID%>").value = chapter_id;
            document.getElementById("<%=btnKyNang.ClientID%>").click();
        }
        //func chọn kỹ năng
       <%-- function myTest(test_id) {
            document.getElementById("<%=txtTestId.ClientID%>").value = test_id;
            document.getElementById("<%=btnChiTiet.ClientID%>").click();
        }--%>
        //func show result test
        <%--function myChiTiet(result_id) {
            document.getElementById("<%=txtResultId.ClientID%>").value = result_id;
            document.getElementById("<%=btnShowResult.ClientID%>").click();
        }--%>
        //func set active
        function myActiveMon(monhoc_id) {
            document.getElementById("btnMonHoc_" + monhoc_id).classList.add("myActive");
        }
        //func set active
        function myActiveKyNang(chapter_id) {
            document.getElementById("btnKyNang_" + chapter_id).classList.add("myActive");
        }
        //func set active
        function myActive(test_id) {
            document.getElementById("btnTest_" + test_id).classList.add("myActive");
        }
        <%--function checkNULL() {
            var getPoints = $("input[name='txt_Diem']").map(function () {
                return $(this).val();
            }).get();
            var getID = $("input[name='txt_Diem']").map(function () {
                return $(this).data("id");
            }).get();
            console.log(getPoints);
            console.log(getID);
            document.getElementById("<%=txtDanhSachId.ClientID%>").value = getID.toString();
            document.getElementById("<%=txtDanhSachDiem.ClientID%>").value = getPoints.toString();
        }--%>
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <asp:Repeater runat="server" ID="rpMonHoc">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnMonHoc_<%#Eval("monhoc_id") %>" onclick="myMonHoc(<%#Eval("monhoc_id") %>)" class="btn btn-success"><%#Eval("monhoc_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group row">
            <asp:Repeater runat="server" ID="rpKyNang">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnKyNang_<%#Eval("kynang_code") %>" onclick="btnKyNang('<%#Eval("kynang_code") %>')" class="btn btn-success"><%#Eval("kynang_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="chart" id="div_De" runat="server">
            <canvas id="resultChart" width="600" height="200"></canvas>
        </div>

        <div style="display: block">
            mã hs
         <input type="text" id="txtHS_Code" runat="server" /> 
            ds hs
         <input type="text" id="txtDSHS" runat="server" />
            ds đề
         <input type="text" id="txtDSDe" runat="server" />
            list Point
        <input type="text" id="txtListPoint" runat="server" />
            <input type="text" id="txtMonHocId" runat="server" />
            <a href="#" id="btnMonHoc" runat="server" onserverclick="btnMonHoc_ServerClick">Môn</a>
            <input type="text" id="txtKyNang" runat="server" />
            <a href="#" id="btnKyNang" runat="server" onserverclick="btnKyNang_ServerClick">Đề</a>
        </div>
    </div>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <script>
        var speedCanvas = document.getElementById("resultChart");

        Chart.defaults.global.defaultFontFamily = "Lato";
        Chart.defaults.global.defaultFontSize = 16;

        // trục tung (dọc) là số điểm của mỗi hs ứng với mỗi đề
        // trục hoành (ngang) là ds các đề (labels)
        // mỗi line là 1 học sinh
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

