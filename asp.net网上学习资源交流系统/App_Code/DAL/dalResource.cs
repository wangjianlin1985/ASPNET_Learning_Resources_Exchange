using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧϰ��Դҵ���߼���ʵ��*/
    public class dalResource
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧϰ��Դʵ��*/
        public static bool AddResource(ENTITY.Resource resource)
        {
            string sql = "insert into Resource(resourceTypeObj,title,resourceDesc,resourceFile,upTime,studentObj) values(@resourceTypeObj,@title,@resourceDesc,@resourceFile,@upTime,@studentObj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@resourceDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceFile",SqlDbType.VarChar),
             new SqlParameter("@upTime",SqlDbType.DateTime),
             new SqlParameter("@studentObj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = resource.resourceTypeObj; //��Դ���
            parm[1].Value = resource.title; //��Դ����
            parm[2].Value = resource.resourceDesc; //��Դ����
            parm[3].Value = resource.resourceFile; //��Դ�ļ�
            parm[4].Value = resource.upTime; //�ϴ�ʱ��
            parm[5].Value = resource.studentObj; //�ϴ���ѧ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����resourceId��ȡĳ��ѧϰ��Դ��¼*/
        public static ENTITY.Resource getSomeResource(int resourceId)
        {
            /*������ѯsql*/
            string sql = "select * from Resource where resourceId=" + resourceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Resource resource = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                resource = new ENTITY.Resource();
                resource.resourceId = Convert.ToInt32(DataRead["resourceId"]);
                resource.resourceTypeObj = Convert.ToInt32(DataRead["resourceTypeObj"]);
                resource.title = DataRead["title"].ToString();
                resource.resourceDesc = DataRead["resourceDesc"].ToString();
                resource.resourceFile = DataRead["resourceFile"].ToString();
                resource.upTime = Convert.ToDateTime(DataRead["upTime"].ToString());
                resource.studentObj = DataRead["studentObj"].ToString();
            }
            return resource;
        }

        /*����ѧϰ��Դʵ��*/
        public static bool EditResource(ENTITY.Resource resource)
        {
            string sql = "update Resource set resourceTypeObj=@resourceTypeObj,title=@title,resourceDesc=@resourceDesc,resourceFile=@resourceFile,upTime=@upTime,studentObj=@studentObj where resourceId=@resourceId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@resourceDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceFile",SqlDbType.VarChar),
             new SqlParameter("@upTime",SqlDbType.DateTime),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@resourceId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = resource.resourceTypeObj;
            parm[1].Value = resource.title;
            parm[2].Value = resource.resourceDesc;
            parm[3].Value = resource.resourceFile;
            parm[4].Value = resource.upTime;
            parm[5].Value = resource.studentObj;
            parm[6].Value = resource.resourceId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧϰ��Դ*/
        public static bool DelResource(string p)
        {
            string sql = "delete from Resource where resourceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧϰ��Դ*/
        public static DataSet GetResource(string strWhere)
        {
            try
            {
                string strSql = "select * from Resource" + strWhere + " order by resourceId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧϰ��Դ*/
        public static System.Data.DataTable GetResource(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Resource";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "resourceId", strShow, strSql, strWhere, " resourceId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllResource()
        {
            try
            {
                string strSql = "select * from Resource";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
