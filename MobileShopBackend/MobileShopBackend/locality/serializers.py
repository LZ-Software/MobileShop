from rest_framework import serializers


class CountryCreateSerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )


class CountryEditSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )
    name = serializers.CharField(
        max_length=128,
        required=True
    )


class CountryDeleteSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )


class CitySerializer(serializers.Serializer):

    name = serializers.CharField(
        max_length=128,
        required=True
    )
    country = serializers.IntegerField(
        required=True
    )
