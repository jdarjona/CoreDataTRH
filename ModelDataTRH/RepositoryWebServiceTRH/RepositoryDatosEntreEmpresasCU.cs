using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebServiceTRH
{
    class RepositoryDatosEntreEmpresasCU : RespositoryBase
    {
        public RepositoryDatosEntreEmpresasCU(HostWebService hostRespositorio) : base(hostRespositorio)
        {
        }

        public void getDatosPCInterno(string codProducto,string almacen) {
            try
            {
                decimal precio = 0;
                decimal inventario = 0;
                if (Context.contextDatosEntreEmpresas.GetInventarioCosteUnitario(codProducto, almacen, ref precio, ref inventario))
                {

                }
                else
                {

                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(@"codProducto/almacen", "El parametro 'codProducto/almacen' no pueden vernir vacios");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo getDatosPCInterno]", ex.Message), ex.InnerException);
            }
        }
    }
}
