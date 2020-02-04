using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebAPI.Models;
using Whois;

namespace WebAPI.Services.Impl
{
    public class WhoisService : IWhoisService
    {
        /// <summary>
        /// Get basic WHOIS info
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public WhoisRecord GetWhoisInfo(string domain)
        {
            //validate domain before making whois Query
            try
            {
                domain = Cleanse(domain);
            }
            catch (Exception)
            {
                throw;
            }
            var record = new WhoisRecord();
            var whoisResult = new WhoisLookup().Lookup(domain);
            var records = whoisResult.ParsedResponse;

            record.Raw = whoisResult.Content;
            record.Domain = domain;
            // try to populate whois record,
            try
            {
                record.Created = records.Registered;

                record.Expired = records.Expiration;

                record.DomainStatus = records.DomainStatus;

                record.Nameservers = records.NameServers;

                record.Registrant.Email = records.Registrant.Email;
                record.Admin.Email = records.AdminContact.Email;
            }
            catch (Exception)
            {
                return record;
            }

            return record;
        }
        /// <summary>
        /// Get detailed WHOIS info
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<object> GetWhoisInfoDetails(string domain)
        {
            //validate domain before making whois Query
            try
            {
                domain = Cleanse(domain);
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            var whoisResult = await new WhoisLookup().LookupAsync(domain);

            var json = JsonConvert.SerializeObject(whoisResult.ParsedResponse, Formatting.Indented);

            return json;
        }

        private string Cleanse(string domain)
        {
            return domain;
        }
    }
}