﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Resources;

namespace Microsoft.CodeAnalysis.Sarif.Driver
{
    public abstract class Skimmer<TContext> : ReportingDescriptor
    {
        public Skimmer(ReportingDescriptor rule) : base(rule)
        {
            this.Options = new Dictionary<string, string>();

            if (this.Name == null)
            {
                this.Name = this.GetType().Name;
            }
        }

        public IDictionary<string, string> Options { get; }

        public virtual void Initialize(TContext context) { }

        public virtual SupportedPlatform SupportedPlatforms => SupportedPlatform.All;

        public virtual AnalysisApplicability CanAnalyze(TContext context, out string reasonIfNotApplicable)
        {
            reasonIfNotApplicable = null;
            return AnalysisApplicability.ApplicableToSpecifiedTarget;
        }

        public abstract void Analyze(TContext context);
    }
}
