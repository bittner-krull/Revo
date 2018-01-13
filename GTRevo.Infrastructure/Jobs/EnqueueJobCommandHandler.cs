﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GTRevo.Core.Commands;

namespace GTRevo.Infrastructure.Jobs
{
    public class EnqueueJobCommandHandler : ICommandHandler<EnqueueJobCommand>
    {
        private readonly IJobScheduler jobScheduler;

        public EnqueueJobCommandHandler(IJobScheduler jobScheduler)
        {
            this.jobScheduler = jobScheduler;
        }

        public Task HandleAsync(EnqueueJobCommand command, CancellationToken cancellationToken)
        {
            return jobScheduler.EnqeueJobAsync(new ExecuteCommandJob(command.Command), command.TimeDelay);
        }
    }
}