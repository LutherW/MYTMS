<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_order_edit.aspx.cs" Inherits="DTcms.Web.admin.dialog.dialog_order_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加订单</title>
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
        var api = frameElement.api, W = api.opener;
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            $("#ddlHaulway").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    $.getJSON("../../tools/Haulway.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtLoadingCapacityRunning").val(data.loadingCapacityRunning);
                            $("#txtNoLoadingCapacityRunning").val(data.noLoadingCapacityRunning);
                        }
                    });
                } else {
                    $("#txtLoadingCapacityRunning").val("0.00");
                    $("#txtNoLoadingCapacityRunning").val("0.00");
                }
            });

            $("#ddlGoods").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    $.getJSON("../../tools/Goods.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtUnit").val(data.unit);
                        }
                    });
                } else {
                    $("#txtUnit").val("");
                }
            });
        });

        function closeDialog() {
            api.close();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <%--<div class="location">
            <a href="order_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单管理</span>
            <i class="arrow"></i>
            <span>编辑订单</span>
        </div>--%>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">客户信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">货物信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>接单时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtAcceptOrderTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>要求到货时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtArrivedTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>合同号</dt>
                <dd>
                    <asp:TextBox ID="txtContractNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>提单号</dt>
                <dd>
                    <asp:TextBox ID="txtBillNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>地磅号</dt>
                <dd>
                    <asp:TextBox ID="txtWeighbridgeNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>预发量</dt>
                <dd>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" " CssClass="input small"></asp:TextBox>
                    <asp:CheckBox ID="chkIsCharteredCar" runat="server" Text="包车" />
                    <asp:CheckBox ID="chkIsWeightNote" runat="server" Text="磅单" />
                    <asp:CheckBox ID="chkIsAllotted" runat="server" Text="调单" />
                    <span class="Validform_checktip">如果选择包车，预发量填0.00</span></dd>
            </dl>
            <dl>
                <dt>单价</dt>
                <dd>
                    <asp:TextBox ID="txtUnitPrice" runat="server" Text="0.00" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>重量</dt>
                <dd>
                    <asp:TextBox ID="txtWeight" runat="server" Text="0.00" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>运费</dt>
                <dd>
                    <asp:TextBox ID="txtFreight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>已结运费</dt>
                <dd>
                    <asp:TextBox ID="txtPaidFreight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>下余运费</dt>
                <dd>
                    <asp:TextBox ID="txtUnpaidFreight" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>装卸费</dt>
                <dd>
                    <asp:TextBox ID="txtHandlingCharge" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>提货地址</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11013">
                        <asp:DropDownList ID="ddlLoadingAddress" runat="server" datatype="*" errormsg="请选择提货地址" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>目的地址</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11004">
                        <asp:DropDownList ID="ddlUnloadingAddress" runat="server" datatype="*" errormsg="请选择目的地址" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            
            <dl>
                <dt>托运方</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11000">
                        <asp:DropDownList ID="ddlShipper" runat="server" datatype="*" errormsg="请选择托运方" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>收货方</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:1006">
                        <asp:DropDownList ID="ddlReceiver" runat="server" datatype="*" errormsg="请选择收货方" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>运输路线</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11000">
                        <asp:DropDownList ID="ddlHaulway" runat="server" datatype="*" errormsg="请选择运输路线" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>载重公里</dt>
                <dd>
                    <asp:TextBox ID="txtLoadingCapacityRunning" runat="server" CssClass="input small" Text="0.00"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>空载公里</dt>
                <dd>
                    <asp:TextBox ID="txtNoLoadingCapacityRunning" runat="server" CssClass="input small" Text="0.00"></asp:TextBox></dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>承运货物</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:1007">
                        <asp:DropDownList ID="ddlGoods" runat="server" datatype="*" errormsg="请选择承运货物" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>计量单位</dt>
                <dd>
                    <asp:TextBox ID="txtUnit" runat="server" CssClass="input small"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
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
                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="关闭" class="btn yellow" onclick="javascript: closeDialog();" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
