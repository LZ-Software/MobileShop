from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers

from MobileShopBackend.authentication.roles.permissions import permissions, has_permission

from MobileShopBackend.game import models as game_models

import random


class GetShoppingCart(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_SHOPPING_CART_READ

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        shopping_cart = list(request.session.get(f'shopping_cart_{request.user.id}', []))

        return rest_response.Response(
            data=shopping_cart,
            status=rest_status.HTTP_200_OK,
        )


class AddToShoppingCart(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_SHOPPING_CART_CREATE_ITEM

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.ShoppingCartSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        new_id = data['id']

        try:
            game_models.Library.objects.get(game_id=new_id, user_id=request.user)
            return rest_response.Response(
                data={
                    'status': 'Already in library'
                },
                status=rest_status.HTTP_400_BAD_REQUEST,
            )
        except game_models.Library.DoesNotExist:
            pass

        shopping_cart = list(request.session.get(f'shopping_cart_{request.user.id}', []))

        if new_id in shopping_cart:
            return rest_response.Response(
                data={
                    'status': 'Already in shopping cart'
                },
                status=rest_status.HTTP_400_BAD_REQUEST,
            )

        shopping_cart.append(new_id)
        request.session[f'shopping_cart_{request.user.id}'] = shopping_cart

        return rest_response.Response(
            data={
                'status': 'Success'
            },
            status=rest_status.HTTP_201_CREATED,
        )


class PopFromShoppingCart(views.APIView):

    http_method_names = ['delete']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_SHOPPING_CART_DELETE_ITEM

    @staticmethod
    def delete(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.ShoppingCartSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        game_id = data['id']

        shopping_cart = list(request.session.get(f'shopping_cart_{request.user.id}', []))

        if game_id not in shopping_cart:
            return rest_response.Response(
                data={
                    'status': 'Not in shopping cart'
                },
                status=rest_status.HTTP_400_BAD_REQUEST,
            )

        shopping_cart = list(request.session.get(f'shopping_cart_{request.user.id}', []))
        shopping_cart.remove(game_id)

        request.session[f'shopping_cart_{request.user.id}'] = shopping_cart

        return rest_response.Response(
            data={
                'status': 'Success'
            },
            status=rest_status.HTTP_200_OK,
        )


class Purchase(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_GAME_PURCHASE_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        shopping_cart = list(request.session.get(f'shopping_cart_{request.user.id}', []))

        if len(shopping_cart) == 0:
            return rest_response.Response(
                data={
                    'success': 'Shopping cart is empty'
                },
                status=rest_status.HTTP_200_OK,
            )

        if status := random.choice([True, False]):
            for game_id in shopping_cart:
                purchase = game_models.GamePurchase.objects.create(user=request.user, game_id=game_id)
                purchase.save()
                game_library = game_models.Library.objects.create(user=request.user, game_id=game_id)
                game_library.save()
            shopping_cart.clear()
            request.session[f'shopping_cart_{request.user.id}'] = shopping_cart

        return rest_response.Response(
            data={
                'status': status
            },
            status=rest_status.HTTP_200_OK,
        )
