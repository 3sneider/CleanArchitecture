using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using solicitudes.Service.Queries.DTOs;
using solisitudes.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solicitudes.Service.Queries
{
    public interface ISolicitudQueryService
    {
        Task<DataCollection<SolicitudDto>> GetAllAsync(int page, int take, IEnumerable<int> solicitudes = null);

        Task<SolicitudDto> GetAsync(int id);
    }

    public class SolicitudQueryService: ISolicitudQueryService
    {
        private readonly ApplicationDbContext _context;

        public SolicitudQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<SolicitudDto>> GetAllAsync(int page, int take, IEnumerable<int> solicitudes = null) {
            var collection = await _context.Solicitudes
                                .Where(x => solicitudes == null || solicitudes.Contains(x.SolicitudId))
                                .OrderByDescending(x => x.SolicitudId)
                                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<SolicitudDto>>();
        }

        public async Task<SolicitudDto> GetAsync(int id)
        {
            return (await _context.Solicitudes.SingleAsync(x => x.SolicitudId == id)).MapTo<SolicitudDto>();
        }
    }
}
