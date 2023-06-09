using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllQuestion{
        /*�������*/
        public static bool AddQuestion(ENTITY.Question question)
        {
            return DAL.dalQuestion.AddQuestion(question);
        }

        /*����questionId��ȡĳ�������¼*/
        public static ENTITY.Question getSomeQuestion(int questionId)
        {
            return DAL.dalQuestion.getSomeQuestion(questionId);
        }

        /*��������*/
        public static bool EditQuestion(ENTITY.Question question)
        {
            return DAL.dalQuestion.EditQuestion(question);
        }

        /*ɾ������*/
        public static bool DelQuestion(string p)
        {
            return DAL.dalQuestion.DelQuestion(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetQuestion(string strWhere)
        {
            return DAL.dalQuestion.GetQuestion(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetQuestion(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalQuestion.GetQuestion(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�����*/
        public static System.Data.DataSet getAllQuestion()
        {
            return DAL.dalQuestion.getAllQuestion();
        }
    }
}
