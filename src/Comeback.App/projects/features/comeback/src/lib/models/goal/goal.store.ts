// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject, Injectable } from "@angular/core";
import { ComponentStore, tapResponse } from "@ngrx/component-store";
import { combineLatest, exhaustMap, map, noop, tap, withLatestFrom } from "rxjs";
import { Goal } from "./goal";
import { GoalService } from "./goal.service";

export interface GoalState {
    goals: Goal[],
    goalToday: Goal | null
}

const initialGoalState = {
    goals: [] as Goal[],
    goalToday: null
};

@Injectable({
    providedIn:"root"
})
export class GoalStore extends ComponentStore<GoalState> {
    private  readonly _goalService = inject(GoalService);

    constructor() {
        super(initialGoalState);        
    }

    readonly save = (goal:Goal, nextFn: {(response:any): void} | null = null, errorFn: {(response:any): void} | null = null) => {        
        
        const apiRequest$ = goal.goalId ? this._goalService.update({ goal }) : this._goalService.create({ goal });
        
        const updateFn = goal?.goalId ? ([response, goals]: [any, Goal[]]) => this.patchState({

            goals: goals.map(t => response.goal.goalId == t.goalId ? response.goal : t)
        })
        :(([response, goals]: [any, Goal[]]) => this.patchState({ goals: [...goals, response.goal ]}));
        
        return this.effect<void>(
            exhaustMap(()=> apiRequest$.pipe(
                withLatestFrom(this.select(x => x.goals)),
                tap(updateFn),
                tapResponse(
                    nextFn || noop,
                    errorFn || noop
                )
            )
        ))();
    }

    readonly delete = this.effect<Goal>(
        exhaustMap((goal) => this._goalService.delete({ goal: goal }).pipe( 
            withLatestFrom(this.select(x => x.goals )),           
            tapResponse(
                ([_, goals]) => this.patchState({ goals: goals.filter(t => t.goalId != goal.goalId )}),
                noop
            )
        ))
    );

    readonly load = this.effect<void>(
        
        exhaustMap(_ => combineLatest([
            this._goalService.get(),
            this._goalService.getToday()
        ]).pipe(            
            tapResponse(
                ([goals, goalToday]) => {
                    this.patchState({ goals, goalToday });
                },
                noop                
            )
        ))
    );    
}
