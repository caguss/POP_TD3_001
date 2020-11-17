using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web;
using System.Data;

namespace POP_TD3_001
{
    public class Setting
    {
        public string strIP = string.Empty;
        public string strDataBase = string.Empty;
        public string strID = string.Empty;
        public string strPass = string.Empty;

        public bool load_DBSetting(string xmlFilePath)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFilePath);

                DataTable dt = ds.Tables["DB"];

                strIP = dt.Rows[0]["IP"].ToString();
                strDataBase = dt.Rows[0]["DataBase"].ToString();
                strID = dt.Rows[0]["ID"].ToString();
                strPass = dt.Rows[0]["pass"].ToString();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// DB Connection
        /// </summary>
        public MySqlConnection Dbconn = new MySqlConnection();

        /// <summary>
        /// DB Command 
        /// </summary>
        public MySqlCommand Dbcmd = new MySqlCommand();
        
        /// <summary>
        /// sql 연결스트링
        /// </summary>
        string connectionString = string.Empty;
             

        /// <summary>
        /// DB연결 재시도 횟수 (범위 1~5)
        /// </summary>
        int retryTimes_Connecting = 1;


   


        public Setting()
        {
            if (strIP != string.Empty || strIP =="")
                Set_ConnectionString(strIP, strDataBase, strID, strPass);
        }



        /// <summary>
        /// 연결스트링을 설정합니다.
        /// </summary>
        /// <param name="strServer">서버 IP / 이름</param>
        /// <param name="strDB">DataBase이름</param>
        /// <param name="strID">ID</param>
        /// <param name="strPassword">Password</param>
        public void Set_ConnectionString(string strServer, string strDB, string strID, string strPassword)
        {
            strServer = "m.coever.co.kr";
            strDB = "corechips_opc";
            strID = "dbmes";
            strPassword = "dbmes1!";

            this.connectionString = string.Format("Server={0};database={1};uid={2};pwd={3}", strServer, strDB, strID, strPassword);            
        }



        /// <summary>
        /// Db를 연결한다.
        /// </summary>
        /// <returns></returns>
        public bool DB_Open()
        {
            int Count = 1;
            while (this.retryTimes_Connecting >= Count)
            {
                try
                {
                    Count++;

                    if (db_Open())
                        return true;
                }
                catch (Exception ex)
                {
                    if (Count == retryTimes_Connecting) throw ex;
                }

            }

            return false;

        }
        private bool db_Open()
        {
            try
            {
                if (this.connectionString == string.Empty)
                    throw new Exception("연결 스트링 설정이 되어 있지 않습니다.");

                Dbconn.ConnectionString = this.connectionString;

                Dbconn.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// db를 닫는다.
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool DB_Close()
        {
            try
            {

                Dbconn.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// db가 연결 상태인가를 체크
        /// </summary>
        /// <returns></returns>
        public bool DB_isOpen()
        {
            try
            {
                if (Dbconn.State == System.Data.ConnectionState.Open || Dbconn.State == System.Data.ConnectionState.Connecting)
                    return true;
                else
                    return this.db_Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

