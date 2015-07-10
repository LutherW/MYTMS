using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class transportOrder_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

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
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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

            txtDispatchTime.Text = model.DispatchTime.ToString("yyyy-MM-dd");
            ddlDriver.SelectedValue = model.DriverId.ToString();
            txtCustomerRemarks.Text = model.CustomerRemarks;
            txtHaulwayRemarks.Text = model.HaulwayRemarks;
            txtDispatchCount.Text = model.DispatchCount.ToString();
            txtWeight.Text = model.Weight.ToString();
            txtCarriageUnitPrice.Text = model.CarriageUnitPrice.ToString();
            txtCarriage.Text = model.Carriage.ToString();
            txtLoadingCapacityRunning.Text = model.LoadingCapacityRunning.ToString();
            txtNoLoadingCapacityRunning.Text = model.NoLoadingCapacityRunning.ToString();
            txtRemarks.Text = model.Remarks;

         
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.TransportOrder model = new Model.TransportOrder();
            BLL.TransportOrder bll = new BLL.TransportOrder();

            model.Code = "No" + DateTime.Now.ToString("yyyyMMddhhmmss");
            model.DispatchTime = Convert.ToDateTime(txtDispatchTime.Text.Trim());
            model.FactDispatchTime = model.DispatchTime;
            model.DriverId = Convert.ToInt32(ddlDriver.SelectedValue);
            model.CustomerRemarks = txtCustomerRemarks.Text;
            model.HaulwayRemarks = txtHaulwayRemarks.Text;
            model.DispatchCount = Convert.ToDecimal(txtDispatchCount.Text);
            model.FactDispatchCount = model.DispatchCount;
            model.Weight = Convert.ToDecimal(txtWeight.Text);
            model.FactWeight = model.Weight;
            model.FactTotalPrice = model.TotalPrice;
            model.CarriageUnitPrice = Convert.ToDecimal(txtCarriageUnitPrice.Text);
            model.Carriage = Convert.ToDecimal(txtCarriage.Text);
            model.FactCarriage = model.Carriage;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text);
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text);
            model.Remarks = txtRemarks.Text.Trim();
            model.AddTime = DateTime.Now;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加运输单:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            model.DispatchTime = Convert.ToDateTime(txtDispatchTime.Text.Trim());
            model.FactDispatchTime = model.DispatchTime;
            model.DriverId = Convert.ToInt32(ddlDriver.SelectedValue);
            model.CustomerRemarks = txtCustomerRemarks.Text;
            model.HaulwayRemarks = txtHaulwayRemarks.Text;
            model.DispatchCount = Convert.ToDecimal(txtDispatchCount.Text);
            model.FactDispatchCount = model.DispatchCount;
            model.Weight = Convert.ToDecimal(txtWeight.Text);
            model.FactWeight = model.Weight;
            model.FactTotalPrice = model.TotalPrice;
            model.CarriageUnitPrice = Convert.ToDecimal(txtCarriageUnitPrice.Text);
            model.Carriage = Convert.ToDecimal(txtCarriage.Text);
            model.FactCarriage = model.Carriage;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text);
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text);
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改运输单信息:" + model.Id); //记录日志
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
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改运输单成功！", "transportOrder_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加运输单成功！", "transportOrder_list.aspx", "Success");
            }
        }
    }
}