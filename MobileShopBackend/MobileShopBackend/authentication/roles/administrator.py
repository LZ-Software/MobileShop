from django.utils import translation

from rolepermissions import roles

from . import common
from . import permissions


class Administrator(roles.AbstractUserRole, common.Mixin):

    role_name = permissions.configuration.ADMINISTRATOR_NAME
    verbose_name = translation.pgettext_lazy('app_authentication', 'Administrator')
    is_superuser = True

    available_permissions = permissions.configuration.ADMINISTRATOR_PERMISSIONS
