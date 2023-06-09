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
    public partial class ResourceTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["resourceTypeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "resourceTypeId")))
            {
                ENTITY.ResourceType resourceType = BLL.bllResourceType.getSomeResourceType(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "resourceTypeId")));
                resourceTypeName.Value = resourceType.resourceTypeName;
                resourceTypeDesc.Value = resourceType.resourceTypeDesc;
            }
        }

        protected void BtnResourceTypeSave_Click(object sender, EventArgs e)
        {
            ENTITY.ResourceType resourceType = new ENTITY.ResourceType();
            resourceType.resourceTypeName = resourceTypeName.Value;
            resourceType.resourceTypeDesc = resourceTypeDesc.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "resourceTypeId")))
            {
                resourceType.resourceTypeId = int.Parse(Request["resourceTypeId"]);
                if (BLL.bllResourceType.EditResourceType(resourceType))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ResourceTypeEdit.aspx?resourceTypeId=" + Request["resourceTypeId"] + "\"} else  {location.href=\"ResourceTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllResourceType.AddResourceType(resourceType))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ResourceTypeEdit.aspx\"} else  {location.href=\"ResourceTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceTypeList.aspx");
        }
    }
}

