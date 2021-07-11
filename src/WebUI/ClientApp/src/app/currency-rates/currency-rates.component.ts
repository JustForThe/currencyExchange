import { Component, OnInit } from '@angular/core';
import { CurrencyRate, CurrencyRatesClient } from '../web-api-client';

@Component({
  selector: 'app-currency-rates',
  templateUrl: './currency-rates.component.html',
  styleUrls: ['./currency-rates.component.css']
})
export class CurrencyRatesComponent implements OnInit {
  public currencyRates: CurrencyRate[];

  constructor(private client: CurrencyRatesClient) {
    client.get().subscribe(result => {
      this.currencyRates = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
