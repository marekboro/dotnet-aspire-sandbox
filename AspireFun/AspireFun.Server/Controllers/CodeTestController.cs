using Microsoft.AspNetCore.Mvc;

namespace AspireFun.Server.Controllers;

[ApiController]
[Route("/tests")]
public class CodeTestController: ControllerBase
{
    private readonly ILogger<CodeTestController> _logger;
    
    public CodeTestController()
    {
        _logger = new  LoggerFactory().CreateLogger<CodeTestController>();
    }

    [Route("out-and-pass-by-ref")]
    [HttpGet]
    public Task<ActionResult> TestOutAndPassByRef()
    {
        _logger.LogInformation("TestOutAndPassByRef");
        OutTwentyExample(out var twenty);
        OutMinusFive(out var minusFive);
        PassByRef(ref twenty);
        PassByRef(ref minusFive);
        Console.WriteLine($"var twenty = {twenty}");
        Console.WriteLine($"var minusFive = {minusFive}");
        
        return Task.FromResult<ActionResult>(Ok());
    }
    
    [Route("delegates")]
    [HttpGet]
    public Task<ActionResult> TestDelegates()
    {
        var add = new MyDelegate((a, b) => { Console.WriteLine($"{a} + {b} = {a + b}"); return a + b; });
        var sum = add(1, 2);
        
        return Task.FromResult<ActionResult>(Ok(sum));
    }
    

    private static void PassByRef(ref int number)
    {
        if (number > 10)
        {
            number = 10;
        }

        if (number < 0)
        {
            number = 0;
        }
    }

    private static void OutTwentyExample(out int twenty) => twenty = 20;
    private static void OutMinusFive(out int minusFive) => minusFive = -5;

    private delegate int MyDelegate(int a, int b);

}