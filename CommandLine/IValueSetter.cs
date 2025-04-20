using System.CommandLine.Invocation;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public interface IValueSetter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand> where TCommand : class,ICommand<TCommand>
{
    void SetValue(TCommand command, InvocationContext context);
}