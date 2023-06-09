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
    ///Resource 的摘要说明：学习资源实体
    /// </summary>

    public class Resource
    {
        /*资源id*/
        private int _resourceId;
        public int resourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }

        /*资源类别*/
        private int _resourceTypeObj;
        public int resourceTypeObj
        {
            get { return _resourceTypeObj; }
            set { _resourceTypeObj = value; }
        }

        /*资源标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*资源描述*/
        private string _resourceDesc;
        public string resourceDesc
        {
            get { return _resourceDesc; }
            set { _resourceDesc = value; }
        }

        /*资源文件*/
        private string _resourceFile;
        public string resourceFile
        {
            get { return _resourceFile; }
            set { _resourceFile = value; }
        }

        /*上传时间*/
        private DateTime _upTime;
        public DateTime upTime
        {
            get { return _upTime; }
            set { _upTime = value; }
        }

        /*上传的学生*/
        private string _studentObj;
        public string studentObj
        {
            get { return _studentObj; }
            set { _studentObj = value; }
        }

    }
}
