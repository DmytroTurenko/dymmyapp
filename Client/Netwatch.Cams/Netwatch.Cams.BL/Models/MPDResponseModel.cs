using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:mpeg:dash:schema:mpd:2011", IsNullable = false)]
    public partial class MPD
    {

        private MPDAdaptationSet[] periodField;

        private string profilesField;

        private string typeField;

        private string minBufferTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AdaptationSet", IsNullable = false)]
        public MPDAdaptationSet[] Period
        {
            get
            {
                return this.periodField;
            }
            set
            {
                this.periodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string profiles
        {
            get
            {
                return this.profilesField;
            }
            set
            {
                this.profilesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "duration")]
        public string minBufferTime
        {
            get
            {
                return this.minBufferTimeField;
            }
            set
            {
                this.minBufferTimeField = value;
            }
        }
    }
}


/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
public partial class MPDAdaptationSet
{

    private MPDAdaptationSetSupplementalProperty[] supplementalPropertyField;

    private MPDAdaptationSetRole roleField;

    private MPDAdaptationSetRepresentation[] representationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SupplementalProperty")]
    public MPDAdaptationSetSupplementalProperty[] SupplementalProperty
    {
        get
        {
            return this.supplementalPropertyField;
        }
        set
        {
            this.supplementalPropertyField = value;
        }
    }

    /// <remarks/>
    public MPDAdaptationSetRole Role
    {
        get
        {
            return this.roleField;
        }
        set
        {
            this.roleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Representation")]
    public MPDAdaptationSetRepresentation[] Representation
    {
        get
        {
            return this.representationField;
        }
        set
        {
            this.representationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
public partial class MPDAdaptationSetSupplementalProperty
{

    private string schemeIdUriField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeIdUri
    {
        get
        {
            return this.schemeIdUriField;
        }
        set
        {
            this.schemeIdUriField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
public partial class MPDAdaptationSetRole
{

    private string schemeIdUriField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeIdUri
    {
        get
        {
            return this.schemeIdUriField;
        }
        set
        {
            this.schemeIdUriField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
public partial class MPDAdaptationSetRepresentation
{

    private MPDAdaptationSetRepresentationSupplementalProperty supplementalPropertyField;

    private string baseURLField;

    private byte idField;

    private uint bandwidthField;

    private ushort widthField;

    private bool widthFieldSpecified;

    private ushort heightField;

    private bool heightFieldSpecified;

    private string mimeTypeField;

    private string codecsField;

    private ushort audioSamplingRateField;

    private bool audioSamplingRateFieldSpecified;

    /// <remarks/>
    public MPDAdaptationSetRepresentationSupplementalProperty SupplementalProperty
    {
        get
        {
            return this.supplementalPropertyField;
        }
        set
        {
            this.supplementalPropertyField = value;
        }
    }

    /// <remarks/>
    public string BaseURL
    {
        get
        {
            return this.baseURLField;
        }
        set
        {
            this.baseURLField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint bandwidth
    {
        get
        {
            return this.bandwidthField;
        }
        set
        {
            this.bandwidthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort width
    {
        get
        {
            return this.widthField;
        }
        set
        {
            this.widthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool widthSpecified
    {
        get
        {
            return this.widthFieldSpecified;
        }
        set
        {
            this.widthFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort height
    {
        get
        {
            return this.heightField;
        }
        set
        {
            this.heightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool heightSpecified
    {
        get
        {
            return this.heightFieldSpecified;
        }
        set
        {
            this.heightFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mimeType
    {
        get
        {
            return this.mimeTypeField;
        }
        set
        {
            this.mimeTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codecs
    {
        get
        {
            return this.codecsField;
        }
        set
        {
            this.codecsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort audioSamplingRate
    {
        get
        {
            return this.audioSamplingRateField;
        }
        set
        {
            this.audioSamplingRateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool audioSamplingRateSpecified
    {
        get
        {
            return this.audioSamplingRateFieldSpecified;
        }
        set
        {
            this.audioSamplingRateFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:mpeg:dash:schema:mpd:2011")]
public partial class MPDAdaptationSetRepresentationSupplementalProperty
{

    private string schemeIdUriField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string schemeIdUri
    {
        get
        {
            return this.schemeIdUriField;
        }
        set
        {
            this.schemeIdUriField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value
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

