using System;
using System.Data;
using Microsoft.Data.SqlClient;

public static class DBEngine
{
    private static int result = 0;
    internal static bool ExecuteNonQuery(string connectionString, string query)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Dispose();
        }

    }

    public static string ExecuteScaler(string connectionString, string query)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
            string value = null;
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            var firstColumn = cmd.ExecuteScalar();

            if (firstColumn != null)
            {
                value = firstColumn.ToString();
            }
            return value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Dispose();
        }

    }

    internal static DataSet GetDataSet(string connectionString, string query, string filterText)
    {

        SqlConnection conn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@filterText", filterText);
            cmd.Connection = conn;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            adpt.Dispose();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Dispose();
        }

    }

    internal static DataSet GetDataSet(string connectionString, string query)
    {

        SqlConnection conn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            adpt.Dispose();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Dispose();
        }

    }

    public static DataTable GetDataTable(string connectionString, string query)
    {
        DataTable dt = new DataTable();
        dt = GetDataSet(connectionString, query).Tables[0];
        return dt;
    }

    public static DataTable GetDataTable(string connectionString, string query, string filterText)
    {
        DataTable dt = new DataTable();
        dt = GetDataSet(connectionString, query, filterText).Tables[0];
        return dt;
    }

}