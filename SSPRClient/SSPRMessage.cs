using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSPRClient
{
    public class PasswordStatus
    {
        public bool expired { get; set; }
        public bool preExpired { get; set; }
        public bool violatesPolicy { get; set; }
        public bool warnPeriod { get; set; }
    }

    public class PasswordPolicy
    {
        public string MaximumNumeric { get; set; }
        public string MinimumSpecial { get; set; }
        public string AllowLastCharSpecial { get; set; }
        public string ADComplexity { get; set; }
        public string RegExNoMatch { get; set; }
        public string AllowSpecial { get; set; }
        public string MaximumSpecial { get; set; }
        public string MinimumLowerCase { get; set; }
        public string MinimumUnique { get; set; }
        public string MinimumNumeric { get; set; }
        public string MinimumLength { get; set; }
        public string DisallowedValues { get; set; }
        public string CaseSensitive { get; set; }
        public string RegExMatch { get; set; }
        public string DisallowCurrent { get; set; }
        public string AllowFirstCharSpecial { get; set; }
        public string MinimumLifetime { get; set; }
        public string ExpirationInterval { get; set; }
        public string UniqueRequired { get; set; }
        public string MaximumSequentialRepeat { get; set; }
        public string AllowNumeric { get; set; }
        public string AllowFirstCharNumeric { get; set; }
        public string EnableWordlist { get; set; }
        public string MaximumLength { get; set; }
        public string DisallowedAttributes { get; set; }
        public string AllowLastCharNumeric { get; set; }
        public string PolicyEnabled { get; set; }
        public string MaximumUpperCase { get; set; }
        public string MinimumUpperCase { get; set; }
        public string ChangeMessage { get; set; }
        public string MinimumAlpha { get; set; }
        public string MaximumLowerCase { get; set; }
    }

    public class Data
    {
        public string userDN { get; set; }
        public string userID { get; set; }
        public string userEmailAddress { get; set; }
        public bool requiresNewPassword { get; set; }
        public bool requiresResponseConfig { get; set; }
        public bool requiresUpdateProfile { get; set; }
        public PasswordStatus passwordStatus { get; set; }
        public PasswordPolicy passwordPolicy { get; set; }
        public List<string> passwordRules { get; set; }
    }

    public class RootObject
    {
        public bool error { get; set; }
        public int errorCode { get; set; }
        public Data data { get; set; }
    }
}
