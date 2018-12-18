using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly2.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Description { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}