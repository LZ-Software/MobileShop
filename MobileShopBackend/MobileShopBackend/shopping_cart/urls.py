from django.conf import urls

from . import views

urlpatterns = [
    urls.url(r'^get$', views.GetShoppingCart.as_view(), name='shopping-cart'),
    urls.url(r'^add$', views.AddToShoppingCart.as_view(), name='add-shopping-cart'),
    urls.url(r'^pop$', views.PopFromShoppingCart.as_view(), name='pop-shopping-cart'),
    urls.url(r'^purchase$', views.Purchase.as_view(), name='purchase-shopping-cart'),
]
