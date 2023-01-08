from django.contrib.auth import models as auth_models
from django.db import models
from rolepermissions import checkers as rolepermissions_checkers

from MobileShopBackend.authentication import roles
from MobileShopBackend.locality import models as locality_models
from MobileShopBackend.images import models as image_models


class User(auth_models.AbstractBaseUser, auth_models.PermissionsMixin):
    """ User in system """

    id = models.AutoField(
        primary_key=True
    )
    username = models.CharField(
        max_length=128,
        null=False,
        unique=True
    )
    password = models.CharField(
        max_length=256,
        null=False
    )

    class Meta:
        """ Additional meta information on model """
        db_table = 'user_login'

    def __str__(self):
        return str(self.username)

    @property
    def is_superuser(self) -> bool:
        """
        :return: Is user a superuser
        """

        return any(
            role.is_superuser
            for role in roles.get_user_roles(self)
        )

    @property
    def is_staff(self) -> bool:
        """
        :return: Is user allowed to enter to administrator site
        """

        return rolepermissions_checkers.has_permission(
            self,
            roles.permissions.ADMIN_ACCESS,
        )

    def get_role_name(self) -> str:
        """
        :return: Name(s) of the role(s) assigned to user
        """

        return ', '.join(
            str(role.verbose_name)
            for role in roles.get_user_roles(self)
        )


class Profile(auth_models.AbstractBaseUser):
    """
    User profile information
    """

    id = models.AutoField(
        primary_key=True
    )
    user = models.ForeignKey(
        to=User,
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
        to=image_models.Image,
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
