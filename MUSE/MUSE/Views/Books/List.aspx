<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/common.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CSSLink" runat="server">
    <link href="../../css/allcourse.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- 主体部分 -->
    <div class="boss">
        <div class="box1">
            <span class="layui-breadcrumb">
                <a href="<%= Url.Action("Index", "Home") %>">首页</a>
                <a><cite>全部课程</cite></a>
            </span>
        </div>

        <div class="box2">
            <table class="layui-hide" id="test" lay-filter="test"></table>
            <script type="text/html" id="toolbarDemo">
                <form action="<%=Url.Action("List", "Books") %>" method="post">
                    <input type="text" placeholder="课程搜索" name="keyword" id="" value="">
                    <button>搜索</button>
                </form>
            </script>

            <%-- url: '<%= Url.Action("CourseList", "Books")%>',--%>
            <%--<script src="layui/layui.js"></script>--%>
            <script src="../../layui/layui.js"></script>

            <script>
                layui.use('table', function () {
                    var table = layui.table;

                    table.render({
                            elem: '#test',
                            url: '<%= Url.Action("CourseList", "Books" ,new { keyword = ViewBag.keyword})%>',
				            title: '用户数据表',
				            toolbar: '#toolbarDemo', //开启头部工具栏
				            defaultToolbar: ['filter', 'exports', 'print'],
				            page: true,
				            limit: 10,
				            limits: [10, 20, 30],
				            layEvent: 'LAYTABLE_TIPS',
				            icon: 'layui-icon-tips',
				            totalRow: true,
				            cols: [
								[{
								    field: 'id',
								    title: '课程号',
								    width: 100,
								    fixed: 'left',
								    unresize: true,
								    sort: true,
								    totalRowText: "合计",
								    align: 'center'
								}, {
								    field: 'name',
								    title: '课程名',
								    /* width: 250, */
								    align: 'center'
								}, {
								    field: 'credit',
								    title: '课程学分',
								    width: 110,
								    sort: true,
								    totalRow: true,
								    align: 'center'
								}, {
								    field: 'period',
								    title: '课程学时',
								    width: 110,
								    align: 'center'
								}, {
								    field: 'type',
								    title: '课程类型',
								    width: 120,
								    align: 'center'
								}, {
								    field: 'college',
								    title: '所属院系',
								    width: 150,
								    align: 'center'
								}, {
								    field: 'starttime',
								    title: '开始时间',
								    width: 110,
								    sort: true,
								    align: 'center'
								}]
				            ]
				        });
				        //头工具栏事件
				        table.on('toolbar(test)', function (obj) {
				            var checkStatus = table.checkStatus(obj.config.id);
				            switch (obj.event) {
				                case 'getCheckData':
				                    var data = checkStatus.data;
				                    layer.alert(JSON.stringify(data));
				                    break;
				                case 'getCheckLength':
				                    var data = checkStatus.data;
				                    layer.msg('选中了：' + data.length + ' 个');
				                    break;
				                case 'isAll':
				                    layer.msg(checkStatus.isAll ? '全选' : '未全选');
				                    break;
				            };
				        });
				    });
            </script>
        </div>
    </div>


    <script>
        layui.use('element', function () {
            var element = layui.element; //导航的hover效果、二级菜单等功能，需要依赖element模块

            //监听导航点击
            element.on('nav(demo)', function (elem) {
                //console.log(elem)
                layer.msg(elem.text());
            });
        });
    </script>


</asp:Content>

