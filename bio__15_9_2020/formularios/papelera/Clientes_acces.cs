using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace bio
{
    class Clientes_acces
    {



        // metodo utilizado para insertar los registros  en la la tabla Empleado

        public static void Insert(string Cedula, string FechaExpCed, string LugarExpCed, string TipoCed, string Nombre, string Apellidos, string Direccion, string Ciudad, string Telefono, string Celular, string Email
            , string Ocupacion, string Observaciones, string FechaCrea, string FechaMod, string HoraCrea, string HoraMod, string TipoTP, string TP, string Sexo, string EstadoCivil, string FechaNacimiento, string LugarNacimiento, string Padre
            , string Madre, string RegistroCivilNotaria, string RegistroCivilFolio, string RegistroCivilFecha, byte[] foto, byte[] huella, byte[] firma)
        {
            OleDbConnection conn = bd_comun_acces.ObtenerConexion();

            {
                string query = "INSERT INTO DatosPersonal (Cedula,FechaExpCed,LugarExpCed,TipoCed,Nombre,Apellidos,Direccion,Ciudad,Telefono,Celular,Email,Ocupacion,Observaciones,FechaCrea,FechaMod,HoraCrea,HoraMod,TipoTP,TP,Sexo,EstadoCivil,FechaNacimiento,LugarNacimiento,Padre,Madre,RegistroCivilNotaria,RegistroCivilFolio,RegistroCivilFecha,foto,huella,firma) VALUES(@Cedula,@FechaExpCed,@LugarExpCed,@TipoCed,@Nombre,@Apellidos,@Direccion,@Ciudad,@Telefono,@Celular,@Email,@Ocupacion,@Observaciones,@FechaCrea,@FechaMod,@HoraCrea,@HoraMod,@TipoTP,@TP,@Sexo,@EstadoCivil,@FechaNacimiento,@LugarNacimiento,@Padre,@Madre,@RegistroCivilNotaria,@RegistroCivilFolio,@RegistroCivilFecha,@foto,@huella,@firma)";
               OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@FechaExpCed", FechaExpCed);
                cmd.Parameters.AddWithValue("@LugarExpCed", LugarExpCed);
                cmd.Parameters.AddWithValue("@TipoCed", TipoCed);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Celular", Celular);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Ocupacion", Ocupacion);
                cmd.Parameters.AddWithValue("@Observaciones", Observaciones );
                cmd.Parameters.AddWithValue("@FechaCrea", FechaCrea);
                cmd.Parameters.AddWithValue("@FechaMod", FechaMod);
                cmd.Parameters.AddWithValue("@HoraCrea", HoraCrea);
                cmd.Parameters.AddWithValue("@HoraMod", HoraMod);
                cmd.Parameters.AddWithValue("@TipoTP", TipoTP);
                cmd.Parameters.AddWithValue("@TP", TP);
                cmd.Parameters.AddWithValue("@Sexo", Sexo);
                cmd.Parameters.AddWithValue("@EstadoCivil", EstadoCivil);
                cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                cmd.Parameters.AddWithValue("@LugarNacimiento", LugarNacimiento);
                cmd.Parameters.AddWithValue("@Padre", Padre);
                cmd.Parameters.AddWithValue("@Madre", Madre);
                cmd.Parameters.AddWithValue("@RegistroCivilNotaria", RegistroCivilNotaria);
                cmd.Parameters.AddWithValue("@RegistroCivilFolio", RegistroCivilFolio);
                cmd.Parameters.AddWithValue("@RegistroCivilFecha", RegistroCivilFecha);
               
                

                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto;
                cmd.Parameters.Add("@huella", SqlDbType.VarBinary).Value = huella;
                cmd.Parameters.Add("@firma", SqlDbType.VarBinary).Value = firma;
               

                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }



                conn.Close();

            }

        }






     

    }
}
