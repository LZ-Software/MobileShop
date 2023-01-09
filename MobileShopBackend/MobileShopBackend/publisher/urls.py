from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^get$', views.GetPublishers.as_view(), name='get-publishers'),
    urls.url(r'^create$', views.CreatePublisher.as_view(), name='create-publisher'),
    urls.url(r'^edit$', views.EditPublisher.as_view(), name='edit-publisher'),
    urls.url(r'^delete$', views.DeletePublisher.as_view(), name='delete-publisher'),
]
