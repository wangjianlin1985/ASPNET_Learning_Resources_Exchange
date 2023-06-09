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
    ///Teacher 的摘要说明：教师实体
    /// </summary>

    public class Teacher
    {
        /*教师工号*/
        private string _teacherNo;
        public string teacherNo
        {
            get { return _teacherNo; }
            set { _teacherNo = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*姓名*/
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /*性别*/
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /*出生日期*/
        private DateTime _birthDate;
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        /*教师照片*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*邮箱*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
