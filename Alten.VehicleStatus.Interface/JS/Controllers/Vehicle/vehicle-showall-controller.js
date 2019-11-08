App.controller("vehicleShowAllController", ["$scope", "vehicleService", "commonClientService", "commonService",
	function ($scope, vehicleService, commonClientService, commonService) {

		$scope.pageDirection = {
			first: 1,
			previous: 2,
			next: 3,
			last: 4
		}
		if (commonClientService && commonClientService.sharedParam && commonClientService.sharedParam.timeInterval)
			clearInterval(commonClientService.sharedParam.timeInterval);
		$scope.searchquery = "";
		//$scope.pageSizing = [{ Id:10, Value: 10 }, { Id:50,Value: 50 }, { Id:100,Value: 100 }];
		$scope.Application = {};
		$scope.init = function () {
			if (!$scope.Application)
				$scope.Application = {};
			$scope.Application.IsHidden = true;
			$scope.pageSize = 10;
			$scope.pageNumber = 1;
			$scope.getvehiclePaging();
		}

		$scope.changePage = function (direction) {
			switch (direction) {
				case $scope.pageDirection.first:
					$scope.pageNumber = 1;
					break;
				case $scope.pageDirection.previous:
					$scope.pageNumber = $scope.pageNumber - 1;
					break;
				case $scope.pageDirection.next:
					$scope.pageNumber = $scope.pageNumber + 1;
					break;
				case $scope.pageDirection.last:
					$scope.pageNumber = $scope.endPage;
					break;
			}
			$scope.getvehiclePaging();
		}
		$scope.changePageSize = function () {
			$scope.pageNumber = 1;
			$scope.getvehiclePaging();
		}
		$scope.getvehiclePaging = function () {
			$scope.Application.IsHidden = true;

			vehicleService.getvehicles(/*$scope.pageSize, $scope.pageNumber, $scope.count*/).then(
				function (response) {
					$scope.Application = {};
					$scope.Application = response.Data;
					$scope.count = parseInt(response.Message);
					//$scope.endPage = Math.ceil($scope.count / $scope.pageSize);
					$scope.Application.IsHidden = false;
				}
			);
		}
			   
		$scope.setvehicle = function (vehicle) {
			commonClientService.sharedParam.vehicle = vehicle;
			if (commonClientService && commonClientService.sharedParam && commonClientService.sharedParam.isListenerServerUp != "up")
				vehicleService.listen().then(
					function(response) {
						commonClientService.sharedParam.isListenerServerUp = response;
					}
				);


		}
	}]);