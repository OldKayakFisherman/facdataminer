from dotenv import load_dotenv
import os
from abc import abstractmethod
from enum import Enum
from app.services.files import PathResolver

class EnvironmentType(Enum):
    DEV = 0
    TEST = 1
    PROD = 2


class BaseConfig:
    
    @property
    @abstractmethod
    def environment(self) -> EnvironmentType:
        """Returns the Config Environment"""

class DEVConfig(BaseConfig):
    
    @property
    @abstractmethod
    def environment(self) -> EnvironmentType:
        """Returns the Config Environment"""
        return EnvironmentType.DEV
    

class TESTConfig(BaseConfig):

    @property
    @abstractmethod
    def environment(self) -> EnvironmentType:
        """Returns the Config Environment"""
        return EnvironmentType.TEST

class PRODConfig(BaseConfig):

    @property
    @abstractmethod
    def environment(self) -> EnvironmentType:
        """Returns the Config Environment"""
        return EnvironmentType.PROD
    


def get_config():

    load_dotenv(PathResolver().get_environment_filepath(), override=True)

    working_env = os.getenv("RUNTIME.ENV") 

    if not working_env or working_env.upper() == "DEV":
        return DEVConfig()

    if working_env or working_env.upper() == "TEST":
        return TESTConfig()
    
    if working_env or working_env.upper() == "PROD":
        return PRODConfig()


