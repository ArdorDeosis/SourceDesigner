using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using SourceDesigner;
using SourceDesigner.Utilities;

namespace SourceDesignerTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        private static object[][] indentationExpectedOutcomes =
        {
            new object[] { string.Empty, CodeStyle.Default.Indentation },
            new object[] { "a", $"{CodeStyle.Default.Indentation}a" },
            new object[] { $"{CodeStyle.Default.Indentation}a",
                $"{CodeStyle.Default.Indentation}{CodeStyle.Default.Indentation}a" },
            new object[] { $"a{Environment.NewLine}b",
                    $"{CodeStyle.Default.Indentation}a{Environment.NewLine}{CodeStyle.Default.Indentation}b" },
        };

        [TestCaseSource(nameof(indentationExpectedOutcomes))]
        public void Indent_SeveralValues_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.Indent(CodeStyle.Default), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Indent_Null_Throws()
        {
            Assert.That(() => StringExtensions.Indent(null, CodeStyle.Default), Throws.ArgumentNullException);
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Indent_NullStyle_Throws()
        {
            Assert.That(() => "".Indent(null), Throws.ArgumentNullException);
        }

        [TestCase("type")]
        [TestCase("Type")]
        [TestCase("_type")]
        [TestCase("_type1337")]
        [TestCase("_1337")]
        [TestCase("NameSpace.Type")]
        [TestCase("namespace.type")]
        [TestCase("_.type")]
        public void IsValidTypeName_SeveralValidValues_true(string value)
        {
            Assert.That(value.IsValidTypeName());
        }

        [TestCase("-type")]
        [TestCase("#type")]
        [TestCase("1337")]
        [TestCase("NameSpace.1337")]
        [TestCase("namespace..type")]
        [TestCase(".type")]
        [TestCase("namespace.")]
        public void IsValidTypeName_SeveralValidValues_false(string value)
        {
            Assert.That(value.IsValidTypeName(), Is.False);
        }

        [TestCase("type")]
        [TestCase("Type")]
        [TestCase("_type")]
        [TestCase("_type1337")]
        [TestCase("_1337")]
        public void IsValidIdentifier_SeveralValidValues_true(string value)
        {
            Assert.That(value.IsValidIdentifier());
        }

        [TestCase("-type")]
        [TestCase("#type")]
        [TestCase(".type")]
        [TestCase("_.type")]
        [TestCase("1337")]
        [TestCase("NameSpace.1337")]
        [TestCase("namespace.type")]
        [TestCase("namespace.")]
        [TestCase("NameSpace.Type")]
        [TestCase("namespace.type")]
        public void IsValidIdentifier_SeveralValidValues_false(string value)
        {
            Assert.That(value.IsValidIdentifier(), Is.False);
        }
    }
}