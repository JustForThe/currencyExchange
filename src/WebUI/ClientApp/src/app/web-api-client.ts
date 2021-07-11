/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IAdminSettingsClient {
    get(): Observable<MarkupVm>;
    update(command: UpdateMarkupSettingCommand): Observable<FileResponse>;
}

@Injectable({
    providedIn: 'root'
})
export class AdminSettingsClient implements IAdminSettingsClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    get(): Observable<MarkupVm> {
        let url_ = this.baseUrl + "/api/AdminSettings";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(<any>response_);
                } catch (e) {
                    return <Observable<MarkupVm>><any>_observableThrow(e);
                }
            } else
                return <Observable<MarkupVm>><any>_observableThrow(response_);
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<MarkupVm> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = MarkupVm.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<MarkupVm>(<any>null);
    }

    update(command: UpdateMarkupSettingCommand): Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/AdminSettings";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdate(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processUpdate(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }
}

export interface ICurrencyRatesClient {
    get(): Observable<CurrencyRate[]>;
}

@Injectable({
    providedIn: 'root'
})
export class CurrencyRatesClient implements ICurrencyRatesClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    get(): Observable<CurrencyRate[]> {
        let url_ = this.baseUrl + "/api/CurrencyRates";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(<any>response_);
                } catch (e) {
                    return <Observable<CurrencyRate[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<CurrencyRate[]>><any>_observableThrow(response_);
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<CurrencyRate[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(CurrencyRate.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<CurrencyRate[]>(<any>null);
    }
}

export class MarkupVm implements IMarkupVm {
    id?: number;
    markupSettingPercentage?: number;
    maximumMarkupPercentage?: number;
    minimunMarkupPercentage?: number;

    constructor(data?: IMarkupVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.markupSettingPercentage = _data["markupSettingPercentage"];
            this.maximumMarkupPercentage = _data["maximumMarkupPercentage"];
            this.minimunMarkupPercentage = _data["minimunMarkupPercentage"];
        }
    }

    static fromJS(data: any): MarkupVm {
        data = typeof data === 'object' ? data : {};
        let result = new MarkupVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["markupSettingPercentage"] = this.markupSettingPercentage;
        data["maximumMarkupPercentage"] = this.maximumMarkupPercentage;
        data["minimunMarkupPercentage"] = this.minimunMarkupPercentage;
        return data; 
    }
}

export interface IMarkupVm {
    id?: number;
    markupSettingPercentage?: number;
    maximumMarkupPercentage?: number;
    minimunMarkupPercentage?: number;
}

export class UpdateMarkupSettingCommand implements IUpdateMarkupSettingCommand {
    id?: number;
    markupSettingPercentage?: number;

    constructor(data?: IUpdateMarkupSettingCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.markupSettingPercentage = _data["markupSettingPercentage"];
        }
    }

    static fromJS(data: any): UpdateMarkupSettingCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateMarkupSettingCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["markupSettingPercentage"] = this.markupSettingPercentage;
        return data; 
    }
}

export interface IUpdateMarkupSettingCommand {
    id?: number;
    markupSettingPercentage?: number;
}

export class CurrencyRate implements ICurrencyRate {
    fromCurrency?: Currencies;
    toCurrency?: Currencies;
    exchangeRate?: number;
    finalExchangeRate?: number;

    constructor(data?: ICurrencyRate) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.fromCurrency = _data["fromCurrency"];
            this.toCurrency = _data["toCurrency"];
            this.exchangeRate = _data["exchangeRate"];
            this.finalExchangeRate = _data["finalExchangeRate"];
        }
    }

    static fromJS(data: any): CurrencyRate {
        data = typeof data === 'object' ? data : {};
        let result = new CurrencyRate();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["fromCurrency"] = this.fromCurrency;
        data["toCurrency"] = this.toCurrency;
        data["exchangeRate"] = this.exchangeRate;
        data["finalExchangeRate"] = this.finalExchangeRate;
        return data; 
    }
}

export interface ICurrencyRate {
    fromCurrency?: Currencies;
    toCurrency?: Currencies;
    exchangeRate?: number;
    finalExchangeRate?: number;
}

export enum Currencies {
    AUD = "AUD",
    USD = "USD",
    NZD = "NZD",
    JPY = "JPY",
    CNY = "CNY",
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class SwaggerException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}