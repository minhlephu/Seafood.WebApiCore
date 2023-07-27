using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using Seafood.INFRASTRUCTURE.Base.Models;

namespace Seafood.API.Controllers
{
    [ApiController]
    [Route("api")]
    public abstract class ApiControllerBase<T> : ControllerBase where T : ApiControllerBase<T>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        protected ResponseModel ResponseModel;

        protected ApiControllerBase()
        {
            ResponseModel = new ResponseModel();
        }

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();
    }
}
