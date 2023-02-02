using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_DanhSachBaiLuyenTap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            var user = (from u in db.admin_Users
                        where u.username_username == Request.Cookies["UserName"].Value
                        select u).FirstOrDefault();

            //if(user.groupuser_id == 1 || user.groupuser_id == 2 || user.groupuser_id == 3 || user.groupuser_id == 4) //only root or admin or teacher or worker can access 
            //{
            _idUser = user.username_id;
            //}
            //else
            //{
            //    _idUser = 0;
            //}
        }
        getdata();
    }
    private void getdata()
    {
        //var getdata = (from test in db.tbTracNghiem_Tests
        //              join khoi in db.tbKhois on test.khoi_id equals khoi.khoi_id
        //              join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
        //             // join c in db.tbTracNghiem_Chapters on khoi.khoi_id equals c.khoi_id
        //              join lt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals lt.luyentap_id
        //              join user in db.admin_Users on test.username_id equals user.username_id
        //              where user.username_username == Request.Cookies["UserName"].Value
        //              && test.luyentap_id != null
        //              && lt.luyentap_status == 1
        //              select new
        //              {
        //                  test.test_id,
        //                  khoi.khoi_name,
        //                  lt.luyentap_name,
        //                  lt.luyentap_id,
        //                  test.test_createdate,
        //                //  c.chapter_name,
        //                  mh.monhoc_name,
        //              }).OrderByDescending(test => test.test_createdate);

        var getdata = (from test in db.tbTracNghiem_Tests
                       join khoi in db.tbKhois on test.khoi_id equals khoi.khoi_id
                       join ch in db.tbTracNghiem_DeThis on test.dethi_id equals ch.dethi_id
                       join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                       //join ls in db.tbTracNghiem_Lessons on test.lesson_id equals ls.lesson_id
                       //join c in db.tbTracNghiem_Chapters on khoi.khoi_id equals c.khoi_id
                       join c in db.tbTracNghiem_BaiThiCates on test.baithicate_id equals c.baithicate_id
                       join user in db.admin_Users on test.username_id equals user.username_id
                       where user.username_id == _idUser
                      && c.baithicate_loai == "luyen tap"
                       && test.hidden == false
                       select new
                       {
                           test.test_id,
                           khoi.khoi_name,
                           c.baithicate_name,
                           c.baithicate_id,
                           test.test_createdate,
                           //ls.lesson_name,
                           ch.dethi_name,
                           mh.monhoc_name,
                           test_trangthai = test.test_trangthai == null ? "Chưa chuyển duyệt" : test.test_trangthai
                       }).OrderByDescending(test => test.test_createdate);
        grvList.DataSource = getdata;
        grvList.DataBind();

    }
    protected void build_url_Click(object sender, EventArgs e)
    {
        //exercise-listening-a2-de-3-test-207
        var test = (from t in db.tbTracNghiem_Tests
                        //join btk in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals btk.baithicate_id
                    where t.test_id == Convert.ToInt32(id_key.Value)
                    select new
                    {
                        //t.test_id,
                        //t.khoi_id,
                        //btk.baithicate_name,
                        t.test_link,
                    }).SingleOrDefault();

        string[] arrList = test.test_link.Split('/');
        string str_first = arrList[0];
        string str_sec = arrList[1];
        string duongdan = "http://english.vietnhatschool.edu.vn/exercise-" + "truy-cap-" + str_first + "-" + _idUser + "/" + str_sec;
        url.Value = duongdan;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "geturl()", true);
    }

    protected void btnChiTiet_ServerClick(object sender, EventArgs e)
    {
        try
        {
            List<object> selectedId = grvList.GetSelectedFieldValues(new string[] { "test_id" });
            if (selectedId.Count == 1)
            {
                _id = Convert.ToInt32(selectedId[0]);
                var checkDe = (from t in db.tbTracNghiem_Tests
                               join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                               where t.test_id == _id
                               select new
                               {
                                   t.test_id,
                                   t.monhoc_id,
                                   cate.baithicate_name
                               }).FirstOrDefault();
                if (checkDe.monhoc_id == 72 && checkDe.baithicate_name.ToLower().Contains("reading"))
                {
                    Response.Redirect("exercise-reading-b1-test-" + _id);
                }
                else if (checkDe.monhoc_id == 72 && checkDe.baithicate_name.ToLower().Contains("listening"))
                {
                    Response.Redirect("exercise-listening-b1-test-" + _id);
                }
                else if (checkDe.monhoc_id == 74 && checkDe.baithicate_name.ToLower().Contains("reading"))
                {
                    Response.Redirect("exercise-reading-a2-test-" + _id);
                }
                else if (checkDe.monhoc_id == 74 && checkDe.baithicate_name.ToLower().Contains("listening"))
                {
                    Response.Redirect("exercise-listening-a2-test-" + _id);
                }
                //exercise-reading-b1-test-

            }
            else if (selectedId.Count == 0)
            {
                alert.alert_Warning(Page, "Chưa chọn bài luyện tập để xem!", "");
            }
            else if (selectedId.Count > 1)
            {
                alert.alert_Warning(Page, "Chỉ được chọn 1 bài luyện tập để xem!", "");
            }
        }
        catch (Exception)
        {
            alert.alert_Error(Page, "Lỗi! Xin vui lòng liên hệ tổ IT!", "");
        }

    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "test_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbTracNghiem_Test del = db.tbTracNghiem_Tests.Where(x => x.test_id == Convert.ToInt32(item)).FirstOrDefault();
                if (del.test_trangthai =="Đã duyệt" || del.test_trangthai == "Tổ trưởng duyệt")
                {

                }
                else
                {
                    del.hidden = true;
                }
                try
                {
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Xóa thành công", "");
                }
                catch (Exception ex)
                {
                    alert.alert_Error(Page, "Xoá không thành công!", "");
                }
                getdata();
                //if (cls.Linq_Xoa(Convert.ToInt32(item)))
                //    alert.alert_Success(Page, "Xóa thành công", "");
                //else
                //    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
    }

    protected void btnChuyenDuyet_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "test_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbTracNghiem_Test del = db.tbTracNghiem_Tests.Where(x => x.test_id == Convert.ToInt32(item)).FirstOrDefault();
                if (del.test_trangthai == "Đã duyệt" || del.test_trangthai == "Tổ trưởng đã duyệt")
                {

                }
                else
                {
                    del.test_trangthai = "Chờ duyệt";
                }
                try
                {
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Chuyển duyệt thành công", "");
                }
                catch (Exception ex)
                {
                    alert.alert_Error(Page, "Chuyển duyệt không thành công!", "");
                }
                getdata();
            }
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
    }
}