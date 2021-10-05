using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using SourceDesigner;
using SourceDesigner.Utilities;

namespace SourceDesignerTests.Utilities
{
    [TestFixture]
    public class StringExtensionTests
    {
        private static object[][] removeTrailingWhitespaceExpectedOutcomes =
        {
            new object[] { string.Empty, string.Empty },
            new object[] { " ", string.Empty },
            new object[] { "    ", string.Empty },
            new object[] { "\t", string.Empty },
            new object[] { "\t\t", string.Empty },
            new object[] { "\t \t", string.Empty },
            new object[] { " \t ", string.Empty },
            new object[] { " a", " a" },
            new object[] { "\ta", "\ta" },
            new object[] { " a ", " a" },
            new object[] { " a\t", " a" },
            new object[] { $"a {Environment.NewLine}b ", $"a{Environment.NewLine}b" },
            new object[]
            {
                $"a {Environment.NewLine} {Environment.NewLine}b ",
                $"a{Environment.NewLine}{Environment.NewLine}b"
            },
        };

        private static object[][] indentationExpectedOutcomes =
        {
            new object[] { string.Empty, string.Empty },
            new object[] { CodeStyle.Default.Indentation, string.Empty },
            new object[] { "a", $"{CodeStyle.Default.Indentation}a" },
            new object[]
            {
                $"{CodeStyle.Default.Indentation}a",
                $"{CodeStyle.Default.Indentation}{CodeStyle.Default.Indentation}a"
            },
            new object[]
            {
                $"a{Environment.NewLine}b",
                $"{CodeStyle.Default.Indentation}a{Environment.NewLine}{CodeStyle.Default.Indentation}b"
            },
            new object[]
            {
                $"a{Environment.NewLine}{Environment.NewLine}b",
                $"{CodeStyle.Default.Indentation}a{Environment.NewLine}{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}b"
            },
            new object[]
            {
                $"a{Environment.NewLine}{CodeStyle.Default.Indentation}{Environment.NewLine}b",
                $"{CodeStyle.Default.Indentation}a{Environment.NewLine}{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}b"
            },
        };

        private static object[][] wrapInBracesAndIndentExpectedOutcomes =
        {
            new object[] { string.Empty, $"{{{Environment.NewLine}}}" },
            new object[] { CodeStyle.Default.Indentation, $"{{{Environment.NewLine}}}" },
            new object[]
            {
                $"{CodeStyle.Default.Indentation}a",
                $"{{{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}{CodeStyle.Default.Indentation}a{Environment.NewLine}" +
                $"}}"
            },
            new object[]
            {
                "a",
                $"{{{Environment.NewLine}{CodeStyle.Default.Indentation}a{Environment.NewLine}}}"
            },
            new object[]
            {
                $"a{Environment.NewLine}b",
                $"{{{Environment.NewLine}{CodeStyle.Default.Indentation}a{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}b{Environment.NewLine}}}"
            },
            new object[]
            {
                $"a{Environment.NewLine}{Environment.NewLine}b",
                $"{{{Environment.NewLine}{CodeStyle.Default.Indentation}a{Environment.NewLine}{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}b{Environment.NewLine}}}"
            },
            new object[]
            {
                $"a{Environment.NewLine}{CodeStyle.Default.Indentation}{Environment.NewLine}b",
                $"{{{Environment.NewLine}{CodeStyle.Default.Indentation}a{Environment.NewLine}{Environment.NewLine}" +
                $"{CodeStyle.Default.Indentation}b{Environment.NewLine}}}"
            },
        };
        
        [TestCase("\n")]
        [TestCase("a\n")]
        [TestCase("\na")]
        [TestCase("a\na")]
        [TestCase("\n\n")]
        [TestCase("a\n\n")]
        [TestCase("\n\na")]
        [TestCase("a\n\na")]
        [TestCase("\r\n")]
        [TestCase("a\r\n")]
        [TestCase("\r\na")]
        [TestCase("a\r\na")]
        [TestCase("\r\n\r\n")]
        [TestCase("a\r\n\r\n")]
        [TestCase("\r\n\r\na")]
        [TestCase("a\r\n\r\na")]
        public void IsMultiLine_True(string input) => Assert.That(input.IsMultiLine(), Is.True);

        [TestCase("")]
        [TestCase("a")]
        [TestCase("\r")]
        [TestCase("a\r")]
        [TestCase("\ra")]
        [TestCase("a\ra")]
        public void IsMultiLine_False(string input) => Assert.That(input.IsMultiLine(), Is.False);

        [TestCaseSource(nameof(removeTrailingWhitespaceExpectedOutcomes))]
        public void RemoveTrailingWhitespace_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.RemoveTrailingWhitespace(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void RemoveTrailingWhitespace_Null_Throws()
        {
            Assert.That(() => StringExtensions.RemoveTrailingWhitespace(null), Throws.ArgumentNullException);
        }

        [TestCaseSource(nameof(indentationExpectedOutcomes))]
        public void Indent_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.Indent(CodeStyle.Default), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Indent_NullInput_Throws()
        {
            Assert.That(() => StringExtensions.Indent(null, CodeStyle.Default), Throws.ArgumentNullException);
            Assert.That(() => string.Empty.Indent(null), Throws.ArgumentNullException);
        }

        [TestCase("", "")]
        [TestCase("a", "a ")]
        [TestCase("a ", "a ")]
        [TestCase(" ", " ")]
        public void WithTrailingSpace_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.WithTrailingSpace(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void WithTrailingSpace_NullInput_Throws()
        {
            Assert.That(() => StringExtensions.WithTrailingSpace(null), Throws.ArgumentNullException);
        }

        [TestCase("", "")]
        [TestCase("a", " a")]
        [TestCase(" a", " a")]
        [TestCase(" ", " ")]
        public void WithLeadingSpace_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.WithLeadingSpace(), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void WithLeadingSpace_NullInput_Throws()
        {
            Assert.That(() => StringExtensions.WithLeadingSpace(null), Throws.ArgumentNullException);
        }

        [TestCaseSource(nameof(wrapInBracesAndIndentExpectedOutcomes))]
        public void WrapInBracesAndIndent_ExpectedOutcome(string input, string expectedOutcome)
        {
            Assert.That(input.WrapInBracesAndIndent(CodeStyle.Default), Is.EqualTo(expectedOutcome));
        }

        [Test]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void WrapInBracesAndIndent_NullInput_Throws()
        {
            Assert.That(() => StringExtensions.WrapInBracesAndIndent(null, CodeStyle.Default),
                Throws.ArgumentNullException);
            Assert.That(() => string.Empty.WrapInBracesAndIndent(null), Throws.ArgumentNullException);
        }
    }
}