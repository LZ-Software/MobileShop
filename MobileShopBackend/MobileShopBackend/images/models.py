from django.db import models


class Image(models.Model):
    """ Country of user"""

    id = models.AutoField(
        primary_key=True
    )
    image = models.TextField(
        null=False
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'images'
