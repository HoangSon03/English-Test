using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_BaiKiemTra_module_DanhSachBaiKiemTra : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    int _id;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        getdata();
    }
    private void getdata()
    {
        var getdata = from test in db.tbTracNghiem_Tests
                      join khoi in db.tbKhois on test.khoi_id equals khoi.khoi_id
                      join baithi in db.tbTracNghiem_BaiThiCates on test.baithicate_id equals baithi.baithicate_id
                      join user in db.admin_Users on test.username_id equals user.username_id
                      join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                      where test.hidden == false && user.username_username == Request.Cookies["UserName"].Value
                      && test.hidden == false
                      select new
                      {
                          test.test_id,
                          khoi.khoi_name,
                          baithi.baithicate_name,
                          mh.monhoc_name,
                          baithi.baithicate_id,
                          user.username_fullname,
                          test.test_createdate,
                      };
        grvList.DataSource = getdata;
        grvList.DataBind();

    }
    protected void build_url_Click(object sender, EventArgs e)
    {
        var x = id_key.Value;
        var test = (from t in db.tbTracNghiem_Tests
                    join btk in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals btk.baithicate_id
                    where t.test_id == Convert.ToInt32(id_key.Value) && btk.baithicate_id == t.baithicate_id
                    select new
                    {
                        t.test_id,
                        t.khoi_id,
                        btk.baithicate_name
                    }).SingleOrDefault();
        var check = (from t in db.tbTracNghiem_Tests
                     join btk in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals btk.baithicate_id
                     join tnl in db.tbTracNghiem_Lessons on t.khoi_id equals tnl.khoi_id
                     where t.test_id == Convert.ToInt32(id_key.Value) && btk.baithicate_id == t.baithicate_id
                     && tnl.lesson_name == "Listening"
                     select tnl).FirstOrDefault();
        string duongdan;
        if (check != null)
        {
            duongdan = "http://tracnghiem.vietnhatschool.edu.vn/" + "bai-kiem-tra-listening-" + test.khoi_id + "/bai-kiem-tra-chi-tiet/" + cls_ToAscii.ToAscii(test.baithicate_name) + "-" + test.test_id + ".html";
        }
        else
        {
            duongdan = "http://tracnghiem.vietnhatschool.edu.vn/" + "bai-kiem-tra-" + test.khoi_id + "/bai-kiem-tra-chi-tiet/" + cls_ToAscii.ToAscii(test.baithicate_name) + "-" + test.test_id + ".html";
        }
        url.Value = duongdan;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "geturl()", true);
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "test_id" });
        if (selectedKey.Count == 1)
        {
            foreach (var item in selectedKey)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupShow()", true);
                var getCh = from gch in db.tbTracNghiem_Questions
                            join ct in db.tbTracNghiem_TestDetails on gch.question_id equals ct.question_id
                            join u in db.admin_Users on gch.username_id equals u.username_id
                            where ct.test_id == Convert.ToInt32(item) && ct.question_id == gch.question_id
                            select new
                            {
                                gch.question_id,
                                question_content = gch.question_content.Contains("style=") ? "<div class='content_image'>" + gch.question_content + "</div>" : gch.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + gch.question_content + "'>" : gch.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gch.question_content + "'>" : gch.question_content.Contains("mp3") ? " <audio controls> <source src = '" + gch.question_content + "'> </audio>" : gch.question_content,
                                gch.question_type,
                                u.username_fullname
                            };
                rpCH.DataSource = getCh;
                rpCH.DataBind();
            }
        }
        else
        {
            alert.alert_Error(Page, "Bạn chưa chọn đối tượng hoặc đã chọn nhiều hơn một", "");
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "test_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getTest = (from t in db.tbTracNghiem_Tests
                               where t.test_id == Convert.ToInt32(item)
                               select t).SingleOrDefault();
                getTest.hidden = true;
                db.SubmitChanges();
            }
            alert.alert_Success(Page, "Xóa thành công", "");
            getdata();
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn bài kiểm tra cần xóa", "");
        }
    }
}