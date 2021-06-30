# DatingAppSPA

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.2.9.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## My application addon Notes Start here

## Anjular Jwt - use for client side token validation and also used for send token automatically to the server 

## Command to install Angular Jwt
npm install @auth0/angular-jwt

## ngx bootstrap - Integrates Bootstrap3 or Bootstrap4 components with Angular

## Command to install ngx-bootstrap 
npm install ngx-bootstrap@3.0.1 --save


## Bootswatch - bootswatch provides free themes for our application. There are different themes available you can see all those in node_modules/bootswatch/themenames. whichever theme you are using you need to import bootstrap.min.css in styles.css from that specific theme folder, In this project I used United theme so node_modules/bootswatch/united/bootstrap.min.css. 

## Command to install Bootswatch 
npm install bootswatch

## Routing - To implement routing in this application I have created routes.ts file and eported appRoute const with all routes then configure routerModule in app.modules.ts then add routes-outlet tag in app.component.html
## Now we want to restrict the user navigate through url directly, so if user is loggedIn then only it can redirect through url directly otherwise show error and redirect to homepage for login. To achieve this we need to add route guard to our application. Then we will use canActivate methode to achieve out goal. Also need to add canActivate parameter in our routes(route.ts)

## Command to add route guard
ng g guard auth --skipTests