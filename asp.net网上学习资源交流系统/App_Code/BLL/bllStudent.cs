using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ��ҵ���߼���*/
    public class bllStudent{
        /*���ѧ��*/
        public static bool AddStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.AddStudent(student);
        }

        /*����studentNumber��ȡĳ��ѧ����¼*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            return DAL.dalStudent.getSomeStudent(studentNumber);
        }

        /*����ѧ��*/
        public static bool EditStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.EditStudent(student);
        }

        /*ɾ��ѧ��*/
        public static bool DelStudent(string p)
        {
            return DAL.dalStudent.DelStudent(p);
        }

        /*��ѯѧ��*/
        public static System.Data.DataSet GetStudent(string strWhere)
        {
            return DAL.dalStudent.GetStudent(strWhere);
        }

        /*����������ҳ��ѯѧ��*/
        public static System.Data.DataTable GetStudent(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudent.GetStudent(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ��*/
        public static System.Data.DataSet getAllStudent()
        {
            return DAL.dalStudent.getAllStudent();
        }
    }
}
