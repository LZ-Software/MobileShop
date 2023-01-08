from django.contrib.auth import models as auth_models
from django.db import models
from rolepermissions import checkers as rolepermissions_checkers

from MobileShopBackend.authentication import roles


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

    def get_full_name(self) -> str:
        """
        Get users full name

        :return: Full name
        """

        profile = self.profiles.actual()

        if profile:
            return f'{profile.first_name} {profile.last_name}'

        return self.username

    def get_short_name(self) -> str:
        """
        Get users short name

        :return: Short name
        """
        profile = self.profiles.actual()

        if profile:
            return f'{profile.last_name} {profile.first_name[:1].upper()}.'

        return self.username

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

    EXCLUDE_FIELDS = ['pk']
    FILTER_FIELDS = ['user_id']

    class Meta:
        """
        Additional meta information on model
        """

        db_table = 'user_info'
