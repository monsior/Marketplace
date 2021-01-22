import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators'
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  register(user: any){
    return this.http.post(this.baseUrl + 'register', user);
  }

  login(user: any) {
    return this.http.post(this.baseUrl + 'login', user).pipe(
      map((response: any) => {
        const resp = response;
        if (resp) {
          localStorage.setItem('token', resp.token);
        }
      })
    )
  }

  logout(){
    localStorage.removeItem('token');
  }

  isLogged() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
