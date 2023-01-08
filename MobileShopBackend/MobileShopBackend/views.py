from django.contrib import auth
from django.utils import translation
from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status
from rest_framework.authtoken import models as authtoken_models
from advoservice.apps.general.tools.converters import SimpleObject
from advoservice.apps.authentication import models as auth_models
from ... import serializers


class AuthEmailApiView(views.APIView):
    """ View for customer authorization by email and password """

    http_method_names = ['post']

    @staticmethod
    def post(
            request: rest_request.Request,
    ) -> rest_response.Response:
        """ Authenticate by email & password """

        serializer = serializers.v1.AuthEmailSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = SimpleObject(**serializer.validated_data)

        user_exists = auth_models.UserLogin.objects.filter(is_active=True,
                                                           type=auth_models.UserLoginType.EMAIL,
                                                           login=data.email).exists()

        if not user_exists:
            return rest_response.Response(
                data={
                    'detail': translation.pgettext_lazy('app_client_api', 'The email you provided is not registered'),
                },
                status=rest_status.HTTP_400_BAD_REQUEST,
            )

        user = auth.authenticate(
            request=request._request,  # pylint: disable=protected-access
            username=data.email,
            password=data.password,
        )
        if user:
            authtoken_models.Token.objects.filter(user=user).delete()
            token = authtoken_models.Token.objects.create(user=user)
            return rest_response.Response(
                data={
                    'token': token.key,
                },
                status=rest_status.HTTP_200_OK,
            )
        return rest_response.Response(
            data={
                'detail': translation.pgettext_lazy('app_client_api', 'Login or password is incorrect'),
            },
            status=rest_status.HTTP_400_BAD_REQUEST,
        )
