// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DialogRef } from "@angular/cdk/dialog";
import { inject } from "@angular/core";
import { FormControl } from "@angular/forms";
import { map,of } from "rxjs";
import { Goal, GoalStore } from "../../models";

export function createCreateGoalViewModel() {

  const goalStore = inject(GoalStore);

  const dialogRef = inject(DialogRef);

  const save = (goal:Goal | null) => {
    goalStore.save(goal!);
    dialogRef.close(null);
  };

  return of(new FormControl(null,[])).pipe(
    map(formControl => {
      return {
        save,
        cancel: () => dialogRef.close(null),
        formControl
      };
    })
  );
};


