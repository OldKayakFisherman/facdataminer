create table public.census_cfdas (
  id integer primary key not null default nextval('census_cfdas_id_seq'::regclass),
  audityear integer not null,
  dbkey integer not null,
  ein text,
  cfda text,
  awardidentification text,
  rd text,
  federalprogramname text,
  amount money,
  clustername text,
  stateclustername text,
  programtotal text,
  clustertotal text,
  direct text,
  passthroughaward text,
  passthroughamount money,
  majorprogram text,
  typereport_mp text,
  typerequirement text,
  qcosts2 text,
  findings text,
  findingrefnums text,
  arra text,
  loans text,
  loanbalance text,
  findingscount integer,
  elecauditsid integer
);

create table public.census_general (
  id serial primary key,
  audityear integer not null,
  dbkey integer not null,
  typeofentity character varying(50),
  fyenddate character varying(20),
  audittype character varying(1),
  periodcovered character varying(1),
  numbermonths character varying(3),
  ein character varying(9),
  multipleeins character varying(1),
  einsubcode character varying(9),
  duns character varying(9),
  multipleduns character varying(1),
  auditeename character varying(70),
  street1 character varying(45),
  street2 character varying(45),
  city character varying(30),
  state character varying(2),
  zipcode character varying(9),
  auditeecontact character varying(50),
  auditeetitle character varying(40),
  auditeephone character varying(10),
  auditeefax character varying(10),
  auditeeemail character varying(60),
  auditeedatesigned character varying(10),
  auditeenametitle character varying(70),
  cpafirmname character varying(64),
  cpastreet1 character varying(45),
  cpastreet2 character varying(45),
  cpacity character varying(30),
  cpastate character varying(2),
  cpazipcode character varying(9),
  cpacontact character varying(50),
  cpatitle character varying(40),
  cpaphone character varying(10),
  cpafax character varying(10),
  cpaemail character varying(60),
  cpadatesigned character varying(10),
  cog_over character varying(10),
  cogagency character varying(10),
  oversightagency character varying(10),
  typereport_fs character varying(4),
  sp_framework character varying(15),
  sp_framework_required character varying(1),
  typereport_sp_framework character varying(15),
  goingconcern character varying(1),
  reportablecondition character varying(1),
  materialweakness character varying(1),
  materialnoncompliance character varying(1),
  typereport_mp character varying(3),
  dup_reports character varying(1),
  dollarthreshold character varying(12),
  lowrisk character varying(1),
  reportablecondition_mp character varying(1),
  materialweakness_mp character varying(4),
  qcosts character varying(1),
  cyfindings character varying(1),
  pyschedule character varying(1),
  totfedexpend character varying(12),
  datefirewall character varying(20),
  previousdatefirewall character varying(20),
  reportrequired character varying(1),
  multiple_cpas character varying(1),
  auditor_ein character varying(9),
  facaccepteddate character varying(10),
  cpaforeign character varying(400),
  cpacountry character varying(50),
  entity_type character varying(50),
  uei character varying(15),
  multipleueis character varying(1)
);

create table census_agencies (
  id serial primary key not null,
  audityear integer,
  dbkey integer,
  ein character varying(9),
  agency character varying(300)
);

CREATE table census_captext
(
    id serial primary key not null,
    seqnumber text,
    dbkey int,
    audityear int,
    findingrefnums text,
    captext text,
    chartstables text
);

create table census_cpas (
  id serial primary key not null,
  dbkey integer,
  audityear integer,
  cpafirmname character varying(70),
  cpaein character varying(9),
  cpastreet1 character varying(50),
  cpacity character varying(30),
  cpastate character varying(2),
  cpazipcode character varying(9),
  cpacontact character varying(50),
  cpatitle character varying(40),
  cpaphone character varying(10),
  cpafax character varying(10),
  cpaemail character varying(60)
);


create table census_duns (
  id serial primary key,
  audityear integer,
  dbkey integer,
  duns character varying(9),
  dunseqnum character varying(4)
);



create table census_eins (
  id serial primary key,
  audityear integer,
  dbkey integer,
  ein character varying(9),
  einseqnum character varying(4)
);


create table census_findings (
    id serial primary key,
    dbkey integer,
    audityear integer,
    elecauditsid integer,
    elecauditfindingsid integer,
    findingsrefnums text,
    typerequirement text,
    modifiedopinion text,
    othernoncompliance text,
    materialweakness text,
    significantdeficiency text,
    otherfindings text,
    qcosts text,
    repeatfinding text,
    priorfindingrefnums text
);

              
CREATE table census_findingstext
(
    id serial primary key not null,
    seqnumber text,
    dbkey int,
    audityear int,
    findingrefnums text,
    findingstext text,
    chartstables text
);
           
           
CREATE table census_notes
(
    id serial primary key,
    census_id integer,
    reportid integer,
    version integer,
    audityear integer,
    dbkey integer,
    seq_number integer,
    type_id integer,
    note_index integer,
    title text,
    content text
);    
          
CREATE table census_passthroughs
(
    id serial primary key,
    dbkey integer,
    audityear integer,
    elecauditsid integer,
    passthroughname text,
    passthroughid text 
);
             
create table census_revisions
(
  id serial primary key,
  dbkey integer,
  audityear integer,
  geninfo text,
  geninfoexplain text,
  federalawards text,
  federalawardsexplain text,
  notestosefa text,
  notestosefaexplain text,
  auditinfo text,
  auditinfoexplain text,
  findings text,
  findingsexplain text,
  findingstext text,
  findingstextexplain text ,
  cap text,
  capexplain text,
  other text,
  otherexplain text,
  elecrptrevisionid integer
);


create table census_ueis
(
    id serial primary key,
    audityear integer,
    dbkey integer,
    uei text,
    ueiseqnum text    
);
