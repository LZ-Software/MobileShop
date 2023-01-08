from django.db import models


class Country(models.Model):

    id = models.AutoField(
        primary_key=True
    )
    name = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )

    class Meta:
        db_table = 'country'

    def __str__(self):
        return str(self.name)


class City(models.Model):

    id = models.AutoField(
        primary_key=True
    )
    name = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )
    country = models.ForeignKey(
        to=Country,
        related_name='cities',
        related_query_name='city',
        on_delete=models.CASCADE,
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'city'

    def __str__(self):
        return str(self.name)
