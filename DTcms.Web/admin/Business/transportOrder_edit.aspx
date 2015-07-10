<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transportOrder_edit.aspx.cs" Inherits="DTcms.Web.admin.Business.transportOrder_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑运输单</title>
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
            <a href="transportOrder_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>运输单管理</span>
            <i class="arrow"></i>
            <span>编辑运输单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">运输单信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>计划出车时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtDispatchTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>司机</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:9990">
                        <asp:DropDownList ID="ddlDriver" runat="server" datatype="*" errormsg="请选择司机" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>客户描述</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerRemarks" runat="server" CssClass="input high" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>运输路线描述</dt>
                <dd>
                    <asp:TextBox ID="txtHaulwayRemarks" runat="server" CssClass="input high" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>预发数量</dt>
                <dd>
                    <asp:TextBox ID="txtDispatchCount" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            
            <dl>
                <dt>单价(运价)</dt>
                <dd>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>重量(吨位)</dt>
                <dd>
                    <asp:TextBox ID="txtWeight" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>运费</dt>
                <dd>
                    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>司机费用单价</dt>
                <dd>
                    <asp:TextBox ID="txtCarriageUnitPrice" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>司机费用总价</dt>
                <dd>
                    <asp:TextBox ID="txtCarriage" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>装载里程</dt>
                <dd>
                    <asp:TextBox ID="txtLoadingCapacityRunning" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>

            <dl>
                <dt>空载里程</dt>
                <dd>
                    <asp:TextBox ID="txtNoLoadingCapacityRunning" runat="server" CssClass="input high" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>

            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                </dd>
            </dl>
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
