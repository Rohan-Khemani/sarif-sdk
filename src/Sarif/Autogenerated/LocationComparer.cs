// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Location for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class LocationComparer : IComparer<Location>
    {
        internal static readonly LocationComparer Instance = new LocationComparer();

        public int Compare(Location left, Location right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.Id.CompareTo(right.Id);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = PhysicalLocationComparer.Instance.Compare(left.PhysicalLocation, right.PhysicalLocation);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LogicalLocations.ListCompares(right.LogicalLocations, LogicalLocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Message, right.Message);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Annotations.ListCompares(right.Annotations, RegionComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Relationships.ListCompares(right.Relationships, LocationRelationshipComparer.Instance);
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