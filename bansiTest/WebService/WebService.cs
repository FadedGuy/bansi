using examenSeleccionBansi.Models;
using System.Transactions;
using System.Collections.Generic;

namespace WebService
{
    public class WebService
    {
        public WebService() { }
        public bool AgregarExamen(int id, string nombre, string descripcion, out bool resultado, out string descripcionRetorno)
        {
            try
            {
                using (BdiExamenContext db = new BdiExamenContext())
                {
                    using (var scope = new TransactionScope())
                    {
                        TblExaman oExamen = new TblExaman();
                        oExamen.IdExamen = id;
                        oExamen.Nombre = nombre;
                        oExamen.Descripcion = descripcion;

                        db.TblExamen.Add(oExamen);
                        db.SaveChanges();

                        scope.Complete();

                        resultado = true;
                        descripcionRetorno = "Examen agregado correctamente!";
                    }

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                descripcionRetorno = "Error al agregar a tblExamen: " + ex.Message;
                Console.WriteLine(ex.ToString());
            }

            return resultado;
        }

        public bool ActualizarExamen(int id, string nombre, string descripcion, out bool resultado, out string descripcionRetorno)
        {
            try
            {
                using (BdiExamenContext db = new BdiExamenContext())
                {
                    using (var scope = new TransactionScope())
                    {
                        TblExaman oExamen = db.TblExamen.Find(id);

                        oExamen.Nombre = nombre;
                        oExamen.Descripcion = descripcion;

                        db.Entry(oExamen).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();

                        scope.Complete();

                        resultado = true;
                        descripcionRetorno = "Examen actualizado correctamente!";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                descripcionRetorno = "Error al actualizar a tblExamen: " + ex.Message;
            }

            return resultado;
        }

        public bool EliminarExamen(int id, out bool resultado, out string descripcionRetorno)
        {
            try
            {
                using (BdiExamenContext db = new BdiExamenContext())
                {
                    using (var scope = new TransactionScope())
                    {
                        TblExaman oExamen = db.TblExamen.Find(id);

                        db.TblExamen.Remove(oExamen);
                        db.SaveChanges();

                        scope.Complete();

                        resultado = true;
                        descripcionRetorno = "Examen eliminado correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                descripcionRetorno = "Error al eliminar de tblExamen: " + ex.Message;
            }

            return resultado;
        }

        public List<TblExaman> ConsultarExamen(string nombre, string descripcion)
        {
            using (BdiExamenContext db = new BdiExamenContext())
            {
                return db.TblExamen.Where(exam => exam.Nombre == nombre && exam.Descripcion == descripcion).ToList();
            }
        }
    }
}
