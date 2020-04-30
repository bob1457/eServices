using eServices.Ecommerce.CatelogService.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eServices.Ecommerce.CatelogService.Application.CommandHandlers
{
    public class CreateCategoryCommandHandlers : IRequestHandler<CreateCategoryCommand, bool>
    {
        public CreateCategoryCommandHandlers()
        {

        }

        public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
