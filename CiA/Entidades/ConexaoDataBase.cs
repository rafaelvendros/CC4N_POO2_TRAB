using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace CiA.Entidades
{
    class ConexaoDataBase
    {
        public SQLiteConnection myConnection;

        public ConexaoDataBase()
        {
            myConnection = new SQLiteConnection("Data Source = cia.sqlite3");

            if (!File.Exists("./cia.sqlite3"))
            {
                SQLiteConnection.CreateFile("cia.sqlite3");
                Console.WriteLine("Arquivo do Banco de Dados Gerados");
            }
        }

        public void OpenConnection() 
        {
            if (myConnection.State != System.Data.ConnectionState.Open) 
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
