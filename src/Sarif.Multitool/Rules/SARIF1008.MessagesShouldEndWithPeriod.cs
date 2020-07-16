﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.Json.Pointer;

namespace Microsoft.CodeAnalysis.Sarif.Multitool.Rules
{
    public class MessagesShouldEndWithPeriod : SarifValidationSkimmerBase
    {
        public MessagesShouldEndWithPeriod() : base(
            RuleId.MessagesShouldEndWithPeriod,
            RuleResources.SARIF1008_MessagesShouldEndWithPeriod,
            FailureLevel.Warning,
            new string[] { nameof(RuleResources.SARIF1008_Default) }
            )
        { }

        protected override void Analyze(ReportingDescriptor reportingDescriptor, string reportingDescriptorPointer)
        {
            AnalyzeMessageStrings(reportingDescriptor.MessageStrings, reportingDescriptorPointer);
        }

        private void AnalyzeMessageStrings(
            IDictionary<string, MultiformatMessageString> messageStrings,
            string reportingDescriptorPointer)
        {
            if (messageStrings != null)
            {
                string messageStringsPointer = reportingDescriptorPointer.AtProperty(SarifPropertyName.MessageStrings);

                foreach (string key in messageStrings.Keys)
                {
                    MultiformatMessageString messageString = messageStrings[key];

                    string messageStringPointer = messageStringsPointer.AtProperty(key);

                    AnalyzeMessageString(messageString.Text, messageStringPointer, SarifPropertyName.Text);
                }
            }
        }

        protected override void Analyze(MultiformatMessageString multiformatMessageString, string multiformatMessageStringPointer)
        {
            AnalyzeMessageString(multiformatMessageString.Text, multiformatMessageStringPointer, SarifPropertyName.Text);
        }

        protected override void Analyze(Message message, string messagePointer)
        {
            AnalyzeMessageString(message.Text, messagePointer, SarifPropertyName.Text);
        }

        private void AnalyzeMessageString(
            string messageString,
            string messagePointer,
            string propertyName)
        {
            if (!string.IsNullOrEmpty(messageString) && DoesNotEndWithPeriod(messageString))
            {
                string textPointer = messagePointer.AtProperty(propertyName);

                LogResult(
                    textPointer,
                    nameof(RuleResources.SARIF1008_Default),
                    messageString);
            }
        }

        private static bool DoesNotEndWithPeriod(string message)
        {
            return message != null && !message.EndsWith(".", StringComparison.Ordinal);
        }
    }
}
