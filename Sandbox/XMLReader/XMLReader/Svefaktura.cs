
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader", IsNullable = false)]
public partial class StandardBusinessDocument
{

    private StandardBusinessDocumentStandardBusinessDocumentHeader standardBusinessDocumentHeaderField;

    private Invoice invoiceField;

    private ObjectEnvelope[] objectEnvelopeField;

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeader StandardBusinessDocumentHeader
    {
        get
        {
            return this.standardBusinessDocumentHeaderField;
        }
        set
        {
            this.standardBusinessDocumentHeaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:documents:BasicInvoice:1:0")]
    public Invoice Invoice
    {
        get
        {
            return this.invoiceField;
        }
        set
        {
            this.invoiceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ObjectEnvelope", Namespace = "urn:sfti:documents:ObjectEnvelope:1:0")]
    public ObjectEnvelope[] ObjectEnvelope
    {
        get
        {
            return this.objectEnvelopeField;
        }
        set
        {
            this.objectEnvelopeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeader
{

    private decimal headerVersionField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderSender senderField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver receiverField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification documentIdentificationField;

    /// <remarks/>
    public decimal HeaderVersion
    {
        get
        {
            return this.headerVersionField;
        }
        set
        {
            this.headerVersionField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderSender Sender
    {
        get
        {
            return this.senderField;
        }
        set
        {
            this.senderField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver Receiver
    {
        get
        {
            return this.receiverField;
        }
        set
        {
            this.receiverField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification DocumentIdentification
    {
        get
        {
            return this.documentIdentificationField;
        }
        set
        {
            this.documentIdentificationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderSender
{

    private ulong identifierField;

    /// <remarks/>
    public ulong Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver
{

    private object identifierField;

    /// <remarks/>
    public object Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification
{

    private string standardField;

    private decimal typeVersionField;

    private uint instanceIdentifierField;

    private string typeField;

    private bool multipleTypeField;

    private System.DateTime creationDateAndTimeField;

    /// <remarks/>
    public string Standard
    {
        get
        {
            return this.standardField;
        }
        set
        {
            this.standardField = value;
        }
    }

    /// <remarks/>
    public decimal TypeVersion
    {
        get
        {
            return this.typeVersionField;
        }
        set
        {
            this.typeVersionField = value;
        }
    }

    /// <remarks/>
    public uint InstanceIdentifier
    {
        get
        {
            return this.instanceIdentifierField;
        }
        set
        {
            this.instanceIdentifierField = value;
        }
    }

    /// <remarks/>
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public bool MultipleType
    {
        get
        {
            return this.multipleTypeField;
        }
        set
        {
            this.multipleTypeField = value;
        }
    }

    /// <remarks/>
    public System.DateTime CreationDateAndTime
    {
        get
        {
            return this.creationDateAndTimeField;
        }
        set
        {
            this.creationDateAndTimeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:BasicInvoice:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:documents:BasicInvoice:1:0", IsNullable = false)]
public partial class Invoice
{

    private ulong idField;

    private System.DateTime issueDateField;

    private ushort invoiceTypeCodeField;

    private string noteField;

    private string invoiceCurrencyCodeField;

    private byte lineItemCountNumericField;

    private InvoiceAdditionalDocumentReference[] additionalDocumentReferenceField;

    private BuyerParty buyerPartyField;

    private SellerParty sellerPartyField;

    private Delivery deliveryField;

    private PaymentMeans[] paymentMeansField;

    private PaymentTerms paymentTermsField;

    private TaxTotal taxTotalField;

    private LegalTotal legalTotalField;

    private InvoiceLine invoiceLineField;

    private InvoiceRequisitionistDocumentReference requisitionistDocumentReferenceField;

    /// <remarks/>
    public ulong ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", DataType = "date")]
    public System.DateTime IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    /// <remarks/>
    public ushort InvoiceTypeCode
    {
        get
        {
            return this.invoiceTypeCodeField;
        }
        set
        {
            this.invoiceTypeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    /// <remarks/>
    public string InvoiceCurrencyCode
    {
        get
        {
            return this.invoiceCurrencyCodeField;
        }
        set
        {
            this.invoiceCurrencyCodeField = value;
        }
    }

    /// <remarks/>
    public byte LineItemCountNumeric
    {
        get
        {
            return this.lineItemCountNumericField;
        }
        set
        {
            this.lineItemCountNumericField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AdditionalDocumentReference")]
    public InvoiceAdditionalDocumentReference[] AdditionalDocumentReference
    {
        get
        {
            return this.additionalDocumentReferenceField;
        }
        set
        {
            this.additionalDocumentReferenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public BuyerParty BuyerParty
    {
        get
        {
            return this.buyerPartyField;
        }
        set
        {
            this.buyerPartyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public SellerParty SellerParty
    {
        get
        {
            return this.sellerPartyField;
        }
        set
        {
            this.sellerPartyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public Delivery Delivery
    {
        get
        {
            return this.deliveryField;
        }
        set
        {
            this.deliveryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PaymentMeans", Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public PaymentMeans[] PaymentMeans
    {
        get
        {
            return this.paymentMeansField;
        }
        set
        {
            this.paymentMeansField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public PaymentTerms PaymentTerms
    {
        get
        {
            return this.paymentTermsField;
        }
        set
        {
            this.paymentTermsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public TaxTotal TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public LegalTotal LegalTotal
    {
        get
        {
            return this.legalTotalField;
        }
        set
        {
            this.legalTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public InvoiceLine InvoiceLine
    {
        get
        {
            return this.invoiceLineField;
        }
        set
        {
            this.invoiceLineField = value;
        }
    }

    /// <remarks/>
    public InvoiceRequisitionistDocumentReference RequisitionistDocumentReference
    {
        get
        {
            return this.requisitionistDocumentReferenceField;
        }
        set
        {
            this.requisitionistDocumentReferenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:BasicInvoice:1:0")]
public partial class InvoiceAdditionalDocumentReference
{

    private ID idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class ID
{

    private string identificationSchemeIDField;

    private string identificationSchemeAgencyNameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string identificationSchemeID
    {
        get
        {
            return this.identificationSchemeIDField;
        }
        set
        {
            this.identificationSchemeIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string identificationSchemeAgencyName
    {
        get
        {
            return this.identificationSchemeAgencyNameField;
        }
        set
        {
            this.identificationSchemeAgencyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class BuyerParty
{

    private BuyerPartyParty partyField;

    /// <remarks/>
    public BuyerPartyParty Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyParty
{

    private BuyerPartyPartyPartyIdentification[] partyIdentificationField;

    private BuyerPartyPartyPartyName partyNameField;

    private BuyerPartyPartyAddress addressField;

    private BuyerPartyPartyPartyTaxScheme[] partyTaxSchemeField;

    private BuyerPartyPartyContact contactField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PartyIdentification")]
    public BuyerPartyPartyPartyIdentification[] PartyIdentification
    {
        get
        {
            return this.partyIdentificationField;
        }
        set
        {
            this.partyIdentificationField = value;
        }
    }

    /// <remarks/>
    public BuyerPartyPartyPartyName PartyName
    {
        get
        {
            return this.partyNameField;
        }
        set
        {
            this.partyNameField = value;
        }
    }

    /// <remarks/>
    public BuyerPartyPartyAddress Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PartyTaxScheme")]
    public BuyerPartyPartyPartyTaxScheme[] PartyTaxScheme
    {
        get
        {
            return this.partyTaxSchemeField;
        }
        set
        {
            this.partyTaxSchemeField = value;
        }
    }

    /// <remarks/>
    public BuyerPartyPartyContact Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyPartyIdentification
{

    private BuyerPartyPartyPartyIdentificationID idField;

    /// <remarks/>
    public BuyerPartyPartyPartyIdentificationID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyPartyIdentificationID
{

    private byte identificationSchemeAgencyIDField;

    private bool identificationSchemeAgencyIDFieldSpecified;

    private ulong valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte identificationSchemeAgencyID
    {
        get
        {
            return this.identificationSchemeAgencyIDField;
        }
        set
        {
            this.identificationSchemeAgencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool identificationSchemeAgencyIDSpecified
    {
        get
        {
            return this.identificationSchemeAgencyIDFieldSpecified;
        }
        set
        {
            this.identificationSchemeAgencyIDFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public ulong Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyPartyName
{

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyAddress
{

    private string streetNameField;

    private string cityNameField;

    private ushort postalZoneField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string StreetName
    {
        get
        {
            return this.streetNameField;
        }
        set
        {
            this.streetNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public ushort PostalZone
    {
        get
        {
            return this.postalZoneField;
        }
        set
        {
            this.postalZoneField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyPartyTaxScheme
{

    private string companyIDField;

    private BuyerPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

    /// <remarks/>
    public string CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    public BuyerPartyPartyPartyTaxSchemeTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyPartyTaxSchemeTaxScheme
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class BuyerPartyPartyContact
{

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class SellerParty
{

    private SellerPartyParty partyField;

    /// <remarks/>
    public SellerPartyParty Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyParty
{

    private SellerPartyPartyPartyName partyNameField;

    private SellerPartyPartyAddress addressField;

    private SellerPartyPartyPartyTaxScheme[] partyTaxSchemeField;

    private SellerPartyPartyContact contactField;

    /// <remarks/>
    public SellerPartyPartyPartyName PartyName
    {
        get
        {
            return this.partyNameField;
        }
        set
        {
            this.partyNameField = value;
        }
    }

    /// <remarks/>
    public SellerPartyPartyAddress Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PartyTaxScheme")]
    public SellerPartyPartyPartyTaxScheme[] PartyTaxScheme
    {
        get
        {
            return this.partyTaxSchemeField;
        }
        set
        {
            this.partyTaxSchemeField = value;
        }
    }

    /// <remarks/>
    public SellerPartyPartyContact Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyPartyName
{

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyAddress
{

    private string streetNameField;

    private string cityNameField;

    private ushort postalZoneField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string StreetName
    {
        get
        {
            return this.streetNameField;
        }
        set
        {
            this.streetNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public ushort PostalZone
    {
        get
        {
            return this.postalZoneField;
        }
        set
        {
            this.postalZoneField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyPartyTaxScheme
{

    private string companyIDField;

    private string exemptionReasonField;

    private SellerPartyPartyPartyTaxSchemeRegistrationAddress registrationAddressField;

    private SellerPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

    /// <remarks/>
    public string CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string ExemptionReason
    {
        get
        {
            return this.exemptionReasonField;
        }
        set
        {
            this.exemptionReasonField = value;
        }
    }

    /// <remarks/>
    public SellerPartyPartyPartyTaxSchemeRegistrationAddress RegistrationAddress
    {
        get
        {
            return this.registrationAddressField;
        }
        set
        {
            this.registrationAddressField = value;
        }
    }

    /// <remarks/>
    public SellerPartyPartyPartyTaxSchemeTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyPartyTaxSchemeRegistrationAddress
{

    private string cityNameField;

    private SellerPartyPartyPartyTaxSchemeRegistrationAddressCountry countryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    /// <remarks/>
    public SellerPartyPartyPartyTaxSchemeRegistrationAddressCountry Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyPartyTaxSchemeRegistrationAddressCountry
{

    private string identificationCodeField;

    /// <remarks/>
    public string IdentificationCode
    {
        get
        {
            return this.identificationCodeField;
        }
        set
        {
            this.identificationCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyPartyTaxSchemeTaxScheme
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class SellerPartyPartyContact
{

    private string nameField;

    private uint telephoneField;

    private uint telefaxField;

    private string electronicMailField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public uint Telephone
    {
        get
        {
            return this.telephoneField;
        }
        set
        {
            this.telephoneField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public uint Telefax
    {
        get
        {
            return this.telefaxField;
        }
        set
        {
            this.telefaxField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string ElectronicMail
    {
        get
        {
            return this.electronicMailField;
        }
        set
        {
            this.electronicMailField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class Delivery
{

    private System.DateTime actualDeliveryDateTimeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public System.DateTime ActualDeliveryDateTime
    {
        get
        {
            return this.actualDeliveryDateTimeField;
        }
        set
        {
            this.actualDeliveryDateTimeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class PaymentMeans
{

    private byte paymentMeansTypeCodeField;

    private System.DateTime duePaymentDateField;

    private PaymentMeansPayeeFinancialAccount payeeFinancialAccountField;

    /// <remarks/>
    public byte PaymentMeansTypeCode
    {
        get
        {
            return this.paymentMeansTypeCodeField;
        }
        set
        {
            this.paymentMeansTypeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", DataType = "date")]
    public System.DateTime DuePaymentDate
    {
        get
        {
            return this.duePaymentDateField;
        }
        set
        {
            this.duePaymentDateField = value;
        }
    }

    /// <remarks/>
    public PaymentMeansPayeeFinancialAccount PayeeFinancialAccount
    {
        get
        {
            return this.payeeFinancialAccountField;
        }
        set
        {
            this.payeeFinancialAccountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class PaymentMeansPayeeFinancialAccount
{

    private uint idField;

    private PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch financialInstitutionBranchField;

    private ulong paymentInstructionIDField;

    /// <remarks/>
    public uint ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch FinancialInstitutionBranch
    {
        get
        {
            return this.financialInstitutionBranchField;
        }
        set
        {
            this.financialInstitutionBranchField = value;
        }
    }

    /// <remarks/>
    public ulong PaymentInstructionID
    {
        get
        {
            return this.paymentInstructionIDField;
        }
        set
        {
            this.paymentInstructionIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch
{

    private PaymentMeansPayeeFinancialAccountFinancialInstitutionBranchFinancialInstitution financialInstitutionField;

    /// <remarks/>
    public PaymentMeansPayeeFinancialAccountFinancialInstitutionBranchFinancialInstitution FinancialInstitution
    {
        get
        {
            return this.financialInstitutionField;
        }
        set
        {
            this.financialInstitutionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class PaymentMeansPayeeFinancialAccountFinancialInstitutionBranchFinancialInstitution
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class PaymentTerms
{

    private string noteField;

    private byte penaltySurchargePercentField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public byte PenaltySurchargePercent
    {
        get
        {
            return this.penaltySurchargePercentField;
        }
        set
        {
            this.penaltySurchargePercentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class TaxTotal
{

    private TotalTaxAmount totalTaxAmountField;

    private TaxTotalTaxSubTotal taxSubTotalField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public TotalTaxAmount TotalTaxAmount
    {
        get
        {
            return this.totalTaxAmountField;
        }
        set
        {
            this.totalTaxAmountField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubTotal TaxSubTotal
    {
        get
        {
            return this.taxSubTotalField;
        }
        set
        {
            this.taxSubTotalField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class TotalTaxAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class TaxTotalTaxSubTotal
{

    private TaxableAmount taxableAmountField;

    private TaxAmount taxAmountField;

    private TaxTotalTaxSubTotalTaxCategory taxCategoryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public TaxableAmount TaxableAmount
    {
        get
        {
            return this.taxableAmountField;
        }
        set
        {
            this.taxableAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public TaxAmount TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubTotalTaxCategory TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class TaxableAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class TaxAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class TaxTotalTaxSubTotalTaxCategory
{

    private string idField;

    private decimal percentField;

    private TaxTotalTaxSubTotalTaxCategoryTaxScheme taxSchemeField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public decimal Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    /// <remarks/>
    public TaxTotalTaxSubTotalTaxCategoryTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class TaxTotalTaxSubTotalTaxCategoryTaxScheme
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class LegalTotal
{

    private LineExtensionTotalAmount lineExtensionTotalAmountField;

    private TaxExclusiveTotalAmount taxExclusiveTotalAmountField;

    private TaxInclusiveTotalAmount taxInclusiveTotalAmountField;

    private LegalTotalRoundOffAmount roundOffAmountField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public LineExtensionTotalAmount LineExtensionTotalAmount
    {
        get
        {
            return this.lineExtensionTotalAmountField;
        }
        set
        {
            this.lineExtensionTotalAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public TaxExclusiveTotalAmount TaxExclusiveTotalAmount
    {
        get
        {
            return this.taxExclusiveTotalAmountField;
        }
        set
        {
            this.taxExclusiveTotalAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public TaxInclusiveTotalAmount TaxInclusiveTotalAmount
    {
        get
        {
            return this.taxInclusiveTotalAmountField;
        }
        set
        {
            this.taxInclusiveTotalAmountField = value;
        }
    }

    /// <remarks/>
    public LegalTotalRoundOffAmount RoundOffAmount
    {
        get
        {
            return this.roundOffAmountField;
        }
        set
        {
            this.roundOffAmountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class LineExtensionTotalAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class TaxExclusiveTotalAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class TaxInclusiveTotalAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class LegalTotalRoundOffAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0", IsNullable = false)]
public partial class InvoiceLine
{

    private byte idField;

    private InvoicedQuantity invoicedQuantityField;

    private LineExtensionAmount lineExtensionAmountField;

    private InvoiceLineOrderLineReference orderLineReferenceField;

    private InvoiceLineAllowanceCharge allowanceChargeField;

    private InvoiceLineItem itemField;

    /// <remarks/>
    public byte ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public InvoicedQuantity InvoicedQuantity
    {
        get
        {
            return this.invoicedQuantityField;
        }
        set
        {
            this.invoicedQuantityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public LineExtensionAmount LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineOrderLineReference OrderLineReference
    {
        get
        {
            return this.orderLineReferenceField;
        }
        set
        {
            this.orderLineReferenceField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineAllowanceCharge AllowanceCharge
    {
        get
        {
            return this.allowanceChargeField;
        }
        set
        {
            this.allowanceChargeField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItem Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class InvoicedQuantity
{

    private string quantityUnitCodeField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string quantityUnitCode
    {
        get
        {
            return this.quantityUnitCodeField;
        }
        set
        {
            this.quantityUnitCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class LineExtensionAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineOrderLineReference
{

    private InvoiceLineOrderLineReferenceOrderReference orderReferenceField;

    /// <remarks/>
    public InvoiceLineOrderLineReferenceOrderReference OrderReference
    {
        get
        {
            return this.orderReferenceField;
        }
        set
        {
            this.orderReferenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineOrderLineReferenceOrderReference
{

    private object buyersIDField;

    /// <remarks/>
    public object BuyersID
    {
        get
        {
            return this.buyersIDField;
        }
        set
        {
            this.buyersIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineAllowanceCharge
{

    private bool chargeIndicatorField;

    private Amount amountField;

    private InvoiceLineAllowanceChargeAllowanceChargeBaseAmount allowanceChargeBaseAmountField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public bool ChargeIndicator
    {
        get
        {
            return this.chargeIndicatorField;
        }
        set
        {
            this.chargeIndicatorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public Amount Amount
    {
        get
        {
            return this.amountField;
        }
        set
        {
            this.amountField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineAllowanceChargeAllowanceChargeBaseAmount AllowanceChargeBaseAmount
    {
        get
        {
            return this.allowanceChargeBaseAmountField;
        }
        set
        {
            this.allowanceChargeBaseAmountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class Amount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineAllowanceChargeAllowanceChargeBaseAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineItem
{

    private string descriptionField;

    private InvoiceLineItemSellersItemIdentification sellersItemIdentificationField;

    private InvoiceLineItemTaxCategory taxCategoryField;

    private InvoiceLineItemBasePrice basePriceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public string Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemSellersItemIdentification SellersItemIdentification
    {
        get
        {
            return this.sellersItemIdentificationField;
        }
        set
        {
            this.sellersItemIdentificationField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemTaxCategory TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemBasePrice BasePrice
    {
        get
        {
            return this.basePriceField;
        }
        set
        {
            this.basePriceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineItemSellersItemIdentification
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineItemTaxCategory
{

    private string idField;

    private decimal percentField;

    private InvoiceLineItemTaxCategoryTaxScheme taxSchemeField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public decimal Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    /// <remarks/>
    public InvoiceLineItemTaxCategoryTaxScheme TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineItemTaxCategoryTaxScheme
{

    private string idField;

    /// <remarks/>
    public string ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
public partial class InvoiceLineItemBasePrice
{

    private PriceAmount priceAmountField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
    public PriceAmount PriceAmount
    {
        get
        {
            return this.priceAmountField;
        }
        set
        {
            this.priceAmountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:ubl:CommonBasicComponents:1:0", IsNullable = false)]
public partial class PriceAmount
{

    private string amountCurrencyIDField;

    private decimal valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amountCurrencyID
    {
        get
        {
            return this.amountCurrencyIDField;
        }
        set
        {
            this.amountCurrencyIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:BasicInvoice:1:0")]
public partial class InvoiceRequisitionistDocumentReference
{

    private ID idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:sfti:CommonAggregateComponents:1:0")]
    public ID ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:ObjectEnvelope:1:0")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:sfti:documents:ObjectEnvelope:1:0", IsNullable = false)]
public partial class ObjectEnvelope
{

    private ObjectEnvelopeDocumentReference documentReferenceField;

    private System.DateTime creationDateTimeField;

    private ObjectEnvelopeEncodedObject encodedObjectField;

    /// <remarks/>
    public ObjectEnvelopeDocumentReference DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    /// <remarks/>
    public System.DateTime CreationDateTime
    {
        get
        {
            return this.creationDateTimeField;
        }
        set
        {
            this.creationDateTimeField = value;
        }
    }

    /// <remarks/>
    public ObjectEnvelopeEncodedObject EncodedObject
    {
        get
        {
            return this.encodedObjectField;
        }
        set
        {
            this.encodedObjectField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:ObjectEnvelope:1:0")]
public partial class ObjectEnvelopeDocumentReference
{

    private ulong documentIDField;

    private System.DateTime issueDateField;

    private string issuerIDField;

    private string documentTypeField;

    /// <remarks/>
    public ulong DocumentID
    {
        get
        {
            return this.documentIDField;
        }
        set
        {
            this.documentIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    /// <remarks/>
    public string IssuerID
    {
        get
        {
            return this.issuerIDField;
        }
        set
        {
            this.issuerIDField = value;
        }
    }

    /// <remarks/>
    public string DocumentType
    {
        get
        {
            return this.documentTypeField;
        }
        set
        {
            this.documentTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:ObjectEnvelope:1:0")]
public partial class ObjectEnvelopeEncodedObject
{

    private ulong objectIDField;

    private ObjectEnvelopeEncodedObjectEncodedData encodedDataField;

    /// <remarks/>
    public ulong ObjectID
    {
        get
        {
            return this.objectIDField;
        }
        set
        {
            this.objectIDField = value;
        }
    }

    /// <remarks/>
    public ObjectEnvelopeEncodedObjectEncodedData EncodedData
    {
        get
        {
            return this.encodedDataField;
        }
        set
        {
            this.encodedDataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sfti:documents:ObjectEnvelope:1:0")]
public partial class ObjectEnvelopeEncodedObjectEncodedData
{

    private string formatField;

    private string mimeCodeField;

    private string filenameField;

    private string dtField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mimeCode
    {
        get
        {
            return this.mimeCodeField;
        }
        set
        {
            this.mimeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string filename
    {
        get
        {
            return this.filenameField;
        }
        set
        {
            this.filenameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:datatypes")]
    public string dt
    {
        get
        {
            return this.dtField;
        }
        set
        {
            this.dtField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

