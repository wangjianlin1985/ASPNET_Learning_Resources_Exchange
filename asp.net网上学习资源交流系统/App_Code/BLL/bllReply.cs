using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*答复业务逻辑层*/
    public class bllReply{
        /*添加答复*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.AddReply(reply);
        }

        /*根据replyId获取某条答复记录*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            return DAL.dalReply.getSomeReply(replyId);
        }

        /*更新答复*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.EditReply(reply);
        }

        /*删除答复*/
        public static bool DelReply(string p)
        {
            return DAL.dalReply.DelReply(p);
        }

        /*查询答复*/
        public static System.Data.DataSet GetReply(string strWhere)
        {
            return DAL.dalReply.GetReply(strWhere);
        }

        /*根据条件分页查询答复*/
        public static System.Data.DataTable GetReply(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReply.GetReply(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的答复*/
        public static System.Data.DataSet getAllReply()
        {
            return DAL.dalReply.getAllReply();
        }
    }
}
