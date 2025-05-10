
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Middleware.Responses;
using Middleware.Services.Base;


namespace Middleware.Controllers;

[Route("/api/[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError,Type=typeof(InternalServerErrorResponse))]
[ProducesResponseType((int)HttpStatusCode.BadRequest,Type=typeof(BadRequestResponse))]
[ProducesResponseType((int)HttpStatusCode.NotFound,Type=typeof(NotFoundResponse))]
[ProducesResponseType((int)HttpStatusCode.OK)]

public class TestController : ControllerBase
{
    private ITestService testService;
    private IHttpLogger logger;

    public TestController(ITestService testService,IHttpLogger logger)
    {
        this.testService=testService;
        this.logger=logger;
    }

    [HttpGet]
    public ActionResult Method(string? text)
    {  
        testService.DontPutNull(text);
        testService.FindBook();
        testService.NeverCrashes();
       
        return base.Ok();
    }
}
