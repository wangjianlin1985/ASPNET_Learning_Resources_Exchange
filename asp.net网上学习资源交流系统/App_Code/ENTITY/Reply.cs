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
    ///Reply 的摘要说明：答复实体
    /// </summary>

    public class Reply
    {
        /*答复id*/
        private int _replyId;
        public int replyId
        {
            get { return _replyId; }
            set { _replyId = value; }
        }

        /*回答的问题*/
        private int _questionObj;
        public int questionObj
        {
            get { return _questionObj; }
            set { _questionObj = value; }
        }

        /*答复内容*/
        private string _replyContent;
        public string replyContent
        {
            get { return _replyContent; }
            set { _replyContent = value; }
        }

        /*答复时间*/
        private DateTime _replyTime;
        public DateTime replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

        /*回答的老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

    }
}
