from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^game/create$', views.CreateGame.as_view(), name='create-game'),
    urls.url(r'^game/delete$', views.DeleteGame.as_view(), name='delete-game'),
]
