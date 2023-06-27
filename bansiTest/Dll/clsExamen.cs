using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace Dll
{
    public class clsExamen
    {
        // Indica si usar WebServices o StoredProcedures
        private bool usarWS;
        private HttpClient httpClient;
        private static string connectionString = "data source=localhost;initial catalog=BdiExamen;integrated security=True";

        public clsExamen(bool usarWs)
        {
            this.usarWS = usarWs;
            if (this.usarWS)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7123");
            }
        }

        // Función auxiliar para validar los datos dados
        public bool validacionDatos(int id, string nombre, string descripcion)
        {
            if(id < 0) { return false; }
            if(nombre.Length < 0 || nombre.Length > 255) { return false; }
            if(descripcion.Length < 0 || descripcion.Length > 255) { return false; }

            return true;
        }

        public async Task<(bool, string)> AgregarExamen(int id, string nombre, string descripcion)
        {
            bool resultado;
            string descripcionResultado;

            if(!validacionDatos(id, nombre, descripcion)) 
            { 
                resultado = false;
                descripcionResultado = "Error en la validación de datos";
                return (resultado, descripcionResultado);
            }

            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"/agregar?{query}");

                    resultado = response.IsSuccessStatusCode;
                    descripcionResultado = await response.Content.ReadAsStringAsync();
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
                using (SqlConnection connection = new SqlConnection(connectionString))
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

            return (resultado, descripcionResultado);
        }

        public async Task<(bool, string)> ActualizarExamen(int id, string nombre, string descripcion)
        {
            bool resultado;
            string descripcionResultado;

            if (!validacionDatos(id, nombre, descripcion))
            {
                resultado = false;
                descripcionResultado = "Error en la validación de datos";
                return (resultado, descripcionResultado);
            }

            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                HttpResponseMessage response = await httpClient.GetAsync($"/actualizar?{query}");

                resultado = response.IsSuccessStatusCode;
                descripcionResultado = await response.Content.ReadAsStringAsync();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

            return (resultado, descripcionResultado);
        }

        public async Task<(bool, string)> EliminarExamen(int id)
        {
            bool resultado;
            string descripcionResultado;

            if (!validacionDatos(id, "", ""))
            {
                resultado = false;
                descripcionResultado = "Error en la validación de datos";

                return (resultado, descripcionResultado);
            }

            if (usarWS)
            {
                string query = $"id={id}";
                HttpResponseMessage response = await httpClient.GetAsync($"/eliminar?{query}");

                resultado = response.IsSuccessStatusCode;
                descripcionResultado = await response.Content.ReadAsStringAsync();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

            return (resultado, descripcionResultado);
        }

        public async Task<List<tblExaman>> consultarExamenes(int id, string nombre, string descripcion)
        {
            List<tblExaman> oExamenList = new List<tblExaman>();
            if (!validacionDatos(id, nombre, descripcion))
            { 
                return oExamenList;
            }

            if (usarWS)
            {
                string query = $"id={id}&nombre={nombre}&descripcion={descripcion}";
                HttpResponseMessage response = await httpClient.GetAsync($"/consultar?{query}");

                string responseContent = await response.Content.ReadAsStringAsync();    

                oExamenList = JsonConvert.DeserializeObject<List<tblExaman>>(responseContent);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("spConsultar", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = transaction;

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
