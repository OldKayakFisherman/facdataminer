from django.db import models

# Create your models here.

class census_cfda(models.Model):
    
    class Meta:
        managed = False
        db_table = "census_cfdas"

    audityear = models.IntegerField
    dbkey = models.IntegerField
    ein = models.CharField
    cfda = models.CharField
    awardidentification =models.CharField
    rd= models.CharField
    federalprogramname= models.CharField
    amount = models.DecimalField(max_digits=6, decimal_places=2)
    clustername =models.CharField
    stateclustername =models.CharField
    programtotal =models.CharField
    clustertotal =models.CharField
    direct =models.CharField
    passthroughaward =models.CharField
    passthroughamount = models.DecimalField(max_digits=6, decimal_places=2)
    majorprogram =models.CharField
    typereport_mp =models.CharField
    typerequirement =models.CharField
    qcosts2 =models.CharField
    findings =models.CharField
    findingrefnums = models.CharField
    arra =models.CharField
    loans =models.CharField
    loanbalance =models.CharField
    findingscount = models.CharField
    elecauditsid = models.IntegerField


class census_general(models.Model):
    
    class Meta:
        managed = False
        db_table = "census_general"

    audityear = models.IntegerField
    dbkey = models.IntegerField
    typeofentity = models.CharField
    fyenddate = models.CharField
    audittype = models.CharField
    periodcovered = models.CharField
    numbermonths = models.CharField
    ein = models.CharField
    multipleeins = models.CharField
    einsubcode = models.CharField
    duns = models.CharField
    multipleduns = models.CharField
    auditeename = models.CharField
    street1 = models.CharField
    street2 = models.CharField
    city = models.CharField
    state  = models.CharField
    zipcode  = models.CharField
    auditeecontact  = models.CharField
    auditeetitle  = models.CharField
    auditeephone  = models.CharField
    auditeefax  = models.CharField
    auditeeemail  = models.CharField
    auditeedatesigned  = models.CharField
    auditeenametitle  = models.CharField
    cpafirmname  = models.CharField
    cpastreet1  = models.CharField
    cpastreet2  = models.CharField
    cpacity  = models.CharField
    cpastate  = models.CharField
    cpazipcode  = models.CharField
    cpacontact  = models.CharField
    cpatitle  = models.CharField
    cpaphone  = models.CharField
    cpafax  = models.CharField
    cpaemail  = models.CharField
    cpadatesigned  = models.CharField
    cog_over  = models.CharField
    cogagency  = models.CharField
    oversightagency  = models.CharField
    typereport_fs  = models.CharField
    sp_framework  = models.CharField
    sp_framework_required  = models.CharField
    typereport_sp_framework  = models.CharField
    goingconcern  = models.CharField
    reportablecondition  = models.CharField
    materialweakness  = models.CharField
    materialnoncompliance  = models.CharField
    typereport_mp  = models.CharField
    dup_reports  = models.CharField
    dollarthreshold  = models.CharField
    lowrisk  = models.CharField
    reportablecondition_mp  = models.CharField
    materialweakness_mp  = models.CharField
    qcosts  = models.CharField
    cyfindings  = models.CharField
    pyschedule  = models.CharField
    totfedexpend  = models.CharField
    datefirewall  = models.CharField
    previousdatefirewall  = models.CharField
    reportrequired  = models.CharField
    multiple_cpas  = models.CharField
    auditor_ein  = models.CharField
    facaccepteddate  = models.CharField
    cpaforeign  = models.CharField
    cpacountry  = models.CharField
    entity_type  = models.CharField
    uei  = models.CharField
    multipleueis = models.CharField

class census_agency(models.Model):
    
    class Meta:
        managed = False
        db_table = "census_agencies"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    ein = models.CharField
    agency = models.CharField


class census_cpas(models.Model):

    class Meta:
        managed = False
        db_table = "census_captext"

    seqnumber  = models.CharField
    dbkey = models.IntegerField
    audityear = models.IntegerField
    findingrefnums  = models.CharField
    captext  = models.CharField
    chartstables  = models.CharField

