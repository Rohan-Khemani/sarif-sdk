// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type ResultProvenance for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class ResultProvenanceComparer : IComparer<ResultProvenance>
    {
        internal static readonly ResultProvenanceComparer Instance = new ResultProvenanceComparer();

        public int Compare(ResultProvenance left, ResultProvenance right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.FirstDetectionTimeUtc.CompareTo(right.FirstDetectionTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LastDetectionTimeUtc.CompareTo(right.LastDetectionTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.FirstDetectionRunGuid, right.FirstDetectionRunGuid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.LastDetectionRunGuid, right.LastDetectionRunGuid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.InvocationIndex.CompareTo(right.InvocationIndex);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ConversionSources.ListCompares(right.ConversionSources, PhysicalLocationComparer.Instance);
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