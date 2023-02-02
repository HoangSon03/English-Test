using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiemDetails : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    //public int STTTraLoi;
    public int count = 0;
    int question_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                          join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                          where rs.test_id == id_Test && rs.hocsinh_code == Request.Cookies["User_name"].Value
                          select t;
        if (checkLamBai.Count() > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
        }
        else
        {
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
                                     noidungcauhoi = q.englishquestion_content
                                 };
            rpCauHoiDetals.DataSource = getDataDetails;
            rpCauHoiDetals.DataBind();

            //var getCauHoiLon = from chl in db.tbTracNghiem_QuestionBigs where chl.QuestionBig_id == 1 select chl;
            //Rp_cau_hoi_lon.DataSource = getCauHoiLon;
            //Rp_cau_hoi_lon.DataBind();
            ////var getCauHoiLon2 = from chl in db.tbTracNghiem_QuestionBigs where chl.QuestionBig_id == 2 select chl;
            //Rp_cau_hoi_lon2.DataSource = getCauHoiLon2;
            //Rp_cau_hoi_lon2.DataBind();
            count = getDataDetails.Count();
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "countdown(ten-countdown,2, 0)", true);
        }
    }

    protected void rpCauHoiDetals_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ////STTTraLoi = 1;
        //// int STTT = 1;
        //Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
        //question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        //var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
        //                       where t.question_id == question_id
        //                       select new
        //                       {
        //                           //STTTraLoi = STTT+ 1,
        //                           //kitu = STTTraLoi == 1 ? "A." : STTTraLoi == 2 ? "B." : STTTraLoi == 3 ? "C." : "D.",
        //                           t.answer_id,
        //                           t.answer_content,
        //                           t.answer_true,
        //                           t.question_id
        //                       };
        //rpCauTraLoi.DataSource = getDataCauTraLoi;
        //rpCauTraLoi.DataBind();
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
            var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                              join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                              where rs.test_id == Convert.ToInt32(RouteData.Values["id_test"]) && rs.hocsinh_code == Request.Cookies["User_name"].Value
                              select t;
            if (checkLamBai.Count() > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
            }
            else
            {
                tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
                kq.resulttest_result = txtSoCauDung.Value;
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
                part1.answer_checked_id = txtDapAn1.Value.Replace("\n", "<br/>");
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part1);
                db.SubmitChanges();
                //insert part2
                tbTracNghiem_ResultChiTiet part2 = new tbTracNghiem_ResultChiTiet();
                part2.resulttest_id = kq.resulttest_id;
                part2.question_id = Convert.ToInt32(txtIDQuestion2.Value);
                part2.answer_checked_id = txtDapAn2.Value.Replace("\n", "<br/>");
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part2);
                db.SubmitChanges();
                //insert part3
                tbTracNghiem_ResultChiTiet part3 = new tbTracNghiem_ResultChiTiet();
                part3.resulttest_id = kq.resulttest_id;
                part3.question_id = Convert.ToInt32(txtIDQuestion3.Value);
                part3.answer_checked_id = txtDapAn3.Value.Replace("\n", "<br/>");
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part3);
                db.SubmitChanges();

                //sau khi nộp bài thì xóa session link bài kiểm tra
                Session["Url_Test"] = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();", true);
            }
        }
        catch (Exception ex)
        {
            alert.alert_Error(Page, "Đã có lỗi xảy ra", "");
        }
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

    protected void Rp_cau_hoi_lon_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoi = e.Item.FindControl("Rp_cau_hoi_lon") as Repeater;
        int cauhoilon_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "QuestionBig_id").ToString());
        var getdata = from chl in db.tbTracNghiem_Questions
                      where chl.questionbig_groupidquestion == cauhoilon_id
                      select new
                      {
                          chl.question_id,
                          noidungcauhoi = chl.question_content.Contains("style=") ? "<div class='content_image'>" + chl.question_content + "</div>" : chl.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + chl.question_content + "'>" : chl.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + chl.question_content + "'>" : chl.question_content.Contains("mp3") ? " <audio controls> <source src = '" + chl.question_content + "'> </audio>" : chl.question_content
                      };
        rpCauTraLoi.DataSource = getdata;
        rpCauTraLoi.DataBind();
    }

    protected void rpcauhoi_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
        int question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getcautraloi = from chl in db.tbTracNghiem_Answers
                           where chl.question_id == question_id
                           select new
                           {
                               chl.answer_id,
                               chl.answer_content,
                               chl.answer_true,
                               chl.question_id
                           };
        rpCauTraLoi.DataSource = getcautraloi;
        rpCauTraLoi.DataBind();
    }

    protected void Rp_cau_hoi_lon2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoi = e.Item.FindControl("Rp_cau_hoi_lon2") as Repeater;
        int cauhoilon_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "QuestionBig_id").ToString());
        var getdata = from chl in db.tbTracNghiem_Questions
                      where chl.questionbig_groupidquestion == cauhoilon_id
                      select new
                      {
                          chl.question_id,
                          noidungcauhoi = chl.question_content.Contains("style=") ? "<div class='content_image'>" + chl.question_content + "</div>" : chl.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + chl.question_content + "'>" : chl.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + chl.question_content + "'>" : chl.question_content.Contains("mp3") ? " <audio controls> <source src = '" + chl.question_content + "'> </audio>" : chl.question_content
                      };
        rpCauTraLoi.DataSource = getdata;
        rpCauTraLoi.DataBind();
    }

    protected void Rp_cau_hoi_lon2_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
        int question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getcautraloi = from chl in db.tbTracNghiem_Answers
                           where chl.question_id == question_id
                           select new
                           {
                               chl.answer_id,
                               chl.answer_content,
                               chl.answer_true,
                               chl.question_id
                           };
        rpCauTraLoi.DataSource = getcautraloi;
        rpCauTraLoi.DataBind();
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
    protected void check_back_ServerClick(object sender, EventArgs e)
    {
        //chuyển về form các phần của bài thi
        int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        var checkTest = (from t in db.tbTracNghiem_Tests
                         where t.test_id == id_Test
                         select t).FirstOrDefault();
        Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);
    }
}