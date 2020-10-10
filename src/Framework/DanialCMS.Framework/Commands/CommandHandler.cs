using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Framework.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand:ICommand
    {

        private readonly CommandResult _result = new CommandResult();


        protected CommandResult Ok()
        {
            SetOkData();
            return _result;
        }
      
        protected CommandResult Ok(string message)
        {
            SetOkData();
            _result.Message = message;
            return _result;
        }
        protected CommandResult Ok(string message, params string[] arguments)
        {
            SetOkData();
            _result.Message = $"{message}, {arguments}";
            return _result;
        }
        private void SetOkData()
        {
            _result.ClearErrors();
            _result.IsSuccess = true;
        }
        protected CommandResult Failure()
        {
            SetFailureData();
            return _result;
        }
        protected CommandResult Failure(string message)
        {
            SetFailureData();
            _result.Message = message;
            return _result;
        }
        protected CommandResult Failure(string message, params string[] arguments)
        {
            SetFailureData();
            _result.Message = $"{message}, {arguments}";
            return _result;
        }
        private void SetFailureData()
        {
            _result.IsSuccess = false;
        }
        protected void AddError(string error)
        {
            _result.AddError(error);
        }
        protected void AddError(string error, params string[] arguments)
        {
            _result.AddError($"{error}, {arguments}");
        }
        public abstract CommandResult Handle(TCommand command);




    }
}
