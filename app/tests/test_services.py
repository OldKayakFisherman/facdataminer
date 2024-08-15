import unittest
from app.services.config import DEVConfig, TESTConfig, PRODConfig, get_config, EnvironmentType
from app.services.files import PathResolver
from dotenv import set_key

class ConfigTests(unittest.TestCase):

    def test_dev_config(self):
        env_file = PathResolver().get_environment_filepath()
        set_key(env_file, "RUNTIME.ENV", "dev")
        eval_config = get_config()
        self.assertEqual(eval_config.environment, EnvironmentType.DEV)
        del eval_config
    
    def test_tst_config(self):
        env_file = PathResolver().get_environment_filepath()
        set_key(env_file, "RUNTIME.ENV", "test")
        eval_config = get_config()
        self.assertEqual(eval_config.environment, EnvironmentType.TEST)
        set_key(env_file, "RUNTIME.ENV", "dev")
        del eval_config