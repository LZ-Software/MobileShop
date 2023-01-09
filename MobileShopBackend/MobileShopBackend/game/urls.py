from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^create$', views.CreateGame.as_view(), name='create-game'),
    urls.url(r'^delete$', views.DeleteGame.as_view(), name='delete-game'),
    urls.url(r'^edit$', views.EditGame.as_view(), name='edit-game'),
]
