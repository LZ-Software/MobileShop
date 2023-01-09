from rest_framework import serializers


class CreateGameSerializer(serializers.Serializer):

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

    publisher = serializers.CharField(
        max_length=128,
        required=True
    )

    dt_release = serializers.DateTimeField(
        required=True
    )

    image_base64 = serializers.CharField(
        required=True
    )

    genres = serializers.ListField(
        genre=serializers.CharField(
            max_length=128,
            required=True,
        )
    )
