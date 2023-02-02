using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiListening : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public string image, audio;
    private int username_id;
    int _id, mon_id, dethi_id, kynang_id;

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
    //private void getCH()
    //{
    //    var getCH = from gch in db.tbTracNghiem_EnglishQuestions
    //                join bh in db.tbTracNghiem_Lessons on gch.lesson_id equals bh.lesson_id
    //                join name in db.admin_Users on gch.username_id equals name.username_id
    //                where gch.lesson_id == Convert.ToInt16(ddlKyNang.SelectedValue)
    //                && gch.hidden == false
    //                select new
    //                {
    //                    gch.englishquestion_id,
    //                    bh.lesson_name,
    //                    gch.englishquestion_content,
    //                    gch.englishquestion_level,
    //                    gch.englishquestion_dangcauhoi,
    //                    name.username_fullname
    //                };
    //    //grvList.DataSource = getCH;
    //    //grvList.DataBind();
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
    //    if (ddlKyNang.SelectedValue != "Chọn kỹ năng")
    //        getCH();
    //    else
    //    {
    //        //grvList.DataSource = null;
    //        //grvList.DataBind();
    //    }

    //}
    private void SavefileImage()
    {
        if (Page.IsValid && FileUpload2.HasFile)
        {
            String folderUser;
            string url;
            string filename;
            string fileName_save;
            folderUser = Server.MapPath("~/uploadimages/tracnghiemtienganh/B1/listening");
            if (!Directory.Exists(folderUser))
            {
                Directory.CreateDirectory(folderUser);
            }
            url = "/uploadimages/tracnghiemtienganh/B1/listening/";
            HttpFileCollection hfc = Request.Files;
            filename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + FileUpload2.FileName;
            fileName_save = Path.Combine(Server.MapPath("~/uploadimages/tracnghiemtienganh/B1/listening"), filename);
            FileUpload2.SaveAs(fileName_save);
            image = url + filename;
        }
    }
    private void SavefileAudio()
    {
        if (Page.IsValid && FileUpload1.HasFile)
        {
            String folderUser;
            string url;
            string filename;
            string fileName_save;
            folderUser = Server.MapPath("~/uploadimages/tracnghiemtienganh/B1/listening");
            if (!Directory.Exists(folderUser))
            {
                Directory.CreateDirectory(folderUser);
            }
            url = "/uploadimages/tracnghiemtienganh/B1/listening/";
            HttpFileCollection hfc = Request.Files;
            filename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + FileUpload1.FileName;
            fileName_save = Path.Combine(Server.MapPath("~/uploadimages/tracnghiemtienganh/B1/listening"), filename);
            FileUpload1.SaveAs(fileName_save);
            audio = url + filename;
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
        //edtContentPart3.Html = "";
        //edtDapAnA_Part3.Html = "";
        //edtDapAnB_Part3.Html = "";
        //edtDapAnC_Part3.Html = "";
        //edtDapAnD_Part3.Html = "";
        //ckPart3_A.Checked = false;
        //ckPart3_B.Checked = false;
        //ckPart3_C.Checked = false;
        //ckPart3_D.Checked = false;
        btnLuuCauHoi.Text = "Lưu";
        btnLuuVaThemmoi.Text = "Lưu và thêm mới";
    }

    private void themData()
    {
        if (audio != null)
        {
            //lưu vào bảng câu hổi lớn
            tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
            content.questionbig_mp3 = audio;
            content.lesson_id = kynang_id;
            content.questionbig_part = txtPart.Value;
            db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
            db.SubmitChanges();
            Session["questionbig_id"] = content.QuestionBig_id;
        }
        tbTracNghiem_EnglishQuestion themcauhoi = new tbTracNghiem_EnglishQuestion();
        themcauhoi.englishquestion_content = edtContent.Html;
        themcauhoi.englishquestion_createdate = DateTime.Now;
        themcauhoi.username_id = username_id;
        themcauhoi.dethi_id = dethi_id;
        themcauhoi.hidden = false;
        themcauhoi.kynang_id = kynang_id;
        themcauhoi.englishquestion_groupidquestion = Convert.ToInt16(Session["questionbig_id"].ToString());
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
        btnLuuCauHoi.Text = "Cập nhật";
        btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
    }
    private void updateData()
    {
        var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                       where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                       select ct).Single();
        var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                         where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                         select q).FirstOrDefault();
        if (audio != null)
        {
            cauhoilon.questionbig_mp3 = audio;
            db.SubmitChanges();
        }
        chitiet.englishquestion_content = edtContent.Html;
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
                if (FileUpload1.HasFile)
                {
                    SavefileAudio();
                    themData();
                }
                else
                {
                    alert.alert_Warning(Page, "Vui lòng chọn file âm thanh!", "");
                }
            }
            else
            {
                //cập nhật dữ liệu
                SavefileAudio();
                updateData();
            }
            loadData();
        }
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

                //if (FileUpload1.HasFile)
                //{
                    SavefileAudio();
                    //lưu vào bảng câu hổi lớn
                    themData();
                    Session["_id"] = "0";
                //}
                //else
                //{
                //    alert.alert_Warning(Page, "Vui lòng chọn file âm thanh!", "");
                //}
            }
            else
            {
                //update data
                SavefileAudio();
                updateData();
                Session["_id"] = "0";
            }
            datarong();
            loadData();
        }
    }

    protected void btnLuuPart3_Click(object sender, EventArgs e)
    {
        if (Session["_id"].ToString() == "0")
        {
            if (!FileUpload1.HasFile || !FileUpload2.HasFile)
            {
                alert.alert_Warning(Page, "Vui lòng chọn đầy đủ dữ liệu", "");
            }
            else
            {
                SavefileAudio();
                SavefileImage();
                //lưu hình ảnh và âm thanh vào bảng câu hỏi lớn
                tbTracNghiem_QuestionBig content = new tbTracNghiem_QuestionBig();
                content.QuestionBig_content = image;
                content.questionbig_mp3 = audio;
                content.lesson_id = kynang_id;
                content.questionbig_part = txtPart.Value;
                db.tbTracNghiem_QuestionBigs.InsertOnSubmit(content);
                db.SubmitChanges();
                Session["questionbig_id"] = content.QuestionBig_id;
                //lưu câu hỏi chi tiết
                //câu 14
                tbTracNghiem_EnglishQuestion cau14 = new tbTracNghiem_EnglishQuestion();
                cau14.englishquestion_content = txtCau1.Value.Trim();
                cau14.englishquestion_createdate = DateTime.Now;
                cau14.username_id = username_id;
                cau14.dethi_id = dethi_id;
                cau14.hidden = false;
                cau14.kynang_id = kynang_id;
                cau14.englishquestion_groupidquestion = content.QuestionBig_id;
                cau14.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau14);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan14 = new tbTracNghiem_Answer();
                dapan14.answer_content = txtDapAn1.Value.Trim();
                dapan14.question_id = cau14.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan14);
                db.SubmitChanges();
                //câu 15
                tbTracNghiem_EnglishQuestion cau15 = new tbTracNghiem_EnglishQuestion();
                cau15.englishquestion_content = txtCau2.Value.Trim();
                cau15.englishquestion_createdate = DateTime.Now;
                cau15.username_id = username_id;
                cau15.dethi_id = dethi_id;
                cau15.hidden = false;
                cau15.kynang_id = kynang_id;
                cau15.englishquestion_groupidquestion = content.QuestionBig_id;
                cau15.englishquestion_part = txtPart.Value;

                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau15);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan15 = new tbTracNghiem_Answer();
                dapan15.answer_content = txtDapAn2.Value.Trim();
                dapan15.question_id = cau15.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan15);
                db.SubmitChanges();
                //câu 16
                tbTracNghiem_EnglishQuestion cau16 = new tbTracNghiem_EnglishQuestion();
                cau16.englishquestion_content = txtCau3.Value.Trim();
                cau16.englishquestion_createdate = DateTime.Now;
                cau16.username_id = username_id;
                cau16.dethi_id = dethi_id;
                cau16.hidden = false;
                cau16.kynang_id = kynang_id;
                cau16.englishquestion_groupidquestion = content.QuestionBig_id;
                cau16.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau16);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan16 = new tbTracNghiem_Answer();
                dapan16.answer_content = txtDapAn3.Value.Trim();
                dapan16.question_id = cau16.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan16);
                db.SubmitChanges();
                //câu 17
                tbTracNghiem_EnglishQuestion cau17 = new tbTracNghiem_EnglishQuestion();
                cau17.englishquestion_content = txtCau4.Value.Trim();
                cau17.englishquestion_createdate = DateTime.Now;
                cau17.username_id = username_id;
                cau17.dethi_id = dethi_id;
                cau17.hidden = false;
                cau17.kynang_id = kynang_id;
                cau17.englishquestion_groupidquestion = content.QuestionBig_id;
                cau17.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau17);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan17 = new tbTracNghiem_Answer();
                dapan17.answer_content = txtDapAn4.Value.Trim();
                dapan17.question_id = cau17.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan17);
                db.SubmitChanges();
                //câu 18
                tbTracNghiem_EnglishQuestion cau18 = new tbTracNghiem_EnglishQuestion();
                cau18.englishquestion_content = txtCau5.Value.Trim();
                cau18.englishquestion_createdate = DateTime.Now;
                cau18.username_id = username_id;
                cau18.dethi_id = dethi_id;
                cau18.hidden = false;
                cau18.kynang_id = kynang_id;
                cau18.englishquestion_groupidquestion = content.QuestionBig_id;
                cau18.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau18);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan18 = new tbTracNghiem_Answer();
                dapan18.answer_content = txtDapAn5.Value.Trim();
                dapan18.question_id = cau18.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan18);
                db.SubmitChanges();
                //câu 19
                tbTracNghiem_EnglishQuestion cau19 = new tbTracNghiem_EnglishQuestion();
                cau19.englishquestion_content = txtCau6.Value.Trim();
                cau19.englishquestion_createdate = DateTime.Now;
                cau19.username_id = username_id;
                cau19.dethi_id = dethi_id;
                cau19.hidden = false;
                cau19.kynang_id = kynang_id;
                cau19.englishquestion_groupidquestion = content.QuestionBig_id;
                cau19.englishquestion_part = txtPart.Value;
                db.tbTracNghiem_EnglishQuestions.InsertOnSubmit(cau19);
                db.SubmitChanges();
                tbTracNghiem_Answer dapan19 = new tbTracNghiem_Answer();
                dapan19.answer_content = txtDapAn6.Value.Trim();
                dapan19.question_id = cau19.englishquestion_id;
                db.tbTracNghiem_Answers.InsertOnSubmit(dapan19);
                db.SubmitChanges();
                alert.alert_Success(Page, "Lưu thành công", "");
            }
        }
        else
        {
            if (FileUpload1.HasFile)
                SavefileAudio();
            if (FileUpload2.HasFile)
                SavefileImage();
            //cập nhật dữ liệu
            var chitiet = (from ct in db.tbTracNghiem_EnglishQuestions
                           where ct.englishquestion_id == Convert.ToInt32(Session["_id"].ToString())
                           select ct).Single();
            var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                             where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                             select q).FirstOrDefault();

            if (audio != null)
                cauhoilon.questionbig_mp3 = audio;
            if (image != null)
                cauhoilon.QuestionBig_content = image;
            db.SubmitChanges();
            var getDapAn = (from da in db.tbTracNghiem_Answers
                            join ch in db.tbTracNghiem_EnglishQuestions on da.question_id equals ch.englishquestion_id
                            where ch.englishquestion_groupidquestion == cauhoilon.QuestionBig_id
                            select da);
            getDapAn.First().answer_content = txtDapAn1.Value;
            getDapAn.Skip(1).Take(1).FirstOrDefault().answer_content = txtDapAn2.Value;
            getDapAn.Skip(2).Take(1).FirstOrDefault().answer_content = txtDapAn3.Value;
            getDapAn.Skip(3).Take(1).FirstOrDefault().answer_content = txtDapAn4.Value;
            getDapAn.Skip(4).Take(1).FirstOrDefault().answer_content = txtDapAn5.Value;
            getDapAn.Skip(5).Take(1).FirstOrDefault().answer_content = txtDapAn6.Value;
            db.SubmitChanges();
            alert.alert_Success(Page, "Cập nhật thành công", "");
        }
        loadData();
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
            if (chitiet.englishquestion_part == "1" || chitiet.englishquestion_part == "2" || chitiet.englishquestion_part == "4")
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showAudio1_1('" + cauhoilon.questionbig_mp3 + "');myPart1()", true);
            }
            else
            {
                //get câu hỏi lớn
                var cauhoilon = (from q in db.tbTracNghiem_QuestionBigs
                                 where q.QuestionBig_id == chitiet.englishquestion_groupidquestion
                                 select q).FirstOrDefault();
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
                txtCau6.Value = getDetail.Skip(5).Take(1).First().englishquestion_content;
                txtDapAn6.Value = getDetail.Skip(5).Take(1).First().answer_content;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showAudio1_1('" + cauhoilon.questionbig_mp3 + "');showImg1_1('" + cauhoilon.QuestionBig_content + "');myPart3()", true);
            }
            btnLuuCauHoi.Text = "Cập nhật";
            btnLuuVaThemmoi.Text = "Cập nhật và thêm mới";
        }
        else
        {
            alert.alert_Error(Page, "Sai thông tin người dùng", "");
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

    protected void btnTaiLaiTrang_Click(object sender, EventArgs e)
    {
        loadData();
        datarong();
    }
}