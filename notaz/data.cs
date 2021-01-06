
using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace notaz
{
    internal class data
    {
        //string cs = @"Data Source=D:\personal projects\notaz\notaz\bin\Debug\database.db;";
        SQLiteConnection con = new SQLiteConnection(@"Data Source=database.db;Version=3;");

        public data()
        {

        }

        public DataTable getTable(string table, string conditionals)
        {
            try
            {
                if (conditionals == string.Empty)
                {
                    conditionals = "1=1";
                }

                abrir();
                string mSQL = "Select * from " + table + " where " + conditionals;
                SQLiteCommand cmd = new SQLiteCommand(mSQL, ver());
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SQLiteException fbex)
            {
                throw fbex;
            }
            finally
            {
                cerrar();
            }
        }

        public void save(string table, string fields, string values)
        {
            try
            {
                string sql = "INSERT INTO " + table + " (" + fields + ")VALUES(" + values + ")";
                abrir();
                SQLiteCommand comando = new SQLiteCommand();
                comando.CommandText = sql;
                comando.Connection = ver();
                comando.ExecuteNonQuery();
                cerrar();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                cerrar();
            }
        }

        public void update(string table, string modifications, string where)
        {
            try
            {
                string sql = "update "+table+" set "+modifications+" where "+where;
                abrir();
                SQLiteCommand comando = new SQLiteCommand();
                comando.CommandText = sql;
                comando.Connection = ver();
                comando.ExecuteNonQuery();
                cerrar();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                cerrar();
            }
        }

        public int getCount(string table, string conditionals)
        {
            try
            {
                if (conditionals == string.Empty)
                {
                    conditionals = " where 1=1;";
                }
                else
                {
                    conditionals = " where " + conditionals;
                }
                abrir();
                SQLiteCommand cmd = new SQLiteCommand(ver());
                cmd.CommandText = "select * from " + table + conditionals;
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                    reader.Read();
                int total_rows_in_resultset = reader.StepCount;
                return total_rows_in_resultset;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.ToString());                
                return 0;
            }
            finally
            {
                cerrar();
            }

        }

        private SQLiteConnection ver()
        {
            return con;
        }

        public bool insert()
        {
            try
            {
                abrir();
                
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "INSERT INTO cars(name, price) VALUES(@name, @price)";

                cmd.Parameters.AddWithValue("@name", "BMW");
                cmd.Parameters.AddWithValue("@price", 36600);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Console.WriteLine("row inserted");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                cerrar();
            }
        }

        public void abrir()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            else
            {
                cerrar();
                abrir();
            }
        }
        public void cerrar()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }


    }
}