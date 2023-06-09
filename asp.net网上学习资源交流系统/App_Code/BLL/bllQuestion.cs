using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*问题业务逻辑层*/
    public class bllQuestion{
        /*添加问题*/
        public static bool AddQuestion(ENTITY.Question question)
        {
            return DAL.dalQuestion.AddQuestion(question);
        }

        /*根据questionId获取某条问题记录*/
        public static ENTITY.Question getSomeQuestion(int questionId)
        {
            return DAL.dalQuestion.getSomeQuestion(questionId);
        }

        /*更新问题*/
        public static bool EditQuestion(ENTITY.Question question)
        {
            return DAL.dalQuestion.EditQuestion(question);
        }

        /*删除问题*/
        public static bool DelQuestion(string p)
        {
            return DAL.dalQuestion.DelQuestion(p);
        }

        /*查询问题*/
        public static System.Data.DataSet GetQuestion(string strWhere)
        {
            return DAL.dalQuestion.GetQuestion(strWhere);
        }

        /*根据条件分页查询问题*/
        public static System.Data.DataTable GetQuestion(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalQuestion.GetQuestion(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的问题*/
        public static System.Data.DataSet getAllQuestion()
        {
            return DAL.dalQuestion.getAllQuestion();
        }
    }
}
