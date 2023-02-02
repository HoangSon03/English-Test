using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ChamDiem_mudule_ThongKeKetQuaThi_A2B1 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get ds môn học của tiếng anh
            var getMonHoc = from mhck in db.tbMonHocCuaKhois
                            join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                            where mhck.khoi_id == 18 && mhck.hidden == true
                            orderby mh.monhoc_name ascending
                            select new
                            {
                                mh.monhoc_id,
                                mh.monhoc_name,
                                mhck.khoi_id
                            };

            rpMonHoc.DataSource = getMonHoc;
            rpMonHoc.DataBind();
        }
        if (txtTestId.Value != "")
        {
            loadData();
        }
    }

    protected void btnMonHoc_ServerClick(object sender, EventArgs e)
    {
        //hiện thị danh sách đề của môn học
        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.monhoc_id == Convert.ToInt32(txtMonHocId.Value)
                    && c.hidden == true //c.khoi_id == _idKhoi &&
                    select c;

        rpDanhSachDe.DataSource = getCh;
        rpDanhSachDe.DataBind();
        div_De.Visible = true;
        div_KyNang.Visible = false;
        div_KetQua.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "')", true);
    }

    protected void btnChapter_ServerClick(object sender, EventArgs e)
    {
        var getData = from t in db.tbTracNghiem_Tests
                      join c in db.tbTracNghiem_BaiThiCates
                      on t.baithicate_id equals c.baithicate_id
                      where t.lesson_id == Convert.ToInt32(txtChapterId.Value)
                      && t.hidden == false
                      select new
                      {
                          c.baithicate_id,
                          c.baithicate_name,
                          t.test_show,
                          t.monhoc_id,
                          t.test_id,
                      };
        rpKyNang.DataSource = getData;
        rpKyNang.DataBind();
        div_De.Visible = true;
        div_KyNang.Visible = true;
        div_KetQua.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "');myActiveChuong('" + txtChapterId.Value + "')", true);
    }
    private void loadData()
    {
        //get ds hs làm kỹ năng đó
        int test_id = Convert.ToInt32(txtTestId.Value);
        var getData = from bd in db.tbTracNghiem_ResultTests
                      join t in db.tbTracNghiem_Tests on bd.test_id equals t.test_id
                      join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                      where bd.test_id == test_id
                      select new
                      {
                          bd.test_id,
                          bd.resulttest_id,
                          hocsinh_name = (from hs in db.tbHocSinhs
                                          where hs.hocsinh_code == bd.hocsinh_code
                                          select hs.hocsinh_name).FirstOrDefault(),
                          bd.hocsinh_code,
                          ngaylam = bd.resulttest_datetime,
                          bd.resulttest_result,
                          sumpoint = (from rs in db.tbTracNghiem_ResultChiTiets
                                      where rs.resulttest_id == bd.resulttest_id
                                      select rs.resultchitiet_point).Sum(),
                          percent = string.Format("{0:0.0%}", (from rs in db.tbTracNghiem_ResultChiTiets
                                                               where rs.resulttest_id == bd.resulttest_id
                                                               select rs.result_phantram).Sum() / 100 ?? 0),
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
        //rpKetQuaLamBai.DataSource = getData;
        //rpKetQuaLamBai.DataBind();
        div_KetQua.Visible = true;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "');myActiveChuong('" + txtChapterId.Value + "');myActive('" + txtTestId.Value + "')", true);
    }
    protected void btnChiTiet_ServerClick(object sender, EventArgs e)
    {
        //get ds hs làm kỹ năng đó
        int test_id = Convert.ToInt32(txtTestId.Value);
        var getData = from bd in db.tbTracNghiem_ResultTests
                      join t in db.tbTracNghiem_Tests on bd.test_id equals t.test_id
                      join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                      where bd.test_id == test_id
                      select new
                      {
                          bd.test_id,
                          bd.resulttest_id,
                          hocsinh_name = (from hs in db.tbHocSinhs
                                          where hs.hocsinh_code == bd.hocsinh_code
                                          select hs.hocsinh_name).FirstOrDefault(),
                          bd.hocsinh_code,
                          ngaylam = bd.resulttest_datetime,
                          bd.resulttest_result,
                          sumpoint = (from rs in db.tbTracNghiem_ResultChiTiets
                                      where rs.resulttest_id == bd.resulttest_id
                                      select rs.resultchitiet_point).Sum(),
                          percent = string.Format("{0:0.0%}", (from rs in db.tbTracNghiem_ResultChiTiets
                                                               where rs.resulttest_id == bd.resulttest_id
                                                               select rs.result_phantram).Sum() / 100 ?? 0),
                          //percent = Convert.ToString(bd.resulttest_result).Split('/')[1]+"",
                          //percent = (from rs in db.tbTracNghiem_ResultChiTiets
                          //           where rs.resulttest_id == bd.resulttest_id
                          //           select rs.result_phantram).Sum(),
                          // String.Format("{0:#,0.##} {1}", Convert.ToDouble(p.prNewPrice.ToString()), "VND"),
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
        //rpKetQuaLamBai.DataSource = getData;s
        //rpKetQuaLamBai.DataBind();
        div_KetQua.Visible = true;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "');myActiveChuong('" + txtChapterId.Value + "');myActive('" + txtTestId.Value + "')", true);
    }


    protected void btnShowResult_ServerClick(object sender, EventArgs e)
    {
        //get chi tiết bài làm của hs
        int resulttest_id = Convert.ToInt32(txtResultId.Value);
        var checkDangBai = (from rt in db.tbTracNghiem_ResultTests
                            join t in db.tbTracNghiem_Tests on rt.test_id equals t.test_id
                            join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                            where rt.resulttest_id == resulttest_id
                            select cate).FirstOrDefault();
        if (txtMonHocId.Value == "74")
        {
            if (checkDangBai.baithicate_name.ToLower().Contains("reading") || checkDangBai.baithicate_name.ToLower().Contains("writing"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == resulttest_id && ctkq.answer_true_id != null
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where Convert.ToString(ans.answer_id) == ctkq.answer_checked_id
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                    ctkq.resultchitiet_point
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == resulttest_id && rs.question_id == null
                               select new
                               {
                                   result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                                   rs.resultchitiet_point
                               };
                //get phần writing
                var getPart3 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == resulttest_id && ctkq.answer_true_id == null
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content,
                                    content_dapandung = "",
                                    content_dapanchon = ctkq.answer_checked_id,
                                    ctkq.result_part,
                                    //ctkq.resultchitiet_id,
                                    ctkq.resultchitiet_point
                                });
                var result = getPart1.Union(getPart2);
                var result1 = result.Union(getPart3);
                rpChiTiet.DataSource = result1.OrderBy(x => x.result_part);
                rpChiTiet.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("listening"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == resulttest_id && ctkq.answer_true_id != null
                                select new
                                {
                                    //result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where Convert.ToString(ans.answer_id) == ctkq.answer_checked_id
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                    ctkq.resultchitiet_id,
                                    ctkq.resultchitiet_point
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == resulttest_id && rs.question_id == null
                               select new
                               {
                                   //result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                                   rs.resultchitiet_id,
                                   rs.resultchitiet_point
                               };
                var result = getPart1.Union(getPart2);
                rpChiTiet.DataSource = result.OrderBy(x => x.result_part);
                rpChiTiet.DataBind();
            }
            else //speaking
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == resulttest_id
                                     select new
                                     {
                                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                              select ans.answer_content).SingleOrDefault(),
                                         content_dapanchon = " <audio controls> <source src = '" + ctkq.answer_checked_id + "'> </audio>",
                                         ctkq.resultchitiet_id,
                                         ctkq.resultchitiet_point
                                     };
                rpChiTiet.DataSource = getDataDetails;
                rpChiTiet.DataBind();
            }
        }
        else
        {
            if (checkDangBai.baithicate_name.ToLower().Contains("writing"))
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == resulttest_id
                                     select new
                                     {
                                         //STTs = STTs + 1,
                                         //noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         noidungcauhoi = "<div class='tracnghiem-answer__image'>" + ch.englishquestion_content + "</div>",
                                         content_dapandung = "",
                                         content_dapanchon = ctkq.answer_checked_id,
                                         ctkq.resultchitiet_id,
                                         ctkq.resultchitiet_point,
                                     };
                rpChiTiet.DataSource = getDataDetails;
                rpChiTiet.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("speaking"))
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == resulttest_id
                                     select new
                                     {
                                         //STTs = STTs + 1,
                                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                              select ans.answer_content).SingleOrDefault(),
                                         content_dapanchon = " <audio controls> <source src = '" + ctkq.answer_checked_id + "'> </audio>",
                                         ctkq.resultchitiet_id,
                                         ctkq.resultchitiet_point,
                                     };
                rpChiTiet.DataSource = getDataDetails;
                rpChiTiet.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("reading") || checkDangBai.baithicate_name.ToLower().Contains("listening"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == resulttest_id
                                select new
                                {

                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                    ctkq.resultchitiet_id,
                                    ctkq.resultchitiet_point
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == resulttest_id && rs.question_id == null
                               select new
                               {
                                   //result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                                   rs.resultchitiet_id,
                                   rs.resultchitiet_point
                               };
                //var getPart3= (from ctkq in db.tbTracNghiem_ResultChiTiets
                //               join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                //               where ctkq.resulttest_id == listChecked
                //               select new
                //               {
                //                   //STTs = STTs + 1,
                //                   result_id = ctkq.resultchitiet_id,
                //                   noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                //                   content_dapandung = (from ans in db.tbTracNghiem_Answers
                //                                        where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                //                                        select ans.answer_content).SingleOrDefault(),
                //                   content_dapanchon = (from ans in db.tbTracNghiem_Answers
                //                                        where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                //                                        select ans.answer_content).SingleOrDefault()
                //               }).Skip(5).Take(5);
                var result = getPart1.Union(getPart2);
                //var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                //                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                //                     where ctkq.resulttest_id == listChecked
                //                     select new
                //                     {
                //                         STTs = STTs + 1,
                //                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                //                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                //                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                //                                              select ans.answer_content).SingleOrDefault(),
                //                         content_dapanchon = (from ans in db.tbTracNghiem_Answers
                //                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                //                                              select ans.answer_content).SingleOrDefault()
                //                     };
                rpChiTiet.DataSource = result.OrderBy(x => x.result_part);
                rpChiTiet.DataBind();
            }
        }
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }

    protected void btnLuuDiem_Click(object sender, EventArgs e)
    {

    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        //alert.alert_Error(Page, txtDanhSachDiem.Value + "," + txtDanhSachId.Value, "");
        try
        {
            string[] arr_ID = txtDanhSachId.Value.Split(',');
            string[] arr_Point = txtDanhSachDiem.Value.Split(',');
            for (int i = 0; i < arr_ID.Length; i++)
            {
                tbTracNghiem_ResultChiTiet update = (from rs in db.tbTracNghiem_ResultChiTiets
                                                     where rs.resultchitiet_id == Convert.ToInt32(arr_ID[i])
                                                     select rs).FirstOrDefault();
                update.resultchitiet_point = Convert.ToDouble(arr_Point[i]);
                db.SubmitChanges();
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Lưu thành công!','','success').then(function(){popupControl.Hide();})", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myActiveMon('" + txtMonHocId.Value + "');myActiveChuong('" + txtChapterId.Value + "');myActive('" + txtTestId.Value + "')", true);
        }
        catch (Exception ex)
        {
            alert.alert_Error(Page, "Đã xảy ra lỗi trong quá trình!", "");
        }
    }
}