using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Logica
{
    public class Logica
    {
        Sentencias sn = new Sentencias();
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }
        public OdbcDataReader bitacora(string sCodigo, string sip, string Smac, string susuario, string sdepartamento, string sfechahora, string saccion, string sformulario)
        {
            return sn.insertarbitacora(sCodigo, sip, Smac, susuario, sdepartamento, sfechahora, saccion, sformulario);
        }
        public OdbcDataReader Insertar(string[] datos)
        {
            return sn.Insertar(datos);
        }
        public OdbcDataReader Eliminar(string[] datos)
        {
            return sn.Eliminar(datos);
        }

        public OdbcDataReader Modificar(string[] datos, string[] campos)
        {
            return sn.Modificar(datos, campos);
        }
        public OdbcDataReader consultacurso(string tabla)
        {
            return sn.consultacurso(tabla);
        }
    }
}
