// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type SarifLog for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class SarifLogComparer : IComparer<SarifLog>
    {
        internal static readonly SarifLogComparer Instance = new SarifLogComparer();

        public int Compare(SarifLog left, SarifLog right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.SchemaUri.UriCompares(right.SchemaUri);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Version.CompareTo(right.Version);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Runs.ListCompares(right.Runs, RunComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.InlineExternalProperties.ListCompares(right.InlineExternalProperties, ExternalPropertiesComparer.Instance);
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