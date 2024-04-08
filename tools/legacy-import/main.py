from dotenv import load_dotenv
import os, sys
import csv
import json
import logging


logging.basicConfig(level=logging.INFO)

load_dotenv()

SOURCE_PATH = os.getenv("SOURCE.PATH")
OUTPUT_PATH = os.getenv("OUTPUT.PATH")


JSON_AGENCY_FILE = os.path.join(OUTPUT_PATH, "agency.json")
JSON_CAPTEXT_FILE = os.path.join(OUTPUT_PATH, "captext.json")
JSON_CFDA_FILE = os.path.join(OUTPUT_PATH, "cfda.json")
JSON_CPA_FILE = os.path.join(OUTPUT_PATH, "cpas.json")
JSON_DUNS_FILE = os.path.join(OUTPUT_PATH, "duns.json")
JSON_EINS_FILE = os.path.join(OUTPUT_PATH, "eins.json")
JSON_FINDINGS_FILE = os.path.join(OUTPUT_PATH, "findings.json")
JSON_FINDINGSTEXT_FILE = os.path.join(OUTPUT_PATH, "findingstext.json")
JSON_GENERAL_FILE = os.path.join(OUTPUT_PATH, "general.json")
JSON_NOTES_FILE = os.path.join(OUTPUT_PATH, "notes.json")
JSON_PASSTHROUGH_FILE = os.path.join(OUTPUT_PATH, "passthrough.json")
JSON_REVISION_FILE = os.path.join(OUTPUT_PATH, "revisions.json")
JSON_UEIS_FILE = os.path.join(OUTPUT_PATH, "ueis.json")

CSV_AGENCY_FILE = os.path.join(SOURCE_PATH, "agency.csv")
CSV_CAPTEXT_FILE = os.path.join(SOURCE_PATH, "captext.csv")
CSV_CFDA_FILE = os.path.join(SOURCE_PATH, "cfda.csv")
CSV_CPA_FILE = os.path.join(SOURCE_PATH, "cpas.csv")
CSV_DUNS_FILE = os.path.join(SOURCE_PATH, "duns.csv")
CSV_EINS_FILE = os.path.join(SOURCE_PATH, "eins.csv")
CSV_FINDINGS_FILE = os.path.join(SOURCE_PATH, "findings.csv")
CSV_FINDINGSTEXT_FILE = os.path.join(SOURCE_PATH, "findingstext.csv")
CSV_GENERAL_FILE = os.path.join(SOURCE_PATH, "general.csv")
CSV_NOTES_FILE = os.path.join(SOURCE_PATH, "notes.csv")
CSV_PASSTHROUGH_FILE = os.path.join(SOURCE_PATH, "passthrough.csv")
CSV_REVISION_FILE = os.path.join(SOURCE_PATH, "revisions.csv")
CSV_UEIS_FILE = os.path.join(SOURCE_PATH, "ueis.csv")


#set the CSV max size
csv.field_size_limit(sys.maxsize)

def clean_json_files():

    if os.path.exists(JSON_AGENCY_FILE):
        os.remove(JSON_AGENCY_FILE)
    
    if os.path.exists(JSON_CAPTEXT_FILE):
        os.remove(JSON_CAPTEXT_FILE)

    if os.path.exists(JSON_CPA_FILE):
        os.remove(JSON_CPA_FILE)

    if os.path.exists(JSON_DUNS_FILE):
        os.remove(JSON_DUNS_FILE)

    if os.path.exists(JSON_EINS_FILE):
        os.remove(JSON_EINS_FILE)

    if os.path.exists(JSON_FINDINGS_FILE):
        os.remove(JSON_FINDINGS_FILE)

    if os.path.exists(JSON_FINDINGSTEXT_FILE):
        os.remove(JSON_FINDINGSTEXT_FILE)

    if os.path.exists(CSV_NOTES_FILE):
        os.remove(CSV_NOTES_FILE)

    if os.path.exists(JSON_PASSTHROUGH_FILE):
        os.remove(JSON_PASSTHROUGH_FILE)

    if os.path.exists(CSV_REVISION_FILE):
        os.remove(CSV_REVISION_FILE)

    if os.path.exists(JSON_UEIS_FILE):
        os.remove(JSON_UEIS_FILE)


def write_json(records, json_filepath):

    logging.info(f"Writing {len(records)} record(s) to json file: {json_filepath}")

    with open(json_filepath, "w") as f:
        f.write(json.dumps(records))
        

