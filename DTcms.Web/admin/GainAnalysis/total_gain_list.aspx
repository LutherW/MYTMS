<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="total_gain_list.aspx.cs" Inherits="DTcms.Web.admin.GainAnalysis.total_gain_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>单车利润统计</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function showCost(id) {
            var dialog = $.dialog({
                title: '收费项',
                content: 'url:dialog/dialog_cost_list.aspx?id=' + id,
                min: false,
                max: false,
                lock: true,
                width: 700
            });
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>单车利润统计</span>
            <i class="arrow"></i>
            <span>单车利润统计列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <div class="menu-list">
                        <span style="font-size:12px;">
                            车号:
                        </span>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlDriver" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="1%"></th>
                        <th align="left">单据编号</th>
                        <th align="left">发车日期</th>
                        <th align="left">回车日期</th>
                        <th width="8%">车号</th>
                        <th width="8%">司机</th>
                        <th width="7%">出车支款</th>
                        <th width="7%">实交还款</th>
                        <th width="8%">司机运费</th>
                        <th width="8%">厂结运费</th>
                        <th width="8%">总路费</th>
                        <th width="8%">利润</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                    </td>
                    <td><%#Eval("Code")%></td>
                    <td><%#Convert.ToDateTime(Eval("FactDispatchTime")).ToString("yyyy/MM/dd")%></td>
                    <td><%#string.IsNullOrEmpty(Eval("FactBackTime").ToString()) ? "--" : Convert.ToDateTime(Eval("FactBackTime")).ToString("yyyy/MM/dd")%></td>
                    <td align="center"><%#Eval("CarNumber")%></td>
                    <td align="center"><%#Eval("Driver")%></td>
                    <td align="center">￥<%#string.Format("{0:N2}", Eval("Advance"))%></td>
                    <td align="center">￥<%#string.Format("{0:N2}", Eval("FactRepayment"))%></td>
                    <td align="center">￥<%#string.Format("{0:N2}", Eval("FactCarriage"))%></td>
                    <%#GetTotal(Eval("Id").ToString(), Eval("Advance").ToString(), Eval("FactRepayment").ToString(), Eval("FactCarriage").ToString()) %>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
