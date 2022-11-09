using System;

namespace Maestria.Extensions;

public interface IThenPromiseNullable<TValue> where TValue : struct
{
    TValue? Then(TValue? newValue);
    TValue? Then(Func<TValue?> newValue);
}

public interface IThenPromise<TValue> : IThenPromiseNullable<TValue>
    where TValue : struct
{
    TValue Then(TValue newValue);
    TValue Then(Func<TValue> newValue);
}

public struct ThenPromise<TValue> : IThenPromise<TValue>
    where TValue : struct, IComparable
{
    private TValue _value;
    private TValue _compareTo;
    private ComparisonOperation _operation;
    public ThenPromise(TValue value, TValue compareTo, ComparisonOperation operation)
    {
        _value = value;
        _compareTo = compareTo;
        _operation = operation;
    }

    public TValue Then(TValue newValue) => Then((TValue?)newValue).GetValueOrDefault();
    public TValue Then(Func<TValue> newValue) => Then(() => (TValue?)newValue()).GetValueOrDefault();

    public TValue? Then(TValue? newValue)
    {
        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.CompareTo(_compareTo) > 0 ? newValue : _value,
            ComparisonOperation.GreaterOrEqual => _value.CompareTo(_compareTo) >= 0 ? newValue : _value,
            ComparisonOperation.Equal => _value.CompareTo(_compareTo) == 0 ? newValue : _value,
            ComparisonOperation.NotEqual => _value.CompareTo(_compareTo) != 0 ? newValue : _value,
            ComparisonOperation.Less => _value.CompareTo(_compareTo) < 0 ? newValue : _value,
            ComparisonOperation.LessOrEqual => _value.CompareTo(_compareTo) <= 0 ? newValue : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }

    public TValue? Then(Func<TValue?> newValue)
    {
        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.CompareTo(_compareTo) > 0 ? newValue() : _value,
            ComparisonOperation.GreaterOrEqual => _value.CompareTo(_compareTo) >= 0 ? newValue() : _value,
            ComparisonOperation.Equal => _value.CompareTo(_compareTo) == 0 ? newValue() : _value,
            ComparisonOperation.NotEqual => _value.CompareTo(_compareTo) != 0 ? newValue() : _value,
            ComparisonOperation.Less => _value.CompareTo(_compareTo) < 0 ? newValue() : _value,
            ComparisonOperation.LessOrEqual => _value.CompareTo(_compareTo) <= 0 ? newValue() : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }
}

public struct ThenPromiseCompareValueNullable<TValue> : IThenPromise<TValue>
    where TValue : struct, IComparable
{
    private TValue _value;
    private TValue? _compareTo;
    private ComparisonOperation _operation;
    public ThenPromiseCompareValueNullable(TValue value, TValue? compareTo, ComparisonOperation operation)
    {
        _value = value;
        _compareTo = compareTo;
        _operation = operation;
    }

    public TValue Then(TValue newValue) => Then((TValue?)newValue).GetValueOrDefault();
    public TValue Then(Func<TValue> newValue) => Then(() => (TValue?)newValue()).GetValueOrDefault();

    public TValue? Then(TValue? newValue)
    {
        if (_compareTo == null)
            return _operation == ComparisonOperation.NotEqual ? newValue : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.CompareTo(_compareTo.Value) > 0 ? newValue : _value,
            ComparisonOperation.GreaterOrEqual => _value.CompareTo(_compareTo.Value) >= 0 ? newValue : _value,
            ComparisonOperation.Equal => _value.CompareTo(_compareTo.Value) == 0 ? newValue : _value,
            ComparisonOperation.NotEqual => _value.CompareTo(_compareTo.Value) != 0 ? newValue : _value,
            ComparisonOperation.Less => _value.CompareTo(_compareTo.Value) < 0 ? newValue : _value,
            ComparisonOperation.LessOrEqual => _value.CompareTo(_compareTo.Value) <= 0 ? newValue : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }

    public TValue? Then(Func<TValue?> newValue)
    {
        if (_compareTo == null)
            return _operation == ComparisonOperation.NotEqual ? newValue() : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.CompareTo(_compareTo.Value) > 0 ? newValue() : _value,
            ComparisonOperation.GreaterOrEqual => _value.CompareTo(_compareTo.Value) >= 0 ? newValue() : _value,
            ComparisonOperation.Equal => _value.CompareTo(_compareTo.Value) == 0 ? newValue() : _value,
            ComparisonOperation.NotEqual => _value.CompareTo(_compareTo.Value) != 0 ? newValue() : _value,
            ComparisonOperation.Less => _value.CompareTo(_compareTo.Value) < 0 ? newValue() : _value,
            ComparisonOperation.LessOrEqual => _value.CompareTo(_compareTo.Value) <= 0 ? newValue() : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }
}

