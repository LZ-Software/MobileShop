from abc import ABC

from rest_framework import serializers


class RegisterUserSerializer(serializers.Serializer, ABC):

    login = serializers.CharField(
        max_length=128,
        required=True
    )
    password = serializers.CharField(
        max_length=256,
        required=True
    )
    first_name = serializers.CharField(
        max_length=128,
        required=True
    )
    last_name = serializers.CharField(
        max_length=128,
        required=False
    )
    country = serializers.CharField(
        max_length=128,
        required=True
    )
    city = serializers.CharField(
        max_length=128,
        required=True
    )
