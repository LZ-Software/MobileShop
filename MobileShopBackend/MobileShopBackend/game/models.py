from django.db import models

from MobileShopBackend.authentication.models import User
from MobileShopBackend.genre.models import Genre
from MobileShopBackend.images.models import ImageModel
from MobileShopBackend.publisher.models import Publisher


class Game(models.Model):
    id = models.AutoField(
        primary_key=True
    )

    name = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )

    description = models.CharField(
        max_length=2048,
        null=False
    )

    price = models.FloatField(
        null=False
    )

    publisher = models.ForeignKey(
        null=False,
        to=Publisher,
        related_name='publishers',
        related_query_name='publisher',
        on_delete=models.CASCADE
    )
    dt_release = models.DateTimeField(
        null=False
    )

    image = models.ForeignKey(
        to=ImageModel,
        related_name='images',
        related_query_name='image',
        on_delete=models.DO_NOTHING
    )

    class Meta:
        db_table = 'game'

    def __str__(self):
        return str(self.name)


class GameGenre(models.Model):

    id = models.AutoField(
        primary_key=True
    )

    game = models.ForeignKey(
        to=Game,
        related_name='games',
        related_query_name='game',
        on_delete=models.CASCADE
    )

    genre = models.ForeignKey(
        to=Genre,
        related_name='genres',
        related_query_name='genre',
        on_delete=models.CASCADE
    )

    class Meta:
        db_table = 'game_genre'

    def __str__(self):
        return "{game} {genre}".format(game=self.game, genre=self.genre)


class GamePurchase(models.Model):

    id = models.AutoField(
        primary_key=True
    )

    game = models.ForeignKey(
        to=Game,
        related_name='games',
        related_query_name='game',
        on_delete=models.DO_NOTHING
    )

    user = models.ForeignKey(
        to=User,
        related_name='users',
        related_query_name='user',
        on_delete=models.DO_NOTHING
    )

    time = models.DateTimeField(
        auto_now_add=True
    )

    class Meta:
        db_table = 'game_purchase'

    def __str__(self):
        return str(self.game)


class Library(models.Model):

    id = models.AutoField(
        primary_key=True
    )

    user = models.ForeignKey(
        to=User,
        related_name='users',
        related_query_name='user',
        on_delete=models.CASCADE
    )

    game = models.ForeignKey(
        to=Game,
        related_name='games',
        related_query_name='game',
        on_delete=models.CASCADE
    )

    class Meta:
        db_table = 'user_library'

    def __str__(self):
        return "{user} {game}".format(user=self.user, game=self.game)
