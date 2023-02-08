using Clientes_API.Entities;

namespace Clientes_API.Services
{
    public interface IAddressesService
    {
        /// <summary>
        /// get list of all Addresses
        /// </summary>
        /// <returns></returns>
        List<Address> GetAddressesList(int clienteId);

        /// <summary>
        /// get Address details by Address id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        Address GetAddressDetailsById(int empId);

        /// <summary>
        ///  add edit Address
        /// </summary>
        /// <param name="AddressModel"></param>
        /// <returns></returns>
        ResponseModel SaveAddress(List<Address> AddressModel);


        /// <summary>
        /// delete Addresses
        /// </summary>
        /// <param name="AddressId"></param>
        /// <returns></returns>
        ResponseModel DeleteAddress(int AddressId);
    }
}
