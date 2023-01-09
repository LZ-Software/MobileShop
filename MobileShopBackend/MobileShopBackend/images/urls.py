from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^set_image$', views.SetImage.as_view(), name='set-image'),
]