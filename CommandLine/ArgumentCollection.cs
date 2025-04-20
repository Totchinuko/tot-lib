using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

internal class ArgumentCollection<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand>(CommandConfigurator<TCommand> commandConfigurator) 
    : IArgumentCollection<TCommand> 
    where TCommand : class,ICommand<TCommand>
{
    public IArgument<TCommand, TValue> Create<TValue>()
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>());
    }

    public IArgument<TCommand, TValue> Create<TValue>(string? name, string? description = null)
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>(name, description));
    }

    public IArgument<TCommand, TValue> Create<TValue>(string name, Func<TValue> getDefaultValue, string? description = null)
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>(name, getDefaultValue, description));
    }

    public IArgument<TCommand, TValue> Create<TValue>(Func<TValue> getDefaultValue)
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>(getDefaultValue));
    }

    public IArgument<TCommand, TValue> Create<TValue>(string? name, ParseArgument<TValue> parse, bool isDefault = false, string? description = null)
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>(name, parse, isDefault, description));
    }

    public IArgument<TCommand, TValue> Create<TValue>(ParseArgument<TValue> parse, bool isDefault = false)
    {
        return new ArgumentConfigurator<TCommand, TValue>(commandConfigurator,
            new Argument<TCommand, TValue>(parse, isDefault));
    }
}