from django.db import models


class ShoppingCart(models.Model):
    """ Country of user"""

    id = models.AutoField(
        primary_key=True
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'images'
