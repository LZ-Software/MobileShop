from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^get$', views.CreateImage.as_view(), name='create-image'),
]
