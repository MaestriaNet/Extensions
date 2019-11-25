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
        
        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1f, 1f.Truncate());
            Assert.AreEqual(1f, 1.225f.Truncate());
            Assert.AreEqual(1.22f, 1.22f.Truncate(2));
            Assert.AreEqual(1.22f, 1.225f.Truncate(2));
            Assert.AreEqual(1.23f, 1.235f.Truncate(2));
            Assert.AreEqual(1.23f, 1.231f.Truncate(2));
            Assert.AreEqual(1.23f, 1.239f.Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1f, 1f.RoundUp());
            Assert.AreEqual(2f, 1.225f.RoundUp());
            Assert.AreEqual(1.22f, 1.22f.RoundUp(2));
            Assert.AreEqual(1.23f, 1.225f.RoundUp(2));
            Assert.AreEqual(1.24f, 1.235f.RoundUp(2));
            Assert.AreEqual(1.24f, 1.231f.RoundUp(2));
            Assert.AreEqual(1.24f, 1.239f.RoundUp(2));
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
        
        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1d, 1d.Truncate());
            Assert.AreEqual(1d, 1.225d.Truncate());
            Assert.AreEqual(1.22d, 1.22d.Truncate(2));
            Assert.AreEqual(1.22d, 1.225d.Truncate(2));
            Assert.AreEqual(1.23d, 1.235d.Truncate(2));
            Assert.AreEqual(1.23d, 1.231d.Truncate(2));
            Assert.AreEqual(1.23d, 1.239d.Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1d, 1d.RoundUp());
            Assert.AreEqual(2d, 1.225d.RoundUp());
            Assert.AreEqual(1.22d, 1.22d.RoundUp(2));
            Assert.AreEqual(1.23d, 1.225d.RoundUp(2));
            Assert.AreEqual(1.24d, 1.235d.RoundUp(2));
            Assert.AreEqual(1.24d, 1.231d.RoundUp(2));
            Assert.AreEqual(1.24d, 1.239d.RoundUp(2));
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

        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1m, 1m.Truncate());
            Assert.AreEqual(1m, 1.225m.Truncate());
            Assert.AreEqual(1.22m, 1.22m.Truncate(2));
            Assert.AreEqual(1.22m, 1.225m.Truncate(2));
            Assert.AreEqual(1.23m, 1.235m.Truncate(2));
            Assert.AreEqual(1.23m, 1.231m.Truncate(2));
            Assert.AreEqual(1.23m, 1.239m.Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1m, 1m.RoundUp());
            Assert.AreEqual(2m, 1.225m.RoundUp());
            Assert.AreEqual(1.22m, 1.22m.RoundUp(2));
            Assert.AreEqual(1.23m, 1.225m.RoundUp(2));
            Assert.AreEqual(1.24m, 1.235m.RoundUp(2));
            Assert.AreEqual(1.24m, 1.231m.RoundUp(2));
            Assert.AreEqual(1.24m, 1.239m.RoundUp(2));
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
        
        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1f, new float?(1f).Truncate());
            Assert.AreEqual(1f, new float?(1.225f).Truncate());
            Assert.AreEqual(1.22f, new float?(1.22f).Truncate(2));
            Assert.AreEqual(1.22f, new float?(1.225f).Truncate(2));
            Assert.AreEqual(1.23f, new float?(1.235f).Truncate(2));
            Assert.AreEqual(1.23f, new float?(1.231f).Truncate(2));
            Assert.AreEqual(1.23f, new float?(1.239f).Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1f, new float?(1f).RoundUp());
            Assert.AreEqual(2f, new float?(1.225f).RoundUp());
            Assert.AreEqual(1.22f, new float?(1.22f).RoundUp(2));
            Assert.AreEqual(1.23f, new float?(1.225f).RoundUp(2));
            Assert.AreEqual(1.24f, new float?(1.235f).RoundUp(2));
            Assert.AreEqual(1.24f, new float?(1.231f).RoundUp(2));
            Assert.AreEqual(1.24f, new float?(1.239f).RoundUp(2));
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
        
        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1d, new double?(1d).Truncate());
            Assert.AreEqual(1d, new double?(1.225d).Truncate());
            Assert.AreEqual(1.22d, new double?(1.22d).Truncate(2));
            Assert.AreEqual(1.22d, new double?(1.225d).Truncate(2));
            Assert.AreEqual(1.23d, new double?(1.235d).Truncate(2));
            Assert.AreEqual(1.23d, new double?(1.231d).Truncate(2));
            Assert.AreEqual(1.23d, new double?(1.239d).Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1d, new double?(1d).RoundUp());
            Assert.AreEqual(2d, new double?(1.225d).RoundUp());
            Assert.AreEqual(1.22d, new double?(1.22d).RoundUp(2));
            Assert.AreEqual(1.23d, new double?(1.225d).RoundUp(2));
            Assert.AreEqual(1.24d, new double?(1.235d).RoundUp(2));
            Assert.AreEqual(1.24d, new double?(1.231d).RoundUp(2));
            Assert.AreEqual(1.24d, new double?(1.239d).RoundUp(2));
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
        
        [Test]
        public void Truncate()
        {
            Assert.AreEqual(1m, new decimal?(1m).Truncate());
            Assert.AreEqual(1m, new decimal?(1.225m).Truncate());
            Assert.AreEqual(1.22m, new decimal?(1.22m).Truncate(2));
            Assert.AreEqual(1.22m, new decimal?(1.225m).Truncate(2));
            Assert.AreEqual(1.23m, new decimal?(1.235m).Truncate(2));
            Assert.AreEqual(1.23m, new decimal?(1.231m).Truncate(2));
            Assert.AreEqual(1.23m, new decimal?(1.239m).Truncate(2));
        }
        
        [Test]
        public void RoundUp()
        {
            Assert.AreEqual(1m, new decimal?(1m).RoundUp());
            Assert.AreEqual(2m, new decimal?(1.225m).RoundUp());
            Assert.AreEqual(1.22m, new decimal?(1.22m).RoundUp(2));
            Assert.AreEqual(1.23m, new decimal?(1.225m).RoundUp(2));
            Assert.AreEqual(1.24m, new decimal?(1.235m).RoundUp(2));
            Assert.AreEqual(1.24m, new decimal?(1.231m).RoundUp(2));
            Assert.AreEqual(1.24m, new decimal?(1.239m).RoundUp(2));
        }
    }
    
    #endregion
}