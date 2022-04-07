// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type VersionControlDetails for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class VersionControlDetailsComparer : IComparer<VersionControlDetails>
    {
        internal static readonly VersionControlDetailsComparer Instance = new VersionControlDetailsComparer();

        public int Compare(VersionControlDetails left, VersionControlDetails right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.RepositoryUri.UriCompares(right.RepositoryUri);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.RevisionId, right.RevisionId);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Branch, right.Branch);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.RevisionTag, right.RevisionTag);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.AsOfTimeUtc.CompareTo(right.AsOfTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.MappedTo, right.MappedTo);
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