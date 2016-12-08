require('!!file?name=[name].[ext]!./index.html');
require('bootstrap/dist/css/bootstrap.css');
require('./soundcloud.js');

import * as angular from 'angular';
import appModule from './app';

angular.element(document).ready(() => {
  angular.bootstrap(document, [
    appModule.name
  ]);
});
