using System;

namespace Maestria.Extensions.DataTypes
{
    public struct NullableComparable<T> : IComparable, IComparable<T>, IComparable<Nullable<T>>, IComparable<NullableComparable<T>>
        where T : struct, IComparable
    {
        private Nullable<T> _valueRef;
        public T Value => _valueRef.Value;
        public bool HasValue => _valueRef.HasValue;

        public NullableComparable(T? value)
        {
            _valueRef = value;
        }

        public T GetValueOrDefault() => _valueRef.GetValueOrDefault();
        public T GetValueOrDefault(T defaultValue) => _valueRef.GetValueOrDefault(defaultValue);
        public override string ToString() => _valueRef.ToString();
        public override bool Equals(object obj) => _valueRef.Equals(obj);
        public override int GetHashCode() => _valueRef.GetHashCode();

        public int CompareTo(object other)
        {
            if (_valueRef == null)
                return default(T).CompareTo(other);
            
            if (other == null)
                return _valueRef.Value.CompareTo(default(T));

            if (other is NullableComparable<T> otherNullableComp)
                return _valueRef.Value.CompareTo(otherNullableComp.Value);

            if (other is T?)
                return _valueRef.Value.CompareTo(((T?) other).Value);
            
            return _valueRef.Value.CompareTo(other);
        }

        public int CompareTo(T other)
        {
            if (_valueRef == null)
                return default(T).CompareTo(other);
            
            return _valueRef.Value.CompareTo(other);
        }

        public int CompareTo(T? other)
        {
            if (_valueRef == null)
                return default(T).CompareTo(other);
            
            if (other == null)
                return _valueRef.Value.CompareTo(default(T));

            return _valueRef.Value.CompareTo(other.Value);
        }

        public int CompareTo(NullableComparable<T> other)
        {
            if (_valueRef == null)
                return default(T).CompareTo(other);
            
            if (other._valueRef == null)
                return _valueRef.Value.CompareTo(default(T));

            return _valueRef.Value.CompareTo(other.Value);
        }

        public static implicit operator T(NullableComparable<T> value) => value._valueRef.Value;
        public static implicit operator T?(NullableComparable<T> value) => value._valueRef;
        public static implicit operator NullableComparable<T>(T value) => new NullableComparable<T>(value);
        public static implicit operator NullableComparable<T>(T? value) => new NullableComparable<T>(value);
    }
}