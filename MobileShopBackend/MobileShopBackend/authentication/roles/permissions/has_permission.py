from rest_framework import request as rest_request
from rest_framework import permissions
from rest_framework import views as rest_views

from rolepermissions import checkers


class HasPermission(permissions.BasePermission, metaclass=permissions.BasePermissionMetaclass):
    def has_permission(
            self,
            request: rest_request.Request,
            view: rest_views.View,
    ) -> bool:

        user = request.user

        if (not user) or (not request.user.is_authenticated):
            return False

        for field_name in [
                'permission',
                f'permission_{ request.method.lower() }',
        ]:
            permission = getattr(view, field_name, None)
            if permission and (not checkers.has_permission(request.user, permission)):
                return False

        return True
