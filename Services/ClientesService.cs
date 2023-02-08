using Clientes_API.DAL;
using Clientes_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes_API.Services
{
    public class ClientesService : IClientesService
    {
        private Context _context;

        public ClientesService(Context context)
        {
            _context = context;
        }
        
        public ResponseModel DeleteCliente(int ClienteId)
        {
            ResponseModel model = new ResponseModel();
            
            try
            {
                using (var db = new Context())
                {
                    Cliente cliente = GetClienteDetailsById(ClienteId);
                    db.Entry(cliente).State = EntityState.Deleted;

                    model.IsSuccess = true;
                    model.Message = "Cliente eliminado exitosamente";
                }
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Message = "Error al eliminar el cliente";                
            }
            return model;
        }

        public Cliente GetClienteDetailsById(int id)
        {
            Cliente cliente = null;
            try
            {
                using (var db = new Context())
                {
                    cliente = db.Clientes.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }

        public List<Cliente> GetClientesList()
        {
            List<Cliente> lista = null;
            try
            {
                using (var db = new Context())
                {
                    lista = db.Clientes.Include("Addresses").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public ResponseModel SaveCliente(Cliente ClienteModel)
        {
            ResponseModel response = new ResponseModel();
            
            try
            {
                using (var db = new Context())
                {
                    if (GetClienteDetailsById(ClienteModel.Id) == null)
                    {
                        db.Clientes.Add(ClienteModel);
                    }
                    else
                    {
                        db.Entry(ClienteModel).State = EntityState.Modified;
                    }
                    
                    db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Cliente guardado exitosamente";
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Error al guardar el cliente";
            }
            return response;
        }
    }
}
