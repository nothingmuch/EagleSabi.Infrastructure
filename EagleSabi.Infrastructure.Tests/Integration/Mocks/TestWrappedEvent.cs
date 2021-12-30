using System;
using EagleSabi.Common.Abstractions.EventSourcing.Models;
using EagleSabi.Common.Abstractions.EventSourcing.Records;

namespace EagleSabi.Infrastructure.Tests.Integration.Mocks
{
    public record TestWrappedEvent(long SequenceId, string Value = "", IEvent? DomainEvent = null, Guid SourceId = default) : WrappedEvent("", "", SequenceId, DomainEvent!, SourceId);
}