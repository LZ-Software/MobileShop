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
        publisher: typing.Optional[int],
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
                                      image=image)
    game.save()

    for genre in genres:
        game_genre = models.GameGenre.objects.create(game=game, genre=genre)
        game_genre.save()

    return game


@transaction.atomic
def edit_game(
        game_id: typing.Optional[int],
        name: typing.Optional[str],
        description: typing.Optional[str],
        price: typing.Optional[float],
        publisher: typing.Optional[int],
        dt_release: datetime,
        image_base64: typing.Optional[str],
        genres: typing.Optional[list]):

    image = models.ImageModel.objects.create(image_base64=image_base64)
    image.save()

    game = models.Game.objects.get(id=game_id)
    game.name = name
    game.description = description
    game.price = price
    game.publisher = publisher
    game.dt_release = dt_release
    game.image = image
    game.save()

    models.GameGenre.objects.get(game_id=game_id).delete()

    for genre in genres:
        game_genre = models.GameGenre.objects.create(game=game, genre=genre)
        game_genre.save()


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


class EditGame(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_GENRE_UPDATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:
        serializer = serializers.GameEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        edit_game(**data)

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetGame(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_GAME_READ

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        serializer = serializers.GameDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        game = models.Game.objects.get(id=data['id'])
        image = game.image.image_base64
        publisher = game.publisher.name
        genres = models.GameGenre.objects.filter(game=game)

        genre_ret = []

        for genre in genres:
            genre_ret.append(genre.genre)

        game_ret = [{
            'id': game.pk,
            'name': game.name,
            'description': game.description,
            'price': game.price,
            'publisher': publisher,
            'dt_release': game.dt_release,
            'image': image,
            'genres': genre_ret
        }]

        return rest_response.Response(
            game_ret,
            status=rest_status.HTTP_200_OK,
        )


class GetGames(views.APIView):

    http_method_names = ['get']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.USER_GAME_READ

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        games = models.Game.objects.values()

        games_ret = []
        for game in games:
            image = game.image.image_base64
            publisher = game.publisher.name
            genres = models.GameGenre.objects.filter(game=game)

            genre_ret = []
            for genre in genres:
                genre_ret.append(genre.genre)

            game_ret = {
                'id': game.pk,
                'name': game.name,
                'description': game.description,
                'price': game.price,
                'publisher': publisher,
                'dt_release': game.dt_release,
                'image': image,
                'genres': genre_ret
            }
            games_ret.append(game_ret)

        return rest_response.Response(
            games_ret,
            status=rest_status.HTTP_200_OK,
        )
        