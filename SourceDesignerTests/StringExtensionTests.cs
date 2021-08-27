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
    }
}