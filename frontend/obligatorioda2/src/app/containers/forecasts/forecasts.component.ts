import { Component, OnInit } from '@angular/core';
import { ForecastsService } from "./forecasts.service";
import Forecast from "./forecast";

@Component({
  selector: 'app-forecasts',
  templateUrl: './forecasts.component.html',
  styleUrls: ['./forecasts.component.scss']
})
export class ForecastsComponent implements OnInit {
  forecasts: Forecast[] | null = null;

  constructor(private forecastsService: ForecastsService) {
  }

  async ngOnInit() {
    await this.loadForecasts();
  }

  async reload() {
    await this.loadForecasts();
  }

  private async loadForecasts() {
    this.forecasts = await this.forecastsService.getAllFromBackEnd();
    console.log(this.forecasts);
  }
}
