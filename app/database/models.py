from sqlalchemy import Integer, String, BigInteger, ForeignKey
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.orm import DeclarativeBase

from datetime import datetime
from typing import List

class Base(DeclarativeBase):
  pass

class GSAInjestLog(Base):

	__tablename__ = "gsa_injection_log"

	id: Mapped[int] = mapped_column(primary_key=True)
	reports_injested : Mapped[datetime]
	collection_date : Mapped[datetime]
	injection_date: Mapped[datetime]

class General(Base):
  
	__tablename__ = "general"

	id: Mapped[int] = mapped_column(primary_key=True)
	report_id: Mapped[str] = mapped_column(index=True)
	audit_year: Mapped[str]	= mapped_column(index=True)
	entity_type: Mapped[str]	
	fy_start_date: Mapped[datetime]	
	fy_end_date: Mapped[datetime]	
	audit_type: Mapped[str]	
	audit_period_covered: Mapped[str]	
	number_months: Mapped[str]	
	auditee_ein: Mapped[str]	
	auditee_name: Mapped[str] = mapped_column(index=True)	
	auditee_address_line_1: Mapped[str]	
	auditee_city: Mapped[str]	
	auditee_state: Mapped[str]
	auditee_zip: Mapped[str]
	auditee_contact_name: Mapped[str]	
	auditee_contact_title: Mapped[str]	
	auditee_phone: Mapped[str]	
	auditee_email: Mapped[str]	
	auditee_certified_date: Mapped[datetime]	
	auditor_firm_name: Mapped[str]	
	auditor_address_line_1: Mapped[str]	
	auditor_city: Mapped[str]	
	auditor_state: Mapped[str]	
	auditor_zip: Mapped[str]
	auditor_contact_name: Mapped[str]
	auditor_contact_title: Mapped[str]
	auditor_phone: Mapped[str]	
	auditor_email: Mapped[str]	
	auditor_certified_date: Mapped[datetime]
	cognizant_agency: Mapped[str]	
	oversight_agency: Mapped[str]	
	gaap_results: Mapped[str]
	sp_framework_basis: Mapped[str]	
	sp_framework_opinions: Mapped[str]
	is_going_concern_included: Mapped[bool]	
	is_internal_control_material_weakness_disclosed: Mapped[bool]
	is_aicpa_audit_guide_included: Mapped[bool]
	dollar_threshold: Mapped[BigInteger]
	is_low_risk_auditee: Mapped[bool]
	total_amount_expended: Mapped[BigInteger]
	auditor_ein: Mapped[str]
	fac_accepted_date: Mapped[datetime]
	auditor_foreign_address: Mapped[str]
	auditor_country: Mapped[str]
	auditee_uei: Mapped[str]
	is_additional_ueis: Mapped[bool]
	auditee_certify_name: Mapped[str]
	auditee_certify_title: Mapped[str]
	is_sp_framework_required: Mapped[bool]
	is_internal_control_deficiency_disclosed: Mapped[bool]
	is_material_noncompliance_disclosed: Mapped[bool]
	date_created: Mapped[datetime] = mapped_column(index=True)
	type_audit_code: Mapped[str]
	is_public: Mapped[bool]
	ready_for_certification_date: Mapped[datetime]
	data_source: Mapped[str]
	dbkey: Mapped[int]
	is_secondary_auditors: Mapped[str]
	date_injested: Mapped[datetime]
	prior_findings: Mapped[List["PriorFindings"]] = relationship(back_populates="general")
	federal_awards: Mapped[List["FederalAwards"]] = relationship(back_populates="general") 
	notes_to_sefa: Mapped["NotesToSefa"] = relationship(back_populates="general") 
	findings: Mapped[List["Findings"]] = relationship(back_populates="general") 
	findings_text: Mapped[List["FindingsText"]] = relationship(back_populates="general") 
	corrective_action_plan: Mapped["CorrectiveActionPlans"] = relationship(back_populates="general")
	passthroughs: Mapped[List["FindingsText"]] = relationship(back_populates="general") 
	secondary_auditors: Mapped[List["SecondaryAuditors"]] = relationship(back_populates="general") 
	additional_ueis: Mapped[List["AdditionalUEIs"]] = relationship(back_populates="general")
	additional_eins: Mapped[List["AdditionalEINs"]] = relationship(back_populates="general")

class PriorFindings(Base):
	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="prior_findings")
	agency: Mapped[str]


class FederalAwards(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="prior_findings")
	federal_agency_prefix: Mapped[str]
	federal_award_extension: Mapped[str]
	additional_award_identification: Mapped[str]
	federal_program_name: Mapped[str]
	amount_expended: Mapped[BigInteger]
	cluster_name: Mapped[str]
	state_cluster_name: Mapped[str]
	federal_program_total: Mapped[BigInteger]
	cluster_total: Mapped[BigInteger]
	is_direct: Mapped[bool]
	is_passthrough_award: Mapped[bool]
	passthrough_amount: Mapped[BigInteger]
	is_major: Mapped[bool]
	audit_report_type: Mapped[str]
	finding_ref_number: Mapped[str]
	is_loan: Mapped[bool]
	loan_balance: Mapped[str]
	findings_count: Mapped[int]
	award_reference: Mapped[str]
	other_cluster_name: Mapped[str]


class NotesToSefa(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="notes_to_sefa")
	title: Mapped[str]
	content: Mapped[str]
	accounting_policies: Mapped[str]
	is_minimis_rate_used: Mapped[str]
	rate_explained: Mapped[str]
	contains_chart_or_table: Mapped[str]


class Findings(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="findings")
	reference_number: Mapped[str]
	type_requirement: Mapped[str]
	is_modified_opinion: Mapped[bool]
	is_other_matters: Mapped[bool]
	is_material_weakness: Mapped[bool]
	is_significant_deficiency: Mapped[bool]
	is_other_findings: Mapped[bool]
	is_questioned_costs: Mapped[bool]
	is_repeat_finding: Mapped[bool]
	prior_finding_ref_numbers: Mapped[str]

class FindingsText(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="findings_text")
	finding_ref_number: Mapped[str]
	finding_text: Mapped[str]
	contains_chart_or_table: Mapped[str]

class CorrectiveActionPlans(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="corrective_action_plan")
	finding_ref_number: Mapped[str]
	planned_action: Mapped[str]
	contains_chart_or_table: Mapped[str]

class Passthroughs(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="passthroughs")
	award_reference: Mapped[str]
	passthrough_name: Mapped[str]
	passthrough_id: Mapped[str]


class SecondaryAuditors(Base):


	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="secondary_auditors")
	auditor_name: Mapped[str]
	auditor_ein: Mapped[str]
	address_street: Mapped[str]
	address_city: Mapped[str]
	address_state: Mapped[str]
	address_zipcode: Mapped[str]
	contact_name: Mapped[str]
	contact_title: Mapped[str]
	contact_phone: Mapped[str]
	contact_email: Mapped[str]

class AdditionalUEIs(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="additional_ueis")
	uei: Mapped[str]


class AdditionalEINs(Base):

	id: Mapped[int] = mapped_column(primary_key=True)
	general_id: Mapped[int] = mapped_column(ForeignKey("gsa_general.id"))
	general = relationship("General", back_populates="additional_eins")
	ein: Mapped[str]

