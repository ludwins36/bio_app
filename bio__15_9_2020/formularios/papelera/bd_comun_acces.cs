using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using bio.Properties;
namespace bio
{
    class bd_comun_acces
    {
       

            public static string obtenerstring()
            {

                return Settings.Default.autenticacionConnectionString;
            }



            public static OleDbConnection ObtenerConexion()
            {
                OleDbConnection conectar = new OleDbConnection(obtenerstring());
                conectar.Open();
                return conectar;
            }
       

    }
}
