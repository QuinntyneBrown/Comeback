// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalEditorComponent } from './goal-editor.component';

describe('GoalEditorComponent', () => {
  let component: GoalEditorComponent;
  let fixture: ComponentFixture<GoalEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ GoalEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoalEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

