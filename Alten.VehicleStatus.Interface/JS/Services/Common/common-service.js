App.service("commonService", ["$http", function ($http) {
    return {
        upload: uploadingFile,
        serverPath: "http://localhost:8118/WebAPI/EmployeeImages/",
        profilePictureExtension: ".ppic",
        removeImage: removeImage
    }
    function removeImage(fileName) {
        var request = $http({
            headers: {
                'Content-type': 'application/json;charset=utf-8'
            },
            method: "DELETE",
            url: "http://localhost:8118/WebAPI/api/rpc/Common/DeleteFile/" + fileName ,
            //contentType: false,
            processData: false,           
        });
        return (request.then(
                    function (response) {
                        return response.data;
                    }, function (error) {
                        return error;
                    }));
    }
    function uploadingFile(fileToUpload,fileName) {       
        var request = $http({
            headers: {'Content-Type': undefined},
            method: "POST",
            url: "http://localhost:8118/WebAPI/api/rpc/Common/Upload?fileName="+fileName,
            //contentType: false,
            processData: false,
            data: fileToUpload
        });
        return (request.then(
                    function (response) {
                        return response.data;
                    }, function (error) {
                        return error;
                    }));
    }
    var extinsion = ".ppic";
    var fullPath = "http://localhost:8118/WebAPI/EmployeeImages"
}]);