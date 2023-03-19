// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject } from "@angular/core";
import { FormControl } from "@angular/forms";
import { map,of } from "rxjs";
import { Goal, GoalStore } from "../../models";

export function createCreateGoalViewModel() {

  const goalStore = inject(GoalStore);

  const save = (goal:Goal | null) => {
    goalStore.save(goal!);
  };

  const cancel = () => {

  };

  const formControl = new FormControl<Goal | null>(null,[]);

  return of("create-goal works!").pipe(
    map(message => {

      return {
        save,
        cancel,
        formControl
      }
    })
  );
};


