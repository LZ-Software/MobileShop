from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^country$', views.GetCountries.as_view(), name='get-countries'),
    urls.url(r'^country/create$', views.AddCountry.as_view(), name='create-country'),
    urls.url(r'^country/edit$', views.EditCountry.as_view(), name='edit-country'),
    urls.url(r'^country/delete$', views.DeleteCountry.as_view(), name='delete-country'),
    urls.url(r'^city$', views.GetCities.as_view(), name='get-cities'),
    urls.url(r'^city/create$', views.AddCity.as_view(), name='create-city'),
    urls.url(r'^city/edit$', views.EditCity.as_view(), name='edit-city'),
    urls.url(r'^city/delete$', views.DeleteCity.as_view(), name='delete-city'),
]
