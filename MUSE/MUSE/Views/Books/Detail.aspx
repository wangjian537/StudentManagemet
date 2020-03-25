<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/common.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CSSLink" runat="server">
    <link href="../../css/bookdetail.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!-- 主体部分 -->
		<div class="boss">
			<div class="box1">
				<span class="layui-breadcrumb">
				  <a href="<%= Url.Action("Index", "Home") %>">首页</a>
				  <a href="<%= Url.Action("List", "Home") %>">全部课程</a>
				  <a><cite>课程详情</cite></a>
				</span>
			</div>
			<div class="box2">
			    <img src="<%= Url.Content("/img/" + Model._courseCover.ToString()) %>" >
				<div class="box2_1">
					<h2><%= Model._Course %></h2>
					<ul>
						<li>课程学分：<%= Model.CourseCredit%></li>
						<li>课程学时：<%= Model._coursePeriod%></li>
						<li>课程类型：<%= Model._courseType%></li>
						<li>学院：<%= Model._academy%></li>
						<li>开课时间：<%= Model._courseBeginTime%></li>
						<li class="li6">课程描述：<%= Model._note%></li>
					</ul>
					<a href="">
					<button type="button" class="layui-btn layui-btn-xs layui-btn-radius">进入选课</button>
					</a>
				</div>
			</div>


         <%--<script src="layui/layui.js"></script>--%>
            <script src="../../layui/layui.js"></script>
		<script type="text/javascript">
		    layui.use(['element'], function () {

		    })
		</script>
</asp:Content>

