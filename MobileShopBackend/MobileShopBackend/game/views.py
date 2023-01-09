import datetime
import typing
from django.db import transaction
from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers
from . import models

from MobileShopBackend.authentication.roles.permissions import permissions, has_permission


@transaction.atomic
def create_game(
        name: typing.Optional[str],
        description: typing.Optional[str],
        price: typing.Optional[float],
        publisher: typing.Optional[str],
        dt_release: datetime,
        image_base64: typing.Optional[str],
        genres: typing.Optional[list]):
    image = models.ImageModel.objects.create(image_base64=image_base64)
    image.save()

    game = models.Game.objects.create(name=name,
                                      description=description,
                                      price=price,
                                      publisher=publisher,
                                      dt_release=dt_release,
                                      image_id=image.pk)
    game.save()

    for genre in genres:

        game_genre = models.GameGenre.objects.create(game_id=game.pk,
                                                     genre_id=genre)
        game_genre.save()

    return game


class CreateGame(views.APIView):
    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GAME_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:
        serializer = serializers.GameCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        game = create_game(**data)

        return rest_response.Response(
            data={
                'game': game.pk,
            },
            status=rest_status.HTTP_200_OK,
        )


class DeleteGame(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GAME_DELETE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.GameDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        game = models.Game.objects.get(id=data['id'])
        game.delete()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )
