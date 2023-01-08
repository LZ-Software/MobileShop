from django.contrib.auth import models as auth_models
from django.contrib.auth.models import UserManager
from django.db import models

from rolepermissions import checkers as rolepermissions_checkers

from MobileShopBackend.authentication import roles
from MobileShopBackend.locality import models as locality_models
from MobileShopBackend.images import models as image_models


class Profile(auth_models.AbstractBaseUser):
    """
    User profile information
    """

    id = models.AutoField(
        primary_key=True
    )
    user = models.ForeignKey(
        to=auth_models.User,
        related_name='profiles',
        related_query_name='profile',
        on_delete=models.CASCADE,
    )
    first_name = models.CharField(
        max_length=128,
        null=False
    )
    last_name = models.CharField(
        max_length=128,
        null=True
    )
    city = models.ForeignKey(
        to=locality_models.City,
        related_name='cities',
        related_query_name='city',
        on_delete=models.DO_NOTHING,
    )
    image = models.ForeignKey(
        to=image_models.ImageModel,
        related_name='images',
        related_query_name='image',
        on_delete=models.DO_NOTHING,
    )

    EXCLUDE_FIELDS = ['pk']
    FILTER_FIELDS = ['user_id']

    class Meta:
        """
        Additional meta information on model
        """

        db_table = 'user_info'
