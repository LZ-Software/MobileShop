"""
Information about permission mappings to roles
"""

from . import permissions


ADMIN_USER_ROLES_TO_ADD = {
    permissions.ADMIN_CREATE_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_CREATE_USER: 'user',
}

ADMIN_USER_ROLES_TO_READ = {
    permissions.ADMIN_READ_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_READ_USER: 'user',
}

ADMIN_USER_ROLES_TO_READ_PROFILE = {
    permissions.ADMIN_READ_ADMINISTRATOR_PROFILE: 'administrator',
    permissions.ADMIN_READ_USER_PROFILE: 'user',
}

ADMIN_USER_ROLES_TO_UPDATE_PASSWORD = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_PASSWORD: 'administrator',
    permissions.ADMIN_UPDATE_USER_PASSWORD: 'user',
}

ADMIN_USER_ROLES_TO_UPDATE_PROFILE = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_PROFILE: 'administrator',
    permissions.ADMIN_UPDATE_USER_PROFILE: 'user',
}

ADMIN_USER_ROLES_TO_UPDATE_ROLE = {
    permissions.ADMIN_UPDATE_ROLE_TO_ADMINISTRATOR: 'administrator',
    permissions.ADMIN_UPDATE_ROLE_TO_USER: 'user',
}

ADMIN_USER_ROLES_TO_UPDATE_USERNAME = {
    permissions.ADMIN_UPDATE_ADMINISTRATOR_USERNAME: 'administrator',
    permissions.ADMIN_UPDATE_USER_USERNAME: 'user',
}