public struct ThenPromiseValueNullable<TValue> : IThenPromiseNullable<TValue>
    where TValue : struct, IComparable
{
    private TValue? _value;
    private TValue _compareTo;
    private ComparisonOperation _operation;
    public ThenPromiseValueNullable(TValue? value, TValue compareTo, ComparisonOperation operation)
    {
        _value = value;
        _compareTo = compareTo;
        _operation = operation;
    }

    public TValue? Then(TValue? newValue)
    {
        if (_value == null)
            return _operation == ComparisonOperation.NotEqual ? newValue : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.Value.CompareTo(_compareTo) > 0 ? newValue : _value,
            ComparisonOperation.GreaterOrEqual => _value.Value.CompareTo(_compareTo) >= 0 ? newValue : _value,
            ComparisonOperation.Equal => _value.Value.CompareTo(_compareTo) == 0 ? newValue : _value,
            ComparisonOperation.NotEqual => _value.Value.CompareTo(_compareTo) != 0 ? newValue : _value,
            ComparisonOperation.Less => _value.Value.CompareTo(_compareTo) < 0 ? newValue : _value,
            ComparisonOperation.LessOrEqual => _value.Value.CompareTo(_compareTo) <= 0 ? newValue : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }

    public TValue? Then(Func<TValue?> newValue)
    {
        if (_value == null)
            return _operation == ComparisonOperation.NotEqual ? newValue() : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.Value.CompareTo(_compareTo) > 0 ? newValue() : _value,
            ComparisonOperation.GreaterOrEqual => _value.Value.CompareTo(_compareTo) >= 0 ? newValue() : _value,
            ComparisonOperation.Equal => _value.Value.CompareTo(_compareTo) == 0 ? newValue() : _value,
            ComparisonOperation.NotEqual => _value.Value.CompareTo(_compareTo) != 0 ? newValue() : _value,
            ComparisonOperation.Less => _value.Value.CompareTo(_compareTo) < 0 ? newValue() : _value,
            ComparisonOperation.LessOrEqual => _value.Value.CompareTo(_compareTo) <= 0 ? newValue() : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }
}

public struct ThenPromiseNullable<TValue> : IThenPromiseNullable<TValue>
    where TValue : struct, IComparable
{
    private TValue? _value;
    private TValue? _compareTo;
    private ComparisonOperation _operation;
    public ThenPromiseNullable(TValue? value, TValue? compareTo, ComparisonOperation operation)
    {
        _value = value;
        _compareTo = compareTo;
        _operation = operation;
    }

    public TValue? Then(TValue? newValue)
    {
        if (_value == null && _compareTo == null)
            return _operation == ComparisonOperation.Equal ? newValue : _value;

        if (_value == null || _compareTo == null)
            return _operation == ComparisonOperation.NotEqual ? newValue : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.Value.CompareTo(_compareTo.Value) > 0 ? newValue : _value,
            ComparisonOperation.GreaterOrEqual => _value.Value.CompareTo(_compareTo.Value) >= 0 ? newValue : _value,
            ComparisonOperation.Equal => _value.Value.CompareTo(_compareTo.Value) == 0 ? newValue : _value,
            ComparisonOperation.NotEqual => _value.Value.CompareTo(_compareTo.Value) != 0 ? newValue : _value,
            ComparisonOperation.Less => _value.Value.CompareTo(_compareTo.Value) < 0 ? newValue : _value,
            ComparisonOperation.LessOrEqual => _value.Value.CompareTo(_compareTo.Value) <= 0 ? newValue : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }

    public TValue? Then(Func<TValue?> newValue)
    {
        if (_value == null && _compareTo == null)
            return _operation == ComparisonOperation.Equal ? newValue() : _value;

        if (_value == null || _compareTo == null)
            return _operation == ComparisonOperation.NotEqual ? newValue() : _value;

        TValue? result = _operation switch
        {
            ComparisonOperation.Greater => _value.Value.CompareTo(_compareTo.Value) > 0 ? newValue() : _value,
            ComparisonOperation.GreaterOrEqual => _value.Value.CompareTo(_compareTo.Value) >= 0 ? newValue() : _value,
            ComparisonOperation.Equal => _value.Value.CompareTo(_compareTo.Value) == 0 ? newValue() : _value,
            ComparisonOperation.NotEqual => _value.Value.CompareTo(_compareTo.Value) != 0 ? newValue() : _value,
            ComparisonOperation.Less => _value.Value.CompareTo(_compareTo.Value) < 0 ? newValue() : _value,
            ComparisonOperation.LessOrEqual => _value.Value.CompareTo(_compareTo.Value) <= 0 ? newValue() : _value,
            _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
        };
        return result;
    }
}