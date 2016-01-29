angular.module('ProductAdd', [])
        .controller('ProductAddController', ['$scope', '$http', function ($scope, $http) {
            $scope.submit = function () {
                if ($scope.Name) {
                    var product = {
                        "Name": $scope.Name,
                        "Category": $scope.Type,
                        "Price": $scope.Price
                    }
                    $http.post('http://localhost:1110/api/product', product)
                    .success(function (data, status, headers, config) {
                        alert('Product Added Successfully');
                    })
                    .error(function (data, status, headers, config) {
                        alert("erro");
                    });
                }
            };
        }]);