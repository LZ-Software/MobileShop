# Generated by Django 2.2.28 on 2023-01-09 01:53

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
                ('image_base64', models.TextField(default='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')),
            ],
            options={
                'db_table': 'images',
            },
        ),
    ]
