﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;

using FluentAssertions;

using Microsoft.CodeAnalysis.Sarif;
using Microsoft.CodeAnalysis.Sarif.Writers;

using Newtonsoft.Json.Linq;

using Xunit;

namespace Microsoft.CodeAnalysis.Test.UnitTests.Sarif.Core
{
    public class ResultTests
    {
        [Fact]
        public void Result_Kind_ResetsLevelValue()
        {
            // This test ensures NotYetAutoGenerated field 'Level' value is reset if 'Kind' value is changed to a non-default value.
            // see .src/sarif/NotYetAutoGenerated/Result.cs (Level property)
            var result = new Result();

            result.Level.Should().Be(FailureLevel.Warning);

            result.GetEffectiveLevel(new ReportingDescriptor()).Should().Be(FailureLevel.Warning);

            result.Kind = ResultKind.Pass;

            result.Level.Should().Be(FailureLevel.None);

            result.GetEffectiveLevel(new ReportingDescriptor()).Should().Be(FailureLevel.None);
        }

        [Fact]
        public void Result_Level_ResetsKindValue()
        {
            // This test ensures NotYetAutoGenerated field 'Kind' value is reset if 'Level' value is changed to a non-default value.
            // see .src/sarif/NotYetAutoGenerated/Result.cs (Kind property)
            var result = new Result();

            result.Kind.Should().Be(ResultKind.Fail); // Default value

            result.Kind = ResultKind.Pass;
            result.Level = FailureLevel.Error;
            result.Kind.Should().Be(ResultKind.Fail);

            result.Kind = ResultKind.Pass;
            result.Level = FailureLevel.Warning;
            result.Kind.Should().Be(ResultKind.Fail);

            result.Kind = ResultKind.Pass;
            result.Level = FailureLevel.None;
            result.Kind.Should().Be(ResultKind.Pass);
        }

        [Fact]
        public void Result_Level_ResetsKindValue_WithDefaultConfiguration()
        {
            const string sampleRuleId = "SampleRuleId";
            ReportingConfiguration defaultConfiguration;
            Result result;

            result = new Result() { RuleId = sampleRuleId };
            // default values
            result.Level.Should().Be(FailureLevel.Warning);
            result.Kind.Should().Be(ResultKind.Fail);

            result.Kind = ResultKind.Pass;
            // manually set Kind, reset Level
            result.Level.Should().Be(FailureLevel.None);
            result.Kind.Should().Be(ResultKind.Pass);

            result = new Result() { RuleId = sampleRuleId };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.None };
            AssociateResultAndDefaultConfiguration(result, defaultConfiguration);
            // now default configuration is set, Level not set, default to whatever set in the default configuration (None)
            result.Level.Should().Be(FailureLevel.None);
            result.Kind.Should().Be(ResultKind.Fail); // If kind is absent, it SHALL default to "fail"

            result = new Result() { RuleId = sampleRuleId };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Error };
            AssociateResultAndDefaultConfiguration(result, defaultConfiguration);
            // now default configuration is set, Level not set, default to whatever set in the default configuration (Error)
            result.Level.Should().Be(FailureLevel.Error);
            result.Kind.Should().Be(ResultKind.Fail); // If kind is absent, it SHALL default to "fail"

            // continue above, now user update the default configuration (to None)
            defaultConfiguration.Level = FailureLevel.None;
            // still, user did not set the result level, so default to whatever set in the default configuration (None)
            result.Level.Should().Be(FailureLevel.None);
            result.Kind.Should().Be(ResultKind.Fail); // If kind is absent, it SHALL default to "fail"

            // continue above, now user got the actual applicable result level and set it (Note)
            result.Level = FailureLevel.Note;
            // now both default configuration (None) and actual result level (Note) is set, use actual value set
            result.Level.Should().Be(FailureLevel.Note);
            result.Kind.Should().Be(ResultKind.Fail); // If kind is absent, it SHALL default to "fail"

