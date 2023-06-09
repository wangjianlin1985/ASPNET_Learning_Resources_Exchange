using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学生业务逻辑层实现*/
    public class dalStudent
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学生实现*/
        public static bool AddStudent(ENTITY.Student student)
        {
            string sql = "insert into Student(studentNumber,password,name,gender,birthDate,userPhoto,telephone,email,address,regTime) values(@studentNumber,@password,@name,@gender,@birthDate,@userPhoto,@telephone,@email,@address,@regTime)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = student.studentNumber; //学号
            parm[1].Value = student.password; //登录密码
            parm[2].Value = student.name; //姓名
            parm[3].Value = student.gender; //性别
            parm[4].Value = student.birthDate; //出生日期
            parm[5].Value = student.userPhoto; //用户照片
            parm[6].Value = student.telephone; //联系电话
            parm[7].Value = student.email; //邮箱
            parm[8].Value = student.address; //家庭地址
            parm[9].Value = student.regTime; //注册时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据studentNumber获取某条学生记录*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            /*构建查询sql*/
            string sql = "select * from Student where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student student = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新学生实现*/
        public static bool EditStudent(ENTITY.Student student)
        {
            string sql = "update Student set password=@password,name=@name,gender=@gender,birthDate=@birthDate,userPhoto=@userPhoto,telephone=@telephone,email=@email,address=@address,regTime=@regTime where studentNumber=@studentNumber";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
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
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学生*/
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


        /*查询学生*/
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

        /*查询学生*/
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
