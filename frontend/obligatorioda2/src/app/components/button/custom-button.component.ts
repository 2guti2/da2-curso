import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NzButtonType } from "ng-zorro-antd/button";

@Component({
  selector: 'custom-button',
  template: `
    <button nz-button [nzType]="type" (click)="onClick.emit($event)">
      <ng-content></ng-content>
    </button>
  `
})
export class CustomButtonComponent {
  @Input() type: NzButtonType = "primary";
  @Output() onClick: EventEmitter<Event> = new EventEmitter<Event>();
}