def parse_cfdas():

    if os.path.exists(JSON_CFDA_FILE):
        os.remove(JSON_CFDA_FILE)

    records = []
 
    with open(CSV_CFDA_FILE) as f:
        print(CSV_CFDA_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
                "AUDITYEAR": row[0],
                "DBKEY": row[1],
                "EIN": row[2],
                "CFDA": row[3],
                "AWARDIDENTIFICATION": row[4],
                "RD": row[5],
                "FEDERALPROGRAMNAME": row[6],
                "AMOUNT": row[7],
                "CLUSTERNAME": row[8],
                "STATECLUSTERNAME": row[9],
                "PROGRAMTOTAL": row[10],
                "CLUSTERTOTAL": row[11],
                "DIRECT": row[12],
                "PASSTHROUGHAWARD": row[13],
                "PASSTHROUGHAMOUNT": row[14],
                "MAJORPROGRAM": row[15],
                "TYPEREPORT_MP": row[16],
                "TYPEREQUIREMENT": row[17],
                "QCOSTS2": row[18],
                "FINDINGS": row[19],
                "FINDINGREFNUMS": row[20],
                "ARRA": row[21],
                "LOANS": row[22],
                "LOANBALANCE": row[23],
                "FINDINGSCOUNT": row[24],
                "ELECAUDITSID": row[25],
            }

            if len(row) == 28:
                record["OTHERCLUSTERNAME"]= row[26]
                record["CFDAPROGRAMNAME"]= row[27]
            else:
                record["OTHERCLUSTERNAME"]= None
                record["CFDAPROGRAMNAME"]= None

           

            records.append(record)

    logging.info(f"Parsed {len(records)} CFDA records")

    if records:
        write_json(records, JSON_CFDA_FILE)
        records.clear()


