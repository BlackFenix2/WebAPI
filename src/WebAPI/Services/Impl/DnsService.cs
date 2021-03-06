﻿using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Impl
{
    public class DnsService : IDnsService
    {
        public async Task<DnsRecord> GetDnsInfoAsync(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                // QueryType cannot be ANY, will throw an IndexOutOfRange exception.
                var ARecords = await lookup.QueryAsync(domain, QueryType.A);

                var MxRecords = await lookup.QueryAsync(domain, QueryType.MX);

                var CnameRecords = await lookup.QueryAsync(domain, QueryType.CNAME);

                var dnsRecords = new DnsRecord()
                {
                    // MxRecords = GetMXRecords(domain),
                    // ARecords = GetARecord(domain),
                    // CnameRecords = GetCnameRecord(domain)

                    MxRecords = MxRecords.Answers.MxRecords().Select(x => x.Exchange.ToString()).ToList(),
                    ARecords = ARecords.Answers.ARecords().Select(x => x.Address.ToString()).ToList(),
                    CnameRecords = CnameRecords.Answers.CnameRecords().Select(x => x.CanonicalName.ToString()).ToList()
                };
                return dnsRecords;
            }
            catch (Exception)
            {
                return new DnsRecord()
                {
                    MxRecords = new List<string>(){
                        "empty"
                    },
                    ARecords = new List<string>(){
                        "empty"
                    },
                    CnameRecords = new List<string>(){
                        "empty"
                    }
                };
            }
        }

        private List<string> GetMXRecords(string domain)
        {
            throw new NotImplementedException();
        }

        private List<string> GetARecord(string domain)
        {
            throw new NotImplementedException();
        }

        private List<string> GetCnameRecord(string domain)
        {
            throw new NotImplementedException();
        }

        public DnsRecord GetDnsInfo(string domain)
        {
            throw new NotImplementedException();
        }
    }
}