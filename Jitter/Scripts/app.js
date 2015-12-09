var app = angular.module("jitter", []);

app.controller("TestController", ["$scope", "$http", function($scope, $http) {
    $scope.test = "Test variable"

    $scope.hello = function () {
        $http.get("/api/test")
        .success(function (data) {
            $scope.test = data;
        })
        .error(function(err) {
            alert(err.error)
        });
    }
}]);