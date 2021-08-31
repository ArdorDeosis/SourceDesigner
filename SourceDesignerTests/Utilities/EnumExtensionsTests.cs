using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using SourceDesigner;
using SourceDesigner.Utilities;

namespace SourceDesignerTests.Utilities
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EnumExtensionsTests
    {
        private const string SomeValue_CodeRepresentation = "some value";
        private const string FlagA_CodeRepresentation = "a";
        private const string FlagB_CodeRepresentation = "b";
        private const string FlagAB_CodeRepresentation = FlagA_CodeRepresentation + " " + FlagB_CodeRepresentation;

        private enum ValueEnum
        {
            [CodeRepresentation(SomeValue_CodeRepresentation)]
            SomeValue,
            SomeOtherValue,
        }

        [Flags]
        public enum FlagEnum
        {
            None = 0,
            [CodeRepresentation(FlagA_CodeRepresentation)]
            FlagA = 1,
            [CodeRepresentation(FlagB_CodeRepresentation)]
            FlagB = 2,
            FlagC = 4,
        }
        
        [Test]
        public void EnumToCode_ExpectedOutcome()
        {
            Assert.That(ValueEnum.SomeValue.EnumToCode(), Is.EqualTo(SomeValue_CodeRepresentation));
        }
        
        [Test]
        public void EnumToCode_NoCodeRepresentationAttribute_Throws()
        {
            Assert.That(() => ValueEnum.SomeOtherValue.EnumToCode(), Throws.Exception);
        }
        
        [TestCase(FlagEnum.None, "")]
        [TestCase(FlagEnum.FlagA, FlagA_CodeRepresentation)]
        [TestCase(FlagEnum.FlagB, FlagB_CodeRepresentation)]
        [TestCase(FlagEnum.FlagA | FlagEnum.FlagB, FlagAB_CodeRepresentation)]
        public void FlagEnumToCode_ExpectedOutcome(FlagEnum value, string expectedOutcome)
        {
            Assert.That(value.FlagEnumToCode(), Is.EqualTo(expectedOutcome));
        }
        
        [TestCase(FlagEnum.FlagC)]
        [TestCase(FlagEnum.FlagA | FlagEnum.FlagC)]
        [TestCase(FlagEnum.FlagB | FlagEnum.FlagC)]
        [TestCase(FlagEnum.FlagA | FlagEnum.FlagB | FlagEnum.FlagC)]
        public void FlagEnumToCode_NoCodeRepresentationAttribute_Throws(FlagEnum value)
        {
            Assert.That(() => ValueEnum.SomeOtherValue.EnumToCode(), Throws.Exception);
        }
    }
}