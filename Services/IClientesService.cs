using Clientes_API.Entities;

namespace Clientes_API.Services
{
    public interface IClientesService
    {
        /// <summary>
        /// get list of all Clientes
        /// </summary>
        /// <returns></returns>
        List<Cliente> GetClientesList();

        /// <summary>
        /// get Cliente details by Cliente id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        Cliente GetClienteDetailsById(int empId);

        /// <summary>
        ///  add edit Cliente
        /// </summary>
        /// <param name="ClienteModel"></param>
        /// <returns></returns>
        ResponseModel SaveCliente(Cliente ClienteModel);


        /// <summary>
        /// delete Clientes
        /// </summary>
        /// <param name="ClienteId"></param>
        /// <returns></returns>
        ResponseModel DeleteCliente(int ClienteId);
    }
}
