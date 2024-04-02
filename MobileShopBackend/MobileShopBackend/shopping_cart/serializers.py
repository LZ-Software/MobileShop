from rest_framework import serializers

from MobileShopBackend.game import models as game_models


class ShoppingCartSerializer(serializers.Serializer):

    id = serializers.IntegerField(
        required=True
    )

    def validate_id(self, value):
        try:
            game_models.Game.objects.get(id=value)
        except game_models.Game.DoesNotExist:
            raise serializers.ValidationError("Game does not exist")
        return value
