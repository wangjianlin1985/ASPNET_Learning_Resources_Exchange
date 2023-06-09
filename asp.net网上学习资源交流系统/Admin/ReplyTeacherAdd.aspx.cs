using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ReplyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindQuestionquestionObj();
                BindTeacherteacherObj();
                
            }
        }
        private void BindQuestionquestionObj()
        {
            questionObj.DataSource = BLL.bllQuestion.getAllQuestion();
            questionObj.DataTextField = "title";
            questionObj.DataValueField = "questionId";
            questionObj.DataBind();

            questionObj.SelectedValue =  Request.QueryString["questionObj"];
        }

        private void BindTeacherteacherObj()
        {
            teacherObj.DataSource = BLL.bllTeacher.getAllTeacher();
            teacherObj.DataTextField = "name";
            teacherObj.DataValueField = "teacherNo";
            teacherObj.DataBind();
        }

         

        protected void BtnReplySave_Click(object sender, EventArgs e)
        {
            ENTITY.Reply reply = new ENTITY.Reply(); 
            reply.questionObj = int.Parse(Request.QueryString["questionObj"]);
            reply.replyContent = replyContent.Value;
            reply.replyTime = DateTime.Now;
            reply.teacherObj = Session["Customername"].ToString();
            
            
                if (BLL.bllReply.AddReply(reply))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "alert(\"回复成功\");location.href=\"QuestionTeacherList.aspx\";");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ReplyList.aspx");
        }
    }
}

