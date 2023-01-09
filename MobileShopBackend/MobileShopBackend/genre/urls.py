from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^get$', views.CreateGenre.as_view(), name='get-genres'),
    urls.url(r'^create$', views.CreateGenre.as_view(), name='create-genre'),
    urls.url(r'^edit$', views.EditGenre.as_view(), name='edit-genre'),
    urls.url(r'^delete$', views.DeleteGenre.as_view(), name='delete-genre'),
]
