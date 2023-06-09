using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*资源分类业务逻辑层*/
    public class bllResourceType{
        /*添加资源分类*/
        public static bool AddResourceType(ENTITY.ResourceType resourceType)
        {
            return DAL.dalResourceType.AddResourceType(resourceType);
        }

        /*根据resourceTypeId获取某条资源分类记录*/
        public static ENTITY.ResourceType getSomeResourceType(int resourceTypeId)
        {
            return DAL.dalResourceType.getSomeResourceType(resourceTypeId);
        }

        /*更新资源分类*/
        public static bool EditResourceType(ENTITY.ResourceType resourceType)
        {
            return DAL.dalResourceType.EditResourceType(resourceType);
        }

        /*删除资源分类*/
        public static bool DelResourceType(string p)
        {
            return DAL.dalResourceType.DelResourceType(p);
        }

        /*查询资源分类*/
        public static System.Data.DataSet GetResourceType(string strWhere)
        {
            return DAL.dalResourceType.GetResourceType(strWhere);
        }

        /*根据条件分页查询资源分类*/
        public static System.Data.DataTable GetResourceType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalResourceType.GetResourceType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的资源分类*/
        public static System.Data.DataSet getAllResourceType()
        {
            return DAL.dalResourceType.getAllResourceType();
        }
    }
}
