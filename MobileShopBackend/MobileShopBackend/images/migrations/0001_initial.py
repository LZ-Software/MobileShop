# Generated by Django 4.1.5 on 2023-01-08 21:00

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='ImageModel',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('image_base64', models.TextField()),
            ],
            options={
                'db_table': 'images',
            },
        ),
    ]
