"use strict";
require('!!file?name=[name].[ext]!./index.html');
require('bootstrap/dist/css/bootstrap.css');
require('./soundcloud.js');
var angular = require("angular");
var app_1 = require("./app");
angular.element(document).ready(function () {
    angular.bootstrap(document, [
        app_1.default.name
    ]);
});
//# sourceMappingURL=bootstrap.js.map