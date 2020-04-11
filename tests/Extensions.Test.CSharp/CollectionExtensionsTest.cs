using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maestria.Extensions;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class CollectionExtensionsTest
    {
        private readonly IEnumerable _enumerable = new List<int> {10, 20, 30};
        private readonly IEnumerable<int> _enumerableTyped = new List<int> {10, 20, 30};

        private readonly IDictionary<string, int> _dictionary = new Dictionary<string, int>
        {
            {"key1", 10},
            {"key2", 20},
            {"key3", 30},
        };

        private void AssetArrayIndex(object item, int index)
        {
            switch (item)
            {
                case 10:
                    Assert.AreEqual(0, index);
                    break;
                case 20:
                    Assert.AreEqual(1, index);
                    break;
                case 30:
                    Assert.AreEqual(2, index);
                    break;
                default:
                    Assert.Fail("Unexpected item");
                    break;
            }
        }

        [Test]
        public void Iterate()
        {
            var sum = 0;
            _enumerable.Iterate(item => sum += (int) item);
            Assert.AreEqual(60, sum);
        }

        [Test]
        public void Iterate_WithIndex()
        {
            var sum = 0;
            _enumerable.Iterate((item, index) =>
            {
                AssetArrayIndex(item, index);
                sum += (int) item;
            });
            Assert.AreEqual(60, sum);
        }

        [Test]
        public void Iterate_Typed()
        {
            var sum = 0;
            _enumerableTyped.Iterate(item => sum += item);
            Assert.AreEqual(60, sum);
        }

        [Test]
        public void Iterate_Typed_WithIndex()
        {
            var sum = 0;
            _enumerableTyped.Iterate((item, index) =>
            {
                AssetArrayIndex(item, index);
                sum += item;
            });
            Assert.AreEqual(60, sum);
        }

        [Test]
        public async Task IterateAsync()
        {
            var sum = 0;
            await _enumerable.IterateAsync(async item =>
            {
                Task temp = Task.Factory.StartNew(() => sum += (int) item);
                await temp;
            });
            Assert.AreEqual(60, sum);
        }

        [Test]
        public async Task IterateAsync_WithIndex()
        {
            var sum = 0;
            await _enumerable.IterateAsync(async (item, index) =>
            {
                AssetArrayIndex(item, index);
                Task temp = Task.Factory.StartNew(() => sum += (int) item);
                await temp;
            });
            Assert.AreEqual(60, sum);
        }

        [Test]
        public async Task IterateAsync_Typed()
        {
            var sum = 0;
            await _enumerableTyped.IterateAsync(async item =>
            {
                Task temp = Task.Factory.StartNew(() => sum += item);
                await temp;
            });
            Assert.AreEqual(60, sum);
        }

        [Test]
        public async Task IterateAsync_Typed_WithIndex()
        {
            var sum = 0;
            await _enumerableTyped.IterateAsync(async (item, index) =>
            {
                AssetArrayIndex(item, index);
                Task temp = Task.Factory.StartNew(() => sum += item);
                await temp;
            });
            Assert.AreEqual(60, sum);
        }

        [TestCase("key1", 10)]
        [TestCase("key2", 20)]
        [TestCase("key3", 30)]
        public void TryGetValue(string key, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _dictionary.TryGetValue(key));
        }

        [Test]
        public void TryGetValue_InvalidKey()
        {
            Assert.AreEqual(0, _dictionary.TryGetValue("invalid key"));
            Assert.AreEqual(-1, _dictionary.TryGetValue("invalid key", -1));
        }

        [Test]
        public void WithIndex()
        {
            foreach (var (item, index) in _enumerableTyped.WithIndex())
            {
                switch (index)
                {
                    case 0:
                        Assert.AreEqual(10, item);
                        break;
                    case 1:
                        Assert.AreEqual(20, item);
                        break;
                    case 2:
                        Assert.AreEqual(30, item);
                        break;
                    default:
                        Assert.Fail("Unexpected value");
                        break;
                }
            }
        }
    }
}