using System;
using GenericForm;
using PX.Data;

namespace GenericFormTZ
{
    [Serializable]
    [PXCacheName("CSUserDefDataDetail")]
    public class CSUserDefDataDetail : IBqlTable
    {
        public const int Text = 1;
        public const int Combo = 2;
        public const int CheckBox = 4;
        public const int Datetime = 5;
        public const int MultiSelectCombo = 6;
        public const int GISelector = 7;
          #region UserDefDataID
    [PXDBInt(IsKey = true)]
    [PXDBDefault(typeof(CSUserDefDataHeader.userDefDataID))]
    [PXParent(typeof(Select<CSUserDefDataHeader, 
        Where<CSUserDefDataHeader.userDefDataID.IsEqual<userDefDataID>>>))]
    public virtual int? UserDefDataID { get; set; }
    public abstract class userDefDataID : PX.Data.BQL.BqlInt.Field<userDefDataID> { }
    #endregion
    
          #region UserDefDataLineID
    [PXDBInt(IsKey = true)]
    [PXLineNbr(typeof(CSUserDefDataHeader.prevLineNbr))]
    public virtual int? UserDefDataLineID { get; set; }
    public abstract class userDefDataLineID : PX.Data.BQL.BqlInt.Field<userDefDataLineID> { }
    #endregion
    
          #region DataElementName
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Data Element Name")]
    public virtual string DataElementName { get; set; }
    public abstract class dataElementName : PX.Data.BQL.BqlString.Field<dataElementName> { }
    #endregion
    
          #region DataElementType
        
          [PXDBString(20, IsUnicode = true)]
          [PXUIField(DisplayName = "Data Element Type")]
          public virtual string DataElementType { get; set; }
          public abstract class dataElementType : PX.Data.BQL.BqlString.Field<dataElementType> { }
          #endregion
    
          #region ControlType
          [PXDBInt()]
          [ControlTypes]
          [PXUIField(DisplayName = "Control Type")]
          public virtual int? ControlType { get; set; }
          public abstract class controlType : PX.Data.BQL.BqlString.Field<controlType> { }
          #endregion
    
          #region SequenceNo
    [PXDBInt()]
    [PXUIField(DisplayName = "Sequence No")]
    public virtual int? SequenceNo { get; set; }
    public abstract class sequenceNo : PX.Data.BQL.BqlInt.Field<sequenceNo> { }
    #endregion
    
          #region Tstamp
    [PXDBTimestamp()]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
    #endregion
    
          #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion
    
          #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion
    
          #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion
    
          #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion
    
          #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion
    
          #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion
    
          #region Noteid
          [PXNote()]
          public virtual Guid? Noteid { get; set; }
          public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
          #endregion
    }
}