from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^create$', views.CreateGenre.as_view(), name='set-genre'),
]
