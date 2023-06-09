using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*问题业务逻辑层实现*/
    public class dalQuestion
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加问题实现*/
        public static bool AddQuestion(ENTITY.Question question)
        {
            string sql = "insert into Question(title,content,studentObj,questionTime) values(@title,@content,@studentObj,@questionTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@questionTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = question.title; //问题标题
            parm[1].Value = question.content; //问题描述
            parm[2].Value = question.studentObj; //提问人
            parm[3].Value = question.questionTime; //提问时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据questionId获取某条问题记录*/
        public static ENTITY.Question getSomeQuestion(int questionId)
        {
            /*构建查询sql*/
            string sql = "select * from Question where questionId=" + questionId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Question question = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新问题实现*/
        public static bool EditQuestion(ENTITY.Question question)
        {
            string sql = "update Question set title=@title,content=@content,studentObj=@studentObj,questionTime=@questionTime where questionId=@questionId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@questionTime",SqlDbType.DateTime),
             new SqlParameter("@questionId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = question.title;
            parm[1].Value = question.content;
            parm[2].Value = question.studentObj;
            parm[3].Value = question.questionTime;
            parm[4].Value = question.questionId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除问题*/
        public static bool DelQuestion(string p)
        {
            string sql = "delete from Question where questionId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询问题*/
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

        /*查询问题*/
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
