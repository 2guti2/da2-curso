import { Component } from '@angular/core';
import { NzButtonType } from 'ng-zorro-antd/button';

class Grade {
  name: string;
  score: number;

  constructor(name: string, score: number) {
    this.name = name;
    this.score = score;
  }
}

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent {
  type: NzButtonType = "primary";
  grades: Array<Grade> = [
    new Grade("math", 12),
    new Grade("literature", 3)
  ];
  name: string = "Juan"

  constructor() {
  }

  onTestClick(e: Event) {
    console.log(e);
  }

  addGrade(e: Event) {
    this.grades.push(new Grade("history", 6));
  }

  remove(index: number){
    this.grades.splice(index, 1);
  }

  test(e: Event) {
    alert("hey");
  }

  test2(){
    alert("hola guti")
  }
}
