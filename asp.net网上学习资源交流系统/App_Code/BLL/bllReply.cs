using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ҵ���߼���*/
    public class bllReply{
        /*��Ӵ�*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.AddReply(reply);
        }

        /*����replyId��ȡĳ���𸴼�¼*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            return DAL.dalReply.getSomeReply(replyId);
        }

        /*���´�*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.EditReply(reply);
        }

        /*ɾ����*/
        public static bool DelReply(string p)
        {
            return DAL.dalReply.DelReply(p);
        }

        /*��ѯ��*/
        public static System.Data.DataSet GetReply(string strWhere)
        {
            return DAL.dalReply.GetReply(strWhere);
        }

        /*����������ҳ��ѯ��*/
        public static System.Data.DataTable GetReply(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReply.GetReply(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĴ�*/
        public static System.Data.DataSet getAllReply()
        {
            return DAL.dalReply.getAllReply();
        }
    }
}
