import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Goal, GoalService } from '@api';
import { NavigationService } from '@core';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-create-goal',
  templateUrl: './create-goal.component.html',
  styleUrls: ['./create-goal.component.scss']
})
export class CreateGoalComponent {

  private readonly _destroyed$: Subject<void> = new Subject();
  readonly formControl: FormControl = new FormControl();

  constructor(
    private readonly _goalService: GoalService,
    private readonly _navigationService: NavigationService
  ) { }

  save(goal: Goal): void {
    this._goalService.create({
      goal
    })
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._navigationService.redirectToDefault())
    )
    .subscribe();
  }

  cancel() {
    this._navigationService.redirectToDefault()
  }
}
