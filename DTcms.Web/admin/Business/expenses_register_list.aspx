﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expenses_register_list.aspx.cs" Inherits="DTcms.Web.admin.Business.expenses_register_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>运输单管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.browser.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.jqprint-0.3.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function showOrders(id) {
            var dialog = $.dialog({
                title: '订单列表',
                content: 'url:dialog/dialog_order_list.aspx?transportOrderId=' + id,
                min: false,
                max: false,
                lock: true,
                width: 1300
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
            <span>业务管理</span>
            <i class="arrow"></i>
            <span>回车报账列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <div class="menu-list">
                        <span style="font-size: 12px;">车号:
                        </span>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlDriver" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="r-list">
                    <div style="float: left; margin-right: 10px; font-size: 12px;">
                        出车时间：<asp:TextBox ID="txtBeginTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                        -
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    </div>
                    <div style="float: right;">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left">运输单编号</th>
                            <th align="left" width="7%">出车时间</th>
                            <th width="8%">装货时间</th>
                            <th width="8%">出车支款</th>
                            <th width="8%">领款人</th>
                            <th width="5%">司机</th>
                            <th width="8%">车号</th>
                            <th width="8%">单价(运价)</th>
                            <th width="8%">运费(总价)</th>
                            <th width="5%">重量</th>
                            <th width="5%">数量</th>
                            <th width="10%">里程(装载/空载公里)</th>
                            <th width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td>
                            <%#(Eval("Status").ToString().Equals("0") || Eval("Status").ToString().Equals("1")) ? string.Format("<a href=\"transportOrder_edit.aspx?action={0}&id={1}\">{2}</a>", DTEnums.ActionEnum.Edit, Eval("Id"), Eval("Code")) : Eval("Code")%>
                        </td>
                        <td><%#string.Format("{0:d}", Eval("FactDispatchTime"))%></td>
                        <td align="center"><%#string.Format("{0:d}", Eval("LoadingDate"))%></td>
                        <td align="center"><%#Eval("Advance")%></td>
                        <td align="center"><%#Eval("Payee")%></td>
                        <td align="center"><%#Eval("Driver")%></td>
                        <td align="center"><%#Eval("CarNumber")%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("CarriageUnitPrice"))%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("FactCarriage"))%></td>
                        <td align="center"><%#string.Format("{0:N2}", Eval("FactWeight"))%></td>
                        <td align="center"><%#string.Format("{0:N2}", Eval("FactDispatchCount"))%></td>
                        <td align="center"><%#string.Format("{0:N2}/{1:N2}", Eval("LoadingCapacityRunning"), Eval("NoLoadingCapacityRunning"))%></td>
                        <td align="center">
                            <a href="expenses_register.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">报账</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
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
