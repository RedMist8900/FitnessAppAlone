﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataStorage
{
    public class SqlAccess
    {
        SqlConnection connection = null;

        public SqlAccess()
        {
            Connection();
        }

        public bool Connection()
        {
            string cs; // connection string (shorted for document space)
            cs = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=FitnessAppDB";
            connection = new SqlConnection();
            connection.ConnectionString = cs;
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public DataTable ExecuteSql(string sql)
        {
            // Open new connection.
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            // Create sql command.
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            // Exceute sql command
            DataTable table = ExecuteCmd(cmd);
            // Close the connetion.
            connection.Close();
            return table;
        }

        private DataTable ExecuteCmd(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            return table;
        }
    }
}
