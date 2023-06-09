using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalQuestion
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddQuestion(ENTITY.Question question)
        {
            string sql = "insert into Question(title,content,studentObj,questionTime) values(@title,@content,@studentObj,@questionTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@questionTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = question.title; //�������
            parm[1].Value = question.content; //��������
            parm[2].Value = question.studentObj; //������
            parm[3].Value = question.questionTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����questionId��ȡĳ�������¼*/
        public static ENTITY.Question getSomeQuestion(int questionId)
        {
            /*������ѯsql*/
            string sql = "select * from Question where questionId=" + questionId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Question question = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                question = new ENTITY.Question();
                question.questionId = Convert.ToInt32(DataRead["questionId"]);
                question.title = DataRead["title"].ToString();
                question.content = DataRead["content"].ToString();
                question.studentObj = DataRead["studentObj"].ToString();
                question.questionTime = Convert.ToDateTime(DataRead["questionTime"].ToString());
            }
            return question;
        }

        /*��������ʵ��*/
        public static bool EditQuestion(ENTITY.Question question)
        {
            string sql = "update Question set title=@title,content=@content,studentObj=@studentObj,questionTime=@questionTime where questionId=@questionId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@questionTime",SqlDbType.DateTime),
             new SqlParameter("@questionId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = question.title;
            parm[1].Value = question.content;
            parm[2].Value = question.studentObj;
            parm[3].Value = question.questionTime;
            parm[4].Value = question.questionId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelQuestion(string p)
        {
            string sql = "delete from Question where questionId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetQuestion(string strWhere)
        {
            try
            {
                string strSql = "select * from Question" + strWhere + " order by questionId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����*/
        public static System.Data.DataTable GetQuestion(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Question";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "questionId", strShow, strSql, strWhere, " questionId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllQuestion()
        {
            try
            {
                string strSql = "select * from Question";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
