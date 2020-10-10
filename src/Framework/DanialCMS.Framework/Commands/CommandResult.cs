using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Framework.Commands
{
    public class CommandResult
    {

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
        private readonly List<string> _errors = new List<string>();

        public IEnumerable<string> Errors => _errors;
        


        internal void AddError(string error)
        {
            IsSuccess = false;
            _errors.Add(error);
        }
        
        internal void ClearErrors()
        {
            _errors.Clear();

        }
    }
}
