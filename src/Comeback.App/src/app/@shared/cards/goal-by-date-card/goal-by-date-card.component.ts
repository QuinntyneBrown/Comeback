import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DailyMeasurement, Goal } from '@api';

@Component({
  selector: 'app-goal-by-date-card',
  templateUrl: './goal-by-date-card.component.html',
  styleUrls: ['./goal-by-date-card.component.scss']
})
export class GoalByDateCardComponent {

  @Output() public editClick: EventEmitter<DailyMeasurement> = new EventEmitter();

  @Input() public goal: Goal;

  @Input() public dailyMeasurement: DailyMeasurement;

}
