using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IronPythonAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public int Get()
    {
      var engine = IronPython.Hosting.Python.CreateEngine();
      var scope = engine.CreateScope();
      engine.ExecuteFile(".\\samPy.py",scope);

      var calcSum = scope.GetVariable("calcSum");
      var result = calcSum(34, 8);

      return result;
    }
  }
}
