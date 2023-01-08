from django.utils import translation

from rolepermissions import roles

from . import common
from . import permissions


class Publisher(roles.AbstractUserRole, common.Mixin):

    role_name = permissions.configuration.PUBLISHER_NAME
    verbose_name = translation.pgettext_lazy('app_authentication', 'Publisher')
    is_superuser = True

    available_permissions = permissions.configuration.USER_PERMISSIONS
