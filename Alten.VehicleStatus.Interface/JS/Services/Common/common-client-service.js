App.service("commonClientService", [function () {
   
	var sharedParamter = {
		vehicle: {},
		isListenerServerUp: "",
		
	};

	return {
		sharedParam: sharedParamter
	}
}]);