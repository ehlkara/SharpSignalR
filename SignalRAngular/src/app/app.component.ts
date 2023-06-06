import { Component, OnInit } from '@angular/core';
import { CovidService } from './Services/covid.service';
import { ChartType } from 'angular-google-charts';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SignalRAngular';
LineChartType = ChartType.LineChart;
columnNames = ["CovidDate", "Istanbul",
"Ankara",
"Izmir",
"Konya",
"Sivas"];

options:any={legend:{positional:"Bottom"}};
  constructor(public covidService:CovidService) {}

  ngOnInit(): void {
    this.covidService.startConnection();
    this.covidService.startListener();
  }
}
