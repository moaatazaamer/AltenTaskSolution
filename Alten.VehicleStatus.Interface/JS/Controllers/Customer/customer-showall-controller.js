App.controller("customerShowAllController", ["$scope", "customerService", "customerClientService", "commonService",
function ($scope, customerService, customerClientService,commonService) {
       
        $scope.pageDirection={
            first:1,
            previous: 2,
            next: 3,
            last:4
        }
        $scope.pageSizing = [{ Id:10, Value: 10 }, { Id:50,Value: 50 }, { Id:100,Value: 100 }];
        $scope.Application = {};
        $scope.init = function () {
            if (!$scope.Application)
                $scope.Application={};
            $scope.Application.IsHidden = true;
            $scope.commonService = commonService;
            $scope.pageSize = 10;
            $scope.pageNumber = 1;
            $scope.getcustomerPaging();
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
            $scope.getcustomerPaging();
        }
        $scope.changePageSize = function () {
            $scope.pageNumber = 1;
            $scope.getcustomerPaging();
        }
        $scope.getcustomerPaging = function () {
            $scope.Application.IsHidden = true;
            customerService.getcustomers($scope.pageSize, $scope.pageNumber, $scope.count).then(
                function (response) {
                    $scope.Application = {};
                    $scope.Application = response.Data;
                    $scope.count = parseInt(response.Message);
                    $scope.endPage = Math.ceil($scope.count / $scope.pageSize);
                    $scope.Application.IsHidden = false;
                }
                );            
        }
       
        $scope.addDummy = function ($event) {
            if ($event)
                event.preventDefault();
            if (!$scope.Application)
                $scope.Application = {};
            $scope.Application.IsHidden = true;
            customerService.addDummy(100).then(
              function (response) {
                  if (response && response.IsSuccessded) {
                      $scope.Application.IsHidden = false;
                  }
              });
        }

        $scope.setcustomer = function (customer) {
            customerClientService.sharedParam = customer;
            
        }
}]);