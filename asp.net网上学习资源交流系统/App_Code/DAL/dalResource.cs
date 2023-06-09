using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学习资源业务逻辑层实现*/
    public class dalResource
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学习资源实现*/
        public static bool AddResource(ENTITY.Resource resource)
        {
            string sql = "insert into Resource(resourceTypeObj,title,resourceDesc,resourceFile,upTime,studentObj) values(@resourceTypeObj,@title,@resourceDesc,@resourceFile,@upTime,@studentObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@resourceDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceFile",SqlDbType.VarChar),
             new SqlParameter("@upTime",SqlDbType.DateTime),
             new SqlParameter("@studentObj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = resource.resourceTypeObj; //资源类别
            parm[1].Value = resource.title; //资源标题
            parm[2].Value = resource.resourceDesc; //资源描述
            parm[3].Value = resource.resourceFile; //资源文件
            parm[4].Value = resource.upTime; //上传时间
            parm[5].Value = resource.studentObj; //上传的学生

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据resourceId获取某条学习资源记录*/
        public static ENTITY.Resource getSomeResource(int resourceId)
        {
            /*构建查询sql*/
            string sql = "select * from Resource where resourceId=" + resourceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Resource resource = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新学习资源实现*/
        public static bool EditResource(ENTITY.Resource resource)
        {
            string sql = "update Resource set resourceTypeObj=@resourceTypeObj,title=@title,resourceDesc=@resourceDesc,resourceFile=@resourceFile,upTime=@upTime,studentObj=@studentObj where resourceId=@resourceId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@resourceDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceFile",SqlDbType.VarChar),
             new SqlParameter("@upTime",SqlDbType.DateTime),
             new SqlParameter("@studentObj",SqlDbType.VarChar),
             new SqlParameter("@resourceId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = resource.resourceTypeObj;
            parm[1].Value = resource.title;
            parm[2].Value = resource.resourceDesc;
            parm[3].Value = resource.resourceFile;
            parm[4].Value = resource.upTime;
            parm[5].Value = resource.studentObj;
            parm[6].Value = resource.resourceId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学习资源*/
        public static bool DelResource(string p)
        {
            string sql = "delete from Resource where resourceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学习资源*/
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

        /*查询学习资源*/
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
