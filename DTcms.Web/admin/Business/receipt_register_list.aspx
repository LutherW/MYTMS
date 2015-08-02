<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receipt_register_list.aspx.cs" Inherits="DTcms.Web.admin.Business.receipt_register_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>回单登记管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.browser.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.jqprint-0.3.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {

        });

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
            <span>运输单列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <%--<div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="transportOrder_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新建</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        <li><a class="all" href="javascript:void(0);" onclick="print();"><i></i><span>打印</span></a></li>
                    </ul>
                </div>
            </div>--%>
            <div id="Div1" class="toolbar">
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
                        计划回车时间：<asp:TextBox ID="txtBeginTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
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
                            <th width="4%">选择</th>
                            <th align="left">运输单编号</th>
                            <th align="left" width="7%">送达时间</th>
                            <th align="left" width="7%">计划回车时间</th>
                            <th width="5%">应交还款</th>
                            <th width="5%">实交还款</th>
                            <th width="5%">司机</th>
                            <th width="8%">车号</th>
                            <th width="8%">单价(运价)</th>
                            <th width="8%">运费(总价)</th>
                            <th width="5%">发货重量</th>
                            <th width="5%">收货重量</th>
                            <th width="10%">里程(装载/空载公里)</th>
                            <th width="10%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td>
                            <%#Eval("Code")%>
                        </td>
                        <td><%#string.Format("{0:d}", Eval("FactArriveDate"))%></td>
                        <td><%#string.Format("{0:d}", Eval("BackTime"))%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("Repayment"))%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("FactRepayment"))%></td>
                        <td align="center"><%#Eval("Driver")%></td>
                        <td align="center"><%#Eval("CarNumber")%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("CarriageUnitPrice"))%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("FactCarriage"))%></td>
                        <td align="center"><%#string.Format("{0:N2}", Eval("FactWeight"))%></td>
                        <td align="center"><%#string.Format("{0:N2}", Eval("ReceivedWeight"))%></td>
                        <td align="center"><%#string.Format("{0:N2}/{1:N2}", Eval("LoadingCapacityRunning"), Eval("NoLoadingCapacityRunning"))%></td>
                        <td align="center">
                            <a href="receipt_register.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">登记</a>
                            <a href="receipt_warning.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">提醒</a>
                            <a href='javascript:void(0);' onclick="showOrders(<%#Eval("Id") %>);">订单</a>
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
