using Inventario.Entity.Parametros;
using Inventario.Entity.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Datos
{
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss) 
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();
                using (SqlConnection con= new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_ListarPaises",con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader rdr= cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            var result = new ResponsePais();
                            result.IdPais = Convert.ToInt32(rdr["idpais"]);
                            result.Pais = Convert.ToString(rdr["pais"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
