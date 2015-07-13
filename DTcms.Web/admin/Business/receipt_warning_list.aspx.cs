using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class receipt_warning_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string _carNumber;
        protected string _customer1;
        protected string _customer2;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("receipt_register_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            _carNumber = DTRequest.GetQueryString("carNumber");
            _customer1 = DTRequest.GetQueryString("customer1");
            _customer2 = DTRequest.GetQueryString("customer2");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量


            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("Status = 2 AND WarningTime <= '" + DateTime.Now.ToString() + "' " + CombSqlTxt(_carNumber, _customer1, _customer2, this.keywords), "WarningTime asc,Id desc");
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
            string pageUrl = Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&keywords={3}&page={4}",
                _carNumber, _customer1, _customer2, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string carNumber, string customer1, string customer2, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(carNumber))
            {
                strTemp.Append(" and B.CarNumber='" + carNumber + "'");
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
            if (int.TryParse(Utils.GetCookie("receipt_register_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&keywords={3}",
                _carNumber, _customer1, _customer2, txtKeywords.Text));
        }

        //筛选类别
        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&keywords={3}",
                ddlDriver.SelectedValue, _customer1, _customer2, keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("receipt_register_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&keywords={3}",
                _carNumber, _customer1, _customer2, this.keywords));
        }
    }
}