from django.contrib import admin

from .models import Game, GameGenre, GamePurchase, Library

# Register your models here.
admin.site.register(Game)
admin.site.register(GameGenre)
admin.site.register(GamePurchase)
admin.site.register(Library)
