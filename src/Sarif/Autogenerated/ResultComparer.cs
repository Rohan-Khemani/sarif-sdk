// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Result for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class ResultComparer : IComparer<Result>
    {
        internal static readonly ResultComparer Instance = new ResultComparer();

        public int Compare(Result left, Result right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = string.Compare(left.RuleId, right.RuleId);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.RuleIndex.CompareTo(right.RuleIndex);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ReportingDescriptorReferenceComparer.Instance.Compare(left.Rule, right.Rule);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Kind.CompareTo(right.Kind);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Level.CompareTo(right.Level);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Message, right.Message);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.AnalysisTarget, right.AnalysisTarget);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Locations.ListCompares(right.Locations, LocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Guid, right.Guid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.CorrelationGuid, right.CorrelationGuid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.OccurrenceCount.CompareTo(right.OccurrenceCount);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.PartialFingerprints.DictionaryCompares(right.PartialFingerprints);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Fingerprints.DictionaryCompares(right.Fingerprints);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Stacks.ListCompares(right.Stacks, StackComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.CodeFlows.ListCompares(right.CodeFlows, CodeFlowComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Graphs.ListCompares(right.Graphs, GraphComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.GraphTraversals.ListCompares(right.GraphTraversals, GraphTraversalComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.RelatedLocations.ListCompares(right.RelatedLocations, LocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Suppressions.ListCompares(right.Suppressions, SuppressionComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.BaselineState.CompareTo(right.BaselineState);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Rank.CompareTo(right.Rank);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Attachments.ListCompares(right.Attachments, AttachmentComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.HostedViewerUri.UriCompares(right.HostedViewerUri);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.WorkItemUris.ListCompares(right.WorkItemUris, (a, b) => a.UriCompares(b));
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ResultProvenanceComparer.Instance.Compare(left.Provenance, right.Provenance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Fixes.ListCompares(right.Fixes, FixComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Taxa.ListCompares(right.Taxa, ReportingDescriptorReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = WebRequestComparer.Instance.Compare(left.WebRequest, right.WebRequest);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = WebResponseComparer.Instance.Compare(left.WebResponse, right.WebResponse);
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