using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧϰ��Դҵ���߼���*/
    public class bllResource{
        /*���ѧϰ��Դ*/
        public static bool AddResource(ENTITY.Resource resource)
        {
            return DAL.dalResource.AddResource(resource);
        }

        /*����resourceId��ȡĳ��ѧϰ��Դ��¼*/
        public static ENTITY.Resource getSomeResource(int resourceId)
        {
            return DAL.dalResource.getSomeResource(resourceId);
        }

        /*����ѧϰ��Դ*/
        public static bool EditResource(ENTITY.Resource resource)
        {
            return DAL.dalResource.EditResource(resource);
        }

        /*ɾ��ѧϰ��Դ*/
        public static bool DelResource(string p)
        {
            return DAL.dalResource.DelResource(p);
        }

        /*��ѯѧϰ��Դ*/
        public static System.Data.DataSet GetResource(string strWhere)
        {
            return DAL.dalResource.GetResource(strWhere);
        }

        /*����������ҳ��ѯѧϰ��Դ*/
        public static System.Data.DataTable GetResource(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalResource.GetResource(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧϰ��Դ*/
        public static System.Data.DataSet getAllResource()
        {
            return DAL.dalResource.getAllResource();
        }
    }
}
