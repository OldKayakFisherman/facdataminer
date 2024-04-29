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
    multipleueis  = models.CharField
