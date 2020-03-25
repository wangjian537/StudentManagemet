<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/common.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MUSE
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CSSLink" runat="server">
    <link href="../../css/body.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 轮播图 -->
		<div class="ban">
			<div class="full-screen-slider">
			<div class="layui-carousel" id="test10">
			<div carousel-item="">
			<div><img src="img/lunbo_1.jpg"></div>
			<div><img src="img/lunbo_2.jpg" ></div>
			<div><img src="img/lunbo_3.jpg" ></div>
			<div><img src="img/lunbo_4.jpg" ></div>
			</div>
			</div>
			</div>
		</div>

    <div class="news">
			<div class="news1">
				<img src="<%= Url.Content("img/首页新闻图.png") %>" alt="">
			</div>
			<div class="words">
				<h2>新           闻</h2>
				<h3>web程序设计学生选课管理系统</h3>
				<p>以“web程序设计学生选课管理系统...</p>
				<ul>
					<li>
						<a href="#">web程序设计学生选课管理系统</a>
					</li>
					<li>
						<a href="#">web程序设计学生选课管理系统</a>
					</li>
					<li>
						<a href="#">web程序设计学生选课管理系统</a>
					</li>
					<li>
						<a href="#">web程序设计学生选课管理系统</a>
					</li>
				</ul>
			</div>
	</div>

<!-- 最新课程 -->
		<div class="wxxwlft">
			<div class="wxxwlftlf">最新课程</div>
		</div>
        <div class="zxkc">
		    <div class="box_1">
			    <ul>
                    <% for (int i = 3; i < 7; i++ )
                       { %>
                        <li>
					        <div class="pic">
					                <a href="<%= Url.Action("Detail", "Books", new { id = Model[i]._courseCode})%>"><img src="<%= Url.Content("/img/" + Model[i]._courseCover.ToString()) %>" /></a>
					         </div>
					         <div class="name">
					                <a href="<%= Url.Action("Detail", "Books", new { id = Model[i]._courseCode})%>"><%= Model[i]._Course %></a>
					        </div>
				        </li>
                     <%} %>
				
			    </ul>
		    </div>
			
			<div class="more">
			    <a href="<%= Url.Action("List", "Books") %>">	
			        <button class="layui-btn" type="button"> <span class="layui-icon">&#xe609;</span>更多课程</button>
			    </a>
			</div>
		</div>
		
		<!-- 全部 -->
		<div class="wxxwlft">
			<div class="wxxwlftlf">全部课程</div>
		</div>
		<div class="zxkc">
		    <div class="box_1">
			    <ul>
                    <% for (int i = 0; i < 4; i++ )
                       { %>
                        <li>
					        <div class="pic">
					                <a href="<%= Url.Action("Detail", "Books", new { id = Model[i]._courseCode})%>"><img src="<%= Url.Content("/img/" + Model[i]._courseCover) %>"/></a>
					         </div>
					         <div class="name">
					                <a href="<%= Url.Action("Detail", "Books", new { id = Model[i]._courseCode})%>"><%= Model[i]._Course %></a>
					        </div>
				        </li>
                     <%} %>
				
			    </ul>
		    </div>
			
			<div class="more">
			    <a href="<%= Url.Action("List", "Books") %>">	
			        <button class="layui-btn" type="button"> <span class="layui-icon">&#xe609;</span>更多课程</button>
			    </a>
			</div>
		</div>
		

<script src="../../layui/layui.js"></script>
<script type="text/javascript">
    layui.use(['element', 'jquery', 'carousel'], function () {
        var $ = layui.jquery;
        var element = layui.element;
        var carousel = layui.carousel;
        //图片轮播
        carousel.render({
            elem: '#test10'
        , width: '100%'
        , height: '498px'
        , interval: 5000
        });
    });
		</script>

</asp:Content>


