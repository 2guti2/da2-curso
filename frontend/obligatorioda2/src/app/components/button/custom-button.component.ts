import { Component, Input } from '@angular/core';
import { NzButtonType } from "ng-zorro-antd/button";

@Component({
  selector: 'custom-button',
  template: `
    <button nz-button [nzType]="type" (click)="onClick($event)">
      <ng-content></ng-content>
    </button>
  `
})
export class CustomButtonComponent {
  @Input() type: NzButtonType = "primary";
  @Input() callback: (e: Event) => void = () => {};

  onClick(e: Event) {
    this.callback(e);
  }
}
