from abc import ABC

from rest_framework import serializers


class RegisterUserSerializer(serializers.Serializer):

    username = serializers.CharField(
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
    city = serializers.CharField(
        max_length=128,
        required=True
    )
