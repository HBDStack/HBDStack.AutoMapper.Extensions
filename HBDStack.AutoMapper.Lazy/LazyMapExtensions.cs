using AutoMapper;
using HBDStack.AutoMapper.Lazy;
using HBDStack.Results;

// ReSharper disable once CheckNamespace
namespace AutoMapper;

public static class LazyMapExtensions
{
    public static ILazyMap<TValue> LazyMap<TValue>(this IMapper mapper, object value) => new LazyMap<TValue>(value, mapper);
    
    public static IResult<TValue> ResultOf<TValue>(this IMapper mapper, object value) => new LazyResult<TValue>(value, mapper);
}