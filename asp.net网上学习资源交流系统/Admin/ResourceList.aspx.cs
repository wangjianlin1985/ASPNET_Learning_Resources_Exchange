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
    public partial class ResourceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindresourceTypeObj();
                BindstudentObj();
                string sqlstr = " where 1=1 ";
                if (Request["resourceTypeObj"] != null && Request["resourceTypeObj"].ToString() != "0")
                {
                    sqlstr += "  and resourceTypeObj=" + Request["resourceTypeObj"].ToString();
                    resourceTypeObj.SelectedValue = Request["resourceTypeObj"].ToString();
                }
                if (Request["title"] != null && Request["title"].ToString() != "")
                {
                    sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                    title.Text = Request["title"].ToString();
                }
                if (Request["upTime"] != null && Request["upTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,upTime,120) like '" + Request["upTime"].ToString() + "%'";
                    upTime.Text = Request["upTime"].ToString();
                }
                if (Request["studentObj"] != null && Request["studentObj"].ToString() != "")
                {
                    sqlstr += "  and studentObj='" + Request["studentObj"].ToString() + "'";
                    studentObj.SelectedValue = Request["studentObj"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindresourceTypeObj()
        {
            ListItem li = new ListItem("不限制", "0");
            resourceTypeObj.Items.Add(li);
            DataSet resourceTypeObjDs = BLL.bllResourceType.getAllResourceType();
            for (int i = 0; i < resourceTypeObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = resourceTypeObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["resourceTypeName"].ToString(), dr["resourceTypeName"].ToString());
                resourceTypeObj.Items.Add(li);
            }
            resourceTypeObj.SelectedValue = "0";
        }

        private void BindstudentObj()
        {
            ListItem li = new ListItem("不限制", "");
            studentObj.Items.Add(li);
            DataSet studentObjDs = BLL.bllStudent.getAllStudent();
            for (int i = 0; i < studentObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = studentObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                studentObj.Items.Add(li);
            }
            studentObj.SelectedValue = "";
        }

        protected void BtnResourceAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllResource.DelResource(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "ResourceList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllResource.GetResource(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpResource.DataSource = dsLog;
            RpResource.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpResource_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllResource.DelResource((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "ResourceList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "ResourceList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "ResourceList.aspx");
                }
            }
        }
        public string GetResourceTyperesourceTypeObj(string resourceTypeObj)
        {
            return BLL.bllResourceType.getSomeResourceType(int.Parse(resourceTypeObj)).resourceTypeName;
        }

        public string GetStudentstudentObj(string studentObj)
        {
            return BLL.bllStudent.getSomeStudent(studentObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceList.aspx?resourceTypeObj=" + resourceTypeObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&upTime=" + upTime.Text.Trim() + "&&studentObj=" + studentObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet resourceDataSet = BLL.bllResource.GetResource(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='5'>学习资源记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>资源类别</th>");
            sb.Append("<th>资源标题</th>");
            sb.Append("<th>资源文件</th>");
            sb.Append("<th>上传时间</th>");
            sb.Append("<th>上传的学生</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < resourceDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = resourceDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + BLL.bllResourceType.getSomeResourceType(Convert.ToInt32(dr["resourceTypeObj"])).resourceTypeName + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td>" + dr["resourceFile"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["upTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + BLL.bllStudent.getSomeStudent(dr["studentObj"].ToString()).name + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "学习资源记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
