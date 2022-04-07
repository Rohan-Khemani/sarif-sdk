// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type ExternalPropertyFileReference for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class ExternalPropertyFileReferenceComparer : IComparer<ExternalPropertyFileReference>
    {
        internal static readonly ExternalPropertyFileReferenceComparer Instance = new ExternalPropertyFileReferenceComparer();

        public int Compare(ExternalPropertyFileReference left, ExternalPropertyFileReference right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Location, right.Location);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Guid, right.Guid);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ItemCount.CompareTo(right.ItemCount);
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