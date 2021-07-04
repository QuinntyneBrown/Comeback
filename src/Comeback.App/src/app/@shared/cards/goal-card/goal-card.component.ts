import { Component, Input, OnInit } from '@angular/core';
import { Goal } from '@api';

@Component({
  selector: 'app-goal-card',
  templateUrl: './goal-card.component.html',
  styleUrls: ['./goal-card.component.scss']
})
export class GoalCardComponent  {
  @Input() public goal: Goal;
}
