using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class CollectionExtensionsTest
{
    private readonly IEnumerable _enumerable = new List<int> {10, 20, 30};
    private readonly IEnumerable<int> _enumerableTyped = new List<int> {10, 20, 30};
    private readonly int[] _array = {1, 2, 3, 4, 5};
    private readonly int[] _emptyArray = System.Array.Empty<int>();
    private readonly List<int> _nullList = null;

    private readonly IDictionary<string, int> _dictionary = new Dictionary<string, int>
    {
        {"key1", 10},
        {"key2", 20},
        {"key3", 30},
    };

    private readonly IDictionary<string, int?> _dictionaryWithNullable = new Dictionary<string, int?>
    {
        {"key1", 10},
        {"key2", 20},
        {"key3", 30},
        {"key4", null},
    };

    private void AssetArrayIndex(object item, int index)
    {
        switch (item)
        {
            case 10:
                Assert.Equal(0, index);
                break;
            case 20:
                Assert.Equal(1, index);
                break;
            case 30:
                Assert.Equal(2, index);
                break;
            default:
                Assert.Fail("Unexpected item");
                break;
        }
    }

    [Fact]
    public void Iterate()
    {
        var sum = 0;
        _enumerable.Iterate(item => sum += (int) item);
        Assert.Equal(60, sum);
    }

    [Fact]
    public void Iterate_WithIndex()
    {
        var sum = 0;
        _enumerable.Iterate((item, index) =>
        {
            AssetArrayIndex(item, index);
            sum += (int) item;
        });
        Assert.Equal(60, sum);
    }

    [Fact]
    public void Iterate_Typed()
    {
        var sum = 0;
        _enumerableTyped.Iterate(item => sum += item);
        Assert.Equal(60, sum);
    }

    [Fact]
    public void Iterate_Typed_WithIndex()
    {
        var sum = 0;
        _enumerableTyped.Iterate((item, index) =>
        {
            AssetArrayIndex(item, index);
            sum += item;
        });
        Assert.Equal(60, sum);
    }

    [Fact]
    public async Task IterateAsync()
    {
        var sum = 0;
        await _enumerable.Iterate(async item =>
        {
            Task temp = Task.Factory.StartNew(() => sum += (int) item);
            await temp;
        });
        Assert.Equal(60, sum);
    }

    [Fact]
    public async Task IterateAsync_WithIndex()
    {
        var sum = 0;
        await _enumerable.Iterate(async (item, index) =>
        {
            AssetArrayIndex(item, index);
            Task temp = Task.Factory.StartNew(() => sum += (int) item);
            await temp;
        });
        Assert.Equal(60, sum);
    }

    [Fact]
    public async Task IterateAsync_Typed()
    {
        var sum = 0;
        await _enumerableTyped.Iterate(async item =>
        {
            Task temp = Task.Factory.StartNew(() => sum += item);
            await temp;
        });
        Assert.Equal(60, sum);
    }

    [Fact]
    public async Task IterateAsync_Typed_WithIndex()
    {
        var sum = 0;
        await _enumerableTyped.Iterate(async (item, index) =>
        {
            AssetArrayIndex(item, index);
            Task temp = Task.Factory.StartNew(() => sum += item);
            await temp;
        });
        Assert.Equal(60, sum);
    }

    [Theory]
    [InlineData("key1", 10)]
    [InlineData("key2", 20)]
    [InlineData("key3", 30)]
    public void TryGetValue(string key, int expectedValue)
    {
        Assert.Equal(expectedValue, _dictionary.TryGetValue(key));
    }

    [Theory]
    [InlineData("key1", 10)]
    [InlineData("key2", 20)]
    [InlineData("key3", 30)]
    [InlineData("key4", null)]
    public void TryGetValueInDictionaryWithNullable(string key, int? expectedValue)
    {
        Assert.Equal(expectedValue, _dictionaryWithNullable.TryGetValue(key));
    }

    [Fact]
    public void TryGetValue_InvalidKey()
    {
        Assert.Equal(0, _dictionary.TryGetValue("invalid key"));
        Assert.Equal(-1, _dictionary.TryGetValue("invalid key", -1));
    }

    [Theory]
    [InlineData("key1", 10)]
    [InlineData("key2", 20)]
    [InlineData("key3", 30)]
    public void TryGetValueFunc(string key, int expectedValue)
    {
        Assert.Equal(expectedValue, _dictionary.TryGetValue(key));
    }

    [Theory]
    [InlineData("key1", 10)]
    [InlineData("key2", 20)]
    [InlineData("key3", 30)]
    [InlineData("key4", null)]
    public void TryGetValueInDictionaryWithNullableFunc(string key, int? expectedValue)
    {
        Assert.Equal(expectedValue, _dictionaryWithNullable.TryGetValue(key));
    }

    [Fact]
    public void TryGetValueFunc_InvalidKey()
    {
        Assert.Equal(-1, _dictionary.TryGetValue("invalid key", () => -1));
    }

    [Fact]
    public void WithIndex_Untyped()
    {
        foreach (var (item, index) in _enumerable.WithIndex())
        {
            switch (index)
            {
                case 0:
                    Assert.Equal(10, item);
                    break;
                case 1:
                    Assert.Equal(20, item);
                    break;
                case 2:
                    Assert.Equal(30, item);
                    break;
                default:
                    Assert.Fail("Unexpected value");
                    break;
            }
        }
    }

    [Fact]
    public void WithIndex_Typed()
    {
        foreach (var (item, index) in _enumerableTyped.WithIndex())
        {
            switch (index)
            {
                case 0:
                    Assert.Equal(10, item);
                    break;
                case 1:
                    Assert.Equal(20, item);
                    break;
                case 2:
                    Assert.Equal(30, item);
                    break;
                default:
                    Assert.Fail("Unexpected value");
                    break;
            }
        }
    }

    // Tests from F# CollectionExtensionsTest
    [Fact]
    public void Iterate_ArrayForEachExecute()
    {
        _array.Iterate(i => Assert.True(new[] {1, 2, 3, 4, 5}.Contains(i)));
    }

    [Fact]
    public void Iterate_EmptyCollectionForEachExecute()
    {
        var result = _emptyArray.Iterate(i => { });
        Assert.Equal(_emptyArray, result);
    }

    [Fact]
    public void Iterate_NullCollectionForEachExecute()
    {
        var result = _nullList.Iterate(i => { });
        Assert.Equal(_nullList, result);
    }

    [Fact]
    public void IsNullOrEmpty_AnyCollectionIsEmptyCheck()
    {
        Assert.False(_array.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_EmptyCollectionIsEmptyCheck()
    {
        Assert.True(_emptyArray.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_NullCollectionIsEmptyCheck()
    {
        Assert.True(_nullList.IsNullOrEmpty());
    }

    [Fact]
    public void HasItems_AnyCollectionHasItemsCheck()
    {
        Assert.True(_array.HasItems());
    }

    [Fact]
    public void HasItems_EmptyCollectionHasItemsCheck()
    {
        Assert.False(_emptyArray.HasItems());
    }

    [Fact]
    public void HasItems_NullCollectionHasItemsCheck()
    {
        Assert.False(_nullList.HasItems());
    }
}
