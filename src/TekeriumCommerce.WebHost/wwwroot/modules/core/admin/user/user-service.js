﻿(function() {
    angular.module('tekerAdmin.core')
        .factory('userService', userService);

    //ngInject
    function userService($http) {
        var service = {
            getUsers: getUsers,
            getUser: getUser,
            createUser: createUser,
            editUser: editUser,
            deleteUser: deleteUser,
            getRoles: getRoles,
            getVendors: getVendors
        };
        return service;

        function getUsers(params) {
            console.log('we are here');
            return $http.post('api/users/grid', params);
        }

        function getUser(id) {
            console.log('getUser');
            return $http.get('api/users/' + id);
        }

        function createUser(user) {
            return $http.post('api/users', user);
        }

        function editUser(user) {
            return $http.put('api/users/' + user.id, user);
        }

        function deleteUser(user) {
            console.log('delete user');
            return $http.delete('api/users/' + user.id, null);
        }

        function getRoles() {
            console.log('log: getRoles');
            return $http.get('api/roles');
        }

        function getVendors() {
            return $http.get('api/vendors');
        }
    }
})();