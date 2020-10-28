using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Analysis.Entities
{
    public class CMSAnalysis
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string? Host { get; set; }
        public string? RemoteIpAddress { get; set; }

        public string? BrowserName { get; set; }
        public string? OsName { get; set; }
        public string? Path { get; set; }
        public string? HttpMethod { get; set; }
        public int? SatusCode { get; set; }
        public string? ContentType { get; set; }
        public long? ContentLength { get; set; }
        public string? Scheme { get; set; }
        public int? Port { get; set; }
        public int? RemotePort { get; set; }
        public string? Protocol { get; set; }
        public string? Referer { get; set; }

        public bool? IsHttps { get; set; }
        public bool? HasCockies { get; set; }
        public string? OSArchitecture { get; set; }



        public override string? ToString()
        {
            return $"{nameof(BrowserName)}: {BrowserName}\n" +
                $"{nameof(ContentLength)}: {ContentLength}\n" +
                $"{nameof(ContentType)}: {ContentType}\n" +
                $"{nameof(Date)}: {Date}\n" +
                $"{nameof(HasCockies)}: {HasCockies}\n" +
                $"{nameof(Host)}: {Host}\n" +
                $"{nameof(HttpMethod)}: {HttpMethod}\n" +
                $"{nameof(Id)}: {Id}\n" +
                $"{nameof(IsHttps)}: {IsHttps}\n" +
                $"{nameof(OSArchitecture)}: {OSArchitecture}\n" +
                $"{nameof(OsName)}: {OsName}\n" +
                $"{nameof(Path)}: {Path}\n" +
                $"{nameof(Port)}: {Port}\n" +
                $"{nameof(Protocol)}: {Protocol}\n" +
                $"{nameof(Referer)}: {Referer}\n" +
                $"{nameof(RemoteIpAddress)}: {RemoteIpAddress}\n" +
                $"{nameof(RemotePort)}: {RemotePort}\n" +
                $"{nameof(SatusCode)}: {SatusCode}\n" +
                $"{nameof(Scheme)}: {Scheme}\n" +
                $"{nameof(Time)}: {Time}\n";
        }
    }
}
