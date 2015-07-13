using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.GainAnalysis
{
    public partial class total_gain_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string _carNumber;
        protected string _beginTime;
        protected string _endTime;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("total_gain_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            _carNumber = DTRequest.GetQueryString("carNumber");
            _beginTime = DTRequest.GetQueryString("beginTime");
            _endTime = DTRequest.GetQueryString("endTime");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("A.Status >= 2" + CombSqlTxt(_carNumber, _beginTime, _endTime, this.keywords), "FactDispatchTime desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Driver driverBll = new BLL.Driver();
            DataTable driverDT = driverBll.GetList(0, "IsDimission != 1 ", "Id desc").Tables[0];

            ddlDriver.Items.Clear();
            ddlDriver.Items.Add(new ListItem("不限", ""));
            foreach (DataRow dr in driverDT.Rows)
            {
                this.ddlDriver.Items.Add(new ListItem(string.Format("{0}({1})", dr["CarNumber"].ToString(), dr["RealName"].ToString()), dr["CarNumber"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (!string.IsNullOrEmpty(_carNumber))
            {
                ddlDriver.SelectedValue = _carNumber;
            }
            //if (!string.IsNullOrEmpty(_beginTime))
            //{
            //    txtBeginTime.Text = _beginTime;
            //}
            //if (!string.IsNullOrEmpty(_endTime))
            //{
            //    txtEndTime.Text = _endTime;
            //}
            this.txtKeywords.Text = this.keywords;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("total_gain_list.aspx", "carNumber={0}&beginTime={1}&endTime={2}&keywords={3}&page={4}",
                _carNumber, _beginTime, _endTime, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        protected decimal GetOrderTotalPrice(string transportOrderId)
        {
            return new BLL.Order().GetTotalPrice(Convert.ToInt32(transportOrderId));
        }

        protected decimal GetTotalConsumption(string transportOrderId)
        {
            decimal totalCost = 0.00M;
            BLL.Consumption consumptionBll = new BLL.Consumption();
            DataSet consumptionDS = consumptionBll.GetList(0, "TransportOrderId = " + transportOrderId + "", "Money");
            if (consumptionDS != null && consumptionDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in consumptionDS.Tables[0].Rows)
                {
                    totalCost += Utils.StrToDecimal(dr["Money"].ToString(), 0.00M);
                }
            }

            return totalCost;
        }

        protected string GetTotal(string transportOrderId, string advance, string factRepayment, string factCarriage) 
        {
            decimal orderTotal = GetOrderTotalPrice(transportOrderId);
            decimal totalCost = GetTotalConsumption(transportOrderId);
            string html = string.Format("<td align=\"center\">￥{0}</td><td align=\"center\">￥{1}</td><td align=\"center\">￥{2}</td>",
                string.Format("{0:N2}", orderTotal),
                string.Format("<a href=\"javascript:void(0);\" onclick=\"showCost(" + transportOrderId + ");\">{0:N2}</a>", totalCost),
                string.Format("{0:N2}", (orderTotal - totalCost - Convert.ToDecimal(factCarriage) - Convert.ToDecimal(advance) + Convert.ToDecimal(factRepayment))));

            return html;
        }

        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string carNumber, string beginTime, string endTime, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(carNumber))
            {
                strTemp.Append(" and B.CarNumber='" + carNumber + "'");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and A.FactDispatchTime>='" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and A.FactDispatchTime<='" + endTime + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (A.CustomerRemarks like '%" + _keywords + "%' or A.HaulwayRemarks like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回运输单每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("total_gain_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("total_gain_list.aspx", "carNumber={0}&beginTime={1}&endTime={2}&keywords={3}",
                _carNumber, _beginTime, _endTime, txtKeywords.Text));
        }

        //筛选类别
        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("total_gain_list.aspx", "carNumber={0}&beginTime={1}&endTime={2}&keywords={3}",
                ddlDriver.SelectedValue, _beginTime, _endTime, keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("total_gain_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("total_gain_list.aspx", "carNumber={0}&beginTime={1}&endTime={2}&keywords={3}",
                _carNumber, _beginTime, _endTime, this.keywords));
        }

        protected string GetStatus(string status)
        {
            string strStatus = string.Empty;
            switch (status)
            {
                case "0":
                    strStatus = "待发车";
                    break;
                case "1":
                    strStatus = "已发车";
                    break;
                case "2":
                    strStatus = "已报账";
                    break;
                case "3":
                    strStatus = "已完成";
                    break;
                default:
                    break;
            }

            return strStatus;
        }


    }
}