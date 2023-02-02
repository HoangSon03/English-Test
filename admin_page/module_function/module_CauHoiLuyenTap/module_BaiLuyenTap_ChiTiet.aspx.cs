using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_BaiLuyenTap_ChiTiet : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private static int _id;
    private static int _idKhoi;
    private static int _idMonhoc;
    private static int _idChapter;
    private static int _idLesson;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _id = Convert.ToInt32(RouteData.Values["id"]);
            //load thong tin cua bai luyen tap
            var getdetail = (from test in db.tbTracNghiem_Tests
                                 //join blt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals blt.luyentap_id
                             join khoi in db.tbKhois on test.khoi_id equals khoi.khoi_id
                             join monhoc in db.tbMonHocs on test.monhoc_id equals monhoc.monhoc_id
                             join chapter in db.tbTracNghiem_DeThis on test.dethi_id equals chapter.dethi_id
                             where test.test_id == _id
                             && test.monhoc_id == chapter.monhoc_id
                             select new
                             {
                                 //blt.luyentap_linkvideo,
                                 //blt.luyentap_name,
                                 //blt.luyentap_baitaptuluan,
                                 test.lesson_id,
                                 khoi.khoi_id,
                                 khoi.khoi_name,
                                 monhoc.monhoc_id,
                                 monhoc.monhoc_name,
                                 chapter.dethi_id,
                                 chapter.dethi_name,
                                 test.kynang_id,
                                 //test.dethi_id,
                             }).FirstOrDefault();
            //get ds môn học của Tiếng anh
            var getMonHoc = from mh in db.tbMonHocs
                            join mhck in db.tbMonHocCuaKhois on mh.monhoc_id equals mhck.monhoc_id
                            where mhck.khoi_id == 18
                            select mh;
            ddlMon.Items.Clear();
            ddlMon.AppendDataBoundItems = true;
            ddlMon.Items.Insert(0, "Chọn môn");
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataSource = getMonHoc;
            ddlMon.DataBind();
            //get ds đề của môn học của bài luyện tập
            var getmhck = from ch in db.tbTracNghiem_DeThis
                          join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
                          where ch.monhoc_id == getdetail.monhoc_id
                          && ch.hidden == true
                          select ch;
            ddlDe.Items.Clear();
            ddlDe.AppendDataBoundItems = true;
            ddlDe.Items.Insert(0, "Chọn đề");
            ddlDe.DataValueField = "dethi_id";
            ddlDe.DataTextField = "dethi_name";
            ddlDe.DataSource = getmhck;
            ddlDe.DataBind();
            //load Kỹ Năng
            var getchapter = from kn in db.tbTracNghiem_KyNangs
                             join c in db.tbTracNghiem_DeThis on kn.dethi_id equals c.dethi_id
                             where c.dethi_id == getdetail.dethi_id
                             select kn;
            ddlKyNang.Items.Clear();
            ddlKyNang.AppendDataBoundItems = true;
            ddlKyNang.Items.Insert(0, "Chọn kỹ năng");
            ddlKyNang.DataValueField = "kynang_id";
            ddlKyNang.DataTextField = "kynang_name";
            ddlKyNang.DataSource = getchapter;
            ddlKyNang.DataBind();
            ddlMon.SelectedValue = getdetail.monhoc_id.ToString();
            ddlDe.SelectedValue = getdetail.dethi_id.ToString();
            ddlKyNang.SelectedValue = getdetail.kynang_id.ToString();
            ////gán các giá trị cho các id để thêm vào url trong module thêm câu hỏi 
            _idKhoi = getdetail.khoi_id;
            _idMonhoc = getdetail.monhoc_id;
            _idChapter = getdetail.dethi_id;
            //mapping data 
            //if (getdetail.luyentap_linkvideo != "")
            //{
            //    //hien thi url video youtube len txtLink 
            //    string first_link = "https://www.youtube.com/watch?v=";
            //    txtLink.Value = first_link + getdetail.luyentap_linkvideo.Substring(30);
            //}
            //else
            //{
            //    txtLink.Value = "";
            //}

            //txtTenBai.Value = getdetail.luyentap_name;

            //edtnoidung.Html = getdetail.luyentap_baitaptuluan;
        }
        if (ddlKyNang.SelectedValue != "Chọn kỹ năng")
        {
            getdata();
        }
    }

    private void getdata()
    {

        var gdtCauhoi = from gdtCH in db.tbTracNghiem_EnglishQuestions
                        join ch in db.tbTracNghiem_KyNangs on gdtCH.kynang_id equals ch.kynang_id
                        where ch.kynang_id == Convert.ToInt32(ddlKyNang.SelectedValue)
                        && gdtCH.hidden == false
                        select new
                        {
                            question_content = gdtCH.englishquestion_content,//.Contains("style=") ? "<div class='content_image'>" + gdtCH.question_content + "</div>" : gdtCH.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' style='width:200px;height:200px' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + gdtCH.question_content + "'>" : gdtCH.question_content.Contains("mp3") ? " <audio controls> <source src = '" + gdtCH.question_content + "'> </audio>" : gdtCH.question_content,
                            gdtCH.englishquestion_id,
                            gdtCH.englishquestion_part,
                            ch.kynang_name,
                        };
        grvList.DataSource = gdtCauhoi;
        grvList.DataBind();
    }
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //get ds đề
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
        }
        catch (Exception)
        {
        }
    }

    protected void ddlDe_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get list kỹ năng của đề
        var getKyNang = from kn in db.tbTracNghiem_KyNangs
                        join c in db.tbTracNghiem_DeThis on kn.dethi_id equals c.dethi_id
                        //join gvdm in db.tbGiaoVienDayMons on mh.monhoc_id equals gvdm.monhoc_id
                        //join u in db.admin_Users on gvdm.username_id equals u.username_id
                        where c.dethi_id == Convert.ToInt32(ddlDe.SelectedValue)
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
    }

    protected void btnQuayLai_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-danh-sach-bai-luyen-tap");
    }

    protected void btnThemCauHoi_Click(object sender, EventArgs e)
    {
        var data = (from l in db.tbTracNghiem_Lessons
                    join c in db.tbTracNghiem_Chapters on l.chapter_id equals c.chapter_id
                    where c.khoi_id == _idKhoi
                    && c.monhoc_id == _idMonhoc
                    select new
                    {
                        l.lesson_id,
                        c.chapter_id,
                    }).First();
        _idChapter = data.chapter_id;
        _idLesson = data.lesson_id;

        Response.Redirect("admin-cap-nhat-cau-hoi-trac-nghiem-" + _idKhoi + "-" + _idMonhoc + "-" + _idChapter + "-" + _idLesson + "-" + _id);
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
            List<object> seclectedKey = grvList.GetSelectedFieldValues(new string[] { "question_id" });
            if (seclectedKey.Count() == 0)
            {
                alert.alert_Error(Page, "Bạn chưa chọn câu hỏi", "");
            }
            else
            {
                if (Request.Cookies["UserName"] != null)
                {
                    string[] arrList = new string[100];
                    string str_init = "";
                    string str_code = "";
                    string str_first = "";
                    bool is_link = true;
                    //xu ly chuoi url cua video youtube
                    //if (txtLink.Value != "")
                    //{
                    //    arrList = txtLink.Value.Split('=');
                    //    try
                    //    {
                    //        str_init = arrList[0];
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
                    //update BaiLuyenTap
                    //tbTracNghiem_BaiLuyenTap update = (from t in db.tbTracNghiem_Tests
                    //                                   join blt in db.tbTracNghiem_BaiLuyenTaps on t.luyentap_id equals blt.luyentap_id
                    //                                   where t.test_id == _id
                    //                                   select blt).First();

                    //update.luyentap_name = txtTenBai.Value;
                    //update.luyentap_linkvideo = str_first + str_code;
                    //update.luyentap_status = 1;
                    //update.luyentap_baitaptuluan = edtnoidung.Html;
                    //update.username_id = checkuserid.username_id;

                    tbTracNghiem_BaiThiCate update = (from t in db.tbTracNghiem_Tests
                                                      join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                                                      where t.test_id == _id
                                                      select c).First();
                    update.baithicate_name = ddlKyNang.SelectedItem.Text;
                    db.SubmitChanges();
                    //update Test
                    tbTracNghiem_Test test = (from t in db.tbTracNghiem_Tests where t.test_id == _id select t).First();
                    test.question_id = String.Join(",", seclectedKey);
                    test.username_id = checkuserid.username_id;
                    test.khoi_id = 18;
                    test.monhoc_id = Convert.ToInt16(ddlMon.SelectedValue);
                    test.lesson_id = Convert.ToInt16(ddlDe.SelectedValue);
                    test.kynang_id = ddlKyNang.SelectedValue;
                    test.test_createdate = DateTime.Now;
                    //test.luyentap_id = update.luyentap_id;
                    test.hidden = false;
                    //test.test_link = "bai-luyen-tap-chi-tiet-" + Convert.ToInt32(ddlKhoi.SelectedValue) + "/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + test.test_id + ".html";
                    //update TestDetails
                    db.SubmitChanges();
                    List<tbTracNghiem_TestDetail> list = new List<tbTracNghiem_TestDetail>();
                    foreach (var i in db.tbTracNghiem_TestDetails.ToList())
                    {
                        if (i.test_id == _id)
                            list.Add(i);
                    }
                    // xoa di data cu
                    foreach (var delete in list)
                    {
                        // db.tbTracNghiem_TestDetails.DeleteOnSubmit(delete);
                        delete.hidden = true;
                    }
                    // them lai data moi
                    foreach (var item in seclectedKey)
                    {
                        tbTracNghiem_TestDetail tdt = new tbTracNghiem_TestDetail();
                        tdt.question_id = Convert.ToInt32(item);
                        tdt.test_id = _id;
                        tdt.hidden = false;
                        db.tbTracNghiem_TestDetails.InsertOnSubmit(tdt);
                    }
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Cập nhật thành công!", "");
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