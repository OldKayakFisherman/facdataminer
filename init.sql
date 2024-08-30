DROP INDEX IF EXISTS general_audit_year_idx;
DROP INDEX IF EXISTS general_auditee_name_idx;
DROP INDEX IF EXISTS general_date_created_idx;
DROP INDEX IF EXISTS prior_findings_agency_idx;
DROP INDEX IF EXISTS federal_awards_federal_agency_prefix_idx;
DROP INDEX IF EXISTS federal_awards_federal_award_extension_idx;
DROP INDEX IF EXISTS federal_awards_additional_award_identification_idx;
DROP INDEX IF EXISTS federal_awards_federal_program_name_idx;
DROP INDEX IF EXISTS findings_reference_number;
DROP INDEX IF EXISTS findings_text_finding_ref_number;
DROP INDEX IF EXISTS finding_ref_number_finding_ref_number;
DROP INDEX IF EXISTS secondary_auditors_auditor_name;
DROP INDEX IF EXISTS additional_ueis_uei;
DROP INDEX IF EXISTS additional_eins_ein;

DROP TABLE IF EXISTS gsa_injest_log;
DROP TABLE IF EXISTS census_injest_log;
DROP TABLE IF EXISTS general;
DROP TABLE IF EXISTS prior_findings;
DROP TABLE IF EXISTS notes_to_sefa;
DROP TABLE IF EXISTS findings;
DROP TABLE IF EXISTS findings_text;
DROP TABLE IF EXISTS corrective_action_plans;
DROP TABLE IF EXISTS secondary_auditors;
DROP TABLE IF EXISTS additional_ueis;
DROP TABLE IF EXISTS additional_eins;


CREATE TABLE gsa_injest_log
(
    id serial PRIMARY KEY NOT NULL,
    reports_injested integer NOT NULL,
	collection_date date  NOT NULL,
	injection_date date  NOT NULL,
);


CREATE TABLE census_injest_log
(
    id serial PRIMARY KEY NOT NULL,
    collection_date date  NOT NULL,
	injection_date date  NOT NULL,
	dbkeyinteger NOT NULL,
	audit_year TEXT NOT NULL
);

CREATE TABLE general
(
    id serial PRIMARY KEY NOT NULL,
	report_id text not null UNIQUE,
	audit_year text NOT NULL,
	entity_type text,	
	fy_start_date date NOT NULL,
	fy_end_date: date,	
	audit_type text,	
	audit_period_covered text,	
	number_months text,	
	auditee_ein text,	
	auditee_name text NOT NULL,	
	auditee_address_line_1 text,	
	auditee_city text,	
	auditee_state text,
	auditee_zip text,
	auditee_contact_name text,	
	auditee_contact_title text,	
	auditee_phone text,	
	auditee_email text,	
	auditee_certified_date date,	
	auditor_firm_name text,	
	auditor_address_line_1 text,	
	auditor_city text,	
	auditor_state text,	
	auditor_zip text,
	auditor_contact_name text,
	auditor_contact_title text,
	auditor_phone text,	
	auditor_email text,	
	auditor_certified_date date,
	cognizant_agency text,	
	oversight_agency text,	
	gaap_results text,
	sp_framework_basis text,	
	sp_framework_opinions text,
	is_going_concern_included bool,	
	is_internal_control_material_weakness_disclosed bool,
	is_aicpa_audit_guide_included bool,
	dollar_threshold biginteger,
	is_low_risk_auditee bool,
	total_amount_expended biginteger,
	auditor_ein text,
	fac_accepted_date date,
	auditor_foreign_address text,
	auditor_country text,
	auditee_uei text,
	is_additional_ueis bool,
	auditee_certify_name text,
	auditee_certify_title text,
	is_sp_framework_required bool,
	is_internal_control_deficiency_disclosed bool,
	is_material_noncompliance_disclosed bool,
	date_created date,
	type_audit_code text,
	is_public bool,
	ready_for_certification_date date,
	data_source text,
	census_dbkey integer,
	is_secondary_auditors text,
	date_injested date
);

CREATE TABLE prior_findings
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	agency text not null
);

