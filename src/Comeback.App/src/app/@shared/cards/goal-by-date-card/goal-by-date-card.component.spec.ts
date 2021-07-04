import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalByDateCardComponent } from './goal-by-date-card.component';

describe('GoalByDateCardComponent', () => {
  let component: GoalByDateCardComponent;
  let fixture: ComponentFixture<GoalByDateCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoalByDateCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalByDateCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
