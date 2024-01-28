using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebFramework.Api;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseSimpleController : ControllerBase
{
}