from django.contrib import auth

from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status
from rest_framework.authtoken import models as authtoken_models

from . import models as auth_models
from . import serializers
from .roles import permissions
from .roles.permissions import has_permission

from MobileShopBackend.locality import models as locality_models

USER = auth.get_user_model()


class RegisterUser(views.APIView):

    http_method_names = ['post']

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.UserCreateSerializer(data=request.data)
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

        serializer = serializers.UserEditSerializer(data=request.data)
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
