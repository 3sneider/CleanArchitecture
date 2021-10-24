using MediatR;
using solicitudes.Domain;
using solicitudes.Service.EventHandlers.Commands;
using solisitudes.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace solicitudes.Service.EventHandlers
{
    public class SolicitudCreateEventHandler
        : INotificationHandler<SolicitudCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public SolicitudCreateEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        async public Task Handle(SolicitudCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Solicitud { 
                Nombre = "Solicitud command",
                Descripcion = "Solicitud Description command"
            });

            await _context.SaveChangesAsync();
        }
    }
}
