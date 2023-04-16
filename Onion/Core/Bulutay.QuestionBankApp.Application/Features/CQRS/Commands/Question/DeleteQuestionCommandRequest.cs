﻿using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteQuestionCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }

        public DeleteQuestionCommandRequest(int id)
        {
            Id = id;
        }
    }
}
