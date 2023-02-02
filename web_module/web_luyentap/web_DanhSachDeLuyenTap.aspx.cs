using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_luyentap_web_DanhSachDeLuyenTap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        //load ds đề của kỹ năng 
        if (Request.Cookies["User_name"] != null)
        {
            string kynang = RouteData.Values["kynang"].ToString();
            var checkHocSinh = (from hs in db.tbHocSinhs
                                join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                join l in db.tbLops on hstl.lop_id equals l.lop_id
                                where hs.hocsinh_code == Request.Cookies["User_name"].Value
                                select new
                                {
                                    hs.hocsinh_id,
                                    l.lop_id,
                                    l.khoi_id
                                }).Single();
            //nếu khối <10 là lấy ds đề của A2, ngược lại là ds đề b1

            if (checkHocSinh.khoi_id < 10)
            {
                var getChuong = from t in db.tbTracNghiem_Tests
                                join d in db.tbTracNghiem_DeThis on t.dethi_id equals d.dethi_id
                                join kn in db.tbTracNghiem_KyNangs on Convert.ToInt32(t.kynang_id) equals kn.kynang_id
                                join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                                join mh in db.tbMonHocs on d.monhoc_id equals mh.monhoc_id
                                where d.monhoc_id == 74 && t.hidden == false && d.hidden == true
                                 && d.hidden == true && c.baithicate_loai == "luyen tap" && kn.kynang_name.Contains(kynang)
                                select new
                                {
                                    d.dethi_id,
                                    d.dethi_name,
                                    t.test_id,
                                    //exercise-reading-b1-{de}-test-{test_id}
                                    link_test = kynang == "reading" ? "/exercise-reading-a2-de-" + d.dethi_id + "-test-" + t.test_id : "/exercise-listening-a2-de-" + d.dethi_id + "-test-" + t.test_id
                                };
                rpDanhSachDe.DataSource = getChuong;
                rpDanhSachDe.DataBind();
            }
            else
            {
                var getChuong = from t in db.tbTracNghiem_Tests
                                join d in db.tbTracNghiem_DeThis on t.dethi_id equals d.dethi_id
                                join kn in db.tbTracNghiem_KyNangs on Convert.ToInt32(t.kynang_id) equals kn.kynang_id
                                join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                                join mh in db.tbMonHocs on d.monhoc_id equals mh.monhoc_id
                                where d.monhoc_id == 72 && t.hidden == false
                                && d.hidden == true && c.baithicate_loai == "luyen tap" && kn.kynang_name.Contains(kynang)
                                select new
                                {
                                    d.dethi_id,
                                    d.dethi_name,
                                    t.test_id,
                                    //exercise-reading-b1-{de}-test-{test_id}
                                    link_test = kynang == "reading" ? "/exercise-reading-b1-de-" + d.dethi_id + "-test-" + t.test_id : "/exercise-listening-b1-de-" + d.dethi_id + "-test-" + t.test_id
                                };
                rpDanhSachDe.DataSource = getChuong;
                rpDanhSachDe.DataBind();

            }
        }
        else
        {
            Response.Redirect("/login-account");
        }
    }
}