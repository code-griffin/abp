import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eAccountRouteNames } from '../enums/route-names';

export const ACCOUNT_ROUTE_PROVIDERS = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

export function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: undefined,
        name: eAccountRouteNames.Account,
        invisible: true,
        layout: eLayoutType.account,
        breadcrumbText: eAccountRouteNames.Account,
        iconClass: 'bi bi-person-fill-gear',
        order: 1,
      },
      {
        path: '/account/login',
        name: eAccountRouteNames.Login,
        parentName: eAccountRouteNames.Account,
        order: 1,
      },
      {
        path: '/account/register',
        name: eAccountRouteNames.Register,
        parentName: eAccountRouteNames.Account,
        order: 2,
      },
      {
        path: '/account/manage',
        name: eAccountRouteNames.ManageProfile,
        parentName: eAccountRouteNames.Account,
        layout: eLayoutType.application,
        breadcrumbText: 'AbpAccount::Manage',
        iconClass: 'bi bi-kanban-fill',
        order: 3,
      },
      {
        path: '/account/forgot-password',
        parentName: eAccountRouteNames.Account,
        name: eAccountRouteNames.ForgotPassword,
        invisible: true,
      },
      {
        path: '/account/reset-password',
        parentName: eAccountRouteNames.Account,
        name: eAccountRouteNames.ResetPassword,
        invisible: true,
      },
    ]);
  };
}
