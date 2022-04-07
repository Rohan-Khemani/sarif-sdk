// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Graph for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class GraphComparer : IComparer<Graph>
    {
        internal static readonly GraphComparer Instance = new GraphComparer();

        public int Compare(Graph left, Graph right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Description, right.Description);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Nodes.ListCompares(right.Nodes, NodeComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Edges.ListCompares(right.Edges, EdgeComparer.Instance);
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