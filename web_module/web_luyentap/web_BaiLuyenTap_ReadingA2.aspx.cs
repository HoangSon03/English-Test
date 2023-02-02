using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_luyentap_web_BaiLuyenTap_ReadingA2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1, _part = 2;
    public int S = 31;
    public int P = 6;
    public int STT_Part3 = 11;
    //public int STTTraLoi;
    public int count = 0;
    int question_id;
    int test_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        //int id_Test = 176;  //Convert.ToInt32(RouteData.Values["id_test"]);
        int id_Test = Convert.ToInt32(RouteData.Values["test_id"]);
        test_id = id_Test;
        var checkLamBai = from rs in db.tbTracNghiem_ResultTests
                          join t in db.tbTracNghiem_Tests on rs.test_id equals t.test_id
                          where rs.test_id == id_Test && rs.hocsinh_code == Request.Cookies["User_name"].Value
                          && Convert.ToDateTime(rs.resulttest_datetime).Day == DateTime.Now.Day
                          && Convert.ToDateTime(rs.resulttest_datetime).Month == DateTime.Now.Month
                          && Convert.ToDateTime(rs.resulttest_datetime).Year == DateTime.Now.Year
                          select t;
        if (checkLamBai.Count() > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Hôm nay bạn đã làm bài, hãy quay lại vào ngày hôm sau!', '','warning').then(function(){window.location = '/exercise-list-test-reading';})", true);
        }
        else
        {
            //var getThoiGianLamBaiKiemTra = (from td in db.tbTracNghiem_Tests
            //                                join c in db.tbTracNghiem_BaiThiCates on td.baithicate_id equals c.baithicate_id
            //                                where td.test_id == id_Test
            //                                select c).First();
            //txtPhutHiden.Value = getThoiGianLamBaiKiemTra.thoigianlambai;
            //txtTitle.Value = getThoiGianLamBaiKiemTra.baithicate_name;
            // part1
            var getDataDetails1 = (from td in db.tbTracNghiem_TestDetails
                                   join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                   where td.test_id == id_Test && q.englishquestion_part == "1"
                                   select new
                                   {
                                       td.question_id,
                                       noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                                   });
            rpCauHoiPart1.DataSource = getDataDetails1;
            rpCauHoiPart1.DataBind();
            //get câu hỏi lớn part 2,3,4
            var getCauHoiLon = (from td in db.tbTracNghiem_TestDetails
                                join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                where (td.test_id == id_Test && ch.questionbig_part == "2") || (td.test_id == id_Test && ch.questionbig_part == "3") || (td.test_id == id_Test && ch.questionbig_part == "4")
                                group ch by ch.QuestionBig_id into k
                                select new
                                {
                                    _part = _part + 1,
                                    QuestionBig_id = k.Key,
                                    QuestionBig_content = k.First().QuestionBig_content,
                                });
            rpCauHoiLon.DataSource = getCauHoiLon;
            rpCauHoiLon.DataBind();
            //// part5
            var getCauHoiLonPart5 = (from td in db.tbTracNghiem_TestDetails
                                     join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                     join ch in db.tbTracNghiem_QuestionBigs on q.englishquestion_groupidquestion equals ch.QuestionBig_id
                                     where td.test_id == id_Test && ch.questionbig_part == "5"
                                     group ch by ch.QuestionBig_id into k
                                     select new
                                     {
                                         QuestionBig_id = k.Key,
                                         QuestionBig_content = k.First().QuestionBig_content,
                                     });
            rpCauHoiLonPart5.DataSource = getCauHoiLonPart5;
            rpCauHoiLonPart5.DataBind();
            var listCauHoiPart5 = (from td in db.tbTracNghiem_TestDetails
                                   join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                   where td.test_id == id_Test //&& q.englishquestion_groupidquestion == getCauHoiLonPart5.First().QuestionBig_id
                                   && q.englishquestion_part == "5"
                                   select new
                                   {
                                       td.question_id,
                                       noidungcauhoi = q.englishquestion_content,
                                   });
            rpCauHoiPart5.DataSource = listCauHoiPart5;
            rpCauHoiPart5.DataBind();
            var getDataDetails67 = (from td in db.tbTracNghiem_TestDetails
                                    join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                                    where td.test_id == id_Test
                                    select new
                                    {
                                        td.question_id,
                                        noidungcauhoi = q.englishquestion_content
                                    }).Skip(30);
            rpCauHoiPart67.DataSource = getDataDetails67;
            rpCauHoiPart67.DataBind();
            ////check hiển thị các câu hỏi cứng
            //var checkDe = (from t in db.tbTracNghiem_Tests
            //               where t.test_id == id_Test
            //               select t).FirstOrDefault();
            //if (checkDe.lesson_id == 119)//đề 1
            //{
            //    div_Part2_De1.Visible = true;
            //    div_Part3_De1.Visible = true;
            //    div_Part4_De1.Visible = true;
            //    div_Part5_De1.Visible = true;
            //    div_Part2_De2.Visible = false;
            //    div_Part3_De2.Visible = false;
            //    div_Part4_De2.Visible = false;
            //    div_Part5_De2.Visible = false;
            //}
            //else if (checkDe.lesson_id == 120)//đề 2
            //{
            //    div_Part2_De1.Visible = false;
            //    div_Part3_De1.Visible = false;
            //    div_Part4_De1.Visible = false;
            //    div_Part5_De1.Visible = false;
            //    div_Part2_De2.Visible = true;
            //    div_Part3_De2.Visible = true;
            //    div_Part4_De2.Visible = true;
            //    div_Part5_De2.Visible = true;
            //}

            //var getCauHoiLon = from chl in db.tbTracNghiem_QuestionBigs where chl.QuestionBig_id == 1 select chl;
            //Rp_cau_hoi_lon.DataSource = getCauHoiLon;
            //Rp_cau_hoi_lon.DataBind();
            //var getCauHoiLon2 = from chl in db.tbTracNghiem_QuestionBigs where chl.QuestionBig_id == 2 select chl;
            //Rp_cau_hoi_lon2.DataSource = getCauHoiLon2;
            //Rp_cau_hoi_lon2.DataBind();
            //count = getDataDetails.Count();
        }
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "countdown(ten-countdown,2, 0)", true);
    }

    protected void rpCauHoiDetals_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
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
                              where rs.test_id == test_id && rs.hocsinh_code == Request.Cookies["User_name"].Value
                              && Convert.ToDateTime(rs.resulttest_datetime).Day == DateTime.Now.Day
                              && Convert.ToDateTime(rs.resulttest_datetime).Month == DateTime.Now.Month
                              && Convert.ToDateTime(rs.resulttest_datetime).Year == DateTime.Now.Year
                              select t;
            if (checkLamBai.Count() > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Hôm nay bạn đã làm bài, hãy quay lại vào ngày hôm sau!', '','warning').then(function(){window.location = '/exercise-list-test-reading';})", true);
            }
            else
            {
                //
                tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
                kq.resulttest_result = txtSoCauDung.Value;
                kq.hocsinh_code = Request.Cookies["User_name"].Value;
                kq.resulttest_datetime = DateTime.Now;
                kq.test_id = Convert.ToInt32(RouteData.Values["test_id"]);
                kq.lop_id = 18;
                //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
                kq.result_type = 2;
                db.tbTracNghiem_ResultTests.InsertOnSubmit(kq);
                db.SubmitChanges();
                //int TongDiem = 0;

                //khai báo biến listchecked chứa id đáp án đánchọn
                string listChecked = txtChecked.Value;
                string[] arrlistChecked = listChecked.Split(',');
                //khai bóa bi^^ến ít id c^^au hỏi chứa id c^^au hỏi
                string listID = txtIDQuestion.Value;
                string[] arrID = listID.Split(',');
                for (int index = 0; index < arrID.Length; index++)
                {
                    //part 1(6 câu), part 3 (7 câu), part 3 (5 câu), part 4 (6 câu)
                    tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
                    kqct.resulttest_id = kq.resulttest_id;
                    kqct.question_id = Convert.ToInt32(arrID[index]);
                    var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                            where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                                            select t).FirstOrDefault();
                    kqct.answer_true_id = getDataCauTraLoi.answer_id + "";
                    if (arrlistChecked[index] == "")
                        kqct.answer_checked_id = "0";
                    else
                        kqct.answer_checked_id = arrlistChecked[index];

                    //lưu part
                    if (index <= 5)
                        kqct.result_part = 1;
                    else if (index > 5 && index <= 12)
                        kqct.result_part = 2;
                    else if (index > 12 && index <= 17)
                        kqct.result_part = 3;
                    else
                        kqct.result_part = 4;
                    //mỗi câu trắc nghiệm đúng được 1 điểm
                    if (kqct.answer_true_id == kqct.answer_checked_id)
                    {
                        kqct.resultchitiet_point = 1;
                        kqct.result_phantram = 3.33;
                    }
                    else
                    {
                        kqct.resultchitiet_point = 0;
                        kqct.result_phantram = 0;
                    }
                    db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
                    db.SubmitChanges();
                }

                //lưu kết quả những câu nhập 
                if (txtValueInput.Value != "")
                {
                    string[] arrValue = txtValueInput.Value.Split(',');//giá trị nhập vào
                    string[] arrDapAnDung = txtDanAnInput.Value.Split(',');//check đúng sai
                    string[] arr_ID = txtDanhSachID.Value.Split(',');//id câu hỏi

                    for (int i = 0; i < arrValue.Length; i++)
                    {
                        //part 5 6 câu
                        tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
                        kqct.resulttest_id = kq.resulttest_id;
                        kqct.question_id = Convert.ToInt32(arr_ID[i]);
                        var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                                where t.question_id == Convert.ToInt32(arr_ID[i])
                                                select t).FirstOrDefault();
                        kqct.answer_true_id = getDataCauTraLoi.answer_content;//đáp án được nhập trong database
                        kqct.answer_checked_id = arrValue[i];//đáp án nhập từ input bài làm
                                                             //kqct.answer_true_id = arrDapAnDung[i];
                                                             //kqct.answer_checked_id = arrValue[i];
                        kqct.result_part = 5;
                        if (arrDapAnDung[i] == "true")
                        {
                            kqct.resultchitiet_point = 1;
                            kqct.result_phantram = 3.33;
                        }
                        else
                        {
                            kqct.resultchitiet_point = 0;
                            kqct.result_phantram = 0;
                        }
                        db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
                        db.SubmitChanges();
                    }
                }
                //phần viết
                if (txtContentWriting.Value != "")
                {
                    string[] arrContent = txtContentWriting.Value.Split('|');
                    string[] arridWriting = txtIDWriting.Value.Split(',');
                    int part = 6;
                    for (int i = 0; i < arridWriting.Length; i++)
                    {
                        tbTracNghiem_ResultChiTiet part6 = new tbTracNghiem_ResultChiTiet();
                        part6.resulttest_id = kq.resulttest_id;
                        part6.question_id = Convert.ToInt32(arridWriting[i]);
                        part6.answer_checked_id = arrContent[i].Replace("\n", "<br/>");
                        part6.result_part = part++;
                        db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part6);
                        db.SubmitChanges();
                    }
                }
                //tbTracNghiem_ResultChiTiet part6 = new tbTracNghiem_ResultChiTiet();
                //part6.resulttest_id = kq.resulttest_id;
                //part6.question_id = Convert.ToInt32(txtIDQuestion1.Value);
                //part6.answer_checked_id = txtDapAn1.Value.Replace("\n", "<br/>");
                //part6.result_part = 6;
                //db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part6);
                //db.SubmitChanges();
                ////insert part7
                //tbTracNghiem_ResultChiTiet part7 = new tbTracNghiem_ResultChiTiet();
                //part7.resulttest_id = kq.resulttest_id;
                ////part7.question_id = Convert.ToInt32(txtIDQuestion2.Value);
                ////part7.answer_checked_id = txtDapAn2.Value.Replace("\n", "<br/>");
                //part7.result_part = 7;
                //db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(part7);
                //db.SubmitChanges();
                //sau khi nộp bài thì xóa session link bài kiểm tra
                Session["Url_Test"] = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showPopUp();HiddenLoadingIcon();", true);
            }
            //transaction.Commit();
            //}
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
        //int id_Test = Convert.ToInt32(RouteData.Values["test_id"]);
        //var checkTest = (from t in db.tbTracNghiem_Tests
        //                 where t.test_id == id_Test
        //                 select t).FirstOrDefault();
        //Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);
        Response.Redirect("/exercise-list-test-reading");
    }

    protected void rpCauHoiPart2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
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
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
    }

    protected void rpCauHoiPart3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
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
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
    }

    protected void rpCauHoiPart4_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
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
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
    }

    protected void rpCauHoiPart1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
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
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
    }
    protected void check_back_ServerClick(object sender, EventArgs e)
    {
        //chuyển về form các phần của bài thi
        //int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        //var checkTest = (from t in db.tbTracNghiem_Tests
        //                 where t.test_id == id_Test
        //                 select t).FirstOrDefault();
        //Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);
        Response.Redirect("/exercise-list-test-reading");
    }

    protected void rpCauHoiLon_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauHoiPart2 = e.Item.FindControl("rpCauHoiPart2") as Repeater;
        int questionbig_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "QuestionBig_id").ToString());

        var getQuestion = (from td in db.tbTracNghiem_TestDetails
                           join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                           where td.test_id == test_id && q.englishquestion_groupidquestion == questionbig_id
                           select new
                           {
                               td.question_id,
                               noidungcauhoi = q.englishquestion_part == "2" || q.englishquestion_part == "4" ? "" : q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                           });
        rpCauHoiPart2.DataSource = getQuestion;
        rpCauHoiPart2.DataBind();
    }

    protected void rpCauHoiPart5_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart5 = e.Item.FindControl("rpCauTraLoiPart5") as Repeater;
        int question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
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
}