using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_module_ThongKeKetQuaTungHocSinh : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            var getData = from l in db.tbLops
                          where l.khoi_id >= 6
                          orderby l.lop_position
                          select new
                          {
                              l.lop_id,
                              l.lop_name,
                              dalam = (from rs in db.tbTracNghiem_ResultTests
                                       join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                                       join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                       join lop in db.tbLops on hstl.lop_id equals l.lop_id
                                       where lop.lop_id == l.lop_id
                                       group rs by rs.hocsinh_code into k
                                       select k).Count(),
                              //tong = (from hs in db.tbHocSinhs
                              //        join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                              //        join lop in db.tbLops on hstl.lop_id equals l.lop_id
                              //        where lop.lop_id == l.lop_id && hstl.namhoc_id == 5 && hs.hidden == null
                              //        select hs).Count(),
                              monhoc = l.khoi_id < 10 ? "74" : "72",
                              chapter = l.khoi_id < 10 ? "119" : "112",
                          };
            rpLop.DataSource = getData;
            rpLop.DataBind();
            //div_BieuDo.Visible = false;
            div_KyNang.Visible = false;
        }
    }

    protected void btnXemLop_ServerClick(object sender, EventArgs e)
    {
        //load ds học sinh
        var getHocSinh = from hs in db.tbHocSinhs
                         join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         where l.lop_id == Convert.ToInt32(txtLop.Value)
                         select new
                         {
                             hs.hocsinh_id,
                             hs.hocsinh_code,
                             hs.hocsinh_name,
                             l.lop_id,
                             l.lop_name
                         };
        rpHocSinh.DataSource = getHocSinh;
        rpHocSinh.DataBind();
        div_KyNang.Visible = false;
        //div_BieuDo.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveLop('" + txtLop.Value + "')", true);
    }

    protected void btnXemHocSinh_ServerClick(object sender, EventArgs e)
    {
        //thống kê kết qua chung qua các đề
        div_KyNang.Visible = true;
        //div_BieuDo.Visible = false;
        string[] arrKyNang = { "Reading", "Listening" };
        txtDSKyNang.Value = string.Join(",", arrKyNang); ;
        string str_listDe = "";
        string str_listPoint = "";
        string str_listPercent = "";
        foreach (var kynang in arrKyNang)
        {
            var listDe = from t in db.tbTracNghiem_Tests
                         join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                         join de in db.tbTracNghiem_DeThis on t.dethi_id equals de.dethi_id
                         where cate.baithicate_name.Contains(kynang) && cate.baithicate_loai == "luyen tap"
                         && t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.hidden == false
                         select new
                         {
                             de.dethi_id,
                             de.dethi_name,
                             t.test_id,
                         };
            string _de = string.Join("|", listDe.Select(hs => hs.dethi_name));
            if (str_listDe == "")
                str_listDe = _de;
            else
                str_listDe = str_listDe + ";" + _de;
            string listPoint = "";
            string listPercent = "";
            foreach (var de in listDe)
            {
                var getPoint = from rs in db.tbTracNghiem_ResultTests
                               join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                               where rs.test_id == de.test_id &&
                               rs.hocsinh_code == txtHocSinh_ID.Value && rs.result_type == 2 && t.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
                               select new
                               {
                                   sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                               where p.resulttest_id == rs.resulttest_id
                                               select p.resultchitiet_point).Sum() ?? 0,
                                   percent = (from r in db.tbTracNghiem_ResultChiTiets
                                              where r.resulttest_id == rs.resulttest_id
                                              select r.result_phantram).Sum() ?? 0,
                               };
                string _point = string.Join(";", getPoint.OrderByDescending(x => x.sumpoint).Select(hs => hs.sumpoint).FirstOrDefault());
                string _percent = string.Join(";", getPoint.OrderByDescending(x => x.percent).Select(hs => hs.percent).FirstOrDefault());
                if (listPoint == "")
                    listPoint = _point;
                else
                    listPoint = listPoint + "|" + _point;
                if (listPercent == "")
                    listPercent = _percent;
                else
                    listPercent = listPercent + "|" + _percent;
            }
            if (str_listPoint == "")
                str_listPoint = listPoint;
            else
                str_listPoint = str_listPoint + ";" + listPoint;
            if (str_listPercent == "")
                str_listPercent = listPercent;
            else
                str_listPercent = str_listPercent + ";" + listPercent;
        }
        txtDSDe.Value = str_listDe;
        txtDSDiem.Value = str_listPoint;
        txtDSPhanTram.Value = str_listPercent;

        var getDe = from t in db.tbTracNghiem_Tests
                    join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                    join de in db.tbTracNghiem_DeThis on t.dethi_id equals de.dethi_id
                    where cate.baithicate_loai == "luyen tap"
                    && t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.hidden == false
                    group de by de.dethi_id into k
                    select new
                    {
                        dethi_id = k.Key,
                        dethi_name = k.First().dethi_name,
                        //t.test_id,
                    };
        rpDanhSachDe.DataSource = getDe;
        rpDanhSachDe.DataBind();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveLop('" + txtLop.Value + "'); myActiveHocSinh('" + txtHocSinh_ID.Value + "')", true);
    }

    protected void btnKyNang_ServerClick(object sender, EventArgs e)
    {
        //div_BieuDo.Visible = true;
        //get tất cả các đề mà hs đã làm
        var listDe = from rs in db.tbTracNghiem_ResultTests
                     join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                     join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                     join de in db.tbTracNghiem_DeThis on t.dethi_id equals de.dethi_id
                     where rs.hocsinh_code == txtHocSinh_ID.Value && rs.result_type == 2 && t.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
                     && cate.baithicate_name.Contains(txtKyNang.Value)
                     select new
                     {
                         rs.resulttest_id,
                         de.dethi_id,
                         de.dethi_name,
                         t.test_id,
                         //sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                         //            where p.resulttest_id == rs.resulttest_id
                         //            select p.resultchitiet_point).Sum() ?? 0,
                         //percent = (from r in db.tbTracNghiem_ResultChiTiets
                         //           where r.resulttest_id == rs.resulttest_id
                         //           select r.result_phantram).Sum() ?? 0,
                     };
        txtDSDe.Value = string.Join(";", listDe.GroupBy(x => x.dethi_name).Select(x => x.Key));
        //rpDanhSachDe.DataSource = from d in listDe
        //                          group d by d.dethi_id into k
        //                          select new
        //                          {
        //                              dethi_id = k.Key,
        //                              dethi_name = k.First().dethi_name,
        //                          };
        //rpDanhSachDe.DataBind();
        ////duyệt từng để đã làm để lấy kết quả
        string listPoint = "";
        string listPercent = "";
        foreach (var item in listDe)
        {
            var getPoint = from rs in db.tbTracNghiem_ResultTests
                           join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                           where rs.test_id == item.test_id
                           select new
                           {
                               sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                           where p.resulttest_id == rs.resulttest_id
                                           select p.resultchitiet_point).Sum() ?? 0,
                               percent = (from r in db.tbTracNghiem_ResultChiTiets
                                          where r.resulttest_id == rs.resulttest_id
                                          select r.result_phantram).Sum() ?? 0,
                           };
            string _point = string.Join(";", getPoint.OrderByDescending(x => x.sumpoint).Select(hs => hs.sumpoint).FirstOrDefault());
            string _percent = string.Join(";", getPoint.OrderByDescending(x => x.percent).Select(hs => hs.percent).FirstOrDefault());
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
        }
        txtListPoint.Value = listPoint;
        txtPercent.Value = listPercent;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveLop('" + txtLop.Value + "'); myActiveHocSinh('" + txtHocSinh_ID.Value + "'); myActiveKyNang('" + txtKyNang.Value + "')", true);
    }

    protected void btnXemDe_ServerClick(object sender, EventArgs e)
    {
        //get ds kỹ năng của đề
        var getSkill = from t in db.tbTracNghiem_Tests
                       join kn in db.tbTracNghiem_KyNangs on t.kynang_id equals kn.kynang_id + ""
                       where t.dethi_id == Convert.ToInt32(txtDeThiId.Value) && t.hidden==false
                       select new
                       {
                           kn.kynang_id,
                           kn.kynang_name,
                       };
        txtKyNang.Value = string.Join(";", getSkill.Select(x => x.kynang_name));

        string str_days = "";
        string str_phantram = "";
        foreach (var item in getSkill)
        {
            //lấy ds các ngày làm bài luyện tập
            var result = from rs in db.tbTracNghiem_ResultTests
                         join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                         where t.dethi_id == Convert.ToInt32(txtDeThiId.Value) && rs.hocsinh_code == txtHocSinh_ID.Value
                         && t.kynang_id == item.kynang_id + "" && t.hidden == false
                         select new
                         {
                             rs.resulttest_id,
                             rs.resulttest_datetime,
                             t.test_id
                         };
            string _day = string.Join(";", result.Select(x => Convert.ToDateTime(x.resulttest_datetime).ToShortDateString()));
            if (str_days == "")
                str_days = _day;
            else
                str_days = str_days + "|" + _day;
            //lấy kết quả làm chi tiết
            string listPercent = "";
            foreach (var rs in result)
            {
                var getPoint = from rst in db.tbTracNghiem_ResultTests
                               join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                               where rst.resulttest_id == rs.resulttest_id
                               select new
                               {
                                   sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                               where p.resulttest_id == rst.resulttest_id
                                               select p.resultchitiet_point).Sum() ?? 0,
                                   percent = (from r in db.tbTracNghiem_ResultChiTiets
                                              where r.resulttest_id == rst.resulttest_id
                                              select r.result_phantram).Sum() ?? 0,
                               };
                string _percent = string.Join(";", getPoint.Select(hs => hs.percent));
                if (listPercent == "")
                    listPercent = _percent;
                else
                    listPercent = listPercent + "|" + _percent;
            }
            if (str_phantram == "")
                str_phantram = listPercent;
            else
                str_phantram = str_phantram + "@" + listPercent;
        }
        txtNgay.Value = str_days;
        txtPercent.Value = str_phantram;

        ////kiểm tra xem hs làm đề được chọn bao nhiêu lần
        //var detail = from rs in db.tbTracNghiem_ResultTests
        //             join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //             where t.dethi_id == Convert.ToInt32(txtDeThiId.Value) && rs.hocsinh_code == txtHocSinh_ID.Value
        //             select new
        //             {
        //                 rs.resulttest_id,
        //                 rs.resulttest_datetime,
        //                 t.test_id
        //             };

        //txtNgay.Value = string.Join(";", detail.Select(x => Convert.ToDateTime(x.resulttest_datetime).ToShortDateString()));
        //string listPoint = "";
        //string listPercent = "";
        //foreach (var item in detail)
        //{
        //    //var getPoint = from rs in db.tbTracNghiem_ResultTests
        //    //               join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //    //               where t.dethi_id == Convert.ToInt32(txtDeThiId.Value) && rs.hocsinh_code == txtHocSinh_ID.Value
        //    //               select new
        //    //               {
        //    //                   sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
        //    //                               where p.resulttest_id == rs.resulttest_id
        //    //                               select p.resultchitiet_point).Sum() ?? 0,
        //    //                   percent = (from r in db.tbTracNghiem_ResultChiTiets
        //    //                              where r.resulttest_id == rs.resulttest_id
        //    //                              select r.result_phantram).Sum() ?? 0,
        //    //               };
        //    var getPoint = (from p in db.tbTracNghiem_ResultChiTiets
        //                    where p.resulttest_id == item.resulttest_id
        //                    select new
        //                    {
        //                        p.resultchitiet_point,
        //                        p.result_phantram,
        //                    });
        //    string _point = string.Join(";", getPoint.Sum(x => x.resultchitiet_point));
        //    string _percent = string.Join(";", getPoint.Sum(x => x.result_phantram));
        //    if (listPoint == "")
        //        listPoint = _point;
        //    else
        //        listPoint = listPoint + "|" + _point;
        //    if (listPercent == "")
        //        listPercent = _percent;
        //    else
        //        listPercent = listPercent + "|" + _percent;
        //}
        //txtDiem.Value = listPoint;
        //txtPhanTram.Value = listPercent;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveLop('" + txtLop.Value + "'); myActiveHocSinh('" + txtHocSinh_ID.Value + "'); myActiveDeThi('" + txtDeThiId.Value + "')", true);
    }
}