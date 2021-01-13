<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">
    <Info>
      <SellerIdentity>
        <xsl:choose>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/EndpointID">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID">
            <xsl:value-of select="Invoice/AccountingSupplierParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingSupplierParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/EndpointID">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID">
            <xsl:value-of select="CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingSupplierParty/Party/PartyIdentification/ID" />
          </xsl:when>
        </xsl:choose>
      </SellerIdentity>
      <BuyerIdentity>
        <xsl:choose>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/EndpointID">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="Invoice/AccountingCustomerParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/Invoice/AccountingCustomerParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/EndpointID">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/EndpointID" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0088']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID[@schemeID='0007']" />
          </xsl:when>
          <xsl:when test="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID">
            <xsl:value-of select="StandardBusinessDocument/CreditNote/AccountingCustomerParty/Party/PartyIdentification/ID" />
          </xsl:when>
        </xsl:choose>
      </BuyerIdentity>
    </Info>
  </xsl:template>

</xsl:stylesheet>

