"""
Commonly used functions
"""

__all__ = [
    'get_available_roles',
    'get_verbose_roles',
    'check_permissions',
    'check_permissions_mapping'
]

import typing

from rolepermissions import roles
from rolepermissions import checkers


if typing.TYPE_CHECKING:
    pass


def get_available_roles(
        collection: typing.Dict[str, str],
        user: 'models.User',
) -> typing.Tuple[str, ...]:
    """
    Retrieve list of roles, that are available to user

    :param collection: Description of the permission mapping
    :param user: User to check availability for
    :return: Collection of available roles
    """

    result = ()

    for permission, role in collection.items():
        if checkers.has_permission(user, permission):
            result += (
                role,
            )

    return result


def get_verbose_roles(
        collection: typing.Dict[str, str],
        user: 'models.User',
) -> typing.Tuple[typing.Tuple[str, str], ...]:
    """
    Convert permission mapping to verbose list of roles, that are available to user

    :param collection: Description of the permission mapping
    :param user: User to check availability for
    :return: Verbose collection of available roles
    """

    result = ()

    for permission, role in collection.items():
        if checkers.has_permission(user, permission):
            role = roles.retrieve_role(role)
            result += (
                (role.get_name(), role.verbose_name),
            )

    return result


def check_permissions(
        collection: typing.Iterable[str],
        user: 'models.User',
) -> bool:
    """
    Check if user has at least one permission from list

    :param collection: List of permissions to check
    :param user: User to check permissions for
    :return: Check result
    """

    for permission in collection:
        if checkers.has_permission(user, permission):
            return True

    return False


def check_permissions_mapping(
        collection: typing.Dict[str, str],
        user: 'models.User',
        target: 'models.User',
) -> bool:
    """
    Check if user has access to another user instance by permission mapping

    :param collection: Description of the permission mapping
    :param user: User to check permissions for
    :param target: Target user to check (if it is accessible by "user")
    :return: Check result
    """

    target_roles = {
        role.get_name()
        for role in roles.get_user_roles(target)
    }

    for permission, role in collection.items():
        if role not in target_roles:
            continue

        if checkers.has_permission(user, permission):
            return True

    return False
