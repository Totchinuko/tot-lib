using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public interface IArgument<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue> where TCommand : class,ICommand<TCommand>
{
    IArgument<TCommand, TValue> AddSetter(Action<TCommand, TValue?> setter);
    ICommandBuilder<TCommand> BuildArgument();
}