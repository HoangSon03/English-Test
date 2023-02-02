using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxHtmlEditor;

public partial class admin_page_module_function_module_TracNghiem_Test_Speaking : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    int _id;
    public string title_BaiHoc, image;
    private void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //edtContent.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    //edtDapAnA.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    //edtDapAnB.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    //edtDapAnC.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    //edtDapAnD.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    //edtGiaiThich.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        //    Session["_id"] = 0;
        //}
        //var getChuong = (from c in db.tbTracNghiem_Lessons
        //                 where c.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
        //                 select c).SingleOrDefault();
        ////title_BaiHoc = getChuong.lesson_name;
        loadData();
        //getCH();
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
                            englishquestion_content = gdtCH.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + gdtCH.englishquestion_content + "'</div>" : gdtCH.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.englishquestion_content + "'> </audio>" : gdtCH.englishquestion_content,
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
        //edtDapAnA.Html = "";
        //edtDapAnB.Html = "";
        //edtDapAnC.Html = "";
        //edtDapAnD.Html = "";
        //edtGiaiThich.Html = "";
        //DaA.Checked = false;
        //DaB.Checked = false;
        //DaC.Checked = false;
        //DaD.Checked = false;
        //edtContent.Html = "";
        //ddlLoaiCauHoi.Text = "Nhận biết";
        //txtLoaiCauHoi.Value = "Dễ";
        btnLuu.Text = "Lưu";
        //btnLuuvaThemmoi.Text = "Lưu và thêm mới";
    }
    private void themdata()
    {
        //var getUser = (from u in db.tbTracNghiem_EnglishQuestionSpeakings
        //               select u).SingleOrDefault();
        //if (Page.IsValid && FileUpload1.HasFile)
        //{
        //    String folderUser = Server.MapPath("~/uploadimages/file-speaking/englishquestionspeaking-" + getUser.englishquestionspeaking_id);
        //    if (!Directory.Exists(folderUser))
        //    {
        //        Directory.CreateDirectory(folderUser);
        //    }
        //    //string filename;
        //    string ulr = "/uploadimages/file-speaking/englishquestionspeaking-" + getUser.englishquestionspeaking_id + "/";
        //    HttpFileCollection hfc = Request.Files;
        //    string filename = Path.GetFileName(FileUpload1.FileName);
        //    string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/file-speaking/englishquestionspeaking-" + getUser.englishquestionspeaking_id + "/"), filename);
        //    FileUpload1.SaveAs(fileName_save);
        //    image = ulr + filename;
        //}
        //tbTracNghiem_EnglishQuestionSpeaking themcauhoi = new tbTracNghiem_EnglishQuestionSpeaking();
        //themcauhoi.englishquestionspeaking_content = image;
        //themcauhoi.englishquestionspeaking_createdate = DateTime.Now;
        //themcauhoi.username_id = getUser.username_id;
        //themcauhoi.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
        //themcauhoi.hidden = false;
        //themcauhoi.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
        //db.tbTracNghiem_EnglishQuestionSpeakings.InsertOnSubmit(themcauhoi);
        //db.SubmitChanges();
        //Session["_id"] = themcauhoi.englishquestionspeaking_id;
        //alert.alert_Success(Page, "Lưu thành công", "");
        //loadData();
    }
    private void updatedata()
    {
        //var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
        //               where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
        //               select ct).Single();
        //if (txtKieuCauHoi.Value != "0")
        //{
        //    if (image != null)
        //    {
        //        chitiet.englishquestion_content = image;
        //    }
        //}
        //else
        //{
        //    chitiet.englishquestion_content = edtContent.Html;
        //}
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + chitiet.englishquestion_content + "')", true);
        //chitiet.englishquestion_level = txtLoaiCauHoi.Value;
        //chitiet.englishquestion_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
        //chitiet.englishquestion_giaithich = edtGiaiThich.Html;
        //db.SubmitChanges();
        //// update bẳng answer
        ////b1: tìm những đáp án của ch có trong bảng và xóa hết
        //var xoaDA = from xDa in db.tbTracNghiem_Answers
        //            where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
        //            select xDa;
        //db.tbTracNghiem_Answers.DeleteAllOnSubmit(xoaDA);
        ////b2 insert lại 4 đáp án mới
        //tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
        //dapanA.answer_content = edtDapAnA.Html;
        //dapanA.question_id = chitiet.englishquestion_id;
        //if (DaA.Checked == true)
        //    dapanA.answer_true = true;
        //else
        //    dapanA.answer_true = false;
        //db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
        //tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
        //dapanB.answer_content = edtDapAnB.Html;
        //dapanB.question_id = chitiet.englishquestion_id;
        //if (DaB.Checked == true)
        //    dapanB.answer_true = true;
        //else
        //    dapanB.answer_true = false;
        //db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
        //tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
        //dapanC.answer_content = edtDapAnC.Html;
        //dapanC.question_id = chitiet.englishquestion_id;
        //if (DaC.Checked == true)
        //    dapanC.answer_true = true;
        //else
        //    dapanC.answer_true = false;
        //db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
        //tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
        //dapanD.answer_content = edtDapAnD.Html;
        //dapanD.question_id = chitiet.englishquestion_id;
        //if (DaD.Checked == true)
        //    dapanD.answer_true = true;
        //else
        //    dapanD.answer_true = false;
        //db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
        //db.SubmitChanges();
        //alert.alert_Success(Page, "Cập nhật thành công", "");
        //btnLuu.Text = "Cập nhật";
        //btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
        //loadData();
    }
    private void SavefileImage()
    {
        //if (Page.IsValid && FileUpload1.HasFile)
        //{
        //    String folderUser;
        //    string url;
        //    string filename;
        //    string fileName_save;
        //    if (txtKieuCauHoi.Value == "1")
        //    {
        //        //lưu hình ảnh
        //        folderUser = Server.MapPath("~/uploadimages/anh_cauhoitracnghiem/");
        //        if (!Directory.Exists(folderUser))
        //        {
        //            Directory.CreateDirectory(folderUser);
        //        }
        //        url = "/uploadimages/anh_cauhoitracnghiem/";
        //        HttpFileCollection hfc = Request.Files;
        //        filename = DateTime.Now.ToString("yyyyMMdd_") + FileUpload1.FileName;
        //        fileName_save = Path.Combine(Server.MapPath("~/uploadimages/anh_cauhoitracnghiem"), filename);
        //        FileUpload1.SaveAs(fileName_save);
        //        image = url + filename;
        //    }
        //    else if (txtKieuCauHoi.Value == "2")
        //    {
        //        //lưu video
        //        folderUser = Server.MapPath("~/uploadimages/video_cauhoitracnghiem/");
        //        if (!Directory.Exists(folderUser))
        //        {
        //            Directory.CreateDirectory(folderUser);
        //        }
        //        url = "/uploadimages/video_cauhoitracnghiem/";
        //        HttpFileCollection hfc = Request.Files;
        //        filename = DateTime.Now.ToString("yyyyMMdd_") + FileUpload1.FileName;
        //        fileName_save = Path.Combine(Server.MapPath("~/uploadimages/video_cauhoitracnghiem"), filename);
        //        FileUpload1.SaveAs(fileName_save);
        //        image = url + filename;
        //    }

        //}
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {

        // đếm số đáp án chọn.
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault();
        if (Page.IsValid && FileUpload1.HasFile)
        {
            String folderUser = Server.MapPath("~/uploadimages/file-speaking/englishquestionspeaking-" + getUser.username_username);
            if (!Directory.Exists(folderUser))
            {
                Directory.CreateDirectory(folderUser);
            }
            //string filename;
            string ulr = "/uploadimages/file-speaking/englishquestionspeaking-" + getUser.username_username + "/";
            HttpFileCollection hfc = Request.Files;
            string filename = Path.GetFileName(FileUpload1.FileName);
            string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/file-speaking/englishquestionspeaking-" + getUser.username_username + "/"), filename);
            FileUpload1.SaveAs(fileName_save);
            image = ulr + filename;
        }
        tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
        themcauhoi.englishquestion_content = image;
        themcauhoi.englishquestion_createdate = DateTime.Now;
        themcauhoi.username_id = getUser.username_id;
        themcauhoi.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
        themcauhoi.hidden = false;
        themcauhoi.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
        db.SubmitChanges();
        Session["_id"] = themcauhoi.englishquestion_id;
        alert.alert_Success(Page, "Lưu thành công", "");
        loadData();

    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "englishquestion_id" });
        //if (selectedKey.Count > 0)
        //{
        //    try
        //    {

        //        foreach (var item in selectedKey)
        //        {
        //            tbTracNghiem_EnglishQuestion del = db.tbTracNghiem_EnglishQuestions.Where(x => x.englishquestion_id == Convert.ToInt32(item)).FirstOrDefault();
        //            db.tbTracNghiem_EnglishQuestions.DeleteOnSubmit(del);
        //            db.SubmitChanges();
        //            //var listDanhSachCauHoi = from eq in db.tbTracNghiem_EnglishQuestions
        //            //                         orderby eq.englishquestion_id descending
        //            //                         select eq;
        //            //grvList.DataSource = listDanhSachCauHoi;
        //            //grvList.DataBind();
        //            alert.alert_Success(Page, "Xóa thành công", "");
        //            //else
        //            //    alert.alert_Error(Page, "Xóa thất bại", "");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        alert.alert_Error(Page, "Xoá không thành công!", "");
        //    }
        //}
        //else
        //{
        //    alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        //}
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var xoa = (from x in db.tbTracNghiem_EnglishQuestions
                           where x.englishquestion_id == Convert.ToInt32(item)
                           select x).SingleOrDefault();
                var user = (from u in db.admin_Users
                            where u.username_username == Request.Cookies["UserName"].Value
                            select u).SingleOrDefault();
                if (xoa.username_id == user.username_id)
                {
                    xoa.hidden = true;
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Xóa thành công", "");
                    loadData();
                }
                else
                {
                    alert.alert_Error(Page, "Sai thông tin người dùng", "");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "grvList.UnselectRows()", true);
                }

            }
        }
        else
        {
            alert.alert_Warning(Page, "Vui lòng chọn", "");
        }
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // //List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "question_id" });
        // //if (selectedKey.Count() == 1)
        // //{
        // int countDADung = 0;
        // //lay id cuar row dduwocj click
        // _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "englishquestion_id" }));
        // Session["_id"] = _id;
        // var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
        //                where ct.englishquestion_id == _id
        //                select new
        //                {
        //                    ct.username_id,
        //                    ct.englishquestion_content,
        //                    ct.englishquestion_type,
        //                    ct.englishquestion_dangcauhoi,
        //                    ct.englishquestion_level,
        //                    ct.englishquestion_giaithich,
        //                }).Single();
        // var user = (from u in db.admin_Users
        //             where u.username_username == Request.Cookies["UserName"].Value
        //             select u).SingleOrDefault();
        // if (chitiet.username_id == user.username_id)
        // {
        //     txtLoaiCauHoi.Value = chitiet.englishquestion_level + "";
        //     ddlLoaiCauHoi.Text = chitiet.englishquestion_dangcauhoi + "";
        //     edtGiaiThich.Html = chitiet.englishquestion_giaithich;
        //     if(!chitiet.englishquestion_content.Contains("uploadimages"))
        //     {
        //         txtKieuCauHoi.Value = "0";
        //         edtContent.Html = chitiet.englishquestion_content;
        //         ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setChecked();", true);
        //     }
        //     else
        //     {
        //         if (!chitiet.englishquestion_content.Contains("mp3"))
        //         {
        //             image = chitiet.englishquestion_content;
        //             txtKieuCauHoi.Value = "1";
        //             ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "'),lockAudio()", true);
        //         }
        //         else
        //         {
        //             txtKieuCauHoi.Value = "1";
        //             ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "'),lockImg()", true);
        //         }
        //     }
        //     var chitietquestion = (from ctCH in db.tbTracNghiem_Answers
        //                            where ctCH.question_id == _id
        //                            select ctCH);
        //     edtDapAnA.Html = chitietquestion.First().answer_content;
        //     if (chitietquestion.First().answer_true == true)
        //     {
        //         DaA.Checked = true;
        //         countDADung++;

        //     }
        //     else
        //         DaA.Checked = false;
        //     edtDapAnB.Html = chitietquestion.Skip(1).First().answer_content;
        //     if (chitietquestion.Skip(1).First().answer_true == true)
        //     {
        //         DaB.Checked = true;
        //         countDADung++;

        //     }
        //     else
        //         DaB.Checked = false;
        //     edtDapAnC.Html = chitietquestion.Skip(2).First().answer_content;
        //     if (chitietquestion.Skip(2).First().answer_true == true)
        //     {
        //         DaC.Checked = true;
        //         countDADung++;

        //     }
        //     else
        //         DaC.Checked = false;
        //     edtDapAnD.Html = chitietquestion.Skip(3).First().answer_content;
        //     if (chitietquestion.Skip(3).First().answer_true == true)
        //     {
        //         DaD.Checked = true;
        //         countDADung++;

        //     }
        //     else
        //         DaD.Checked = false;

        //     btnLuu.Text = "Cập nhật";
        //     btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
        // }
        // else
        // {
        //     alert.alert_Error(Page, "Sai thông tin người dùng", "");
        // }

        // //}

        // //else
        // //{
        // //    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Lỗi!','Bạn chỉ được chọn 1 dòng dữ liệu để xem chi tiết','error').then(function(){grvList.UnselectRows();setForm()})", true);
        // //    datarong();
        // //}
        //// ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);
    }

    protected void btnLuuvaThemmoi_Click1(object sender, EventArgs e)
    {
        //SavefileImage();
        //if ( image == null)
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //if (Session["_id"].ToString() == "0")
        //{
        //    tbTracNghiem_EnglishQuestionSpeaking themcauhoi = new tbTracNghiem_EnglishQuestionSpeaking();
        //    themdata();
        //    Session["_id"] = "0";
        //}

        //else
        //{
        //    //update
        //    updatedata();
        //    Session["_id"] = "0";
        //    btnLuu.Text = "Lưu";
        //    btnLuuvaThemmoi.Text = "Lưu và thêm mới";
        //}
        //datarong();
    }

    protected void btnTaiLaiTrang_Click(object sender, EventArgs e)
    {
        loadData();
        datarong();
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "grvList.UnselectRows();setForm()", true);
    }

    protected void btnQuayLai_Click(object sender, EventArgs e)
    {
        int testId = Convert.ToInt32(RouteData.Values["test_id"]);
        if (testId != 0)
        {
            Response.Redirect("admin-bai-luyen-tap-chi-tiet-" + testId);
        }
        else
        {
            Response.Redirect("admin-home");
        }
    }
}