from django.db import models


class ImageModel(models.Model):
    """ Country of user"""

    id = models.AutoField(
        primary_key=True
    )
    image_base64 = models.TextField(
        null=False
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'images'
