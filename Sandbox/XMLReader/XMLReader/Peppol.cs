
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
namespace Hantverksdata.Peppol
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2",
        IsNullable = false)]
    public class Invoice
    {

        private string customizationIDField;

        private string profileIDField;

        private ID idField;

        private System.DateTime issueDateField;

        private ushort invoiceTypeCodeField;

        private string documentCurrencyCodeField;

        private ushort buyerReferenceField;

        //private AdditionalDocumentReference[] additionalDocumentReferenceField;

        private AccountingSupplierParty accountingSupplierPartyField;

        private AccountingCustomerParty accountingCustomerPartyField;

        private Delivery deliveryField;

        private PaymentMeans[] paymentMeansField;

        private PaymentTerms paymentTermsField;

        private TaxTotal taxTotalField;

        private LegalMonetaryTotal legalMonetaryTotalField;

        private InvoiceLine invoiceLineField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CustomizationID
        {
            get { return this.customizationIDField; }
            set { this.customizationIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileID
        {
            get { return this.profileIDField; }
            set { this.profileIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
        public System.DateTime IssueDate
        {
            get { return this.issueDateField; }
            set { this.issueDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ushort InvoiceTypeCode
        {
            get { return this.invoiceTypeCodeField; }
            set { this.invoiceTypeCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentCurrencyCode
        {
            get { return this.documentCurrencyCodeField; }
            set { this.documentCurrencyCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ushort BuyerReference
        {
            get { return this.buyerReferenceField; }
            set { this.buyerReferenceField = value; }
        }

        /// <remarks/>
        // [System.Xml.Serialization.XmlElementAttribute("AdditionalDocumentReference",
        //     Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        // public AdditionalDocumentReference[] AdditionalDocumentReference
        // {
        //     get { return this.additionalDocumentReferenceField; }
        //     set { this.additionalDocumentReferenceField = value; }
        // }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingSupplierParty AccountingSupplierParty
        {
            get { return this.accountingSupplierPartyField; }
            set { this.accountingSupplierPartyField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingCustomerParty AccountingCustomerParty
        {
            get { return this.accountingCustomerPartyField; }
            set { this.accountingCustomerPartyField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Delivery Delivery
        {
            get { return this.deliveryField; }
            set { this.deliveryField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PaymentMeans",
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PaymentMeans[] PaymentMeans
        {
            get { return this.paymentMeansField; }
            set { this.paymentMeansField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PaymentTerms PaymentTerms
        {
            get { return this.paymentTermsField; }
            set { this.paymentTermsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxTotal TaxTotal
        {
            get { return this.taxTotalField; }
            set { this.taxTotalField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public LegalMonetaryTotal LegalMonetaryTotal
        {
            get { return this.legalMonetaryTotalField; }
            set { this.legalMonetaryTotalField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public InvoiceLine InvoiceLine
        {
            get { return this.invoiceLineField; }
            set { this.invoiceLineField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class ID
    {

        private byte schemeIDField;

        private bool schemeIDFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte schemeID
        {
            get { return this.schemeIDField; }
            set { this.schemeIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool schemeIDSpecified
        {
            get { return this.schemeIDFieldSpecified; }
            set { this.schemeIDFieldSpecified = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    // [System.SerializableAttribute()]
    // [System.ComponentModel.DesignerCategoryAttribute("code")]
    // [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
    //     Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    // [System.Xml.Serialization.XmlRootAttribute(
    //     Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    // public partial class AdditionalDocumentReference
    // {
    //
    //     private ID idField;
    //
    //     private string documentDescriptionField;
    //
    //     private AdditionalDocumentReferenceAttachment attachmentField;
    //
    //     /// <remarks/>
    //     [System.Xml.Serialization.XmlElementAttribute(Namespace =
    //         "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    //     public ID ID
    //     {
    //         get { return this.idField; }
    //         set { this.idField = value; }
    //     }
    //
    //     /// <remarks/>
    //     [System.Xml.Serialization.XmlElementAttribute(Namespace =
    //         "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    //     public string DocumentDescription
    //     {
    //         get { return this.documentDescriptionField; }
    //         set { this.documentDescriptionField = value; }
    //     }
    //
    //     /// <remarks/>
    //     public AdditionalDocumentReferenceAttachment Attachment
    //     {
    //         get { return this.attachmentField; }
    //         set { this.attachmentField = value; }
    //     }
    // }

    /// <remarks/>
    // [System.SerializableAttribute()]
    // [System.ComponentModel.DesignerCategoryAttribute("code")]
    // [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
    //     Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    // public partial class AdditionalDocumentReferenceAttachment
    // {
    //
    //     private EmbeddedDocumentBinaryObject embeddedDocumentBinaryObjectField;
    //
    //     /// <remarks/>
    //     [System.Xml.Serialization.XmlElementAttribute(Namespace =
    //         "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    //     public EmbeddedDocumentBinaryObject EmbeddedDocumentBinaryObject
    //     {
    //         get { return this.embeddedDocumentBinaryObjectField; }
    //         set { this.embeddedDocumentBinaryObjectField = value; }
    //     }
    // }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class EmbeddedDocumentBinaryObject
    {

        private string mimeCodeField;

        private string filenameField;

        private string dtField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mimeCode
        {
            get { return this.mimeCodeField; }
            set { this.mimeCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string filename
        {
            get { return this.filenameField; }
            set { this.filenameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
            Namespace = "urn:schemas-microsoft-com:datatypes")]
        public string dt
        {
            get { return this.dtField; }
            set { this.dtField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class AccountingSupplierParty
    {

        private AccountingSupplierPartyParty partyField;

        /// <remarks/>
        public AccountingSupplierPartyParty Party
        {
            get { return this.partyField; }
            set { this.partyField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyParty
    {

        private EndpointID endpointIDField;

        private AccountingSupplierPartyPartyPostalAddress postalAddressField;

        private AccountingSupplierPartyPartyPartyTaxScheme[] partyTaxSchemeField;

        private AccountingSupplierPartyPartyPartyLegalEntity partyLegalEntityField;

        private AccountingSupplierPartyPartyContact contactField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public EndpointID EndpointID
        {
            get { return this.endpointIDField; }
            set { this.endpointIDField = value; }
        }

        /// <remarks/>
        public AccountingSupplierPartyPartyPostalAddress PostalAddress
        {
            get { return this.postalAddressField; }
            set { this.postalAddressField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PartyTaxScheme")]
        public AccountingSupplierPartyPartyPartyTaxScheme[] PartyTaxScheme
        {
            get { return this.partyTaxSchemeField; }
            set { this.partyTaxSchemeField = value; }
        }

        /// <remarks/>
        public AccountingSupplierPartyPartyPartyLegalEntity PartyLegalEntity
        {
            get { return this.partyLegalEntityField; }
            set { this.partyLegalEntityField = value; }
        }

        /// <remarks/>
        public AccountingSupplierPartyPartyContact Contact
        {
            get { return this.contactField; }
            set { this.contactField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class EndpointID
    {

        private byte schemeIDField;

        private ulong valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte schemeID
        {
            get { return this.schemeIDField; }
            set { this.schemeIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ulong Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyPostalAddress
    {

        private string cityNameField;

        private ushort postalZoneField;

        private AccountingSupplierPartyPartyPostalAddressCountry countryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName
        {
            get { return this.cityNameField; }
            set { this.cityNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ushort PostalZone
        {
            get { return this.postalZoneField; }
            set { this.postalZoneField = value; }
        }

        /// <remarks/>
        public AccountingSupplierPartyPartyPostalAddressCountry Country
        {
            get { return this.countryField; }
            set { this.countryField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyPostalAddressCountry
    {

        private string identificationCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IdentificationCode
        {
            get { return this.identificationCodeField; }
            set { this.identificationCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyPartyTaxScheme
    {

        private CompanyID companyIDField;

        private AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID
        {
            get { return this.companyIDField; }
            set { this.companyIDField = value; }
        }

        /// <remarks/>
        public AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme TaxScheme
        {
            get { return this.taxSchemeField; }
            set { this.taxSchemeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class CompanyID
    {

        private byte schemeIDField;

        private bool schemeIDFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte schemeID
        {
            get { return this.schemeIDField; }
            set { this.schemeIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool schemeIDSpecified
        {
            get { return this.schemeIDFieldSpecified; }
            set { this.schemeIDFieldSpecified = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyPartyTaxSchemeTaxScheme
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyPartyLegalEntity
    {

        private string registrationNameField;

        private CompanyID companyIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName
        {
            get { return this.registrationNameField; }
            set { this.registrationNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID
        {
            get { return this.companyIDField; }
            set { this.companyIDField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingSupplierPartyPartyContact
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class AccountingCustomerParty
    {

        private AccountingCustomerPartyParty partyField;

        /// <remarks/>
        public AccountingCustomerPartyParty Party
        {
            get { return this.partyField; }
            set { this.partyField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyParty
    {

        private EndpointID endpointIDField;

        private AccountingCustomerPartyPartyPartyIdentification partyIdentificationField;

        private AccountingCustomerPartyPartyPostalAddress postalAddressField;

        private AccountingCustomerPartyPartyPartyTaxScheme partyTaxSchemeField;

        private AccountingCustomerPartyPartyPartyLegalEntity partyLegalEntityField;

        private AccountingCustomerPartyPartyContact contactField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public EndpointID EndpointID
        {
            get { return this.endpointIDField; }
            set { this.endpointIDField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPartyIdentification PartyIdentification
        {
            get { return this.partyIdentificationField; }
            set { this.partyIdentificationField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPostalAddress PostalAddress
        {
            get { return this.postalAddressField; }
            set { this.postalAddressField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPartyTaxScheme PartyTaxScheme
        {
            get { return this.partyTaxSchemeField; }
            set { this.partyTaxSchemeField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPartyLegalEntity PartyLegalEntity
        {
            get { return this.partyLegalEntityField; }
            set { this.partyLegalEntityField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyContact Contact
        {
            get { return this.contactField; }
            set { this.contactField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPartyIdentification
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPostalAddress
    {

        private string streetNameField;

        private string cityNameField;

        private ushort postalZoneField;

        private AccountingCustomerPartyPartyPostalAddressCountry countryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StreetName
        {
            get { return this.streetNameField; }
            set { this.streetNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName
        {
            get { return this.cityNameField; }
            set { this.cityNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ushort PostalZone
        {
            get { return this.postalZoneField; }
            set { this.postalZoneField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPostalAddressCountry Country
        {
            get { return this.countryField; }
            set { this.countryField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPostalAddressCountry
    {

        private string identificationCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IdentificationCode
        {
            get { return this.identificationCodeField; }
            set { this.identificationCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPartyTaxScheme
    {

        private CompanyID companyIDField;

        private AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme taxSchemeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID
        {
            get { return this.companyIDField; }
            set { this.companyIDField = value; }
        }

        /// <remarks/>
        public AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme TaxScheme
        {
            get { return this.taxSchemeField; }
            set { this.taxSchemeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPartyTaxSchemeTaxScheme
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyPartyLegalEntity
    {

        private string registrationNameField;

        private CompanyID companyIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName
        {
            get { return this.registrationNameField; }
            set { this.registrationNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CompanyID CompanyID
        {
            get { return this.companyIDField; }
            set { this.companyIDField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class AccountingCustomerPartyPartyContact
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class Delivery
    {

        private System.DateTime actualDeliveryDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", DataType = "date")]
        public System.DateTime ActualDeliveryDate
        {
            get { return this.actualDeliveryDateField; }
            set { this.actualDeliveryDateField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class PaymentMeans
    {

        private byte paymentMeansCodeField;

        private ulong paymentIDField;

        private PaymentMeansPayeeFinancialAccount payeeFinancialAccountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public byte PaymentMeansCode
        {
            get { return this.paymentMeansCodeField; }
            set { this.paymentMeansCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ulong PaymentID
        {
            get { return this.paymentIDField; }
            set { this.paymentIDField = value; }
        }

        /// <remarks/>
        public PaymentMeansPayeeFinancialAccount PayeeFinancialAccount
        {
            get { return this.payeeFinancialAccountField; }
            set { this.payeeFinancialAccountField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class PaymentMeansPayeeFinancialAccount
    {

        private ID idField;

        private PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch financialInstitutionBranchField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        public PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch FinancialInstitutionBranch
        {
            get { return this.financialInstitutionBranchField; }
            set { this.financialInstitutionBranchField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class PaymentMeansPayeeFinancialAccountFinancialInstitutionBranch
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class PaymentTerms
    {

        private string noteField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Note
        {
            get { return this.noteField; }
            set { this.noteField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class TaxTotal
    {

        private TaxAmount taxAmountField;

        private TaxTotalTaxSubtotal taxSubtotalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount
        {
            get { return this.taxAmountField; }
            set { this.taxAmountField = value; }
        }

        /// <remarks/>
        public TaxTotalTaxSubtotal TaxSubtotal
        {
            get { return this.taxSubtotalField; }
            set { this.taxSubtotalField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class TaxAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class TaxTotalTaxSubtotal
    {

        private TaxableAmount taxableAmountField;

        private TaxAmount taxAmountField;

        private TaxTotalTaxSubtotalTaxCategory taxCategoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxableAmount TaxableAmount
        {
            get { return this.taxableAmountField; }
            set { this.taxableAmountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount
        {
            get { return this.taxAmountField; }
            set { this.taxAmountField = value; }
        }

        /// <remarks/>
        public TaxTotalTaxSubtotalTaxCategory TaxCategory
        {
            get { return this.taxCategoryField; }
            set { this.taxCategoryField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class TaxableAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class TaxTotalTaxSubtotalTaxCategory
    {

        private ID idField;

        private decimal percentField;

        private TaxTotalTaxSubtotalTaxCategoryTaxScheme taxSchemeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public decimal Percent
        {
            get { return this.percentField; }
            set { this.percentField = value; }
        }

        /// <remarks/>
        public TaxTotalTaxSubtotalTaxCategoryTaxScheme TaxScheme
        {
            get { return this.taxSchemeField; }
            set { this.taxSchemeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class TaxTotalTaxSubtotalTaxCategoryTaxScheme
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class LegalMonetaryTotal
    {

        private LineExtensionAmount lineExtensionAmountField;

        private TaxExclusiveAmount taxExclusiveAmountField;

        private TaxInclusiveAmount taxInclusiveAmountField;

        private PayableAmount payableAmountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount
        {
            get { return this.lineExtensionAmountField; }
            set { this.lineExtensionAmountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxExclusiveAmount TaxExclusiveAmount
        {
            get { return this.taxExclusiveAmountField; }
            set { this.taxExclusiveAmountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxInclusiveAmount TaxInclusiveAmount
        {
            get { return this.taxInclusiveAmountField; }
            set { this.taxInclusiveAmountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PayableAmount PayableAmount
        {
            get { return this.payableAmountField; }
            set { this.payableAmountField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class LineExtensionAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class TaxExclusiveAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class TaxInclusiveAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class PayableAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class InvoiceLine
    {

        private ID idField;

        private InvoicedQuantity invoicedQuantityField;

        private LineExtensionAmount lineExtensionAmountField;

        private InvoiceLineOrderLineReference orderLineReferenceField;

        private InvoiceLineAllowanceCharge allowanceChargeField;

        private InvoiceLineItem itemField;

        private InvoiceLinePrice priceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public InvoicedQuantity InvoicedQuantity
        {
            get { return this.invoicedQuantityField; }
            set { this.invoicedQuantityField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount
        {
            get { return this.lineExtensionAmountField; }
            set { this.lineExtensionAmountField = value; }
        }

        /// <remarks/>
        public InvoiceLineOrderLineReference OrderLineReference
        {
            get { return this.orderLineReferenceField; }
            set { this.orderLineReferenceField = value; }
        }

        /// <remarks/>
        public InvoiceLineAllowanceCharge AllowanceCharge
        {
            get { return this.allowanceChargeField; }
            set { this.allowanceChargeField = value; }
        }

        /// <remarks/>
        public InvoiceLineItem Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        public InvoiceLinePrice Price
        {
            get { return this.priceField; }
            set { this.priceField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class InvoicedQuantity
    {

        private string unitCodeField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitCode
        {
            get { return this.unitCodeField; }
            set { this.unitCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineOrderLineReference
    {

        private byte lineIDField;

        private InvoiceLineOrderLineReferenceOrderReference orderReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public byte LineID
        {
            get { return this.lineIDField; }
            set { this.lineIDField = value; }
        }

        /// <remarks/>
        public InvoiceLineOrderLineReferenceOrderReference OrderReference
        {
            get { return this.orderReferenceField; }
            set { this.orderReferenceField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineOrderLineReferenceOrderReference
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineAllowanceCharge
    {

        private bool chargeIndicatorField;

        private string allowanceChargeReasonField;

        private decimal multiplierFactorNumericField;

        private Amount amountField;

        private BaseAmount baseAmountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public bool ChargeIndicator
        {
            get { return this.chargeIndicatorField; }
            set { this.chargeIndicatorField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string AllowanceChargeReason
        {
            get { return this.allowanceChargeReasonField; }
            set { this.allowanceChargeReasonField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public decimal MultiplierFactorNumeric
        {
            get { return this.multiplierFactorNumericField; }
            set { this.multiplierFactorNumericField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Amount Amount
        {
            get { return this.amountField; }
            set { this.amountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public BaseAmount BaseAmount
        {
            get { return this.baseAmountField; }
            set { this.baseAmountField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class Amount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class BaseAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineItem
    {

        private string descriptionField;

        private string nameField;

        private InvoiceLineItemBuyersItemIdentification buyersItemIdentificationField;

        private InvoiceLineItemSellersItemIdentification sellersItemIdentificationField;

        private InvoiceLineItemClassifiedTaxCategory classifiedTaxCategoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Description
        {
            get { return this.descriptionField; }
            set { this.descriptionField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        public InvoiceLineItemBuyersItemIdentification BuyersItemIdentification
        {
            get { return this.buyersItemIdentificationField; }
            set { this.buyersItemIdentificationField = value; }
        }

        /// <remarks/>
        public InvoiceLineItemSellersItemIdentification SellersItemIdentification
        {
            get { return this.sellersItemIdentificationField; }
            set { this.sellersItemIdentificationField = value; }
        }

        /// <remarks/>
        public InvoiceLineItemClassifiedTaxCategory ClassifiedTaxCategory
        {
            get { return this.classifiedTaxCategoryField; }
            set { this.classifiedTaxCategoryField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineItemBuyersItemIdentification
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineItemSellersItemIdentification
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineItemClassifiedTaxCategory
    {

        private ID idField;

        private decimal percentField;

        private InvoiceLineItemClassifiedTaxCategoryTaxScheme taxSchemeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public decimal Percent
        {
            get { return this.percentField; }
            set { this.percentField = value; }
        }

        /// <remarks/>
        public InvoiceLineItemClassifiedTaxCategoryTaxScheme TaxScheme
        {
            get { return this.taxSchemeField; }
            set { this.taxSchemeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLineItemClassifiedTaxCategoryTaxScheme
    {

        private ID idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public partial class InvoiceLinePrice
    {

        private PriceAmount priceAmountField;

        private BaseQuantity baseQuantityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PriceAmount PriceAmount
        {
            get { return this.priceAmountField; }
            set { this.priceAmountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace =
            "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public BaseQuantity BaseQuantity
        {
            get { return this.baseQuantityField; }
            set { this.baseQuantityField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class PriceAmount
    {

        private string currencyIDField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currencyID
        {
            get { return this.currencyIDField; }
            set { this.currencyIDField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute(
        Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", IsNullable = false)]
    public partial class BaseQuantity
    {

        private string unitCodeField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitCode
        {
            get { return this.unitCodeField; }
            set { this.unitCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

}
