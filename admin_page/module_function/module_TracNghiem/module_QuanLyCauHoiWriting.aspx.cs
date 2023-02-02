using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxHtmlEditor;

public partial class admin_page_module_function_module_TracNghiem_Test_Writing : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    int _id;
    private int username_id;
    public string title_BaiHoc, image;
    private void Page_Load(object sender, EventArgs e)
    {
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        username_id = getUser.username_id;
        if (!IsPostBack)
        {
            edtContent.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            Session["_id"] = 0;
        }
        loadData();
    }
    private void getCH()
    {
        var getCH = from gch in db.tbTracNghiem_EnglishQuestionSpeakings
                    join bh in db.tbTracNghiem_Lessons on gch.lesson_id equals bh.lesson_id
                    join name in db.admin_Users on gch.username_id equals name.username_id
                    where gch.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
                    && gch.hidden == false
                    select new
                    {
                        gch.englishquestionspeaking_id,
                        bh.lesson_name,
                        gch.englishquestionspeaking_content,
                        name.username_fullname
                    };
        grvList.DataSource = getCH;
        grvList.DataBind();
    }
    private void loadData()
    {
        var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                        join name in db.admin_Users on gdtCH.username_id equals name.username_id
                        where gdtCH.hidden == false
                        && gdtCH.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
                        orderby gdtCH.englishquestion_id descending
                        select new
                        {
                            c.chapter_id,
                            //englishquestion_content = gdtCH.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + gdtCH.englishquestion_content + "'</div>" : gdtCH.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.englishquestion_content + "'> </audio>" : gdtCH.englishquestion_content,
                            englishquestion_content = gdtCH.englishquestion_content,
                            gdtCH.englishquestion_createdate,
                            c.lesson_name,
                            name.username_fullname,
                            gdtCH.englishquestion_id,

                        };
        grvList.DataSource = gdtCauhoi;
        grvList.DataBind();
    }
    private void datarong()
    {
        edtContent.Html = "";
        btnLuu.Text = "Lưu";
        btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {

        // đếm số đáp án chọn.
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault();
        if (Session["_id"].ToString() == "0")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = edtContent.Html;
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            themcauhoi.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
            themcauhoi.hidden = false;
            themcauhoi.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            Session["_id"] = themcauhoi.englishquestion_id;
            alert.alert_Success(Page, "Lưu thành công", "");
        }
        else
        {
            tbTracNghiem_EnglishQuestion udpate = (from q in db.tbTracNghiem_EnglishQuestions
                                                   where q.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                                                   select q).Single();
            udpate.englishquestion_content = edtContent.Html;
            udpate.englishquestion_createdate = DateTime.Now;
            db.SubmitChanges();
            Session["_id"] = udpate.englishquestion_id;
            alert.alert_Success(Page, "Cập nhật thành công", "");
        }
        loadData();
        btnLuu.Text = "Cập nhật";
        btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "englishquestion_id" });
        if (selectedKey.Count > 0)
        {
            try
            {
                foreach (var item in selectedKey)
                {
                    tbTracNghiem_EnglishQuestion del = db.tbTracNghiem_EnglishQuestions.Where(x => x.englishquestion_id == Convert.ToInt32(item)).FirstOrDefault();
                    db.tbTracNghiem_EnglishQuestions.DeleteOnSubmit(del);
                    db.SubmitChanges();
                    //var listDanhSachCauHoi = from eq in db.tbTracNghiem_EnglishQuestions
                    //                         orderby eq.englishquestion_id descending
                    //                         select eq;
                    //grvList.DataSource = listDanhSachCauHoi;
                    //grvList.DataBind();
                    alert.alert_Success(Page, "Xóa thành công", "");
                }
                loadData();
            }
            catch (Exception ex)
            {
                alert.alert_Error(Page, "Xoá không thành công!", "");
            }
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
        //if (selectedKey.Count > 0)
        //{
        //    foreach (var item in selectedKey)
        //    {
        //        var xoa = (from x in db.tbTracNghiem_EnglishQuestions
        //                   where x.englishquestion_id == Convert.ToInt32(item)
        //                   select x).SingleOrDefault();
        //        var user = (from u in db.admin_Users
        //                    where u.username_username == Request.Cookies["UserName"].Value
        //                    select u).SingleOrDefault();
        //        if (xoa.username_id == user.username_id)
        //        {
        //            xoa.hidden = true;
        //            db.SubmitChanges();
        //            alert.alert_Success(Page, "Xóa thành công", "");
        //            loadData();
        //        }
        //        else
        //        {
        //            alert.alert_Error(Page, "Sai thông tin người dùng", "");
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "grvList.UnselectRows()", true);
        //        }

        //    }
        //}
        //else
        //{
        //    alert.alert_Warning(Page, "Vui lòng chọn", "");
        //}
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "englishquestion_id" }));
        Session["_id"] = _id;
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == _id
                       select new
                       {
                           ct.username_id,
                           ct.englishquestion_content,
                           ct.englishquestion_type,
                           ct.englishquestion_dangcauhoi,
                           ct.englishquestion_level,
                       }).Single();
        if (chitiet.username_id == username_id)
        {
            edtContent.Html = chitiet.englishquestion_content;
            btnLuu.Text = "Cập nhật";
            btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
        }
        else
        {
            alert.alert_Error(Page, "Sai thông tin người dùng", "");
        }
    }
    protected void btnTaiLaiTrang_Click(object sender, EventArgs e)
    {
        loadData();
        datarong();
    }

    protected void btnLuuvaThemmoi_Click(object sender, EventArgs e)
    {
        if (Session["_id"].ToString() == "0")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = edtContent.Html;
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = username_id;
            themcauhoi.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
            themcauhoi.hidden = false;
            themcauhoi.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            Session["_id"] = 0;
            alert.alert_Success(Page, "Lưu thành công", "");
        }
        else
        {
            tbTracNghiem_EnglishQuestion udpate = (from q in db.tbTracNghiem_EnglishQuestions
                                                   where q.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                                                   select q).Single();
            udpate.englishquestion_content = edtContent.Html;
            udpate.englishquestion_createdate = DateTime.Now;
            db.SubmitChanges();
            Session["_id"] = udpate.englishquestion_id;
            alert.alert_Success(Page, "Cập nhật thành công", "");
        }
        btnLuu.Text = "Lưu";
        btnLuuvaThemmoi.Text = "Lưu và thêm mới";
        loadData();
        datarong();
    }
}