using AlzaUkol.Application.Dummy.DTOs;
using Microsoft.Extensions.Configuration;

namespace AlzaUkol.Application.Dummy;

public class DummyFacade
{
    private readonly IConfiguration _config;

    public DummyFacade(IConfiguration config)
    {
        _config = config;
    }

    public DummyMessageOUT GetMessage()
    {
        string msg = _config["Message"];

        DummyMessageOUT outputDTO = new DummyMessageOUT()
        {
            Message = msg
        };

        return outputDTO;
    }
}
