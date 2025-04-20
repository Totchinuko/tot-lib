using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace tot_lib.CommandLine;

public class Argument<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]TCommand,TValue> : 
    System.CommandLine.Argument<TValue>, IValueSetter<TCommand>
    where TCommand : class,ICommand<TCommand>
{
    public Argument()
    {
    }

    public Argument(string? name, string? description = null) : base(name, description)
    {
    }

    public Argument(string name, Func<TValue> getDefaultValue, string? description = null) : base(name, getDefaultValue, description)
    {
    }

    public Argument(Func<TValue> getDefaultValue) : base(getDefaultValue)
    {
    }

    public Argument(string? name, ParseArgument<TValue> parse, bool isDefault = false, string? description = null) : base(name, parse, isDefault, description)
    {
    }

    public Argument(ParseArgument<TValue> parse, bool isDefault = false) : base(parse, isDefault)
    {
    }
    
    private Action<TCommand,TValue?>? _setter;
    
    public void AddSetter(Action<TCommand,TValue?> action)
    {
        _setter = action;
    }
    
    public void SetValue(TCommand command, InvocationContext context)
    {
        _setter?.Invoke(command, context.ParseResult.GetValueForArgument(this));
    }
}