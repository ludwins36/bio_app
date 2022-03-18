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
    class bd_comun
    {
       

            public static string obtenerstring()
            {

                return Settings.Default.notariaConnectionString;
            }



            public static string obtenerstring_de_la_otra_bd()
            {

                return Settings.Default.VerDBConnectionString;
            }





            public static SqlConnection ObtenerConexion()
            {
                SqlConnection conectar = new SqlConnection(obtenerstring());
                conectar.Open();
                return conectar;
            }


            public static SqlConnection ObtenerConexion_de_la_otra_bd()
            {
                SqlConnection conectar = new SqlConnection(obtenerstring_de_la_otra_bd());
                conectar.Open();
                return conectar;
            }


       

    }
}
