import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalEditorComponent } from './goal-editor.component';

describe('GoalEditorComponent', () => {
  let component: GoalEditorComponent;
  let fixture: ComponentFixture<GoalEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoalEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
