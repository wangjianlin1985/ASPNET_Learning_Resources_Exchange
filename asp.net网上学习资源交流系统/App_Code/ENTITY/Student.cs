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
    ///Student ��ժҪ˵����ѧ��ʵ��
    /// </summary>

    public class Student
    {
        /*ѧ��*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
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

        /*�û���Ƭ*/
        private string _userPhoto;
        public string userPhoto
        {
            get { return _userPhoto; }
            set { _userPhoto = value; }
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

        /*��ͥ��ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*ע��ʱ��*/
        private DateTime _regTime;
        public DateTime regTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }

    }
}
