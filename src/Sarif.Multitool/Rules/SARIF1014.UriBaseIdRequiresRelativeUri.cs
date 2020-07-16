﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Microsoft.Json.Pointer;

namespace Microsoft.CodeAnalysis.Sarif.Multitool.Rules
{
    public class UriBaseIdRequiresRelativeUri : SarifValidationSkimmerBase
    {
        public UriBaseIdRequiresRelativeUri() : base(
            RuleId.UriBaseIdRequiresRelativeUri,
            RuleResources.SARIF1014_UriBaseIdRequiresRelativeUri,
            FailureLevel.Error,
            new string[] { nameof(RuleResources.SARIF1014_Default) }
            )
        { }

        protected override void Analyze(ArtifactLocation fileLocation, string fileLocationPointer)
        {
            if (fileLocation.UriBaseId != null && fileLocation.Uri.IsAbsoluteUri)
            {
                LogResult(
                    fileLocationPointer.AtProperty(SarifPropertyName.Uri),
                    nameof(RuleResources.SARIF1014_Default),
                    fileLocation.Uri.OriginalString);
            }
        }
    }
}
