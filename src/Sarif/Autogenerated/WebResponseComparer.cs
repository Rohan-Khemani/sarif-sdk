// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type WebResponse for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class WebResponseComparer : IComparer<WebResponse>
    {
        internal static readonly WebResponseComparer Instance = new WebResponseComparer();

        public int Compare(WebResponse left, WebResponse right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.Index.CompareTo(right.Index);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Protocol, right.Protocol);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Version, right.Version);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.StatusCode.CompareTo(right.StatusCode);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.ReasonPhrase, right.ReasonPhrase);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Headers.DictionaryCompares(right.Headers);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactContentComparer.Instance.Compare(left.Body, right.Body);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.NoResponseReceived.CompareTo(right.NoResponseReceived);
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