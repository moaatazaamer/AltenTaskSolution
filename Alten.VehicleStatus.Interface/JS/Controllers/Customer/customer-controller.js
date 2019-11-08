App.controller("customerController", ["$scope", "customerService", "customerClientService", "commonService",
function ($scope, customerService, customerClientService, commonService) {


    $scope.init = function () {
        if (customerClientService && customerClientService.sharedParam) {
            $scope.customer = angular.copy(customerClientService.sharedParam);
            $scope.imgURL = commonService.serverPath + "0" + commonService.profilePictureExtension + "?img=" + $scope.customer.Id + "&size=L";           
        }
        customerClientService.sharedParam = {};
        if (!$scope.customer)
            $scope.customer = {};

        $scope.customer.IsHidden = false;
    }

    $scope.addcustomer = function ($event) {
        if ($event)
            event.preventDefault();
        $scope.customer.IsHidden = true;
        if ($scope.customer && $scope.customer.Name)
            customerService.addcustomer($scope.customer).then(
                function (response) {
                    if (response && response.IsSuccessded) {
                        $scope.customer = response.Data;
                        var imgName = '';
                        imgName = $scope.customer.Id ?
                       $scope.customer.Id : '0';
                        $scope.isEmpUpdated = (response.Message = "updated")
                        if (imgName)
                            $scope.upload(imgName)
                        else
                            $scope.customer.IsHidden = false;
                        if (!$scope.isEmpUpdated) {
                            alert("added succcessfuly");
                            $scope.customer = {};
                            var uploaderElement = document.getElementById('file_ProfilePic');
                            document.getElementById('img_PP').src = '';
                            $scope.imgURL = '';
                            uploaderElement.value = "";
                            
                        }
                    }

                });
    }

    $scope.upload = function (imgName) {
        if ($scope.customer && $scope.customer.Name) {
            var uploaderElement = document.getElementById('file_ProfilePic');
            if (uploaderElement) {
                var files = uploaderElement.files;
                var myPhoto = new FormData();
                myPhoto.append("UploadedFile", files[0]);
                var customerData = angular.copy($scope.customer);
                commonService.upload(myPhoto, imgName).then(function (response) {
                                       
                        if (!$scope.isEmpUpdated) {
                            $scope.customer = {}
                        document.getElementById('img_PP').src = '';
                        $scope.imgURL = '';
                        uploaderElement.value = "";
                    }
                    $scope.customer.IsHidden = false;
                    if ($scope.isEmpUpdated) {
                        alert('updated successfuly!');
                        $scope.customer = customerData;
                    }
                });
            }
        }
    }
    $scope.previewImage = function () {
        var files = document.getElementById('file_ProfilePic').files;
        if (files && files.length > 0) {
            var file = files[0];
            var img = document.getElementById("img_PP");
            img.file = file;
            var reader = new FileReader();
            reader.onload = (function (aImg) {
                return function (event) {
                    aImg.src = event.target.result;
                };
            })(img);
            reader.readAsDataURL(file);
        }
    }
    $scope.removeImage = function () {        
        if ($scope.imgURL != commonService.serverPath + "0" + commonService.profilePictureExtension + "?img=0&size=L")
            commonService.removeImage($scope.customer.Id).then($scope.imgURL = commonService.serverPath + "0" + commonService.profilePictureExtension + "?img=0&size=L");
    }

}]);