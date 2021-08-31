using System;
using NUnit.Framework;
using SourceDesigner.Utilities;

namespace SourceDesignerTests.Utilities
{
    [TestFixture]
    public class EnumUtilitiesTests
    {
        private enum ValueEnum
        {
            SomeValue,
            SomeOtherValue,
        }

        [Flags]
        private enum FlagEnum
        {
            None = 0,
            FlagA = 1,
            FlagB = 2,
        }

        [Test]
        public void GetAll_ReturnsAllValues()
        {
            Assert.That(EnumUtilities.GetAll<ValueEnum>(),
                Is.EquivalentTo(new[]{ValueEnum.SomeValue, ValueEnum.SomeOtherValue}));
            Assert.That(EnumUtilities.GetAll<FlagEnum>(),
                Is.EquivalentTo(new[]{FlagEnum.None, FlagEnum.FlagA, FlagEnum.FlagB}));
        }
    }
}