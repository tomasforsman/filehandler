<?xml version="1.0" encoding="UTF-8"?>

<!--

2007-12-11 Martin Landström
**** IMPORT till PRIWeb ****
- Mallen som denna XSLT-fil skall arbeta mot måste ha obligatoriska fält för att 
  att importen skall fungera. 
- Mallen som används i PRIWeb skall importera XML (SVE-faktura-format). 
- Numeriska fält skall ha punkt som decimalavskiljare
- Filen laddas upp till PRIWeb och innan den sparas ned till temporära tabeller
  transformeras den till PRIWeb-XML-format

-->

<xsl:stylesheet version="1.0"
                xmlns="urn:sfti:documents:BasicInvoice:1:0"
                xmlns:cac="urn:sfti:CommonAggregateComponents:1:0" 
                xmlns:cbc="urn:oasis:names:tc:ubl:CommonBasicComponents:1:0" 
                xmlns:ccts="urn:oasis:names:tc:ubl:CoreComponentParameters:1:0" 
                xmlns:cur="urn:oasis:names:tc:ubl:codelist:CurrencyCode:1:0" 
                xmlns:sdt="urn:oasis:names:tc:ubl:SpecializedDatatypes:1:0" 
                xmlns:udt="urn:oasis:names:tc:ubl:UnspecializedDatatypes:1:0" 
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
								xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
