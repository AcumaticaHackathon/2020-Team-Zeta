using System;
using PX.Data;

namespace GF
{
  [Serializable]
  [PXCacheName("CSGenericFormResults")]
  public class CSGenericFormResults : IBqlTable
  {
    #region RefNoteID
    [PXDBGuid()]
    [PXUIField(DisplayName = "Ref Note ID")]
    public virtual Guid? RefNoteID { get; set; }
    public abstract class refNoteID : PX.Data.BQL.BqlGuid.Field<refNoteID> { }
    #endregion

    #region FormDescription
    [PXDBString(80, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Form Description")]
    public virtual string FormDescription { get; set; }
    public abstract class formDescription : PX.Data.BQL.BqlString.Field<formDescription> { }
    #endregion

    #region UserDefDataID
    [PXDBInt()]
    [PXUIField(DisplayName = "User Def Data ID")]
    public virtual int? UserDefDataID { get; set; }
    public abstract class userDefDataID : PX.Data.BQL.BqlInt.Field<userDefDataID> { }
    #endregion

    #region UserDefDataCD
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "User Def Data CD")]
    public virtual string UserDefDataCD { get; set; }
    public abstract class userDefDataCD : PX.Data.BQL.BqlString.Field<userDefDataCD> { }
    #endregion

    #region Field1
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field1")]
    public virtual string Field1 { get; set; }
    public abstract class field1 : PX.Data.BQL.BqlString.Field<field1> { }
    #endregion

    #region Field1Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field1 Value")]
    public virtual string Field1Value { get; set; }
    public abstract class field1Value : PX.Data.BQL.BqlString.Field<field1Value> { }
    #endregion

    #region Field2
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field2")]
    public virtual string Field2 { get; set; }
    public abstract class field2 : PX.Data.BQL.BqlString.Field<field2> { }
    #endregion

    #region Field2Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field2 Value")]
    public virtual string Field2Value { get; set; }
    public abstract class field2Value : PX.Data.BQL.BqlString.Field<field2Value> { }
    #endregion

    #region Field3
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field3")]
    public virtual string Field3 { get; set; }
    public abstract class field3 : PX.Data.BQL.BqlString.Field<field3> { }
    #endregion

    #region Field3Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field3 Value")]
    public virtual string Field3Value { get; set; }
    public abstract class field3Value : PX.Data.BQL.BqlString.Field<field3Value> { }
    #endregion

    #region Field4
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field4")]
    public virtual string Field4 { get; set; }
    public abstract class field4 : PX.Data.BQL.BqlString.Field<field4> { }
    #endregion

    #region Field4Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field4 Value")]
    public virtual string Field4Value { get; set; }
    public abstract class field4Value : PX.Data.BQL.BqlString.Field<field4Value> { }
    #endregion

    #region Field5
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field5")]
    public virtual string Field5 { get; set; }
    public abstract class field5 : PX.Data.BQL.BqlString.Field<field5> { }
    #endregion

    #region Field5Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field5 Value")]
    public virtual string Field5Value { get; set; }
    public abstract class field5Value : PX.Data.BQL.BqlString.Field<field5Value> { }
    #endregion

    #region Field6
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field6")]
    public virtual string Field6 { get; set; }
    public abstract class field6 : PX.Data.BQL.BqlString.Field<field6> { }
    #endregion

    #region Field6Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field6 Value")]
    public virtual string Field6Value { get; set; }
    public abstract class field6Value : PX.Data.BQL.BqlString.Field<field6Value> { }
    #endregion

    #region Field7
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field7")]
    public virtual string Field7 { get; set; }
    public abstract class field7 : PX.Data.BQL.BqlString.Field<field7> { }
    #endregion

    #region Field7Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field7 Value")]
    public virtual string Field7Value { get; set; }
    public abstract class field7Value : PX.Data.BQL.BqlString.Field<field7Value> { }
    #endregion

