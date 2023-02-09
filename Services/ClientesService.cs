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
                Cliente cliente = GetClienteDetailsById(ClienteId);
                _context.Entry(cliente).State = EntityState.Deleted;

                _context.SaveChanges();

                model.IsSuccess = true;
                model.Message = "Cliente eliminado exitosamente";
            }
            catch (Exception e)
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
                cliente = _context.Clientes.Find(id);
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
                lista = _context.Clientes
                    .ToList();
            }
            catch (Exception e)
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
                if (ClienteModel.ClienteId == 0)
                    _context.Clientes.Add(ClienteModel);
                else
                    _context.Entry(ClienteModel).State = EntityState.Modified;

                _context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Cliente guardado exitosamente";
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Error al guardar el cliente";
            }
            return response;
        }
    }
}
