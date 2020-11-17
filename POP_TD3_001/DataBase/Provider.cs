using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace POP_TD3_001
{
    public class Provider
    {


        public DataTable Machine_Refresh(string res_id)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();

            cmd = sett.Dbcmd;
            DataTable dt = new DataTable();
            cmd.CommandText = "test";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@p_res_id", MySqlDbType.VarChar, 8));
            //cmd.Parameters.Add(new MySqlParameter("@v_server_code", MySqlDbType.Int32));

            cmd.Parameters["@p_res_id"].Value = res_id;
            //cmd.Parameters["@v_server_code"].Value = userinfo[1];
            if (sett.DB_Open())
            {
                MySqlDataReader reader;

                reader = cmd.ExecuteReader();
                dt = this.GetTable(reader);


                sett.DB_Close();
            }
            

          
       

            return dt;


        }

        public void Change_Connection()
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Change_Connection";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            //cmd.Parameters.Add(new MySqlParameter("@v_company_code", MySqlDbType.Int32));
            //cmd.Parameters.Add(new MySqlParameter("@v_server_code", MySqlDbType.Int32));

            //cmd.Parameters["@v_company_code"].Value = userinfo[0];
            //cmd.Parameters["@v_server_code"].Value = userinfo[1];
            sett.DB_Open();

            cmd.ExecuteNonQuery();


            sett.DB_Close();

        }

        public DataTable Machine_List()
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            DataTable dt = new DataTable();
            cmd.CommandText = "Machine_List_R10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            //cmd.Parameters.Add(new MySqlParameter("@v_company_code", MySqlDbType.Int32));
            //cmd.Parameters.Add(new MySqlParameter("@v_server_code", MySqlDbType.Int32));

            //cmd.Parameters["@v_company_code"].Value = userinfo[0];
            //cmd.Parameters["@v_server_code"].Value = userinfo[1];
            sett.DB_Open();

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            dt = this.GetTable(reader);


            sett.DB_Close();


            return dt;
        }

        public System.Data.DataTable GetTable(MySqlDataReader reader)
        {
            System.Data.DataTable table = reader.GetSchemaTable();
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataColumn dc;
            System.Data.DataRow row;
            System.Collections.ArrayList aList = new System.Collections.ArrayList();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                dc = new System.Data.DataColumn();

                if (!dt.Columns.Contains(table.Rows[i]["ColumnName"].ToString()))
                {
                    dc.ColumnName = table.Rows[i]["ColumnName"].ToString();
                    dc.Unique = Convert.ToBoolean(table.Rows[i]["IsUnique"]);
                    dc.AllowDBNull = Convert.ToBoolean(table.Rows[i]["AllowDBNull"]);
                    dc.ReadOnly = Convert.ToBoolean(table.Rows[i]["IsReadOnly"]);
                    aList.Add(dc.ColumnName);
                    dt.Columns.Add(dc);
                }
            }

            while (reader.Read())
            {
                row = dt.NewRow();
                for (int i = 0; i < aList.Count; i++)
                {
                    row[((string)aList[i])] = reader[(string)aList[i]];
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}