            // continue above, now user set the kind to review
            result.Kind = ResultKind.Review;
            // If kind (§3.27.9) has any value other than "fail", then if level is absent, it SHALL default to "none",
            // and if it is present, it SHALL have the value "none".
            result.Level.Should().Be(FailureLevel.None);
            result.Kind.Should().Be(ResultKind.Review); // Kind is present
        }

        [Fact]
        public void Result_Level_WriteCorrectValue_GeneralCases()
        {
            Result result;
            ReportingConfiguration defaultConfiguration;
            ReportingConfiguration overrideConfiguration;

            result = new Result() { Level = FailureLevel.Error };
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.Error);

            result = new Result() { Level = FailureLevel.Note };
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.Note);

            result = new Result() { Level = FailureLevel.None };
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.None);

            result = new Result() { Kind = ResultKind.Review };
            // If kind (§3.27.9) has any value other than "fail", then if level is absent, it SHALL default to "none",
            // and if it is present, it SHALL have the value "none".
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.None);

            result = new Result() { Kind = ResultKind.Fail, Level = FailureLevel.None };
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.None);

            result = new Result() { };
            Assert.True(WriteSarifThenReadLevelNode(result) == null);

            result = new Result() { Level = FailureLevel.Error };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Warning };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration) == FailureLevel.Error);

            result = new Result() { Level = FailureLevel.Error };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Warning };
            overrideConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Note };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration, overrideConfiguration) == FailureLevel.Error);
        }

        [Fact]
        public void Result_Level_WriteCorrectValue_Warning()
        {
            Result result;
            ReportingConfiguration defaultConfiguration;
            ReportingConfiguration overrideConfiguration;

            result = new Result() { Level = FailureLevel.Warning };
            Assert.True(WriteSarifThenReadLevelNode(result) == FailureLevel.Warning);

            result = new Result() { Level = FailureLevel.Warning };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Error };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration) == FailureLevel.Warning);

            result = new Result() { Level = FailureLevel.Warning };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Error };
            overrideConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Note };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration, overrideConfiguration) == FailureLevel.Warning);
        }

        [Fact]
        public void Result_Level_WriteCorrectValue_NotSet()
        {
            Result result;
            ReportingConfiguration defaultConfiguration;
            ReportingConfiguration overrideConfiguration;

            result = new Result() { };
            Assert.True(WriteSarifThenReadLevelNode(result) == null);

            result = new Result() { };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Error };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration) == null);

            result = new Result() { };
            defaultConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Error };
            overrideConfiguration = new ReportingConfiguration() { Enabled = true, Level = FailureLevel.Note };
            Assert.True(WriteSarifThenReadLevelNode(result, defaultConfiguration, overrideConfiguration) == null);
        }

        [Fact]
        public void Result_TryIsSuppressed_ShouldReturnFalseWhenNoSuppressionsAreAvailable()
        {
            var result = new Result();
            result.TryIsSuppressed(out bool _).Should().BeFalse();
        }

        [Fact]
        public void Result_TryIsSuppressed_ShouldReturnTrueWhenSuppressionsAreAvailable()
        {
            var result = new Result
            {
                Suppressions = new List<Suppression>()
            };
            result.TryIsSuppressed(out bool isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeFalse();

            // Suppression with 'UnderReview' only.
            result.Suppressions.Add(new Suppression { Status = SuppressionStatus.UnderReview });
            result.TryIsSuppressed(out isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeFalse();

            // Suppression with 'UnderReview' and 'Accepted'.
            result.Suppressions.Add(new Suppression { Status = SuppressionStatus.Accepted });
            result.TryIsSuppressed(out isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeFalse();

            // Suppression with 'Rejected' only.
            result.Suppressions.Clear();
            result.Suppressions.Add(new Suppression { Status = SuppressionStatus.Rejected });
            result.TryIsSuppressed(out isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeFalse();

            // Suppression with 'Rejected' and 'Accepted'.
            result.Suppressions.Add(new Suppression { Status = SuppressionStatus.Accepted });
            result.TryIsSuppressed(out isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeFalse();

            // Suppression with 'Accepted' only.
            result.Suppressions.Clear();
            result.Suppressions.Add(new Suppression { Status = SuppressionStatus.Accepted });
            result.TryIsSuppressed(out isSuppressed).Should().BeTrue();
            isSuppressed.Should().BeTrue();
        }

        private static FailureLevel? WriteSarifThenReadLevelNode(Result result,
            ReportingConfiguration defaultConfiguration = null, ReportingConfiguration overrideConfiguration = null)
        {
            const string sampleRuleId = "SampleRuleId";
            const string sampleMessage = "Sample Message";
            result.RuleId = sampleRuleId;
            result.Message = new Message() { Text = sampleMessage };

            List<ConfigurationOverride> ruleConfigurationOverrides = null;

            if (overrideConfiguration != null)
            {
                var ruleConfigurationOverride = new ConfigurationOverride()
                {
                    Descriptor = new ReportingDescriptorReference()
                    {
                        Index = 0
                    },
                    Configuration = overrideConfiguration
                };
                ruleConfigurationOverrides = new List<ConfigurationOverride>() { ruleConfigurationOverride };
            }

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);

            using (var logger = new SarifLogger(
                streamWriter,
                logFilePersistenceOptions: LogFilePersistenceOptions.PrettyPrint,
                dataToRemove: OptionallyEmittedData.NondeterministicProperties,
                closeWriterOnDispose: false,
                run: new Run() { Invocations = new List<Invocation> { new Invocation() { RuleConfigurationOverrides = ruleConfigurationOverrides } } },
                levels: new List<FailureLevel> { FailureLevel.Error, FailureLevel.Warning, FailureLevel.Note, FailureLevel.None },
                kinds: new List<ResultKind> { ResultKind.None, ResultKind.NotApplicable, ResultKind.Pass,
                    ResultKind.Fail, ResultKind.Review, ResultKind.Open, ResultKind.Informational }))
            {
                logger.Log(new ReportingDescriptor { Id = sampleRuleId, DefaultConfiguration = defaultConfiguration }, result);
            }

            // Important. Force streamwriter to commit everything.
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            string memoryStreamText = streamWriter.Encoding.GetString(memoryStream.ToArray());
            var jObject = JObject.Parse(memoryStreamText);
            JToken levelJson = jObject["runs"][0]["results"][0]["level"];
            string levelString = levelJson == null ? null : (string)levelJson;
            FailureLevel? level = levelString == null ? null : (FailureLevel?)Enum.Parse(typeof(FailureLevel), levelString, ignoreCase: true);
            return level;
        }

        private static void AssociateResultAndDefaultConfiguration(Result result,
            ReportingConfiguration defaultConfiguration = null)
        {
            Run run = new Run()
            {
                Tool = new Tool()
                {
                    Driver = new ToolComponent()
                    {
                        Rules = new List<ReportingDescriptor>()
                        {
                            new ReportingDescriptor()
                            {
                                Id = result.RuleId,
                                DefaultConfiguration = defaultConfiguration
                            }
                        }
                    }
                },
                Results = new List<Result>()
                {
                    result
                }
            };
            run.SetRunOnResults();
        }
    }
}
