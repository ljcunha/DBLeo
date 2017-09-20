using DB.Leo.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace DB.Leo.Lib.Implementations.Factories
{
    public class ConnectionFactory
    {

        
        private static SqlConnection[] poolInstancia = new SqlConnection[9];


        public static SqlConnection getInstancia(ConnectionEnum enConn)
        {
            if (poolInstancia[Convert.ToInt32(enConn)] == null) { new Conexao(enConn); }

            return poolInstancia[Convert.ToInt32(enConn)];
        }

        public static bool DestruirInstancias()
        {
            try
            {
                for (int i = 0; i < poolInstancia.Count(); i++)
                {
                    if (poolInstancia[i] != null)
                    {
                        poolInstancia[i].Close();
                    }
                    poolInstancia[i] = null;
                }

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
