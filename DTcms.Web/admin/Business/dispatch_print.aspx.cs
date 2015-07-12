using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class dispatch_print : Web.UI.ManagePage
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
            
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            labCode.Text = model.Code;
            labFactDispatchTime.Text = model.FactDispatchTime.ToString("yyyy-MM-dd");
            Model.Driver driver = new BLL.Driver().GetModel(model.DriverId);
            if (driver != null)
            {
                labDriver.Text = driver.RealName;
                labLinkTel.Text = driver.LinkTel;
                labCarNumber.Text = driver.CarNumber;
            }
            labPayee.Text = model.Payee;
            labAdvance.Text = model.Advance.ToString();

            BLL.Order itemBll = new BLL.Order();
            DataTable dt = itemBll.GetPrintList(0, " and A.TransportOrderId = " + model.Id + "", " order by A.Id desc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                transportOrderItems += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                transportOrderItems += "<td></td>";
                transportOrderItems += "<td align=\"left\">" + dr["Code"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["BillNumber"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["WeighbridgeNumber"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Shipper"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Receiver"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["GoodsName"].ToString() + "</td>";
                transportOrderItems += "<td width=\"6%\">" + dr["Quantity"].ToString() + "</td>";
                transportOrderItems += "<td width=\"5%\">" + dr["Weight"].ToString() + "</td>";
                transportOrderItems += "<td width=\"5%\">￥" +string.Format("{0:N2}", dr["UnitPrice"].ToString())+ "</td>";
                transportOrderItems += "<td width=\"5%\">￥" + string.Format("{0:N2}", dr["Freight"].ToString()) + "</td>";
                transportOrderItems += "<td width=\"5%\">￥" + string.Format("{0:N2}", dr["HandlingCharge"].ToString()) + "</td>";
                transportOrderItems += "</tr>";
            }
          
        }
        #endregion
    }
}