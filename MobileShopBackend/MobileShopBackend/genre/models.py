from django.db import models


class Genre(models.Model):
    id = models.AutoField(
        primary_key=True
    )
    name = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )

    class Meta:
        db_table = 'genre'

    def __str__(self):
        return str(self.name)