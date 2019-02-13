using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsControl.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsControl.Gateways.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeService _service;
        public NodesController(INodeService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<NodeDto> Get()
        {
            return _service.GetAll();
        }
        //[HttpPost]
        //public void Create(CreateNodeDto dto)
        //{
        //    _service.Create(dto);
        //}
    }
}