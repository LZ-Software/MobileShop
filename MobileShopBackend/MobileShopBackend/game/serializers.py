from rest_framework import serializers


class GameCreateSerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )
    description = serializers.CharField(
        max_length=2048,
        required=True
    )
    price = serializers.FloatField(
        required=True
    )
    publisher = serializers.IntegerField(
        required=True
    )
    dt_release = serializers.DateTimeField(
        required=True
    )
    image_base64 = serializers.CharField(
        required=True
    )
    genres = serializers.ListField(
        child=serializers.IntegerField(
            required=True,
        )
    )


class GameDeleteSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )


class GameEditSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )
    name = serializers.CharField(
        max_length=128,
        required=True
    )
    description = serializers.CharField(
        max_length=2048,
        required=True
    )
    price = serializers.FloatField(
        required=True
    )
    publisher = serializers.IntegerField(
        required=True
    )
    dt_release = serializers.DateTimeField(
        required=True
    )
    image_base64 = serializers.CharField(
        required=True
    )
    genres = serializers.ListField(
        child=serializers.IntegerField(
            required=True,
        )
    )
