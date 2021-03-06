﻿using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;


namespace DanialCMS.Core.Domain.Analysis.Commands
{
    public class AddRecordCommand : ICommand
    {
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
        public string? UserName { get; set; }
    }
}
