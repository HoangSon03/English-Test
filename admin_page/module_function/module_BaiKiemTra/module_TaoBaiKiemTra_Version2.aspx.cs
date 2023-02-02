using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_BaiKiemTra_module_TaoBaiKiemTra_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_GetLink cls = new cls_GetLink();
    DataTable dtListCauhoi;

    protected void Page_Load(object sender, EventArgs e)
    {
        //lấy thông tin tk đăng nhập
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        if (!IsPostBack)
        {
            ddlDeThi.Visible = false;
            ddlKyNang.Visible = false;
            //lkChuong.Visible = false;

            // dvSoCauHoi.Visible = false;
            var listLoaiBai = from mhck in db.tbMonHocCuaKhois
                              join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                              where mhck.khoi_id == 18 && mhck.hidden == true //id = 18 là môn tiếng anh
                              select mh;
            ddlLoaiBai.Items.Clear();
            ddlLoaiBai.AppendDataBoundItems = true;
            ddlLoaiBai.Items.Insert(0, "Chọn bài thi");
            ddlLoaiBai.DataValueField = "monhoc_id";
            ddlLoaiBai.DataTextField = "monhoc_name";
            ddlLoaiBai.DataSource = listLoaiBai;
            ddlLoaiBai.DataBind();
            // dvButton.Visible = false;
            //var getLoaiBaiThi = from c in db.tbTracNghiem_BaiThiCates
            //                    where c.username_id == 1 && c.username_id == getUser.username_id
            //                    orderby c.baithicate_position ascending
            //                    select c;
            //ddlLoaiBaiKiemTra.Items.Clear();
            //ddlLoaiBaiKiemTra.AppendDataBoundItems = true;
            //ddlLoaiBaiKiemTra.Items.Insert(0, "Chọn loại bài kiểm tra");
            //ddlLoaiBaiKiemTra.DataValueField = "baithicate_id";
            //ddlLoaiBaiKiemTra.DataTextField = "baithicate_name";
            //ddlLoaiBaiKiemTra.DataSource = getLoaiBaiThi;
            //ddlLoaiBaiKiemTra.DataBind();
        }
        //loadDataTable();
        //nếu lkChuong được chọn thì load những câu hỏi của chương được chọn lên gridview
        //if (lkChuong.Text != "")
        //{
        //    //dvButton.Visible = true;
        //    // dvSoCauHoi.Visible = true;
        //    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "displayButton()", true);
        //    //load data lên gridview
        //    string _id = lkChuong.Text;
        //    string[] arrListStr = _id.Split(',');

        //    var list = from ch in db.tbTracNghiem_EnglishQuestions
        //               join l in db.tbTracNghiem_Lessons on ch.lesson_id equals l.lesson_id
        //               join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
        //               join u in db.admin_Users on ch.username_id equals u.username_id
        //               where c.chapter_name == "" && ch.hidden == false
        //               select new
        //               {
        //                   ch.englishquestion_id,
        //                   englishquestion_content = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "'</div>" : ch.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
        //                   l.lesson_name,
        //                   c.chapter_name,
        //                   u.username_fullname
        //               };
        //    //var User_BoPhans = new List<User_BoPhan>();
        //    foreach (string item in arrListStr)
        //    {

        //        var list1 = from ch in db.tbTracNghiem_EnglishQuestions
        //                    join l in db.tbTracNghiem_Lessons on ch.lesson_id equals l.lesson_id
        //                    join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
        //                    join u in db.admin_Users on ch.username_id equals u.username_id
        //                    where c.chapter_name == item.ToString().Trim() && ch.hidden == false
        //                    select new
        //                    {
        //                        ch.englishquestion_id,

        //                        englishquestion_content = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains("mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
        //                        l.lesson_name,
        //                        c.chapter_name,
        //                        u.username_fullname
        //                    };
        //        list = list.Union(list1);
        //        grvList.DataSource = list;
        //        grvList.DataBind();
        //        //Session["listCauHoi"] = list;
        //    }
        //} 

        //dtListCauhoi = (DataTable)Session["listCauHoi"];
        //grvList.DataSource = dtListCauhoi;
        //grvList.DataBind();

        if (grvList.VisibleRowCount.ToString() != "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "displayButton()", true);
        }
    }
    //khởi tạo data table
    private void loadDataTable()
    {
        try
        {
            if (dtListCauhoi == null)
            {
                dtListCauhoi = new DataTable();
                dtListCauhoi.Columns.Add("englishquestion_id", typeof(int));
                dtListCauhoi.Columns.Add("englishquestion_content", typeof(string));
                dtListCauhoi.Columns.Add("englishquestion_type", typeof(string));
                dtListCauhoi.Columns.Add("chapter_name", typeof(string));
                dtListCauhoi.Columns.Add("username_fullname", typeof(string));
            }
        }
        catch (Exception) { }
    }
    //khi chọn khối lớp sẽ đổ ra ds các môn học của khối lớp đó.
    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var getdataMon = from mhck in db.tbMonHocCuaKhois
        //                 join m in db.tbMonHocs on mhck.monhoc_id equals m.monhoc_id
        //                 join gvdm in db.tbGiaoVienDayMons on m.monhoc_id equals gvdm.monhoc_id
        //                 join u in db.admin_Users on gvdm.username_id equals u.username_id
        //                 where mhck.khoi_id == Convert.ToInt32(ddlLoaiBai.SelectedValue) && mhck.hidden == true
        //                && u.username_username == Request.Cookies["UserName"].Value
        //                 select m;
        //ddlMon.Items.Clear();
        //ddlMon.AppendDataBoundItems = true;
        //ddlMon.Items.Insert(0, "Chọn môn");
        //ddlMon.DataValueField = "monhoc_id";
        //ddlMon.DataTextField = "monhoc_name";
        //ddlMon.DataSource = getdataMon;
        //ddlMon.DataBind();
        //ddlMon.Visible = true;
        //grvList.DataSource = null;
        //grvList.DataBind();
    }

    //khi chọn môn lớp sẽ đổ ra ds các chương học của môn đó.
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getdataChuong = from ch in db.tbTracNghiem_Chapters
                            where ch.monhoc_id == Convert.ToInt32(ddlDeThi.SelectedValue)
                            && ch.khoi_id == Convert.ToInt32(ddlLoaiBai.SelectedValue)
                            && ch.hidden == true
                            select ch;
        lkChuong.DataSource = getdataChuong;
        lkChuong.DataBind();
        lkChuong.Visible = true;
        grvList.DataSource = null;
        grvList.DataBind();
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        //bai-kiem-tra-{id_khoi}/bai-kiem-tra-chi-tiet/{title}-{id_test}.html
        //var maxID = from t
        //string getLink = "bai-kiem-tra-" + ddlKhoi.SelectedValue + "/bai-kiem-tra-chi-tiet/" + cls.getLink(ddlLoaiBaiKiemTra.SelectedItem.Text) + "-1";
        //txtLink.Value = getLink;

        //if (ddlLoaiBaiKiemTra.SelectedValue == "Chọn loại bài kiểm tra")
        //{
        //    alert.alert_Warning(Page, "Vui lòng chọn loại bài kiểm tra", "");
        //}
        //else if (Convert.ToInt32(ddlLoaiBaiKiemTra.SelectedValue) == 4 && txtLoai.Value == "")
        //{
        //    alert.alert_Warning(Page, "Vui lòng nhập tên loại bài kiểm tra", "");
        //}
        //else
        //{

        //lấy thông tin tk đăng nhập
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        var maxID = (from t in db.tbTracNghiem_Tests
                     orderby t.test_id descending
                     select t.test_id).First();
        //int id = Convert.ToInt32(maxID) + 1;
        //kiểm tra nếu click chọn đủ số câu yêu thì mới cho lưu, ngược lại thì báo lỗi
        //int soCH = Convert.ToInt32(txtSoCauHoi.Value);
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "englishquestion_id" });
        //if (selectedKey.Count() == soCH)
        //{
        //lưu vào databasse

        /* 
         * nếu mà chọn loại bài thi là "Khác" 
         * thì sẽ lưu thêm mới loại bài thi mới tạo vào bảng tbTracNghiem_BaiThiCate
         * với username và status=2
         */
        //if (ddlLoaiBaiKiemTra.SelectedValue == "4")
        //{
        //if (txtThoiGianLamBai.Value == "")
        //{
        //    alert.alert_Warning(Page, "Vui lòng nhập thời gian làm bài!", "");
        //}
        //else
        //{
        tbTracNghiem_BaiThiCate loaibaithi = new tbTracNghiem_BaiThiCate();
        loaibaithi.baithicate_name = ddlKyNang.SelectedItem.Text;
        loaibaithi.hidden = false;
        loaibaithi.baithicate_position = 2;
        loaibaithi.baithicate_status = 2;
        loaibaithi.username_id = getUser.username_id;
        loaibaithi.thoigianlambai = txtThoiGianHoanThanh.Value;
        db.tbTracNghiem_BaiThiCates.InsertOnSubmit(loaibaithi);
        db.SubmitChanges();
        tbTracNghiem_Test insert = new tbTracNghiem_Test();
        insert.baithicate_id = loaibaithi.baithicate_id;
        insert.question_id = String.Join(",", selectedKey);
        insert.test_createdate = DateTime.Now;
        insert.username_id = getUser.username_id;
        insert.hidden = false;
        insert.khoi_id = 18;
        insert.monhoc_id = Convert.ToInt16(ddlLoaiBai.SelectedValue);
        insert.lesson_id = Convert.ToInt16(ddlDeThi.SelectedValue);
        insert.kynang_id = ddlKyNang.SelectedValue;
        insert.test_show = "";
        //insert.test_link = /*"bai-kiem-tra-" + Convert.ToInt32(ddlKhoi.SelectedValue) + */"bai-kiem-tra-chi-tiet/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + (Convert.ToInt32(maxID) + 1) + ".html";
        db.tbTracNghiem_Tests.InsertOnSubmit(insert);
        db.SubmitChanges();
        //bai-kiem-tra-{id_khoi}/bai-kiem-tra-chi-tiet/{title}-{id_test}.html
        foreach (var item in selectedKey)
        {
            tbTracNghiem_TestDetail ins = new tbTracNghiem_TestDetail();
            ins.test_id = insert.test_id;
            ins.question_id = Convert.ToInt32(item);
            ins.hidden = false;
            db.tbTracNghiem_TestDetails.InsertOnSubmit(ins);
            db.SubmitChanges();
        }
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tạo bài kiểm tra thành công!','','success').then(function(){grvList.UnselectRows();})", true);
        //    }
        //}
        //else
        //{
        //    insert.baithicate_id = Convert.ToInt32(ddlLoaiBaiKiemTra.SelectedValue);
        //    insert.question_id = String.Join(",", selectedKey);
        //    insert.test_createdate = DateTime.Now;
        //    insert.username_id = getUser.username_id;
        //    insert.hidden = false;
        //    insert.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
        //    insert.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
        //    if (ddlLoaiBaiKiemTra.SelectedValue == "1")
        //        insert.test_show = "show";
        //    else
        //        insert.test_show = "";
        //    insert.test_link = /*"bai-kiem-tra-" + Convert.ToInt32(ddlKhoi.SelectedValue) + */"bai-kiem-tra-chi-tiet/" + cls_ToAscii.ToAscii(ddlLoaiBaiKiemTra.SelectedItem.Text) + "-" + (Convert.ToInt32(maxID) + 1) + ".html";
        //    db.tbTracNghiem_Tests.InsertOnSubmit(insert);
        //    db.SubmitChanges();
        //    foreach (var item in selectedKey)
        //    {
        //        tbTracNghiem_TestDetail ins = new tbTracNghiem_TestDetail();
        //        ins.test_id = insert.test_id;
        //        ins.question_id = Convert.ToInt32(item);
        //        ins.hidden = false;
        //        db.tbTracNghiem_TestDetails.InsertOnSubmit(ins);
        //        db.SubmitChanges();
        //    }
        //    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tạo bài kiểm tra thành công!','','success').then(function(){grvList.UnselectRows();})", true);
        //}
        //}
        //else
        //{
        //    alert.alert_Error(Page, "Vui lòng chọn đủ số câu hỏi", "");
        //}
        //}
    }

    protected void btnChon_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnLuuBai_Click(object sender, EventArgs e)
    {

    }

    protected void ddlChuong_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _idKhoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
        int _idMon = Convert.ToInt32(RouteData.Values["id_mon"]);

        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.khoi_id == _idKhoi && c.monhoc_id == _idMon && c.hidden == true
                    select c;
        lkChuong.DataSource = getCh;
        lkChuong.DataBind();
        lkChuong.Visible = true;
        grvList.DataSource = null;
        grvList.DataBind();
    }

    protected void ddlLoaiBai_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get ds đề thi của bài thi
        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.khoi_id == 18 && c.monhoc_id == Convert.ToInt16(ddlLoaiBai.SelectedValue)
                     && c.hidden == true
                    select c;
        ddlDeThi.Items.Clear();
        ddlDeThi.AppendDataBoundItems = true;
        ddlDeThi.Items.Insert(0, "Chọn đề thi");
        ddlDeThi.DataValueField = "chapter_id";
        ddlDeThi.DataTextField = "chapter_name";
        ddlDeThi.DataSource = getCh;
        ddlDeThi.DataBind();
        ddlDeThi.Visible = true;
        grvList.DataSource = null;
        grvList.DataBind();
    }

    protected void ddlDeThi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getKyNang = from l in db.tbTracNghiem_Lessons
                        where l.chapter_id == Convert.ToInt16(ddlDeThi.SelectedValue) && l.hidden == true
                        select l;

        ddlKyNang.Items.Clear();
        ddlKyNang.AppendDataBoundItems = true;
        ddlKyNang.Items.Insert(0, "Chọn kỹ năng");
        ddlKyNang.DataValueField = "lesson_id";
        ddlKyNang.DataTextField = "lesson_name";
        ddlKyNang.DataSource = getKyNang;
        ddlKyNang.DataBind();
        ddlKyNang.Visible = true;
        grvList.DataSource = null;
        grvList.DataBind();
    }

    //protected void ddlKyNang_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    protected void ddlKyNang_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getCH = from gch in db.tbTracNghiem_EnglishQuestions
                    join bh in db.tbTracNghiem_Lessons on gch.lesson_id equals bh.lesson_id
                    join name in db.admin_Users on gch.username_id equals name.username_id
                    where gch.lesson_id == Convert.ToInt16(ddlKyNang.SelectedValue)
                    && gch.hidden == false
                    select new
                    {
                        gch.englishquestion_id,
                        bh.lesson_name,
                        englishquestion_content = gch.englishquestion_content.Contains("/uploadimages/tracnghiemtienganh/B1/speaking/") ? "<img src='"+ gch.englishquestion_content + "'/>": gch.englishquestion_content,
                        gch.englishquestion_level,
                        gch.englishquestion_dangcauhoi,
                        name.username_fullname
                    };
        grvList.DataSource = getCH;
        grvList.DataBind();
    }
}