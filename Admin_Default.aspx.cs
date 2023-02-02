using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT;
    cls_Alert alert = new cls_Alert();
    //public string activeKhoi, activeMon, activeChuong;
    protected void Page_Load(object sender, EventArgs e)
    {
        // activeKhoi = activeKhoi.Attributes.Add("style", "background:#ffd800");
        STT = 1;
        //if(!IsPostBack)
        //{
        //    divTao.Visible = false;
        //}

        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            btnThemChuong.Visible = false;
            btnThemBaiHoc.Visible = false;
            btnTaoListening.Visible = false;
            btnTaoReading.Visible = false;
            btnTaoSpeaking.Visible = false;
            btnTaoWriting.Visible = false;
        }
        //if (!IsPostBack)
        //{
        //    var listMH = from mhck in db.tbMonHocCuaKhois
        //                 join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
        //                 where mhck.khoi_id == 18 && mhck.hidden == true
        //                 select mh;
        //    ddlMonHoc.Items.Clear();
        //    ddlMonHoc.AppendDataBoundItems = true;
        //    ddlMonHoc.Items.Insert(0, "Chọn môn học");
        //    ddlMonHoc.DataValueField = "monhoc_id";
        //    ddlMonHoc.DataTextField = "monhoc_name";
        //    ddlMonHoc.DataSource = listMH;
        //    ddlMonHoc.DataBind();
        //}
        var getmh = from mhck in db.tbMonHocCuaKhois
                    join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                    where mhck.khoi_id == 18 && mhck.hidden == true
                    select mh;
        rpMonHoc.DataSource = getmh;
        rpMonHoc.DataBind();
        rpChuong.DataSource = null;
        rpChuong.DataBind();
        rpBaiHoc.DataSource = null;
        rpBaiHoc.DataBind();
        //if (txtKhoi_Id.Value != "")
        //{
        //    btnThemMonBL.Visible = true;
        //}
        //else
        //{
        //    btnThemMonBL.Visible = false;
        //}
        if (txtMon_Id.Value != "")
        {
            btnThemChuongBL.Visible = true;
        }
        else
        {
            btnThemChuongBL.Visible = false;
        }
        //rpKhoi.DataBind();
    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        //alert.alert_Success(Page,"get_id" + txtThongBao_id.Value,"");
        //Response.Redirect("admin-file-huong-dan-danh-gia-" + txtThongBao_id.Value);
    }
    //protected void btnGetMonHoc_ServerClick(object sender, EventArgs e)
    //{
    //    int _IdKhoi = Convert.ToInt32(txtKhoi_Id.Value);
    //    var getMH = from mhck in db.tbMonHocCuaKhois
    //                join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                where mhck.khoi_id == _IdKhoi && mhck.hidden == true
    //                select mh;
    //    rpMonHoc.DataSource = getMH;
    //    rpMonHoc.DataBind();
    //    if (rpMonHoc.DataSource != null)
    //        btnThemMon.Visible = true;
    //    else
    //        btnThemMon.Visible = false;
    //    rpChuong.DataSource = null;
    //    rpChuong.DataBind();
    //    rpBaiHoc.DataSource = null;
    //    rpBaiHoc.DataBind();
    //}
    private void getDanhSachDe(int monhoc)
    {
        //var getCh = from c in db.tbTracNghiem_Chapters
        //            join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
        //            join k in db.tbKhois on c.khoi_id equals k.khoi_id
        //            where c.khoi_id == 18 && c.monhoc_id == monhoc
        //            && c.hidden == true
        //            select c;
        var getCh = from d in db.tbTracNghiem_DeThis
                    join mh in db.tbMonHocs on d.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on d.khoi_id equals k.khoi_id
                    where d.khoi_id == 18 && d.monhoc_id == monhoc
                    && d.hidden == true
                    select d;
        rpChuong.DataSource = getCh;
        rpChuong.DataBind();
        //ddlDeThi.Items.Clear();
        //ddlDeThi.AppendDataBoundItems = true;
        //ddlDeThi.Items.Insert(0, "Chọn đề thi");
        //ddlDeThi.DataValueField = "chapter_id";
        //ddlDeThi.DataTextField = "chapter_name";
        //ddlDeThi.DataSource = getCh;
        //ddlDeThi.DataBind();
        if (rpChuong.DataSource != null)
            btnThemChuong.Visible = true;
        else
            btnThemChuong.Visible = false;
        rpBaiHoc.DataSource = null;
        rpBaiHoc.DataBind();
    }
    protected void bntGetChuongHoc_ServerClick(object sender, EventArgs e)
    {
        int _IdMon = Convert.ToInt32(txtMon_Id.Value);
        getDanhSachDe(_IdMon);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActive('" + _IdMon + "')", true);
    }


    protected void btnGetBaiHoc_ServerClick(object sender, EventArgs e)
    {
        btnThemChuong.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        getDanhSachDe(Convert.ToInt32(txtMon_Id.Value));
        int _IdChuong = Convert.ToInt32(txtChuong_ID.Value);
        //var getLesson = from l in db.tbTracNghiem_Lessons
        //                where l.chapter_id == _IdChuong && l.hidden == true
        //                select l; 
        var getLesson = from l in db.tbTracNghiem_KyNangs
                        where l.dethi_id == _IdChuong && l.hidden == true
                        select l;
        rpBaiHoc.DataSource = getLesson;
        rpBaiHoc.DataBind();
        if (rpBaiHoc.DataSource != null)
        {

            btnThemBaiHoc.Visible = true;
            btnTaoListening.Visible = true;
            btnTaoReading.Visible = true;
            btnTaoSpeaking.Visible = true;
            btnTaoWriting.Visible = true;
        }
        else
        {
            btnThemBaiHoc.Visible = false;
        }
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActive('" + txtMon_Id.Value + "');myActive('" + _IdChuong + "')", true);
    }

    protected void btnThemMon_ServerClick(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupShow()", true);
    }

    protected void btnThemChuong_ServerClick(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupShow1()", true);
    }
    //protected void btnLuu_Click(object sender, EventArgs e)
    //{
    //    //if (txtMonHoc.Value == "")
    //    //{
    //    //    alert.alert_Error(Page, "Bạn chưa nhập tên môn", "");
    //    //}
    //    //else
    //    //{
    //    var getMon = from mhck in db.tbMonHocCuaKhois
    //                 join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                 //join k in db.tbKhois on mhck.khoi_id equals k.khoi_id
    //                 where mhck.khoi_id == Convert.ToInt32(txtKhoi_Id.Value)
    //                 && mh.monhoc_name.Contains(txtMonHoc.Value)
    //                 select mh;
    //    if (getMon.Count() > 0)
    //    {
    //        alert.alert_Warning(Page, "Môn này đã được thêm!", "");
    //    }
    //    else
    //    {
    //        var getMH = (from mh in db.tbMonHocs
    //                     where mh.monhoc_name == txtMonHoc.Value
    //                     select mh).SingleOrDefault();
    //        if (getMH == null)
    //        {
    //            tbMonHoc monhoc = new tbMonHoc();
    //            monhoc.monhoc_name = txtMonHoc.Value;
    //            db.tbMonHocs.InsertOnSubmit(monhoc);
    //            db.SubmitChanges();
    //            var get = (from mh in db.tbMonHocs
    //                       where mh.monhoc_name == txtMonHoc.Value
    //                       select mh).SingleOrDefault();
    //            tbMonHocCuaKhoi addMon = new tbMonHocCuaKhoi();
    //            addMon.monhoc_id = get.monhoc_id;
    //            addMon.khoi_id = Convert.ToInt32(txtKhoi_Id.Value);
    //            addMon.hidden = true;
    //            //addMon.hidden = false;
    //            db.tbMonHocCuaKhois.InsertOnSubmit(addMon);
    //            db.SubmitChanges();
    //            // load lại dữ liệu
    //            int _IdKhoi = Convert.ToInt32(txtKhoi_Id.Value);
    //            var getMH1 = from mhck in db.tbMonHocCuaKhois
    //                         join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                         where mhck.khoi_id == _IdKhoi && mhck.hidden == true
    //                         select mh;
    //            rpMonHoc.DataSource = getMH1;
    //            rpMonHoc.DataBind();
    //            if (rpMonHoc.DataSource != null)
    //                btnThemMon.Visible = true;
    //            else
    //                btnThemMon.Visible = false;
    //        }
    //        else
    //        {
    //             getMH = (from mh in db.tbMonHocs
    //                         where mh.monhoc_name == txtMonHoc.Value
    //                         select mh).SingleOrDefault();
    //            if (getMH == null)
    //            {
    //                tbMonHoc monhoc = new tbMonHoc();
    //                monhoc.monhoc_name = txtMonHoc.Value;
    //                db.tbMonHocs.InsertOnSubmit(monhoc);
    //                db.SubmitChanges();
    //                var get = (from mh in db.tbMonHocs
    //                           where mh.monhoc_name == txtMonHoc.Value
    //                           select mh).SingleOrDefault();
    //                tbMonHocCuaKhoi addMon = new tbMonHocCuaKhoi();
    //                addMon.monhoc_id = get.monhoc_id;
    //                addMon.khoi_id = Convert.ToInt32(txtKhoi_Id.Value);
    //                addMon.hidden = true;
    //                //addMon.hidden = false;
    //                db.tbMonHocCuaKhois.InsertOnSubmit(addMon);
    //                db.SubmitChanges();
    //                //alert.alert_Success(Page, "Thêm môn thành công", "");
    //                int _IdKhoi = Convert.ToInt32(txtKhoi_Id.Value);
    //                var getMH1 = from mhck in db.tbMonHocCuaKhois
    //                             join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                             where mhck.khoi_id == _IdKhoi && mhck.hidden == true
    //                             select mh;
    //                rpMonHoc.DataSource = getMH1;
    //                rpMonHoc.DataBind();
    //                if (rpMonHoc.DataSource != null)
    //                    btnThemMon.Visible = true;
    //                else
    //                    btnThemMon.Visible = false;
    //                // alert.alert_Success(Page, "Vui lòng đợi quản trị viên duyệt trong 24h", "Thêm môn thành công");
    //            }
    //            else
    //            {
    //                tbMonHocCuaKhoi addMon = new tbMonHocCuaKhoi();
    //                addMon.monhoc_id = getMH.monhoc_id;
    //                addMon.khoi_id = Convert.ToInt32(txtKhoi_Id.Value);
    //                addMon.hidden = true;
    //                //addMon.hidden = false;
    //                db.tbMonHocCuaKhois.InsertOnSubmit(addMon);
    //                db.SubmitChanges();
    //                alert.alert_Success(Page, "Thêm môn thành công", "");
    //                int _IdKhoi = Convert.ToInt32(txtKhoi_Id.Value);
    //                var getMH1 = from mhck in db.tbMonHocCuaKhois
    //                             join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                             where mhck.khoi_id == _IdKhoi && mhck.hidden == true
    //                             select mh;
    //                rpMonHoc.DataSource = getMH1;
    //                rpMonHoc.DataBind();
    //                if (rpMonHoc.DataSource != null)
    //                    btnThemMon.Visible = true;
    //                else
    //                    btnThemMon.Visible = false;
    //                //alert.alert_Success(Page, "Vui lòng đợi quản trị viên duyệt trong 24h", "Thêm môn thành công");
    //            }
    //        }
    //    }
    //    //}
    //}
    protected void btnLuuChuong_Click(object sender, EventArgs e)
    {
        // Đang xử lý chương
        //var checkName = from ch in db.tbTracNghiem_Chapters
        //                where ch.chapter_name.Contains(txtChuong.Value)
        //                && ch.hidden == true
        //                && ch.khoi_id == 18
        //                && ch.monhoc_id == Convert.ToInt32(txtMon_Id.Value)
        //                select ch;
        var checkName = from ch in db.tbTracNghiem_DeThis
                        where ch.dethi_name.Contains(txtChuong.Value)
                        && ch.hidden == true
                        && ch.khoi_id == 18
                        && ch.monhoc_id == Convert.ToInt32(txtMon_Id.Value)
                        select ch;
        if (checkName.Count() > 0)
        {
            alert.alert_Warning(Page, "Đề này đã được thêm!", "");
        }
        else
        {
            //tbTracNghiem_Chapter chuong = new tbTracNghiem_Chapter();
            //chuong.monhoc_id = Convert.ToInt32(txtMon_Id.Value);
            //chuong.khoi_id = 18;
            //chuong.chapter_name = txtChuong.Value;
            //chuong.hidden = true;
            //db.tbTracNghiem_Chapters.InsertOnSubmit(chuong);
            tbTracNghiem_DeThi de = new tbTracNghiem_DeThi();
            de.monhoc_id = Convert.ToInt32(txtMon_Id.Value);
            de.khoi_id = 18;
            de.dethi_name = txtChuong.Value;
            de.hidden = true;
            db.tbTracNghiem_DeThis.InsertOnSubmit(de);
            db.SubmitChanges();
            int _IdMon = Convert.ToInt32(txtMon_Id.Value);
            //var getCh = from c in db.tbTracNghiem_Chapters
            //            join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
            //            join k in db.tbKhois on c.khoi_id equals k.khoi_id
            //            where c.khoi_id == 18 && c.monhoc_id == _IdMon
            //             && c.hidden == true
            //            select c;
            var getCh = from c in db.tbTracNghiem_DeThis
                        join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                        join k in db.tbKhois on c.khoi_id equals k.khoi_id
                        where c.khoi_id == 18 && c.monhoc_id == _IdMon
                         && c.hidden == true
                        select c;
            rpChuong.DataSource = getCh;
            rpChuong.DataBind();
            alert.alert_Success(Page, "Thêm đề thành công", "");
            //alert.alert_Success(Page, "Vui lòng đợi quản trị viên duyệt trong 24h", "Thêm chương thành công");
            btnThemChuong.Visible = true;
        }
    }

    protected void btnThemBaiHoc_ServerClick(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupShow2();", true);
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;

    }

    protected void btnLuuBaiHoc_Click(object sender, EventArgs e)
    {
        //tbTracNghiem_Lesson baihoc = new tbTracNghiem_Lesson();
        //baihoc.lesson_name = txtBaiHoc.Value;
        //baihoc.chapter_id = Convert.ToInt32(txtChuong_ID.Value);
        //baihoc.hidden = true;
        ////baihoc.hidden = false;
        //baihoc.khoi_id = 18;
        //baihoc.monhoc_id = Convert.ToInt32(txtMon_Id.Value);
        //db.tbTracNghiem_Lessons.InsertOnSubmit(baihoc);
        tbTracNghiem_KyNang baihoc = new tbTracNghiem_KyNang();
        baihoc.kynang_name = txtBaiHoc.Value;
        baihoc.dethi_id = Convert.ToInt32(txtChuong_ID.Value);
        baihoc.hidden = true;
        //baihoc.hidden = false;
        baihoc.khoi_id = 18;
        baihoc.monhoc_id = Convert.ToInt32(txtMon_Id.Value);
        db.tbTracNghiem_KyNangs.InsertOnSubmit(baihoc);
        db.SubmitChanges();
        int _IdChuong = Convert.ToInt32(txtChuong_ID.Value);
        //var getLesson = from l in db.tbTracNghiem_Lessons
        //                where l.chapter_id == _IdChuong && l.hidden == true
        //                select l;
        var getLesson = from l in db.tbTracNghiem_KyNangs
                        where l.dethi_id == _IdChuong && l.hidden == true
                        select l;
        rpBaiHoc.DataSource = getLesson;
        rpBaiHoc.DataBind();
        //alert.alert_Success(Page, "Thêm bài học thành công", "");
        //alert.alert_Success(Page, "Vui lòng đợi quản trị viên duyệt trong 24h", "Thêm bài học thành công");
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;

        //}
    }

    //protected void btnDelMon_ServerClick(object sender, EventArgs e)
    //{
    //    var del = (from mh in db.tbMonHocs
    //               join mhck in db.tbMonHocCuaKhois on mh.monhoc_id equals mhck.monhoc_id
    //               where mh.monhoc_id == Convert.ToInt32(txtMon_Id.Value)
    //               select mhck).FirstOrDefault();
    //    del.hidden = false;
    //    db.SubmitChanges();

    //    //load
    //    int _IdKhoi = Convert.ToInt32(txtKhoi_Id.Value);
    //    var getMH = from mhck in db.tbMonHocCuaKhois
    //                join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
    //                where mhck.khoi_id == _IdKhoi && mhck.hidden == true
    //                select mh;
    //    rpMonHoc.DataSource = getMH;
    //    rpMonHoc.DataBind();
    //    if (rpMonHoc.DataSource != null)
    //        btnThemMon.Visible = true;
    //    else
    //        btnThemMon.Visible = false;
    //    rpChuong.DataSource = null;
    //    rpChuong.DataBind();
    //    rpBaiHoc.DataSource = null;
    //    rpBaiHoc.DataBind();
    //}

    protected void btnDelChapter_ServerClick(object sender, EventArgs e)
    {
        //var del = (from chap in db.tbTracNghiem_Chapters
        //           where chap.chapter_id == Convert.ToInt32(txtChuong_ID.Value)
        //           select chap).FirstOrDefault();
        var del = (from chap in db.tbTracNghiem_DeThis
                   where chap.dethi_id == Convert.ToInt32(txtChuong_ID.Value)
                   select chap).FirstOrDefault();
        del.hidden = false;
        db.SubmitChanges();

        //load
        int _IdMon = Convert.ToInt32(txtMon_Id.Value);
        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.khoi_id == 18 && c.monhoc_id == _IdMon && c.hidden == true
                    select c;
        rpChuong.DataSource = getCh;
        rpChuong.DataBind();
        if (rpChuong.DataSource != null)
            btnThemChuong.Visible = true;
        else
            btnThemChuong.Visible = false;
        rpBaiHoc.DataSource = null;
        rpBaiHoc.DataBind();

    }
    protected void btnDelLesson_ServerClick(object sender, EventArgs e)
    {
        //var del = (from l in db.tbTracNghiem_Lessons
        //           join c in db.tbTracNghiem_Chapters on l.chapter_id equals c.chapter_id
        //           join k in db.tbKhois on l.khoi_id equals k.khoi_id
        //           join mh in db.tbMonHocs on l.monhoc_id equals mh.monhoc_id
        //           where c.chapter_id == (Convert.ToInt32(txtChuong_ID.Value))
        //           && k.khoi_id == Convert.ToInt32(txtKhoi_Id.Value)
        //           && mh.monhoc_id == Convert.ToInt32(txtMon_Id.Value)
        //           select l).FirstOrDefault();

        //var del = (from l in db.tbTracNghiem_Lessons
        //           where l.lesson_id == Convert.ToInt32(txtBaiHoc_ID.Value)
        //           select l).FirstOrDefault();
        var del = (from l in db.tbTracNghiem_KyNangs
                   where l.kynang_id == Convert.ToInt32(txtBaiHoc_ID.Value)
                   select l).FirstOrDefault();
        del.hidden = false;
        db.SubmitChanges();

        //load
        btnThemChuong.Visible = true;
        int _IdChuong = Convert.ToInt32(txtChuong_ID.Value);
        var getLesson = from l in db.tbTracNghiem_Lessons
                        where l.chapter_id == _IdChuong && l.hidden == true
                        select l;
        rpBaiHoc.DataSource = getLesson;
        rpBaiHoc.DataBind();
        if (rpBaiHoc.DataSource != null)
        {
            btnThemBaiHoc.Visible = true;
            btnTaoListening.Visible = true;
            btnTaoReading.Visible = true;
            btnTaoSpeaking.Visible = true;
            btnTaoWriting.Visible = true;

        }
        else
        {
            btnThemBaiHoc.Visible = false;
        }
    }

    protected void btnTaoSpeaking_ServerClick(object sender, EventArgs e)
    {
        int ID_Mon = Convert.ToInt32(txtMon_Id.Value);
        int ID_Chuong = Convert.ToInt32(txtChuong_ID.Value);
        if (txtBaiHoc_ID.Value == "")
        {
            alert.alert_Warning(Page, "Chưa chọn bài học!", "");
        }
        else
        {
            int ID_Bai = Convert.ToInt32(txtBaiHoc_ID.Value);
            var lesson = (from l in db.tbTracNghiem_Lessons
                          where l.lesson_id == ID_Bai
                          select l).FirstOrDefault();
            if (lesson.hidden == true)
            {
                Response.Redirect("admin-quan-ly-cau-hoi-speaking-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
            }
            else
            {
                alert.alert_Warning(Page, "Chưa chọn bài học!", "");
            }
        }
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;

    }

    protected void btnTaoWriting_ServerClick(object sender, EventArgs e)
    {
        int ID_Mon = Convert.ToInt32(txtMon_Id.Value);
        int ID_Chuong = Convert.ToInt32(txtChuong_ID.Value);
        if (txtBaiHoc_ID.Value == "")
        {
            alert.alert_Warning(Page, "Chưa chọn bài học!", "");
        }
        else
        {
            int ID_Bai = Convert.ToInt32(txtBaiHoc_ID.Value);
            var lesson = (from l in db.tbTracNghiem_Lessons
                          where l.lesson_id == ID_Bai
                          select l).FirstOrDefault();
            if (lesson.hidden == true)
            {
                Response.Redirect("admin-quan-ly-cau-hoi-writing-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
            }
            else
            {
                alert.alert_Warning(Page, "Chưa chọn bài học!", "");
            }
        }
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;
    }

    //protected void ddlMonHoc_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    getDanhSachDe(Convert.ToInt32(ddlMonHoc.SelectedValue));
    //}

    protected void btnTaoReading_ServerClick(object sender, EventArgs e)
    {
        int ID_Mon = Convert.ToInt32(txtMon_Id.Value);
        int ID_Chuong = Convert.ToInt32(txtChuong_ID.Value);

        if (txtBaiHoc_ID.Value == "")
        {
            alert.alert_Warning(Page, "Chưa chọn kỹ năng!", "");
        }
        else
        {
            int ID_Bai = Convert.ToInt32(txtBaiHoc_ID.Value);
            //var lesson = (from l in db.tbTracNghiem_Lessons
            //              where l.lesson_id == ID_Bai
            //              select l).FirstOrDefault();
            var lesson = (from l in db.tbTracNghiem_KyNangs
                          where l.kynang_id == ID_Bai
                          select l).FirstOrDefault();
            if (lesson.hidden == true)
            {
                if (txtMon_Id.Value == "72")
                    Response.Redirect("admin-quan-ly-cau-hoi-reading-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
                else
                    Response.Redirect("admin-quan-ly-cau-hoi-readinga2-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
            }
            else
            {
                alert.alert_Warning(Page, "Chưa chọn kỹ năng!", "");
            }
        }
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;
    }

    protected void btnTaoListening_ServerClick(object sender, EventArgs e)
    {

        if (txtBaiHoc_ID.Value == "")
        {
            alert.alert_Warning(Page, "Chưa chọn bài học!", "");
        }
        else
        {
            int ID_Mon = Convert.ToInt32(txtMon_Id.Value);
            int ID_Chuong = Convert.ToInt32(txtChuong_ID.Value);
            int ID_Bai = Convert.ToInt32(txtBaiHoc_ID.Value);
            var lesson = (from l in db.tbTracNghiem_KyNangs
                          where l.kynang_id == ID_Bai
                          select l).FirstOrDefault();
            if (lesson.hidden == true)
            {
                if (txtMon_Id.Value == "72")
                    Response.Redirect("admin-quan-ly-cau-hoi-listening-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
                else
                    Response.Redirect("admin-quan-ly-cau-hoi-listeninga2-18-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
            }
            else
            {
                alert.alert_Warning(Page, "Chưa chọn bài học!", "");
            }
        }
        btnThemBaiHoc.Visible = true;
        btnTaoListening.Visible = true;
        btnTaoReading.Visible = true;
        btnTaoSpeaking.Visible = true;
        btnTaoWriting.Visible = true;
    }
}