    #region Field8
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field8")]
    public virtual string Field8 { get; set; }
    public abstract class field8 : PX.Data.BQL.BqlString.Field<field8> { }
    #endregion

    #region Field8Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field8 Value")]
    public virtual string Field8Value { get; set; }
    public abstract class field8Value : PX.Data.BQL.BqlString.Field<field8Value> { }
    #endregion

    #region Field9
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field9")]
    public virtual string Field9 { get; set; }
    public abstract class field9 : PX.Data.BQL.BqlString.Field<field9> { }
    #endregion

    #region Field9Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field9 Value")]
    public virtual string Field9Value { get; set; }
    public abstract class field9Value : PX.Data.BQL.BqlString.Field<field9Value> { }
    #endregion

    #region Field10
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field10")]
    public virtual string Field10 { get; set; }
    public abstract class field10 : PX.Data.BQL.BqlString.Field<field10> { }
    #endregion

    #region Field10Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field10 Value")]
    public virtual string Field10Value { get; set; }
    public abstract class field10Value : PX.Data.BQL.BqlString.Field<field10Value> { }
    #endregion

    #region Field11
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field11")]
    public virtual string Field11 { get; set; }
    public abstract class field11 : PX.Data.BQL.BqlString.Field<field11> { }
    #endregion

    #region Field11Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field11 Value")]
    public virtual string Field11Value { get; set; }
    public abstract class field11Value : PX.Data.BQL.BqlString.Field<field11Value> { }
    #endregion

    #region Field12
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field12")]
    public virtual string Field12 { get; set; }
    public abstract class field12 : PX.Data.BQL.BqlString.Field<field12> { }
    #endregion

    #region Field12Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field12 Value")]
    public virtual string Field12Value { get; set; }
    public abstract class field12Value : PX.Data.BQL.BqlString.Field<field12Value> { }
    #endregion

    #region Field13
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field13")]
    public virtual string Field13 { get; set; }
    public abstract class field13 : PX.Data.BQL.BqlString.Field<field13> { }
    #endregion

    #region Field13Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field13 Value")]
    public virtual string Field13Value { get; set; }
    public abstract class field13Value : PX.Data.BQL.BqlString.Field<field13Value> { }
    #endregion

    #region Field14
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field14")]
    public virtual string Field14 { get; set; }
    public abstract class field14 : PX.Data.BQL.BqlString.Field<field14> { }
    #endregion

    #region Field14Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field14 Value")]
    public virtual string Field14Value { get; set; }
    public abstract class field14Value : PX.Data.BQL.BqlString.Field<field14Value> { }
    #endregion

    #region Field15
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field15")]
    public virtual string Field15 { get; set; }
    public abstract class field15 : PX.Data.BQL.BqlString.Field<field15> { }
    #endregion

    #region Field15Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field15 Value")]
    public virtual string Field15Value { get; set; }
    public abstract class field15Value : PX.Data.BQL.BqlString.Field<field15Value> { }
    #endregion

    #region Field16
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field16")]
    public virtual string Field16 { get; set; }
    public abstract class field16 : PX.Data.BQL.BqlString.Field<field16> { }
    #endregion

    #region Field16Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field16 Value")]
    public virtual string Field16Value { get; set; }
    public abstract class field16Value : PX.Data.BQL.BqlString.Field<field16Value> { }
    #endregion

    #region Field17
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field17")]
    public virtual string Field17 { get; set; }
    public abstract class field17 : PX.Data.BQL.BqlString.Field<field17> { }
    #endregion

    #region Field17Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field17 Value")]
    public virtual string Field17Value { get; set; }
    public abstract class field17Value : PX.Data.BQL.BqlString.Field<field17Value> { }
    #endregion

    #region Field18
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field18")]
    public virtual string Field18 { get; set; }
    public abstract class field18 : PX.Data.BQL.BqlString.Field<field18> { }
    #endregion

    #region Field18Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field18 Value")]
    public virtual string Field18Value { get; set; }
    public abstract class field18Value : PX.Data.BQL.BqlString.Field<field18Value> { }
    #endregion

