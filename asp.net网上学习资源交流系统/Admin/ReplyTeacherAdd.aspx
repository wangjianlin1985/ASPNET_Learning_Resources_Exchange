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
                alert("�����������...");
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
    <div class="Body_Title">�𸴹��� �����༭��</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �ش�����⣺</td>
                    <td width="650px;">
                         <asp:DropDownList ID="questionObj" runat="server" AutoPostBack="true" Enabled="false">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �����ݣ�</td>
                    <td width="650px;">
                        <textarea id="replyContent" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>����������ݣ�</td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ��ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="replyTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �ش����ʦ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="teacherObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnReplySave" runat="server" Text=" �ύ�ش� "
                            OnClientClick="return CheckIn()" onclick="BtnReplySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

