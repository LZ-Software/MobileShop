from rest_framework import serializers


class GenreCreateSerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )


class GenreSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )

    name = serializers.CharField(
        max_length=128,
        required=True
    )


class GenreDeleteSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )
