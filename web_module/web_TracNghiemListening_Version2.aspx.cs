using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiemListening_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT_Part = 1;
    public int STT = 1;
    public int STT_Part4 = 20;
    //public int STTTraLoi;
    public int count = 1;
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
        //if (checkLamBai.Count() > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
        //}
        //else
        //{
        var getThoiGianLamBaiKiemTra = (from td in db.tbTracNghiem_Tests
                                        join c in db.tbTracNghiem_BaiThiCates on td.baithicate_id equals c.baithicate_id
                                        where td.test_id == id_Test
                                        select c).First();
        txtPhutHiden.Value = getThoiGianLamBaiKiemTra.thoigianlambai;
        txtTitle.Value = getThoiGianLamBaiKiemTra.baithicate_name;

        //get câu hỏi lớn part1, part2
        var getCHL = (from t in db.tbTracNghiem_Tests
                      join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                      where t.test_id == id_Test
                      select new
                      {
                          t.test_id,
                          qsb.QuestionBig_id,
                          qsb.questionbig_mp3
                      }).Take(2);
        rpCauHoiLon.DataSource = getCHL;
        rpCauHoiLon.DataBind();
        //get câu hỏi lớn part3
        var getCHL_Part3 = (from t in db.tbTracNghiem_Tests
                            join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                            where t.test_id == id_Test
                            select new
                            {
                                t.test_id,
                                qsb.QuestionBig_id,
                                qsb.questionbig_mp3,
                                qsb.QuestionBig_content,
                            }).Skip(2).Take(1);
        rpCauHoiLonPart3.DataSource = getCHL_Part3;
        rpCauHoiLonPart3.DataBind();
        //get câu hỏi part 3
        var getCauHoiPart3 = (from td in db.tbTracNghiem_TestDetails
                              join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                              where td.test_id == id_Test && q.englishquestion_groupidquestion == getCHL_Part3.FirstOrDefault().QuestionBig_id
                              select new
                              {
                                  td.question_id,
                                  noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                              });
        rpCauHoiPart3.DataSource = getCauHoiPart3;
        rpCauHoiPart3.DataBind();
        //get câu hỏi lớn part4
        var getCHL_Part4 = (from t in db.tbTracNghiem_Tests
                            join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                            where t.test_id == id_Test
                            select new
                            {
                                t.test_id,
                                qsb.QuestionBig_id,
                                qsb.questionbig_mp3
                            }).Skip(3).Take(1);
        rpCauHoiLonPart4.DataSource = getCHL_Part4;
        rpCauHoiLonPart4.DataBind();
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

    protected void rpCauHoiLon_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauHoi = e.Item.FindControl("rpCauHoi") as Repeater;
        int cauhoilon_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "QuestionBig_id").ToString());
        int test_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "test_id").ToString());
        var getData = (from td in db.tbTracNghiem_TestDetails
                       join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                       where td.test_id == test_id && q.englishquestion_groupidquestion == cauhoilon_id
                       select new
                       {
                           td.question_id,
                           noidungcauhoi = q.englishquestion_content,
                       });
        rpCauHoi.DataSource = getData;
        rpCauHoi.DataBind();
    }

    protected void rpCauHoi_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
        int question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getcautraloi = from chl in db.tbTracNghiem_Answers
                           where chl.question_id == question_id && chl.answer_content != ""
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
    protected void rpCauHoiPart3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart3 = e.Item.FindControl("rpCauTraLoiPart3") as Repeater;
        int _question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getCauTraLoi = from t in db.tbTracNghiem_Answers
                           where t.question_id == _question_id && t.answer_content != ""
                           select new
                           {
                               t.answer_id,
                               t.answer_content,
                               t.answer_true,
                               t.question_id
                           };
        rpCauTraLoiPart3.DataSource = getCauTraLoi;
        rpCauTraLoiPart3.DataBind();
    }
    protected void rpCauHoiLonPart4_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauHoi = e.Item.FindControl("rpCauHoiPart4") as Repeater;
        int cauhoilon_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "QuestionBig_id").ToString());
        int test_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "test_id").ToString());
        var getData = (from td in db.tbTracNghiem_TestDetails
                       join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                       where td.test_id == test_id && q.englishquestion_groupidquestion == cauhoilon_id
                       select new
                       {
                           td.question_id,
                           noidungcauhoi = q.englishquestion_content,
                       });
        rpCauHoi.DataSource = getData;
        rpCauHoi.DataBind();
    }

    protected void btnClose_ServerClick(object sender, EventArgs e)
    {

    }

    protected void check_back_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnNopBai_Click(object sender, EventArgs e)
    {
        //try
        //{
        //kiểm tra xem đã làm bài đó chưa.
        //var checkLamBai = from rs in db.tbTracNghiem_ResultTests
        //                  join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
        //                  where rs.test_id == Convert.ToInt32(RouteData.Values["id_test"]) && rs.hocsinh_code == Request.Cookies["User_name"].Value
        //                  select t;
        //if (checkLamBai.Count() > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
        //}
        //else
        //{
        tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
        kq.resulttest_result = txtSoCauDung.Value + "/25";
        kq.hocsinh_code = Request.Cookies["User_name"].Value;
        kq.resulttest_datetime = DateTime.Now;
        kq.test_id = Convert.ToInt32(RouteData.Values["id_test"]);
        kq.lop_id = Convert.ToInt32(RouteData.Values["id_khoi"]);
        //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
        kq.result_type = 1;
        db.tbTracNghiem_ResultTests.InsertOnSubmit(kq);
        db.SubmitChanges();
        /*
         - Tổng điểm phần listening: 20
         - mỗi câu đúng được 0.8 điểm
         */

        string listChecked = txtChecked.Value;
        string[] arrlistChecked = listChecked.Split(',');
        //khai bóa bi^^ến ít id c^^au hỏi chứa id c^^au hỏi
        string listID = txtIDQuestion.Value;
        string[] arrID = listID.Split(',');
        for (int index = 0; index < arrID.Length; index++)
        {
            //part 1(7 câu), part 2 (6 câu), part 4 (6 câu)
            tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
            kqct.resulttest_id = kq.resulttest_id;
            kqct.question_id = Convert.ToInt32(arrID[index]);
            var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                    where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                                    select t).FirstOrDefault();
            kqct.answer_true_id = Convert.ToString(getDataCauTraLoi.answer_id);
            if (arrlistChecked[index] == "")
                kqct.answer_checked_id = "0";
            else
                kqct.answer_checked_id = Convert.ToString(arrlistChecked[index]);
            if (index <= 6)
                kqct.result_part = 1;
            else if (index > 6 && index <= 11)
                kqct.result_part = 2;
            else
                kqct.result_part = 4;
            if (kqct.answer_true_id == kqct.answer_checked_id)
                kqct.resultchitiet_point = 0.8;
            else
                kqct.resultchitiet_point = 0;
            db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
            db.SubmitChanges();
        }
        string[] arrValue = txtValueInput.Value.Split(',');//value nhập vào
        string[] arrCauHoi = txtIdCauHoi.Value.Split(',');//id câu hỏi
        string[] arrCheck = txtDapAnDung.Value.Split(',');//arr đúng sai
        for (int i = 0; i < arrValue.Length; i++)
        {
            //part 3 là nhập input
            tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
            kqct.resulttest_id = kq.resulttest_id;
            kqct.question_id = Convert.ToInt32(arrCauHoi[i]);
            var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                    where t.question_id == Convert.ToInt32(arrCauHoi[i])
                                    select t).FirstOrDefault();
            kqct.answer_true_id = getDataCauTraLoi.answer_content;//đáp án được nhập trong database
            kqct.answer_checked_id = arrValue[i];//đáp án nhập từ input bài làm
            //kqct.answer_true_id = arrDapAnDung[i];
            //kqct.answer_checked_id = arrValue[i];
            //kqct.resulttest_id = kq.resulttest_id;
            kqct.result_part = 3;
            if (arrCheck[i] == "true")
                kqct.resultchitiet_point = 0.8;
            else
                kqct.resultchitiet_point = 0;
            db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
            db.SubmitChanges();
        }
        alert.alert_Success(Page, "Lưu thành công", "");
        //sau khi nộp bài thì xóa session link bài kiểm tra
        Session["Url_Test"] = "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();HiddenLoadingIcon()", true);
        //}
        //}
        //catch (Exception ex)
        //{
        //    alert.alert_Error(Page, "Đã có lỗi xảy ra", "");
        //}
    }

}