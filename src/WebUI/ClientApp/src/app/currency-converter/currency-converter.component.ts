import { Component, OnInit } from '@angular/core';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { Currencies, CurrencyRate, CurrencyRatesClient } from '../web-api-client';

@Component({
  selector: 'app-currency-converter',
  templateUrl: './currency-converter.component.html',
  styleUrls: ['./currency-converter.component.css']
})
export class CurrencyConverterComponent implements OnInit {

  fromCurrency?: Currencies;
  fromAmount: string;
  toCurrency?: Currencies;
  toAmount: string;

  fromCurrencies: Currencies[];
  toCurrencies: Currencies[];

  exchangeRate: number;
  exchangeRates: CurrencyRate[];

  constructor(private client: CurrencyRatesClient, private currencyPipe: CurrencyPipe) {
    client.get().subscribe(exchangeRates => {
      this.exchangeRates = exchangeRates;

      this.fromCurrencies = exchangeRates.map(rate => rate.fromCurrency)
        .filter((value, index, self) => self.indexOf(value) === index); // dictinct

      this.fromCurrency = this.exchangeRates[0].fromCurrency; // default to AUD
      this.onFromCurrencyChanged(this.fromCurrency);

      this.resetValues();

    }, error => console.error(error));
  }

  ngOnInit(): void {

  }

  resetValues(): void {
    this.toCurrency = null;
    this.exchangeRate = 0;
    this.toAmount = "";
  }

  onFromCurrencyChanged(selectedCurrency: Currencies): void {
    this.toCurrencies = this.exchangeRates
      .filter(rate => rate.fromCurrency === selectedCurrency)
      .map(rate => rate.toCurrency);

    if (this.toCurrencies.length === 1) {
      this.toCurrency = this.toCurrencies[0];
      this.onToCurrencyChanged(this.toCurrency);
    } else {
      this.resetValues();
    }
  }

  onToCurrencyChanged(selectedCurrency: Currencies): void {
    const selectedRate = this.exchangeRates
      .find(rate => rate.toCurrency === selectedCurrency && rate.fromCurrency === this.fromCurrency);

    this.exchangeRate = selectedRate?.finalExchangeRate;

    this.onFromAmountChange(null);
  }

  onToAmountChange(element): void {
    if (this.exchangeRate <= 0) {
      return;
    }

    const newValue = (Number(this.toAmount.replace(/[^0-9.-]+/g, "")) / this.exchangeRate).toFixed(2);
    this.fromAmount = this.currencyPipe.transform(newValue, ' ');
  }

  onFromAmountChange(element): void {
    if (this.exchangeRate <= 0) {
      return;
    }

    const newValue = (Number(this.fromAmount.replace(/[^0-9.-]+/g, "")) * this.exchangeRate).toFixed(2);
    this.toAmount = this.currencyPipe.transform(newValue, ' ');
  }

  transformFromAmount(element): void {
    this.fromAmount = this.currencyPipe.transform(this.fromAmount, ' ');

    element.target.value = this.fromAmount;
  }

  transformToAmount(element): void { 
    this.toAmount = this.currencyPipe.transform(this.toAmount, ' ');

    element.target.value = this.toAmount;
  }
}
