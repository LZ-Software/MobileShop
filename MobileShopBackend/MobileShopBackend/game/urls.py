from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^game/create$', views.CreateGame.as_view(), name='create-game'),
]
