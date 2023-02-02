using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
    public adminmodule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();

        list.Add("modulethoikhoabieutunggiaovien|admin-thoi-khoa-bieu|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_omt_NhapThoiKhoaBieuGiaoVien.aspx");


        list.Add("modulequanlychuong|admin-chuong|~/admin_page/module_function/module_TracNghiem/module_QuanLyChuong.aspx");
        //Module thêm chương
        list.Add("modulethemchuong|admin-them-chuong-{khoi_id}-{mon_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyChuong.aspx");
        //Module quản lý môn học của khối
        list.Add("modulethemmonhoc|admin-them-mon-hoc-{khoi_id}|~/admin_page/module_function/module_MonHoc/module_QuanLyMonHocCuaKhoi.aspx");
        //Module thêm bài học
        list.Add("modulethembaihoc|admin-them-bai-hoc/{chuong_id}|~/admin_page/module_function/module_MonHoc/module_ThemBaiHoc.aspx");
        // Module thêm câu hỏi Trắc Nghiệm reading b1
        //list.Add("modulethemcauhoitracnghiem|admin-quan-ly-cau-hoi-trac-nghiem-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoi.aspx");
        list.Add("modulethemcauhoitracnghiem|admin-quan-ly-cau-hoi-reading-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Reading.aspx");
        list.Add("modulethemcauhoireadinga2|admin-quan-ly-cau-hoi-readinga2-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Reading_A2.aspx");
        // Module thêm câu hỏi listening b1
        list.Add("modulethemcauhoilistening|admin-quan-ly-cau-hoi-listening-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Listening.aspx");
        list.Add("modulethemcauhoilisteninga2|admin-quan-ly-cau-hoi-listeninga2-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Listening_A2.aspx");

        // Module thêm câu hỏi Speaking b1
        //list.Add("modulethemcauhoispeaking|admin-quan-ly-cau-hoi-speaking-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiSpeaking.aspx");
        list.Add("modulethemcauhoispeaking|admin-quan-ly-cau-hoi-speaking-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Speaking.aspx");
        // Module Thêm Câu Hỏi Writing b1
        //list.Add("modulethemcauhoiwriting|admin-quan-ly-cau-hoi-writing-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiWriting.aspx");
        list.Add("modulethemcauhoiwriting|admin-quan-ly-cau-hoi-writing-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoi_Writing.aspx");

        // Module tạo bài kiểm tra
        //list.Add("moduletaobaikiemtra|admin-tao-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtra|admin-tao-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTra_Version2.aspx");
        list.Add("moduletaobaikiemtraa2|admin-tao-bai-kiem-tra-a2|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTra_A2.aspx");
        list.Add("moduletaobaikiemtrangaunhien|admin-tao-bai-kiem-tra-ngau-nhien|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTraNgauNhien.aspx");
        list.Add("moduledanhsachbaikiemtra|admin-danh-sach-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_DanhSachBaiKiemTra.aspx");
        list.Add("moduletaohsvaokiemtra|admin-hoc-sinh-vao-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_TaoHocSinhVaoBaiKiemTra.aspx");


        // module câu hỏi luyện tập
        //list.Add("moduletaocauhoiluyentap|admin-tao-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoiLuyenTap.aspx");
        list.Add("moduletaobailuyentaptienganh|admin-tao-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoiLuyenTap_Version2.aspx");
        list.Add("moduledanhsachbailuyentap|admin-danh-sach-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_DanhSachBaiLuyenTap.aspx");
        list.Add("modulebailuyentapchitiet|admin-bai-luyen-tap-chi-tiet-{id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_BaiLuyenTap_ChiTiet.aspx");
        list.Add("modulecapnhattracnghiem|admin-cap-nhat-cau-hoi-trac-nghiem-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}-{test_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoi.aspx");
        //xem trước bài luyện tạp

        list.Add("modulexemluyentapreadingb1|exercise-reading-b1-test-{test_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_XemLuyenTap_Reading_B1.aspx");
        list.Add("modulexemluyentaplisteningb1|exercise-listening-b1-test-{test_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_XemLuyenTap_Listening_B1.aspx");
        list.Add("modulexemluyentaplisteninga2|exercise-listening-a2-test-{test_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_XemLuyenTap_Listening_A2.aspx");
        list.Add("modulexemluyentapreadinga2|exercise-reading-a2-test-{test_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_XemLuyenTap_Reading_A2.aspx");
        //duyệt bài luyện tập
        list.Add("moduleduyetbailuyentap|admin-duyet-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_Duyet_BaiLuyenTap.aspx");




        //module duyệt môn - chương - bài
        list.Add("moduleduyetmonhoc|admin-duyet-mon-hoc|~/admin_page/module_function/module_Duyet/module_DuyetMon.aspx");
        list.Add("moduleduyetchuonghoc|admin-duyet-chuong-hoc|~/admin_page/module_function/module_Duyet/module_DuyetChuong.aspx");
        list.Add("moduleduyetbaihoc|admin-duyet-bai-hoc|~/admin_page/module_function/module_Duyet/module_DuyetBaiHoc.aspx");

        //module thống kê
        list.Add("modulethongkebieudo|admin-thong-ke-bieu-do-{id}|~/admin_page/module_function/module_ThongKe/admin_ThongKeBieuDo.aspx");
        //list.Add("modulethongketong|admin-thong-ke-tong|~/admin_page/module_function/module_ThongKe/admin_ThongKeTong.aspx");
        //admin-thong-ke-ket-qua-tung-hoc-sinh
        //thống kế kết quả từng học sinh
        list.Add("modulethongkeketquatunghocsinh|admin-thong-ke-ket-qua-tung-hoc-sinh|~/admin_page/module_function/module_ThongKe/module_ThongKeKetQuaTungHocSinh.aspx");
        list.Add("moduletchitietthongkebieudo4|admin-chi-tiet-thong-ke-bieu-do-4-{hocsinh_code}|~/admin_page/module_function/module_ThongKe/admin_ChiTiet_ThongKeBieuDo_4.aspx");

        //module thống kê theo số lần làm bài
        list.Add("modulethongkesolanlambai|admin-thong-ke-so-lan-lam-bai-{lop_id}|~/admin_page/module_function/module_ThongKe/admin_BieuDoSoLanLamBai.aspx");
        list.Add("modulethongketongsolanlambai|admin-thong-ke-tong-so-lan-lam-bai|~/admin_page/module_function/module_ThongKe/admin_ThongKeTongSoLanLamBai.aspx");
        list.Add("moduletchitietlambaitap|admin-chi-tiet-lam-bai-tap-{hocsinh_code}|~/admin_page/module_function/module_ThongKe/admin_ChiTiet_LamBaiTap.aspx");

        //moduel kết quả học tập -rèn luyện
        list.Add("moduleketquabailuyentap|admin-ket-qua-luyen-tap|~/admin_page/module_function/module_KetQuaHocTap/admin_KetQuaBaiLuyenTap.aspx");

        //modun tiêng anh
        //admin-danh-sach-bai-kiem-tra-a2-b1

        list.Add("moduledanhsachbaikiemtraa2b1|admin-danh-sach-bai-kiem-tra-a2-b1|~/admin_page/module_function/module_English/module_DanhSachBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtraa2b1|admin-tao-bai-kiem-tra-a2-b1|~/admin_page/module_function/module_English/module_TaoBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtrangaunhiena2b1|admin-tao-bai-kiem-tra-ngau-nhien-a2-b1|~/admin_page/module_function/module_English/module_TaoBaiKiemTraNgauNhien.aspx");
       
        
        //module chấm điểm
        list.Add("modulechamdiemtienganha2b1|admin-cham-diem-tieng-anh-a2-b1|~/admin_page/module_function/module_ChamDiem/module_ChamDiemTiengAnh_A2B1.aspx");
        list.Add("modulethongkeketquaa2b1|admin-thong-ke-ket-qua-a2-b1|~/admin_page/module_function/module_ChamDiem/mudule_ThongKeKetQuaThi_A2B1.aspx");
        list.Add("modulethongketongtheodea2b1|admin-thong-ke-tong|~/admin_page/module_function/module_ChamDiem/module_BieuDoThongKeKetQuaTheoDe_A2B1.aspx");
        list.Add("modulethongketunglop|admin-ket-qua-kiem-tra|~/admin_page/module_function/module_ChamDiem/module_ThongKeHocSinhLamBai.aspx");
        return list;
    }
}