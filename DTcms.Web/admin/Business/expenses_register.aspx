<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expenses_register.aspx.cs" Inherits="DTcms.Web.admin.Business.expenses_register" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>回车报账</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="expenses_register_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>回车报账列表</span>
            <i class="arrow"></i>
            <span>回车报账</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">运输单信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">承运单信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">出车费用</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>送达时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtFactArriveDate" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>预计回车时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtBackTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>应交还款</dt>
                <dd>
                    <asp:TextBox ID="txtRepayment" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>实交还款</dt>
                <dd>
                    <asp:TextBox ID="txtFactRepayment" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>发货数量</dt>
                <dd>
                    <asp:TextBox ID="txtFactDispatchCount" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>发货重量</dt>
                <dd>
                    <asp:TextBox ID="txtFactWeight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>收货重量</dt>
                <dd>
                    <asp:TextBox ID="txtReceivedWeight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>卸货重量</dt>
                <dd>
                    <asp:TextBox ID="txtUnloadingWeight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>运费</dt>
                <dd>
                    <asp:TextBox ID="txtFactCarriage" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none; padding: 0 0 10px 0;">
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="12" style="text-align: center; font-weight: bold;">承运订单</td>
                </tr>
            </table>
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="5%"></td>
                    <td align="left">提单号</td>
                    <td width="13%">托运方</td>
                    <td width="13%">收货方</td>
                    <td width="12%">货物</td>
                    <td width="8%">单价</td>
                    <td width="8%">重量</td>
                    <td width="8%">总运费</td>
                    <td width="8%">已收运费</td>
                    <td width="8%">下余运费</td>
                </tr>
                <%=transportOrderItems %>
            </table>
        </div>
        <div class="tab-content" style="display: none; padding: 0 0 10px 0;">
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="5%"></td>
                    <td align="left">费用名称</td>
                    <td width="50%">金额</td>
                </tr>
                <%=consumptions %>
            </table>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
