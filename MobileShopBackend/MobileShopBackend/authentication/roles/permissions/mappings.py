"""
Information about permission mappings to roles
"""

from . import permissions


ADMIN_USER_ROLES_TO_ADD = {
    permissions.ADMIN_CREATE_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_CREATE_USER: 'user',
    permissions.ADMIN_CREATE_PUBLISHER: 'publisher',
}

ADMIN_USER_ROLES_TO_READ = {
    permissions.ADMIN_READ_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_READ_USER: 'user',
    permissions.ADMIN_READ_PUBLISHER: 'publisher',
}

ADMIN_USER_ROLES_TO_READ_PROFILE = {
    permissions.ADMIN_READ_ADMINISTRATOR_PROFILE: 'administrator',
    permissions.ADMIN_READ_USER_PROFILE: 'user',
    permissions.ADMIN_READ_PUBLISHER_PROFILE: 'publisher',
}

ADMIN_USER_ROLES_TO_UPDATE_PASSWORD = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_PASSWORD: 'administrator',
    permissions.ADMIN_UPDATE_USER_PASSWORD: 'user',
    permissions.ADMIN_UPDATE_PUBLISHER_PASSWORD: 'publisher',
}

ADMIN_USER_ROLES_TO_UPDATE_PROFILE = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_PROFILE: 'administrator',
    permissions.ADMIN_UPDATE_USER_PROFILE: 'user',
    permissions.ADMIN_UPDATE_PUBLISHER_PROFILE: 'publisher',
}

ADMIN_USER_ROLES_TO_UPDATE_ROLE = {
    permissions.ADMIN_UPDATE_ROLE_TO_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_UPDATE_ROLE_TO_USER: 'user',
    permissions.ADMIN_UPDATE_ROLE_TO_PUBLISHER: 'publisher',
}

ADMIN_USER_ROLES_TO_UPDATE_USERNAME = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_USERNAME: 'administrator',
    permissions.ADMIN_UPDATE_USER_USERNAME: 'user',
    permissions.ADMIN_UPDATE_PUBLISHER_USERNAME: 'publisher',
}
