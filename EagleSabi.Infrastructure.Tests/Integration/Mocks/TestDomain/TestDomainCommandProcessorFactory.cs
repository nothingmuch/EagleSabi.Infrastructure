using System;
using EagleSabi.Common.Abstractions.EventSourcing.Dependencies;
using EagleSabi.Common.Abstractions.EventSourcing.Factories;
using EagleSabi.Common.Exceptions;

namespace EagleSabi.Infrastructure.Tests.Integration.Mocks.TestDomain
{
    internal class TestDomainCommandProcessorFactory : ICommandProcessorFactory
    {
        public ICommandProcessor Create(string aggregateType)
        {
            if (TryCreate(aggregateType, out var commandProcessor))
            {
                return commandProcessor
                    ?? throw new AssertionFailedException($"CommandProcessorFactory returned null for aggregateType: '{aggregateType}'");
            }
            else
            {
                throw new InvalidOperationException($"CommandProcessor is missing for aggregate type '{aggregateType}'.");
            }
        }

        public bool TryCreate(string aggregateType, out ICommandProcessor commandProcessor)
        {
            switch (aggregateType)
            {
                case nameof(TestRoundAggregate):
                    commandProcessor = new TestRoundCommandProcessor();
                    return true;

                default:
                    commandProcessor = null!;
                    return false;
            }
        }
    }
}