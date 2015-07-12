using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class dispatch_register : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected string transportOrderItems = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.TransportOrder().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("dispatch_register_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(""); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Driver driverBll = new BLL.Driver();
            DataTable driverDT = driverBll.GetList(0, "IsDimission != 1 ", "Id desc").Tables[0];

            ddlDriver.Items.Clear();
            ddlDriver.Items.Add(new ListItem("请选择司机", ""));
            foreach (DataRow dr in driverDT.Rows)
            {
                this.ddlDriver.Items.Add(new ListItem(string.Format("{0}({1})", dr["CarNumber"].ToString(), dr["RealName"].ToString()), dr["Id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            ddlDriver.SelectedValue = model.DriverId.ToString();
            txtFactDispatchTime.Text = model.DispatchTime.ToString("yyyy-MM-dd");
            txtFactDispatchCount.Text = model.DispatchCount.ToString();
            txtFactWeight.Text = model.Weight.ToString();
            txtLoadingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtPayee.Text = GetDriverName(model.DriverId);
        }

        private string GetDriverName(int driverId) 
        {
            Model.Driver driver = new BLL.Driver().GetModel(driverId);
            if (driver != null)
            {
                return driver.RealName;
            }

            return "";
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            model.FactDispatchTime = Utils.StrToDateTime(txtFactDispatchTime.Text.Trim(), DateTime.Now);
            model.FactDispatchCount = Utils.StrToDecimal(txtFactDispatchCount.Text.Trim(), 0.00M);
            model.FactWeight = Utils.StrToDecimal(txtFactWeight.Text.Trim(), 0.00M);
            model.LoadingDate = Utils.StrToDateTime(txtLoadingDate.Text.Trim(), DateTime.Now); 
            model.Advance = Utils.StrToDecimal(txtAdvance.Text.Trim(), 0.00M);
            model.Payee = txtPayee.Text.Trim();
            model.ArriveDate = Utils.StrToDateTime(txtArriveDate.Text.Trim(), DateTime.Now); 
            model.Status = 1;

            if (bll.Update(model))
            {
                result = true; 
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("dispatch_register_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("出车登记成功！", "dispatch_register_list.aspx", "Success");
            }
        }
    }
}