<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Resource_frontList" %>
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
<title>学习资源查询</title>
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
			    	<li role="presentation" class="active"><a href="#resourceListPanel" aria-controls="resourceListPanel" role="tab" data-toggle="tab">学习资源列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加学习资源</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="resourceListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>资源类别</td><td>资源标题</td><td>资源文件</td><td>上传时间</td><td>上传的学生</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpResource" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetResourceTyperesourceTypeObj(Eval("resourceTypeObj").ToString())%></td>
 											<td><%#Eval("title")%></td>
 											<td><%#Eval("resourceFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("resourceFile").ToString() + "' target='_blank'>" + Eval("resourceFile").ToString() +  "</a>" %></td>
 											<td><%#Eval("upTime")%></td>
 											<td><%#GetStudentstudentObj(Eval("studentObj").ToString())%></td>
 											<td>
 												<a href="frontshow.aspx?resourceId=<%#Eval("resourceId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="resourceEdit('<%#Eval("resourceId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="resourceDelete('<%#Eval("resourceId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>学习资源查询</h1>
		</div>
            <div class="form-group">
            	<label for="resourceTypeObj_resourceId">资源类别：</label>
                <asp:DropDownList ID="resourceTypeObj" runat="server"  CssClass="form-control" placeholder="请选择资源类别"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="title">资源标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入资源标题"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="upTime">上传时间:</label>
				<asp:TextBox ID="upTime"  runat="server" CssClass="form-control" placeholder="请选择上传时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="studentObj_resourceId">上传的学生：</label>
                <asp:DropDownList ID="studentObj" runat="server"  CssClass="form-control" placeholder="请选择上传的学生"></asp:DropDownList>
            </div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="resourceEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;学习资源信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="resourceEditForm" id="resourceEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="resource_resourceId_edit" class="col-md-3 text-right">资源id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="resource_resourceId_edit" name="resource.resourceId" class="form-control" placeholder="请输入资源id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="resource_resourceTypeObj_resourceTypeId_edit" class="col-md-3 text-right">资源类别:</label>
		  	 <div class="col-md-9">
			    <select id="resource_resourceTypeObj_resourceTypeId_edit" name="resource.resourceTypeObj.resourceTypeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="resource_title_edit" class="col-md-3 text-right">资源标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="resource_title_edit" name="resource.title" class="form-control" placeholder="请输入资源标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="resource_resourceDesc_edit" class="col-md-3 text-right">资源描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="resource_resourceDesc_edit" name="resource.resourceDesc" rows="8" class="form-control" placeholder="请输入资源描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="resource_resourceFile_edit" class="col-md-3 text-right">资源文件:</label>
		  	 <div class="col-md-9">
			    <a id="resource_resourceFileA" target="_blank"></a><br/>
			    <input type="hidden" id="resource_resourceFile" name="resource.resourceFile"/>
			    <input id="resourceFileFile" name="resourceFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="resource_upTime_edit" class="col-md-3 text-right">上传时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date resource_upTime_edit col-md-12" data-link-field="resource_upTime_edit">
                    <input class="form-control" id="resource_upTime_edit" name="resource.upTime" size="16" type="text" value="" placeholder="请选择上传时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="resource_studentObj_studentNumber_edit" class="col-md-3 text-right">上传的学生:</label>
		  	 <div class="col-md-9">
			    <select id="resource_studentObj_studentNumber_edit" name="resource.studentObj.studentNumber" class="form-control">
			    </select>
		  	 </div>
		  </div>
		</form> 
	    <style>#resourceEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxResourceModify();">提交</button>
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
/*弹出修改学习资源界面并初始化数据*/
function resourceEdit(resourceId) {
	$.ajax({
		url :  basePath + "Resource/ResourceController.aspx?action=getResource&resourceId=" + resourceId,
		type : "get",
		dataType: "json",
		success : function (resource, response, status) {
			if (resource) {
				$("#resource_resourceId_edit").val(resource.resourceId);
				$.ajax({
					url: basePath + "ResourceType/ResourceTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(resourceTypes,response,status) { 
						$("#resource_resourceTypeObj_resourceTypeId_edit").empty();
						var html="";
		        		$(resourceTypes).each(function(i,resourceType){
		        			html += "<option value='" + resourceType.resourceTypeId + "'>" + resourceType.resourceTypeName + "</option>";
		        		});
		        		$("#resource_resourceTypeObj_resourceTypeId_edit").html(html);
		        		$("#resource_resourceTypeObj_resourceTypeId_edit").val(resource.resourceTypeObjPri);
					}
				});
				$("#resource_title_edit").val(resource.title);
				$("#resource_resourceDesc_edit").val(resource.resourceDesc);
				$("#resource_resourceFile").val(resource.resourceFile);
				$("#resource_resourceFileA").text(resource.resourceFile);
				$("#resource_resourceFileA").attr("href", basePath +　resource.resourceFile);
				$("#resource_upTime_edit").val(resource.upTime);
				$.ajax({
					url: basePath + "Student/StudentController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(students,response,status) { 
						$("#resource_studentObj_studentNumber_edit").empty();
						var html="";
		        		$(students).each(function(i,student){
		        			html += "<option value='" + student.studentNumber + "'>" + student.name + "</option>";
		        		});
		        		$("#resource_studentObj_studentNumber_edit").html(html);
		        		$("#resource_studentObj_studentNumber_edit").val(resource.studentObjPri);
					}
				});
				$('#resourceEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除学习资源信息*/
function resourceDelete(resourceId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Resource/ResourceController.aspx?action=delete",
			data : {
				resourceId : resourceId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Resource/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交学习资源信息表单给服务器端修改*/
function ajaxResourceModify() {
	$.ajax({
		url :  basePath + "Resource/ResourceController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#resourceEditForm")[0]),
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

    /*上传时间组件*/
    $('.resource_upTime_edit').datetimepicker({
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

