// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Invocation for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class InvocationComparer : IComparer<Invocation>
    {
        internal static readonly InvocationComparer Instance = new InvocationComparer();

        public int Compare(Invocation left, Invocation right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = string.Compare(left.CommandLine, right.CommandLine);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Arguments.ListCompares(right.Arguments);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ResponseFiles.ListCompares(right.ResponseFiles, ArtifactLocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.StartTimeUtc.CompareTo(right.StartTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.EndTimeUtc.CompareTo(right.EndTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ExitCode.CompareTo(right.ExitCode);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.RuleConfigurationOverrides.ListCompares(right.RuleConfigurationOverrides, ConfigurationOverrideComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.NotificationConfigurationOverrides.ListCompares(right.NotificationConfigurationOverrides, ConfigurationOverrideComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ToolExecutionNotifications.ListCompares(right.ToolExecutionNotifications, NotificationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ToolConfigurationNotifications.ListCompares(right.ToolConfigurationNotifications, NotificationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.ExitCodeDescription, right.ExitCodeDescription);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.ExitSignalName, right.ExitSignalName);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ExitSignalNumber.CompareTo(right.ExitSignalNumber);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.ProcessStartFailureMessage, right.ProcessStartFailureMessage);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ExecutionSuccessful.CompareTo(right.ExecutionSuccessful);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Machine, right.Machine);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Account, right.Account);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ProcessId.CompareTo(right.ProcessId);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.ExecutableLocation, right.ExecutableLocation);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.WorkingDirectory, right.WorkingDirectory);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.EnvironmentVariables.DictionaryCompares(right.EnvironmentVariables);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Stdin, right.Stdin);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Stdout, right.Stdout);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Stderr, right.Stderr);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.StdoutStderr, right.StdoutStderr);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Properties.DictionaryCompares(right.Properties, SerializedPropertyInfoComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            return compareResult;
        }
    }
}