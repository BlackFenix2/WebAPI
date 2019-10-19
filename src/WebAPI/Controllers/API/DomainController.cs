using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers.API
{
    public class DomainController : ApiController
    {
        public IWhoisService _WhoisService;
        public IDnsService _DnsService;

        public DomainController(IWhoisService WhoisService, IDnsService DnsService)
        {
            _WhoisService = WhoisService;
            _DnsService = DnsService;
        }

        // GET api/values
        [HttpGet("{domain}")]
        public async Task<IActionResult> Get(string domain)
        {
            var Record = new DomainRecord()
            {
                Whois = _WhoisService.GetWhoisInfo(domain),
                Dns = await _DnsService.GetDnsInfoAsync(domain),
                Summary = new SummaryRecord()
            };
            try
            {
                Record.Summary.DomainOwner = Record.Whois.Registrant.Email;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(Record);
        }
    }
}