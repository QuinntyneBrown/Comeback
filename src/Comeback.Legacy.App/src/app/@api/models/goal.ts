// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { GoalStatus } from "./goal-status";

export type Goal = {
    goalId: string,
    name: string,
    description: string,
    date: string,
    status: GoalStatus,
    weight: number
};

