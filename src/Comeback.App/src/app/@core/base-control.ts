import { Injectable } from "@angular/core";
import { ControlValueAccessor } from "@angular/forms";
import { Destroyable } from "./destroyable";

@Injectable()
export class BaseControl extends Destroyable implements ControlValueAccessor {

    writeValue(obj: any): void {

    }
    registerOnChange(fn: any): void {
        throw new Error("Method not implemented.");
    }
    registerOnTouched(fn: any): void {

    }
    setDisabledState?(isDisabled: boolean): void {

    }

}