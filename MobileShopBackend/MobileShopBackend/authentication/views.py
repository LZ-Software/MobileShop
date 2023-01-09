from django.contrib import auth

from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status
from rest_framework.authtoken import models as authtoken_models

from . import models
from . import serializers


class RegisterUser(views.APIView):

    http_method_names = ['post']

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.RegisterUserSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        user = models.SelfUserManager.create_user(username=data.username,
                                                  password=data.password,
                                                  first_name=data.first_name,
                                                  last_name=data.last_name,
                                                  city=data.city)

        if user:
            authtoken_models.Token.objects.filter(user=user).delete()
            token = authtoken_models.Token.objects.create(user=user)
            return rest_response.Response(
                data={
                    'token': token.key,
                },
                status=rest_status.HTTP_200_OK,
            )
