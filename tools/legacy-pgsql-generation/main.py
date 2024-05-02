#https://jinja.palletsprojects.com/en/3.1.x/api/#basics

from jinja2 import Environment, PackageLoader, select_autoescape
from dotenv import load_dotenv
import os
import json
import psycopg2


env = Environment(
    loader=PackageLoader("main"),
    autoescape=select_autoescape()
)

load_dotenv()

JSON_DIR = os.getenv("JSON.DIR")
BASE_SQL_DIR = os.getenv("BASE.SQL.DIR")


LAST_CENSUS_COLLECTION_YEAR = 2022


def correct_cfda_data_oddities(record):

    if record['LOANBALANCE'] == 'N/A':
        record['LOANBALANCE'] = 0

    #special case for eleaudits id 26290134
    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290134:
            record['AWARDIDENTIFICATION'] = 'TITLE I – HOMELESS CHILDREN & YOUTH'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'EDUCATION FOR HOMELESS CHILDREN AND YOUTH'
            record['AMOUNT'] = 18795
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 60568
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290134
            

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290136:
            record['AWARDIDENTIFICATION'] = 'TITLE I – HOMELESS CHILDREN & YOUTH'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'EDUCATION FOR HOMELESS CHILDREN AND YOUTH'
            record['AMOUNT'] = 41773
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 60568
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290136

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290141:
            record['AWARDIDENTIFICATION'] = 'VOCATIONAL EDUCATION BASIC'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'CAREER AND TECHNICAL EDUCATION -- BASIC GRANTS TO STATES'
            record['AMOUNT'] = 2974
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 64204
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290141

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290145:
            record['AWARDIDENTIFICATION'] = 'VOCATIONAL EDUCATION BASIC'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'CAREER AND TECHNICAL EDUCATION -- BASIC GRANTS TO STATES'
            record['AMOUNT'] = 2520
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 64204
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290145

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290147:
            record['AWARDIDENTIFICATION'] = 'VOCATIONAL EDUCATION BASIC'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'CAREER AND TECHNICAL EDUCATION -- BASIC GRANTS TO STATES'
            record['AMOUNT'] = 58710
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 64204
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290147
    
    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290153:
            record['AWARDIDENTIFICATION'] = 'TITLE IV-RURAL/LOW INCOME'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'RURAL EDUCATION'
            record['AMOUNT'] = 64007
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 189107
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290153       

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290155:
            record['AWARDIDENTIFICATION'] = 'TITLE IV-RURAL/LOW INCOME'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'RURAL EDUCATION'
            record['AMOUNT'] = 125100
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 189107
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290155       

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290159:
            record['AWARDIDENTIFICATION'] = 'IMPROVING TEACHER QUALITY'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'IMPROVING TEACHER QUALITY STATE GRANTS'
            record['AMOUNT'] = 35665
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 715154
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290159       

    if int(record['DBKEY']) == 146578 and int(record['AUDITYEAR']) == 2016 and \
        int(record['LOANBALANCE']) == 26290163:
            record['AWARDIDENTIFICATION'] = 'IMPROVING TEACHER QUALITY'
            record['RD'] = ''
            record['FEDERALPROGRAMNAME'] = 'IMPROVING TEACHER QUALITY STATE GRANTS'
            record['AMOUNT'] = 679489
            record['CLUSTERNAME'] = 'N/A'
            record['STATECLUSTERNAME'] = ''
            record['PROGRAMTOTAL'] = 715154
            record['CLUSTERTOTAL'] = ''
            record['DIRECT'] = 'N'
            record['PASSTHROUGHAWARD'] = 'N'
            record['PASSTHROUGHAMOUNT'] = 0
            record['MAJORPROGRAM'] = 'N'
            record['TYPEREPORT_MP'] = ''
            record['TYPEREQUIREMENT'] = '' 
            record['QCOSTS2'] = ''
            record['FINDINGS'] = ''
            record['FINDINGREFNUMS'] = ''
            record['ARRA'] = ''
            record['LOANS'] = 'N'
            record['LOANBALANCE'] = 0
            record['FINDINGSCOUNT'] = 0
            record['ELECAUDITSID'] = 26290163      


    return record

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
                    record = correct_cfda_data_oddities(record)
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

def generate_revisions():

    records = None
    
    with open(os.path.join(JSON_DIR, 'revisions.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_revisions.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "revisions" ,f'{i}_revisions_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def generate_ueis():

    records = None
    
    with open(os.path.join(JSON_DIR, 'ueis.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        for i in range(1997, 2023):
            
            filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == i]

            sql_statements = []

            if filtered_records:

                for record in filtered_records:
                    template = env.get_template("insert_into_ueis.sql.jinja")
                    sql_statements.append(template.render(record))

                sql_file = os.path.join(BASE_SQL_DIR, "ueis" ,f'{i}_ueis_inserts.sql')

                if os.path.exists(sql_file):
                    os.remove(sql_file)

                with open(sql_file, 'w') as f:
                    f.writelines(sql_statements)

def check_cfda_statements(year: int):

    records = None
    
    with open(os.path.join(JSON_DIR, 'cfda.json')) as f:
        content = f.read()
        records = json.loads(content)
    
    if records:

        filtered_records = [x for x in records if int(str(x['AUDITYEAR']).strip()) == year]

        sql_statements = []

        if filtered_records:

            for record in filtered_records:
                template = env.get_template("insert_into_cfdas.sql.jinja")
                record = correct_cfda_data_oddities(record)
                sql_statements.append(template.render(record))


        dsn = f"""
            dbname={os.getenv("DB.NAME")} 
            user={os.getenv("DB.USER")} 
            password={os.getenv("DB.PASSWORD")} 
            host={os.getenv("DB.HOST")} 
            port={os.getenv("DB.PORT")}
        """

        cn = psycopg2.connect(dsn)
        cn.autocommit = False

        statement_count = len(sql_statements)
        statement_counter = 1

        for sql_statement in sql_statements:

            print(f"Analyzing statement { statement_counter} of {statement_count}")

            with cn.cursor() as cur:

                try:
                    cur.execute(sql_statement)
                except psycopg2.Error as e:
                    print(e)
                    print(sql_statement)
                    return
               
       
            statement_counter = statement_counter + 1



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
    #generate_passthroughs()
    #generate_revisions()
    #generate_ueis()
    check_cfda_statements(2016)
