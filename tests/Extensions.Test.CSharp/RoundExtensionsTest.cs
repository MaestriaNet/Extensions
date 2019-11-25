using System;
using NUnit.Framework;
// ReSharper disable InconsistentNaming

namespace Maestria.Extensions.Test.CSharp
{
    #region Not nullable
    
    public class RoundExtensions_FloatTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123f, 123.45f.Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45f, 123.4533f.Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22f, 1.225f.Round(2));
            Assert.AreEqual(1.24f, 1.235f.Round(2));
            
            Assert.AreEqual(1.22f, 1.225f.Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24f, 1.235f.Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23f, 1.225f.Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24f, 1.235f.Round(2, MidpointRounding.AwayFromZero));
        } 
    }
    
    public class RoundExtensions_DoubleTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123d, 123.45d.Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45d, 123.4533d.Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22d, 1.225d.Round(2));
            Assert.AreEqual(1.24d, 1.235d.Round(2));
            
            Assert.AreEqual(1.22d, 1.225d.Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24d, 1.235d.Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23d, 1.225d.Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24d, 1.235d.Round(2, MidpointRounding.AwayFromZero));
        } 
    }

    public class RoundExtensions_DecimalTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123m, 123.45m.Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45m, 123.4533m.Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22m, 1.225m.Round(2));
            Assert.AreEqual(1.24m, 1.235m.Round(2));
            
            Assert.AreEqual(1.22m, 1.225m.Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24m, 1.235m.Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23m, 1.225m.Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24m, 1.235m.Round(2, MidpointRounding.AwayFromZero));
        } 
    }
    
    #endregion
    
    #region Nullable
    
    public class RoundExtensions_NullableFloatTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123f, new float?(123.45f).Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45f, new float?(123.4533f).Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22f, new float?(1.225f).Round(2));
            Assert.AreEqual(1.24f, new float?(1.235f).Round(2));
            
            Assert.AreEqual(1.22f, new float?(1.225f).Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24f, new float?(1.235f).Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23f, new float?(1.225f).Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24f, new float?(1.235f).Round(2, MidpointRounding.AwayFromZero));
        } 
    }
    
    public class RoundExtensions_NullableDoubleTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123d, new double?(123.45d).Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45d, new double?(123.4533d).Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22d, new double?(1.225d).Round(2));
            Assert.AreEqual(1.24d, new double?(1.235d).Round(2));
            
            Assert.AreEqual(1.22d, new double?(1.225d).Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24d, new double?(1.235d).Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23d, new double?(1.225d).Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24d, new double?(1.235d).Round(2, MidpointRounding.AwayFromZero));
        } 
    }

    public class RoundExtensions_NullableDecimalTest
    {
        [Test]
        public void Round() => Assert.AreEqual(123m, new decimal?(123.45m).Round());

        [Test]
        public void Round_TwoDigits() => Assert.AreEqual(123.45m, new decimal?(123.4533m).Round(2));
        
        [Test]
        public void Round_Midpoint()
        {
            Assert.AreEqual(1.22m, new decimal?(1.225m).Round(2));
            Assert.AreEqual(1.24m, new decimal?(1.235m).Round(2));
            
            Assert.AreEqual(1.22m, new decimal?(1.225m).Round(2, MidpointRounding.ToEven));
            Assert.AreEqual(1.24m, new decimal?(1.235m).Round(2, MidpointRounding.ToEven));
            
            Assert.AreEqual(1.23m, new decimal?(1.225m).Round(2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(1.24m, new decimal?(1.235m).Round(2, MidpointRounding.AwayFromZero));
        } 
    }
    
    #endregion
}