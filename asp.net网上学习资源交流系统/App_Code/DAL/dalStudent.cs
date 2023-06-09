using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ��ҵ���߼���ʵ��*/
    public class dalStudent
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ��ʵ��*/
        public static bool AddStudent(ENTITY.Student student)
        {
            string sql = "insert into Student(studentNumber,password,name,gender,birthDate,userPhoto,telephone,email,address,regTime) values(@studentNumber,@password,@name,@gender,@birthDate,@userPhoto,@telephone,@email,@address,@regTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = student.studentNumber; //ѧ��
            parm[1].Value = student.password; //��¼����
            parm[2].Value = student.name; //����
            parm[3].Value = student.gender; //�Ա�
            parm[4].Value = student.birthDate; //��������
            parm[5].Value = student.userPhoto; //�û���Ƭ
            parm[6].Value = student.telephone; //��ϵ�绰
            parm[7].Value = student.email; //����
            parm[8].Value = student.address; //��ͥ��ַ
            parm[9].Value = student.regTime; //ע��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����studentNumber��ȡĳ��ѧ����¼*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            /*������ѯsql*/
            string sql = "select * from Student where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student student = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                student = new ENTITY.Student();
                student.studentNumber = DataRead["studentNumber"].ToString();
                student.password = DataRead["password"].ToString();
                student.name = DataRead["name"].ToString();
                student.gender = DataRead["gender"].ToString();
                student.birthDate = Convert.ToDateTime(DataRead["birthDate"].ToString());
                student.userPhoto = DataRead["userPhoto"].ToString();
                student.telephone = DataRead["telephone"].ToString();
                student.email = DataRead["email"].ToString();
                student.address = DataRead["address"].ToString();
                student.regTime = Convert.ToDateTime(DataRead["regTime"].ToString());
            }
            return student;
        }

        /*����ѧ��ʵ��*/
        public static bool EditStudent(ENTITY.Student student)
        {
            string sql = "update Student set password=@password,name=@name,gender=@gender,birthDate=@birthDate,userPhoto=@userPhoto,telephone=@telephone,email=@email,address=@address,regTime=@regTime where studentNumber=@studentNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@studentNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = student.password;
            parm[1].Value = student.name;
            parm[2].Value = student.gender;
            parm[3].Value = student.birthDate;
            parm[4].Value = student.userPhoto;
            parm[5].Value = student.telephone;
            parm[6].Value = student.email;
            parm[7].Value = student.address;
            parm[8].Value = student.regTime;
            parm[9].Value = student.studentNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ��*/
        public static bool DelStudent(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Student where studentNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ��*/
        public static DataSet GetStudent(string strWhere)
        {
            try
            {
                string strSql = "select * from Student" + strWhere + " order by studentNumber asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ��*/
        public static System.Data.DataTable GetStudent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Student";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "studentNumber", strShow, strSql, strWhere, " studentNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudent()
        {
            try
            {
                string strSql = "select * from Student";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
