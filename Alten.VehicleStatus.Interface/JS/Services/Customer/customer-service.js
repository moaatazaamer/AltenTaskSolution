App.service("customerService", ["$http",
function ($http) {
        return {
            getcustomers: getcustomerPaging,
            addcustomer: addcustomer,
            addDummy:addDummy
        }
        function addDummy(numberOfDummies) {
            var request = $http({
                method: "GET",
                url: "http://localhost:8118/WebAPI/api/rpc/customer/AddDummy/" + numberOfDummies
            });
            return (request.then(
                       function (response) {
                           return response.data;
                       }, function (error) {
                           return error;
                       }));
        }
        function getcustomerPaging(pageSize,pageNumber,count) {
            var request = $http({
                method: "GET",
                url: "http://localhost:8118/WebAPI/api/rpc/customer/GetApplication/" + pageSize + "/" + pageNumber + "/" + count
            });
            return (request.then(
                        function (response) {                         
                            return response.data;
                        }, function (error) {
                            return error;
                        }));
        }
        function addcustomer(customer) {
            var request = $http({
                method: "POST",
                url: "http://localhost:8118/WebAPI/api/rpc/customer/Submit",
                data:customer
            });
            return (request.then(
                        function (response) {
                            return response.data;
                        }, function (error) {
                            return error;
                        }));
        }
    }]);