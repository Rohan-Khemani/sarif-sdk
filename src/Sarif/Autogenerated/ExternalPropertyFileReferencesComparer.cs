// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type ExternalPropertyFileReferences for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class ExternalPropertyFileReferencesComparer : IComparer<ExternalPropertyFileReferences>
    {
        internal static readonly ExternalPropertyFileReferencesComparer Instance = new ExternalPropertyFileReferencesComparer();

        public int Compare(ExternalPropertyFileReferences left, ExternalPropertyFileReferences right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = ExternalPropertyFileReferenceComparer.Instance.Compare(left.Conversion, right.Conversion);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Graphs.ListCompares(right.Graphs, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ExternalPropertyFileReferenceComparer.Instance.Compare(left.ExternalizedProperties, right.ExternalizedProperties);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Artifacts.ListCompares(right.Artifacts, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Invocations.ListCompares(right.Invocations, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LogicalLocations.ListCompares(right.LogicalLocations, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ThreadFlowLocations.ListCompares(right.ThreadFlowLocations, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Results.ListCompares(right.Results, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Taxonomies.ListCompares(right.Taxonomies, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Addresses.ListCompares(right.Addresses, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ExternalPropertyFileReferenceComparer.Instance.Compare(left.Driver, right.Driver);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Extensions.ListCompares(right.Extensions, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Policies.ListCompares(right.Policies, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Translations.ListCompares(right.Translations, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.WebRequests.ListCompares(right.WebRequests, ExternalPropertyFileReferenceComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.WebResponses.ListCompares(right.WebResponses, ExternalPropertyFileReferenceComparer.Instance);
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