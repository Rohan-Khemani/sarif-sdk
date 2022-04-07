// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type TranslationMetadata for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class TranslationMetadataComparer : IComparer<TranslationMetadata>
    {
        internal static readonly TranslationMetadataComparer Instance = new TranslationMetadataComparer();

        public int Compare(TranslationMetadata left, TranslationMetadata right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Name, right.Name);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.FullName, right.FullName);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MultiformatMessageStringComparer.Instance.Compare(left.ShortDescription, right.ShortDescription);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MultiformatMessageStringComparer.Instance.Compare(left.FullDescription, right.FullDescription);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.DownloadUri.UriCompares(right.DownloadUri);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.InformationUri.UriCompares(right.InformationUri);
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