// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Attachment for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class AttachmentComparer : IComparer<Attachment>
    {
        internal static readonly AttachmentComparer Instance = new AttachmentComparer();

        public int Compare(Attachment left, Attachment right)
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

            compareResult = ArtifactLocationComparer.Instance.Compare(left.ArtifactLocation, right.ArtifactLocation);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Regions.ListCompares(right.Regions, RegionComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Rectangles.ListCompares(right.Rectangles, RectangleComparer.Instance);
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