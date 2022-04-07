// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type ExternalProperties for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class ExternalPropertiesComparer : IComparer<ExternalProperties>
    {
        internal static readonly ExternalPropertiesComparer Instance = new ExternalPropertiesComparer();

        public int Compare(ExternalProperties left, ExternalProperties right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.Schema.UriCompares(right.Schema);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Version.CompareTo(right.Version);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Guid, right.Guid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.RunGuid, right.RunGuid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ConversionComparer.Instance.Compare(left.Conversion, right.Conversion);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Graphs.ListCompares(right.Graphs, GraphComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = PropertyBagComparer.Instance.Compare(left.ExternalizedProperties, right.ExternalizedProperties);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Artifacts.ListCompares(right.Artifacts, ArtifactComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Invocations.ListCompares(right.Invocations, InvocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LogicalLocations.ListCompares(right.LogicalLocations, LogicalLocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ThreadFlowLocations.ListCompares(right.ThreadFlowLocations, ThreadFlowLocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Results.ListCompares(right.Results, ResultComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Taxonomies.ListCompares(right.Taxonomies, ToolComponentComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ToolComponentComparer.Instance.Compare(left.Driver, right.Driver);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Extensions.ListCompares(right.Extensions, ToolComponentComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Policies.ListCompares(right.Policies, ToolComponentComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Translations.ListCompares(right.Translations, ToolComponentComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Addresses.ListCompares(right.Addresses, AddressComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.WebRequests.ListCompares(right.WebRequests, WebRequestComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.WebResponses.ListCompares(right.WebResponses, WebResponseComparer.Instance);
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