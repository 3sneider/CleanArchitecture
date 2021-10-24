using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace solicitudes.Service.EventHandlers.Commands
{
    public class SolicitudCreateCommand : INotification
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
