using DanialCMS.Framework.Commands;

namespace DanialCMS.Core.Domain.FileManagements.Commands
{
    public class RenameFileCommand : ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
