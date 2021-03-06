﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace TekeriumCommerce.Infrastructure
{
    // read about this class purpose
    public class SequentialMediator : Mediator
    {
        public SequentialMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected override async Task PublishCore(IEnumerable<Task> allHandlers)
        {
            foreach (var handler in allHandlers)
            {
                await handler;
            }
        }
    }
}