// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Edge for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class EdgeComparer : IComparer<Edge>
    {
        internal static readonly EdgeComparer Instance = new EdgeComparer();

        public int Compare(Edge left, Edge right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Id, right.Id);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Label, right.Label);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.SourceNodeId, right.SourceNodeId);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.TargetNodeId, right.TargetNodeId);
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