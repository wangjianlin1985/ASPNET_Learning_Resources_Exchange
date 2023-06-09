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
    ///Resource ��ժҪ˵����ѧϰ��Դʵ��
    /// </summary>

    public class Resource
    {
        /*��Դid*/
        private int _resourceId;
        public int resourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }

        /*��Դ���*/
        private int _resourceTypeObj;
        public int resourceTypeObj
        {
            get { return _resourceTypeObj; }
            set { _resourceTypeObj = value; }
        }

        /*��Դ����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��Դ����*/
        private string _resourceDesc;
        public string resourceDesc
        {
            get { return _resourceDesc; }
            set { _resourceDesc = value; }
        }

        /*��Դ�ļ�*/
        private string _resourceFile;
        public string resourceFile
        {
            get { return _resourceFile; }
            set { _resourceFile = value; }
        }

        /*�ϴ�ʱ��*/
        private DateTime _upTime;
        public DateTime upTime
        {
            get { return _upTime; }
            set { _upTime = value; }
        }

        /*�ϴ���ѧ��*/
        private string _studentObj;
        public string studentObj
        {
            get { return _studentObj; }
            set { _studentObj = value; }
        }

    }
}
