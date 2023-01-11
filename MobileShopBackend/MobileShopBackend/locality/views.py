from django.contrib import auth
from rest_framework import views
from rest_framework import request as rest_request
from rest_framework import response as rest_response
from rest_framework import status as rest_status

from . import serializers as locality_serializers

from MobileShopBackend.authentication.roles import permissions
from MobileShopBackend.authentication.roles.permissions import has_permission

from MobileShopBackend.locality import models as locality_models

USER = auth.get_user_model()


class AddCountry(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_COUNTRY_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CountryCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        country = locality_models.Country.objects.create(**data)

        return rest_response.Response(
            data={
                'country': country.pk,
            },
            status=rest_status.HTTP_200_OK,
        )


class EditCountry(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_COUNTRY_UPDATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CountryEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        country = locality_models.Country.objects.get(id=data['id'])
        country.name = data['name']
        country.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class DeleteCountry(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_COUNTRY_DELETE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CountryDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        country = locality_models.Country.objects.get(id=data['id'])
        country.delete()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetCountries(views.APIView):

    http_method_names = ['get']

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        return rest_response.Response(
            locality_models.Country.objects.values(),
            status=rest_status.HTTP_200_OK,
        )


class AddCity(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_CITY_CREATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CityCreateSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        country = locality_models.City.objects.create(**data)

        return rest_response.Response(
            data={
                'city': country.pk,
            },
            status=rest_status.HTTP_200_OK,
        )


class EditCity(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_CITY_UPDATE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CityEditSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        city = locality_models.City.objects.get(id=data['id'])
        city.name = data['name']
        city.country = data['country']
        city.save()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class DeleteCity(views.APIView):

    http_method_names = ['post']

    permission_classes = [has_permission.HasPermission]
    permission = permissions.ADMIN_CITY_DELETE

    @staticmethod
    def post(request: rest_request.Request) -> rest_response.Response:

        serializer = locality_serializers.CityDeleteSerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        data = serializer.validated_data

        city = locality_models.City.objects.get(id=data['id'])
        city.delete()

        return rest_response.Response(
            data={
                'success': True,
            },
            status=rest_status.HTTP_200_OK,
        )


class GetCities(views.APIView):

    http_method_names = ['get']

    @staticmethod
    def get(request: rest_request.Request) -> rest_response.Response:

        return rest_response.Response(
            locality_models.City.objects.values(),
            status=rest_status.HTTP_200_OK,
        )
