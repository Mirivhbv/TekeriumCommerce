﻿(function() {
    angular
        .module('tekerAdmin.catalog')
        .factory('categoryService', categoryService);

    function categoryService($http, Upload) {
        var service = {
            getCategory: getCategory,
            createCategory: createCategory,
            editCategory: editCategory,
            deleteCategory: deleteCategory,
            getCategories: getCategories,
            getProducts: getProducts,
            saveProduct: saveProduct,
            getSeasons: getSeasons,
            getCultures: getCultures
        };
        return service;

        function getCategory(id) {
            return $http.get('api/categories/' + id);
        }

        function getCategories() {
            return $http.get('api/categories');
        }

        function createCategory(category) {
            return Upload.upload({
                url: 'api/categories',
                data: category
            });
        }

        function editCategory(category) {
            return Upload.upload({
                url: 'api/categories/' + category.id,
                method: 'PUT',
                data: category
            });
        }

        function deleteCategory(category) {
            return $http.delete('api/categories/' + category.id);
        }

        function getProducts(id, params) {
            return $http.post('api/categories/' + id + '/products', params);
        }

        function saveProduct(product) {
            return $http.put('api/categories/update-product/' + product.id, product);
        }

        function getSeasons() {
            return $http.get('api/categories/seasons');
        }

        function getCultures() {
	        return $http.get('api/categories/getCultures'); // todo: move it to localization module later
        }
    }
})();