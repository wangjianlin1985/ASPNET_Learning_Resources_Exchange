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
    ///ResourceType 的摘要说明：资源分类实体
    /// </summary>

    public class ResourceType
    {
        /*资源分类id*/
        private int _resourceTypeId;
        public int resourceTypeId
        {
            get { return _resourceTypeId; }
            set { _resourceTypeId = value; }
        }

        /*资源分类名称*/
        private string _resourceTypeName;
        public string resourceTypeName
        {
            get { return _resourceTypeName; }
            set { _resourceTypeName = value; }
        }

        /*分类描述*/
        private string _resourceTypeDesc;
        public string resourceTypeDesc
        {
            get { return _resourceTypeDesc; }
            set { _resourceTypeDesc = value; }
        }

    }
}
