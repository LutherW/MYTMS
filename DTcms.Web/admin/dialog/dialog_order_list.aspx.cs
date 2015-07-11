﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_order_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int _goods;
        protected int _customer1;
        protected int _customer2;
        protected string _beginTime;
        protected string _endTime;
        protected string keywords = string.Empty;
        private int transportOrderId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("order_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            this.transportOrderId = DTRequest.GetQueryInt("transportOrderId");
            _goods = DTRequest.GetQueryInt("goods");
            _customer1 = DTRequest.GetQueryInt("customer1");
            _customer2 = DTRequest.GetQueryInt("customer2");
            _beginTime = DTRequest.GetQueryString("beginTime");
            _endTime = DTRequest.GetQueryString("endTime");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("TransportOrderId = " + this.transportOrderId + "" + CombSqlTxt(_goods, _customer1, _customer2, _beginTime, _endTime, this.keywords), "Id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Goods goodsBll = new BLL.Goods();
            DataTable goodsDT = goodsBll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlGoods.Items.Clear();
            ddlGoods.Items.Add(new ListItem("承运货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            BLL.Customer customerBll = new BLL.Customer();
            DataTable customerDT = customerBll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlCustomer1.Items.Clear();
            ddlCustomer1.Items.Add(new ListItem("托运方", ""));
            ddlCustomer2.Items.Clear();
            ddlCustomer2.Items.Add(new ListItem("收货方", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                if (!dr["Category"].ToString().Equals("托运方"))
                {
                    this.ddlCustomer2.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
                if (!dr["Category"].ToString().Equals("收货方"))
                {
                    this.ddlCustomer1.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (_goods > 0)
            {
                ddlGoods.SelectedValue = _goods.ToString();
            }
            if (_customer1 > 0)
            {
                ddlCustomer1.SelectedValue = _customer1.ToString();
            }
            if (_customer2 > 0)
            {
                ddlCustomer2.SelectedValue = _customer2.ToString();
            }
            if (!string.IsNullOrEmpty(_beginTime))
            {
                txtBeginTime.Text = _beginTime;
            }
            if (!string.IsNullOrEmpty(_endTime))
            {
                txtEndTime.Text = _endTime;
            }
            this.txtKeywords.Text = this.keywords;
            BLL.Order bll = new BLL.Order();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&page={6}&transportOrderId=" + this.transportOrderId + "",
                _goods.ToString(), _customer1.ToString(), _customer2.ToString(), _beginTime, _endTime, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int goods, int customer1, int customer2, string beginTime, string endTime, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (goods > 0)
            {
                strTemp.Append(" and A.GoodsId=" + goods + "");
            }
            if (customer1 > 0)
            {
                strTemp.Append(" and ShipperId=" + customer1 + "");
            }
            if (customer2 > 0)
            {
                strTemp.Append(" and ReceiverId=" + customer2 + "");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and AcceptOrderTime>='" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and AcceptOrderTime<='" + endTime + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (BillNumber like '%" + _keywords + "%' or WeighbridgeNumber like '%" + _keywords + "%' or ContractNumber like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回订单每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("order_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&transportOrderId=" + this.transportOrderId + "",
                _goods.ToString(), _customer1.ToString(), _customer2.ToString(), txtBeginTime.Text, txtEndTime.Text, txtKeywords.Text));
        }

        //筛选类别
        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&transportOrderId=" + this.transportOrderId + "",
                ddlGoods.SelectedValue, _customer1.ToString(), _customer2.ToString(), _beginTime, _endTime, this.keywords));
        }

        protected void ddlCustomer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&transportOrderId=" + this.transportOrderId + "",
                _goods.ToString(), ddlCustomer1.SelectedValue, _customer2.ToString(), _beginTime, _endTime, this.keywords));
        }

        protected void ddlCustomer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&transportOrderId=" + this.transportOrderId + "",
                _goods.ToString(), _customer1.ToString(), ddlCustomer2.SelectedValue, _beginTime, _endTime, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("order_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&keywords={3}&transportOrderId=" + this.transportOrderId + "",
                _goods.ToString(), _customer1.ToString(), _customer2.ToString(), this.keywords));
        }


        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Order bll = new BLL.Order();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除订单" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("dialog_order_list.aspx", "goods={0}&customer1={1}&customer2={2}&keywords={3}&transportOrderId=" + this.transportOrderId + "", _goods.ToString(), _customer1.ToString(), _customer2.ToString(), this.keywords), "Success");
        }

    }
}