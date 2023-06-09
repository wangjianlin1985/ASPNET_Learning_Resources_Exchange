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
    ///Question 的摘要说明：问题实体
    /// </summary>

    public class Question
    {
        /*问题id*/
        private int _questionId;
        public int questionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }

        /*问题标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*问题描述*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*提问人*/
        private string _studentObj;
        public string studentObj
        {
            get { return _studentObj; }
            set { _studentObj = value; }
        }

        /*提问时间*/
        private DateTime _questionTime;
        public DateTime questionTime
        {
            get { return _questionTime; }
            set { _questionTime = value; }
        }

    }
}