    #region Field19
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field19")]
    public virtual string Field19 { get; set; }
    public abstract class field19 : PX.Data.BQL.BqlString.Field<field19> { }
    #endregion

    #region Field19Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field19 Value")]
    public virtual string Field19Value { get; set; }
    public abstract class field19Value : PX.Data.BQL.BqlString.Field<field19Value> { }
    #endregion

    #region Field20
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field20")]
    public virtual string Field20 { get; set; }
    public abstract class field20 : PX.Data.BQL.BqlString.Field<field20> { }
    #endregion

    #region Field20Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field20 Value")]
    public virtual string Field20Value { get; set; }
    public abstract class field20Value : PX.Data.BQL.BqlString.Field<field20Value> { }
    #endregion

    #region Field21
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field21")]
    public virtual string Field21 { get; set; }
    public abstract class field21 : PX.Data.BQL.BqlString.Field<field21> { }
    #endregion

    #region Field21Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field21 Value")]
    public virtual string Field21Value { get; set; }
    public abstract class field21Value : PX.Data.BQL.BqlString.Field<field21Value> { }
    #endregion

    #region Field22
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field22")]
    public virtual string Field22 { get; set; }
    public abstract class field22 : PX.Data.BQL.BqlString.Field<field22> { }
    #endregion

    #region Field22Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field22 Value")]
    public virtual string Field22Value { get; set; }
    public abstract class field22Value : PX.Data.BQL.BqlString.Field<field22Value> { }
    #endregion

    #region Field23
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field23")]
    public virtual string Field23 { get; set; }
    public abstract class field23 : PX.Data.BQL.BqlString.Field<field23> { }
    #endregion

    #region Field23Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field23 Value")]
    public virtual string Field23Value { get; set; }
    public abstract class field23Value : PX.Data.BQL.BqlString.Field<field23Value> { }
    #endregion

    #region Field24
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field24")]
    public virtual string Field24 { get; set; }
    public abstract class field24 : PX.Data.BQL.BqlString.Field<field24> { }
    #endregion

    #region Field24Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field24 Value")]
    public virtual string Field24Value { get; set; }
    public abstract class field24Value : PX.Data.BQL.BqlString.Field<field24Value> { }
    #endregion

    #region Field25
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field25")]
    public virtual string Field25 { get; set; }
    public abstract class field25 : PX.Data.BQL.BqlString.Field<field25> { }
    #endregion

    #region Field25Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field25 Value")]
    public virtual string Field25Value { get; set; }
    public abstract class field25Value : PX.Data.BQL.BqlString.Field<field25Value> { }
    #endregion

    #region Field26
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field26")]
    public virtual string Field26 { get; set; }
    public abstract class field26 : PX.Data.BQL.BqlString.Field<field26> { }
    #endregion

    #region Field26Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field26 Value")]
    public virtual string Field26Value { get; set; }
    public abstract class field26Value : PX.Data.BQL.BqlString.Field<field26Value> { }
    #endregion

    #region Field27
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field27")]
    public virtual string Field27 { get; set; }
    public abstract class field27 : PX.Data.BQL.BqlString.Field<field27> { }
    #endregion

    #region Field27Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field27 Value")]
    public virtual string Field27Value { get; set; }
    public abstract class field27Value : PX.Data.BQL.BqlString.Field<field27Value> { }
    #endregion

    #region Field28
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field28")]
    public virtual string Field28 { get; set; }
    public abstract class field28 : PX.Data.BQL.BqlString.Field<field28> { }
    #endregion

    #region Field28Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field28 Value")]
    public virtual string Field28Value { get; set; }
    public abstract class field28Value : PX.Data.BQL.BqlString.Field<field28Value> { }
    #endregion

    #region Field29
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field29")]
    public virtual string Field29 { get; set; }
    public abstract class field29 : PX.Data.BQL.BqlString.Field<field29> { }
    #endregion

