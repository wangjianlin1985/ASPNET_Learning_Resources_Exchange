<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyTeacherAdd.aspx.cs" Inherits="chengxusheji.Admin.ReplyEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var replyContent = document.getElementById("replyContent").value;
            if (replyContent == "") {
                alert("请输入答复内容...");
                document.getElementById("replyContent").focus();
                return false;
            }

           
            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">答复管理 》》编辑答复</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    回答的问题：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="questionObj" runat="server" AutoPostBack="true" Enabled="false">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   答复内容：</td>
                    <td width="650px;">
                        <textarea id="replyContent" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入答复内容！</td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  答复时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="replyTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    回答的老师：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="teacherObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnReplySave" runat="server" Text=" 提交回答 "
                            OnClientClick="return CheckIn()" onclick="BtnReplySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

