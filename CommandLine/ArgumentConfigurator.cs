using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

internal class ArgumentConfigurator<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue>
    (CommandConfigurator<TCommand> commandConfigurator, Argument<TCommand, TValue> argument)
    : IArgument<TCommand, TValue>
    where TCommand : class,ICommand<TCommand>
{
    public IArgument<TCommand, TValue> AddSetter(Action<TCommand, TValue?> setter)
    {
        argument.AddSetter(setter);
        return this;
    }

    public ICommandBuilder<TCommand> BuildArgument()
    {
        commandConfigurator.Command.AddArgument(argument);
        return commandConfigurator;
    }
}