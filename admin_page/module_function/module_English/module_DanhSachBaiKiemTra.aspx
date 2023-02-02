<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DanhSachBaiKiemTra.aspx.cs" Inherits="admin_page_module_function_module_BaiKiemTra_module_DanhSachBaiKiemTra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script>
        function myfunction(id) {
            document.getElementById("<%=id_key.ClientID%>").value = id;
            var dd = document.getElementById("<%=build_url.ClientID%>");
            dd.click();
        }
        function geturl() {
            var copyText = document.getElementById("<%=url.ClientID%>");
            copyText.select();
            copyText.setSelectionRange(0, 99999)
            document.execCommand("copy");
            console.log(copyText.value);
            //Swal.fire({
            //    position: 'center',
            //    icon: 'success',
            //    title: 'Đã sao chép đường liên kết',
            //    showConfirmButton: false,
            //    timer: 1500
            //})
            var tooltip = document.getElementById("myTooltip");
            tooltip.classList.add('tooltiptext__show');
            tooltip.innerHTML = "Đã sao chép đường liên kết";
            //tooltip.style.display = "block";
            setTimeout(function () {
                tooltip.style.transform = "scale(0)";
            }, 1500);
        }
        function popupShow() {
            document.getElementById('showPopup').click();
        }
        function popupHide() {
            document.getElementById('btnClosePopup').click();
        }
        function confirmDel() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể thay đổi.",
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
    <style>
        .link {
            position: absolute;
            top: 100px;
            z-index: -1;
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

        .popup {
            width: 55rem;
        }

        .brg {
            position: absolute;
            top: -30px;
            bottom: -100px;
            left: -153px;
            z-index: -1;
            width: 100rem;
            height: 107%;
            background: black;
            opacity: 0.6;
        }

        #myTooltip {
            width: auto;
            height: 42px;
            color: white;
            text-align: center;
            border-radius: 6px;
            padding: 5px;
            position: fixed;
            z-index: 7;
            right: 40%;
            top: 50%;
            background: #656767;
            line-height: 30px;
        }

        .tooltiptext {
            opacity: 0;
            visibility: hidden;
            transform: scale(0);
            transition: transform 0.3s linear;
        }

            .tooltiptext.tooltiptext__show {
                opacity: 1;
                visibility: visible;
                transform: scale(1);
            }
    </style>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-5">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" OnClick="btnChiTiet_Click" />
                        <input type="submit" class="btn btn-primary " value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <input type="text" name="name" value="" hidden="hidden" runat="server" id="id_key" placeholder="id_click" />
        <div class="row">
            <div class="col-sm-12">
                <span class="tooltiptext" id="myTooltip">Đã sao chép đường liên kết</span>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <input type="text" name="name" value="" class="link" runat="server" id="url" placeholder="đường dẫn" style="width: 1000px" />
                        <asp:Button Text="text" ID="build_url" runat="server" CssClass="invisible" OnClick="build_url_Click" />
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="test_id">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                        <DataItemTemplate>
                                            <%#Container.ItemIndex+1 %>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" Width="5%"></dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="Tên bài kiểm tra" FieldName="baithicate_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Môn học" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="12%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="17%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ngày tạo" FieldName="test_createdate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" Width="23%" Settings-AllowEllipsisInText="true">
                                        <DataItemTemplate>
                                            <a href="javascript:void(0)" id="<%#Eval("test_id") %>" onclick="myfunction(this.id)"  class="btn btn-primary" >Sao chép đường liên kết</a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
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
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <button id="showPopup" type="button" class="btn btn-info btn-lg" style="display: none;" data-toggle="modal" data-target="#myModal">Open Modal</button>
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="brg"></div>

                    <div class="modal-content popup">
                        <div class="modal-header">
                            <button id="btnClosePopup" type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Chi tiết bài kiểm tra</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">STT</th>
                                        <th scope="col">Nội dung câu hỏi</th>
                                        <th scope="col">Loại câu hỏi</th>
                                        <th scope="col">Người tạo</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rpCH">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%#Container.ItemIndex+1 %></th>
                                                <td><%#Eval("question_content") %></td>
                                                <td><%#Eval("question_type") %></td>
                                                <td><%#Eval("username_fullname") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

