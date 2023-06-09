using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Դ����ҵ���߼���ʵ��*/
    public class dalResourceType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Դ����ʵ��*/
        public static bool AddResourceType(ENTITY.ResourceType resourceType)
        {
            string sql = "insert into ResourceType(resourceTypeName,resourceTypeDesc) values(@resourceTypeName,@resourceTypeDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeName",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = resourceType.resourceTypeName; //��Դ��������
            parm[1].Value = resourceType.resourceTypeDesc; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����resourceTypeId��ȡĳ����Դ�����¼*/
        public static ENTITY.ResourceType getSomeResourceType(int resourceTypeId)
        {
            /*������ѯsql*/
            string sql = "select * from ResourceType where resourceTypeId=" + resourceTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ResourceType resourceType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                resourceType = new ENTITY.ResourceType();
                resourceType.resourceTypeId = Convert.ToInt32(DataRead["resourceTypeId"]);
                resourceType.resourceTypeName = DataRead["resourceTypeName"].ToString();
                resourceType.resourceTypeDesc = DataRead["resourceTypeDesc"].ToString();
            }
            return resourceType;
        }

        /*������Դ����ʵ��*/
        public static bool EditResourceType(ENTITY.ResourceType resourceType)
        {
            string sql = "update ResourceType set resourceTypeName=@resourceTypeName,resourceTypeDesc=@resourceTypeDesc where resourceTypeId=@resourceTypeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@resourceTypeName",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeDesc",SqlDbType.VarChar),
             new SqlParameter("@resourceTypeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = resourceType.resourceTypeName;
            parm[1].Value = resourceType.resourceTypeDesc;
            parm[2].Value = resourceType.resourceTypeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Դ����*/
        public static bool DelResourceType(string p)
        {
            string sql = "delete from ResourceType where resourceTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Դ����*/
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

        /*��ѯ��Դ����*/
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
