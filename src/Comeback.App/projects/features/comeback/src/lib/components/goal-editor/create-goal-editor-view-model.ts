// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { map,of } from "rxjs";
import { Goal } from "../../models";

export function createGoalEditorViewModel() {
  const form = new FormGroup<any>({

  });
  
  return of("GoalEditor works!").pipe(
    map(message => {
      return {
        form
      }
    })
  );
};


