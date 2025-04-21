using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

internal class ArgumentConfigurator<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue>
    (CommandConfigurator<TCommand> commandConfigurator, Argument<TCommand, TValue> argument)
    : IArgument<TCommand, TValue>
    where TCommand : class,ICommand<TCommand>
{
    public IArgument<TCommand, TValue> SetSetter(Action<TCommand, TValue?> setter)
    {
        argument.SetSetter(setter);
        return this;
    }
    
    public IArgument<TCommand, TValue> SetDefault(TValue defaultValue)
    {
        argument.SetDefaultValue(defaultValue);
        return this;
    }

    public IArgument<TCommand, TValue> AddValidator(ValidateSymbolResult<ArgumentResult> validate)
    {
        argument.AddValidator(validate);
        return this;
    }

    public IArgument<TCommand, TValue> LegalFileNamesOnly()
    {
        argument.LegalFileNamesOnly();
        return this;
    }

    public IArgument<TCommand, TValue> LegalFilePathsOnly()
    {
        argument.LegalFilePathsOnly();
        return this;
    }

    public ICommandBuilder<TCommand> BuildArgument()
    {
        commandConfigurator.Command.AddArgument(argument);
        return commandConfigurator;
    }
}