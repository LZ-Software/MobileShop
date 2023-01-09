from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^register$', views.RegisterUser.as_view(), name='register-user'),
    urls.url(r'^edit$', views.EditUser.as_view(), name='register-user'),
]
