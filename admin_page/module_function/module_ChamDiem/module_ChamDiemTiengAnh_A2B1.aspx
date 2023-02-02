<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ChamDiemTiengAnh_A2B1.aspx.cs" Inherits="admin_page_module_function_module_ChamDiem_module_ChamDiemTiengAnh_A2B1" %>

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
        function myChapter(chapter_id) {
            document.getElementById("<%=txtChapterId.ClientID%>").value = chapter_id;
            document.getElementById("<%=btnChapter.ClientID%>").click();
        }
        //func chọn kỹ năng
        function myTest(test_id) {
            document.getElementById("<%=txtTestId.ClientID%>").value = test_id;
            document.getElementById("<%=btnChiTiet.ClientID%>").click();
        }
        //func show result test
        function myChiTiet(result_id) {
            document.getElementById("<%=txtResultId.ClientID%>").value = result_id;
            document.getElementById("<%=btnShowResult.ClientID%>").click();
        }
        //func set active
        function myActiveMon(monhoc_id) {
            document.getElementById("btnMonHoc_" + monhoc_id).classList.add("myActive");
        }
        //func set active
        function myActiveChuong(chapter_id) {
            document.getElementById("btnChapter_" + chapter_id).classList.add("myActive");
        }
        //func set active
        function myActive(test_id) {
            document.getElementById("btnTest_" + test_id).classList.add("myActive");
        }
        function checkNULL() {
            var getPoints = $("input[name='txt_Diem']").map(function () {
                return $(this).val().replace(',', '.');
            }).get();
            var getID = $("input[name='txt_Diem']").map(function () {
                return $(this).data("id");
            }).get();
            console.log(getPoints);
            console.log(getID);
            document.getElementById("<%=txtDanhSachId.ClientID%>").value = getID.toString();
            document.getElementById("<%=txtDanhSachDiem.ClientID%>").value = getPoints.toString();
        }
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <asp:Repeater runat="server" ID="rpMonHoc">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnMonHoc_<%#Eval("monhoc_id") %>" onclick="myMonHoc(<%#Eval("monhoc_id") %>)" class="btn btn-success"><%#Eval("monhoc_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group row" id="div_De" runat="server">
            <asp:Repeater runat="server" ID="rpDanhSachDe">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnChapter_<%#Eval("chapter_id") %>" onclick="myChapter(<%#Eval("chapter_id") %>)" class="btn btn-success"><%#Eval("chapter_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group row" id="div_KyNang" runat="server">
            <asp:Repeater runat="server" ID="rpKyNang">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnTest_<%#Eval("test_id") %>" onclick="myTest(<%#Eval("test_id") %>)" class="btn btn-success"><%#Eval("baithicate_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group row" id="div_KetQua" runat="server">
            <table class="table table-hover table-striped table_baogiang">
                <tr>
                    <th>STT</th>
                    <th>Họ tên</th>
                    <th>Ngày làm</th>
                    <th>#</th>
                </tr>
                <asp:Repeater ID="rpDanhSachHocSinh" runat="server">
                    <ItemTemplate>
                        <tr>
                            <th><%#Container.ItemIndex+1 %></th>
                            <th><%#Eval("hocsinh_name") %></th>
                            <th><%#Eval("ngaylam") %></th>
                            <th><a href="javascript:void(0)" id="<%#Eval("resulttest_id") %>" class="btn btn-primary" onclick="myChiTiet('<%#Eval("resulttest_id") %>')">Chi tiết</a></th>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>

        <dx:ASPxPopupControl ID="popupControl" runat="server" Width="1000px" Height="550px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
            HeaderText="Chi tiết bài làm" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){}">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <asp:UpdatePanel ID="udPopup" runat="server">
                        <ContentTemplate>
                            <div class="popup-main">
                                <div class="div_content col-12">
                                    <table class="table table-bordered table-hover table_baogiang">
                                        <tr class="table-info table__point-head">
                                            <th scope="col">STT</th>
                                            <th scope="col">Content Questions</th>
                                            <th scope="col">Correct answer</th>
                                            <th scope="col">Answer</th>
                                            <th scope="col">Point</th>
                                        </tr>
                                        <asp:Repeater ID="rpChiTiet" runat="server">
                                            <ItemTemplate>
                                                <tr class="table-light table__point">
                                                    <th scope="row"><%#Container.ItemIndex+1 %></th>
                                                    <td style="width: 475px"><%#Eval("noidungcauhoi") %></td>
                                                    <td><%#Eval("content_dapandung") %></td>
                                                    <td><%#Eval("content_dapanchon") %></td>
                                                    <td>
                                                        <input type="text" id="txtDiem_<%#Eval("resultchitiet_id") %>" data-id="<%#Eval("resultchitiet_id") %>" name="txt_Diem" value="<%#Eval("resultchitiet_point") %>" autocomplete="off" style="width: 80px" /></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterContentTemplate>
                <div class="mar_but button">
                    <a href="#" id="btnLuu" runat="server" onclick="checkNULL()" onserverclick="btnLuu_ServerClick" class="btn btn-primary">Lưu Điểm</a>
                    <%--<asp:Button ID="btnLuuDiem" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary"  OnClick="btnLuuDiem_Click"/>--%> <%-- --%>
                </div>
            </FooterContentTemplate>
            <ContentStyle>
                <Paddings PaddingBottom="0px" />
            </ContentStyle>
        </dx:ASPxPopupControl>

        <div style="display: none">
            <input type="text" id="txtMonHocId" runat="server" />
            <a href="#" id="btnMonHoc" runat="server" onserverclick="btnMonHoc_ServerClick">Môn</a>
            <input type="text" id="txtChapterId" runat="server" />
            <a href="#" id="btnChapter" runat="server" onserverclick="btnChapter_ServerClick">Đề</a>
            <input type="text" id="txtTestId" runat="server" />
            <a href="#" id="btnChiTiet" runat="server" onserverclick="btnChiTiet_ServerClick">Đề</a>
            <input type="text" id="txtDanhSachId" runat="server" />
            <input type="text" id="txtDanhSachDiem" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <input type="text" id="txtResultId" runat="server" />
                    <a href="#" id="btnShowResult" runat="server" onserverclick="btnShowResult_ServerClick">content</a>
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

