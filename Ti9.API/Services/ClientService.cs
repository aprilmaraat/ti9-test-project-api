using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ti9.Models;
using System.Windows;

namespace Ti9.API
{
    public class ClientService
    {
        private readonly DataContext _context;
        public ClientService(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Client>>> List() 
        {
            try
            {
                var data = _context.Clients.ToList();
                return Response<List<Client>>.Success(data);
            }
            catch (Exception ex) 
            {
                return Response<List<Client>>.Error(ex);
            }
        }

        public async Task<Response> Create(Client model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var data = _context.Clients.FirstOrDefault(x => x.IpAddress == model.IpAddress);
                    if (data == null)
                    {
                        OperatingSystem os = Environment.OSVersion;
                        model.OsVersion = os.VersionString;
                        await _context.Clients.AddAsync(model);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return Response.Success();
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        return await Update(model);
                    }

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response.Error(ex);
                }
            }
        }
        public async Task<Response> Update(Client model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var data = _context.Clients.FirstOrDefault(x => x.IpAddress == model.IpAddress);

                    if (data != null)
                    {
                        data.LocalTime = model.LocalTime;
                        data.OnlineStatus = model.OnlineStatus;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return Response.Success();
                    }

                    return Response.Error("Client not existing.");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response.Error(ex);
                }
            }
        }
    }
}