class census_cpa(models.Model):

    class Meta:
        managed = False
        db_table = "census_cpas"

    dbkey = models.IntegerField
    audityear = models.IntegerField
    cpafirmname  = models.CharField
    cpaein  = models.CharField
    cpastreet1  = models.CharField
    cpacity  = models.CharField
    cpastate  = models.CharField
    cpazipcode  = models.CharField
    cpacontact  = models.CharField
    cpatitle  = models.CharField
    cpaphone  = models.CharField
    cpafax  = models.CharField
    cpaemail = models.CharField


class census_dun(models.Model):

    class Meta:
        managed = False
        db_table = "census_duns"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    duns = models.CharField
    dunseqnum = models.CharField

class census_ein(models.Model):

    class Meta:
        managed = False
        db_table = "census_eins"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    ein = models.CharField
    einseqnum = models.CharField


class census_finding(models.Model):

    class Meta:
        managed = False
        db_table = "census_findings"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    elecauditsid = models.IntegerField
    elecauditfindingsid = models.IntegerField
    findingsrefnums = models.CharField
    typerequirement = models.CharField
    modifiedopinion = models.CharField
    othernoncompliance = models.CharField
    materialweakness = models.CharField
    significantdeficiency = models.CharField
    otherfindings = models.CharField
    qcosts = models.CharField
    repeatfinding = models.CharField
    priorfindingrefnums = models.CharField


class census_findingtext(models.Model):

    class Meta:
        managed = False
        db_table = "census_findingstext"

    seqnumber = models.CharField
    audityear = models.IntegerField
    dbkey = models.IntegerField
    findingrefnums = models.CharField
    findingstext = models.CharField
    chartstables = models.CharField


class census_note(models.Model):

    class Meta:
        managed = False
        db_table = "census_notes"

    census_id = models.IntegerField
    reportid = models.IntegerField
    version = models.IntegerField
    audityear = models.IntegerField
    dbkey = models.IntegerField
    seq_number = models.IntegerField
    type_id = models.IntegerField
    note_index = models.IntegerField
    title = models.CharField
    content = models.CharField


class census_passthrough(models.Model):

    class Meta:
        managed = False
        db_table = "census_passthroughs"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    elecauditsid = models.IntegerField
    passthroughname = models.CharField
    passthroughid = models.CharField


class census_revision(models.Model):

    class Meta:
        managed = False
        db_table = "census_revisions"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    geninfo = models.CharField
    geninfoexplain = models.CharField
    federalawards = models.CharField
    federalawardsexplain = models.CharField
    notestosefa = models.CharField
    notestosefaexplain = models.CharField
    auditinfo = models.CharField
    auditinfoexplain = models.CharField
    findings = models.CharField
    findingsexplain = models.CharField
    findingstext = models.CharField
    findingstextexplain = models.CharField
    cap = models.CharField
    capexplain = models.CharField
    other = models.CharField
    otherexplain = models.CharField
    elecrptrevisionid = models.IntegerField


class census_uei(models.Model):

    class Meta:
        managed = False
        db_table = "census_ueis"


    audityear = models.IntegerField
    dbkey = models.IntegerField
    uei = models.CharField
    ueiseqnum = models.CharField    


