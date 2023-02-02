<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_BieuDoThongKeKetQuaTheoDe_A2B1.aspx.cs" Inherits="admin_page_module_function_module_ChamDiem_module_BieuDoThongKeKetQuaTheoDe_A2B1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <%--<link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />--%>
    <link href="../../../admin_css/Loading.css" rel="stylesheet" />
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
        function myActiveChuong(chapter_id) {
            document.getElementById("btnChapter_" + chapter_id).classList.add("myActive");
        }
        function myActiveKyNang(lop_id) {
            document.getElementById("btnKyNang_" + lop_id).classList.add("myActive");
        }
        //func set active
        function myActive(test_id) {
            document.getElementById("btnTest_" + test_id).classList.add("myActive");
        }
        function myKyNang(id) {
            document.getElementById('<%=txtKyNangID.ClientID%>').value = id;
            document.getElementById('<%=txtKyNang.ClientID%>').value = document.getElementById("btnKyNang_" + id).innerHTML;
            <%--document.getElementById('<%=txtChapterId.ClientID%>').value = chapter;--%>
            document.getElementById('<%=btnKyNang.ClientID%>').click();
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
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
    </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="card card-block">
        <div class="form-group row">
            <asp:Repeater runat="server" ID="rpMonHoc">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnMonHoc_<%#Eval("monhoc_id") %>" onclick="myMonHoc(<%#Eval("monhoc_id") %>); DisplayLoadingIcon()" class="btn btn-primary"><%#Eval("monhoc_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group row">
            <asp:Repeater runat="server" ID="rpDanhSachDe">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnChapter_<%#Eval("chapter_id") %>" onclick="myChapter(<%#Eval("chapter_id") %>);DisplayLoadingIcon()" class="btn btn-primary"><%#Eval("chapter_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group">
            <asp:Repeater ID="rpKyNang" runat="server">
                <ItemTemplate>
                    <a href="#" class="btn btn-primary" id="btnKyNang_<%#Eval("test_id")%>" onclick="myKyNang('<%#Eval("test_id")%>'); DisplayLoadingIcon()"><%#Eval("baithicate_name") %>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group" id="KyNangA2" runat="server">
            <a href="#" class="btn btn-primary" id="btnKyNang_189" onclick="myKyNang('189');DisplayLoadingIcon()">Reading</a>
            <a href="#" class="btn btn-primary" id="btnKyNang_1" onclick="myKyNang('1');DisplayLoadingIcon()">Writing</a>
            <a href="#" class="btn btn-primary" id="btnKyNang_190" onclick="myKyNang('190');DisplayLoadingIcon()">Listening</a>
            <a href="#" class="btn btn-primary" id="btnKyNang_191" onclick="myKyNang('191');DisplayLoadingIcon()">Speaking</a>
        </div>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th scope="col">Tỉ lệ</th>
                    <th scope="col">0% - 25%</th>
                    <th scope="col">25% - 50%</th>
                    <th scope="col">50% - 70%</th>
                    <th scope="col">70% - 80%</th>
                    <th scope="col">80% - 90%</th>
                    <th scope="col">>=90%</th>
                </tr>
            </thead>
            <tbody>
                <tr style="text-align: center">
                    <td>Số lượng</td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter"><%=sl0 %></a></td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleTrungBinh"><%=sl25 %></a></td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleVua"><%=sl50 %></a></td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleKha"><%=sl70 %></a></td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleGioi"><%=sl80 %></a></td>
                    <td><a href="#" class="btn btn-primary" data-toggle="modal" data-target="#exampleXuatSac"><%=sl90 %></a></td>
                </tr>
            </tbody>
        </table>
        <%--modal chi tiết--%>
        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSach" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="exampleTrungBinh" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSachTrungBinh" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="exampleVua" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSachVua" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="exampleKha" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSachKha" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="exampleGioi" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSachGioi" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="exampleXuatSac" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Phần trăm</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpDanhSachXuatSac" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_code")%></td>
                                            <td><%#Eval("hocsinh_name")%></td>
                                            <td><%#Eval("percent")+"%"%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="chart" id="div_De" runat="server">
            <canvas id="resultChart" width="600" height="200"></canvas>
        </div>

        <div style="display: none">
            ds hs
         <input type="text" id="txtDSHS" runat="server" />
            ds kỹ năng
         <input type="text" id="txtDSKyNang" runat="server" />
            list Point
        <input type="text" id="txtListPoint" runat="server" />
            <input type="text" id="txtMonHocId" runat="server" />
            <%--ds kỹ năng
         <input type="text" id="Text1" runat="server" />--%>
            tên kỹ năng 
         <input type="text" id="txtKyNang" runat="server" />
            id kỹ năng
         <input type="text" id="txtKyNangID" runat="server" />
            phần trăm
        <input type="text" id="txtPercent" runat="server" />
            <a href="#" id="btnKyNang" runat="server" onserverclick="btnKyNang_ServerClick">Xem</a>
            <a href="#" id="btnMonHoc" runat="server" onserverclick="btnMonHoc_ServerClick">Môn</a>
            <input type="text" id="txtChapterId" runat="server" />
            <a href="#" id="btnChapter" runat="server" onserverclick="btnChapter_ServerClick">Đề</a>
        </div>
    </div>

    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script>
        var speedCanvas = document.getElementById("resultChart");

        Chart.defaults.global.defaultFontFamily = "Lato";
        Chart.defaults.global.defaultFontSize = 16;

        // trục tung (dọc) là số điểm của mỗi kỹ năng
        // trục hoành (ngang) là ds các học sinh làm đề (labels)
        //mỗi line là 1 kỹ năng
        var listHocSinh = document.getElementById("<%=txtDSHS.ClientID%>").value.split(';');
        //var listKyNang = document.getElementById("<%=txtDSKyNang.ClientID%>").value.split(';');
        //console.log(listKyNang.length);
        //var arrPointOfKyNang = document.getElementById("<%=txtListPoint.ClientID%>").value.split('|');
        var arrPointOfKyNang = document.getElementById("<%=txtPercent.ClientID%>").value.replaceAll(',', '.').split(';');
        new Chart("resultChart", {
            type: "line",
            data: {
                labels: listHocSinh,
                datasets: [{
                    fill: false,
                    lineTension: 0,
                    //backgroundColor: "rgba(0,0,255,1.0)",
                    borderColor: "rgb(75, 192, 192)",
                    data: arrPointOfKyNang
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{ ticks: { min: 0, max: 100 } }],
                }
            }
        });
        //var myCharttuan = new Chart("resultChart", {
        //    type: 'line',
        //    data: {
        //        labels: listHocSinh,
        //        datasets: [{
        //            //label: ["Đã xem"],
        //            data: arrPointOfKyNang,
        //            borderColor: 'rgb(75, 192, 192)',
        //        }]
        //    },
        //    options: {
        //        legend: { display: false },
        //        title: {
        //            display: true,
        //            text: "Kết quả"
        //        },
        //        scales: {
        //            yAxes: [{
        //                ticks: {
        //                    min: 0, // minimum value
        //                    max: 100,
        //                }
        //            }]
        //        },
        //    }
        //});
        //debugger
        //if (listKyNang.length == 4) {
        //    let arrPointFirst = arrPointOfKyNang[0].replaceAll(',', '.').split(';');
        //    let arrPointSecond = arrPointOfKyNang[1].replaceAll(',', '.').split(';');
        //    let arrPointThree = arrPointOfKyNang[2].replaceAll(',', '.').split(';');
        //    console.log(arrPointThree);
        //    let arrPointFour = arrPointOfKyNang[3].replaceAll(',', '.').split(';');
        //    var dataFirst = {
        //        label: listKyNang[0],
        //        data: arrPointFirst,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'red'
        //    };

        //    var dataSecond = {
        //        label: listKyNang[1],
        //        data: arrPointSecond,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'blue'
        //    };
        //    var dataThree = {
        //        label: listKyNang[2],
        //        data: arrPointThree,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'green'
        //    };
        //    var dataFour = {
        //        label: listKyNang[3],
        //        data: arrPointFour,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: '#ffa500'
        //    };
        //    var speedData = {
        //        labels: listHocSinh,
        //        datasets: [dataFirst, dataSecond, dataThree, dataFour]
        //    };
        //}
        //else {
        //    let arrPointFirst = arrPointOfKyNang[0].replaceAll(',', '.').split(';');
        //    let arrPointSecond = arrPointOfKyNang[1].replaceAll(',', '.').split(';');
        //    let arrPointThree = arrPointOfKyNang[2].replaceAll(',', '.').split(';');
        //    var dataFirst = {
        //        label: listKyNang[0],
        //        data: arrPointFirst,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'red'
        //    };

        //    var dataSecond = {
        //        label: listKyNang[1],
        //        data: arrPointSecond,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'blue'
        //    };
        //    var dataThree = {
        //        label: listKyNang[2],
        //        data: arrPointThree,
        //        lineTension: 0,
        //        fill: false,
        //        borderColor: 'green'
        //    };
        //    //var dataFour = {
        //    //    label: listKyNang[3],
        //    //    data: arrPointFour,
        //    //    //data: [0,18.5],
        //    //    lineTension: 0,
        //    //    fill: false,
        //    //    borderColor: '#ffa500'
        //    //};
        //    var speedData = {
        //        labels: listHocSinh,
        //        datasets: [dataFirst, dataSecond, dataThree]
        //    };
        //}

        //var chartOptions = {
        //    legend: {
        //        display: true,
        //        position: 'top',
        //        labels: {
        //            boxWidth: 80,
        //            fontColor: 'black'
        //        }
        //    }
        //};

        //var lineChart = new Chart(speedCanvas, {
        //    type: 'line',
        //    data: speedData,
        //    options: chartOptions
        //});
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

