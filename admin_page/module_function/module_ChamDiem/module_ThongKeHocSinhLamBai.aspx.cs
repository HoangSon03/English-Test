using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ChamDiem_module_ThongKeHocSinhLamBai : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int sl0, sl25, sl50, sl70, sl80, sl90;
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
            div_BieuDo.Visible = false;
            KyNangA2.Visible = false;
        }
    }

    protected void btnLop_ServerClick(object sender, EventArgs e)
    {
        //////get tất cả hs đã từng làm đề
        //var getHS = from t in db.tbTracNghiem_Tests
        //            join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
        //            join rs in db.tbTracNghiem_ResultTests on t.test_id equals rs.test_id
        //            join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
        //            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
        //            join l in db.tbLops on hstl.lop_id equals l.lop_id
        //            where t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.lesson_id == Convert.ToInt32(txtChapterId.Value)
        //            && l.lop_id == Convert.ToInt32(txtLop.Value)
        //            group rs by rs.hocsinh_code into k
        //            select new
        //            {
        //                hocsinh_code = k.Key,
        //                hocsinh_name = (from hs in db.tbHocSinhs
        //                                where hs.hocsinh_code == k.Key
        //                                select hs.hocsinh_name).FirstOrDefault(),
        //            };

        //txtDSHS.Value = string.Join(";", getHS.OrderBy(x => x.hocsinh_code).Select(hs => hs.hocsinh_name));


        ////get ds các kỹ năng của đề
        var getSkill = from t in db.tbTracNghiem_Tests
                       join c in db.tbTracNghiem_BaiThiCates
                       on t.baithicate_id equals c.baithicate_id
                       where t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                       && t.hidden == false
                       select new
                       {
                           c.baithicate_id,
                           c.baithicate_name,
                           t.test_show,
                           t.monhoc_id,
                           t.test_id,
                       };
        if (txtMonHocId.Value == "72")
        {
            rpKyNang.DataSource = getSkill;
            rpKyNang.DataBind();
            KyNangA2.Visible = false;
        }
        else
        {
            rpKyNang.DataSource = null;
            rpKyNang.DataBind();
            KyNangA2.Visible = true;
        }
        div_BieuDo.Visible = false;
        //txtDSKyNang.Value = string.Join(";", getSkill.Select(hs => hs.baithicate_name));
        //string listPoint = "";
        //string listPercent = "";

        //foreach (var item in getSkill)
        //{
        //    // get điểm của hs từng skill
        //    var getPoint = from rs in db.tbTracNghiem_ResultTests
        //                   join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //                   join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
        //                   join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
        //                   join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
        //                   join l in db.tbLops on hstl.lop_id equals l.lop_id
        //                   where t.test_id == item.test_id && l.lop_id == Convert.ToInt32(txtLop.Value)
        //                   select new
        //                   {
        //                       hs.hocsinh_code,
        //                       hs.hocsinh_name,
        //                       sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
        //                                   where p.resulttest_id == rs.resulttest_id
        //                                   select p.resultchitiet_point).Sum(),
        //                       percent = (from r in db.tbTracNghiem_ResultChiTiets
        //                                  where r.resulttest_id == rs.resulttest_id
        //                                  select r.result_phantram).Sum()  ?? 0,
        //                   };
        //    if (getPoint.Count() == getHS.Count())
        //    {
        //        string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
        //        string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
        //        if (listPoint == "")
        //            listPoint = _point;
        //        else
        //            listPoint = listPoint + "|" + _point;
        //        if (listPercent == "")
        //            listPercent = _percent;
        //        else
        //            listPercent = listPercent + "|" + _percent;
        //    }
        //    else
        //    {
        //        //posts.Where(p => !skipPosts.Any(p2 => p2.ID == p.ID));
        //        //var list = from hs in getHS
        //        //           //where hs.hocsinh_code == ""
        //        //           select new
        //        //           {
        //        //               hs.hocsinh_code,
        //        //               hs.hocsinh_name,
        //        //               sumpoint = "0",
        //        //               percent = "0,0%"
        //        //           };
        //        //var listPoit = from nc in getPoint
        //        //               select new
        //        //               {
        //        //                   nc.hocsinh_code,
        //        //                   nc.hocsinh_name,
        //        //                   sumpoint = "" + nc.sumpoint.ToString(),
        //        //                   percent = nc.percent
        //        //               };
        //        //var list1 = list.Union(listPoit);
        //        var list1 = getHS.Where(hs => !getPoint.Any(p => p.hocsinh_code == hs.hocsinh_code)
        //                                ).Select(x => new { x.hocsinh_code, x.hocsinh_name, sumpoint = "0", percent = Convert.ToDouble(0) }).Union(from nc in getPoint
        //                                                                                                                             select new
        //                                                                                                                             {
        //                                                                                                                                 nc.hocsinh_code,
        //                                                                                                                                 nc.hocsinh_name,
        //                                                                                                                                 sumpoint = "" + nc.sumpoint.ToString(),
        //                                                                                                                                 percent = nc.percent,
        //                                                                                                                             });
        //        string _point = string.Join(";", list1.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
        //        string _percent = string.Join(";", list1.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
        //        if (listPoint == "")
        //            listPoint = _point;
        //        else
        //            listPoint = listPoint + "|" + _point;
        //        if (listPercent == "")
        //            listPercent = _percent;
        //        else
        //            listPercent = listPercent + "|" + _percent;
        //    }
        //    ////var listChuaLam = list1.Where(x => !getPoint.Any(y => y.hocsinh_code == x.hocsinh_code)).Select(x => new { x.hocsinh_code, x.hocsinh_name, x.sumpoint });
        //    //var listChuaLam = list1.Except(getPoint);
        //    //var result = listChuaLam.Union(getPoint);
        //    //string _point = string.Join(";", result.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
        //    //if (listPoint == "")
        //    //    listPoint = _point;
        //    //else
        //    //    listPoint = listPoint + "|" + _point;
        //    //}
        //    //var listTest = from hs in getHS
        //    //               join rs in db.tbTracNghiem_ResultTests on hs.hocsinh_code equals rs.hocsinh_code
        //    //               join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //    //               where t.test_id == item.test_id
        //    //               select new
        //    //               {
        //    //                   hs.hocsinh_code,
        //    //                   rs.resulttest_result,
        //    //               };

        //}
        //txtListPoint.Value = listPoint;
        //txtPercent.Value = listPercent;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtLop.Value + "')", true);
    }

    protected void btnKyNang_ServerClick(object sender, EventArgs e)
    {
        div_BieuDo.Visible = true;
        //get tất cả hs đã từng làm đề
        var getHS = from t in db.tbTracNghiem_Tests
                    join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                    join rs in db.tbTracNghiem_ResultTests on t.test_id equals rs.test_id
                    join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                    join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                    join l in db.tbLops on hstl.lop_id equals l.lop_id
                    where t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                    && l.lop_id == Convert.ToInt32(txtLop.Value) && t.test_id == Convert.ToInt32(txtKyNangID.Value)
                    group rs by rs.hocsinh_code into k
                    select new
                    {
                        hocsinh_code = k.Key,
                        hocsinh_name = (from hs in db.tbHocSinhs
                                        where hs.hocsinh_code == k.Key
                                        select hs.hocsinh_name).FirstOrDefault(),
                    };
        txtDSHS.Value = string.Join(";", getHS.OrderBy(x => x.hocsinh_code).Select(hs => hs.hocsinh_name));
        string listPoint = "";
        string listPercent = "";

        //foreach (var item in getSkill)
        //{
        // get điểm của hs từng skill
        //var getPoint = from hs in getHS
        //               select new
        //               {
        //                   hs.hocsinh_code,
        //                   hs.hocsinh_name,
        //                   sumpoint = 0.,
        //                   percent = 0
        //               };
        if (txtKyNang.Value.Trim() == "Writing" && txtMonHocId.Value.Trim() == "72")//B1
        {
            listPoint = "";
            listPercent = "";
            var getPoint = from rs in db.tbTracNghiem_ResultTests
                           join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                           join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                           join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where t.test_id == Convert.ToInt32(txtKyNangID.Value) && l.lop_id == Convert.ToInt32(txtLop.Value)
                           select new
                           {
                               hs.hocsinh_code,
                               hs.hocsinh_name,
                               sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                           where p.resulttest_id == rs.resulttest_id
                                           select p.resultchitiet_point).Sum() ?? 0,
                               percent = ((from r in db.tbTracNghiem_ResultChiTiets
                                           where r.resulttest_id == rs.resulttest_id
                                           select r.resultchitiet_point).Sum() ?? 0) * 3.33,
                           };
            string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
            string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
            //số lượng đạt từ 0-25%
            var listYeu = from s in getPoint
                          where Convert.ToInt32(s.percent) < 25
                          select s;
            rpDanhSach.DataSource = listYeu;
            rpDanhSach.DataBind();
            sl0 = listYeu.Count();
            //số lượng đạt từ 25-50%
            var listTrungBinh = from s in getPoint
                                where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
                                select s;
            rpDanhSachTrungBinh.DataSource = listTrungBinh;
            rpDanhSachTrungBinh.DataBind();
            sl25 = listTrungBinh.Count();
            //số lượng đạt từ 50-70%
            var listVua = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
                          select s;
            rpDanhSachVua.DataSource = listVua;
            rpDanhSachVua.DataBind();
            sl50 = listVua.Count();
            //số lượng đạt từ 70-80%
            var listKha = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
                          select s;
            rpDanhSachKha.DataSource = listKha;
            rpDanhSachKha.DataBind();
            sl70 = listKha.Count();
            //số lượng đạt từ 80-90%
            var listGioi = from s in getPoint
                           where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
                           select s;
            rpDanhSachGioi.DataSource = listGioi;
            rpDanhSachGioi.DataBind();
            sl80 = listGioi.Count();
            //số lượng đạt từ >90%
            var listXuatSac = from s in getPoint
                              where Convert.ToInt32(s.percent) >= 90
                              select s;
            rpDanhSachXuatSac.DataSource = listXuatSac;
            rpDanhSachXuatSac.DataBind();
            sl90 = listXuatSac.Count();
        }
        else if (txtKyNang.Value.Trim() == "Writing" && txtMonHocId.Value.Trim() == "74")//A2
        {
            listPoint = "";
            listPercent = "";
            var getHS1 = from t in db.tbTracNghiem_Tests
                         join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                         join rs in db.tbTracNghiem_ResultTests on t.test_id equals rs.test_id
                         join rsct in db.tbTracNghiem_ResultChiTiets on rs.resulttest_id equals rsct.resulttest_id
                         join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                         join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         where (t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                         && l.lop_id == Convert.ToInt32(txtLop.Value)) && (rsct.question_id == 294 || rsct.question_id == 295)
                         //|| (t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                         //&& l.lop_id == Convert.ToInt32(txtLop.Value) && rsct.question_id == 295)
                         group rs by rs.hocsinh_code into k
                         select new
                         {
                             hocsinh_code = k.Key,
                             hocsinh_name = (from hs in db.tbHocSinhs
                                             where hs.hocsinh_code == k.Key
                                             select hs.hocsinh_name).FirstOrDefault(),
                             sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                         join r in db.tbTracNghiem_ResultTests on p.resulttest_id equals r.resulttest_id
                                         where (r.hocsinh_code == k.Key && p.question_id == 294)
                                         || (r.hocsinh_code == k.Key && p.question_id == 295)
                                         select p.resultchitiet_point).Sum() ?? 0,
                             percent = ((from p in db.tbTracNghiem_ResultChiTiets
                                         join r in db.tbTracNghiem_ResultTests on p.resulttest_id equals r.resulttest_id
                                         where (r.hocsinh_code == k.Key && p.question_id == 294)
                                         || (r.hocsinh_code == k.Key && p.question_id == 295)
                                         select p.resultchitiet_point).Sum() ?? 0) * 5,
                         };
            txtDSHS.Value = string.Join(";", getHS1.OrderBy(x => x.hocsinh_code).Select(hs => hs.hocsinh_name));
            string _point = string.Join(";", getHS1.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
            string _percent = string.Join(";", getHS1.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
            //số lượng đạt từ 0-25%
            var listYeu = from s in getHS1
                          where Convert.ToInt32(s.percent) < 25
                          select s;
            rpDanhSach.DataSource = listYeu;
            rpDanhSach.DataBind();
            sl0 = listYeu.Count();
            //số lượng đạt từ 25-50%
            var listTrungBinh = from s in getHS1
                                where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
                                select s;
            rpDanhSachTrungBinh.DataSource = listTrungBinh;
            rpDanhSachTrungBinh.DataBind();
            sl25 = listTrungBinh.Count();
            //số lượng đạt từ 50-70%
            var listVua = from s in getHS1
                          where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
                          select s;
            rpDanhSachVua.DataSource = listVua;
            rpDanhSachVua.DataBind();
            sl50 = listVua.Count();
            //số lượng đạt từ 70-80%
            var listKha = from s in getHS1
                          where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
                          select s;
            rpDanhSachKha.DataSource = listKha;
            rpDanhSachKha.DataBind();
            sl70 = listKha.Count();
            //số lượng đạt từ 80-90%
            var listGioi = from s in getHS1
                           where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
                           select s;
            rpDanhSachGioi.DataSource = listGioi;
            rpDanhSachGioi.DataBind();
            sl80 = listGioi.Count();
            //số lượng đạt từ >90%
            var listXuatSac = from s in getHS1
                              where Convert.ToInt32(s.percent) >= 90
                              select s;
            rpDanhSachXuatSac.DataSource = listXuatSac;
            rpDanhSachXuatSac.DataBind();
            sl90 = listXuatSac.Count();
        }
        else if (txtKyNang.Value.Trim() == "Speaking" && txtMonHocId.Value.Trim() == "72")//B1
        {
            listPoint = "";
            listPercent = "";
            var getPoint = from rs in db.tbTracNghiem_ResultTests
                           join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                           join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                           join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where t.test_id == Convert.ToInt32(txtKyNangID.Value) && l.lop_id == Convert.ToInt32(txtLop.Value)
                           select new
                           {
                               hs.hocsinh_code,
                               hs.hocsinh_name,
                               sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                           where p.resulttest_id == rs.resulttest_id
                                           select p.resultchitiet_point).Sum() ?? 0,
                               percent = ((from r in db.tbTracNghiem_ResultChiTiets
                                           where r.resulttest_id == rs.resulttest_id
                                           select r.resultchitiet_point).Sum() ?? 0) * 5,
                           };
            string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
            string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
            //số lượng đạt từ 0-25%
            var listYeu = from s in getPoint
                          where Convert.ToInt32(s.percent) < 25
                          select s;
            rpDanhSach.DataSource = listYeu;
            rpDanhSach.DataBind();
            sl0 = listYeu.Count();
            //số lượng đạt từ 25-50%
            var listTrungBinh = from s in getPoint
                                where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
                                select s;
            rpDanhSachTrungBinh.DataSource = listTrungBinh;
            rpDanhSachTrungBinh.DataBind();
            sl25 = listTrungBinh.Count();
            //số lượng đạt từ 50-70%
            var listVua = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
                          select s;
            rpDanhSachVua.DataSource = listVua;
            rpDanhSachVua.DataBind();
            sl50 = listVua.Count();
            //số lượng đạt từ 70-80%
            var listKha = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
                          select s;
            rpDanhSachKha.DataSource = listKha;
            rpDanhSachKha.DataBind();
            sl70 = listKha.Count();
            //số lượng đạt từ 80-90%
            var listGioi = from s in getPoint
                           where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
                           select s;
            rpDanhSachGioi.DataSource = listGioi;
            rpDanhSachGioi.DataBind();
            sl80 = listGioi.Count();
            //số lượng đạt từ >90%
            var listXuatSac = from s in getPoint
                              where Convert.ToInt32(s.percent) >= 90
                              select s;
            rpDanhSachXuatSac.DataSource = listXuatSac;
            rpDanhSachXuatSac.DataBind();
            sl90 = listXuatSac.Count();
        }
        else if (txtKyNang.Value.Trim() == "Speaking" && txtMonHocId.Value.Trim() == "74")//A2
        {
            listPoint = "";
            listPercent = "";
            var getPoint = from rs in db.tbTracNghiem_ResultTests
                           join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                           join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                           join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where t.test_id == Convert.ToInt32(txtKyNangID.Value) && l.lop_id == Convert.ToInt32(txtLop.Value)
                           select new
                           {
                               hs.hocsinh_code,
                               hs.hocsinh_name,
                               sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                           where p.resulttest_id == rs.resulttest_id
                                           select p.resultchitiet_point).Sum() ?? 0,
                               percent = ((from r in db.tbTracNghiem_ResultChiTiets
                                           where r.resulttest_id == rs.resulttest_id
                                           select r.resultchitiet_point).Sum() ?? 0) * 4,
                           };
            string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
            string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
            //số lượng đạt từ 0-25%
            var listYeu = from s in getPoint
                          where Convert.ToInt32(s.percent) < 25
                          select s;
            rpDanhSach.DataSource = listYeu;
            rpDanhSach.DataBind();
            sl0 = listYeu.Count();
            //số lượng đạt từ 25-50%
            var listTrungBinh = from s in getPoint
                                where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
                                select s;
            rpDanhSachTrungBinh.DataSource = listTrungBinh;
            rpDanhSachTrungBinh.DataBind();
            sl25 = listTrungBinh.Count();
            //số lượng đạt từ 50-70%
            var listVua = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
                          select s;
            rpDanhSachVua.DataSource = listVua;
            rpDanhSachVua.DataBind();
            sl50 = listVua.Count();
            //số lượng đạt từ 70-80%
            var listKha = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
                          select s;
            rpDanhSachKha.DataSource = listKha;
            rpDanhSachKha.DataBind();
            sl70 = listKha.Count();
            //số lượng đạt từ 80-90%
            var listGioi = from s in getPoint
                           where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
                           select s;
            rpDanhSachGioi.DataSource = listGioi;
            rpDanhSachGioi.DataBind();
            sl80 = listGioi.Count();
            //số lượng đạt từ >90%
            var listXuatSac = from s in getPoint
                              where Convert.ToInt32(s.percent) >= 90
                              select s;
            rpDanhSachXuatSac.DataSource = listXuatSac;
            rpDanhSachXuatSac.DataBind();
            sl90 = listXuatSac.Count();
        }
        else
        {
            var getPoint = from rs in db.tbTracNghiem_ResultTests
                           join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                           join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                           join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where t.test_id == Convert.ToInt32(txtKyNangID.Value) && l.lop_id == Convert.ToInt32(txtLop.Value)
                           select new
                           {
                               hs.hocsinh_code,
                               hs.hocsinh_name,
                               sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                           where p.resulttest_id == rs.resulttest_id
                                           select p.resultchitiet_point).Sum() ?? 0,
                               percent = (from r in db.tbTracNghiem_ResultChiTiets
                                          where r.resulttest_id == rs.resulttest_id
                                          select r.result_phantram).Sum() ?? 0,
                           };
            string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
            string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
            if (listPoint == "")
                listPoint = _point;
            else
                listPoint = listPoint + "|" + _point;
            if (listPercent == "")
                listPercent = _percent;
            else
                listPercent = listPercent + "|" + _percent;
            //số lượng đạt từ 0-25%
            var listYeu = from s in getPoint
                          where Convert.ToInt32(s.percent) < 25
                          select s;
            rpDanhSach.DataSource = listYeu;
            rpDanhSach.DataBind();
            sl0 = listYeu.Count();
            //sl0 = (from s in getPoint
            //       where Convert.ToInt32(s.percent) < 25
            //       select s).Count();
            //số lượng đạt từ 25-50%
            var listTrungBinh = from s in getPoint
                                where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
                                select s;
            rpDanhSachTrungBinh.DataSource = listTrungBinh;
            rpDanhSachTrungBinh.DataBind();
            sl25 = listTrungBinh.Count();
            //(from s in getPoint
            //    where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
            //    select s).Count();
            //số lượng đạt từ 50-70%
            var listVua = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
                          select s;
            rpDanhSachVua.DataSource = listVua;
            rpDanhSachVua.DataBind();
            sl50 = listVua.Count();
            //(from s in getPoint
            //    where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
            //    select s).Count();
            //số lượng đạt từ 70-80%
            var listKha = from s in getPoint
                          where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
                          select s;
            rpDanhSachKha.DataSource = listKha;
            rpDanhSachKha.DataBind();
            sl70 = listKha.Count();
            //(from s in getPoint
            //    where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
            //    select s).Count();
            //số lượng đạt từ 80-90%
            var listGioi = from s in getPoint
                           where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
                           select s;
            rpDanhSachGioi.DataSource = listGioi;
            rpDanhSachGioi.DataBind();
            sl80 = listGioi.Count();
            //(from s in getPoint
            //    where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
            //    select s).Count();
            //số lượng đạt từ >90%
            var listXuatSac = from s in getPoint
                              where Convert.ToInt32(s.percent) >= 90
                              select s;
            rpDanhSachXuatSac.DataSource = listXuatSac;
            rpDanhSachXuatSac.DataBind();
            sl90 = listXuatSac.Count();
            //(from s in getPoint
            //    where Convert.ToInt32(s.percent) >= 90 //&& Convert.ToInt32(s.percent) < 70
            //    select s).Count();
        }
        //var getPoint = from rs in db.tbTracNghiem_ResultTests
        //               join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //               join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
        //               join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
        //               join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
        //               join l in db.tbLops on hstl.lop_id equals l.lop_id
        //               where t.test_id == Convert.ToInt32(txtKyNangID.Value) && l.lop_id == Convert.ToInt32(txtLop.Value)
        //               select new
        //               {
        //                   hs.hocsinh_code,
        //                   hs.hocsinh_name,
        //                   sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
        //                               where p.resulttest_id == rs.resulttest_id
        //                               select p.resultchitiet_point).Sum(),
        //                   percent = (from r in db.tbTracNghiem_ResultChiTiets
        //                              where r.resulttest_id == rs.resulttest_id
        //                              select r.result_phantram).Sum() ?? 0,
        //};
        //if (getPoint.Count() == getHS.Count())
        //{
        //string _point = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
        //string _percent = string.Join(";", getPoint.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
        //if (listPoint == "")
        //    listPoint = _point;
        //else
        //    listPoint = listPoint + "|" + _point;
        //if (listPercent == "")
        //    listPercent = _percent;
        //else
        //    listPercent = listPercent + "|" + _percent;
        ////số lượng đạt từ 0-25%
        //sl0 = (from s in getPoint
        //       where Convert.ToInt32(s.percent) < 25
        //       select s).Count();
        ////số lượng đạt từ 25-50%
        //sl25 = (from s in getPoint
        //        where Convert.ToInt32(s.percent) >= 25 && Convert.ToInt32(s.percent) < 50
        //        select s).Count();
        ////số lượng đạt từ 50-70%
        //sl50 = (from s in getPoint
        //        where Convert.ToInt32(s.percent) >= 50 && Convert.ToInt32(s.percent) < 70
        //        select s).Count();
        ////số lượng đạt từ 70-80%
        //sl70 = (from s in getPoint
        //        where Convert.ToInt32(s.percent) >= 70 && Convert.ToInt32(s.percent) < 80
        //        select s).Count();
        ////số lượng đạt từ 80-90%
        //sl80 = (from s in getPoint
        //        where Convert.ToInt32(s.percent) >= 80 && Convert.ToInt32(s.percent) < 90
        //        select s).Count();
        ////số lượng đạt từ >90%
        //sl90 = (from s in getPoint
        //        where Convert.ToInt32(s.percent) >= 90 //&& Convert.ToInt32(s.percent) < 70
        //        select s).Count();

        // }
        //else
        //{
        //    var list1 = getHS.Where(hs => !getPoint.Any(p => p.hocsinh_code == hs.hocsinh_code)
        //                            ).Select(x => new { x.hocsinh_code, x.hocsinh_name, sumpoint = "0", percent = Convert.ToDouble(0) }).Union(from nc in getPoint
        //                                                                                                                                       select new
        //                                                                                                                                       {
        //                                                                                                                                           nc.hocsinh_code,
        //                                                                                                                                           nc.hocsinh_name,
        //                                                                                                                                           sumpoint = "" + nc.sumpoint.ToString(),
        //                                                                                                                                           percent = nc.percent,
        //                                                                                                                                       });
        //    string _point = string.Join(";", list1.OrderBy(x => x.hocsinh_code).Select(hs => hs.sumpoint));
        //    string _percent = string.Join(";", list1.OrderBy(x => x.hocsinh_code).Select(hs => hs.percent));
        //    if (listPoint == "")
        //        listPoint = _point;
        //    else
        //        listPoint = listPoint + "|" + _point;
        //    if (listPercent == "")
        //        listPercent = _percent;
        //    else
        //        listPercent = listPercent + "|" + _percent;
        //}
        //}
        txtListPoint.Value = listPoint;
        txtPercent.Value = listPercent;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtLop.Value + "');myActiveKyNang('" + txtKyNangID.Value + "')", true);
    }
}