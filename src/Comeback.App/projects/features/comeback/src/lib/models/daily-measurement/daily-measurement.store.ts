// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject, Injectable } from "@angular/core";
import { ComponentStore, tapResponse } from "@ngrx/component-store";
import { combineLatest, exhaustMap, map, noop, tap, withLatestFrom } from "rxjs";
import { DailyMeasurement } from "./daily-measurement";
import { DailyMeasurementService } from "./daily-measurement.service";

export interface DailyMeasurementState {
    dailyMeasurements: DailyMeasurement[]
    dailyMeasurementToday: DailyMeasurement | null
}

const initialDailyMeasurementState = {
    dailyMeasurements: [] as DailyMeasurement[],
    dailyMeasurementToday: null
};

@Injectable({
    providedIn:"root"
})
export class DailyMeasurementStore extends ComponentStore<DailyMeasurementState> {
    private  readonly _dailyMeasurementService = inject(DailyMeasurementService);

    constructor() {
        super(initialDailyMeasurementState);        
    }

    readonly save = (dailyMeasurement:DailyMeasurement, nextFn: {(response:any): void} | null = null, errorFn: {(response:any): void} | null = null) => {        
        
        const apiRequest$ = dailyMeasurement.dailyMeasurementId ? this._dailyMeasurementService.update({ dailyMeasurement }) : this._dailyMeasurementService.create({ dailyMeasurement });
        
        const updateFn = dailyMeasurement?.dailyMeasurementId ? ([response, dailyMeasurements]: [any, DailyMeasurement[]]) => this.patchState({

            dailyMeasurements: dailyMeasurements.map(t => response.dailyMeasurement.dailyMeasurementId == t.dailyMeasurementId ? response.dailyMeasurement : t)
        })
        :(([response, dailyMeasurements]: [any, DailyMeasurement[]]) => this.patchState({ dailyMeasurements: [...dailyMeasurements, response.dailyMeasurement ]}));
        
        return this.effect<void>(
            exhaustMap(()=> apiRequest$.pipe(
                withLatestFrom(this.select(x => x.dailyMeasurements)),
                tap(updateFn),
                tapResponse(
                    nextFn || noop,
                    errorFn || noop
                )
            )
        ))();
    }

    readonly delete = this.effect<DailyMeasurement>(
        exhaustMap((dailyMeasurement) => this._dailyMeasurementService.delete({ dailyMeasurement: dailyMeasurement }).pipe( 
            withLatestFrom(this.select(x => x.dailyMeasurements )),           
            tapResponse(
                ([_, dailyMeasurements]) => this.patchState({ dailyMeasurements: dailyMeasurements.filter(t => t.dailyMeasurementId != dailyMeasurement.dailyMeasurementId )}),
                noop
            )
        ))
    );

    readonly load = this.effect<void>(
        exhaustMap(_ => combineLatest([
            this._dailyMeasurementService.get(),
            this._dailyMeasurementService.getToday()
        ]).pipe(            
            tapResponse(
                ([dailyMeasurements, dailyMeasurementToday]) => this.patchState({ dailyMeasurements, dailyMeasurementToday }),
                noop                
            )
        ))
    );    
}
