using Clientes_API.DAL;
using Clientes_API.Entities;

namespace Clientes_API.Services
{
    public class DashboardService : IDashboardService
    {
        Context _context;

        public DashboardService(Context context)
        {
            _context = context;
        }

        public Dashboard GetDashboard()
        {
            var dashboard = new Dashboard();

            try
            {
                dashboard.TotalClientesActivos = _context.Clientes.Count(x => x.Active);
                dashboard.TotalClientesInactivos = _context.Clientes.Count(x => !x.Active);
                dashboard.TotalDirecciones = _context.Addresses.Count();
                dashboard.TotalClientesMasDirecciones = _context.Clientes.Count(x => x.Addresses.Count > 1);

                return dashboard;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
