using System;
using PX.Data;

namespace GF.DAC
{
    [Serializable]
    [PXCacheName("CSMyAnswers")]
    public class CSMyAnswers : IBqlTable
    {
        #region UserDefDataID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "User Def Data ID")]
        public virtual int? UserDefDataID { get; set; }
        public abstract class userDefDataID : PX.Data.BQL.BqlInt.Field<userDefDataID> { }
        #endregion

        #region UserDefDataLineID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "User Def Data Line ID")]
        public virtual int? UserDefDataLineID { get; set; }
        public abstract class userDefDataLineID : PX.Data.BQL.BqlInt.Field<userDefDataLineID> { }
        #endregion

        #region UserResponseID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "User Response ID")]
        public virtual int? UserResponseID { get; set; }
        public abstract class userResponseID : PX.Data.BQL.BqlInt.Field<userResponseID> { }
        #endregion

        #region Value
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value")]
        public virtual string Value { get; set; }
        public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
        #endregion
    }
}