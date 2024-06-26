from django.db import models

from MobileShopBackend.authentication.models import User


class Publisher(models.Model):

    id = models.AutoField(
        primary_key=True
    )
    name = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )
    user = models.ForeignKey(
        to=User,
        related_name='publishers',
        related_query_name='publisher',
        on_delete=models.DO_NOTHING
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'publisher'

    def __str__(self):
        return str(self.name)
