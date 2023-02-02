using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_MonHoc_module_QuanLyMonHocCuaKhoi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var getmon = from mh in db.tbMonHocs
                         select mh;
            ddlkhoi.Items.Clear();
            ddlkhoi.AppendDataBoundItems = true;
            ddlkhoi.Items.Insert(0, "Chọn môn học");
            ddlkhoi.DataValueField = "monhoc_id";
            ddlkhoi.DataTextField = "monhoc_name";
            ddlkhoi.DataSource = getmon;
            ddlkhoi.DataBind();
        }
        //if (!IsPostBack)
        //{
        //    var khoi = from k in db.tbKhois
        //               where k.khoi_id <= 12
        //               select k;
        //    ddlkhoi.Items.Clear();
        //    ddlkhoi.AppendDataBoundItems = true;
        //    ddlkhoi.Items.Insert(0, "Chọn khối");
        //    ddlkhoi.DataValueField = "khoi_id";
        //    ddlkhoi.DataTextField = "khoi_name";
        //    ddlkhoi.DataSource = khoi;
        //    ddlkhoi.DataBind();
        //}
        //loadData();
        //loaddatadachon();
    }
    protected void loadData()
    {
        //if (ddlkhoi.SelectedValue != "Chọn khối")
        //{
        //    var getMon = from gm in db.tbMonHocs
        //                 select gm;
        //    var getdataChon = from gm in db.tbMonHocs
        //                      join mhck in db.tbMonHocCuaKhois on gm.monhoc_id equals mhck.monhoc_id
        //                      where gm.monhoc_id == mhck.monhoc_id &&
        //                      mhck.khoi_id == Convert.ToInt32(ddlkhoi.SelectedValue)
        //                      select gm;
        //    var MS = getMon.Except(getdataChon).ToList();
        //    grvList.DataSource = MS;
        //    grvList.DataBind();
        //}
    }
    protected void loaddatadachon()
    {
        //if (ddlkhoi.SelectedValue != "Chọn khối")
        //{

        //    var getdataChon = from gm in db.tbMonHocs
        //                      join mhck in db.tbMonHocCuaKhois on gm.monhoc_id equals mhck.monhoc_id
        //                      where gm.monhoc_id == mhck.monhoc_id &&
        //                      mhck.khoi_id == Convert.ToInt32(ddlkhoi.SelectedValue)
        //                      select gm;
        //    grvListDaChon.DataSource = getdataChon;
        //    grvListDaChon.DataBind();
        //}
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        tbMonHocCuaKhoi mhck = new tbMonHocCuaKhoi();
        mhck.monhoc_id = Convert.ToInt32(ddlkhoi.SelectedValue);
        mhck.khoi_id = Convert.ToInt32(RouteData.Values["khoi_id"]);
        mhck.hidden = false;
        db.tbMonHocCuaKhois.InsertOnSubmit(mhck);
        db.SubmitChanges();
        Response.Redirect("/admin-home");
        //if (ddlkhoi.SelectedValue == "Chọn khối")
        //{
        //    alert.alert_Error(Page, "Bạn chưa chọn khối", "");
        //}
        //else
        //{
        //    //List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "monhoc_id" });
        //    if (selectedKey.Count > 0)
        //    {

        //        foreach (var item in selectedKey)
        //        {
        //            var check = from ck in db.tbMonHocCuaKhois
        //                        where ck.monhoc_id == Convert.ToInt32(item) &&
        //                        ck.khoi_id == Convert.ToInt32(ddlkhoi.SelectedValue)
        //                        select ck;
        //            if (check.Count() == 0)
        //            {
        //                tbMonHocCuaKhoi luu = new tbMonHocCuaKhoi();
        //                luu.monhoc_id = Convert.ToInt32(item);
        //                luu.khoi_id = Convert.ToInt32(ddlkhoi.SelectedValue);
        //                db.tbMonHocCuaKhois.InsertOnSubmit(luu);
        //                db.SubmitChanges();
        //                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Lưu thành công!', '','success').then(function(){grvList.UnselectRows();grvListDaChon.UnselectRows();})", true);
        //                loaddatadachon();
        //                loadData();
        //            }
        //            else
        //            {
        //                alert.alert_Error(Page, "Môn đã tồn tại", "");
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        alert.alert_Warning(Page, "Vui lòng chọn môn", "");
        //    }
        //}
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        //List<object> selectedKey = grvListDaChon.GetSelectedFieldValues(new string[] { "monhoc_id" });
        //if (selectedKey.Count() > 0 )
        //{
        //    foreach (var item in selectedKey)
        //    {
        //        var getdataXoa = (from x in db.tbMonHocCuaKhois
        //                          where x.monhoc_id == Convert.ToInt32(item)
        //                          && x.khoi_id == Convert.ToInt32(ddlkhoi.SelectedValue)
        //                          select x).SingleOrDefault();
        //        db.tbMonHocCuaKhois.DeleteOnSubmit(getdataXoa);
        //        db.SubmitChanges();
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Xóa thành công!', '','success').then(function(){grvList.UnselectRows();grvListDaChon.UnselectRows();})", true);
        //        loaddatadachon();
        //        loadData();
        //    }
        //}
        //else
        //{
        //    alert.alert_Error(Page, "Vui lòng chọn môn", "");
        //}
    }
}
