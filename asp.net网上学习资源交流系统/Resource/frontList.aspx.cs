using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Resource_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            li = new ListItem(dr["resourceTypeName"].ToString(),dr["resourceTypeId"].ToString());
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
            li = new ListItem(dr["name"].ToString(),dr["studentNumber"].ToString());
            studentObj.Items.Add(li);
        }
        studentObj.SelectedValue = "";
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
            Response.Redirect("frontList.aspx?resourceTypeObj=" + resourceTypeObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&upTime=" + upTime.Text.Trim() + "&&studentObj=" + studentObj.SelectedValue.Trim());
        }

}
