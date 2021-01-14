<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">
    <Info>
      <SellerIdentity>
        <xsl:choose>
          <xsl:when test="Invoice/SellerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']">
            <xsl:value-of select="Invoice/SellerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/SellerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/SellerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']" />
          </xsl:when>		  
          <xsl:when test="Invoice/SellerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="Invoice/SellerParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/SellerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/SellerParty/Party/PartyIdentification/ID" />
          </xsl:when>		  
        </xsl:choose>
      </SellerIdentity>
      <BuyerIdentity>
        <xsl:choose>
          <xsl:when test="Invoice/BuyerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']">
            <xsl:value-of select="Invoice/BuyerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']" />
          </xsl:when>
		  <xsl:when test="StandardBusinessDocument/Invoice/BuyerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/BuyerParty/Party/PartyIdentification/ID[@identificationSchemeAgencyID='9']" />
          </xsl:when>
          <xsl:when test="Invoice/BuyerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="Invoice/BuyerParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/BuyerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/BuyerParty/Party/PartyIdentification/ID" />
          </xsl:when>
      </xsl:choose>
      </BuyerIdentity>
    </Info>  
  </xsl:template>

</xsl:stylesheet>

