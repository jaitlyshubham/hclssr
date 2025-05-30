import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  myAppUrl: string = "https://localhost:7176/api/user/";

  constructor(private _http: HttpClient) { }

  getUsers(): Observable<any> {
    return this._http.get<any>(this.myAppUrl + 'GetList').pipe(map((data) => {
      return data;
    }))
  }

  getUser(id: number): Observable<any> {
    return this._http.get<any>(`${this.myAppUrl}Get?id=${id}`);
  }

}
