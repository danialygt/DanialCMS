using DanialCMS.Core.Domain.Comments.Commands;
using DanialCMS.Core.Domain.Comments.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Comments.Commands
{
    public class ChangeStatusCommentCommandHandler : CommandHandler<ChangeStatusCommentCommand>
    {
        private readonly ICommentCommandRepository _commentCommandRepository;

        public ChangeStatusCommentCommandHandler(ICommentCommandRepository commentCommandRepository)
        {
            _commentCommandRepository = commentCommandRepository;
        }

        public override CommandResult Handle(ChangeStatusCommentCommand command)
        {
            try
            {
                _commentCommandRepository.CanShow(command.CommentId, command.CommentStatus);
                return Ok();
            }
            catch (Exception e)
            {
                AddError(e.Message);
                return Failure();
            }
        }
    }
}
