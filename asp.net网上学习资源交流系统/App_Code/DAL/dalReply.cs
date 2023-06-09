using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ҵ���߼���ʵ��*/
    public class dalReply
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӵ�ʵ��*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            string sql = "insert into Reply(questionObj,replyContent,replyTime,teacherObj) values(@questionObj,@replyContent,@replyTime,@teacherObj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@questionObj",SqlDbType.Int),
             new SqlParameter("@replyContent",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = reply.questionObj; //�ش������
            parm[1].Value = reply.replyContent; //������
            parm[2].Value = reply.replyTime; //��ʱ��
            parm[3].Value = reply.teacherObj; //�ش����ʦ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����replyId��ȡĳ���𸴼�¼*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            /*������ѯsql*/
            string sql = "select * from Reply where replyId=" + replyId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Reply reply = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                reply = new ENTITY.Reply();
                reply.replyId = Convert.ToInt32(DataRead["replyId"]);
                reply.questionObj = Convert.ToInt32(DataRead["questionObj"]);
                reply.replyContent = DataRead["replyContent"].ToString();
                reply.replyTime = Convert.ToDateTime(DataRead["replyTime"].ToString());
                reply.teacherObj = DataRead["teacherObj"].ToString();
            }
            return reply;
        }

        /*���´�ʵ��*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            string sql = "update Reply set questionObj=@questionObj,replyContent=@replyContent,replyTime=@replyTime,teacherObj=@teacherObj where replyId=@replyId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@questionObj",SqlDbType.Int),
             new SqlParameter("@replyContent",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@replyId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = reply.questionObj;
            parm[1].Value = reply.replyContent;
            parm[2].Value = reply.replyTime;
            parm[3].Value = reply.teacherObj;
            parm[4].Value = reply.replyId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����*/
        public static bool DelReply(string p)
        {
            string sql = "delete from Reply where replyId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��*/
        public static DataSet GetReply(string strWhere)
        {
            try
            {
                string strSql = "select * from Reply" + strWhere + " order by replyId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��*/
        public static System.Data.DataTable GetReply(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Reply";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "replyId", strShow, strSql, strWhere, " replyId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllReply()
        {
            try
            {
                string strSql = "select * from Reply";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
