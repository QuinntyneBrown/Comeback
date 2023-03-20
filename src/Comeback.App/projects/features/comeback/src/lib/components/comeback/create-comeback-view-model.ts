// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Dialog } from "@angular/cdk/dialog";
import { inject } from "@angular/core";
import { combineLatest, map } from "rxjs";
import { DailyMeasurementStore, GoalStore } from "../../models";
import { CreateGoalComponent } from "../create-goal";
import { DailyMeasurementComponent } from "../daily-measurement";

export function createComebackViewModel() {

  const dialog = inject(Dialog);
  const dailyMeasurementStore = inject(DailyMeasurementStore);
  const goalStore = inject(GoalStore);
  dailyMeasurementStore.load();
  goalStore.load();

  return combineLatest([
    goalStore.state$,
    dailyMeasurementStore.state$
  ]).pipe(
    map(([goalState, dailyMeasurementState]) => {

      return {
        dailyMeasurements: dailyMeasurementState.dailyMeasurements,
        goals: goalState.goals,
        goalToday: goalState.goalToday,
        dailyMeasurementToday: dailyMeasurementState.dailyMeasurementToday,
        create: () => {
          dialog.open(DailyMeasurementComponent);
        },
        createGoal: () => {
          dialog.open(CreateGoalComponent);
        }
      }
    })
  );
};


