using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace HomeHero_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingServices : ControllerBase
    {
        private const string ReportServerUrl = "http://localhost/reportserver";

        [HttpGet("{reportName}")]
        public async Task<IActionResult> GetReport(string reportName)
        {
            using (var httpClient = new HttpClient(new HttpClientHandler
            {                
                Credentials = new NetworkCredential("reportsAdmin", "Abc123", "MoOree03")
            }))
            {
                var reportUrl = $"{ReportServerUrl}?/{reportName}&rs:Format=PDF";
                var response = await httpClient.GetAsync(reportUrl);

                if (response.IsSuccessStatusCode)
                {
                    var reportData = await response.Content.ReadAsByteArrayAsync();
                    return File(reportData, "application/pdf", $"{reportName}.pdf");
                }
                else
                {                   
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized();
                    }

                    return BadRequest();
                }
            }
        }
    }
}