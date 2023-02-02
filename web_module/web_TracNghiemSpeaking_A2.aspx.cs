using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiemSpeaking_A2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public string title_BaiHoc, image1, image2, image3, image4;

    //public int STTTraLoi;
    public int count = 0;
    int question_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
            var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                              join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                              where rs.test_id == id_Test && rs.hocsinh_code == Request.Cookies["User_name"].Value
                              select t;
            //if (checkLamBai.Count() > 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
            //}
            //else
            //{
            tbTracNghiem_BaiThiCate getThoiGianLamBaiKiemTra = (from td in db.tbTracNghiem_Tests
                                                                join c in db.tbTracNghiem_BaiThiCates on td.baithicate_id equals c.baithicate_id
                                                                where td.test_id == id_Test
                                                                select c).First();
            txtPhutHiden.Value = getThoiGianLamBaiKiemTra.thoigianlambai;
            txtTitle.Value = getThoiGianLamBaiKiemTra.baithicate_name;
            var getDataDetails = from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions
                                 on td.question_id equals q.englishquestion_id
                                 where td.test_id == id_Test
                                 select new
                                 {
                                     td.question_id,
                                     noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                                 };
            rpCauHoiDetals.DataSource = getDataDetails;
            rpCauHoiDetals.DataBind();
            count = getDataDetails.Count();
            //}
        }
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "countdown(ten-countdown,2, 0)", true);
    }
    protected void btnNopBai_Click(object sender, EventArgs e)
    {
        //db.Connection.Open();
        //using (var transaction = db.Connection.BeginTransaction())
        //{
        //    db.Transaction = transaction;
        try
        {
            //kiểm tra xem đã làm bài đó chưa.

            string hocsinh_code = Request.Cookies["User_name"].Value;
            //file part1
            if (FileUpload1.HasFile)
            {
                String folderUser = Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code);
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                string ulr = "/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/";
                HttpFileCollection hfc = Request.Files;
                string filename = Path.GetFileName(FileUpload1.FileName);
                string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/"), filename);
                FileUpload1.SaveAs(fileName_save);
                image1 = ulr + filename;
            }
            //file part2
            if (FileUpload2.HasFile)
            {
                String folderUser = Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code);
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                string ulr = "/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/";
                HttpFileCollection hfc = Request.Files;
                string filename = Path.GetFileName(FileUpload2.FileName);
                string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/"), filename);
                FileUpload2.SaveAs(fileName_save);
                image2 = ulr + filename;
            }
            ////file part3
            //if (FileUpload3.HasFile)
            //{
            //    String folderUser = Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code);
            //    if (!Directory.Exists(folderUser))
            //    {
            //        Directory.CreateDirectory(folderUser);
            //    }
            //    string ulr = "/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/";
            //    HttpFileCollection hfc = Request.Files;
            //    string filename = Path.GetFileName(FileUpload3.FileName);
            //    string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/"), filename);
            //    FileUpload3.SaveAs(fileName_save);
            //    image3 = ulr + filename;
            //}
            ////file part4
            //if (FileUpload4.HasFile)
            //{
            //    String folderUser = Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code);
            //    if (!Directory.Exists(folderUser))
            //    {
            //        Directory.CreateDirectory(folderUser);
            //    }
            //    string ulr = "/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/";
            //    HttpFileCollection hfc = Request.Files;
            //    string filename = Path.GetFileName(FileUpload4.FileName);
            //    string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/answer_speaking/hocsinh_" + hocsinh_code + "/"), filename);
            //    FileUpload4.SaveAs(fileName_save);
            //    image4 = ulr + filename;
            //}
            var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                              join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                              where rs.test_id == Convert.ToInt32(RouteData.Values["id_test"]) && rs.hocsinh_code == Request.Cookies["User_name"].Value
                              select new
                              {
                                  rs.resulttest_id,
                                  t.test_id,
                              };
            if (checkLamBai.Count() > 0)
            {
                var update = from ct in db.tbTracNghiem_ResultChiTiets
                             where ct.resulttest_id == checkLamBai.FirstOrDefault().resulttest_id
                             select ct;
                //update part1
                update.FirstOrDefault().answer_checked_id = image1;
                //update part2
                update.Skip(1).Take(1).FirstOrDefault().answer_checked_id = image2;
                db.SubmitChanges();
                Session["Url_Test"] = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();HiddenLoadingIcon()", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
            }
            else
            {
                tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
                //kq.resulttest_result = txtSoCauDung.Value;
                kq.hocsinh_code = Request.Cookies["User_name"].Value;
                kq.resulttest_datetime = DateTime.Now;
                kq.test_id = Convert.ToInt32(RouteData.Values["id_test"]);
                kq.lop_id = Convert.ToInt32(RouteData.Values["id_khoi"]);
                //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
                kq.result_type = 1;
                db.tbTracNghiem_ResultTests.InsertOnSubmit(kq);
                db.SubmitChanges();
                //insert part1
                tbTracNghiem_ResultChiTiet part1 = new tbTracNghiem_ResultChiTiet();
                part1.resulttest_id = kq.resulttest_id;
                part1.question_id = Convert.ToInt32(txtIDQuestion1.Value);
                part1.answer_checked_id = image1;
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part1);
                db.SubmitChanges();
                //insert part2
                tbTracNghiem_ResultChiTiet part2 = new tbTracNghiem_ResultChiTiet();
                part2.resulttest_id = kq.resulttest_id;
                part2.question_id = Convert.ToInt32(txtIDQuestion2.Value);
                part2.answer_checked_id = image2;
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part2);
                db.SubmitChanges();
                //insert part3
                //tbTracNghiem_ResultChiTiet part3 = new tbTracNghiem_ResultChiTiet();
                //part3.resulttest_id = kq.resulttest_id;
                //part3.question_id = Convert.ToInt32(txtIDQuestion3.Value);
                //part3.answer_checked_id = image3;
                //db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part3);
                //db.SubmitChanges();
                ////insert part4
                //tbTracNghiem_ResultChiTiet part4 = new tbTracNghiem_ResultChiTiet();
                //part4.resulttest_id = kq.resulttest_id;
                //part4.question_id = Convert.ToInt32(txtIDQuestion4.Value);
                //part4.answer_checked_id = image4;
                //db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part4);
                //db.SubmitChanges();
                //sau khi nộp bài thì xóa session link bài kiểm tra
                Session["Url_Test"] = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();HiddenLoadingIcon()", true);
            }
            //transaction.Commit();
        }
        catch (Exception ex)
        {
            alert.alert_Error(Page, "Đã có lỗi xảy ra", "");
        }
        //}
    }

    protected void btnCheckCookie_ServerClick(object sender, EventArgs e)
    {
        if (Request.Cookies["User_name"] == null)
        {
            //lấy url hiện tại
            string url = HttpContext.Current.Request.RawUrl.ToString();
            Session["Url_Test"] = url;
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Vui lòng đăng nhập để làm bài!', '','warning').then(function(){window.location = '/login-account';})", true);
        }
        else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "checkShow();", true);
    }


    protected void btnClose_ServerClick(object sender, EventArgs e)
    {
        //chuyển về form các phần của bài thi
        int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        var checkTest = (from t in db.tbTracNghiem_Tests
                         where t.test_id == id_Test
                         select t).FirstOrDefault();
        Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);

    }
}