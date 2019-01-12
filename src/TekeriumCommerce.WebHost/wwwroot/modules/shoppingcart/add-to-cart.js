﻿$(function() {
    $('body').on('click', '.btn-add-cart', function() {
        //$('#productOverview').modal('hide');

        var quantity,
            $form = $(this).closest('form'),
            productId =
                $(this).closest('form').find('input[name=productId]')
                    .val(), // check, whether you have added it to page or not?
            $quantityInput = $form.find('.quantity-field');

        quantity = $quantityInput.length === 1 ? $quantityInput.val() : 1;

        $.ajax({
            type: 'POST',
            url: '/cart/addtocart',
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            contentType: 'application/json'
        }).done(function(data) {
            alert('added');
        }).fail(function() {
            alert('something went wrong');
        })
    })
})