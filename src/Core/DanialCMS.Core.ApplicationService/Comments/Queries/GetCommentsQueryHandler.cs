using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Queries;
using DanialCMS.Core.Domain.Comments.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Comments.Queries
{
    public class GetCommentsQueryHandler : IQueryHandler<GetCommentsQuery, List<Comment>>
    {
        private readonly ICommentQueryRepository _commentQueryRepository;

        public GetCommentsQueryHandler(ICommentQueryRepository commentQueryRepository)
        {
            _commentQueryRepository = commentQueryRepository;
        }

        public List<Comment> Handle(GetCommentsQuery query)
        {
            return _commentQueryRepository.GetAll();
        }

       
    }
}
