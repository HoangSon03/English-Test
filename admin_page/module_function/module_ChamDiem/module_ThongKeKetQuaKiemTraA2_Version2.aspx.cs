using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ChamDiem_module_ThongKeKetQuaKiemTraA2_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var getData = from l in db.tbLops
                          where l.khoi_id >= 6 && l.khoi_id < 10
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
                              monhoc = "74",
                              chapter = "119",
                          };
            rpLop.DataSource = getData;
            rpLop.DataBind();
        }
    }
    protected void btnLop_ServerClick(object sender, EventArgs e)
    {
        ////get tất cả hs đã từng làm đề
        var getHS = from t in db.tbTracNghiem_Tests
                    join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                    join rs in db.tbTracNghiem_ResultTests on t.test_id equals rs.test_id
                    join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                    join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                    join l in db.tbLops on hstl.lop_id equals l.lop_id
                    where t.monhoc_id == Convert.ToInt32(txtMonHocId.Value) && t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                    && l.lop_id == Convert.ToInt32(txtLop.Value)
                    group rs by rs.hocsinh_code into k
                    select new
                    {
                        hocsinh_code = k.Key,
                        hocsinh_name = (from hs in db.tbHocSinhs
                                        where hs.hocsinh_code == k.Key
                                        select hs.hocsinh_name).FirstOrDefault(),
                    };

        txtTongHS.Value = getHS.Count()+"";
        txtDSHS.Value = string.Join(";", getHS.OrderBy(x => x.hocsinh_code).Select(hs => hs.hocsinh_name));
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
        txtDSKyNang.Value = string.Join(";", getSkill.Select(hs => hs.baithicate_name));
    }
}