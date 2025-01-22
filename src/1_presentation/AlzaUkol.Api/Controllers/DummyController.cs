using AlzaUkol.Application._Shared.Error;
using AlzaUkol.Application.Dummy;
using AlzaUkol.Application.Dummy.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlzaUkol.Api.Controllers;

[ApiController]
public class DummyController : BaseController
{
    private readonly DummyFacade _dummyFacade;

    public DummyController(
        DummyFacade dummyFacade
    ) {
        _dummyFacade = dummyFacade;
    }

    [HttpGet]
    [Route("~/api/dummy/message")]
    [ProducesResponseType(200, Type = typeof(DummyMessageOUT))]
    public IActionResult GetMessage()
    {
        // call facade method
        DummyMessageOUT outputDTO = _dummyFacade.GetMessage();

        // return envelope
        return Envelope(outputDTO);
    }

    [HttpGet]
    [Route("~/api/dummy/error")]
    [ProducesResponseType(200)]
    public IActionResult GetError()
    {
        // throw error (for tests)
        throw  ErrorEx.ApplicationError("This is an error test.");
    }
}
