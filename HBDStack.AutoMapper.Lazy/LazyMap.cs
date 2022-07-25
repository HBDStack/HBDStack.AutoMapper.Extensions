using AutoMapper;

namespace HBDStack.AutoMapper.Lazy
{
    public interface ILazyMap<out TResult>
    {
        TResult? Value { get; }
    }
    
    internal class LazyMap<TResult>:ILazyMap<TResult>
    {
        private readonly object? _originalValue;
        private readonly IMapper _mapper;
        private TResult? _value;
        
        public LazyMap(object? originalValue,IMapper mapper)
        {
            _originalValue = originalValue;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TResult? Value => GetValue();

        private TResult? GetValue()
        {
            if (_originalValue is null) return default;
            if (_value is not null) return _value;
            if (_originalValue is TResult o) _value = o;
            _value = _mapper.Map<TResult>(_originalValue);
            return _value;
        }
    }
}