using System;
using PX.Data;

namespace GenericFormTZ
{
  [Serializable]
  [PXCacheName("CSUserDefDataHeader")]
  public class CSUserDefDataHeader : IBqlTable
  {
      PXGenericInqGrph
    #region UserDefDataID
    [PXDBIdentity(IsKey = true)]
    public virtual int? UserDefDataID { get; set; }
    public abstract class userDefDataID : PX.Data.BQL.BqlInt.Field<userDefDataID> { }
    #endregion

    #region UserDefDataCD
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Screen ID")]
    public virtual string UserDefDataCD { get; set; }
    public abstract class userDefDataCD : PX.Data.BQL.BqlString.Field<userDefDataCD> { }
    #endregion

    #region Description
    [PXDBString(80, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion

    #region PrevLineNbr
    [PXDBInt()]
    [PXDefault(0, PersistingCheck = PXPersistingCheck.Nothing)]
    public virtual int? PrevLineNbr { get; set; }
    public abstract class prevLineNbr : PX.Data.BQL.BqlInt.Field<prevLineNbr> { }
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