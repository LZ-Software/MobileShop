from rest_framework import serializers


class UserAuthorizeSerializer(serializers.Serializer):

    login = serializers.CharField(
        max_length=128,
        required=True
    )
    password = serializers.CharField(
        max_length=256,
        required=True
    )


class UserCreateSerializer(serializers.Serializer):

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
    city = serializers.CharField(
        max_length=128,
        required=True
    )


class UserEditSerializer(serializers.Serializer):

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
