using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///ResourceType ��ժҪ˵������Դ����ʵ��
    /// </summary>

    public class ResourceType
    {
        /*��Դ����id*/
        private int _resourceTypeId;
        public int resourceTypeId
        {
            get { return _resourceTypeId; }
            set { _resourceTypeId = value; }
        }

        /*��Դ��������*/
        private string _resourceTypeName;
        public string resourceTypeName
        {
            get { return _resourceTypeName; }
            set { _resourceTypeName = value; }
        }

        /*��������*/
        private string _resourceTypeDesc;
        public string resourceTypeDesc
        {
            get { return _resourceTypeDesc; }
            set { _resourceTypeDesc = value; }
        }

    }
}
