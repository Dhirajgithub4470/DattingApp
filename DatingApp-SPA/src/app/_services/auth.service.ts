import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/Http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl = environment.apiUrl + 'auth/';
jwtHelper = new JwtHelperService();
decodedToken: any;

constructor(private http: HttpClient) { }

 login(modal: any) {

  return this.http.post(this.baseUrl + 'login', modal).pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
        console.log('decoded token:', this.decodedToken);
      }
    })
  );
}

register(modal: any) {
  return this.http.post(this.baseUrl + 'register', modal);
}

loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
}

}
