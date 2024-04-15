from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers
from . import models as genre_models

from MobileShopBackend.authentication.roles.permissions import permissions, has_permission


class CreateGenre(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GENRE_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.GenreCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        genre = genre_models.Genre.objects.create(**data)
        genre.save()

        return rest_response.Response(
            data={
                'genre': genre.pk,
            },
            status=rest_status.HTTP_200_OK,
        )


class EditGenre(views.APIView):

    http_method_names = ['put']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GENRE_UPDATE

    @staticmethod
    def put(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.GenreEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        genre = genre_models.Genre.objects.get(id=data['id'])
        genre.name = data['name']
        genre.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class DeleteGenre(views.APIView):

    http_method_names = ['delete']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GENRE_DELETE

    @staticmethod
    def delete(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.GenreDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        genre = genre_models.Genre.objects.get(id=data['id'])
        genre.delete()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetGenres(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_GENRE_READ

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        return rest_response.Response(
            genre_models.Genre.objects.values(),
            status=rest_status.HTTP_200_OK,
        )
