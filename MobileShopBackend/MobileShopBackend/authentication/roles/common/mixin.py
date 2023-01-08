"""
Description of the roles Mixin class
"""

__all__ = [
    'Mixin',
]


class Mixin:
    """
    Mixin with common information for roles
    """

    is_superuser = False

    @property
    def verbose_name(self):
        """
        :return: Name to display
        """

        return self.get_name()
