using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public interface IOption<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue> where TCommand : class,ICommand<TCommand>
{
    IOption<TCommand, TValue> AddAlias(string alias);
    IOption<TCommand, TValue> AddSetter(Action<TCommand, TValue?> setter);
    ICommandBuilder<TCommand> BuildOption();
}