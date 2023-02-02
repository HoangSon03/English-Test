using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiReading : System.Web.UI.Page
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
            edtNoiDungTuLuan.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtContentPart3.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnA_Part3.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnB_Part3.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnC_Part3.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnD_Part3.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
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
        //var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
        //                join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                join name in db.admin_Users on gdtCH.username_id equals name.username_id
        //                where gdtCH.hidden == false
        //                && gdtCH.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
        //                //orderby gdtCH.englishquestion_id descending
        //                select new
        //                {
        //                    c.chapter_id,
        //                    //englishquestion_content = gdtCH.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + gdtCH.englishquestion_content + "'</div>" : gdtCH.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.englishquestion_content + "'>" : gdtCH.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.englishquestion_content + "'> </audio>" : gdtCH.englishquestion_content,
        //                    englishquestion_content = gdtCH.englishquestion_content,
        //                    gdtCH.englishquestion_createdate,
        //                    c.lesson_name,
        //                    name.username_fullname,
        //                    gdtCH.englishquestion_id,

        //                };
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
                            gdtCH.englishquestion_part,
                        };
        grvList.DataSource = gdtCauhoi;
        grvList.DataBind();
    }
    //private void getDanhSachDeThi(int loaibai_id)
    //{
    //    //get ds đề thi của bài thi
    //    var getCh = from c in db.tbTracNghiem_Chapters
    //                join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
    //                join k in db.tbKhois on c.khoi_id equals k.khoi_id
    //                where c.khoi_id == 18 && c.monhoc_id == loaibai_id
    //                 && c.hidden == true
    //                select c;
    //    ddlDeThi.Items.Clear();
    //    ddlDeThi.AppendDataBoundItems = true;
    //    ddlDeThi.Items.Insert(0, "Chọn đề thi");
    //    ddlDeThi.DataValueField = "chapter_id";
    //    ddlDeThi.DataTextField = "chapter_name";
    //    ddlDeThi.DataSource = getCh;
    //    ddlDeThi.DataBind();
    //}

    //private void loadKyNang(int de_id)
    //{
    //    var getKyNang = from l in db.tbTracNghiem_Lessons
    //                    where l.chapter_id == de_id && l.hidden == true
    //                    select l;

    //    ddlKyNang.Items.Clear();
    //    ddlKyNang.AppendDataBoundItems = true;
    //    ddlKyNang.Items.Insert(0, "Chọn kỹ năng");
    //    ddlKyNang.DataValueField = "lesson_id";
    //    ddlKyNang.DataTextField = "lesson_name";
    //    ddlKyNang.DataSource = getKyNang;
    //    ddlKyNang.DataBind();
    //}
    private void getCH()
    {
        //var getCH = from gch in db.tbTracNghiem_EnglishQuestions
        //            join bh in db.tbTracNghiem_Lessons on gch.lesson_id equals bh.lesson_id
        //            join name in db.admin_Users on gch.username_id equals name.username_id
        //            where gch.lesson_id == kynang_id
        //            && gch.hidden == false
        //            select new
        //            {
        //                gch.englishquestion_id,
        //                bh.lesson_name,
        //                gch.englishquestion_content,
        //                gch.englishquestion_level,
        //                gch.englishquestion_dangcauhoi,
        //                name.username_fullname
        //            };
        var getCH = from gch in db.tbTracNghiem_EnglishQuestions
                    join bh in db.tbTracNghiem_KyNangs on gch.kynang_id equals bh.kynang_id
                    join name in db.admin_Users on gch.username_id equals name.username_id
                    where gch.kynang_id == kynang_id
                    && gch.hidden == false
                    select new
                    {
                        gch.englishquestion_id,
                        bh.kynang_name,
                        gch.englishquestion_content,
                        gch.englishquestion_level,
                        gch.englishquestion_dangcauhoi,
                        name.username_fullname,
                        gch.englishquestion_part,
                    };
        grvList.DataSource = getCH;
        grvList.DataBind();
    }
    //protected void btnThemDeThi_Click(object sender, EventArgs e)
    //{
    //    if (ddlLoaiBai.SelectedValue != "Chọn bài thi")
    //    {
    //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupThemDe.Show();", true);
    //    }
    //    else
    //    {
    //        alert.alert_Error(Page, "Vui lòng chọn bài thi", " ");

    //    }
    //}

    //protected void btnLuuDeThi_Click(object sender, EventArgs e)
    //{
    //    // Đang xử lý đề
    //    var checkName = from ch in db.tbTracNghiem_Chapters
    //                    where ch.chapter_name.Contains(txtTenDe.Text)
    //                    && ch.hidden == true
    //                    && ch.khoi_id == 18
    //                    && ch.monhoc_id == Convert.ToInt16(ddlLoaiBai.SelectedValue)
    //                    select ch;
    //    if (checkName.Count() > 0)
    //    {
    //        alert.alert_Warning(Page, "Đề này đã được thêm!", "");
    //    }
    //    else
    //    {
    //        tbTracNghiem_Chapter chuong = new tbTracNghiem_Chapter();
    //        chuong.monhoc_id = Convert.ToInt16(ddlLoaiBai.SelectedValue);
    //        chuong.khoi_id = 18;
    //        chuong.chapter_name = txtTenDe.Text;
    //        chuong.hidden = true;
    //        // chuong.hidden = false;
    //        db.tbTracNghiem_Chapters.InsertOnSubmit(chuong);
    //        db.SubmitChanges();
    //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Lưu thành công!','','success').then(function(){popupThemDe.Hide()})", true);
    //        getDanhSachDeThi(Convert.ToInt16(ddlLoaiBai.SelectedValue));
    //    }
    //}

    //protected void btnThemKyNang_Click(object sender, EventArgs e)
    //{
    //    if (ddlLoaiBai.SelectedValue != "Chọn bài thi")
    //    {
    //        if (ddlDeThi.SelectedValue != "Chọn đề thi")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupThemKyNang.Show();", true);
    //        }
    //        else
    //        {
    //            alert.alert_Error(Page, "Vui lòng chọn đề thi", " ");
    //        }
    //    }
    //    else
    //    {
    //        alert.alert_Error(Page, "Vui lòng chọn bài thi", " ");
    //    }
    //}

    //protected void btnLuuKyNang_Click(object sender, EventArgs e)
    //{
    //    tbTracNghiem_Lesson baihoc = new tbTracNghiem_Lesson();
    //    baihoc.lesson_name = txtKyNang.Text;
    //    baihoc.chapter_id = Convert.ToInt16(ddlDeThi.SelectedValue);
    //    baihoc.hidden = true;
    //    baihoc.khoi_id = 18;
    //    baihoc.monhoc_id = Convert.ToInt16(ddlLoaiBai.SelectedValue);
    //    db.tbTracNghiem_Lessons.InsertOnSubmit(baihoc);
    //    db.SubmitChanges();
    //    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Lưu thành công!','','success').then(function(){popupThemKyNang.Hide()})", true);
    //    loadKyNang(Convert.ToInt16(ddlDeThi.SelectedValue));
    //}

    //protected void ddlLoaiBai_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlLoaiBai.SelectedValue != "Chọn bài thi")
    //    {
    //        //loại bài là gồm a2, b1
    //        getDanhSachDeThi(Convert.ToInt16(ddlLoaiBai.SelectedValue));
    //    }
    //}
    //protected void ddlDeThi_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //load kỹ năng
    //    if (ddlLoaiBai.SelectedValue != "Chọn bài thi" && ddlDeThi.SelectedValue != "Chọn đề thi")
    //    {
    //        loadKyNang(Convert.ToInt16(ddlDeThi.SelectedValue));
    //    }
    //}


    //protected void ddlKyNang_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if(ddlKyNang.SelectedValue!="Chọn kỹ năng")
    //    getCH();
    //    else
    //    {
    //        grvList.DataSource = null;
    //        grvList.DataBind();
    //    }

    //}
    private void themTracNghiem()
    {
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
        //if (edtContent.Html == "" && txtKieuCauHoi.Value != "0")
        //{
        //    themcauhoi.englishquestion_content = image;
        //}
        //else
        //{
        themcauhoi.englishquestion_content = edtContent.Html;
        //}
        themcauhoi.englishquestion_createdate = DateTime.Now;
        //themcauhoi.englishquestion_level = txtLoaiCauHoi.Value;
        themcauhoi.username_id = getUser.username_id;
        //themcauhoi.chapter_id = dethi_id;
        themcauhoi.dethi_id = dethi_id;
        themcauhoi.hidden = false;
        //themcauhoi.englishquestion_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
        //themcauhoi.englishquestion_giaithich = edtGiaiThich.Html;
        //themcauhoi.lesson_id = kynang_id;
        themcauhoi.kynang_id = kynang_id;
        //themcauhoi.englishquestion_chude =
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
    private void updatedata()
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
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();

        /*
         lưu hình ảnh ở bảng câu hỏi lớn,
         stt câu hỏi ở bảng câu hỏi,
         đáp án ở bảng đáp án và là đáp án đúng
         */
        tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
        content.QuestionBig_content = edtNoiDungTuLuan.Html;
        content.questionbig_part = txtPart.Value;
        content.lesson_id = kynang_id;
        db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
        db.SubmitChanges();
        if (txtCau1.Value.Trim() != "" && txtDapAn1.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau1.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            //themcauhoi.englishquestion_level = txtLoaiCauHoi.Value;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.englishquestion_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
            //themcauhoi.englishquestion_giaithich = edtGiaiThich.Html;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn1.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        if (txtCau2.Value.Trim() != "" && txtDapAn2.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau2.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn2.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        if (txtCau3.Value.Trim() != "" && txtDapAn3.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau3.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn3.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        if (txtCau4.Value.Trim() != "" && txtDapAn4.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau4.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn4.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        if (txtCau5.Value.Trim() != "" && txtDapAn5.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau5.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn5.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        if (txtCau6.Value.Trim() != "" && txtDapAn6.Value.Trim() != "")
        {
            tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
            themcauhoi.englishquestion_content = txtCau6.Value.Trim();
            themcauhoi.englishquestion_createdate = DateTime.Now;
            themcauhoi.username_id = getUser.username_id;
            //themcauhoi.chapter_id = dethi_id;
            themcauhoi.dethi_id = dethi_id;
            themcauhoi.hidden = false;
            //themcauhoi.lesson_id = kynang_id;
            themcauhoi.kynang_id = kynang_id;
            themcauhoi.englishquestion_groupidquestion = content.QuestionBig_id;
            themcauhoi.englishquestion_part = txtPart.Value;
            db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
            db.SubmitChanges();
            tbTracNghiem_Answer dapan = new tbTracNghiem_Answer();
            dapan.answer_content = txtDapAn6.Value.Trim();
            dapan.question_id = themcauhoi.englishquestion_id;
            db.tbTracNghiem_Answers.InsertOnSubmit(dapan);
            db.SubmitChanges();
        }
        alert.alert_Success(Page, "Lưu thành công", "");
    }
    //update đáp án part2
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

        cauhoilon.QuestionBig_content = edtNoiDungTuLuan.Html;
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
        btnLuuTuLuan.Text = "Cập nhật";
        loadData();
    }
    private void SavefileImage()
    {
        if (Page.IsValid && FileUpload1.HasFile)
        {
            String folderUser;
            string url;
            string filename;
            string fileName_save;
            //if (txtKieuCauHoi.Value == "1")
            //{
            //lưu hình ảnh
            folderUser = Server.MapPath("~/uploadimages/tracnghiemtienganh/");
            if (!Directory.Exists(folderUser))
            {
                Directory.CreateDirectory(folderUser);
            }
            url = "/uploadimages/tracnghiemtienganh/";
            HttpFileCollection hfc = Request.Files;
            filename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + FileUpload1.FileName;
            fileName_save = Path.Combine(Server.MapPath("~/uploadimages/tracnghiemtienganh"), filename);
            FileUpload1.SaveAs(fileName_save);
            image = url + filename;
            //}
            //else if (txtKieuCauHoi.Value == "2")
            //{
            //    //lưu video
            //    folderUser = Server.MapPath("~/uploadimages/video_cauhoitracnghiem/");
            //    if (!Directory.Exists(folderUser))
            //    {
            //        Directory.CreateDirectory(folderUser);
            //    }
            //    url = "/uploadimages/video_cauhoitracnghiem/";
            //    HttpFileCollection hfc = Request.Files;
            //    filename = DateTime.Now.ToString("yyyyMMdd_") + FileUpload1.FileName;
            //    fileName_save = Path.Combine(Server.MapPath("~/uploadimages/video_cauhoitracnghiem"), filename);
            //    FileUpload1.SaveAs(fileName_save);
            //    image = url + filename;
            //}

        }
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
                getCH();
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
                updatedata();
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
        edtContentPart3.Html = "";
        edtDapAnA_Part3.Html = "";
        edtDapAnB_Part3.Html = "";
        edtDapAnC_Part3.Html = "";
        edtDapAnD_Part3.Html = "";
        ckPart3_A.Checked = false;
        ckPart3_B.Checked = false;
        ckPart3_C.Checked = false;
        ckPart3_D.Checked = false;

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
                getCH();
            }

            else
            {
                //update
                updatedata();
                Session["_id"] = "0";
                //btnLuu.Text = "Lưu";
                //btnLuuvaThemmoi.Text = "Lưu và thêm mới";
            }
            datarong();
        }
    }
    private void setRongTuLuan()
    {
        txtCau1.Value = "";
        txtCau2.Value = "";
        txtCau3.Value = "";
        txtCau4.Value = "";
        txtCau5.Value = "";
        txtCau6.Value = "";
        txtDapAn1.Value = "";
        txtDapAn2.Value = "";
        txtDapAn3.Value = "";
        txtDapAn4.Value = "";
        txtDapAn5.Value = "";
        txtDapAn6.Value = "";
    }
    protected void btnLuuTuLuan_Click(object sender, EventArgs e)
    {
        //themTuLuan()
        //lưu câu hỏi tự luận.
        if (Session["_id"].ToString() == "0")
        {
            themTuLuan();
            btnLuuCauHoi.Text = "Cập nhật";
            btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
            getCH();
            setRongTuLuan();
        }
        else
        {
            //update
            updateTuLuan();
            setRongTuLuan();
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

    protected void btnLuuPart3_Click(object sender, EventArgs e)
    {
        int dem_DapAnChecked = 0;
        if (ckPart3_A.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (ckPart3_B.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckPart3_C.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckPart3_D.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (ckPart3_A.Checked == false && ckPart3_B.Checked == false && ckPart3_C.Checked == false && ckPart3_D.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA_Part3.Html == "" || edtDapAnB_Part3.Html == "")
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
                SavefileImage();
                //themTracNghiem();
                //lưu image vào bảng questionbig và lấy id question big lưu vào groupidquestion trong bảng englishquestion
                if (image != null)
                {
                    tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
                    content.QuestionBig_content = image;
                    content.questionbig_part = txtPart.Value;
                    content.lesson_id = kynang_id;
                    db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
                    db.SubmitChanges();
                    Session["questionbig_id"] = content.QuestionBig_id;
                }
                tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
                themcauhoi.englishquestion_content = edtContentPart3.Html;
                themcauhoi.englishquestion_createdate = DateTime.Now;
                themcauhoi.username_id = username_id;
                //themcauhoi.chapter_id = dethi_id;
                themcauhoi.dethi_id = dethi_id;
                themcauhoi.hidden = false;
                //themcauhoi.lesson_id = kynang_id;
                themcauhoi.kynang_id = kynang_id;
                themcauhoi.englishquestion_groupidquestion = Convert.ToInt16(Session["questionbig_id"].ToString());
                themcauhoi.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
                db.SubmitChanges();
                Session["_id"] = themcauhoi.englishquestion_id;
                //lưu đáp án A
                tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
                dapanA.answer_content = edtDapAnA_Part3.Html;
                dapanA.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_A.Checked == true)
                    dapanA.answer_true = true;
                else
                    dapanA.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
                tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
                dapanB.answer_content = edtDapAnB_Part3.Html;
                dapanB.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_B.Checked == true)
                    dapanB.answer_true = true;
                else
                    dapanB.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
                tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
                dapanC.answer_content = edtDapAnC_Part3.Html;
                dapanC.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_C.Checked == true)
                    dapanC.answer_true = true;
                else
                    dapanC.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
                tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
                dapanD.answer_content = edtDapAnD_Part3.Html;
                dapanD.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_D.Checked == true)
                    dapanD.answer_true = true;
                else
                    dapanD.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
                db.SubmitChanges();
                alert.alert_Success(Page, "Lưu thành công", "");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                getCH();
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
                //updatedata();
            }
        }
    }

    protected void btnLuuVaThemMoiPart3_Click(object sender, EventArgs e)
    {
        int dem_DapAnChecked = 0;
        if (ckPart3_A.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (ckPart3_B.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckPart3_C.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (ckPart3_D.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        //if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        //{
        //    alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        //}
        //else 
        if (ckPart3_A.Checked == false && ckPart3_B.Checked == false && ckPart3_C.Checked == false && ckPart3_D.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA_Part3.Html == "" || edtDapAnB_Part3.Html == "")
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
                SavefileImage();
                //themTracNghiem();
                //lưu image vào bảng questionbig và lấy id question big lưu vào groupidquestion trong bảng englishquestion
                if (image != null)
                {
                    tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
                    content.QuestionBig_content = image;
                    content.questionbig_part = txtPart.Value;
                    content.lesson_id = kynang_id;
                    db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
                    db.SubmitChanges();
                    Session["questionbig_id"] = content.QuestionBig_id;
                }
                tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
                themcauhoi.englishquestion_content = edtContentPart3.Html;
                themcauhoi.englishquestion_createdate = DateTime.Now;
                themcauhoi.username_id = username_id;
                //themcauhoi.chapter_id = dethi_id;
                themcauhoi.dethi_id = dethi_id;
                themcauhoi.hidden = false;
                //themcauhoi.lesson_id = kynang_id;
                themcauhoi.kynang_id = kynang_id;
                themcauhoi.englishquestion_groupidquestion = Convert.ToInt16(Session["questionbig_id"].ToString());
                themcauhoi.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(themcauhoi);
                db.SubmitChanges();
                Session["_id"] = themcauhoi.englishquestion_id;
                //lưu đáp án A
                tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
                dapanA.answer_content = edtDapAnA_Part3.Html;
                dapanA.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_A.Checked == true)
                    dapanA.answer_true = true;
                else
                    dapanA.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
                tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
                dapanB.answer_content = edtDapAnB_Part3.Html;
                dapanB.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_B.Checked == true)
                    dapanB.answer_true = true;
                else
                    dapanB.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
                tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
                dapanC.answer_content = edtDapAnC_Part3.Html;
                dapanC.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_C.Checked == true)
                    dapanC.answer_true = true;
                else
                    dapanC.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
                tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
                dapanD.answer_content = edtDapAnD_Part3.Html;
                dapanD.question_id = themcauhoi.englishquestion_id;
                if (ckPart3_D.Checked == true)
                    dapanD.answer_true = true;
                else
                    dapanD.answer_true = false;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
                db.SubmitChanges();
                alert.alert_Success(Page, "Lưu thành công", "");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);
                btnLuuCauHoi.Text = "Cập nhật";
                btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
                getCH();
                //if (ddlLoaiCauHoi.SelectedValue != "Nhận biết")
                //{
                //    themcauhoi.englishquestion_content = image;
                //}
                //else
                //{
                //    themcauhoi.englishquestion_content = edtContent.Html;
                //}
                Session["_id"] = "0";
            }
            else
            {
                //update
                //updatedata();
                Session["_id"] = "0";
            }
            datarong();
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
            if (chitiet.englishquestion_part == "2" || chitiet.englishquestion_part == "4" || chitiet.englishquestion_part == "6")
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
                edtNoiDungTuLuan.Html = cauhoilon.QuestionBig_content;
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myPart2()", true);
            }
            else if (chitiet.englishquestion_part == "3" || chitiet.englishquestion_part == "5")
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
                edtContentPart3.Html = chitiet.englishquestion_content;
                var chitietquestion = (from ctCH in db.tbTracNghiem_Answers
                                       where ctCH.question_id == _id
                                       select ctCH);
                edtDapAnA_Part3.Html = chitietquestion.First().answer_content;
                if (chitietquestion.First().answer_true == true)
                {
                    ckPart3_A.Checked = true;
                    countDADung++;
                }
                else
                    ckPart3_A.Checked = false;
                edtDapAnB_Part3.Html = chitietquestion.Skip(1).First().answer_content;
                if (chitietquestion.Skip(1).First().answer_true == true)
                {
                    ckPart3_B.Checked = true;
                    countDADung++;
                }
                else
                    ckPart3_B.Checked = false;
                edtDapAnC_Part3.Html = chitietquestion.Skip(2).First().answer_content;
                if (chitietquestion.Skip(2).First().answer_true == true)
                {
                    ckPart3_C.Checked = true;
                    countDADung++;
                }
                else
                    ckPart3_C.Checked = false;
                edtDapAnD_Part3.Html = chitietquestion.Skip(3).First().answer_content;
                if (chitietquestion.Skip(3).First().answer_true == true)
                {
                    ckPart3_D.Checked = true;
                    countDADung++;
                }
                else
                    ckPart3_D.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showImg1_1('" + cauhoilon.QuestionBig_content + "');myPart3()", true);
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
                //myPart1
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myPart1()", true);
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
}