# Generated by Django 2.2.28 on 2023-01-09 00:42

from django.conf import settings
from django.db import migrations, models
import django.db.models.deletion
import django.utils.timezone


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('auth', '0011_update_proxy_permissions'),
        ('images', '0001_initial'),
        ('locality', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='User',
            fields=[
                ('last_login', models.DateTimeField(blank=True, null=True, verbose_name='last login')),
                ('first_name', models.CharField(blank=True, max_length=30, verbose_name='first name')),
                ('last_name', models.CharField(blank=True, max_length=150, verbose_name='last name')),
                ('email', models.EmailField(blank=True, max_length=254, verbose_name='email address')),
                ('is_active', models.BooleanField(default=True, help_text='Designates whether this user should be treated as active. Unselect this instead of deleting accounts.', verbose_name='active')),
                ('date_joined', models.DateTimeField(default=django.utils.timezone.now, verbose_name='date joined')),
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('username', models.CharField(max_length=128, unique=True)),
                ('password', models.CharField(max_length=256)),
                ('groups', models.ManyToManyField(blank=True, help_text='The groups this user belongs to. A user will get all permissions granted to each of their groups.', related_name='user_set', related_query_name='user', to='auth.Group', verbose_name='groups')),
                ('user_permissions', models.ManyToManyField(blank=True, help_text='Specific permissions for this user.', related_name='user_set', related_query_name='user', to='auth.Permission', verbose_name='user permissions')),
            ],
            options={
                'db_table': 'user_login',
            },
        ),
        migrations.CreateModel(
            name='Profile',
            fields=[
                ('password', models.CharField(max_length=128, verbose_name='password')),
                ('last_login', models.DateTimeField(blank=True, null=True, verbose_name='last login')),
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('first_name', models.CharField(max_length=128)),
                ('last_name', models.CharField(max_length=128, null=True)),
                ('city', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='cities', related_query_name='city', to='locality.City')),
                ('image', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='images', related_query_name='image', to='images.ImageModel')),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='profiles', related_query_name='profile', to=settings.AUTH_USER_MODEL)),
            ],
            options={
                'db_table': 'user_info',
            },
        ),
    ]