def parse_general():
    
    if os.path.exists(JSON_GENERAL_FILE):
        os.remove(JSON_GENERAL_FILE)

    records = []
 
    with open(CSV_GENERAL_FILE) as f:
        print(CSV_GENERAL_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {        
                "AUDITYEAR": row[0],
                "DBKEY": row[1],
                "TYPEOFENTITY": row[2],
                "FYENDDATE": row[3],
                "AUDITTYPE": row[4],
                "PERIODCOVERED": row[5],
                "NUMBERMONTHS": row[6],
                "EIN": row[7],
                "MULTIPLEEINS": row[8],
                "EINSUBCODE": row[9],
                "DUNS": row[10],
                "MULTIPLEDUNS": row[11],
                "AUDITEENAME": row[12],
                "STREET1": row[13],
                "STREET2": row[14],
                "CITY": row[15],
                "STATE": row[16],
                "ZIPCODE": row[17],
                "AUDITEECONTACT": row[18],
                "AUDITEETITLE": row[19],
                "AUDITEEPHONE": row[20],
                "AUDITEEFAX": row[21],
                "AUDITEEEMAIL": row[22],
                "AUDITEEDATESIGNED": row[23],
                "AUDITEENAMETITLE": row[24],
                "CPAFIRMNAME": row[25],
                "CPASTREET1": row[26],
                "CPASTREET2": row[27],
                "CPACITY": row[28],
                "CPASTATE": row[29],
                "CPAZIPCODE": row[30],
                "CPACONTACT": row[31],
                "CPATITLE": row[32],
                "CPAPHONE": row[33],
                "CPAFAX": row[34],
                "CPAEMAIL": row[35],
                "CPADATESIGNED": row[36],
                "COG_OVER": row[37],
                "COGAGENCY": row[38],
                "OVERSIGHTAGENCY": row[39],
                "TYPEREPORT_FS": row[40],
                "SP_FRAMEWORK": row[41],
                "SP_FRAMEWORK_REQUIRED": row[42],
                "TYPEREPORT_SP_FRAMEWORK": row[43],
                "GOINGCONCERN": row[44],
                "REPORTABLECONDITION": row[45],
                "MATERIALWEAKNESS": row[46],
                "MATERIALNONCOMPLIANCE": row[47],
                "TYPEREPORT_MP": row[48],
                "DUP_REPORTS": row[49],
                "DOLLARTHRESHOLD": row[50],
                "LOWRISK": row[51],
                "REPORTABLECONDITION_MP": row[52],
                "MATERIALWEAKNESS_MP": row[53],
                "QCOSTS": row[54],
                "CYFINDINGS": row[55],
                "PYSCHEDULE": row[56],
                "TOTFEDEXPEND": row[57],
                "DATEFIREWALL": row[58],
                "PREVIOUSDATEFIREWALL": row[59],
                "REPORTREQUIRED": row[60],
                "MULTIPLE_CPAS": row[61]
            }

            if len(row) == 69:            
                record["AUDITOR_EIN"]= row[62]
                record["FACACCEPTEDDATE"]= row[63]
                record["CPAFOREIGN"]= row[64]
                record["CPACOUNTRY"]= row[65]
                record["ENTITY_TYPE"]= row[66]
                record["UEI"]= row[67]
                record["MULTIPLEUEIS"]= row[68]
            else:
                record["AUDITOR_EIN"]= None
                record["FACACCEPTEDDATE"]= None
                record["CPAFOREIGN"]= None
                record["CPACOUNTRY"]= None
                record["ENTITY_TYPE"]= None
                record["UEI"]= None
                record["MULTIPLEUEIS"]= None

 
            records.append(record)

    logging.info(f"Parsed {len(records)} General records")

    if records:
        write_json(records, JSON_GENERAL_FILE)
        records.clear()


def parse_agencies():

    if os.path.exists(JSON_AGENCY_FILE):
        os.remove(JSON_AGENCY_FILE)

    records = []
 
    with open(CSV_AGENCY_FILE) as f:
        print(CSV_AGENCY_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "AUDITYEAR": row[0],
               "DBKEY": row[1],
               "EIN":row[2],
               "AGENCY": row[3],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} AGENCY records")

    if records:
        write_json(records, JSON_AGENCY_FILE)
        records.clear()

def parse_captext():

    if os.path.exists(JSON_CAPTEXT_FILE):
        os.remove(JSON_CAPTEXT_FILE)

    records = []
 
    with open(CSV_CAPTEXT_FILE) as f:
        print(CSV_CAPTEXT_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "SEQ_NUMBER": row[0],
               "DBKEY": row[1],
               "AUDITYEAR":row[2],
               "FINDINGREFNUMS": row[3],
               "TEXT":row[4],
               "CHARTSTABLES": row[5],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} CAPTEXT records")

    if records:
        write_json(records, JSON_CAPTEXT_FILE)
        records.clear()

def parse_cpas():

    if os.path.exists(JSON_CPA_FILE):
        os.remove(JSON_CPA_FILE)

    records = []
 
    with open(CSV_CPA_FILE) as f:
        print(CSV_CPA_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "DBKEY": row[0],
               "AUDITYEAR": row[1],
               "CPAFIRMNAME": row[2],
               "CPAEIN": row[3],
               "CPASTREET1": row[4],
               "CPACITY": row[5],
               "CPASTATE": row[6],
               "CPAZIPCODE": row[7],
               "CPACONTACT": row[8],
               "CPATITLE": row[9],
               "CPAPHONE": row[10],
               "CPAFAX": row[11],
               "CPAEMAIL": row[12],
            }

            

            records.append(record)

    logging.info(f"Parsed {len(records)} CPAS records")

    if records:
        write_json(records, JSON_CPA_FILE)
        records.clear()


def parse_duns():

    if os.path.exists(JSON_DUNS_FILE):
        os.remove(JSON_DUNS_FILE)

    records = []
 
    with open(CSV_DUNS_FILE) as f:
        print(CSV_DUNS_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "AUDITYEAR": row[0],
               "DBKEY": row[1],
               "DUNS":row[2],
               "DUNSEQNUM": row[3],
            }


            records.append(record)

    logging.info(f"Parsed {len(records)} DUNS records")

    if records:
        write_json(records, JSON_DUNS_FILE)
        records.clear()

def parse_eins():

    if os.path.exists(JSON_EINS_FILE):
        os.remove(JSON_EINS_FILE)

    records = []
 
    with open(CSV_EINS_FILE) as f:
        print(CSV_EINS_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "AUDITYEAR": row[0],
               "DBKEY": row[1],
               "EIN":row[2],
               "EINSEQNUM": row[3],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} EINS records")

    if records:
        write_json(records, JSON_EINS_FILE)
        records.clear()


def parse_findings():

    if os.path.exists(JSON_FINDINGS_FILE):
        os.remove(JSON_FINDINGS_FILE)

    records = []
 
    with open(CSV_FINDINGS_FILE) as f:
        print(CSV_FINDINGS_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "DBKEY": row[0],
               "AUDITYEAR": row[1],
               "ELECAUDITSID":row[2],
               "ELECAUDITFINDINGSID": row[3],
                "FINDINGSREFNUMS": row[4],
                "TYPEREQUIREMENT": row[5],
                "MODIFIEDOPINION": row[6],
                "OTHERNONCOMPLIANCE": row[7],
                "MATERIALWEAKNESS": row[8],
                "SIGNIFICANTDEFICIENCY": row[9],
                "OTHERFINDINGS": row[10],
                "QCOSTS": row[11],
                "REPEATFINDING": row[12],
                "PRIORFINDINGREFNUMS": row[13],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} FINDINGS records")

    if records:
        write_json(records, JSON_FINDINGS_FILE)
        records.clear()

def parse_findingtext():

    if os.path.exists(JSON_FINDINGSTEXT_FILE):
        os.remove(JSON_FINDINGSTEXT_FILE)

    records = []
 
    with open(CSV_FINDINGSTEXT_FILE) as f:
        print(CSV_FINDINGSTEXT_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "SEQ_NUMBER": row[0],
               "DBKEY": row[1],
               "AUDITYEAR":row[2],
               "FINDINGREFNUMS": row[3],
               "TEXT":row[4],
               "CHARTSTABLES": row[5],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} FINDINGSTEXT records")

    if records:
        write_json(records, JSON_FINDINGSTEXT_FILE)
        records.clear()

def parse_notes():

    if os.path.exists(JSON_NOTES_FILE):
        os.remove(JSON_NOTES_FILE)

    records = []
 
    with open(CSV_NOTES_FILE) as f:
        print(CSV_NOTES_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "ID": row[0],
               "REPORTID": row[1],
               "VERSION":row[2],
               "AUDITYEAR": row[3],
               "DBKEY":row[4],
               "SEQ_NUMBER": row[5],
               "TYPE_ID": row[6],
               "NOTE_INDEX": row[7],
               "TITLE": row[8],
               "CONTENT": row[9]
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} NOTES records")

    if records:
        write_json(records, JSON_NOTES_FILE)
        records.clear()


def parse_passthroughs():

    if os.path.exists(JSON_PASSTHROUGH_FILE):
        os.remove(JSON_PASSTHROUGH_FILE)

    records = []
 
    with open(CSV_PASSTHROUGH_FILE) as f:
        print(CSV_PASSTHROUGH_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        counter = 2

        for row in reader:
            
            record = {
               "DBKEY": row[0],
               "AUDITYEAR": row[1],
               "ELECAUDITSID":row[2],
               "PASSTHROUGHNAME": row[3],
            }

            if len(row) == 5:
                record["PASSTHROUGHID"]= row[4]
            else:
                record["PASSTHROUGHID"]="N/A"

            counter = counter + 1


            records.append(record)

    logging.info(f"Parsed {len(records)} PASSTHROUGH records")

    if records:
        write_json(records, JSON_PASSTHROUGH_FILE)
        records.clear()

def parse_revisions():

    if os.path.exists(JSON_REVISION_FILE):
        os.remove(JSON_REVISION_FILE)

    records = []
 
    with open(CSV_REVISION_FILE) as f:
        print(CSV_REVISION_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            

            #very bad data missing elecrevisionid, have to a strict check

            if len(row) == 19:
                record = {
                    "DBKEY": row[0],
                    "AUDITYEAR": row[1],
                    "GENINFO":row[2],
                    "GENINFO_EXPLAIN": row[3],
                    "FEDERALAWARDS":row[4],
                    "FEDERALAWARDS_EXPLAIN": row[5],
                    "NOTESTOSEFA": row[6],
                    "NOTESTOSEFA_EXPLAIN": row[7],
                    "AUDITINFO": row[8],
                    "AUDITINFO_EXPLAIN": row[9],
                    "FINDINGS": row[10],
                    "FINDINGS_EXPLAIN": row[11],
                    "FINDINGSTEXT": row[12],
                    "FINDINGSTEXT_EXPLAIN": row[13],
                    "CAP": row[14],
                    "CAP_EXPLAIN": row[15],
                    "OTHER": row[16],
                    "OTHER_EXPLAIN": row[17],
                    "ELECRPTREVISIONID": row[18],

                }
   
                records.append(record)

    logging.info(f"Parsed {len(records)} REVISIONS records")

    if records:
        write_json(records, JSON_REVISION_FILE)
        records.clear()


def parse_ueis():

    if os.path.exists(JSON_UEIS_FILE):
        os.remove(JSON_UEIS_FILE)

    records = []
 
    with open(CSV_UEIS_FILE) as f:
        print(CSV_UEIS_FILE)
        reader = csv.reader(f, delimiter="|")
        next(reader, None)

        for row in reader:
            
            record = {
               "AUDITYEAR": row[0],
               "DBKEY": row[1],
               "UEI":row[2],
               "UEISEQNUM": row[3],
            }

            records.append(record)

    logging.info(f"Parsed {len(records)} UEIS records")

    if records:
        write_json(records, JSON_UEIS_FILE)
        records.clear()


if __name__ == "__main__":
    logging.info("Starting parsing process ...")
    parse_cfdas()
    parse_general()
    parse_agencies()
    parse_captext()
    parse_cpas()
    parse_duns()
    parse_eins()
    parse_findings()
    parse_findingtext()
    parse_notes()
    parse_passthroughs()
    parse_revisions()
    parse_ueis()
    logging.info("Finished parsing process ...")
