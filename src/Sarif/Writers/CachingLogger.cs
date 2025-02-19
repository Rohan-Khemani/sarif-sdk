﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.Sarif.Writers
{
    /// <summary>
    /// This class caches all results and notifications that are passed to it.
    /// Data cached this way can subsequently be replayed into other IAnalysisLogger
    /// instances. The driver framework uses this mechanism to merge results
    /// produced by a multi-threaded analysis into a single output file.
    /// </summary>
    public class CachingLogger : BaseLogger, IAnalysisLogger
    {
        public CachingLogger(IEnumerable<FailureLevel> levels, IEnumerable<ResultKind> kinds) : base(levels, kinds)
        {
        }

        public IDictionary<ReportingDescriptor, IList<Result>> Results { get; set; }

        public IList<Notification> ConfigurationNotifications { get; set; }

        public IList<Notification> ToolNotifications { get; set; }

        public void AnalysisStarted()
        {
        }

        public void AnalysisStopped(RuntimeConditions runtimeConditions)
        {
        }

        public void AnalyzingTarget(IAnalysisContext context)
        {
        }

        public void Log(ReportingDescriptor rule, Result result)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (!ShouldLog(result))
            {
                return;
            }

            if (rule.GetType().Name != nameof(ReportingDescriptor))
            {
                rule = rule.DeepClone();
            }

            if (!result.RuleId.IsEqualToOrHierarchicalDescendantOf(rule.Id))
            {
                throw new ArgumentException($"rule.Id is not equal to result.RuleId ({rule.Id} != {result.RuleId})");
            }

            Results ??= new Dictionary<ReportingDescriptor, IList<Result>>();

            if (!Results.TryGetValue(rule, out IList<Result> results))
            {
                results = Results[rule] = new List<Result>();
            }
            results.Add(result);
        }

        public void LogConfigurationNotification(Notification notification)
        {
            if (!ShouldLog(notification))
            {
                return;
            }

            ConfigurationNotifications ??= new List<Notification>();
            ConfigurationNotifications.Add(notification);
        }

        public void LogToolNotification(Notification notification)
        {
            if (!ShouldLog(notification))
            {
                return;
            }

            ToolNotifications ??= new List<Notification>();
            ToolNotifications.Add(notification);
        }
    }
}
