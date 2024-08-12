from pathlib import Path
import os


class PathResolver:

    def get_current_directory(self, file):
        return os.path.dirname(os.path.realpath(file))

    def get_parent_directory(self, file):
        return Path(os.path.dirname(os.path.realpath(file))).parent

    def get_environment_filepath(self):

        app_dir = self.get_parent_directory(__file__)
        root_dir = Path(os.path.dirname(app_dir))

        return os.path.join(root_dir, ".env")