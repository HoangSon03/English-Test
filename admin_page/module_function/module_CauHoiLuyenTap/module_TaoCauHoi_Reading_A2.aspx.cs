using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoi_Reading_A2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public string image;
    private int username_id;
    int _id;
    int mon_id, dethi_id, kynang_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        username_id = getUser.username_id;
        mon_id = Convert.ToInt32(RouteData.Values["mon_id"]);
        dethi_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
        kynang_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
        if (!IsPostBack)
        {
            edtContent.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnA.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnB.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnC.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnD.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtNoiDungPart5.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtContentCauHoi.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDA_A.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDA_B.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDA_C.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDA_D.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtNoiDungDe.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            //var listLoaiBai = from mhck in db.tbMonHocCuaKhois
            //                  join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
            //                  where mhck.khoi_id == 18 && mhck.hidden == true //id = 18 là môn tiếng anh
            //                  select mh;
            //ddlLoaiBai.Items.Clear();
            //ddlLoaiBai.AppendDataBoundItems = true;
            //ddlLoaiBai.Items.Insert(0, "Chọn bài thi");
            //ddlLoaiBai.DataValueField = "monhoc_id";
            //ddlLoaiBai.DataTextField = "monhoc_name";
            //ddlLoaiBai.DataSource = listLoaiBai;
            //ddlLoaiBai.DataBind();
            Session["_id"] = 0;
        }
        //if (ddlKyNang.SelectedValue != "")
        //    getCH();
        loadData();
    }
    private void loadData()
    {
        var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
                        join c in db.tbTracNghiem_KyNangs on gdtCH.kynang_id equals c.kynang_id
                        join name in db.admin_Users on gdtCH.username_id equals name.username_id
                        where gdtCH.hidden == false
                        && gdtCH.kynang_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
                        //orderby gdtCH.englishquestion_id descending
                        select new
                        {
                            c.kynang_id,
                            //englishquestion_content = gdtCH.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + gdtCH.englishquestion_content + "'</div>" : gdtCH.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.englishquestion_content + "'> </audio>" : gdtCH.englishquestion_content,
                            englishquestion_content = gdtCH.englishquestion_content,
                            gdtCH.englishquestion_createdate,
                            c.kynang_name,
                            name.username_fullname,
                            gdtCH.englishquestion_id,

                        };
        grvList.DataSource = gdtCauhoi;
        grvList.DataBind();
    }
    private void themTracNghiem()
    {
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
        themcauhoi.englishquestion_content = edtContent.Html;
        themcauhoi.englishquestion_createdate = DateTime.Now;
        themcauhoi.username_id = getUser.username_id;
        themcauhoi.dethi_id = dethi_id;
        themcauhoi.hidden = false;
        themcauhoi.kynang_id = kynang_id;
        themcauhoi.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
        db.SubmitChanges();
        Session["_id"] = themcauhoi.englishquestion_id;
        //lưu đáp án A
        tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
        dapanA.answer_content = edtDapAnA.Html;
        dapanA.question_id = themcauhoi.englishquestion_id;
        if (DaA.Checked == true)
            dapanA.answer_true = true;
        else
            dapanA.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
        tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
        dapanB.answer_content = edtDapAnB.Html;
        dapanB.question_id = themcauhoi.englishquestion_id;
        if (DaB.Checked == true)
            dapanB.answer_true = true;
        else
            dapanB.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
        tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
        dapanC.answer_content = edtDapAnC.Html;
        dapanC.question_id = themcauhoi.englishquestion_id;
        if (DaC.Checked == true)
            dapanC.answer_true = true;
        else
            dapanC.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
        tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
        dapanD.answer_content = edtDapAnD.Html;
        dapanD.question_id = themcauhoi.englishquestion_id;
        if (DaD.Checked == true)
            dapanD.answer_true = true;
        else
            dapanD.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
        db.SubmitChanges();
        alert.alert_Success(Page, "Lưu thành công", "");
        //loadData();
    }
    private void updateTracNghiem()
    {
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                       select ct).Single();
        chitiet.englishquestion_content = edtContent.Html;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + chitiet.englishquestion_content + "')", true);
        //chitiet.englishquestion_level = txtLoaiCauHoi.Value;
        //chitiet.englishquestion_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
        //chitiet.englishquestion_giaithich = edtGiaiThich.Html;
        db.SubmitChanges();
        // update bẳng answer
        //update đáp án A
        var updapanA = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).First();
        updapanA.answer_content = edtDapAnA.Html;
        if (DaA.Checked == true)
            updapanA.answer_true = true;
        else
            updapanA.answer_true = false;
        //update đáp án B
        var updapanB = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(1).Take(1).First();
        updapanB.answer_content = edtDapAnB.Html;
        if (DaB.Checked == true)
            updapanB.answer_true = true;
        else
            updapanB.answer_true = false;

        //update đáp án C
        var updapanC = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(2).Take(1).First();
        updapanC.answer_content = edtDapAnC.Html;
        if (DaC.Checked == true)
            updapanC.answer_true = true;
        else
            updapanC.answer_true = false;
        //update đáp án D
        var updapanD = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(3).Take(1).First();
        updapanD.answer_content = edtDapAnD.Html;
        if (DaD.Checked == true)
            updapanD.answer_true = true;
        else
            updapanD.answer_true = false;
        db.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công", "");
        btnLuuCauHoi.Text = "Cập nhật";
        btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
        loadData();
    }
    private void themTuLuan()
    {
        /*
         lưu hình ảnh ở bảng câu hỏi lớn,
         stt câu hỏi ở bảng câu hỏi,
         đáp án ở bảng đáp án và là đáp án đúng
         */
        tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
        content.QuestionBig_content = edtNoiDungPart5.Html;
        content.questionbig_part = txtPart.Value;
        content.lesson_id = kynang_id;
        db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau1 = new tbTracNghiem_EnglishQuestion();
        cau1.englishquestion_content = txtCau1.Value.Trim();
        cau1.englishquestion_createdate = DateTime.Now;
        cau1.username_id = username_id;
        cau1.dethi_id = dethi_id;
        cau1.hidden = false;
        cau1.kynang_id = kynang_id;
        cau1.englishquestion_groupidquestion = content.QuestionBig_id;
        cau1.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau1);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan1 = new tbTracNghiem_Answer();
        dapan1.answer_content = txtDapAn1.Value.Trim();
        dapan1.question_id = cau1.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan1);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau2 = new tbTracNghiem_EnglishQuestion();
        cau2.englishquestion_content = txtCau2.Value.Trim();
        cau2.englishquestion_createdate = DateTime.Now;
        cau2.username_id = username_id;
        cau2.dethi_id = dethi_id;
        cau2.hidden = false;
        cau2.kynang_id = kynang_id;
        cau2.englishquestion_groupidquestion = content.QuestionBig_id;
        cau2.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau2);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan2 = new tbTracNghiem_Answer();
        dapan2.answer_content = txtDapAn2.Value.Trim();
        dapan2.question_id = cau2.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan2);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau3 = new tbTracNghiem_EnglishQuestion();
        cau3.englishquestion_content = txtCau3.Value.Trim();
        cau3.englishquestion_createdate = DateTime.Now;
        cau3.username_id = username_id;
        cau3.dethi_id = dethi_id;
        cau3.hidden = false;
        cau3.kynang_id = kynang_id;
        cau3.englishquestion_groupidquestion = content.QuestionBig_id;
        cau3.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau3);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan3 = new tbTracNghiem_Answer();
        dapan3.answer_content = txtDapAn3.Value.Trim();
        dapan3.question_id = cau3.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan3);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau4 = new tbTracNghiem_EnglishQuestion();
        cau4.englishquestion_content = txtCau4.Value.Trim();
        cau4.englishquestion_createdate = DateTime.Now;
        cau4.username_id = username_id;
        cau4.dethi_id = dethi_id;
        cau4.hidden = false;
        cau4.kynang_id = kynang_id;
        cau4.englishquestion_groupidquestion = content.QuestionBig_id;
        cau4.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau4);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan4 = new tbTracNghiem_Answer();
        dapan4.answer_content = txtDapAn4.Value.Trim();
        dapan4.question_id = cau4.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan4);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau5 = new tbTracNghiem_EnglishQuestion();
        cau5.englishquestion_content = txtCau5.Value.Trim();
        cau5.englishquestion_createdate = DateTime.Now;
        cau5.username_id = username_id;
        cau5.dethi_id = dethi_id;
        cau5.hidden = false;
        cau5.kynang_id = kynang_id;
        cau5.englishquestion_groupidquestion = content.QuestionBig_id;
        cau5.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau5);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan5 = new tbTracNghiem_Answer();
        dapan5.answer_content = txtDapAn5.Value.Trim();
        dapan5.question_id = cau5.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan5);
        db.SubmitChanges();
        tbTracNghiem_EnglishQuestion cau6 = new tbTracNghiem_EnglishQuestion();
        cau6.englishquestion_content = txtCau6.Value.Trim();
        cau6.englishquestion_createdate = DateTime.Now;
        cau6.username_id = username_id;
        cau6.dethi_id = dethi_id;
        cau6.hidden = false;
        cau6.kynang_id = kynang_id;
        cau6.englishquestion_groupidquestion = content.QuestionBig_id;
        cau6.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau6);
        db.SubmitChanges();
        tbTracNghiem_Answer dapan6 = new tbTracNghiem_Answer();
        dapan6.answer_content = txtDapAn6.Value.Trim();
        dapan6.question_id = cau6.englishquestion_id;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapan6);
        db.SubmitChanges();
        alert.alert_Success(Page, "Lưu thành công", "");
    }
    //update đáp án part5
    private void updateTuLuan()
    {
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                       select ct).Single();
        var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                         where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                         select q).FirstOrDefault();
        var getDapAn = (from da in db.tbTracNghiem_Answers
                        join ch in db.tbTracNghiem_EnglishQuestions on da.question_id equals ch.englishquestion_id
                        where ch.englishquestion_groupidquestion == cauhoilon.QuestionBig_id
                        select da);

        cauhoilon.QuestionBig_content = edtNoiDungDe.Html;
        db.SubmitChanges();
        if (txtDapAn1.Value != "")
            getDapAn.First().answer_content = txtDapAn1.Value;
        if (txtDapAn2.Value != "")
            getDapAn.Skip(1).Take(1).FirstOrDefault().answer_content = txtDapAn2.Value;
        if (txtDapAn3.Value != "")
            getDapAn.Skip(2).Take(1).FirstOrDefault().answer_content = txtDapAn3.Value;
        if (txtDapAn4.Value != "")
            getDapAn.Skip(3).Take(1).FirstOrDefault().answer_content = txtDapAn4.Value;
        if (txtDapAn5.Value != "")
            getDapAn.Skip(4).Take(1).FirstOrDefault().answer_content = txtDapAn5.Value;
        if (txtDapAn6.Value != "")
            getDapAn.Skip(5).Take(1).FirstOrDefault().answer_content = txtDapAn6.Value;
        db.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công", "");
        //btnLuuTuLuan.Text = "Cập nhật";
        loadData();
    }

    private void themData()
    {
        if (edtNoiDungDe.Html != "")
        {
            tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
            content.QuestionBig_content = edtNoiDungDe.Html;
            content.questionbig_part = txtPart.Value;
            content.lesson_id = kynang_id;
            db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
            db.SubmitChanges();
            Session["questionbig_id"] = content.QuestionBig_id;
        }
        tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
        themcauhoi.englishquestion_content = edtContentCauHoi.Html;
        themcauhoi.englishquestion_createdate = DateTime.Now;
        themcauhoi.username_id = username_id;
        themcauhoi.dethi_id = dethi_id;
        themcauhoi.hidden = false;
        themcauhoi.kynang_id = kynang_id;
        themcauhoi.englishquestion_groupidquestion = Convert.ToInt32(Session["questionbig_id"]);
        themcauhoi.englishquestion_part = txtPart.Value;
        db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
        db.SubmitChanges();
        Session["_id"] = themcauhoi.englishquestion_id;
        //lưu đáp án A
        tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
        dapanA.answer_content = edtDA_A.Html;
        dapanA.question_id = themcauhoi.englishquestion_id;
        if (ckDA_A.Checked == true)
            dapanA.answer_true = true;
        else
            dapanA.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
        tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
        dapanB.answer_content = edtDA_B.Html;
        dapanB.question_id = themcauhoi.englishquestion_id;
        if (ckDA_B.Checked == true)
            dapanB.answer_true = true;
        else
            dapanB.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
        tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
        dapanC.answer_content = edtDA_C.Html;
        dapanC.question_id = themcauhoi.englishquestion_id;
        if (ckDA_C.Checked == true)
            dapanC.answer_true = true;
        else
            dapanC.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
        tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
        dapanD.answer_content = edtDA_D.Html;
        dapanD.question_id = themcauhoi.englishquestion_id;
        if (ckDA_D.Checked == true)
            dapanD.answer_true = true;
        else
            dapanD.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
        db.SubmitChanges();
        alert.alert_Success(Page, "Lưu thành công", "");
        //loadData();
    }

    private void updateData()
    {
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                       select ct).Single();
        var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                         where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                         select q).FirstOrDefault();
        if (edtNoiDungDe.Html != "")
        {
            cauhoilon.QuestionBig_content = edtNoiDungDe.Html;
            db.SubmitChanges();
        }
        chitiet.englishquestion_content = edtContentCauHoi.Html;
        chitiet.englishquestion_createdate = DateTime.Now;
        db.SubmitChanges();
        // update bẳng answer
        //update đáp án A
        var updapanA = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).First();
        updapanA.answer_content = edtDA_A.Html;
        if (ckDA_A.Checked == true)
            updapanA.answer_true = true;
        else
            updapanA.answer_true = false;
        //update đáp án B
        var updapanB = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(1).Take(1).First();
        updapanB.answer_content = edtDA_B.Html;
        if (ckDA_B.Checked == true)
            updapanB.answer_true = true;
        else
            updapanB.answer_true = false;

        //update đáp án C
        var updapanC = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(2).Take(1).First();
        updapanC.answer_content = edtDA_C.Html;
        if (ckDA_C.Checked == true)
            updapanC.answer_true = true;
        else
            updapanC.answer_true = false;
        //update đáp án D
        var updapanD = (from xDa in db.tbTracNghiem_Answers
                        where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                        select xDa).Skip(3).Take(1).First();
        updapanD.answer_content = edtDA_D.Html;
        if (ckDA_D.Checked == true)
            updapanD.answer_true = true;
        else
            updapanD.answer_true = false;
        db.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công", "");
        btnLuuCauHoi.Text = "Cập nhật";
        btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
        //loadData();
    }
    protected void btnLuuCauHoi_Click(object sender, EventArgs e)
    {
        int dem_DapAnChecked = 0;
        if (DaA.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (DaB.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaC.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaD.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (DaA.Checked == false && DaB.Checked == false && DaC.Checked == false && DaD.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA.Html == "" || edtDapAnB.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }
        //else if ((edtDapAnC.Html == "" || edtDapAnD.Html == "") && (DaC.Checked == false || DaD.Checked == false))
        //{
        //    alert.alert_Error(Page, "Lỗi ", "");
        //}
        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                //tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
                themTracNghiem();
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                loadData();
                //if (ddlLoaiCauHoi.SelectedValue != "Nhận biết")
                //{
                //    themcauhoi.englishquestion_content = image;
                //}
                //else
                //{
                //    themcauhoi.englishquestion_content = edtContent.Html;
                //}
            }
            else
            {
                //update
                updateTracNghiem();
            }
        }
    }
    private void datarong()
    {
        edtDapAnA.Html = "";
        edtDapAnB.Html = "";
        edtDapAnC.Html = "";
        edtDapAnD.Html = "";
        //edtGiaiThich.Html = "";
        DaA.Checked = false;
        DaB.Checked = false;
        DaC.Checked = false;
        DaD.Checked = false;
        edtContent.Html = "";
        //ddlLoaiCauHoi.Text = "Nhận biết";
        //txtLoaiCauHoi.Value = "Dễ";
        edtContentCauHoi.Html = "";
        edtDA_A.Html = "";
        edtDA_B.Html = "";
        edtDA_C.Html = "";
        edtDA_D.Html = "";
        ckDA_A.Checked = false;
        ckDA_B.Checked = false;
        ckDA_C.Checked = false;
        ckDA_D.Checked = false;
        edtNoiDungDe.Html = "";
        btnLuuCauHoi.Text = "Lưu";
        btnLuuVaThemmoi.Text = "Lưu và thêm mới";
    }

    protected void btnLuuVaThemmoi_Click(object sender, EventArgs e)
    {
        int dem_DapAnChecked = 0;
        if (DaA.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (DaB.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaC.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaD.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && image == null)
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (DaA.Checked == false && DaB.Checked == false && DaC.Checked == false && DaD.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA.Html == "" || edtDapAnB.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }
        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                //tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
                //SavefileImage();
                themTracNghiem();
                Session["_id"] = "0";
                loadData();
            }

            else
            {
                //update
                updateTracNghiem();
                Session["_id"] = "0";
                //btnLuu.Text = "Lưu";
                //btnLuuvaThemmoi.Text = "Lưu và thêm mới";
            }
            datarong();
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "englishquestion_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbTracNghiem_EnglishQuestion del = db.tbTracNghiem_EnglishQuestions.Where(x => x.englishquestion_id == Convert.ToInt32(item)).FirstOrDefault();
                db.tbTracNghiem_EnglishQuestions.DeleteOnSubmit(del);
                try
                {
                    db.SubmitChanges();
                    //var listDanhSachCauHoi = from eq in db.tbTracNghiem_EnglishQuestions
                    //                         orderby eq.englishquestion_id descending
                    //                         select eq;
                    //grvList.DataSource = listDanhSachCauHoi;
                    //grvList.DataBind();
                    alert.alert_Success(Page, "Xóa thành công", "");
                }
                catch (Exception ex)
                {
                    alert.alert_Error(Page, "Xoá không thành công!", "");
                }
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
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        int countDADung = 0;
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "englishquestion_id" }));
        Session["_id"] = _id;
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == _id
                       select new
                       {
                           ct.username_id,
                           ct.englishquestion_content,
                           ct.englishquestion_part,
                           ct.englishquestion_groupidquestion,
                       }).Single();
        if (chitiet.username_id == username_id)
        {
            if (chitiet.englishquestion_part == "5")
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
                edtNoiDungPart5.Html = cauhoilon.QuestionBig_content;
                var getDetail = from ch in db.tbTracNghiem_EnglishQuestions
                                join tl in db.tbTracNghiem_Answers on ch.englishquestion_id equals tl.question_id
                                where ch.englishquestion_groupidquestion == cauhoilon.QuestionBig_id
                                select new
                                {
                                    ch.englishquestion_id,
                                    ch.englishquestion_content,
                                    tl.answer_id,
                                    tl.answer_content
                                };
                txtCau1.Value = getDetail.First().englishquestion_content;
                txtDapAn1.Value = getDetail.First().answer_content;
                txtCau2.Value = getDetail.Skip(1).Take(1).First().englishquestion_content;
                txtDapAn2.Value = getDetail.Skip(1).Take(1).First().answer_content;
                txtCau3.Value = getDetail.Skip(2).Take(1).First().englishquestion_content;
                txtDapAn3.Value = getDetail.Skip(2).Take(1).First().answer_content;
                txtCau4.Value = getDetail.Skip(3).Take(1).First().englishquestion_content;
                txtDapAn4.Value = getDetail.Skip(3).Take(1).First().answer_content;
                txtCau5.Value = getDetail.Skip(4).Take(1).First().englishquestion_content;
                txtDapAn5.Value = getDetail.Skip(4).Take(1).First().answer_content;
                txtCau6.Visible = false;
                txtDapAn6.Visible = false;
                if (getDetail.Count() == 6)
                {
                    txtCau6.Value = getDetail.Skip(5).Take(1).First().englishquestion_content;
                    txtDapAn6.Value = getDetail.Skip(5).Take(1).First().answer_content;
                    txtCau6.Visible = true;
                    txtDapAn6.Visible = true;
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myPart3('5')", true);
            }
            else if (chitiet.englishquestion_part == "2" || chitiet.englishquestion_part == "3" || chitiet.englishquestion_part == "4")
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
                edtNoiDungDe.Html = cauhoilon.QuestionBig_content;
                edtContentCauHoi.Html = chitiet.englishquestion_content;
                var chitietquestion = (from ctCH in db.tbTracNghiem_Answers
                                       where ctCH.question_id == _id
                                       select ctCH);
                edtDA_A.Html = chitietquestion.First().answer_content;
                if (chitietquestion.First().answer_true == true)
                {
                    ckDA_A.Checked = true;
                    countDADung++;
                }
                else
                    ckDA_A.Checked = false;
                edtDA_B.Html = chitietquestion.Skip(1).First().answer_content;
                if (chitietquestion.Skip(1).First().answer_true == true)
                {
                    ckDA_B.Checked = true;
                    countDADung++;
                }
                else
                    ckDA_B.Checked = false;
                edtDA_C.Html = chitietquestion.Skip(2).First().answer_content;
                if (chitietquestion.Skip(2).First().answer_true == true)
                {
                    ckDA_C.Checked = true;
                    countDADung++;
                }
                else
                    ckDA_C.Checked = false;
                edtDA_D.Html = chitietquestion.Skip(3).First().answer_content;
                if (chitietquestion.Skip(3).First().answer_true == true)
                {
                    ckDA_D.Checked = true;
                    countDADung++;
                }
                else
                    ckDA_D.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myPart2('2')", true);
            }
            else
            {
                edtContent.Html = chitiet.englishquestion_content;
                var chitietquestion = (from ctCH in db.tbTracNghiem_Answers
                                       where ctCH.question_id == _id
                                       select ctCH);
                edtDapAnA.Html = chitietquestion.First().answer_content;
                if (chitietquestion.First().answer_true == true)
                {
                    DaA.Checked = true;
                    countDADung++;

                }
                else
                    DaA.Checked = false;
                edtDapAnB.Html = chitietquestion.Skip(1).First().answer_content;
                if (chitietquestion.Skip(1).First().answer_true == true)
                {
                    DaB.Checked = true;
                    countDADung++;

                }
                else
                    DaB.Checked = false;
                edtDapAnC.Html = chitietquestion.Skip(2).First().answer_content;
                if (chitietquestion.Skip(2).First().answer_true == true)
                {
                    DaC.Checked = true;
                    countDADung++;

                }
                else
                    DaC.Checked = false;
                edtDapAnD.Html = chitietquestion.Skip(3).First().answer_content;
                if (chitietquestion.Skip(3).First().answer_true == true)
                {
                    DaD.Checked = true;
                    countDADung++;

                }
                else
                    DaD.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myPart1('1')", true);
            }
            btnLuuCauHoi.Text = "Cập nhật";
            btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
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
    protected void btnLuuKieu2_Click(object sender, EventArgs e)
    {
        //lưu edtNoiDungDe vào bảng câu hỏi lớn, edtContentCauHoi vào bảng question và đáp án như bth
        int dem_DapAnChecked = 0;
        if (ckDA_A.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (ckDA_B.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckDA_C.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckDA_D.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (ckDA_A.Checked == false && ckDA_B.Checked == false && ckDA_C.Checked == false && ckDA_D.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDA_A.Html == "" || edtDA_B.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }
        //else if ((edtDapAnC.Html == "" || edtDapAnD.Html == "") && (DaC.Checked == false || DaD.Checked == false))
        //{
        //    alert.alert_Error(Page, "Lỗi ", "");
        //}
        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                themData();
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                loadData();
            }
            else
            {
                updateData();
            }
        }
    }

    protected void btnLuuVaThemMoiKieu2_Click(object sender, EventArgs e)
    {
        //lưu edtNoiDungDe vào bảng câu hỏi lớn, edtContentCauHoi vào bảng question và đáp án như bth
        int dem_DapAnChecked = 0;
        if (ckDA_A.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (ckDA_B.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckDA_C.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckDA_D.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (ckDA_A.Checked == false && ckDA_B.Checked == false && ckDA_C.Checked == false && ckDA_D.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDA_A.Html == "" || edtDA_B.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }
        //else if ((edtDapAnC.Html == "" || edtDapAnD.Html == "") && (DaC.Checked == false || DaD.Checked == false))
        //{
        //    alert.alert_Error(Page, "Lỗi ", "");
        //}
        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                themData();
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                loadData();
                Session["_id"] = 0;
            }
            else
            {
                updateData();
                Session["_id"] = 0;
            }
        }
        datarong();
    }

    protected void btnLuuPart5_Click(object sender, EventArgs e)
    {
        if (txtDapAn1.Value == "" || txtDapAn2.Value == "" || txtDapAn3.Value == "" || txtDapAn4.Value == "" || txtDapAn5.Value == "" || txtDapAn6.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ đáp án", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                themTuLuan();
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                loadData();
            }
            else
            {
                //update
                updateTuLuan();
                loadData();
            }
        }
    }
}