    #region Field29Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field29 Value")]
    public virtual string Field29Value { get; set; }
    public abstract class field29Value : PX.Data.BQL.BqlString.Field<field29Value> { }
    #endregion

    #region Field30
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field30")]
    public virtual string Field30 { get; set; }
    public abstract class field30 : PX.Data.BQL.BqlString.Field<field30> { }
    #endregion

    #region Field30Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field30 Value")]
    public virtual string Field30Value { get; set; }
    public abstract class field30Value : PX.Data.BQL.BqlString.Field<field30Value> { }
    #endregion

    #region Field31
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field31")]
    public virtual string Field31 { get; set; }
    public abstract class field31 : PX.Data.BQL.BqlString.Field<field31> { }
    #endregion

    #region Field31Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field31 Value")]
    public virtual string Field31Value { get; set; }
    public abstract class field31Value : PX.Data.BQL.BqlString.Field<field31Value> { }
    #endregion

    #region Field32
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field32")]
    public virtual string Field32 { get; set; }
    public abstract class field32 : PX.Data.BQL.BqlString.Field<field32> { }
    #endregion

    #region Field32Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field32 Value")]
    public virtual string Field32Value { get; set; }
    public abstract class field32Value : PX.Data.BQL.BqlString.Field<field32Value> { }
    #endregion

    #region Field33
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field33")]
    public virtual string Field33 { get; set; }
    public abstract class field33 : PX.Data.BQL.BqlString.Field<field33> { }
    #endregion

    #region Field33Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field33 Value")]
    public virtual string Field33Value { get; set; }
    public abstract class field33Value : PX.Data.BQL.BqlString.Field<field33Value> { }
    #endregion

    #region Field34
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field34")]
    public virtual string Field34 { get; set; }
    public abstract class field34 : PX.Data.BQL.BqlString.Field<field34> { }
    #endregion

    #region Field34Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field34 Value")]
    public virtual string Field34Value { get; set; }
    public abstract class field34Value : PX.Data.BQL.BqlString.Field<field34Value> { }
    #endregion

    #region Field35
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field35")]
    public virtual string Field35 { get; set; }
    public abstract class field35 : PX.Data.BQL.BqlString.Field<field35> { }
    #endregion

    #region Field35Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field35 Value")]
    public virtual string Field35Value { get; set; }
    public abstract class field35Value : PX.Data.BQL.BqlString.Field<field35Value> { }
    #endregion

    #region Field36
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field36")]
    public virtual string Field36 { get; set; }
    public abstract class field36 : PX.Data.BQL.BqlString.Field<field36> { }
    #endregion

    #region Field36Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field36 Value")]
    public virtual string Field36Value { get; set; }
    public abstract class field36Value : PX.Data.BQL.BqlString.Field<field36Value> { }
    #endregion

    #region Field37
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field37")]
    public virtual string Field37 { get; set; }
    public abstract class field37 : PX.Data.BQL.BqlString.Field<field37> { }
    #endregion

    #region Field37Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field37 Value")]
    public virtual string Field37Value { get; set; }
    public abstract class field37Value : PX.Data.BQL.BqlString.Field<field37Value> { }
    #endregion

    #region Field38
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field38")]
    public virtual string Field38 { get; set; }
    public abstract class field38 : PX.Data.BQL.BqlString.Field<field38> { }
    #endregion

    #region Field38Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field38 Value")]
    public virtual string Field38Value { get; set; }
    public abstract class field38Value : PX.Data.BQL.BqlString.Field<field38Value> { }
    #endregion

    #region Field39
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field39")]
    public virtual string Field39 { get; set; }
    public abstract class field39 : PX.Data.BQL.BqlString.Field<field39> { }
    #endregion

    #region Field39Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field39 Value")]
    public virtual string Field39Value { get; set; }
    public abstract class field39Value : PX.Data.BQL.BqlString.Field<field39Value> { }
    #endregion

    #region Field40
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field40")]
    public virtual string Field40 { get; set; }
    public abstract class field40 : PX.Data.BQL.BqlString.Field<field40> { }
    #endregion

