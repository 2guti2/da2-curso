import { Injectable } from '@angular/core';
import Forecast from "./forecast";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ForecastsService {
  forecasts: Forecast[];

  constructor(private http: HttpClient) {
    this.forecasts = [
      new Forecast(30, "guti"),
      new Forecast(20, "juan")
    ];
  }

  getAll(): Promise<Forecast[]> {
    const self = this;
    return new Promise<Forecast[]>((resolve) => {
      setTimeout(() => {
        resolve(self.forecasts);
      }, 5000);
    });
  }

  getAllFromBackEnd(): Promise<Forecast[]> {
    return this.http.get<Forecast[]>('http://localhost:5000/WeatherForecast').toPromise();
  }
}
