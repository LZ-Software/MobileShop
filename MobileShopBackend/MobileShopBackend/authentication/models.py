from django.contrib.auth import models as auth_models
from django.db import models, transaction

from rolepermissions import checkers as rolepermissions_checkers

from MobileShopBackend.authentication import roles
from MobileShopBackend.locality import models as locality_models
from MobileShopBackend.images import models as image_models

import typing


class UserQuerySet(models.QuerySet):
    """ QuerySet for User model """

    def get(self, *args, **kwargs):
        return super().get(*args, **kwargs)

    def filter(self, *args, **kwargs):
        filtered_kwargs = {}
        for key in kwargs:
            filtered_kwargs[key] = kwargs[key]

        return super().filter(*args, **filtered_kwargs)

    def employees(self):
        """remain only employees"""
        return self.filter(groups__name__in=['administrator'])


class SelfUserManager(auth_models.BaseUserManager):
    """ Manager for user model """

    def get_queryset(self) -> 'UserQuerySet':
        """ Get initial queryset """
        return UserQuerySet(self.model, using=self.db)

    @transaction.atomic
    def create_user(
            self,
            login: typing.Optional[str],
            password: typing.Optional[str],
            first_name: typing.Optional[str],
            last_name: typing.Optional[str],
            city: typing.Optional[str],
            image_base64: typing.Optional[str] = None,
            role: typing.Optional[typing.Union[typing.Type[roles.AbstractUserRole], str]] = roles.User,
    ) -> 'User':

        user = self.model()

        user.username = login

        if password is not None:
            user.set_password(raw_password=password)

        user.save()

        if role is not None:
            roles.assign_role(user, role)

        if image_base64 is None:
            image = image_models.ImageModel.objects.create()
        else:
            image = image_models.ImageModel.objects.create(image_base64=image_base64)

        city = locality_models.City.objects.get(name=city)

        profile = Profile.objects.create(user=user,
                                         first_name=first_name,
                                         last_name=last_name,
                                         city_id=city.pk,
                                         image_id=image.pk)
        profile.save()

        return user

    def create_superuser(
            self,
            username: str,
            password: str,
    ) -> 'User':

        result = self.create_user(
            username=username,
            password=password,
            role=roles.Administrator,
            first_name='admin',
            last_name='admin',
            city='Moscow',
        )

        return result

    def employees(self):
        """remain only employees"""
        return self.get_queryset().employees()


class User(auth_models.AbstractBaseUser, auth_models.PermissionsMixin):

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

    USERNAME_FIELD = 'username'

    objects = SelfUserManager()

    class Meta:
        db_table = 'user_login'

    def __str__(self):
        return str(self.username)

    @property
    def is_superuser(self) -> bool:
        return any(
            role.is_superuser
            for role in roles.get_user_roles(self)
        )

    @property
    def is_staff(self) -> bool:
        return rolepermissions_checkers.has_permission(
            self,
            roles.permissions.ADMIN_ACCESS,
        )

    def get_role_name(self) -> str:
        return ', '.join(
            str(role.verbose_name)
            for role in roles.get_user_roles(self)
        )


class Profile(auth_models.AbstractBaseUser):

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
        to=image_models.ImageModel,
        related_name='profiles',
        related_query_name='profile',
        on_delete=models.DO_NOTHING,
    )

    EXCLUDE_FIELDS = ['pk']
    FILTER_FIELDS = ['user_id']

    class Meta:
        db_table = 'user_info'
