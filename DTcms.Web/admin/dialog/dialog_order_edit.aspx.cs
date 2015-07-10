using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_order_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int transportOrderId = 0;

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
                if (!new BLL.Order().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Add.ToString())
            {
                this.action = DTEnums.ActionEnum.Add.ToString();//修改类型
                this.transportOrderId = DTRequest.GetQueryInt("transportOrderId");
                if (this.transportOrderId == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.Haulway haulwayBll = new BLL.Haulway();
            DataTable haulwayDT = haulwayBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlHaulway.Items.Clear();
            ddlHaulway.Items.Add(new ListItem("请选择运输路线", ""));
            foreach (DataRow dr in haulwayDT.Rows)
            {
                this.ddlHaulway.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.Customer customerBll = new BLL.Customer();
            DataTable customerDT = customerBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlShipper.Items.Clear();
            ddlShipper.Items.Add(new ListItem("请选择托运方", ""));
            ddlReceiver.Items.Clear();
            ddlReceiver.Items.Add(new ListItem("请选择收货方", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                if (!dr["Category"].ToString().Equals("托运方"))
                {
                    this.ddlReceiver.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
                if (!dr["Category"].ToString().Equals("收货方"))
                {
                    this.ddlShipper.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
            }

            BLL.Address addressBll = new BLL.Address();
            DataTable addressDT = addressBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlLoadingAddress.Items.Clear();
            ddlLoadingAddress.Items.Add(new ListItem("请选择装货地址", ""));
            ddlUnloadingAddress.Items.Clear();
            ddlUnloadingAddress.Items.Add(new ListItem("请选择卸货地址", ""));
            foreach (DataRow dr in addressDT.Rows)
            {
                if (!dr["CategoryName"].ToString().Equals("卸货地址"))
                {
                    this.ddlLoadingAddress.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
                if (!dr["CategoryName"].ToString().Equals("装货地址"))
                {
                    this.ddlUnloadingAddress.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
            }

            BLL.Goods goodsBll = new BLL.Goods();
            DataTable goodsDT = goodsBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlGoods.Items.Clear();
            ddlGoods.Items.Add(new ListItem("请选择承运货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }

        protected void ddlHaulway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlHaulway.SelectedValue))
            {
                BLL.Haulway haulwayBll = new BLL.Haulway();
                Model.Haulway haulway = haulwayBll.GetModel(Convert.ToInt32(ddlHaulway.SelectedValue));
                if (haulway != null)
                {
                    txtLoadingCapacityRunning.Text = haulway.LoadingCapacityRunning.ToString();
                    txtNoLoadingCapacityRunning.Text = haulway.NoLoadingCapacityRunning.ToString();
                }
            }
        }

        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlGoods.SelectedValue))
            {
                BLL.Goods bll = new BLL.Goods();
                Model.Goods m = bll.GetModel(Convert.ToInt32(ddlGoods.SelectedValue));
                if (m != null)
                {
                    txtUnit.Text = m.Unit;
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Order bll = new BLL.Order();
            Model.Order model = bll.GetModel(_id);

            txtAcceptOrderTime.Text = model.AcceptOrderTime.ToString("yyyy-MM-dd");
            txtArrivedTime.Text = model.ArrivedTime.ToString("yyyy-MM-dd");
            txtContractNumber.Text = model.ContractNumber;
            txtBillNumber.Text = model.BillNumber;
            txtWeighbridgeNumber.Text = model.WeighbridgeNumber;
            txtQuantity.Text = model.Quantity.ToString();
            chkIsCharteredCar.Checked = model.IsCharteredCar == 1;
            chkIsWeightNote.Checked = model.IsWeightNote;
            chkIsAllotted.Checked = model.IsAllotted;
            txtUnitPrice.Text = model.UnitPrice.ToString();
            txtWeight.Text = model.Weight.ToString();
            txtFreight.Text = model.Freight.ToString();
            txtPaidFreight.Text = model.Freight.ToString();
            txtUnpaidFreight.Text = model.Freight.ToString();
            txtHandlingCharge.Text = model.HandlingCharge.ToString();


            if (!string.IsNullOrEmpty(model.Haulway))
            {
                ddlHaulway.Items.FindByText(model.Haulway).Selected = true;
            }
            txtLoadingCapacityRunning.Text = model.LoadingCapacityRunning.ToString();
            txtNoLoadingCapacityRunning.Text = model.NoLoadingCapacityRunning.ToString();
            
            
            if (!string.IsNullOrEmpty(model.LoadingAddress))
            {
                ddlLoadingAddress.Items.FindByText(model.LoadingAddress).Selected = true;
            }
            if (!string.IsNullOrEmpty(model.UnloadingAddress))
            {
                ddlUnloadingAddress.Items.FindByText(model.UnloadingAddress).Selected = true;
            }

            txtRemarks.Text = model.Remarks;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Order model = new Model.Order();
            BLL.Order bll = new BLL.Order();

            model.Code = string.Format("No{0}", DateTime.Now.ToString("yyyyMMddhhmmss"));
            model.AcceptOrderTime = Convert.ToDateTime(txtAcceptOrderTime.Text.Trim());
            model.ArrivedTime = Convert.ToDateTime(txtArrivedTime.Text.Trim());
            model.ContractNumber = txtContractNumber.Text.Trim();
            model.LoadingAddress = ddlLoadingAddress.SelectedItem.Text;
            model.UnloadingAddress = ddlUnloadingAddress.SelectedItem.Text;
            model.IsCharteredCar = chkIsCharteredCar.Checked ? 1 : 0;
            model.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
            model.DispatchedCount = 0.00M;
            model.Haulway = ddlHaulway.SelectedItem.Text;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text.Trim());
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text.Trim());
            model.BillNumber = txtBillNumber.Text.Trim();
            model.WeighbridgeNumber = txtWeighbridgeNumber.Text.Trim();
            //model.Formula = ddlFormula.SelectedItem.Text;
            //model.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            //model.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text.Trim());
            //model.SettleAccountsWay = ddlSettleAccountsWay.SelectedValue;
            model.Status = 0;
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加订单:" + model.Code); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Order bll = new BLL.Order();
            Model.Order model = bll.GetModel(_id);

            model.AcceptOrderTime = Convert.ToDateTime(txtAcceptOrderTime.Text.Trim());
            model.ArrivedTime = Convert.ToDateTime(txtArrivedTime.Text.Trim());
            model.ContractNumber = txtContractNumber.Text.Trim();
            model.LoadingAddress = ddlLoadingAddress.SelectedItem.Text;
            model.UnloadingAddress = ddlUnloadingAddress.SelectedItem.Text;
            model.IsCharteredCar = chkIsCharteredCar.Checked ? 1 : 0;
            model.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
            model.Haulway = ddlHaulway.SelectedItem.Text;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text.Trim());
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text.Trim());
            model.BillNumber = txtBillNumber.Text.Trim();
            model.WeighbridgeNumber = txtWeighbridgeNumber.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改订单信息:" + model.Code); //记录日志
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
                ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改订单成功！", "order_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("order_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加订单成功！", "order_list.aspx", "Success");
            }
        }
    }
}