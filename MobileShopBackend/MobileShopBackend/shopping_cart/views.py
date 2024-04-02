from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers
from . import models as image_models

from MobileShopBackend.authentication.roles.permissions import permissions, has_permission


class CreateImage(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_IMAGES_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.ImageSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        image = image_models.ImageModel.objects.create(**data)
        image.save()

        return rest_response.Response(
            data={
                'image': image.pk,
            },
            status=rest_status.HTTP_200_OK,
        )
