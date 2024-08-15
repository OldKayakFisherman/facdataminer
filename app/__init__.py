from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from app.database.models import Base

db: SQLAlchemy = SQLAlchemy()



def create_app(config_name):
    app = Flask(__name__)

    db.init_app(app)