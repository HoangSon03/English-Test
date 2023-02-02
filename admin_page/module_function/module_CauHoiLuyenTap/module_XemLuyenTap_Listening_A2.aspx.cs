using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_XemLuyenTap_Listening_A2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STT_Part3 = 11;
    public int STTT = 20;
    //public int STTTraLoi;
    public int count = 0;
    int question_id;
    public double seconds = 0.0;
    public int STT_Part = 3;
    int test_id;
    cls_Alert alert = new cls_Alert();
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var user = (from u in db.admin_Users
                        where u.username_username == Request.Cookies["UserName"].Value
                        select u).FirstOrDefault();
            _idUser = user.username_id;
            if (_idUser != 24)//cô thủy trung tâm
            {
                btnXacnhanhoanthanh.Visible = false;
            }
            else
            {
                btnXacnhanhoanthanh.Visible = true;
                btnChuyenDuyet.Visible = false;
            }
            //int id_Test = 177; //Convert.ToInt32(RouteData.Values["id_test"]);
            int id_Test = Convert.ToInt32(RouteData.Values["test_id"]);
        test_id = id_Test;
        var checkTrangThai = (from t in db.tbTracNghiem_Tests where t.test_id == test_id select t).FirstOrDefault();
        if (checkTrangThai.test_trangthai == "Đã duyệt")
        {
            btnChuyenDuyet.Visible = false;
        }
        //get câu hỏi part1
        var getCHLPart1 = (from t in db.tbTracNghiem_Tests
                           join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                           where t.test_id == id_Test && qsb.questionbig_part == "1"
                           select new
                           {
                               t.test_id,
                               qsb.QuestionBig_id,
                               qsb.questionbig_mp3
                           });
        rpAmThanhPart1.DataSource = getCHLPart1;
        rpAmThanhPart1.DataBind();
        var getDataDetails = (from td in db.tbTracNghiem_TestDetails
                              join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                              where td.test_id == id_Test && q.englishquestion_part == "1"
                              select new
                              {
                                  td.question_id,
                                  noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                              });
        rpCauHoiPart1.DataSource = getDataDetails;
        rpCauHoiPart1.DataBind();
        //get câu hỏi lớn part2
        var getCHL_Part2 = (from t in db.tbTracNghiem_Tests
                            join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                            where t.test_id == id_Test && qsb.questionbig_part == "2" && t.hidden == false
                            orderby qsb.QuestionBig_id descending
                            select new
                            {
                                t.test_id,
                                qsb.QuestionBig_id,
                                qsb.questionbig_mp3,
                                qsb.QuestionBig_content,
                            }).Take(1);
        rpCauHoiLonPart2.DataSource = getCHL_Part2;
        rpCauHoiLonPart2.DataBind();
        //get câu hỏi part2
        var getCauHoiPart2 = (from td in db.tbTracNghiem_TestDetails
                              join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                              where td.test_id == id_Test && q.englishquestion_groupidquestion == getCHL_Part2.FirstOrDefault().QuestionBig_id
                              && q.englishquestion_part == "2"
                              select new
                              {
                                  td.question_id,
                                  noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                              });
        rpCauHoiPart2.DataSource = getCauHoiPart2;
        rpCauHoiPart2.DataBind();
        //get câu hỏi lớn part3, part4
        var getCHL = (from t in db.tbTracNghiem_Tests
                      join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                      where (t.test_id == id_Test && qsb.questionbig_part == "3") || (t.test_id == id_Test && qsb.questionbig_part == "4")
                      select new
                      {
                          t.test_id,
                          qsb.QuestionBig_id,
                          qsb.questionbig_mp3
                      });
        rpCauHoiLon.DataSource = getCHL;
        rpCauHoiLon.DataBind();

        //get câu hỏi lớn part5
        var getCHL_Part5 = (from t in db.tbTracNghiem_Tests
                            join qsb in db.tbTracNghiem_QuestionBigs on t.kynang_id equals qsb.lesson_id.ToString()
                            where t.test_id == id_Test && qsb.questionbig_part == "5"
                            select new
                            {
                                t.test_id,
                                qsb.QuestionBig_id,
                                qsb.questionbig_mp3,
                                qsb.QuestionBig_content,
                            });
        rpCauHoiLonPart5.DataSource = getCHL_Part5;
        rpCauHoiLonPart5.DataBind();
        //get câu hỏi part5
        var getCauHoiPart5 = (from td in db.tbTracNghiem_TestDetails
                              join q in db.tbTracNghiem_EnglishQuestions on td.question_id equals q.englishquestion_id
                              where td.test_id == id_Test && q.englishquestion_groupidquestion == getCHL_Part5.FirstOrDefault().QuestionBig_id
                              && q.englishquestion_part == "5"
                              select new
                              {
                                  td.question_id,
                                  noidungcauhoi = q.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + q.englishquestion_content + "</div>" : q.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.englishquestion_content + "'>" : q.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + q.englishquestion_content + "'> </audio>" : q.englishquestion_content
                              });
        rpCauHoiPart5.DataSource = getCauHoiPart5;
        rpCauHoiPart5.DataBind();
    }
        else
        {
            Response.Redirect("/admin-login");
        }
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
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
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
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Hôm nay bạn đã làm bài, hãy quay lại vào ngày hôm sau!', '','warning').then(function(){window.location = '/exercise-list-test-listening';})", true);
            }
            else
            {
                tbTracNghiem_ResultTest kq = new tbTracNghiem_ResultTest();
                kq.resulttest_result = txtSoCauDung.Value + "/25";
                kq.hocsinh_code = Request.Cookies["User_name"].Value;
                kq.resulttest_datetime = DateTime.Now;
                kq.test_id = Convert.ToInt32(RouteData.Values["test_id"]);
                kq.lop_id = Convert.ToInt32(RouteData.Values["id_khoi"]);
                //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
                kq.result_type = 2;
                db.tbTracNghiem_ResultTests.InsertOnSubmit(kq);
                db.SubmitChanges();
                //khai bábaosieens listchecked chứa id đáp án đánc chọn
                /*
                 - Tổng điểm là 25
                - mỗi câu đúng được 1đ
                 */
                string listChecked = txtChecked.Value;
                string[] arrlistChecked = listChecked.Split(',');
                //khai bóa bi^^ến ít id c^^au hỏi chứa id c^^au hỏi
                string listID = txtIDQuestion.Value;
                string[] arrID = listID.Split(',');
                for (int index = 0; index < arrID.Length; index++)
                {
                    //part 1(5 câu), part 3 (5 câu), part 4 (5 câu)
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
                    if (index <= 4)
                        kqct.result_part = 1;
                    else if (index > 4 && index <= 9)
                        kqct.result_part = 3;
                    else
                        kqct.result_part = 4;
                    if (kqct.answer_true_id == kqct.answer_checked_id)
                        kqct.resultchitiet_point = 1;
                    else
                        kqct.resultchitiet_point = 0;
                    db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
                    db.SubmitChanges();
                }
                //lưu part 2
                string[] arrValue = txtValuePart2.Value.Split(',');//giá trị nhập vào
                string[] arrDapAnDung = txtDungSai.Value.Split(',');//check đúng sai
                string[] arrCheck = txtCauHoiPart2.Value.Split(',');//id câu hỏi
                for (int i = 0; i < arrValue.Length; i++)
                {
                    tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
                    kqct.resulttest_id = kq.resulttest_id;
                    kqct.question_id = Convert.ToInt32(arrCheck[i]);
                    var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                            where t.question_id == Convert.ToInt32(arrCheck[i])
                                            select t).FirstOrDefault();
                    kqct.answer_true_id = getDataCauTraLoi.answer_content; //đáp án được nhập trong database
                    kqct.answer_checked_id = arrValue[i];//đáp án nhập từ input bài làm
                    kqct.result_part = 2;
                    if (arrDapAnDung[i] == "true")
                        kqct.resultchitiet_point = 1;
                    else
                        kqct.resultchitiet_point = 0;
                    db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
                    db.SubmitChanges();
                }
                //lưu part 5
                string[] arrValuePart5 = txtValuePart5.Value.Split(',');//giá trị nhập vào
                string[] arrDapAnDungPart5 = txtDungSaiPart5.Value.Split(',');//check đúng sai
                string[] arrCheckPart5 = txtCauHoiPart5.Value.Split(',');//id câu hỏi
                for (int i = 0; i < arrValuePart5.Length; i++)
                {
                    tbTracNghiem_ResultChiTiet kqct = new tbTracNghiem_ResultChiTiet();
                    kqct.resulttest_id = kq.resulttest_id;
                    kqct.question_id = Convert.ToInt32(arrCheckPart5[i]);
                    var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                                            where t.question_id == Convert.ToInt32(arrCheckPart5[i])
                                            select t).FirstOrDefault();
                    kqct.answer_true_id = getDataCauTraLoi.answer_content; //đáp án được nhập trong database
                    kqct.answer_checked_id = arrValuePart5[i];//đáp án nhập từ input bài làm
                    kqct.result_part = 5;
                    if (arrDapAnDungPart5[i] == "true")
                        kqct.resultchitiet_point = 1;
                    else
                        kqct.resultchitiet_point = 0;
                    db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(kqct);
                    db.SubmitChanges();
                }
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

    protected void rpCauHoiPart1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
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

    protected void rpCauHoiPart2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
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
    protected void btnClose_ServerClick(object sender, EventArgs e)
    {
        //chuyển về form các phần của bài thi
        //int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        //var checkTest = (from t in db.tbTracNghiem_Tests
        //                 where t.test_id == id_Test
        //                 select t).FirstOrDefault();
        //Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);
        Response.Redirect("exercise-list-test-listening");
    }
    protected void check_back_ServerClick(object sender, EventArgs e)
    {
        //chuyển về form các phần của bài thi
        //int id_Test = Convert.ToInt32(RouteData.Values["id_test"]);
        //var checkTest = (from t in db.tbTracNghiem_Tests
        //                 where t.test_id == id_Test
        //                 select t).FirstOrDefault();
        //Response.Redirect("/bai-kiem-tra-b1-" + checkTest.lesson_id);
        Response.Redirect("exercise-list-test-listening");
    }

    protected void rpCauHoiPart2_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart2 = e.Item.FindControl("rpCauTraLoiPart2") as Repeater;
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
        rpCauTraLoiPart2.DataSource = getCauTraLoi;
        rpCauTraLoiPart2.DataBind();
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

    protected void rpCauHoiPart5_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpCauTraLoiPart5 = e.Item.FindControl("rpCauTraLoiPart5") as Repeater;
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
        rpCauTraLoiPart5.DataSource = getCauTraLoi;
        rpCauTraLoiPart5.DataBind();
    }
    protected void btnChuyenDuyet_ServerClick(object sender, EventArgs e)
    {
        tbTracNghiem_Test update = (from t in db.tbTracNghiem_Tests
                                    where t.test_id == test_id
                                    select t).FirstOrDefault();
        if (_idUser == 22)//tổ trưởng duyệt
        {
            update.test_trangthai = "Tổ trưởng đã duyệt";
            db.SubmitChanges();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Chuyển duyệt thành công!', '','success').then(function(){window.location = '/admin-duyet-bai-luyen-tap';})", true);
        }
        else
        {
            update.test_trangthai = "Chờ duyệt";
            db.SubmitChanges();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Chuyển duyệt thành công!', '','success').then(function(){window.location = '/admin-danh-sach-bai-luyen-tap';})", true);
        }
    }
    protected void btnBack_ServerClick(object sender, EventArgs e)
    {
        if (_idUser == 22 || _idUser == 24)//cô trâm tổ trưởng và cô thủy tổ trưởng
        {
            Response.Redirect("/admin-duyet-bai-luyen-tap");
        }
        else
        {
            //giáo viên bth
            Response.Redirect("/admin-danh-sach-bai-luyen-tap");
        }
    }

    protected void btnXacnhanhoanthanh_ServerClick(object sender, EventArgs e)
    {
        tbTracNghiem_Test update = (from t in db.tbTracNghiem_Tests
                                    where t.test_id == test_id
                                    select t).FirstOrDefault();
        update.test_trangthai = "Đã duyệt";
        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Chuyển duyệt thành công!', '','success').then(function(){window.location = '/admin-duyet-bai-luyen-tap';})", true);
    }
}