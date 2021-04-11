using Inventario.Datos;
using Inventario.Entity.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventario.Controllers
{
    [RoutePrefix("api/RegistroEmpresas")]
    public class RegistroEmpresasController : ApiController
    {
        private DAPaises dapaises;

        public RegistroEmpresasController()
        {
            dapaises = new DAPaises();
        }
        [HttpPost]
        [Route("listarPaises")]
        public IHttpActionResult listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarPaises(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
