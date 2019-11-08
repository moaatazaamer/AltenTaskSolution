App.service("vehicleService", ["$http","commonClientService",
function ($http, commonClientService) {
        return {
            getvehicles: getvehiclePaging,
			listen: listen,
			pingStatus: pingStatus
        }
	function pingStatus() {
            var request = $http({
                method: "GET",
				url: "http://vehicle.status.com/webapi/api/Status/PingStatus/"
            });
		return (request.then(
			function (response) {
				return response.data;
			}, function (error) {
				return error;
			}));
        }
        function getvehiclePaging(pageSize,pageNumber,count) {
            var request = $http({
                method: "GET",
				url: "http://vehicle.status.com/webapi/api/vehicle/"
            });
            return (request.then(
                        function (response) {                         
                            return response.data;
                        }, function (error) {
                            return error;
                        }));
        }
	function listen() {
            var request = $http({
				method: "POST",
				url: "http://vehicle.status.com/webapi/api/Status/Listen/",
                });
            return (request.then(
                        function (response) {
                            return response;
                        }, function (error) {
                            return error;
                        }));
        }
    }]);