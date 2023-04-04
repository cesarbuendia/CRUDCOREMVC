using CRUDCOREMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCOREMVC.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();
            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }

            return oLista;
        }


        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();
            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oContacto;
        }


        public bool Guardar(ContactoModel oContacto)
        {
            bool ans;

            try
            {
                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                ans = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                ans = false;            
            }

            return ans;
        }


        public bool Editar(ContactoModel oContacto)
        {
            bool ans;

            try
            {
                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                ans = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                ans = false;
            }

            return ans;
        }


        public bool Eliminar(int IdContacto)
        {
            bool ans;

            try
            {
                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                ans = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                ans = false;
            }

            return ans;
        }


    }
}
