from rest_framework import serializers


class PublisherCreateSerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )

    country = serializers.IntegerField(
        required=True
    )

    user = serializers.IntegerField(
        required=True
    )


class PublisherEditSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )

    name = serializers.CharField(
        max_length=128,
        required=True
    )

    country = serializers.IntegerField(
        required=True
    )

    user = serializers.IntegerField(
        required=True
    )


class PublisherDeleteSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )
