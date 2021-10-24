using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using solicitudes.Service.EventHandlers.Commands;
using solicitudes.Service.Queries;
using solicitudes.Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solicitudes.api.Controllers
{
    [ApiController]
    [Route("solicitudes")]
    public class SolicitudController : ControllerBase
    {   
        private readonly IMediator _Mediator;
        private readonly ILogger<SolicitudController> _logger;
        private readonly ISolicitudQueryService _SolicitudQueryService;        

        public SolicitudController(
            ILogger<SolicitudController> logger,
            ISolicitudQueryService solicitudQueryService,
            IMediator mediator)
        {
            _logger = logger;
            _Mediator = mediator;
            _SolicitudQueryService = solicitudQueryService;            
        }

        public ISolicitudQueryService SolicitudQueryService { get; }

        [HttpGet]
        public async Task<DataCollection<SolicitudDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> solicitudes = null;

            if (!string.IsNullOrEmpty(ids))
        	{
                solicitudes = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _SolicitudQueryService.GetAllAsync(page, take, solicitudes);
        }

        [HttpGet("{id}")]
        public async Task<SolicitudDto> Get(int id)
        {
            return await _SolicitudQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SolicitudCreateCommand command)
        {
            await _Mediator.Publish(command);
            return Ok();
        }
    }
}
