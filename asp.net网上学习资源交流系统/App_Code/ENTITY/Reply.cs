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
    ///Reply ��ժҪ˵������ʵ��
    /// </summary>

    public class Reply
    {
        /*��id*/
        private int _replyId;
        public int replyId
        {
            get { return _replyId; }
            set { _replyId = value; }
        }

        /*�ش������*/
        private int _questionObj;
        public int questionObj
        {
            get { return _questionObj; }
            set { _questionObj = value; }
        }

        /*������*/
        private string _replyContent;
        public string replyContent
        {
            get { return _replyContent; }
            set { _replyContent = value; }
        }

        /*��ʱ��*/
        private DateTime _replyTime;
        public DateTime replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

        /*�ش����ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

    }
}
