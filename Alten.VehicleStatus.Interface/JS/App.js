/// <reference path="../scripts/angular.js" />
/// <reference path="../scripts/angular-ui-router.js" />


    var App = angular.module('App', ["ui.router"]);
    App.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state("home", {
                url: '/',                
                views: {
                    'all': {
						templateUrl: 'HTML/vehicle/show-All-Vehicle.html',
						controller: "vehicleShowAllController"
                    }
                }
			}).state("vehicles", {
				url: '/details',
                params:{obj:null},
                views: {                    
                    'vehicle': {
						templateUrl: 'HTML/vehicle/vehicle-View.html',
						controller: "vehicleController"
                    },                    
                }
                
            });
    }]);



