import { GoalStatus } from "./goal-status";

export type Goal = {
    goalId: string,
    description: string,
    date: string,
    status: GoalStatus,
    weight: number
};
