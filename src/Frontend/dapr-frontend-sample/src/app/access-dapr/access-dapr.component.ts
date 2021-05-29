import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-access-dapr',
  templateUrl: './access-dapr.component.html',
  styleUrls: ['./access-dapr.component.sass']
})
export class AccessDaprComponent implements OnInit {
  public weathers!: Weather[];

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  callCatalog(){
    this.httpClient.get<Weather[]>("http://localhost:10000/c/api/v1/weatherforecast")
                   .subscribe(t => {
                     this.weathers = t;
                    });
  }
}

class Weather {
  Date!: Date;
  TemperatureC!: number;
  TemperatureF!: number;
  Summary!: string;
}