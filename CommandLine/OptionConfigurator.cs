using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

internal class OptionConfigurator<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue>(CommandConfigurator<TCommand> commandConfigurator, Option<TCommand, TValue> option)
    : IOption<TCommand, TValue>
    where TCommand : class,ICommand<TCommand>
{
    public IOption<TCommand, TValue> AddAlias(string alias)
    {
        option.AddAlias(alias);
        return this;
    }

    public IOption<TCommand, TValue> SetSetter(Action<TCommand, TValue?> setter)
    {
        option.AddSetter(setter);
        return this;
    }

    public IOption<TCommand, TValue> SetDefault(TValue defaultValue)
    {
        option.SetDefaultValue(defaultValue);
        return this;
    }

    public IOption<TCommand, TValue> AddValidator(ValidateSymbolResult<OptionResult> validate)
    {
        option.AddValidator(validate);
        return this;
    }

    public IOption<TCommand, TValue> LegalFileNamesOnly()
    {
        option.LegalFileNamesOnly();
        return this;
    }

    public IOption<TCommand, TValue> LegalFilePathsOnly()
    {
        option.LegalFilePathsOnly();
        return this;
    }

    public ICommandBuilder<TCommand> BuildOption()
    {
        commandConfigurator.Command.AddOption(option);
        return commandConfigurator;
    }
}