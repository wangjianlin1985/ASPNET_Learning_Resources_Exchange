using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学习资源业务逻辑层*/
    public class bllResource{
        /*添加学习资源*/
        public static bool AddResource(ENTITY.Resource resource)
        {
            return DAL.dalResource.AddResource(resource);
        }

        /*根据resourceId获取某条学习资源记录*/
        public static ENTITY.Resource getSomeResource(int resourceId)
        {
            return DAL.dalResource.getSomeResource(resourceId);
        }

        /*更新学习资源*/
        public static bool EditResource(ENTITY.Resource resource)
        {
            return DAL.dalResource.EditResource(resource);
        }

        /*删除学习资源*/
        public static bool DelResource(string p)
        {
            return DAL.dalResource.DelResource(p);
        }

        /*查询学习资源*/
        public static System.Data.DataSet GetResource(string strWhere)
        {
            return DAL.dalResource.GetResource(strWhere);
        }

        /*根据条件分页查询学习资源*/
        public static System.Data.DataTable GetResource(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalResource.GetResource(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学习资源*/
        public static System.Data.DataSet getAllResource()
        {
            return DAL.dalResource.getAllResource();
        }
    }
}
