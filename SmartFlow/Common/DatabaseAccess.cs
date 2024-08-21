using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartFlow
{
    
    public class DatabaseAccess
    {
        public static SqlConnection conn;
        private static SqlConnection ConnOpen() 
        {
            if(conn == null)
            {
                /*conn = new SqlConnection(@"Data Source=10.255.254.241,1433;Initial Catalog=SmartFlow;User id=fabt;Password=Fabt101;");*/
                conn = new SqlConnection(@"Data Source=DESKTOP-1D6LU8Q\SQLEXPRESS;Initial Catalog=SmartFlow;Integrated Security=True;Encrypt=False");
            }

            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }
        public static bool Insert(String query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
            finally { conn.Close(); }
        }
        public static int InsertId(string query)
        {
            try
            {
                int generatedId = 0;
                SqlCommand cmd = new SqlCommand(query,ConnOpen());
                generatedId = Convert.ToInt32(cmd.ExecuteScalar());
                if (generatedId > 0)
                {
                    return generatedId;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex) { throw ex; }
            finally { conn.Close(); }
        }
        public static bool Update(String query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
            finally { conn.Close(); }
        }
        public static bool Delete(String query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
            finally { conn.Close(); }
        }
        public static DataTable Retrive(String query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch { throw; }
            finally { conn.Close(); }
        }
    }
}
