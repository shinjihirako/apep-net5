using Apep.Application.Exceptions;
using Apep.Application.Features.MediaItems.Queries.GetMediaItemDetail;
using Apep.Application.Features.MediaItems.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Apep.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MediaItemController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MediaItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("mediaitems/{id}", Name = "GetMediaItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MediaItemDetailViewModel>> GetMediaItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var dto = await _mediator.Send(new GetMediaItemDetailQuery { Id = id });
                if (dto == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return Ok(dto);
            }
            catch (InternalServerErrorException ex)
            {
                //TODO logging
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
