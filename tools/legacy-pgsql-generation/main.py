#https://jinja.palletsprojects.com/en/3.1.x/api/#basics

from jinja2 import Environment, PackageLoader, select_autoescape
from dotenv import load_dotenv
import os
import json

env = Environment(
    loader=PackageLoader("main"),
    autoescape=select_autoescape()
)

load_dotenv()

JSON_DIR = os.getenv("JSON.DIR")
BASE_SQL_DIR = os.getenv("BASE.SQL.DIR")


LAST_CENSUS_COLLECTION_YEAR = 2022

def generate_cfda_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'cfda.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:


        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_cfdas.sql.jinja")
                    sql_statements.append(template.render(record))

            sql_file = os.path.join(BASE_SQL_DIR, "cfdas" ,f'{i}_cfda_inserts.sql')

            if os.path.exists(sql_file):
                os.remove(sql_file)

            with open(sql_file, 'w') as f:
                f.writelines(sql_statements)
                
def generate_general_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'general.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_general.sql.jinja")
                    sql_statements.append(template.render(record))

            sql_file = os.path.join(BASE_SQL_DIR, "general" ,f'{i}_cfda_inserts.sql')

            if os.path.exists(sql_file):
                os.remove(sql_file)

            with open(sql_file, 'w') as f:
                f.writelines(sql_statements)
                    
def generate_agency_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'agency.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_agencies.sql.jinja")
                    sql_statements.append(template.render(record))

            sql_file = os.path.join(BASE_SQL_DIR, "agencies" ,f'{i}_agency_inserts.sql')

            if os.path.exists(sql_file):
                os.remove(sql_file)

            with open(sql_file, 'w') as f:
                f.writelines(sql_statements)
           


def generate_captext_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'captext.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_captext.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "captext" ,f'{i}_captext_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)
           
def generate_cpa_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'cpas.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_cpas.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "cpas" ,f'{i}_cpas_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)
           
def generate_duns_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'duns.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_duns.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "duns" ,f'{i}_duns_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_eins_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'eins.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_eins.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "eins" ,f'{i}_eins_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_findings_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'findings.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_findings.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "findings" ,f'{i}_findings_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_findingstext_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'findingstext.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_findingstext.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "findingstext" ,f'{i}_findingstext_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_notes_statements():

    records = None
    
    with open(os.path.join(JSON_DIR, 'notes.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_notes.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "notes" ,f'{i}_notes_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_passthroughs():

    records = None
    
    with open(os.path.join(JSON_DIR, 'passthrough.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_passthroughs.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "passthrough" ,f'{i}_passthrough_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

if __name__ == "__main__":
    #generate_cfda_statements()
    #generate_general_statements()
    #generate_agency_statements()
    #generate_captext_statements()
    #generate_cpa_statements()
    #generate_duns_statements()
    #generate_eins_statements()
    #generate_findings_statements()
    #generate_findingstext_statements()
    #generate_notes_statements()
    generate_passthroughs()