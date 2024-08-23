import requests
from services.config import AppConfig
from datetime import datetime
import json

class GeneralAPIService:

    def get_general_by_date(self, config: AppConfig, target_date: datetime):

        route:str = f"{config.general_url_route}?date_created=eq.'{target_date}'"

        return requests.get(route, headers={"X-Api-Key": config.api_key})

    def get_first_injest_date(self, config: AppConfig):

        route:str = f"{config.general_url_route}?select=date_created&order=date_created.asc"

        response = requests.get(route, headers={"X-Api-Key": config.api_key})

        if response.ok:
            dates = response.json()
            return min(dates, key=lambda x: x["date_created"])['date_created']
        
    
