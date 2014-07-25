//create the module
var demoApp = angular.module('demoApp', []); //[] is for mdules that our module 'references'. kinda like dependencies

//var demoApp = angular.module('demoApp', ['helperModule']);

//creating the controler in the module
demoApp.controller('SimpleController', function ($scope) {
    $scope.customers = [
        { name: 'Abe', city: 'Aaa', age: '11' },
        { name: 'Bob', city: 'Bbb', age: '22' },
        { name: 'Ciril', city: 'Ccc', age: '33' },
        { name: 'Dwain', city: 'Ddd', age: '44' }
    ];

    $scope.addCustomer = function ()
    {
        $scope.customers.push(
            {
                name: $scope.newCustomer.name,
                city: $scope.newCustomer.city,
                age: 0
            });
    }
});
demoApp.config(function ($routeProvider) {
   /* $routeProvider
        .when('/',
                {
                    controller: 'SimpleController',
                    templateUrl: 'Partials/View1.html'
                })
        .when('/Products',
                {
                    controller: 'SimpleController',
                    templateUrl: 'Partials/Products.html'
                })
    .otherwise({ redirectTo: '/' });*/

});





