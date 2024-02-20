﻿using MediatR;

namespace CarRent.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand : IRequest
    {
        public int TagClodID { get; set; }

        public string Title { get; set; }

        public int BlogID { get; set; }
    }
}
