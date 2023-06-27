using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace Dll
{
    public class clsExamen
    {
        // Indica si usar WebServices o StoredProcedures
        private bool usarWS;
        private HttpClient httpClient;

        public clsExamen(bool usarWs)
        {
            this.usarWS = usarWs;
            if (this.usarWS)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:7123");
            }
        }

        public bool AgregarExamen(int id, string nombre, string descripcion, out bool resultado, out string descripcionResultado)
        {
            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync($"/agregar?{query}").Result;
                    descripcionResultado = response.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if(ex.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    resultado = false;
                    descripcionResultado = $"{ex.Message} : {ex.InnerException.Message}";
                }

                
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("data source=localhost;initial catalog=BdiExamen;integrated security=True"))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("spAgregar", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = transaction;

                        command.Parameters.AddWithValue("@idExamen", id);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);

                        command.Parameters.AddWithValue("@CodigoRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.AddWithValue("@DescripcionRetorno", SqlDbType.VarChar).Size = 255;

                        command.ExecuteNonQuery();

                        int codigoRetorno = (int)command.Parameters["@CodigoRetorno"].Value;
                        string descripcionRetorno = command.Parameters["@DescripcionRetorno"].Value.ToString();

                        transaction.Commit();

                        resultado = true;
                        descripcionResultado = "Elemento agregado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultado = false;
                        descripcionResultado = "Error al agregar elemento:" + ex.Message;
                    }
                }
            }

            return resultado;
        }

        public bool ActualizarExamen(int id, string nombre, string descripcion, out bool resultado, out string descripcionResultado)
        {
            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                HttpResponseMessage response = httpClient.GetAsync($"/actualizar?{query}").Result;

                descripcionResultado = response.ToString();
                if (response.IsSuccessStatusCode)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("data source=localhost;initial catalog=BdiExamen;integrated security=True"))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("spActualizar", connection);
                        command.CommandType = CommandType.StoredProcedure; 
                        command.Transaction = transaction;

                        command.Parameters.AddWithValue("@idExamen", id);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);

                        command.Parameters.AddWithValue("@CodigoRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.AddWithValue("@DescripcionRetorno", SqlDbType.VarChar).Size = 255;

                        command.ExecuteNonQuery();

                        int codigoRetorno = (int)command.Parameters["@CodigoRetorno"].Value;
                        string descripcionRetorno = command.Parameters["@DescripcionRetorno"].Value.ToString();

                        transaction.Commit();

                        resultado = true;
                        descripcionResultado = "Elemento actualizado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultado = false;
                        descripcionResultado = "Error al actualizar elemento:" + ex.Message;
                    }
                }
            }

            return resultado;
        }

        public bool EliminarExamen(int id, out bool resultado, out string descripcionResultado)
        {
            if (usarWS)
            {
                string query = $"id={id}";
                HttpResponseMessage response = httpClient.GetAsync($"/eliminar?{query}").Result;

                descripcionResultado = response.ToString();
                if (response.IsSuccessStatusCode)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("data source=localhost;initial catalog=BdiExamen;integrated security=True"))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("spEliminar", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = transaction;

                        command.Parameters.AddWithValue("@idExamen", id);

                        command.Parameters.AddWithValue("@CodigoRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.AddWithValue("@DescripcionRetorno", SqlDbType.VarChar).Size = 255;

                        command.ExecuteNonQuery();

                        int codigoRetorno = (int)command.Parameters["@CodigoRetorno"].Value;
                        string descripcionRetorno = command.Parameters["@DescripcionRetorno"].Value.ToString();

                        transaction.Commit();

                        resultado = true;
                        descripcionResultado = "Elemento eliminado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultado = false;
                        descripcionResultado = "Error al eliminar elemento:" + ex.Message;
                    }
                }
            }

            return resultado;
        }

        
        public List<tblExaman> consultarExamenes(int id, string nombre, string descripcion)
        {
            List<tblExaman> oExamenList = new List<tblExaman>();
            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                HttpResponseMessage response = httpClient.GetAsync($"/actualizar?{query}").Result;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("data source=localhost;initial catalog=BdiExamen;integrated security=True"))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("spConsultar", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tblExaman oExamen = new tblExaman();
                                oExamen.IdExamen = Convert.ToInt32(reader["idExamen"]);
                                oExamen.Nombre = reader["Nombre"].ToString();
                                oExamen.Descripcion = reader["Descripcion"].ToString();

                                oExamenList.Add(oExamen);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return oExamenList;
        }

       
    }
}
