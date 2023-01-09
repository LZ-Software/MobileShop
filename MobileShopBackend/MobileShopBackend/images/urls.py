from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^create$', views.CreateImage.as_view(), name='create-image'),
]