CREATE TABLE federal_awards
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	federal_agency_prefix text not null,
	federal_award_extension text not null,
	additional_award_identification text not null,
	federal_program_name text not null,
	amount_expended biginteger not null,
	cluster_name text,
	state_cluster_name text,
	federal_program_total biginteger,
	cluster_total biginteger,
	is_direct bool,
	is_passthrough_award bool,
	passthrough_amount biginteger
	is_major bool,
	audit_report_type text,
	finding_ref_number text,
	is_loan bool,
	loan_balance text,
	findings_count integer,
	award_reference text,
	other_cluster_name text,

);

CREATE TABLE notes_to_sefa
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	title text not null,
	content text not null,
	accounting_policies text,
	is_minimis_rate_used text,
	rate_explained text,
	contains_chart_or_table text

);

CREATE TABLE findings
(
	id serial PRIMARY KEY NOT NULL,
	federal_award_id integer FOREIGN KEY REFERENCES federal_awards(id),
	reference_number text not null,
	type_requirement text,
	is_modified_opinion bool,
	is_other_matters bool,
	is_material_weakness bool,
	is_significant_deficiency bool,
	is_other_findings bool,
	is_questioned_costs bool,
	is_repeat_finding bool,
	prior_finding_ref_numbers text
);

CREATE TABLE findings_text
(
	id serial PRIMARY KEY NOT NULL,
	finding_id integer FOREIGN KEY REFERENCES findings(id),
	finding_ref_number text not null,
	finding_text text,
	contains_chart_or_table text
);

CREATE TABLE corrective_action_plans
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	finding_ref_number text NOT NULL,
	planned_action text,
	contains_chart_or_table text
);

CREATE TABLE passthroughs
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	award_reference text,
	passthrough_name text,
	passthrough_id text
);

CREATE TABLE secondary_auditors
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	auditor_name text NOT NULL,
	auditor_ein text,
	address_street text,
	address_city text,
	address_state text,
	address_zipcode text,
	contact_name text,
	contact_title text,
	contact_phone text,
	contact_email text,

);

CREATE TABLE additional_ueis
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	uei text NOT NULL
);

CREATE TABLE additional_eins
(
	id serial PRIMARY KEY NOT NULL,
	general_id integer FOREIGN KEY REFERENCES general(id),
	ein text NOT NULL
);



CREATE INDEX general_audit_year_idx ON general (audit_year);
CREATE INDEX general_auditee_name_idx ON general (auditee_name);
CREATE INDEX general_date_created_idx ON general (date_created);
CREATE INDEX prior_findings_agency_idx ON prior_findings (agency);
CREATE INDEX federal_awards_federal_agency_prefix_idx ON federal_awards(federal_agency_prefix);
CREATE INDEX federal_awards_federal_award_extension_idx ON federal_awards(federal_award_extension);
CREATE INDEX federal_awards_additional_award_identification_idx ON federal_awards(additional_award_identification);
CREATE INDEX federal_awards_federal_program_name_idx ON federal_awards(federal_program_name);
CREATE INDEX findings_reference_number ON findings (reference_number);
CREATE INDEX findings_text_finding_ref_number ON findings_text (finding_ref_number);
CREATE INDEX finding_ref_number_finding_ref_number ON corrective_action_plans(finding_ref_number);
CREATE INDEX secondary_auditors_auditor_name ON secondary_auditors(auditor_name); 
CREATE INDEX additional_ueis_uei ON additional_ueis(uei);
CREATE INDEX additional_eins_ein ON additional_eins(ein);

ALTER TABLE gsa_injest_log OWNER TO facdata;
ALTER TABLE census_injest_log OWNER TO facdata;
ALTER TABLE general OWNER TO facdata;
ALTER TABLE prior_findings OWNER TO facdata;
ALTER TABLE notes_to_sefa OWNER TO facdata;
ALTER TABLE findings OWNER TO facdata;
ALTER TABLE findings_text OWNER TO facdata;
ALTER TABLE corrective_action_plans OWNER TO facdata;
ALTER TABLE passthroughs OWNER TO facdata;
ALTER TABLE secondary_auditors OWNER TO facdata;
ALTER TABLE additional_ueis OWNER TO facdata;
ALTER TABLE additional_eins TO facdata;

