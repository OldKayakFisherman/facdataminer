from sqlalchemy import Integer, String
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy.orm import DeclarativeBase
from datetime import datetime
from decimal import Decimal

class Base(DeclarativeBase):
  pass

class census_general(Base):

    id = Mapped[int] = mapped_column(primary_key=True)
    report_id = Mapped[str]
    auditee_uei = Mapped[str]
    audit_year = Mapped[int]
    auditee_certify_name = Mapped[str]
    auditee_certify_title = Mapped[str]
    auditee_contact_name = Mapped[str]
    auditee_email = Mapped[str]
    auditee_name = Mapped[str]
    auditee_phone = Mapped[str]
    auditee_contact_title = Mapped[str]
    auditee_address_line_1 = Mapped[str]
    auditee_city = Mapped[str]
    auditee_state = Mapped[str]
    auditee_ein = Mapped[str]
    auditee_zip = Mapped[str]
    auditor_phone = Mapped[str]
    auditor_state = Mapped[str]
    auditor_city = Mapped[str]
    auditor_contact = Mapped[str]
    auditor_address_line_1 = Mapped[str]
    auditor_zip = Mapped[str]
    auditor_country = Mapped[str]
    auditor_contact_name = Mapped[str]
    auditor_email = Mapped[str]
    auditor_firm_name = Mapped[str]
    auditor_foreign_address = Mapped[str]
    auditor_ein = Mapped[str]
    cognizant_agency = Mapped[str]
    oversight_agency = Mapped[str]
    date_created  = Mapped[datetime]
    ready_for_certification_date  = Mapped[datetime]
    auditor_certified_date  = Mapped[datetime]
    auditee_certified_date  = Mapped[datetime]
    submitted_date  = Mapped[datetime]
    fac_accepted_date  = Mapped[datetime]
    fy_end_date  = Mapped[datetime]
    fy_start_date  = Mapped[datetime]
    audit_type  = Mapped[str]
    gaap_results  = Mapped[str]
    sp_framework_basis  = Mapped[str]
    is_sp_framework_required  = Mapped[str]
    sp_framework_opinions  = Mapped[str]
    is_going_concern_included = Mapped[bool]
    is_internal_control_deficiency_disclosed = Mapped[bool]
    is_internal_control_material_weakness_disclosed =Mapped[bool]
    is_material_noncompliance_disclosed =Mapped[bool]
    dollar_threshold = Mapped[Decimal]
    is_low_risk_auditee =Mapped[bool]
    agencies_with_prior_findings = Mapped[str]
    entity_type  = Mapped[str]
    number_months  = Mapped[str]
    audit_period_covered  = Mapped[str]
    total_amount_expended = Mapped[str]
    type_audit_code  = Mapped[str]
    is_public =Mapped[bool]