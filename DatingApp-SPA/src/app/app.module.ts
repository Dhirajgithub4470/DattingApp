import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/Http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavComponent } from './_components/nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './_components/home/home.component';
import { RegisterComponent } from './_components/register/register.component';
import { MessagesComponent } from './_components/messages/messages.component';
import { MemberListComponent } from './_components/members/member-list/member-list.component';
import { ListsComponent } from './_components/lists/lists.component';
import { MemberCardComponent } from './_components/members/member-card/member-card.component';
import { MemberDetailComponent } from './_components/members/member-detail/member-detail.component';

import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap';
import { appRoutes } from './routes';

export function tokkenGetter(){
   return localStorage.getItem('token')
}
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MessagesComponent,
      MemberListComponent,
      ListsComponent,
      MemberCardComponent,
      MemberDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokkenGetter,
            whitelistedDomains: ['localhost:44326'],
            blacklistedRoutes: ['localhost:44326/api/auth/']
         }
      })
   ],
   providers: [
      ErrorInterceptorProvider,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
