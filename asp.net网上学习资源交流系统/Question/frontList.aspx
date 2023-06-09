<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Question_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>问题查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#questionListPanel" aria-controls="questionListPanel" role="tab" data-toggle="tab">问题列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加问题</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="questionListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>问题标题</td><td>提问人</td><td>提问时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpQuestion" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("title")%></td>
 											<td><%#GetStudentstudentObj(Eval("studentObj").ToString())%></td>
 											<td><%#Eval("questionTime")%></td>
 											<td>
 												<a href="frontshow.aspx?questionId=<%#Eval("questionId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="questionEdit('<%#Eval("questionId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="questionDelete('<%#Eval("questionId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>问题查询</h1>
		</div>
			<div class="form-group">
				<label for="title">问题标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入问题标题"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="studentObj_questionId">提问人：</label>
                <asp:DropDownList ID="studentObj" runat="server"  CssClass="form-control" placeholder="请选择提问人"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="questionTime">提问时间:</label>
				<asp:TextBox ID="questionTime"  runat="server" CssClass="form-control" placeholder="请选择提问时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="questionEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;问题信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="questionEditForm" id="questionEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="question_questionId_edit" class="col-md-3 text-right">问题id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="question_questionId_edit" name="question.questionId" class="form-control" placeholder="请输入问题id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="question_title_edit" class="col-md-3 text-right">问题标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="question_title_edit" name="question.title" class="form-control" placeholder="请输入问题标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="question_content_edit" class="col-md-3 text-right">问题描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="question_content_edit" name="question.content" rows="8" class="form-control" placeholder="请输入问题描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="question_studentObj_studentNumber_edit" class="col-md-3 text-right">提问人:</label>
		  	 <div class="col-md-9">
			    <select id="question_studentObj_studentNumber_edit" name="question.studentObj.studentNumber" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="question_questionTime_edit" class="col-md-3 text-right">提问时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date question_questionTime_edit col-md-12" data-link-field="question_questionTime_edit">
                    <input class="form-control" id="question_questionTime_edit" name="question.questionTime" size="16" type="text" value="" placeholder="请选择提问时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#questionEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxQuestionModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改问题界面并初始化数据*/
function questionEdit(questionId) {
	$.ajax({
		url :  basePath + "Question/QuestionController.aspx?action=getQuestion&questionId=" + questionId,
		type : "get",
		dataType: "json",
		success : function (question, response, status) {
			if (question) {
				$("#question_questionId_edit").val(question.questionId);
				$("#question_title_edit").val(question.title);
				$("#question_content_edit").val(question.content);
				$.ajax({
					url: basePath + "Student/StudentController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(students,response,status) { 
						$("#question_studentObj_studentNumber_edit").empty();
						var html="";
		        		$(students).each(function(i,student){
		        			html += "<option value='" + student.studentNumber + "'>" + student.name + "</option>";
		        		});
		        		$("#question_studentObj_studentNumber_edit").html(html);
		        		$("#question_studentObj_studentNumber_edit").val(question.studentObjPri);
					}
				});
				$("#question_questionTime_edit").val(question.questionTime);
				$('#questionEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除问题信息*/
function questionDelete(questionId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Question/QuestionController.aspx?action=delete",
			data : {
				questionId : questionId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Question/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交问题信息表单给服务器端修改*/
function ajaxQuestionModify() {
	$.ajax({
		url :  basePath + "Question/QuestionController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#questionEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*提问时间组件*/
    $('.question_questionTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