>

	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
  
	<xsl:template match="/">
    <PRIWEB>
      <xsl:apply-templates select="Invoice"/>
      <xsl:apply-templates select="StandardBusinessDocument/Invoice"/>
		</PRIWEB>
	</xsl:template>
	
	<xsl:template match="Invoice">
		<FAKTURA>
			<FAKTURAHUVUD>
				<H_Typ_av_faktura><xsl:value-of select="InvoiceTypeCode"/></H_Typ_av_faktura>
				<H_Fakturanr><xsl:value-of select="ID"/></H_Fakturanr>
				<H_Fakturadatum><xsl:value-of select="substring(cbc:IssueDate,0,11)"/></H_Fakturadatum>
		    <H_Leveransdatum><xsl:value-of select="substring(cac:Delivery/cbc:ActualDeliveryDateTime,0,11)"/></H_Leveransdatum>
				<H_Forfallodatum><xsl:value-of select="substring(cac:PaymentMeans/cbc:DuePaymentDate,0,11)"/></H_Forfallodatum>
  			<H_Bet_Valuta><xsl:value-of select="InvoiceCurrencyCode"/></H_Bet_Valuta>
  			<H_Bet_Villkor_Text1><xsl:value-of select="cac:PaymentTerms/cbc:Note"/></H_Bet_Villkor_Text1>
  			
        <!-- Seller info -->
        <xsl:apply-templates select="cac:SellerParty/cac:Party"/>

        <!-- Buyer info -->
        <xsl:apply-templates select="cac:BuyerParty/cac:Party"/>

        <!-- Delivery address -->
        <xsl:apply-templates select="cac:Delivery/cac:DeliveryAddress"/>
        
        <!-- VAT info -->
        <H_MOMS_Total_moms><xsl:value-of select="cac:TaxTotal/cbc:TotalTaxAmount"/></H_MOMS_Total_moms>
		    <xsl:for-each select="cac:TaxTotal/cac:TaxSubTotal">
		      <xsl:if test="position()&lt;=3">
		        <xsl:element name="H_MOMS_Kategori{position()}"><xsl:value-of select="cac:TaxCategory/cac:ID"/></xsl:element>
				<xsl:element name="H_MOMS_Typ{position()}"><xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cac:ID"/></xsl:element>
		        <xsl:element name="H_MOMS_Momspliktigt_belopp{position()}"><xsl:value-of select="cbc:TaxableAmount"/></xsl:element>
		        <xsl:element name="H_MOMS_Momsbelopp{position()}"><xsl:value-of select="cbc:TaxAmount"/></xsl:element>
		        <xsl:element name="H_MOMS_Procent{position()}"><xsl:value-of select="cac:TaxCategory/cbc:Percent"/></xsl:element>
				<xsl:element name="H_ANM_Omv_Skatt_Bygg{position()}"><xsl:value-of select="cac:TaxCategory/cbc:ExemptionReason"/></xsl:element>
          </xsl:if>
		    </xsl:for-each>
				
				<!-- References -->
				<xsl:for-each select="AdditionalDocumentReference">
				  <xsl:choose>
				    <xsl:when test="cac:ID[@identificationSchemeID='DQ']"><H_REF_Leveransavi><xsl:value-of select="cac:ID"/></H_REF_Leveransavi></xsl:when>
				    <xsl:when test="cac:ID[@identificationSchemeID='ACD']"><H_REF_Saljarens_bestnr><xsl:value-of select="cac:ID"/></H_REF_Saljarens_bestnr></xsl:when>
				    <xsl:when test="cac:ID[@identificationSchemeID='ON']"><H_REF_Koparens_referens><xsl:value-of select="cac:ID"/></H_REF_Koparens_referens></xsl:when>
            <xsl:when test="cac:ID[@identificationSchemeID='ORDER']"><H_REF_Koparens_referens><xsl:value-of select="cac:ID"/></H_REF_Koparens_referens></xsl:when>
				    <xsl:when test="cac:ID[@identificationSchemeID='CR']"><H_REF_Markning><xsl:value-of select="cac:ID"/></H_REF_Markning></xsl:when>
				    <xsl:when test="cac:ID[@identificationSchemeID='AEP']"><H_REF_Projektnr><xsl:value-of select="cac:ID"/></H_REF_Projektnr></xsl:when>
				  </xsl:choose>
				</xsl:for-each>

        <xsl:choose>
          <xsl:when test="AdditionalDocumentReference/cac:ID[@identificationSchemeID='AEP']"></xsl:when>
          <xsl:when test="AdditionalDocumentReference/cac:ID[@identificationSchemeID='CT']">
            <H_REF_Projektnr><xsl:value-of select="AdditionalDocumentReference/cac:ID[@identificationSchemeID='CT']"/></H_REF_Projektnr>
          </xsl:when>
        </xsl:choose>

        <xsl:choose>
				  <xsl:when test="AdditionalDocumentReference/cac:ID[@identificationSchemeID='CR']"></xsl:when>
				  <xsl:otherwise>
				    <H_REF_Markning>
              <xsl:value-of select="RequisitionistDocumentReference[1]/cac:ID"/>
              <!--<xsl:for-each select="RequisitionistDocumentReference"><xsl:value-of select="cac:ID"/><xsl:text>&#10;</xsl:text></xsl:for-each>-->
				    </H_REF_Markning>
            <H_REF_Markning_2_SVE>
              <xsl:value-of select="RequisitionistDocumentReference[2]/cac:ID"/>
            </H_REF_Markning_2_SVE>
          </xsl:otherwise>
				</xsl:choose>

        <xsl:if test="AdditionalDocumentReference/cac:ID[@identificationSchemeID='CT'] and AdditionalDocumentReference/cac:ID[@identificationSchemeID!='AEP']">
          <H_REF_Projektnr>
            <xsl:value-of select="AdditionalDocumentReference/cac:ID[@identificationSchemeID='CT']"/>
          </H_REF_Projektnr>
        </xsl:if>
          
        <xsl:choose>
				  <xsl:when test="AdditionalDocumentReference/cac:ID[@identificationSchemeID='ON']"></xsl:when>
				  <xsl:otherwise>
			      <xsl:call-template name="Start" />
				  </xsl:otherwise>
				</xsl:choose>
				
        <!--<H_REF_Koparens_referens><xsl:value-of select="RequisitionistDocumentReference/cac:ID"/></H_REF_Koparens_referens>-->
        <H_REF_Avser_faktura><xsl:value-of select="InitialInvoiceDocumentReference"/></H_REF_Avser_faktura>
		    <xsl:choose>
          <xsl:when test="cac:PaymentMeans/cac:PayeeFinancialAccount[1]/cac:PaymentInstructionID!=''">
            <H_REF_Betalningsreferens><xsl:value-of select="cac:PaymentMeans/cac:PayeeFinancialAccount[1]/cac:PaymentInstructionID"/></H_REF_Betalningsreferens>
          </xsl:when>
          <xsl:when test="cac:PaymentMeans/cac:PayeeFinancialAccount[2]/cac:PaymentInstructionID!=''">
            <H_REF_Betalningsreferens><xsl:value-of select="cac:PaymentMeans/cac:PayeeFinancialAccount[2]/cac:PaymentInstructionID"/></H_REF_Betalningsreferens>
          </xsl:when>
        </xsl:choose>
				
				<!-- Remarks -->
	      <H_ANM_LA1><xsl:value-of select="substring(cbc:Note,1,70)"/></H_ANM_LA1>
	      <H_ANM_LA2><xsl:value-of select="substring(cbc:Note,71,70)"/></H_ANM_LA2>
	      <H_ANM_LA3><xsl:value-of select="substring(cbc:Note,141,70)"/></H_ANM_LA3>
	      <H_ANM_LA4><xsl:value-of select="substring(cbc:Note,211,70)"/></H_ANM_LA4>
        <H_ANM_LA5><xsl:value-of select="substring(cbc:Note,281,70)"/></H_ANM_LA5>
        <H_ANM_IP1><xsl:value-of select="cac:DeliveryTerms/cbc:SpecialTerms"/></H_ANM_IP1>

        <!-- Charges -->
        <xsl:for-each select="AllowanceCharge">
          <xsl:if test="position()&lt;=10">
            <xsl:element name="H_TA_Indikator{position()}">
              <xsl:choose>
					      <xsl:when test="cbc:ChargeIndicator='0' or cbc:ChargeIndicator='false' or cbc:ChargeIndicator='False'">A</xsl:when>
					      <xsl:when test="cbc:ChargeIndicator='1' or cbc:ChargeIndicator='true' or cbc:ChargeIndicator='True'">C</xsl:when>
				      </xsl:choose>
				    </xsl:element>
				    <xsl:element name="H_TA_Beskrivning{position()}"><xsl:value-of select="cac:ReasonCode/@name"/></xsl:element>
				    <xsl:element name="H_TA_Belopp{position()}"><xsl:value-of select="cbc:Amount"/></xsl:element>
				    <xsl:element name="H_TA_Typ{position()}">
				      <xsl:choose>
				        <xsl:when test="cbc:ChargeIndicator='0' or cbc:ChargeIndicator='false' or cbc:ChargeIndicator='False'">DI</xsl:when>
				        <xsl:otherwise>PO</xsl:otherwise>
				      </xsl:choose>
				      <!--<xsl:value-of select="cac:ReasonCode"/>-->
				    </xsl:element>
				  </xsl:if>
        </xsl:for-each>

        <!-- Payment info -->
		    <xsl:for-each select="cac:PaymentMeans/cac:PayeeFinancialAccount">
			    <xsl:choose>
				    <xsl:when test="cac:FinancialInstitutionBranch/cac:FinancialInstitution/cac:ID='BGABSESS'">
				      <H_S_Bankgiro><xsl:value-of select="cac:ID"/></H_S_Bankgiro>
				    </xsl:when>
				    <xsl:when test="cac:FinancialInstitutionBranch/cac:FinancialInstitution/cac:ID='PGSISESS'">
				      <H_S_Postgiro><xsl:value-of select="cac:ID"/></H_S_Postgiro>
				    </xsl:when>
			    </xsl:choose>
		    </xsl:for-each>

        <!-- Sum info -->
        <xsl:variable name="resTotal" select="sum(AllowanceCharge[not(ChargeIndicator)]/Amount) + sum(AllowanceCharge[ChargeIndicator!='false' and ChargeIndicator!='False' and ChargeIndicator!='0']/Amount) - sum(AllowanceCharge[ChargeIndicator='false']/Amount) - sum(AllowanceCharge[ChargeIndicator='False']/Amount) - sum(AllowanceCharge[ChargeIndicator='0']/Amount)"/>
		    <xsl:variable name="resTotalString"><xsl:if test="$resTotal!=0"><xsl:value-of select='format-number($resTotal, "#.00")'/></xsl:if></xsl:variable>
        <H_Summa_Detaljrader><xsl:value-of select="LegalTotal/LineExtensionTotalAmount"/></H_Summa_Detaljrader>
        <H_Summa_ExklMoms><xsl:value-of select="LegalTotal/TaxExclusiveTotalAmount"/></H_Summa_ExklMoms>
		    <H_Summa_TillAvdr><xsl:value-of select='$resTotalString'/></H_Summa_TillAvdr>
        <H_Att_betala><xsl:value-of select="cac:LegalTotal/cbc:TaxInclusiveTotalAmount"/></H_Att_betala>
        <H_Oresutjamning><xsl:value-of select="cac:LegalTotal/cac:RoundOffAmount"/></H_Oresutjamning>
        
			</FAKTURAHUVUD>

			<!-- Iterate invoice lines -->
			<xsl:apply-templates select="cac:InvoiceLine"/>
       
		</FAKTURA>
	</xsl:template>

	<xsl:template name="Start">
	  <xsl:variable name="InitValue" select="cac:InvoiceLine[1]/cac:OrderLineReference[1]/cac:OrderReference[1]/cac:BuyersID" />
	  <xsl:variable name="ValueToAdd">
      <xsl:for-each select="cac:InvoiceLine/cac:OrderLineReference/cac:OrderReference">
        <xsl:choose>
          <xsl:when test="cac:BuyersID!=$InitValue">
            <xsl:value-of select="cac:BuyersID"/>
          </xsl:when>
        </xsl:choose>
		  </xsl:for-each>
		</xsl:variable>
		
		<xsl:if test="$ValueToAdd=''">
		  <H_REF_Koparens_referens><xsl:value-of select="$InitValue"/></H_REF_Koparens_referens>
		</xsl:if>
	</xsl:template>
	
	<xsl:template match="cac:BuyerParty/cac:Party">
	  <!--
    <xsl:for-each select="cac:PartyIdentification">
      <xsl:if test="cac:ID/@identificationSchemeAgencyID='9'">
 		    <H_K_Identitet><xsl:value-of select="cac:ID"/></H_K_Identitet>
      </xsl:if>
	  </xsl:for-each>
    -->
	  <!--
    <xsl:if test="cac:PartyIdentification/cac:ID/@identificationSchemeAgencyID='9'">
 		  <H_K_Identitet><xsl:value-of select="cac:PartyIdentification/cac:ID"/></H_K_Identitet>
    </xsl:if>
    -->
    <xsl:choose>
      <xsl:when test="cac:PartyIdentification/cac:ID[@identificationSchemeAgencyID='9']">
        <H_K_Identitet><xsl:value-of select="cac:PartyIdentification/cac:ID[@identificationSchemeAgencyID='9']" /></H_K_Identitet>
      </xsl:when>
      <xsl:when test="cac:PartyIdentification/cac:ID">
        <H_K_Identitet><xsl:value-of select="cac:PartyIdentification/cac:ID" /></H_K_Identitet>
      </xsl:when>
    </xsl:choose>
		<H_K_Namn><xsl:value-of select="cac:PartyName/cbc:Name"/></H_K_Namn>
		<H_K_GataBox><xsl:value-of select="cac:Address/cbc:StreetName"/></H_K_GataBox>
		<H_K_Ort><xsl:value-of select="cac:Address/cbc:CityName"/></H_K_Ort>
		<H_K_Postnr><xsl:value-of select="cac:Address/cbc:PostalZone"/></H_K_Postnr>
		<H_K_Land><xsl:value-of select="cac:Address/cac:Country/cac:IdentificationCode"/></H_K_Land>
		<H_K_KONTAKT_Namn><xsl:value-of select="cac:Contact/cbc:Name"/></H_K_KONTAKT_Namn>
		<H_K_KONTAKT_Telefon><xsl:value-of select="cac:Contact/cbc:Telephone"/></H_K_KONTAKT_Telefon>
		<H_K_KONTAKT_Fax><xsl:value-of select="cac:Contact/cbc:Telefax"/></H_K_KONTAKT_Fax>
		<H_K_KONTAKT_E-post><xsl:value-of select="cac:Contact/cbc:ElectronicMail"/></H_K_KONTAKT_E-post>
		<H_REF_Saljarens_kundnr><xsl:value-of select="cac:Address/cac:ID"/></H_REF_Saljarens_kundnr>
	</xsl:template>

	<xsl:template match="cac:SellerParty/cac:Party">
    <!--
    <xsl:for-each select="cac:PartyIdentification">
      <xsl:if test="cac:ID/@identificationSchemeAgencyID='9'">
 		    <H_S_Identitet><xsl:value-of select="cac:ID"/></H_S_Identitet>
      </xsl:if>
    </xsl:for-each>
    -->
    <xsl:choose>
      <xsl:when test="cac:PartyIdentification/cac:ID[@identificationSchemeAgencyID='9']">
        <H_S_Identitet><xsl:value-of select="cac:PartyIdentification/cac:ID[@identificationSchemeAgencyID='9']" /></H_S_Identitet>
      </xsl:when>
      <xsl:when test="cac:PartyIdentification/cac:ID">
        <H_S_Identitet><xsl:value-of select="cac:PartyIdentification/cac:ID" /></H_S_Identitet>
      </xsl:when>
    </xsl:choose>
    <H_S_Namn><xsl:value-of select="cac:PartyName/cbc:Name"/></H_S_Namn>
		<H_S_GataBox><xsl:value-of select="cac:Address/cbc:StreetName"/></H_S_GataBox>
		<H_S_Ort><xsl:value-of select="cac:Address/cbc:CityName"/></H_S_Ort>
		<H_S_Postnr><xsl:value-of select="cac:Address/cbc:PostalZone"/></H_S_Postnr>
		<H_S_Land><xsl:value-of select="cac:Address/cac:Country/cac:IdentificationCode"/></H_S_Land>
		<xsl:for-each select="cac:PartyTaxScheme">
		  <xsl:choose>
		    <xsl:when test="cac:TaxScheme/cac:ID='VAT'">
          <H_S_Momsregistreringsnr><xsl:value-of select="cac:CompanyID"/></H_S_Momsregistreringsnr>		      
		    </xsl:when>
		  </xsl:choose>
		</xsl:for-each>
		<H_S_KONTAKT_Namn>
			<xsl:choose>
				<xsl:when test="cac:Contact/cbc:Name!=''">
					<xsl:value-of select="cac:Contact/cbc:Name"/>
				</xsl:when>
				<xsl:when test="../cac:AccountsContact/cbc:Name!=''">
					<xsl:value-of select="../cac:AccountsContact/cbc:Name"/>
				</xsl:when>
			</xsl:choose>
		</H_S_KONTAKT_Namn>
		<H_S_KONTAKT_Telefon><xsl:value-of select="cac:Contact/cbc:Telephone"/></H_S_KONTAKT_Telefon>
		<H_S_KONTAKT_Fax><xsl:value-of select="cac:Contact/cbc:Telefax"/></H_S_KONTAKT_Fax>
		<H_S_KONTAKT_E-post><xsl:value-of select="cac:Contact/cbc:ElectronicMail"/></H_S_KONTAKT_E-post>


		<!--<H_MOMS_Typ1><xsl:value-of select="cac:PartyTaxScheme/cac:TaxScheme/cac:ID"/></H_MOMS_Typ1>-->
	</xsl:template>

	<xsl:template match="cac:Delivery/cac:DeliveryAddress">
    <xsl:if test="cac:ID!=''">
      <H_L_Identitet><xsl:value-of select="cac:ID"/></H_L_Identitet>
    </xsl:if>
		<H_L_Namn><xsl:value-of select="cbc:Department"/></H_L_Namn>
		<H_L_GataBox><xsl:value-of select="cbc:StreetName"/></H_L_GataBox>
		<H_L_Godsadress><xsl:value-of select="cac:AddressLine/cbc:Line"/></H_L_Godsadress>
		<H_L_Postnr><xsl:value-of select="cbc:PostalZone"/></H_L_Postnr>
		<H_L_Ort><xsl:value-of select="cbc:CityName"/></H_L_Ort>
		<H_L_Land><xsl:value-of select="cac:Country/cac:IdentificationCode"/></H_L_Land>
	
  </xsl:template>
	
  <!-- Invoice Lines -->
	<xsl:template match="cac:InvoiceLine">
		<FAKTURARAD>
			<R_Radnr><xsl:value-of select="cac:ID"/></R_Radnr>
			<R_Artikelnr_Saljarens><xsl:value-of select="cac:Item/cac:SellersItemIdentification/cac:ID"/></R_Artikelnr_Saljarens>
			<R_Artikelnr_Koparens><xsl:value-of select="cac:Item/cac:BuyersItemIdentification/cac:ID"/></R_Artikelnr_Koparens>
			<xsl:for-each select="cac:Item/cac:StandardItemIdentification">
			  <xsl:choose>
			    <xsl:when test="cac:ID">
			      <R_Artikelnr_EAN><xsl:value-of select="cac:ID"/></R_Artikelnr_EAN>
			    </xsl:when>
			  </xsl:choose>
			</xsl:for-each>
			<R_Beskrivning1><xsl:value-of select="substring(cac:Item/cbc:Description,1,35)"/></R_Beskrivning1>
			<R_Beskrivning2><xsl:value-of select="substring(cac:Item/cbc:Description,36,35)"/></R_Beskrivning2>
			<R_Kvantitet><xsl:value-of select="cbc:InvoicedQuantity"/></R_Kvantitet>
			<R_Enhet><xsl:value-of select="cbc:InvoicedQuantity/@quantityUnitCode"/></R_Enhet>
			<R_Pris><xsl:value-of select="cac:Item/cac:BasePrice/cbc:PriceAmount"/></R_Pris>
			<R_Prisbas><xsl:value-of select="cac:Item/cac:BasePrice/cbc:BaseQuantity"/></R_Prisbas>
			<R_Summa><xsl:value-of select="cbc:LineExtensionAmount"/></R_Summa>
			<R_Momsprocent><xsl:value-of select="cac:Item/cac:TaxCategory/cbc:Percent"/></R_Momsprocent>

      <!-- Remarks for Line --> 
	    <R_ANM_LA1><xsl:value-of select="substring(cbc:Note,1,70)"/></R_ANM_LA1>
      <R_ANM_LA2><xsl:value-of select="substring(cbc:Note,71,70)"/></R_ANM_LA2>
      <R_ANM_LA3><xsl:value-of select="substring(cbc:Note,141,70)"/></R_ANM_LA3>
	    <R_ANM_LA4><xsl:value-of select="substring(cbc:Note,211,70)"/></R_ANM_LA4>
	    <R_ANM_LA5><xsl:value-of select="substring(cbc:Note,281,70)"/></R_ANM_LA5>

			<!-- Charges for Line -->
			<xsl:for-each select="cac:AllowanceCharge">
			  <xsl:if test="position()&lt;=6">
		      <xsl:element name="R_TA_Just{position()}_Belopp">
		        <xsl:if test="cbc:ChargeIndicator='0' or cbc:ChargeIndicator='false' or cbc:ChargeIndicator='False'">
              <xsl:if test="number(cbc:Amount)!='NaN'">
                <xsl:if test="number(cbc:Amount)>0">-</xsl:if>
              </xsl:if>
            </xsl:if>
		        <xsl:value-of select="cbc:Amount"/>
		      </xsl:element>
		    </xsl:if>
			</xsl:for-each>

			<R_Koparens_bestradnr><xsl:value-of select="cac:OrderLineReference/cac:BuyersLineID"/></R_Koparens_bestradnr>
			<R_Koparens_bestnr><xsl:value-of select="cac:OrderLineReference/cac:OrderReference/cac:BuyersID"/></R_Koparens_bestnr>
		
		</FAKTURARAD>
	</xsl:template>
  
</xsl:stylesheet>