    #region Field40Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field40 Value")]
    public virtual string Field40Value { get; set; }
    public abstract class field40Value : PX.Data.BQL.BqlString.Field<field40Value> { }
    #endregion

    #region Field41
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field41")]
    public virtual string Field41 { get; set; }
    public abstract class field41 : PX.Data.BQL.BqlString.Field<field41> { }
    #endregion

    #region Field41Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field41 Value")]
    public virtual string Field41Value { get; set; }
    public abstract class field41Value : PX.Data.BQL.BqlString.Field<field41Value> { }
    #endregion

    #region Field42
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field42")]
    public virtual string Field42 { get; set; }
    public abstract class field42 : PX.Data.BQL.BqlString.Field<field42> { }
    #endregion

    #region Field42Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field42 Value")]
    public virtual string Field42Value { get; set; }
    public abstract class field42Value : PX.Data.BQL.BqlString.Field<field42Value> { }
    #endregion

    #region Field43
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field43")]
    public virtual string Field43 { get; set; }
    public abstract class field43 : PX.Data.BQL.BqlString.Field<field43> { }
    #endregion

    #region Field43Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field43 Value")]
    public virtual string Field43Value { get; set; }
    public abstract class field43Value : PX.Data.BQL.BqlString.Field<field43Value> { }
    #endregion

    #region Field44
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field44")]
    public virtual string Field44 { get; set; }
    public abstract class field44 : PX.Data.BQL.BqlString.Field<field44> { }
    #endregion

    #region Field44Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field44 Value")]
    public virtual string Field44Value { get; set; }
    public abstract class field44Value : PX.Data.BQL.BqlString.Field<field44Value> { }
    #endregion

    #region Field45
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field45")]
    public virtual string Field45 { get; set; }
    public abstract class field45 : PX.Data.BQL.BqlString.Field<field45> { }
    #endregion

    #region Field45Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field45 Value")]
    public virtual string Field45Value { get; set; }
    public abstract class field45Value : PX.Data.BQL.BqlString.Field<field45Value> { }
    #endregion

    #region Field46
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field46")]
    public virtual string Field46 { get; set; }
    public abstract class field46 : PX.Data.BQL.BqlString.Field<field46> { }
    #endregion

    #region Field46Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field46 Value")]
    public virtual string Field46Value { get; set; }
    public abstract class field46Value : PX.Data.BQL.BqlString.Field<field46Value> { }
    #endregion

    #region Field47
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field47")]
    public virtual string Field47 { get; set; }
    public abstract class field47 : PX.Data.BQL.BqlString.Field<field47> { }
    #endregion

    #region Field47Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field47 Value")]
    public virtual string Field47Value { get; set; }
    public abstract class field47Value : PX.Data.BQL.BqlString.Field<field47Value> { }
    #endregion

    #region Field48
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field48")]
    public virtual string Field48 { get; set; }
    public abstract class field48 : PX.Data.BQL.BqlString.Field<field48> { }
    #endregion

    #region Field48Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field48 Value")]
    public virtual string Field48Value { get; set; }
    public abstract class field48Value : PX.Data.BQL.BqlString.Field<field48Value> { }
    #endregion

    #region Field49
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field49")]
    public virtual string Field49 { get; set; }
    public abstract class field49 : PX.Data.BQL.BqlString.Field<field49> { }
    #endregion

    #region Field49Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field49 Value")]
    public virtual string Field49Value { get; set; }
    public abstract class field49Value : PX.Data.BQL.BqlString.Field<field49Value> { }
    #endregion

    #region Field50
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field50")]
    public virtual string Field50 { get; set; }
    public abstract class field50 : PX.Data.BQL.BqlString.Field<field50> { }
    #endregion

    #region Field50Value
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field50 Value")]
    public virtual string Field50Value { get; set; }
    public abstract class field50Value : PX.Data.BQL.BqlString.Field<field50Value> { }
    #endregion
  }
}