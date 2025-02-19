﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

/// <summary>
/// Note: This comparer may not have all properties compared. Will be replaced by a comprehensive
/// comparer generated by JSchema as part of EqualityComparer in a planned comprehensive solution.
/// Tracking by issue: https://github.com/microsoft/jschema/issues/141
/// </summary>
namespace Microsoft.CodeAnalysis.Sarif.Comparers
{
    internal class ArtifactComparer : IComparer<Artifact>
    {
        internal static readonly ArtifactComparer Instance = new ArtifactComparer();

        public int Compare(Artifact left, Artifact right)
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

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Location, right.Location);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ParentIndex.CompareTo(right.ParentIndex);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Offset.CompareTo(right.Offset);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Length.CompareTo(right.Length);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Roles.CompareTo(right.Roles);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.MimeType, right.MimeType);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactContentComparer.Instance.Compare(left.Contents, right.Contents);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Encoding, right.Encoding);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.SourceLanguage, right.SourceLanguage);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Hashes.DictionaryCompares(right.Hashes);

            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LastModifiedTimeUtc.CompareTo(right.LastModifiedTimeUtc);

            if (compareResult != 0)
            {
                return compareResult;
            }

            // Note: There may be other properties are not compared.
            return compareResult;
        }
    }
}
