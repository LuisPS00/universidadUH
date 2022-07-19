using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace universidadUH
{
    public class ClsUsuario
    {
        private static bool existe;

        /* Atributos de la clase */
        private static string nombre { get; set; }
        private static string clave { get; set; }

        public static int Codigo { get; set; }
        // Constructor de la clase
        public ClsUsuario(string nom, string contrasena)
        {
            nombre = nom;
            clave = contrasena;
        }


        /* Metodos de la clase Get = devolver un valor  Set = Asignar un valor*/

        public static string GetNombre() { return nombre; }
        public static string GetClave() { return clave; }

        public static int GetCodigo() { return Codigo; }

        public static void SetCodigo(int cod)
        {
            Codigo = cod;
        }

        public static void Setnombre(string nom)
        {
            nombre = nom;
        }
        public static void SetClave(String contrasena)
        {
            clave = contrasena;
        }

        public static Boolean ConsultarUsuario()
        {

            return true;
        }


        public static Boolean AgregarUsuario()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_AgregarUsuario", con);
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@clave", clave));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;


            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
            }
            return existe;
        }
        public static Boolean borrarUsuario()
        {

            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_Borrarusuario", con);
                command.Parameters.Add(new SqlParameter("@codigo", Codigo));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;


            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }
        public static Boolean modificar()
        {
            
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_modificarusuario", con);
                command.Parameters.Add(new SqlParameter("@codigo", Codigo));
                command.CommandType = CommandType.StoredProcedure;
                
                command.ExecuteNonQuery();
                
               
                existe = true;


            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;

        }
    }
    }



