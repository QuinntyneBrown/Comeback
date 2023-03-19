// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalCardComponent } from './goal-card.component';

describe('GoalCardComponent', () => {
  let component: GoalCardComponent;
  let fixture: ComponentFixture<GoalCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ GoalCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoalCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

