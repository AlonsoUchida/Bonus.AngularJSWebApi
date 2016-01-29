app.controller("ProductController", function ($scope, $http) {
    $http.get('http://localhost:4567/api/productapi')
        .success(function (data, status, headers, config) {
            $scope.products = data;
            console.log($scope.products);
        })
        .error(function (data, status, headers, config) {
            alert("error");
        });
});