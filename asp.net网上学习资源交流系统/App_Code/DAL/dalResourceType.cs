using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*资源分类业务逻辑层实现*/
    public class dalResourceType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加资源分类实现*/
        public static bool AddResourceType(ENTITY.ResourceType resourceType)
        {
            string sql = "insert into ResourceType(resourceTypeName,resourceTypeDesc) values(@resourceTypeName,@resourceTypeDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeName",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = resourceType.resourceTypeName; //资源分类名称
            parm[1].Value = resourceType.resourceTypeDesc; //分类描述

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据resourceTypeId获取某条资源分类记录*/
        public static ENTITY.ResourceType getSomeResourceType(int resourceTypeId)
        {
            /*构建查询sql*/
            string sql = "select * from ResourceType where resourceTypeId=" + resourceTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ResourceType resourceType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                resourceType = new ENTITY.ResourceType();
                resourceType.resourceTypeId = Convert.ToInt32(DataRead["resourceTypeId"]);
                resourceType.resourceTypeName = DataRead["resourceTypeName"].ToString();
                resourceType.resourceTypeDesc = DataRead["resourceTypeDesc"].ToString();
            }
            return resourceType;
        }

        /*更新资源分类实现*/
        public static bool EditResourceType(ENTITY.ResourceType resourceType)
        {
            string sql = "update ResourceType set resourceTypeName=@resourceTypeName,resourceTypeDesc=@resourceTypeDesc where resourceTypeId=@resourceTypeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeName",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = resourceType.resourceTypeName;
            parm[1].Value = resourceType.resourceTypeDesc;
            parm[2].Value = resourceType.resourceTypeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除资源分类*/
        public static bool DelResourceType(string p)
        {
            string sql = "delete from ResourceType where resourceTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询资源分类*/
        public static DataSet GetResourceType(string strWhere)
        {
            try
            {
                string strSql = "select * from ResourceType" + strWhere + " order by resourceTypeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询资源分类*/
        public static System.Data.DataTable GetResourceType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ResourceType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "resourceTypeId", strShow, strSql, strWhere, " resourceTypeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllResourceType()
        {
            try
            {
                string strSql = "select * from ResourceType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
