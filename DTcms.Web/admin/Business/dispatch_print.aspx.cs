﻿using System;
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
            labFactDispatchTime.Text = model.FactDispatchTime.Value.ToString("yyyy-MM-dd");
            labMotorcadeName.Text = model.MotorcadeName;
            labCarNumber.Text = model.CarNumber;
            labDriver.Text = model.Driver;
            labPayee.Text = model.Payee;
            labAdvance.Text = model.Advance.ToString();

            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
            DataTable dt = itemBll.GetList(" TransportOrderId = " + model.Id + "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                transportOrderItems += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                transportOrderItems += "<td></td>";
                transportOrderItems += "<td align=\"left\">" + dr["OrderCode"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["BillNumber"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Shipper"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Receiver"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Goods"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"9%\" align=\"center\">" + dr["Unit"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"6%\">" + dr["DispatchCount"].ToString() + "</td>";
                transportOrderItems += "<td width=\"5%\">" + dr["FactDispatchCount"].ToString() + "</td>";
                transportOrderItems += "<td width=\"5%\">￥" +string.Format("{0:N2}", dr["UnitPrice"].ToString())+ "</td>";
                transportOrderItems += "<td width=\"5%\">￥" + string.Format("{0:N2}",dr["TotalPrice"].ToString())  + "</td>";
                transportOrderItems += "</tr>";
            }
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            //model.FactDispatchTime = Utils.StrToDateTime(txtFactDispatchTime.Text.Trim(), DateTime.Now);
            //model.Advance = Utils.StrToDecimal(txtAdvance.Text.Trim(), 0.00M);
            model.AddTime = DateTime.Now;
            model.Status = 1;

            string[] itemIds = Request.Params.GetValues("transportOrderItemId");
            string[] factDispatchCounts = Request.Params.GetValues("factDispatchCount");

            
            List<Model.TransportOrderItem> item_list = new List<Model.TransportOrderItem>();
            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();

            for (int i = 0; i < itemIds.Length; i++)
            {
                Model.TransportOrderItem item = itemBll.GetModel(Utils.StrToInt(itemIds[i], 0));
                if (item != null)
                {
                    item.FactDispatchCount = Utils.StrToDecimal(factDispatchCounts[i], item.FactDispatchCount);
                    item_list.Add(item);
                }
            }

            if (bll.Update(model,item_list))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "登记出车信息:" + model.Code); //记录日志
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
                JscriptMsg("修改运输单成功！", "dispatch_register_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("dispatch_register_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加运输单成功！", "dispatch_register_list.aspx", "Success");
            }
        }
    }
}