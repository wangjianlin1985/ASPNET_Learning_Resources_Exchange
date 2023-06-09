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
    ///Question ��ժҪ˵��������ʵ��
    /// </summary>

    public class Question
    {
        /*����id*/
        private int _questionId;
        public int questionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }

        /*�������*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*������*/
        private string _studentObj;
        public string studentObj
        {
            get { return _studentObj; }
            set { _studentObj = value; }
        }

        /*����ʱ��*/
        private DateTime _questionTime;
        public DateTime questionTime
        {
            get { return _questionTime; }
            set { _questionTime = value; }
        }

    }
}
