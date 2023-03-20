// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component, ElementRef, forwardRef, inject, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PushModule } from '@ngrx/component';
import { AbstractControl, ControlValueAccessor, FormControl, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule, MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatFormFieldModule } from '@angular/material/form-field';
import { fromEvent, Subject, takeUntil, tap } from 'rxjs';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';


@Component({
  selector: 'app-goal-editor',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => GoalEditorComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => GoalEditorComponent),
      multi: true
    }       
  ],
  imports: [
    CommonModule, 
    PushModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatMomentDateModule    
  ],
  templateUrl: './goal-editor.component.html',
  styleUrls: ['./goal-editor.component.scss']
})
export class GoalEditorComponent implements ControlValueAccessor, Validator, OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  
  private readonly _elementRef = inject(ElementRef<HTMLElement>);

  validate(control: AbstractControl): ValidationErrors | null {
    return this.form.valid 
    ? null
    : Object.keys(this.form.controls).reduce((accumulatedErrors,formControlName) => { 
      const errors = {...accumulatedErrors} as any;
      
      const controlErrors = this.form.get(formControlName)!.errors;

      if (controlErrors) {
        errors[formControlName] = controlErrors;
      }
      
      return errors;
    }, { });      
  }

  public form = new FormGroup({
    name: new FormControl(null,[]),
    date: new FormControl(null,[]),
    weight: new FormControl(null,[])
  });

  writeValue(obj: any): void {
    if(obj) {
      this.form.patchValue(obj);
    }
  }

  registerOnChange(fn: any): void {
    this.form.valueChanges
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe(fn);
  }

  registerOnTouched(fn: any): void {  
    this._elementRef.nativeElement.querySelectorAll("*").forEach(
      (element: HTMLElement) => {
        fromEvent(element,"blur")
        .pipe(
          takeUntil(this._destroyed$),
          tap(x => fn())
        ).subscribe();
      }
    )    
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
