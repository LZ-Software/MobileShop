# Generated by Django 2.2.28 on 2023-01-09 01:04

from django.conf import settings
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('genre', '0001_initial'),
        migrations.swappable_dependency(settings.AUTH_USER_MODEL),
        ('images', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Game',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=128, unique=True)),
                ('description', models.CharField(max_length=2048)),
                ('price', models.FloatField()),
                ('dt_release', models.DateTimeField()),
                ('image', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='games', related_query_name='game', to='images.ImageModel')),
            ],
            options={
                'db_table': 'game',
            },
        ),
        migrations.CreateModel(
            name='Library',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('game', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='libraries', related_query_name='library', to='game.Game')),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='libraries', related_query_name='library', to=settings.AUTH_USER_MODEL)),
            ],
            options={
                'db_table': 'user_library',
            },
        ),
        migrations.CreateModel(
            name='GamePurchase',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('time', models.DateTimeField(auto_now_add=True)),
                ('game', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='purchases', related_query_name='purchase', to='game.Game')),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='purchases', related_query_name='purchase', to=settings.AUTH_USER_MODEL)),
            ],
            options={
                'db_table': 'game_purchase',
            },
        ),
        migrations.CreateModel(
            name='GameGenre',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('game', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='game_genres', related_query_name='game_genre', to='game.Game')),
                ('genre', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='game_genres', related_query_name='game_genre', to='genre.Genre')),
            ],
            options={
                'db_table': 'game_genre',
            },
        ),
    ]
