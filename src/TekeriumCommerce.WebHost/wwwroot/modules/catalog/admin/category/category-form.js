﻿(function () {
    angular
        .module('tekerAdmin.catalog')
        .controller('CategoryFormCtrl', CategoryFormCtrl);

    function CategoryFormCtrl($q, $state, $stateParams, categoryService) {
        var vm = this, tableStateRef;

        vm.category = { isPublished: true };
        vm.category.locales = [];
        vm.categories = [];
        vm.products = [];
        vm.locales = [];
        vm.cultures = [];
        vm.categoryId = $stateParams.id;
        vm.isEditMode = vm.categoryId > 0;

        vm.updateSlug = function () {
            vm.category.slug = slugify(vm.category.name);
        };

        vm.save = function save() {
            var promise;
            vm.category.description = vm.category.description === null ? '' : vm.category.description;
            vm.category.metaTitle = vm.category.metaTitle === null ? '' : vm.category.metaTitle;
            vm.category.metaKeywords = vm.category.metaKeywords === null ? '' : vm.category.metaKeywords;
            vm.category.metaDescription = vm.category.metaDescription === null ? '' : vm.category.metaDescription;

            // locale
            vm.category.locales.forEach(e => {
	            e.name = e.name === null ? '' : e.name;
	            e.description = e.description === null ? '' : e.description;
            });

            if (vm.isEditMode) {
                promise = categoryService.editCategory(vm.category);
            } else {
                promise = categoryService.createCategory(vm.category);
            }

            promise
                .then(function (result) {
                    $state.go('category');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add category.');
                    }
                });
        }

        vm.getProducts = function getProducts(tableState) {
            if (!vm.categoryId) {
                return;
            }

            tableStateRef = tableState;
            vm.isLoading = true;
            categoryService.getProducts(vm.categoryId, tableState).then(function (result) {
                vm.products = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        }

        vm.editProduct = function editProduct(product) {
            product.isEditing = true;
            product.editingIsFeaturedProduct = product.isFeaturedProduct;
            product.editingDisplayOrder = product.displayOrder;
        }

        vm.saveProduct = function saveProduct(product) {
            var productCategory = {
                'id': product.id,
                'isFeaturedProduct': product.editingIsFeaturedProduct,
                'displayOrder': product.displayOrder
            };
            categoryService.saveProduct(productCategory).then(function () {
                product.isEditing = false;
                product.isFeaturedProduct = product.editingIsFeaturedProduct;
                product.displayOrder = product.editingDisplayOrder;
            });
        }

        function init() {
            if (vm.isEditMode) {
                $q.all([
                    categoryService.getCategories(),
                    categoryService.getCategory(vm.categoryId)
                ])
                    .then(function (result) {
                        console.log(result);

                        var index;
                        vm.categories = result[0].data;
                        vm.category = result[1].data;

                        index = vm.categories.map(x => x.id).indexOf(vm.category.id);
                        vm.categories.splice(index, 1);
                    });
            } else {
                categoryService.getCategories().then(function (result) {
                    vm.categories = result.data;
                });

                categoryService.getCultures().then((r) => {
	                vm.cultures = r.data;
	                //console.log(vm.cultures); // remove later
	                vm.cultures.forEach((e) => {
                        vm.category.locales.push({
	                        cultureId: e.id,
                            name: null,
	                        description: null
						});
                    });
                    console.log(vm.category.locales);
				});
            }
        }

        init();
    }
})();