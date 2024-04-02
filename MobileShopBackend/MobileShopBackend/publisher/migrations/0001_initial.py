# Generated by Django 2.2.28 on 2023-01-09 01:53

from django.conf import settings
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        migrations.swappable_dependency(settings.AUTH_USER_MODEL),
    ]

    operations = [
        migrations.CreateModel(
            name='Publisher',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=128, unique=True)),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, related_name='publishers', related_query_name='publisher', to=settings.AUTH_USER_MODEL)),
            ],
            options={
                'db_table': 'publisher',
            },
        ),
    ]