class gsa_general(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_general"

    report_id = models.CharField
    auditee_uei = models.CharField
    audit_year = models.SmallIntegerField
    auditee_certify_name = models.CharField
    auditee_certify_title = models.CharField
    auditee_contact_name = models.CharField
    auditee_email = models.CharField
    auditee_name = models.CharField
    auditee_phone = models.CharField
    auditee_contact_title = models.CharField
    auditee_address_line_1 = models.CharField
    auditee_city = models.CharField
    auditee_state = models.CharField
    auditee_ein = models.CharField
    auditee_zip = models.CharField
    auditor_phone = models.CharField
    auditor_state = models.CharField
    auditor_city = models.CharField
    auditor_contact_title = models.CharField
    auditor_address_line_1 = models.CharField
    auditor_zip = models.CharField
    auditor_country = models.CharField
    auditor_contact_name = models.CharField
    auditor_email = models.CharField
    auditor_firm_name = models.CharField
    auditor_foreign_address = models.CharField
    auditor_ein = models.CharField
    cognizant_agency = models.CharField
    oversight_agency = models.CharField
    date_created  = models.DateTimeField
    ready_for_certification_date = models.DateTimeField
    auditor_certified_date = models.DateTimeField
    auditee_certified_date = models.DateTimeField
    submitted_date = models.DateTimeField
    fac_accepted_date = models.DateTimeField
    fy_end_date = models.DateTimeField
    fy_start_date = models.DateTimeField
    audit_type  = models.CharField
    gaap_results  = models.CharField
    sp_framework_basis  = models.CharField
    is_sp_framework_required  = models.CharField
    sp_framework_opinions  = models.CharField
    is_going_concern_included = models.BooleanField
    is_internal_control_deficiency_disclosed = models.BooleanField
    is_internal_control_material_weakness_disclosed = models.BooleanField
    is_material_noncompliance_disclosed = models.BooleanField
    dollar_threshold = models.DecimalField
    is_low_risk_auditee = models.BooleanField
    agencies_with_prior_findings = models.CharField
    entity_type = models.CharField
    number_months = models.CharField
    audit_period_covered = models.CharField
    total_amount_expended = models.CharField
    type_audit_code = models.CharField
    is_public  = models.BooleanField
    data_source = models.CharField


class gsa_award(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_awards"

    report_id = models.CharField
    auditee_uei = models.CharField
    audit_year = models.SmallIntegerField
    award_reference = models.CharField
    federal_agency_prefix = models.CharField
    federal_award_extension = models.CharField
    additional_award_identification = models.CharField
    federal_program_name = models.CharField
    amount_expended = models.CharField
    cluster_name = models.CharField
    other_cluster_name = models.CharField
    state_cluster_name = models.CharField
    cluster_total = models.DecimalField
    federal_program = models.DecimalField
    is_major  = models.BooleanField
    is_loan  = models.BooleanField
    loan_balance  = models.CharField
    is_direct  = models.BooleanField
    audit_report_type  = models.CharField
    findings_count = models.IntegerField
    is_passthrough_award = models.BooleanField
    passthrough_amount = models.DecimalField


class gsa_corrective_action_plan(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_corrective_action_plans"

    report_id  = models.CharField
    auditee_uei  = models.CharField
    audit_year = models.SmallIntegerField
    finding_ref_number  = models.CharField
    contains_chart_or_table = models.BooleanField
    planned_action  = models.CharField


class gsa_finding(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_findings"

    report_id =models.CharField
    auditee_uei =models.CharField
    audit_year = models.SmallIntegerField
    award_reference =models.CharField
    reference_number =models.CharField
    is_material_weakness = models.BooleanField
    is_modified_opinion = models.BooleanField
    is_other_findings = models.BooleanField
    is_other_matters = models.BooleanField
    prior_finding_ref_numbers =models.CharField
    is_questioned_costs = models.BooleanField
    is_repeat_finding = models.BooleanField
    is_significant_deficiency = models.BooleanField
    type_requirement =models.CharField

class gsa_findingtext(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_findings_text"

    report_id =models.CharField
    auditee_uei =models.CharField
    audit_year = models.SmallIntegerField
    finding_ref_number =models.CharField
    contains_chart_or_table =models.CharField
    finding_text =models.CharField



class gsa_note_to_sefa(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_notes_to_sefa"

    report_id =models.CharField
    auditee_uei =models.CharField
    audit_year = models.SmallIntegerField
    title =models.CharField
    accounting_policies =models.CharField
    is_minimis_rate_used = models.BooleanField
    rate_explained =models.CharField
    contains_chart_or_table = models.BooleanField

class gsa_passthrough(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_passthroughs"

    report_id =models.CharField
    auditee_uei =models.CharField
    audit_year = models.SmallIntegerField
    award_reference =models.CharField
    passthrough_id =models.CharField
    passthrough_name =models.CharField



class gsa_secondary_auditors(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_secondary_auditors"


    report_id =models.CharField
    auditee_uei =models.CharField
    audit_year = models.SmallIntegerField
    auditor_ein =models.CharField
    auditor_name =models.CharField
    contact_name =models.CharField
    contact_email =models.CharField
    contact_phone =models.CharField
    address_street =models.CharField
    address_city =models.CharField
    address_state =models.CharField
    address_zipcode = models.CharField


class gsa_additional_uei(models.Model):

    class Meta:
        managed = True
        db_table = "gsa_additional_ueis"

    report_id = models.CharField
    auditee_uei = models.CharField
    audit_year= models.SmallIntegerField
    additional_uei = models.CharField




