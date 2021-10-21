import { Component, OnInit } from '@angular/core';
import { ForecastsService } from "./forecasts.service";
import Forecast from "./forecast";

@Component({
  selector: 'app-forecasts',
  templateUrl: './forecasts.component.html',
  styleUrls: ['./forecasts.component.scss']
})
export class ForecastsComponent implements OnInit {
  forecasts: Forecast[] = [];

  constructor(private service: ForecastsService) {
  }

  async ngOnInit() {
    this.forecasts = await this.service.getAll();
    // this.forecasts = await this.service.getAllFromBackEnd();
  }
}
