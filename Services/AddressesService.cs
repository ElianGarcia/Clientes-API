using Clientes_API.DAL;
using Clientes_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes_API.Services
{
    public class AddressesService : IAddressesService
    {
        private Context _context;

        public AddressesService(Context context)
        {
            _context = context;
        }

        public ResponseModel DeleteAddress(int AddressId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Address address = GetAddressDetailsById(AddressId);
                _context.Entry(address).State = EntityState.Deleted;

                model.IsSuccess = true;
                model.Message = "Address deleted successfully";
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Message = "Error deleting address";
            }
            return model;

        }

        public Address GetAddressDetailsById(int empId)
        {
            Address address = null;
            try
            {
                address = _context.Addresses.Find(empId);
            }
            catch (Exception)
            {
                throw;
            }
            return address;
        }

        public List<Address> GetAddressesList(int clienteId)
        {
            List<Address> lista = null;
            try
            {
                lista = _context.Addresses
                    .Where(x => x.ClienteId == clienteId)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public ResponseModel SaveAddress(List<Address> addresses)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                foreach (Address address in addresses)
                {
                    if (address.AddressId == 0)
                    {
                        _context.Entry(address).State = EntityState.Added;
                        model.Message = "Address added successfully";
                    }
                    else
                    {
                        _context.Entry(address).State = EntityState.Modified;
                        model.Message = "Address updated successfully";
                    }
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Message = "Error saving address";
            }

            return model;
        }
    }
}
