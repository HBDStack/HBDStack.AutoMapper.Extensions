using AutoMapper;
using HBDStack.Results;

namespace HBDStack.AutoMapper.Lazy;

internal class LazyResult<TResult> : LazyMap<TResult>, IResult<TResult>
{
    private readonly object? _originalValue;
    private readonly List<IError> _errors = new ();
    
    public LazyResult(object originalValue, IMapper mapper) : base(originalValue, mapper) => _originalValue = originalValue ?? throw new ArgumentNullException(nameof(originalValue));

    public IResult WithError(IError error)
    {
        if(_originalValue is not null)
            throw new InvalidOperationException(nameof(LazyResult<TResult>));
        _errors.Add(error);
        return this;
    }

    public IReadOnlyList<IError> Errors => _errors;
}