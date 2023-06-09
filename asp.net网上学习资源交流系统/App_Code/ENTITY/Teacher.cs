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
    ///Teacher ��ժҪ˵������ʦʵ��
    /// </summary>

    public class Teacher
    {
        /*��ʦ����*/
        private string _teacherNo;
        public string teacherNo
        {
            get { return _teacherNo; }
            set { _teacherNo = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*����*/
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /*�Ա�*/
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /*��������*/
        private DateTime _birthDate;
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        /*��ʦ��Ƭ*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*��ϵ�绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*����*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
