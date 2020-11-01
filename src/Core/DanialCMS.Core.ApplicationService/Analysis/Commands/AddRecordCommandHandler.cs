using DanialCMS.Core.Domain.Analysis.Commands;
using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Framework.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Analysis.Commands
{
    public class AddRecordCommandHandler : CommandHandler<AddRecordCommand>
    {
        private readonly ICMSAnalysisCommandRepository _analysisCommandRepository;
        public AddRecordCommandHandler(ICMSAnalysisCommandRepository analysisCommandRepository)
        {
            _analysisCommandRepository = analysisCommandRepository;
        }

        public override CommandResult Handle(AddRecordCommand command)
        {
            if (IsValid(command))
            {
                _analysisCommandRepository.Add(new CMSAnalysis()
                {
                    Time = DateTime.Now.TimeOfDay,
                    Date = DateTime.Now.Date,
                    BrowserName = command.BrowserName,
                    ContentLength = command.ContentLength,
                    ContentType = command.ContentType,
                    HasCockies = command.HasCockies,
                    Host = command.Host,
                    HttpMethod = command.HttpMethod,
                    IsHttps = command.IsHttps,
                    OSArchitecture = command.OSArchitecture,
                    OsName = command.OsName,
                    Path = command.Path,
                    Port = command.Port,
                    Protocol = command.Protocol,
                    Referer = command.Referer,
                    RemoteIpAddress = command.RemoteIpAddress,
                    RemotePort = command.RemotePort,
                    SatusCode = command.SatusCode,
                    Scheme = command.Scheme,
                    UserName = command.UserName,
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddRecordCommand command)
        {
            bool isValid = true;
            if (command.OsName.Length > 400)
            {
                isValid = false;
                AddError("OsName was bigger than 400 characters");
            }
            if (command.ContentType.Length > 100)
            {
                isValid = false;
                AddError("ContentType was bigger than 100 characters");
            }
            if (command.RemoteIpAddress.Length > 15)
            {
                isValid = false;
                AddError("RemoteIpAddress was bigger than 15 characters");
            }
            if (command.HttpMethod.Length > 10)
            {
                isValid = false;
                AddError("HttpMethod was bigger than 10 characters");
            }
            if (command.Path.Length > 700)
            {
                isValid = false;
                AddError("Path was bigger than 700 characters");
            }
            if (command.Referer.Length > 200)
            {
                isValid = false;
                AddError("Referer was bigger than 200 characters");
            }
            if (command.Scheme.Length > 50)
            {
                isValid = false;
                AddError("Scheme was bigger than 50 characters");
            }
            if (command.BrowserName.Length > 250)
            {
                isValid = false;
                AddError("BrowserName was bigger than 250 characters");
            }
            if (command.OSArchitecture.Length > 400)
            {
                isValid = false;
                AddError("OSArchitecture was bigger than 400 characters");
            }
            
            return isValid;
        }


    }
}
