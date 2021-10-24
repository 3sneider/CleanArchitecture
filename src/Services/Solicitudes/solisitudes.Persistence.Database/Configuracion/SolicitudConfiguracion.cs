using System;
using solicitudes.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace solisitudes.Persistence.Database.Configuracion
{
    public class SolicitudConfiguracion
    {
        public SolicitudConfiguracion(EntityTypeBuilder<Solicitud> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.SolicitudId);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);

            // Solicitudes por default
            var solicitudes = new List<Solicitud>();
            var random = new Random();

            for (int i = 1; i <= 20; i++)
            {
                solicitudes.Add(new Solicitud { 
                    SolicitudId = i,
                    Nombre = $"Solicitud {i}",
                    Descripcion = $"Descripcion {i}"
                });
            }

            entityBuilder.HasData(solicitudes);
        }
    }
}
