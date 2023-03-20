// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Comeback.Core;

public class ResponseBase
{
    public ResponseBase()
    {
        ValidationErrors = new List<string>();
    }
    public List<string> ValidationErrors { get; set; }
}


