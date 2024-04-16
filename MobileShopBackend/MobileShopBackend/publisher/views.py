from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers
from . import models as publisher_models

from MobileShopBackend.authentication.roles.permissions import permissions, has_permission


class CreatePublisher(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_PUBLISHER_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.PublisherCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        publisher = publisher_models.Publisher.objects.create(
            user_id=data.get('user'),
            name=data.get('name')
        )
        publisher.save()

        return rest_response.Response(
            data={
                'publisher': publisher.pk,
            },
            status=rest_status.HTTP_200_OK,
        )


class EditPublisher(views.APIView):

    http_method_names = ['put']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_PUBLISHER_UPDATE

    @staticmethod
    def put(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.PublisherEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        publisher = publisher_models.Publisher.objects.get(id=data['id'])
        publisher.name = data.get('name')
        publisher.user_id = data.get('user')
        publisher.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class DeletePublisher(views.APIView):
    http_method_names = ['delete']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_PUBLISHER_DELETE

    @staticmethod
    def delete(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.PublisherDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        publisher = publisher_models.Publisher.objects.get(id=data['id'])
        publisher.delete()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetPublishers(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_PUBLISHER_READ

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        return rest_response.Response(
            publisher_models.Publisher.objects.values(),
            status=rest_status.HTTP_200_OK,
        )
