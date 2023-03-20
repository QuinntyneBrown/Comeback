// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DialogRef } from "@angular/cdk/dialog";
import { inject } from "@angular/core";
import { FormControl } from "@angular/forms";
import { map,of } from "rxjs";
import { DailyMeasurement, DailyMeasurementStore } from "../../models";

export function createDailyMeasurementViewModel() {
  
  const dialogRef = inject(DialogRef);

  const store = inject(DailyMeasurementStore);

  const save = (dailyMeasurement:DailyMeasurement) => {
    store.save(dailyMeasurement);
    dialogRef.close(null)
  };

  return of(new FormControl()).pipe(
    map(formControl => {

      return {
        formControl,
        save,
        cancel: () => dialogRef.close(null)
      };
    })
  );
};


