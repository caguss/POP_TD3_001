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
            cmd.CommandText = "Machine_Refresh_R10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_res_id", MySqlDbType.VarChar, 8));
            //cmd.Parameters.Add(new MySqlParameter("@v_server_code", MySqlDbType.Int32));

            cmd.Parameters["@v_res_id"].Value = res_id;
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

        public void Product_Out_I10(OrderEntity entity)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Product_Out_I10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_order_id", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_prod_num", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_amount", MySqlDbType.Decimal));
            cmd.Parameters.Add(new MySqlParameter("@v_process", MySqlDbType.VarChar, 10));
            cmd.Parameters.Add(new MySqlParameter("@v_worker", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_product_type", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_remark", MySqlDbType.VarChar, 400));

            cmd.Parameters["@v_order_id"].Value = entity.Order_id;
            cmd.Parameters["@v_prod_num"].Value = entity.Prod_num;
            cmd.Parameters["@v_amount"].Value = entity.Amount;
            cmd.Parameters["@v_process"].Value = entity.Process;
            cmd.Parameters["@v_worker"].Value = entity.Worker;
            cmd.Parameters["@v_product_type"].Value = entity.Product_type;
            cmd.Parameters["@v_remark"].Value = entity.Remark;
            sett.DB_Open();

            cmd.ExecuteNonQuery();


            sett.DB_Close();
        }

        public void Work_Finish_I10(OrderEntity entity)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Work_Finish_I10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_order_id", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_prod_num", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_amount", MySqlDbType.Decimal));
            cmd.Parameters.Add(new MySqlParameter("@v_process", MySqlDbType.VarChar, 10));
            cmd.Parameters.Add(new MySqlParameter("@v_worker", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_product_type", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_remark", MySqlDbType.VarChar, 400));

            cmd.Parameters["@v_order_id"].Value = entity.Order_id;
            cmd.Parameters["@v_prod_num"].Value = entity.Prod_num;
            cmd.Parameters["@v_amount"].Value = entity.Amount;
            cmd.Parameters["@v_process"].Value = entity.Process;
            cmd.Parameters["@v_worker"].Value = entity.Worker;
            cmd.Parameters["@v_product_type"].Value = entity.Product_type;
            cmd.Parameters["@v_remark"].Value = entity.Remark;
            sett.DB_Open();

            cmd.ExecuteNonQuery();


            sett.DB_Close();
        }

        public void Resource_Out(OrderEntity v_entity)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Resource_Out_I10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_order_id", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_prod_num", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_amount", MySqlDbType.Decimal));
            cmd.Parameters.Add(new MySqlParameter("@v_process", MySqlDbType.VarChar, 10));
            cmd.Parameters.Add(new MySqlParameter("@v_worker", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_product_type", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_remark", MySqlDbType.VarChar, 400));

            cmd.Parameters["@v_order_id"].Value = v_entity.Order_id;
            cmd.Parameters["@v_prod_num"].Value = v_entity.Prod_num;
            cmd.Parameters["@v_amount"].Value = v_entity.Amount;
            cmd.Parameters["@v_process"].Value = v_entity.Process;
            cmd.Parameters["@v_worker"].Value = v_entity.Worker;
            cmd.Parameters["@v_product_type"].Value = v_entity.Product_type;
            cmd.Parameters["@v_remark"].Value = v_entity.Remark;
            sett.DB_Open();

            cmd.ExecuteNonQuery();


            sett.DB_Close();
        }

        public void Resource_In(OrderEntity v_entity)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Resource_In_I10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_order_id", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_prod_num", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_amount", MySqlDbType.Decimal));
            cmd.Parameters.Add(new MySqlParameter("@v_process", MySqlDbType.VarChar, 10));
            cmd.Parameters.Add(new MySqlParameter("@v_worker", MySqlDbType.VarChar, 20));
            cmd.Parameters.Add(new MySqlParameter("@v_product_type", MySqlDbType.VarChar, 30));
            cmd.Parameters.Add(new MySqlParameter("@v_remark", MySqlDbType.VarChar, 400));

            cmd.Parameters["@v_order_id"].Value = v_entity.Order_id;
            cmd.Parameters["@v_prod_num"].Value = v_entity.Prod_num;
            cmd.Parameters["@v_amount"].Value = v_entity.Amount;
            cmd.Parameters["@v_process"].Value = v_entity.Process;
            cmd.Parameters["@v_worker"].Value = v_entity.Worker;
            cmd.Parameters["@v_product_type"].Value = v_entity.Product_type;
            cmd.Parameters["@v_remark"].Value = v_entity.Remark;
            sett.DB_Open();

            cmd.ExecuteNonQuery();


            sett.DB_Close();
        }

        public void Change_Connection(string machine_name)
        {
            MySqlCommand cmd = new MySqlCommand();
            Setting sett = new Setting();
            cmd = sett.Dbcmd;
            cmd.CommandText = "Change_Connection";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sett.Dbconn;

            cmd.Parameters.Add(new MySqlParameter("@v_machine_name", MySqlDbType.VarChar, 8));

            cmd.Parameters["@v_machine_name"].Value = machine_name;
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