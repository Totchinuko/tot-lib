using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public interface IArgumentCollection<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand> where TCommand : class,ICommand<TCommand>
{
    IArgument<TCommand, TValue> Create<TValue>();

    IArgument<TCommand, TValue> Create<TValue>(string? name, string? description = null);

    IArgument<TCommand, TValue> Create<TValue>(string name, Func<TValue> getDefaultValue, string? description = null);

    IArgument<TCommand, TValue> Create<TValue>(Func<TValue> getDefaultValue);

    IArgument<TCommand, TValue> Create<TValue>(string? name, ParseArgument<TValue> parse, bool isDefault = false, string? description = null);

    IArgument<TCommand, TValue> Create<TValue>(ParseArgument<TValue> parse, bool isDefault = false);
}