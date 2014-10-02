var app = angular.module('blackSwanAccounting', []);

app.directive('blackSwanHeader', function() {
    return {
        restrict: 'E',
        templateUrl: 'black-swan-header.html'
    };
});

app.directive('blackSwanFooter', function() {
    return {
        restrict: 'E',
        templateUrl: 'black-swan-footer.html'
    };
});

app.directive('incomeTaxRates', function () {
    return {
        restrict: 'E',
        templateUrl: 'income-tax-rates.html'
    };
});