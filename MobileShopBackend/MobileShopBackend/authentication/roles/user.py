from django.utils import translation

from rolepermissions import roles

from . import common
from . import permissions


class User(roles.AbstractUserRole, common.Mixin):

    role_name = permissions.configuration.USER_NAME
    verbose_name = translation.pgettext_lazy('app_authentication', 'User')
    is_superuser = False

    available_permissions = permissions.configuration.USER_PERMISSIONS
