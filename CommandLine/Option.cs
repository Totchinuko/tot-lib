using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

internal class Option<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand, TValue> : 
    System.CommandLine.Option<TValue>, IValueSetter<TCommand>
    where TCommand : class,ICommand<TCommand>
{
    public Option(string name, string? description = null) : base(name, description)
    {
    }

    public Option(string[] aliases, string? description = null) : base(aliases, description)
    {
    }

    public Option(string name, ParseArgument<TValue> parseArgument, bool isDefault = false, string? description = null) : base(name, parseArgument, isDefault, description)
    {
    }

    public Option(string[] aliases, ParseArgument<TValue> parseArgument, bool isDefault = false, string? description = null) : base(aliases, parseArgument, isDefault, description)
    {
    }

    public Option(string name, Func<TValue> getDefaultValue, string? description = null) : base(name, getDefaultValue, description)
    {
    }

    public Option(string[] aliases, Func<TValue> getDefaultValue, string? description = null) : base(aliases, getDefaultValue, description)
    {
    }
    
    private Action<TCommand, TValue?>? _setter;
    
    public void AddSetter(Action<TCommand, TValue?> action)
    {
        _setter = action;
    }
    
    public void SetValue(TCommand command, InvocationContext context)
    {
        _setter?.Invoke(command, context.ParseResult.GetValueForOption(this));
    }
}