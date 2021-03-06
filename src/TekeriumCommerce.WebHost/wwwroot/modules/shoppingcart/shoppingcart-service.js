﻿(function() {
    angular
        .module('teker.shoppingCart')
        .factory('shoppingCartService',
            [
                '$http',
                function($http) {
                    function getShoppingCartItems() {
                        return $http.get('cart/list');
                    }

                    function removeShoppingCartItem(itemId) {
                        return $http.post('cart/remove', itemId);
                    }

                    function updateQuantity(itemId, quantity) {
                        return $http.post('cart/update-quantity',
                            {
                                cartItemId: itemId,
                                quantity: quantity
                            });
                    }

                    function updateCity(cityId) {
                        console.log('city-id:' + cityId);
                        return $http.post('cart/update-shipping-city', cityId);
                    }

                    return {
                        getShoppingCartItems: getShoppingCartItems,
                        removeShoppingCartItem: removeShoppingCartItem,
                        updateQuantity: updateQuantity,
                        updateCity: updateCity
                    };
                }
            ]);
})();