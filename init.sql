CREATE TABLE general
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    auditee_certify_name text,
    auditee_certify_title text,
    auditee_contact_name text,
    auditee_email text,
    auditee_name text,
    auditee_phone text,
    auditee_contact_title text,
    auditee_address_line_1 text,
    auditee_city text,
    auditee_state text,
    auditee_ein text,
    auditee_zip text,
    auditor_phone text,
    auditor_state text,
    auditor_city text,
    auditor_contact_title text,
    auditor_address_line_1 text,
    auditor_zip text,
    auditor_country text,
    auditor_contact_name text,
    auditor_email text,
    auditor_firm_name text,
    auditor_foreign_address text,
    auditor_ein text,
    cognizant_agency text,
    oversight_agency text,
    date_created date,
    ready_for_certification_date date,
    auditor_certified_date date,
    auditee_certified_date date,
    submitted_date date,
    fac_accepted_date date,
    fy_end_date date,
    fy_start_date date,
    audit_type text,
    gaap_results text,
    sp_framework_basis text,
    is_sp_framework_required text,
    sp_framework_opinions text,
    is_going_concern_included bool,
    is_internal_control_deficiency_disclosed bool,
    is_internal_control_material_weakness_disclosed bool,
    is_material_noncompliance_disclosed bool,
    dollar_threshold money,
    is_low_risk_auditee bool,
    agencies_with_prior_findings text,
    entity_type text,
    number_months text,
    audit_period_covered text,
    total_amount_expended text,
    type_audit_code text,
    is_public bool,
    data_source text
);

CREATE TABLE awards
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    award_reference text,
    federal_agency_prefix text,
    federal_award_extension text,
    additional_award_identification text,
    federal_program_name text,
    amount_expended text,
    cluster_name text,
    other_cluster_name text,
    state_cluster_name text,
    cluster_total money,
    federal_program_total money,
    is_major bool,
    is_loan bool,
    loan_balance text,
    is_direct bool,
    audit_report_type text,
    findings_count int,
    is_passthrough_award bool,
    passthrough_amount money

);

CREATE TABLE corrective_action_plans
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    finding_ref_number text,
    contains_chart_or_table bool,
    planned_action text
);

CREATE TABLE findings
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    award_reference text,
    reference_number text,
    is_material_weakness bool,
    is_modified_opinion bool,
    is_other_findings bool,
    is_other_matters bool,
    prior_finding_ref_numbers text,
    is_questioned_costs bool,
    is_repeat_finding bool,
    is_significant_deficiency bool,
    type_requirement text
);

CREATE TABLE findings_text
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    finding_ref_number text,
    contains_chart_or_table text,
    finding_text text
);

CREATE TABLE notes_to_sefa
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    title text,
    accounting_policies text,
    is_minimis_rate_used bool,
    rate_explained text,
    contains_chart_or_table bool
);

CREATE TABLE passthroughs
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    award_reference text,
    passthrough_id text,
    passthrough_name text
);

CREATE TABLE secondary_auditors
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    auditor_ein text,
    auditor_name text,
    contact_name text,
    contact_email text,
    contact_phone text,
    address_street text,
    address_city text,
    address_state text,
    address_zipcode text
);

CREATE TABLE additional_ueis
(
    id serial not null primary key,
    report_id text,
    auditee_uei text,
    audit_year smallint,
    additional_uei text
);


CREATE TABLE process_log
(
    id serial not null primary key,
    process_name text not null,
    process_step text not null,
    was_successful bool not null default false,
    execution_timestamp timestamp default current_timestamp
);










