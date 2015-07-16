using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class expenses_register : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected string transportOrderItems = string.Empty;
        protected string consumptions = string.Empty;

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
                ChkAdminLevel("expenses_register_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            txtFactArriveDate.Text = model.FactArriveDate.Value.ToString("yyyy-MM-dd");
            txtFactBackTime.Text = model.BackTime.Value.ToString("yyyy-MM-dd");
            txtFactDispatchCount.Text = model.FactDispatchCount.ToString();
            txtFactWeight.Text = model.FactWeight.ToString();
            txtReceivedWeight.Text = model.FactWeight.ToString();
            txtUnloadingWeight.Text = model.FactWeight.ToString();
            txtFactCarriage.Text = model.FactCarriage.ToString();
            txtRepayment.Text = model.Advance.ToString();
            txtFactRepayment.Text = "0.00";

            BLL.Order itemBll = new BLL.Order();
            DataTable dt = itemBll.GetPrintList(0, " and A.TransportOrderId = " + model.Id + "", " order by A.Id desc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                transportOrderItems += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                transportOrderItems += "<td width=\"5%\"><input type=\"hidden\" name=\"OrderId\" value=\"" + dr["Id"].ToString() + "\"/></td>";
                transportOrderItems += "<td align=\"left\">" + dr["BillNumber"].ToString() + "</td>";
                transportOrderItems += "<td width=\"13%\">" + dr["Shipper"].ToString() + "</td>";
                transportOrderItems += "<td width=\"13%\">" + dr["Receiver"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"12%\">" + dr["GoodsName"].ToString() + "</td>";
                transportOrderItems += "<td width=\"8%\">￥<input type=\"text\" name=\"UnitPrice\" class=\"input small\" value=\"" + dr["UnitPrice"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"8%\"><input type=\"text\" name=\"Weight\" class=\"input small\" value=\"" + dr["Weight"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"8%\">￥<input type=\"text\" name=\"Freight\" value=\"" + dr["Freight"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"8%\">￥<input type=\"text\" name=\"PaidFreight\" value=\"" + dr["PaidFreight"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"8%\">￥<input type=\"text\" name=\"UnpaidFreight\" value=\"" + dr["UnpaidFreight"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "</tr>";
            }

            BLL.CostItem costItemBll = new BLL.CostItem();
            DataTable costItemDT = costItemBll.GetAllList().Tables[0];
            foreach (DataRow dr in costItemDT.Rows)
            {
                consumptions += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                consumptions += "<td width=\"5%\"><input type=\"hidden\" name=\"costItemName\" value=\"" + dr["Name"].ToString() + "\"/></td>";
                consumptions += "<td width=\"5%\">" + dr["Name"].ToString() + "</td>";
                consumptions += "<td width=\"50%\">￥<input type=\"text\" name=\"money\" class=\"input small\" value=\"0.00\"/></td>";
                consumptions += "</tr>";
            }
          
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            model.FactArriveDate = Utils.StrToDateTime(txtFactArriveDate.Text.Trim(), DateTime.Now);
            model.FactBackTime = Utils.StrToDateTime(txtFactBackTime.Text.Trim(), DateTime.Now);
            model.Repayment = Utils.StrToDecimal(txtRepayment.Text.Trim(), 0.00M);
            model.FactRepayment = Utils.StrToDecimal(txtFactRepayment.Text.Trim(), 0.00M);
            model.FactDispatchCount = Utils.StrToDecimal(txtFactDispatchCount.Text.Trim(), 0.00M);
            model.FactWeight = Utils.StrToDecimal(txtFactWeight.Text.Trim(), 0.00M);
            model.ReceivedWeight = Utils.StrToDecimal(txtReceivedWeight.Text.Trim(), 0.00M);
            model.UnloadingWeight = Utils.StrToDecimal(txtUnloadingWeight.Text.Trim(), 0.00M);
            model.FactCarriage = Utils.StrToDecimal(txtFactCarriage.Text.Trim(), 0.00M);
            model.Status = 3;

            string[] ids = Request.Params.GetValues("OrderId");
            string[] unitPrices = Request.Params.GetValues("UnitPrice");
            string[] weights = Request.Params.GetValues("Weight");
            string[] freights = Request.Params.GetValues("Freight");
            string[] paidFreights = Request.Params.GetValues("PaidFreight");
            string[] unpaidFreights = Request.Params.GetValues("UnpaidFreight");

            string[] costItemNames = Request.Params.GetValues("costItemName");
            string[] monies = Request.Params.GetValues("money");


            List<Model.Order> item_list = new List<Model.Order>();
            BLL.Order orderBLL = new BLL.Order();
            Model.Order item;

            if (ids != null && unitPrices != null && weights != null && freights != null && paidFreights != null && unpaidFreights != null
                && ids.Length == unitPrices.Length && ids.Length == weights.Length && ids.Length == freights.Length && ids.Length == paidFreights.Length && ids.Length == unpaidFreights.Length
                && ids.Length  > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    item = orderBLL.GetModel(Utils.StrToInt(ids[i], 0));
                    if (item != null)
                    {
                        item.UnitPrice = Utils.StrToDecimal(unitPrices[i], 0.00M);
                        item.Weight = Utils.StrToDecimal(weights[i], 0.00M);
                        item.Freight = Utils.StrToDecimal(freights[i], 0.00M);
                        item.PaidFreight = Utils.StrToDecimal(paidFreights[i], 0.00M);
                        item.UnpaidFreight = Utils.StrToDecimal(unpaidFreights[i], 0.00M);
                        item_list.Add(item);
                    }
                }
            }
            
            List<Model.Consumption> consumption_list = new List<Model.Consumption>();
            if (costItemNames != null && monies != null
                && costItemNames.Length == monies.Length
                && costItemNames.Length > 0)
            {
                for (int i = 0; i < costItemNames.Length; i++)
                {
                    Model.Consumption consumption = new Model.Consumption();
                    consumption.Name = costItemNames[i];
                    consumption.Money = Utils.StrToDecimal(monies[i], 0.00M);
                    consumption.TransportOrderId = _id;
                    consumption_list.Add(consumption);
                }
            }
            

            if (bll.Update(model, item_list, consumption_list))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "回车报账信息:" + model.Code); //记录日志
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
                ChkAdminLevel("expenses_register_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("回车报账成功！", "expenses_register_list.aspx", "Success");
            }
        }
    }
}