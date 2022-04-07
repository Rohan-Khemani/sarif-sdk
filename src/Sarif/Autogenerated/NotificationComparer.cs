// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Notification for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.3.0")]
    internal sealed class NotificationComparer : IComparer<Notification>
    {
        internal static readonly NotificationComparer Instance = new NotificationComparer();

        public int Compare(Notification left, Notification right)
        {
            int compareResult = 0;
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = left.Locations.ListCompares(right.Locations, LocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Message, right.Message);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Level.CompareTo(right.Level);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ThreadId.CompareTo(right.ThreadId);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.TimeUtc.CompareTo(right.TimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ExceptionDataComparer.Instance.Compare(left.Exception, right.Exception);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ReportingDescriptorReferenceComparer.Instance.Compare(left.Descriptor, right.Descriptor);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ReportingDescriptorReferenceComparer.Instance.Compare(left.AssociatedRule, right.AssociatedRule);
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