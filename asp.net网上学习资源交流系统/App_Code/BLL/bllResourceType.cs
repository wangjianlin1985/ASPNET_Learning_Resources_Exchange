using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Դ����ҵ���߼���*/
    public class bllResourceType{
        /*�����Դ����*/
        public static bool AddResourceType(ENTITY.ResourceType resourceType)
        {
            return DAL.dalResourceType.AddResourceType(resourceType);
        }

        /*����resourceTypeId��ȡĳ����Դ�����¼*/
        public static ENTITY.ResourceType getSomeResourceType(int resourceTypeId)
        {
            return DAL.dalResourceType.getSomeResourceType(resourceTypeId);
        }

        /*������Դ����*/
        public static bool EditResourceType(ENTITY.ResourceType resourceType)
        {
            return DAL.dalResourceType.EditResourceType(resourceType);
        }

        /*ɾ����Դ����*/
        public static bool DelResourceType(string p)
        {
            return DAL.dalResourceType.DelResourceType(p);
        }

        /*��ѯ��Դ����*/
        public static System.Data.DataSet GetResourceType(string strWhere)
        {
            return DAL.dalResourceType.GetResourceType(strWhere);
        }

        /*����������ҳ��ѯ��Դ����*/
        public static System.Data.DataTable GetResourceType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalResourceType.GetResourceType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Դ����*/
        public static System.Data.DataSet getAllResourceType()
        {
            return DAL.dalResourceType.getAllResourceType();
        }
    }
}
