from django.contrib import auth

from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status
from rest_framework.authtoken import models as authtoken_models

from . import models as auth_models
from . import serializers as user_serializers
from .roles import permissions
from .roles.permissions import has_permission

from MobileShopBackend.locality import models as locality_models
from MobileShopBackend.images import models as image_models
from MobileShopBackend.game import models as game_models

from MobileShopBackend.images import serializers as image_serializers

USER = auth.get_user_model()


class AuthorizeUser(views.APIView):

    http_method_names = ['post']

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = user_serializers.UserAuthorizeSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        user = auth.authenticate(
            request=request._request,
            username=data['login'],
            password=data['password'],
        )

        if user is None:
            return rest_response.Response(
                data={'success': False},
                status=rest_status.HTTP_400_BAD_REQUEST,
            )

        authtoken_models.Token.objects.filter(user=user).delete()
        token = authtoken_models.Token.objects.create(user=user)

        return rest_response.Response(
            data={'token': token.key},
            status=rest_status.HTTP_200_OK,
        )


class GetUserProfile(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_USER_INFO_READ

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        profile = auth_models.Profile.objects.get(user=request.user)

        return rest_response.Response(
            profile.as_dict(),
            status=rest_status.HTTP_200_OK,
        )


class RegisterUser(views.APIView):

    http_method_names = ['post']

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = user_serializers.UserCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        user = USER.objects.create_user(**data)

        if user:
            authtoken_models.Token.objects.filter(user=user).delete()
            token = authtoken_models.Token.objects.create(user=user)
            return rest_response.Response(
                data={
                    'token': token.key,
                },
                status=rest_status.HTTP_200_OK,
            )


class EditUser(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_USER_INFO_UPDATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = user_serializers.UserEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        city = locality_models.City.objects.get(name=data.pop('city'))
        data['city'] = city

        profile = auth_models.Profile.objects.get(user=request.user)
        profile.first_name = data['first_name']
        profile.last_name = data['last_name']
        profile.city = data['city']
        profile.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class EditUserImage(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_USER_INFO_UPDATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = image_serializers.ImageSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        image = image_models.ImageModel.objects.create(image_base64=data['image'])

        profile = auth_models.Profile.objects.get(user=request.user)
        profile.image = image
        profile.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetUserLibrary(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_USER_LIBRARY_ACCESS

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        user_games = game_models.Library.objects.filter(user=request.user)

        games = []
        for user_game in user_games:
            games.append({
                'id': user_game.game.pk,
                'name': user_game.game.name,
                'image': user_game.game.image.image_base64,
            })

        return rest_response.Response(
            games,
            status=rest_status.HTTP_200_OK,
        )
