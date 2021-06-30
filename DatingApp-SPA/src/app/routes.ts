import { Routes } from '@angular/router';
import { HomeComponent } from './_components/home/home.component';
import { ListsComponent } from './_components/lists/lists.component';
import { MessagesComponent } from './_components/messages/messages.component';
import { MemberListComponent } from './_components/members/member-list/member-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './_components/members/member-detail/member-detail.component';

export const appRoutes: Routes = [
    {path : '', component: HomeComponent},

    // below is the alternate way to apply routeguard to all components which we want to apply.
    // i.e Protecting multiple routes at once. to achieve this we have added below dummy route
    {
        path: '',  // path will be like -> localhost:4200/children i.e for ex: localhost:4200/members
        runGuardsAndResolvers : 'always',
        canActivate : [AuthGuard],
        children : [
            {path : 'members', component: MemberListComponent},
            {path : 'members/:id', component: MemberDetailComponent},
            {path : 'messages', component: MessagesComponent},
            {path : 'lists', component: ListsComponent}
        ]

    },

    // Or we can simply add canActivate in each route, this is also fine so use any one as your need.
    // So for now I am using above snippet. therefore commented below code.

    // {path : 'members', component: MemberListComponent, canActivate: [AuthGuard]},
    // {path : 'messages', component: MessagesComponent, canActivate: [AuthGuard]},
    // {path : 'lists', component: ListsComponent, canActivate: [AuthGuard]},

    {path : '**', redirectTo: '', pathMatch: 'full'}
];
