<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生管理</div>
        <div class="MenuNote" style="display:none;" id="StudentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="StudentEdit.aspx" target="main">添加学生</a></li>
                <li><a href="StudentList.aspx" target="main">学生查询</a></li> 
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;问题回复管理</div>
        <div class="MenuNote" style="display:none;" id="QuestionDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                <li><a href="QuestionTeacherList.aspx" target="main">问题查询</a></li> 
                <li><a href="ReplyTeacherList.aspx" target="main">答复查询</a></li>
            </ul>
        </div>
         

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学习资源管理</div>
        <div class="MenuNote" style="display:none;" id="ResourceDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                <li><a href="ResourceList.aspx" target="main">学习资源查询</a></li> 
            </ul>
        </div>

         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统管理</div>
        <div class="MenuNote" style="display:none;" id="Div1" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                <li><a href="TeacherSelfEdit.aspx" target="main">修改个人信息</a></li> 
            </ul>
        </div>

 
  
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
