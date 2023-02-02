using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ChamDiem_module_BieuDoThongKeTheoKyNang_A2B1 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get ds môn học của tiếng anh (a2,b1)
            var getMonHoc = from mhck in db.tbMonHocCuaKhois
                            join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                            where mhck.khoi_id == 18 && mhck.hidden == true
                            orderby mh.monhoc_name ascending
                            select new
                            {
                                mh.monhoc_id,
                                mh.monhoc_name,
                                mhck.khoi_id
                            };

            rpMonHoc.DataSource = getMonHoc;
            rpMonHoc.DataBind();
        }
    }
    public class KyNang
    {
        public string kynang_code { get; set; }
        public string kynang_name { get; set; }
    }
    protected void btnMonHoc_ServerClick(object sender, EventArgs e)
    {
        //hiện thị danh sách kỹ năng của môn học
        if (txtMonHocId.Value == "72")//B1
        {
            List<KyNang> kyNang = new List<KyNang>();
            KyNang r = new KyNang();
            r.kynang_code = "reading";
            r.kynang_name = "Reading";
            kyNang.Add(r);
            KyNang w = new KyNang();
            w.kynang_code = "writing";
            w.kynang_name = "Writing";
            kyNang.Add(w);
            KyNang l = new KyNang();
            l.kynang_code = "listening";
            l.kynang_name = "Listening";
            kyNang.Add(l);
            KyNang s = new KyNang();
            s.kynang_code = "speaking";
            s.kynang_name = "Speaking";
            kyNang.Add(s);
            rpKyNang.DataSource = kyNang;
            rpKyNang.DataBind();
        }
        else
        {
            List<KyNang> kyNang = new List<KyNang>();
            KyNang r = new KyNang();
            r.kynang_code = "reading";
            r.kynang_name = "Reading & Writing";
            kyNang.Add(r);
            //KyNang w = new KyNang();
            //w.kynang_code = "writing";
            //w.kynang_name = "Writing";
            //kyNang.Add(w);
            KyNang l = new KyNang();
            l.kynang_code = "listening";
            l.kynang_name = "Listening";
            kyNang.Add(l);
            KyNang s = new KyNang();
            s.kynang_code = "speaking";
            s.kynang_name = "Speaking";
            kyNang.Add(s);
            rpKyNang.DataSource = kyNang;
            rpKyNang.DataBind();
        }
        //var getCh = from c in db.tbTracNghiem_Chapters
        //            join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
        //            join k in db.tbKhois on c.khoi_id equals k.khoi_id
        //            where c.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
        //            && c.hidden == true //c.khoi_id == _idKhoi &&
        //            select c;

        //rpDanhSachDe.DataSource = getCh;
        //rpDanhSachDe.DataBind();
        div_De.Visible = false;
        //div_KyNang.Visible = false;
        //div_KetQua.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "')", true);
    }

    protected void btnKyNang_ServerClick(object sender, EventArgs e)
    {
        div_De.Visible = true;

        //lấy ds đề
        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
                    && c.hidden == true //c.khoi_id == _idKhoi &&
                    select c;
        //foreach (var item in getCh)
        //{
        //    //get ds hs làm đề
        //    var listHS = from rs in db.tbTracNghiem_ResultTests
        //                 join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //                 join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
        //                 join c in db.tbTracNghiem_Chapters on t.lesson_id equals c.chapter_id
        //                 join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
        //                 where c.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
        //                 && cate.baithicate_name.Contains(txtKyNang.Value)
        //                 && t.lesson_id == Convert.ToInt32(item.chapter_id)
        //                 select new
        //                 {
        //                     hs.hocsinh_code,
        //                     hs.hocsinh_name,
        //                     c.chapter_name,
        //                     sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
        //                                 where p.resulttest_id == rs.resulttest_id
        //                                 select p.resultchitiet_point).Sum(),
        //                 };

        //}
        ////get ds hs làm đề
        var listHS = from rs in db.tbTracNghiem_ResultTests
                     join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                     join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                     join c in db.tbTracNghiem_Chapters on t.lesson_id equals c.chapter_id
                     join hs in db.tbHocSinhs on rs.hocsinh_code equals hs.hocsinh_code
                     where c.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
                     && cate.baithicate_name.Contains(txtKyNang.Value)
                     group t by t.lesson_id into k
                     select new
                     {
                         hocsinh_code = (from h in db.tbTracNghiem_ResultTests
                                         where h.test_id == k.First().test_id
                                         select h.hocsinh_code).FirstOrDefault(),
                         //hs.hocsinh_name,
                         chapter_name = (from ct in db.tbTracNghiem_Chapters
                                         where ct.chapter_id == k.First().lesson_id
                                         select ct.chapter_name).FirstOrDefault(),
                         sumpoint = (from p in db.tbTracNghiem_ResultChiTiets
                                     join kq in db.tbTracNghiem_ResultTests on p.resulttest_id equals kq.resulttest_id
                                     where kq.test_id == k.First().test_id
                                     select p.resultchitiet_point).Sum(),
                     };
        txtHS_Code.Value = string.Join("|", listHS.Select(x => x.hocsinh_code));
        //txtDSHS.Value = string.Join("|", listHS.Select(x => x.hocsinh_name));
        txtDSDe.Value = string.Join("|", listHS.Select(x => x.chapter_name));
        txtListPoint.Value = string.Join("|", listHS.Select(x => x.sumpoint));


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "');myActiveKyNang('" + txtKyNang.Value + "')", true);
    }
}