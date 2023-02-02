using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiLuyenTap_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();

    private static int _idKhoi;
    private static int _idMonHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var getkhoi = from mh in db.tbMonHocs
                          join mhck in db.tbMonHocCuaKhois on mh.monhoc_id equals mhck.monhoc_id
                          where mhck.khoi_id == 18
                          select mh;
            ddlMon.Items.Clear();
            ddlMon.AppendDataBoundItems = true;
            ddlMon.Items.Insert(0, "Chọn môn");
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataSource = getkhoi;
            ddlMon.DataBind();
            ddlDe.Items.Insert(0, "Chọn đề");
            ddlKyNang.Items.Insert(0, "Chọn kỹ năng");
        }
        if (ddlKyNang.SelectedValue != "Chọn kỹ năng")
        {
            getdata();
        }

    }
    private void getdata()
    {
        //var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
        //                join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                //join name in db.admin_Users on gdtCH.username_id equals name.username_id
        //                //join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
        //                where gdtCH.lesson_id == Convert.ToInt32(ddlKyNang.SelectedValue)
        //                && gdtCH.hidden == false
        //                //&& gdtCH.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
        //                //orderby gdtCH.question_id descending
        //                //orderby gdtCH.question_id descending
        //                select new
        //                {
        //                    //c.chapter_id,
        //                    question_content = gdtCH.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + gdtCH.question_content + "'</div>" : gdtCH.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' style='width:200px;height:200px' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.question_content + "'> </audio>" : gdtCH.question_content,
        //                    gdtCH.englishquestion_part,
        //                    //question_level = gdtCH.question_level,
        //                    c.lesson_name,
        //                    // name.username_fullname,
        //                    gdtCH.englishquestion_id,
        //                    //gdtCH.question_dangcauhoi
        //                    //gdtCH.question_dangcauhoi,
        //                    //gdtCH.question_level

        //                };
        var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
                        join c in db.tbTracNghiem_KyNangs on gdtCH.kynang_id equals c.kynang_id
                        //join name in db.admin_Users on gdtCH.username_id equals name.username_id
                        //join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                        where gdtCH.kynang_id == Convert.ToInt32(ddlKyNang.SelectedValue)
                        && gdtCH.hidden == false
                        //&& gdtCH.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
                        //orderby gdtCH.question_id descending
                        //orderby gdtCH.question_id descending
                        select new
                        {
                            //c.chapter_id,
                            question_content = gdtCH.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + gdtCH.question_content + "'</div>" : gdtCH.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' style='width:200px;height:200px' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.question_content + "'> </audio>" : gdtCH.question_content,
                            gdtCH.englishquestion_part,
                            //question_level = gdtCH.question_level,
                            c.kynang_name,
                            // name.username_fullname,
                            gdtCH.englishquestion_id,
                            //gdtCH.question_dangcauhoi
                            //gdtCH.question_dangcauhoi,
                            //gdtCH.question_level

                        };
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" +  + "')", true);
        grvList.DataSource = gdtCauhoi;
        grvList.DataBind();
    }
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get ds đề
        //var getChuong = from ch in db.tbTracNghiem_Chapters
        //                join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
        //                where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
        //                //&& ch.khoi_id == Convert.ToInt32(ddlMon.SelectedValue)
        //                && ch.hidden == true
        //                select ch;
        var getChuong = from ch in db.tbTracNghiem_DeThis
                        join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
                        where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                        //&& ch.khoi_id == Convert.ToInt32(ddlMon.SelectedValue)
                        && ch.hidden == true
                        select ch;
        ddlDe.Items.Clear();
        ddlDe.AppendDataBoundItems = true;
        ddlDe.Items.Insert(0, "Chọn đề");
        ddlDe.DataValueField = "dethi_id";
        ddlDe.DataTextField = "dethi_name";
        ddlDe.DataSource = getChuong;
        ddlDe.DataBind();
        _idMonHoc = Convert.ToInt32(ddlMon.SelectedValue);
        //var getMon = from mhck in db.tbMonHocCuaKhois
        //             join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
        //             join gvdm in db.tbGiaoVienDayMons on mh.monhoc_id equals gvdm.monhoc_id
        //             join u in db.admin_Users on gvdm.username_id equals u.username_id
        //             where mhck.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
        //             && mhck.hidden == true
        //              && u.username_username == Request.Cookies["UserName"].Value
        //             select mh;

        //_idKhoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        //ddlMon.Items.Clear();
        //ddlMon.AppendDataBoundItems = true;
        //ddlMon.Items.Insert(0, "Chọn môn");
        //ddlMon.DataValueField = "monhoc_id";
        //ddlMon.DataTextField = "monhoc_name";
        //ddlMon.DataSource = getMon;
        //ddlMon.DataBind();
    }

    protected void ddlDe_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get list kỹ năng của đề
        //var getKyNang = from kn in db.tbTracNghiem_Lessons
        //                join c in db.tbTracNghiem_Chapters on kn.chapter_id equals c.chapter_id
        //                //join gvdm in db.tbGiaoVienDayMons on mh.monhoc_id equals gvdm.monhoc_id
        //                //join u in db.admin_Users on gvdm.username_id equals u.username_id
        //                where c.chapter_id == Convert.ToInt32(ddlDe.SelectedValue)
        //                //&& mhck.hidden == true
        //                // && u.username_username == Request.Cookies["UserName"].Value
        //                select kn;
        var getKyNang = from kn in db.tbTracNghiem_KyNangs
                        join c in db.tbTracNghiem_DeThis on kn.dethi_id equals c.dethi_id
                        //join gvdm in db.tbGiaoVienDayMons on mh.monhoc_id equals gvdm.monhoc_id
                        //join u in db.admin_Users on gvdm.username_id equals u.username_id
                        where c.dethi_id == Convert.ToInt32(ddlDe.SelectedValue) && kn.hidden == true
                        //&& mhck.hidden == true
                        // && u.username_username == Request.Cookies["UserName"].Value
                        select kn;
        //_idKhoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        ddlKyNang.Items.Clear();
        ddlKyNang.AppendDataBoundItems = true;
        ddlKyNang.Items.Insert(0, "Chọn kỹ năng");
        ddlKyNang.DataValueField = "kynang_id";
        ddlKyNang.DataTextField = "kynang_name";
        ddlKyNang.DataSource = getKyNang;
        ddlKyNang.DataBind();
        //var getChuong = from ch in db.tbTracNghiem_Chapters
        //                join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
        //                where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
        //                && ch.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
        //                && ch.hidden == true

        //                select ch;
        //ddlChuong.Items.Clear();
        //ddlChuong.AppendDataBoundItems = true;
        //ddlChuong.Items.Insert(0, "Chọn chương");
        //ddlChuong.DataValueField = "chapter_id";
        //ddlChuong.DataTextField = "chapter_name";
        //ddlChuong.DataSource = getChuong;
        //ddlChuong.DataBind();
        //_idMonHoc = Convert.ToInt32(ddlMon.SelectedValue);
        // ManageDivTracNghiem();
    }

    protected void ManageDivTracNghiem()
    {
        var getMon = (from mh in db.tbMonHocs
                      join mhck in db.tbMonHocCuaKhois on mh.monhoc_id equals mhck.monhoc_id
                      where mhck.khoi_id == _idKhoi
                      && mh.monhoc_id == _idMonHoc
                      select mh).First().monhoc_name;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (ddlMon.SelectedValue == "Chọn môn")
        {
            alert.alert_Warning(Page, "Vui lòng chọn môn", "");
        }
        else if (ddlDe.SelectedValue == "Chọn đề")
        {
            alert.alert_Warning(Page, "Vui lòng chọn đề", "");
        }
        else if (ddlKyNang.SelectedValue == "Chọn kỹ năng")
        {
            alert.alert_Warning(Page, "Vui lòng chọn kỹ năng", "");
        }
        else
        {
            List<object> seclectedKey = grvList.GetSelectedFieldValues(new string[] { "englishquestion_id" });
            if (seclectedKey.Count() == 0 && divTracNghiem.Visible == true)
            {
                alert.alert_Error(Page, "Bạn chưa chọn câu hỏi", "");
            }
            else
            {
                if (Request.Cookies["UserName"] != null)
                {
                    //string[] arrList = new string[100];
                    //string str_code = "";
                    //string str_first = "";
                    //bool is_link = true;
                    //if (txtLink.Value != "")
                    //{
                    //    arrList = txtLink.Value.Split('=');
                    //    try
                    //    {
                    //        string str_init = arrList[0];
                    //        str_code = arrList[1];
                    //        str_first = "https://www.youtube.com/embed/";
                    //        if ((str_init != "https://www.youtube.com/watch?v") || (str_code.Length != 11))
                    //            is_link = false;
                    //    }
                    //    catch
                    //    {
                    //        is_link = false;
                    //    }

                    //}

                    //if (is_link)
                    //{


                    var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
                    tbTracNghiem_BaiThiCate loaibaithi = new tbTracNghiem_BaiThiCate();
                    loaibaithi.baithicate_name = ddlKyNang.SelectedItem.Text;
                    loaibaithi.hidden = false;
                    loaibaithi.baithicate_position = 2;
                    loaibaithi.baithicate_status = 2;
                    loaibaithi.username_id = checkuserid.username_id;
                    //loaibaithi.thoigianlambai = txtThoiGianHoanThanh.Value;
                    loaibaithi.baithicate_loai = "luyen tap";
                    db.tbTracNghiem_BaiThiCates.InsertOnSubmit(loaibaithi);
                    db.SubmitChanges();
                    tbTracNghiem_Test insert = new tbTracNghiem_Test();
                    insert.baithicate_id = loaibaithi.baithicate_id;
                    insert.question_id = String.Join(",", seclectedKey);
                    insert.test_createdate = DateTime.Now;
                    insert.username_id = checkuserid.username_id;
                    insert.hidden = false;
                    insert.khoi_id = 18;
                    insert.monhoc_id = Convert.ToInt16(ddlMon.SelectedValue);
                    //insert.lesson_id = Convert.ToInt16(ddlDe.SelectedValue);
                    insert.dethi_id = Convert.ToInt16(ddlDe.SelectedValue);
                    insert.kynang_id = ddlKyNang.SelectedValue;
                    insert.test_show = "";
                    //insert.test_link = /*"bai-kiem-tra-" + Convert.ToInt32(ddlKhoi.SelectedValue) + */"bai-kiem-tra-chi-tiet/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + (Convert.ToInt32(maxID) + 1) + ".html";
                    db.tbTracNghiem_Tests.InsertOnSubmit(insert);
                    db.SubmitChanges();
                    //}
                    foreach (var item in seclectedKey)
                    {
                        tbTracNghiem_TestDetail cttest = new tbTracNghiem_TestDetail();
                        cttest.test_id = insert.test_id;
                        cttest.question_id = Convert.ToInt32(item);
                        cttest.hidden = false;
                        db.tbTracNghiem_TestDetails.InsertOnSubmit(cttest);
                        db.SubmitChanges();
                    }
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tạo bài luyện tập thành công!','','success').then(function(){grvList.UnselectRows();})", true);
                    getdata();
                    //}
                    //else
                    //{
                    //    alert.alert_Error(Page, "Đường dẫn Youtube sai định dạng!", "");
                    //}
                }
            }
        }
    }
}