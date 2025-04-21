using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public interface IOption<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue> where TCommand : class,ICommand<TCommand>
{
    IOption<TCommand, TValue> AddAlias(string alias);
    IOption<TCommand, TValue> SetSetter(Action<TCommand, TValue?> setter);
    public IOption<TCommand, TValue> SetDefault(TValue defaultValue);
    public IOption<TCommand, TValue> AddValidator(ValidateSymbolResult<OptionResult> validate);
    public IOption<TCommand, TValue> LegalFileNamesOnly();
    public IOption<TCommand, TValue> LegalFilePathsOnly();
    ICommandBuilder<TCommand> BuildOption();
}