using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AdanSoap
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        private EntityTestEntities db = new EntityTestEntities();

        [WebMethod]
        public List<EjercicioSoap> Get()
        {
            return db.EjercicioSoap.ToList<EjercicioSoap>();
        }

        [WebMethod]
        public List<EjercicioSoap> Post(EjercicioSoap ej)
        {
            var listaEjercicios = db.EjercicioSoap.ToList<EjercicioSoap>();
            listaEjercicios.Add(ej);
            db.SaveChanges();

            return listaEjercicios;
        }

        [WebMethod]
        public List<EjercicioSoap> Put(EjercicioSoap ej)
        {
            var listaEjercicios = db.EjercicioSoap.ToList<EjercicioSoap>();
            var userUpdate = listaEjercicios.Find(x => x.NIF == ej.NIF);


            EjercicioSoap up = listaEjercicios.First(x => x.NIF == ej.NIF);
            up.Apellidos = ej.Apellidos;
            up.Ciudad = ej.Ciudad;
            up.CP = ej.CP;
            up.Direccion = ej.Direccion;
            up.EstadoCivil = ej.EstadoCivil;
            up.NIF = ej.NIF;
            up.Nombre = ej.Nombre;
            up.Provincia = ej.Provincia;
            up.Sexo = ej.Sexo;
            db.SaveChanges();
            return listaEjercicios;

        }

        [WebMethod]
        public List<EjercicioSoap> Delete(int NIF)
        {
            var listaEjercicios = db.EjercicioSoap.ToList<EjercicioSoap>();
            var userDelete = listaEjercicios.Find(x => x.NIF == NIF);

            if (userDelete != null)
            {
                listaEjercicios.Remove(userDelete);
                db.SaveChanges();
                return listaEjercicios;
            }
            return null;
        }
    }

}

