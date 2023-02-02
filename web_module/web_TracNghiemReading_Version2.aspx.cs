using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiemReading_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STT_Part3 = 11;
    //public int STTTraLoi;
    public int count = 1, stt_part6 = 1;
    int question_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);

        var getThoiGianLamBaiKiemTra = (from td in db.tbTracNghiem_Tests
                                        join c in db.tbTracNghiem_BaiThiCates on td.baithicate_id equals c.baithicate_id
                                        where td.test_id == id_Test
                                        select c).First();
        txtPhutHiden.Value = getThoiGianLamBaiKiemTra.thoigianlambai;
        txtTitle.Value = getThoiGianLamBaiKiemTra.baithicate_name;
        var listCauHoiPart1 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Take(5);
        rpCauHoiPart1.DataSource = listCauHoiPart1;
        rpCauHoiPart1.DataBind();
        var getCauHoiLonPart2 = (from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                 join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                 where td.test_id == id_Test
                                 select ch).Take(1);
        rpCauHoiLonPart2.DataSource = getCauHoiLonPart2;
        rpCauHoiLonPart2.DataBind();
        var listCauHoiPart2 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Skip(5).Take(5);
        rpCauHoiPart2.DataSource = listCauHoiPart2;
        rpCauHoiPart2.DataBind();
        var getCauHoiLonPart3 = (from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                 join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                 where td.test_id == id_Test
                                 select ch).Skip(5).Take(1);
        rpCauHoiLonPart3.DataSource = getCauHoiLonPart3;
        rpCauHoiLonPart3.DataBind();
        var listCauHoiPart3 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Skip(10).Take(5);
        rpCauHoiPart3.DataSource = listCauHoiPart3;
        rpCauHoiPart3.DataBind();
        var getCauHoiLonPart4 = (from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                 join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                 where td.test_id == id_Test
                                 select ch).Skip(10).Take(1);
        rpCauHoiLonPart4.DataSource = getCauHoiLonPart4;
        rpCauHoiLonPart4.DataBind();
        var listCauHoiPart4 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Skip(15).Take(5);
        rpCauHoiPart4.DataSource = listCauHoiPart4;
        rpCauHoiPart4.DataBind();
        var getCauHoiLonPart5 = (from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                 join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                 where td.test_id == id_Test
                                 select ch).Skip(15).Take(1);
        rpCauHoiLonPart5.DataSource = getCauHoiLonPart5;
        rpCauHoiLonPart5.DataBind();
        var listCauHoiPart5 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Skip(20).Take(6);
        rpCauHoiPart5.DataSource = listCauHoiPart5;
        rpCauHoiPart5.DataBind();
        var getCauHoiLonPart6 = (from td in db.tbTracNghiem_TestDetails
                                 join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                 join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                 where td.test_id == id_Test
                                 select ch).Skip(26).Take(1);
        rpCauHoiLonPart6.DataSource = getCauHoiLonPart6;
        rpCauHoiLonPart6.DataBind();
        var listCauHoiPart6 = (from td in db.tbTracNghiem_TestDetails
                               join q in db.tbTracNghiem_EnglishQuestions
                               on td.question_id equals q.englishquestion_id
                               where td.test_id == id_Test
                               select new
                               {
                                   td.question_id,
                                   noidungcauhoi = q.englishquestion_content,
                               }).Skip(26);
        rpCauHoiPart6.DataSource = listCauHoiPart6;
        rpCauHoiPart6.DataBind();
    }

    protected void rpPart1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart1 = e.Item.FindControl("rpCauTraLoiPart1") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   //STTTraLoi = STTT+ 1,
                                   //kitu = STTTraLoi == 1 ? "A." : STTTraLoi == 2 ? "B." : STTTraLoi == 3 ? "C." : "D.",
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart1.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart1.DataBind();
    }

    protected void rpCauHoiPart2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart2 = e.Item.FindControl("rpCauTraLoiPart2") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart2.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart2.DataBind();
    }
    protected void rpCauHoiPart3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart3 = e.Item.FindControl("rpCauTraLoiPart3") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart3.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart3.DataBind();
    }

    protected void rpCauHoiPart4_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart4 = e.Item.FindControl("rpCauTraLoiPart4") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart4.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart4.DataBind();
    }

    protected void rpCauHoiPart5_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart5 = e.Item.FindControl("rpCauTraLoiPart5") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart5.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart5.DataBind();
    }
    protected void rpCauHoiPart6_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart6 = e.Item.FindControl("rpCauTraLoiPart6") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id && t.answer_content != ""
                               select new
                               {
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoiPart6.DataSource = getDataCauTraLoi;
        rpCauTraLoiPart6.DataBind();
    }


    protected void btnCheckCookie_ServerClick(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "checkShow();", true);
    }

    protected void btnClose_ServerClick(object sender, EventArgs e)
    {

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



    protected void btnNopBai_Click(object sender, EventArgs e)
    {

        //try
        //{
        //kiểm tra xem đã làm bài đó chưa.
        var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                          join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                          where rs.test_id == Convert.ToInt32(RouteData.Values["id_test"]) && rs.hocsinh_code == Request.Cookies["User_name"].Value
                          select t;
        //if (checkLamBai.Count() > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Bạn đã làm bài thi này!', '','warning').then(function(){window.location = '/bai-kiem-tra-b1-" + checkLamBai.First().lesson_id + "';})", true);
        //}
        //else
        //{
        tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
        kq.resulttest_result = txtSoCauDung.Value + "/32";
        kq.hocsinh_code = Request.Cookies["User_name"].Value;
        kq.resulttest_datetime = DateTime.Now;
        kq.test_id = Convert.ToInt32(RouteData.Values["id_test"]);
        kq.lop_id = Convert.ToInt32(RouteData.Values["id_khoi"]);
        //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
        kq.result_type = 1;
        db.tbTracNghiem_ResultTests.InsertOnSubmit(kq);
        db.SubmitChanges();

        /*- Tổng điểm phần reading: 30
         - 1 câu đúng được 0.935 điểm
         */

        //khai báo biến listchecked chứa id đáp án đã chọn
        string listChecked = txtChecked.Value;
        string[] arrlistChecked = listChecked.Split(',');
        //khai bóa bi^^ến ít id c^^au hỏi chứa id c^^au hỏi
        string listID = txtIDQuestion.Value;
        string[] arrID = listID.Split(',');
        for (int index = 0; index < arrID.Length; index++)
        {
            //part 1(5 câu), part 3 (5 câu), part 5 (6 câu)
            tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
            kqct.resulttest_id = kq.resulttest_id;
            kqct.question_id = Convert.ToInt32(arrID[index]);
            var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                    where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                                    select t).FirstOrDefault();
            kqct.answer_true_id = getDataCauTraLoi.answer_id + "";//id đáp án đúng trong database
            if (arrlistChecked[index] == "")
                kqct.answer_checked_id = "0";
            else
                kqct.answer_checked_id = arrlistChecked[index]; //id đáp án checked trong bài làm
            if (index <= 4)
                kqct.result_part = 1;
            else if (index > 4 && index <= 9)
                kqct.result_part = 3;
            else
                kqct.result_part = 5;
            if (kqct.answer_true_id == kqct.answer_checked_id)
                kqct.resultchitiet_point = 0.9375;
            else
                kqct.resultchitiet_point = 0;
            db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
            db.SubmitChanges();
        }

        //lưu kết quả part2 & part4
        string[] arrValue = txtValueInput.Value.Split(','); //value nhập vào
        string[] arrIdCauHoi = txtCauHoiPart2_4.Value.Split(','); //id câu hỏi
        for (int i = 0; i < arrValue.Length; i++)
        {
            //part 2(5 câu), part 4 (5 câu)
            tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
            kqct.resulttest_id = kq.resulttest_id;
            kqct.question_id = Convert.ToInt32(arrIdCauHoi[i]);
            var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                    where t.question_id == Convert.ToInt32(arrIdCauHoi[i])
                                    select t).FirstOrDefault();
            kqct.answer_true_id = getDataCauTraLoi.answer_content; //đáp án được nhập trong database
            kqct.answer_checked_id = arrValue[i];//đáp án nhập từ input bài làm
            if (i <= 4)
                kqct.result_part = 2;
            else
                kqct.result_part = 4;
            if (kqct.answer_true_id == kqct.answer_checked_id)
                kqct.resultchitiet_point = 0.9375;
            else
                kqct.resultchitiet_point = 0;
            db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
            db.SubmitChanges();
        }
        //lưu kết quả part6
        string[] arrNhap = txtValuePart6.Value.Split(','); //value nhập vào
        string[] arrIdPart6 = txtCauHoiPart6.Value.Split(','); //id câu hỏi
        string[] arrDungSai = txtDungSai.Value.Split(','); //arr đúng sai
        for (int i = 0; i < arrNhap.Length; i++)
        {
            //part 6 (6 câu)
            tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
            kqct.resulttest_id = kq.resulttest_id;
            kqct.question_id = Convert.ToInt32(arrIdPart6[i]);
            var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                    where t.question_id == Convert.ToInt32(arrIdPart6[i])
                                    select t).FirstOrDefault();
            kqct.answer_true_id = getDataCauTraLoi.answer_content;//đáp án được nhập trong database
            kqct.answer_checked_id = arrNhap[i];//đáp án nhập từ input bài làm
            kqct.result_part = 6;
            if (arrDungSai[i] == "true")
                kqct.resultchitiet_point = 0.9375;
            else
                kqct.resultchitiet_point = 0;
            db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
            db.SubmitChanges();
        }
        //tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
        //if (giatri_0.Value == "")
        //    kqct.answer_checked_id = "0";
        //else
        //    kqct.answer_checked_id = kqct.answer_true_id;
        //db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
        //db.SubmitChanges();

        //sau khi nộp bài thì xóa session link bài kiểm tra
        Session["Url_Test"] = "";
        alert.alert_Success(Page, "Lưu thành công", "");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();HiddenLoadingIcon();", true);
        //}
        //transaction.Commit();
        //}
        //catch (Exception ex)
        //{
        //    alert.alert_Error(Page, "Đã có lỗi xảy ra", "");
        //}

    }
}