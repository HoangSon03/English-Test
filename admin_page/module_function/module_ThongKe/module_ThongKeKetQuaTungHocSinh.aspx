<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ThongKeKetQuaTungHocSinh.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_module_ThongKeKetQuaTungHocSinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <link href="../../../admin_css/Loading.css" rel="stylesheet" />
    <style>
        .myActive {
            background-color: red !important;
            border: none
        }

        .danhsachhocsinh {
            height: 450px;
            border-right: 2px solid gray;
            overflow-y: auto;
        }
    </style>
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
        //func set active
        function myActiveLop(lop_id) {
            document.getElementById("btnLop_" + lop_id).classList.add("myActive");
        }
        function myActiveHocSinh(hocsinh_id) {
            document.getElementById("btnHocSinh_" + hocsinh_id).classList.add("myActive");
        }
        function myActiveKyNang(kynang) {
            document.getElementById("btn_" + kynang).classList.add("myActive");
        }
        function myActiveDeThi(dethi) {
            document.getElementById("btnDeThi_" + dethi).classList.add("myActive");
        }
        //func chọn lớp -> hiển thị ra ds các hs đã làm bài luyện tập
        function myLop(id, monhoc) {
            document.getElementById('<%=txtLop.ClientID%>').value = id;
            document.getElementById('<%=txtMonHocId.ClientID%>').value = monhoc;
            document.getElementById('<%=btnXemLop.ClientID%>').click();
        }
        //fun chọn hs để xem kết quả của hs
        function myHocSinh(hocsinh_id) {
            document.getElementById('<%=txtHocSinh_ID.ClientID%>').value = hocsinh_id;
            document.getElementById('<%=btnXemHocSinh.ClientID%>').click();
        }
        //func chọn kỹ năng
        function myKyNang(kynnag) {
            document.getElementById('<%=txtKyNang.ClientID%>').value = kynnag;
            document.getElementById('<%=btnKyNang.ClientID%>').click();
        }
        //func chọn đề thi
        function myDeThi(dethi_id) {
            document.getElementById('<%=txtDeThiId.ClientID%>').value = dethi_id;
            document.getElementById('<%=btnXemDe.ClientID%>').click();
        }
    </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="card card-block">
        <div class="form-group">
            <asp:Repeater ID="rpLop" runat="server">
                <ItemTemplate>
                    <a href="javascript:void(0)" class="btn btn-primary" id="btnLop_<%#Eval("lop_id")%>" onclick="myLop('<%#Eval("lop_id")%>','<%#Eval("monhoc")%>');DisplayLoadingIcon()"><%#Eval("lop_name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group">
            <div class="col-2">
                <div class="danhsachhocsinh">
                    <asp:Repeater ID="rpHocSinh" runat="server">
                        <ItemTemplate>
                            <a href="javascript:void(0)" class="btn btn-primary" id="btnHocSinh_<%#Eval("hocsinh_code")%>" onclick="myHocSinh('<%#Eval("hocsinh_code")%>');DisplayLoadingIcon()"><%#Eval("hocsinh_name") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>


            <div class="col-10" id="div_KyNang" runat="server">
                <%--biểu đồ 1 line--%>
                <%--<div class="button">
                    <a href="#" class="btn btn-primary" id="btn_reading" onclick="myKyNang('reading');DisplayLoadingIcon()">Reading</a>
                    <a href="#" class="btn btn-primary" id="btn_listening" onclick="myKyNang('listening');DisplayLoadingIcon()">Listening</a>
                </div>
                <div class="bieudo" id="div_BieuDo" runat="server">
                    <div class="chart">
                        <canvas id="resultChart" width="500" height="200"></canvas>
                    </div>
                </div>
                <asp:Repeater ID="rpDanhSachDe" runat="server">
                    <ItemTemplate>
                        <a href="javascript:void(0)" class="btn btn-primary" id="btnDeThi_<%#Eval("dethi_id")%>" onclick="myDeThi('<%#Eval("dethi_id")%>');DisplayLoadingIcon()"><%#Eval("dethi_name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
                 <div class="bieudo" id="div1" runat="server">
                    <div class="chart">
                        <canvas id="chart" width="500" height="200"></canvas>
                    </div>
                </div>--%>
                <%--Biểu đồ nhiều line--%>
                <div class="chart">
                    <canvas id="detailChart" width="500" height="200"></canvas>
                </div>

            </div>
        </div>
        <div class="form-group">
            <div class="col-12 mt-2">
                <asp:Repeater ID="rpDanhSachDe" runat="server">
                    <ItemTemplate>
                        <a href="javascript:void(0)" class="btn btn-primary" id="btnDeThi_<%#Eval("dethi_id")%>" onclick="myDeThi('<%#Eval("dethi_id")%>');DisplayLoadingIcon()"><%#Eval("dethi_name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="chart">
                    <canvas id="detail" width="500" height="200"></canvas>
                </div>
                <%-- <div class="chart">
                <div class="col-6" style="border-right: 2px solid #746666;">
                    <canvas id="detail1" width="500" height="200"></canvas>
                </div>
                <div class="col-6">
                    <canvas id="detail2" width="500" height="200"></canvas>
                </div>
            </div>--%>
            </div>
        </div>
    </div>
    <div hidden>
        ds kỹ năng:<input type="text" id="txtDSKyNang" runat="server" />
        ds đề:<input type="text" id="txtDSDe" runat="server" />
        ds diem:<input type="text" id="txtDSDiem" runat="server" />
        ds phantram:<input type="text" id="txtDSPhanTram" runat="server" />
        môn học:<input type="text" id="txtMonHocId" runat="server" />
        id lớp:<input type="text" id="txtLop" runat="server" />
        <a href="javascript:void(0)" id="btnXemLop" runat="server" onserverclick="btnXemLop_ServerClick">Xem</a>
        hs id:<input type="text" id="txtHocSinh_ID" runat="server" />
        <a href="javascript:void(0)" id="btnXemHocSinh" runat="server" onserverclick="btnXemHocSinh_ServerClick">xem hs</a>
        kỹ năng:<input type="text" id="txtKyNang" runat="server" />
        <a href="javascript:void(0)" id="btnKyNang" runat="server" onserverclick="btnKyNang_ServerClick">xem kỹ năng</a>

        list Point
        <input type="text" id="txtListPoint" runat="server" />
        phần trăm
        <input type="text" id="txtPercent" runat="server" />
        dethi_id:<input type="text" id="txtDeThiId" runat="server" />
        <a href="javascript:void(0)" id="btnXemDe" runat="server" onserverclick="btnXemDe_ServerClick">Xem đề</a>
        ngày làm<input type="text" id="txtNgay" runat="server" />
        list Point
        <input type="text" id="txtDiem" runat="server" />
        phần trăm
        <input type="text" id="txtPhanTram" runat="server" />
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <script>
        var speedCanvas = document.getElementById("detailChart");
        var speedCanvas2 = document.getElementById("detail");
        //var chartdetail1 = document.getElementById("detail1");
        //var chartdetail2 = document.getElementById("detail2");
        Chart.defaults.global.defaultFontFamily = "Lato";
        Chart.defaults.global.defaultFontSize = 16;
        // trục tung (dọc) là số điểm (%) của mỗi kỹ năng
        // trục hoành (ngang) là ds các đề của hs đã làm
        //mỗi line là 1 kỹ năng
        <%--var listDe = document.getElementById("<%=txtDSDe.ClientID%>").value.split(';');
        var arrPointOfKyNang = document.getElementById("<%=txtPercent.ClientID%>").value.replaceAll(',', '.').split('|');
        new Chart("resultChart", {
            type: "line",
            data: {
                labels: listDe,
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
        //vẽ biểu đồ chi tiết so sánh qua các lần làm bài
        // trục tung (dọc) là số điểm (%) của kỹ năng của đề
        // trục hoành (ngang) là ds các lần làm bài
        var listNgay = document.getElementById("<%=txtNgay.ClientID%>").value.split(';');
        var arrPhanTram = document.getElementById("<%=txtPhanTram.ClientID%>").value.replaceAll(',', '.').split('|');
        new Chart("chart", {
            type: "line",
            data: {
                labels: listNgay,
                datasets: [{
                    fill: false,
                    lineTension: 0,
                    //backgroundColor: "rgba(0,0,255,1.0)",
                    borderColor: "rgb(75, 192, 192)",
                    data: arrPhanTram
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{ ticks: { min: 0, max: 100 } }],
                }
            }
        });--%>
        const getLongestText = (arr) => arr.reduce(
            (savedText, text) => (text.length > savedText.length ? text : savedText),
            '',
        );
        var listDe = document.getElementById("<%=txtDSDe.ClientID%>").value.split(';');//lấy arr[i] nhiều đề nhất
        var _dsDe = getLongestText(listDe).split('|');
        var arrPointOfKyNang = document.getElementById("<%=txtDSPhanTram.ClientID%>").value.split(';');//arr[0] là điểm của reading, arr[1] là điểm của listening
        //console.log(arrPointOfKyNang);
        let arrPointFirst = arrPointOfKyNang[0].replaceAll(',', '.').split('|');
        let arrPointSecond = arrPointOfKyNang[1].replaceAll(',', '.').split('|');
        var dataFirst = {
            label: "Reading",
            data: arrPointFirst,
            lineTension: 0,
            fill: false,
            borderColor: 'red'
        };

        var dataSecond = {
            label: "Listening",
            data: arrPointSecond,
            lineTension: 0,
            fill: false,
            borderColor: 'blue'
        };
        var speedData = {
            labels: _dsDe,
            datasets: [dataFirst, dataSecond]
        };
        var chartOptions = {
            legend: {
                display: true,
                position: 'top',
                labels: {
                    boxWidth: 80,
                    fontColor: 'black'
                }
            }
        };

        var lineChart = new Chart(speedCanvas, {
            type: 'line',
            data: speedData,
            options: chartOptions
        });

        //vẽ biểu đồ 2 chi tiết làm bài từng đề qua các ngày
        let arr_Ngay = document.getElementById("<%=txtNgay.ClientID%>").value.split("|");//arr_Ngay[0] là list ngày làm arr_KyNang[0],arr_Ngay[1] là list ngày làm arr_KyNang[1]
        let arr_Ngay1 = arr_Ngay[0].split(";");
        let arr_Ngay2 = arr_Ngay[1].split(";");
        let arr_KyNang = document.getElementById("<%=txtKyNang.ClientID%>").value.split(";");
        let arr_PhanTram = document.getElementById("<%=txtPercent.ClientID%>").value.split("@");//arr_PhanTram[0] là list điểm của arr_KyNang[0],arr_PhanTram[1] là list điểm của arr_KyNang[1]
        let arr_First = arr_PhanTram[0].replaceAll(',', '.').split('|');
        let arr_Second = arr_PhanTram[1].replaceAll(',', '.').split('|');
        let arr_SoLan = [];
        //kiểm tra xem trong 2 kỹ năng, cái nào làm nhiều lần hơn thì lấy làm giá trị trục ngang
        if (arr_Ngay1.length > arr_Ngay2.length) {
            for (var i = 1; i <= arr_Ngay1.length; i++) {
                arr_SoLan.push("Lần " + i)
            }
        }
        else {
            for (var i = 1; i <= arr_Ngay2.length; i++) {
                arr_SoLan.push("Lần " + i)
            }
        }
        var data_First = {
            label: arr_KyNang[0],
            data: arr_First,
            lineTension: 0,
            fill: false,
            borderColor: 'red'
        };

        var data_Second = {
            label: arr_KyNang[1],
            data: arr_Second,
            lineTension: 0,
            fill: false,
            borderColor: 'blue'
        };
        var speedData2 = {
            labels: arr_SoLan,
            datasets: [data_First, data_Second]
        };
        var chartOptions2 = {
            legend: {
                display: true,
                position: 'top',
                labels: {
                    boxWidth: 80,
                    fontColor: 'black'
                }
            }
        };

        var lineChart = new Chart(speedCanvas2, {
            type: 'line',
            data: speedData2,
            options: chartOptions2
        });
        //new Chart("detail1", {
        //    type: "line",
        //    data: {
        //        labels: arr_Ngay1,
        //        datasets: [{
        //            fill: false,
        //            lineTension: 0,
        //            //backgroundColor: "rgba(0,0,255,1.0)",
        //            borderColor: "rgb(75, 192, 192)",
        //            data: arr_First
        //        }]
        //    },
        //    options: {
        //        legend: { display: false },
        //        scales: {
        //            yAxes: [{ ticks: { min: 0, max: 100 } }],
        //        },
        //        responsive: true,
        //        title: {
        //            display: true,
        //            text: arr_KyNang[0]
        //        },
        //        hover: {
        //            mode: 'nearest',
        //            intersect: true
        //        },
        //    }
        //});
        //new Chart("detail2", {
        //    type: "line",
        //    data: {
        //        labels: arr_Ngay2,
        //        datasets: [{
        //            fill: false,
        //            lineTension: 0,
        //            //backgroundColor: "rgba(0,0,255,1.0)",
        //            borderColor: "#0392FF",
        //            data: arr_Second
        //        }]
        //    },
        //    options: {
        //        legend: { display: false },
        //        scales: {
        //            yAxes: [{ ticks: { min: 0, max: 100 } }],
        //        },
        //        responsive: true,
        //        title: {
        //            display: true,
        //            text: arr_KyNang[1]
        //        },
        //        hover: {
        //            mode: 'nearest',
        //            intersect: true
        //        },
        //    }
        //});
        //var data_First = {
        //    label: arr_KyNang[0],
        //    data: arr_First,
        //    lineTension: 0,
        //    fill: false,
        //    borderColor: 'red'
        //};

        //var data_Second = {
        //    label: arr_KyNang[1],
        //    data: arr_Second,
        //    lineTension: 0,
        //    fill: false,
        //    borderColor: 'blue'
        //};
        //var speedData2 = {
        //    labels: arr_Ngay,
        //    datasets: [data_First, data_Second]
        //};
        //var chartOptions2 = {
        //    legend: {
        //        display: true,
        //        position: 'top',
        //        labels: {
        //            boxWidth: 80,
        //            fontColor: 'black'
        //        }
        //    }
        //};

        //var lineChart = new Chart(chartChiTiet, {
        //    type: 'line',
        //    data: speedData2,
        //    options: chartOptions2
        //});
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

