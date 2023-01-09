from django.contrib import auth

from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status
from rest_framework.authtoken import models as authtoken_models

from . import serializers

USER = auth.get_user_model()


class RegisterUser(views.APIView):

    http_method_names = ['post']

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.RegisterUserSerializer(data=request.data)
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
