﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public sealed class DataProvider
    {
        //private static string ConStr = @"Data Source=.\sqlexpress;Initial Catalog=CoffeeManagement;Integrated Security=True";        
        private static string ConStr = @"Data Source=DESKTOP-JSTLVFR\SQLEXPRESS;Initial Catalog=DutraManagement;Integrated Security=True;Encrypt=False";
        public SqlConnection con { get; set; }
        private static DataProvider _instance;
        private DataProvider()
        {
            con = new SqlConnection(ConStr);
        }
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DataProvider();
                return _instance;
            }
            private set => _instance = value;

        }
        public DataTable ExecuteTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (SqlException)
            {
                //MessageBox.Show("Đã có lỗi xảy ra hãy kiểm tra lại thông tin !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã có lỗi xảy ra hãy kiểm tra lại thông tin !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void ExecuteNonQuery1(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                //MessageBox.Show("Đã có lỗi xảy ra hãy kiểm tra lại thông tin !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public string ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                return cmd.ExecuteScalar().ToString();
            }
            catch (SqlException)
            {
                //MessageBox.Show("Đã có lỗi xảy ra hãy kiểm tra lại thông tin !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
