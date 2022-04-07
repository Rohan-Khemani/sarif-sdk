// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type GraphTraversal for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class GraphTraversalComparer : IComparer<GraphTraversal>
    {
        internal static readonly GraphTraversalComparer Instance = new GraphTraversalComparer();

        public int Compare(GraphTraversal left, GraphTraversal right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.RunGraphIndex.CompareTo(right.RunGraphIndex);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ResultGraphIndex.CompareTo(right.ResultGraphIndex);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Description, right.Description);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.InitialState.DictionaryCompares(right.InitialState, MultiformatMessageStringComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ImmutableState.ObjectCompares(right.ImmutableState);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.EdgeTraversals.ListCompares(right.EdgeTraversals, EdgeTraversalComparer.Instance);
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