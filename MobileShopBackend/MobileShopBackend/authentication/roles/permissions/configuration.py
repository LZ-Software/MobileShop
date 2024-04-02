"""
Information about permission availability for different roles
"""

from . import permissions


ADMINISTRATOR_NAME = 'administrator'
ADMINISTRATOR_PERMISSIONS = {
    permissions.ADMIN_ACCESS: True,
    permissions.ADMIN_AUTHENTICATION_ACCESS: True,
    permissions.ADMIN_IMAGES_ACCESS: True,
    permissions.ADMIN_IMAGES_CREATE: True,
    permissions.ADMIN_IMAGES_DELETE: True,
    permissions.ADMIN_IMAGES_READ: True,
    permissions.ADMIN_IMAGES_UPDATE: True,
    permissions.ADMIN_USER_LOGIN_ACCESS: True,
    permissions.ADMIN_USER_LOGIN_CREATE: True,
    permissions.ADMIN_USER_LOGIN_DELETE: True,
    permissions.ADMIN_USER_LOGIN_READ: True,
    permissions.ADMIN_USER_LOGIN_UPDATE: True,
    permissions.ADMIN_USER_INFO_ACCESS: True,
    permissions.ADMIN_USER_INFO_CREATE: True,
    permissions.ADMIN_USER_INFO_DELETE: True,
    permissions.ADMIN_USER_INFO_READ: True,
    permissions.ADMIN_USER_INFO_UPDATE: True,
    permissions.ADMIN_ROLE_ACCESS: True,
    permissions.ADMIN_ROLE_CREATE: True,
    permissions.ADMIN_ROLE_DELETE: True,
    permissions.ADMIN_ROLE_READ: True,
    permissions.ADMIN_ROLE_UPDATE: True,
    permissions.ADMIN_USER_ROLE_ACCESS: True,
    permissions.ADMIN_USER_ROLE_CREATE: True,
    permissions.ADMIN_USER_ROLE_READ: True,
    permissions.ADMIN_USER_ROLE_UPDATE: True,
    permissions.ADMIN_PUBLISHER_ACCESS: True,
    permissions.ADMIN_PUBLISHER_CREATE: True,
    permissions.ADMIN_PUBLISHER_DELETE: True,
    permissions.ADMIN_PUBLISHER_READ: True,
    permissions.ADMIN_PUBLISHER_UPDATE: True,
    permissions.ADMIN_GENRE_ACCESS: True,
    permissions.ADMIN_GENRE_CREATE: True,
    permissions.ADMIN_GENRE_DELETE: True,
    permissions.ADMIN_GENRE_READ: True,
    permissions.ADMIN_GENRE_UPDATE: True,
    permissions.ADMIN_GAME_ACCESS: True,
    permissions.ADMIN_GAME_CREATE: True,
    permissions.ADMIN_GAME_DELETE: True,
    permissions.ADMIN_GAME_READ: True,
    permissions.ADMIN_GAME_UPDATE: True,
    permissions.ADMIN_GAME_GENRE_ACCESS: True,
    permissions.ADMIN_GAME_GENRE_CREATE: True,
    permissions.ADMIN_GAME_GENRE_DELETE: True,
    permissions.ADMIN_GAME_GENRE_READ: True,
    permissions.ADMIN_GAME_GENRE_UPDATE: True,
    permissions.ADMIN_GAME_PURCHASE_ACCESS: True,
    permissions.ADMIN_GAME_PURCHASE_CREATE: True,
    permissions.ADMIN_GAME_PURCHASE_DELETE: True,
    permissions.ADMIN_GAME_PURCHASE_READ: True,
    permissions.ADMIN_GAME_PURCHASE_UPDATE: True,
    permissions.ADMIN_USER_LIBRARY_ACCESS: True,
    permissions.ADMIN_USER_LIBRARY_CREATE: True,
    permissions.ADMIN_USER_LIBRARY_DELETE: True,
    permissions.ADMIN_USER_LIBRARY_READ: True,
    permissions.ADMIN_USER_LIBRARY_UPDATE: True,
}

USER_NAME = 'user'
USER_PERMISSIONS = {
    permissions.USER_ACCESS: True,
    permissions.USER_AUTHENTICATION_ACCESS: True,
    permissions.USER_IMAGES_CREATE: True,
    permissions.USER_IMAGES_READ: True,
    permissions.USER_IMAGES_UPDATE: True,
    permissions.USER_USER_LOGIN_ACCESS: True,
    permissions.USER_USER_LOGIN_READ: True,
    permissions.USER_USER_LOGIN_UPDATE: True,
    permissions.USER_USER_INFO_ACCESS: True,
    permissions.USER_USER_INFO_READ: True,
    permissions.USER_USER_INFO_UPDATE: True,
    permissions.USER_USER_LIBRARY_ACCESS: True,
    permissions.USER_USER_LIBRARY_CREATE: True,
    permissions.USER_USER_LIBRARY_READ: True,
    permissions.USER_ROLE_ACCESS: True,
    permissions.USER_ROLE_READ: True,
    permissions.USER_GAME_ACCESS: True,
    permissions.USER_GAME_READ: True,
    permissions.USER_PUBLISHER_ACCESS: True,
    permissions.USER_PUBLISHER_READ: True,
    permissions.USER_GENRE_ACCESS: True,
    permissions.USER_GENRE_READ: True,
    permissions.USER_GAME_GENRE_ACCESS: True,
    permissions.USER_GAME_GENRE_READ: True,
    permissions.USER_GAME_PURCHASE_ACCESS: True,
    permissions.USER_GAME_PURCHASE_CREATE: True,
    permissions.USER_GAME_PURCHASE_READ: True,
}
