from rest_framework import serializers


class GenreSerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )
