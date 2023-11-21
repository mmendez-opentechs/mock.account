using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Mock.AccountInfo.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AccountInfoController : ControllerBase
{
    private readonly ILogger<AccountInfoController> _logger;

    public AccountInfoController(ILogger<AccountInfoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAccountInfo")]
    public AccountInfo Get()
    {
        var accountInfo =  new AccountInfo()
        {
            OpenedDate = DateTime.Now.AddYears(-10),
            AccountNumber = "147839282",
            TaxReportedForNumber = "54523",
            Nickname = "Personal Checking"
        };
        
        _logger.LogDebug(JsonSerializer.Serialize(accountInfo));
        return accountInfo;
    }
}