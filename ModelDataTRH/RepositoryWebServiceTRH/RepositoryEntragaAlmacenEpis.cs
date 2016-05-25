﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryWebServiceTRH.EntregaAlmacenEpisContext;

namespace RepositoryWebServiceTRH
{
    public class RepositoryEntragaAlmacenEpis : RespositoryBase, IRepository<EntregaAlmacen, String>
    {
        public RepositoryEntragaAlmacenEpis(HostWebService hostWs) : base(hostWs)
        {

        }

        public bool register(string codEmpleado) {

            try
            {
                CultureInfo culture = new CultureInfo("es-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;

                Context.contextAlmacenesRepuestos.RegistrarEntrega(codEmpleado);
                return true;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("codEmpleado", "El parametro 'codEmpleado' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo register] [codEmpleado] ", ex.Message), ex.InnerException);

            }
            
        }

        public void Add(EntregaAlmacen entity)
        {

            try
            {
                Context.contextEntregaAlmacenEpis.Create(ref entity);

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("entity", "El parametro 'entity' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo Add] [entity] ", ex.Message), ex.InnerException);
                
            }
           
        }

        public void AddRange(IEnumerable<EntregaAlmacen> entitties)
        {

            try
            {
                EntregaAlmacen[] entregaAlmacenArray = entitties.ToArray<EntregaAlmacen>();
                Context.contextEntregaAlmacenEpis.CreateMultiple(ref entregaAlmacenArray);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("entitties", "El parametro 'entitties' no puede vernir vacio");
            }
            catch (Exception  ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo AddRange] [entitties] ", ex.Message), ex.InnerException);
                
            }
           
        }

        public IEnumerable<EntregaAlmacen> Find(Expression<Func<EntregaAlmacen, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<EntregaAlmacen> GetbyIdKey(string id)
        {
            
            try
            {
                EntregaAlmacen_Filter[] filtro = new EntregaAlmacen_Filter[2];

                //Filtro Empleado
                filtro[0] = new EntregaAlmacen_Filter();
                filtro[0].Field = EntregaAlmacen_Fields.Cod_Empleado;
                filtro[0].Criteria = id;
                //Filtro Empleado
                filtro[1] = new EntregaAlmacen_Filter();
                filtro[1].Field = EntregaAlmacen_Fields.Entregado;
                filtro[1].Criteria = "No";

                return Context.contextEntregaAlmacenEpis.ReadMultiple(filtro, null, 0).ToList();
              
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("id", "El parametro 'id' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo GetbyIdKey] [id] ", ex.Message), ex.InnerException);
            }
        }

        public List<EntregaAlmacen> GetAll()
        {
            try
            {
                return Context.contextEntregaAlmacenEpis.ReadMultiple(null, null, 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado: ", ex.InnerException);
            }
        }

        public void RemoveRange(IEnumerable<EntregaAlmacen> entities)
        {
            throw new NotImplementedException();
        }

        public void Reove(EntregaAlmacen entity)
        {
            throw new NotImplementedException();
        }

        public EntregaAlmacen Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(EntregaAlmacen entity)
        {
            try
            {
                Context.contextEntregaAlmacenEpis.Update(ref entity);

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("entity", "El parametro 'entity' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo Add] [entity] ", ex.Message), ex.InnerException);

            }
        }

        public void UpdateRange(IEnumerable<EntregaAlmacen> entitties)
        {
            try
            {
                EntregaAlmacen[] entregaAlmacenArray = entitties.ToArray<EntregaAlmacen>();
                Context.contextEntregaAlmacenEpis.CreateMultiple(ref entregaAlmacenArray);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("entitties", "El parametro 'entitties' no puede vernir vacio");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} mensaje: {1}", "[Metodo AddRange] [entitties] ", ex.Message), ex.InnerException);

            }
        }
    }
}
