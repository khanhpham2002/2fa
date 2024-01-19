using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Domain
{
    public enum RoleType
    {
        /// <summary>
        /// Can login and list of sites + site details
        /// </summary>
        VIEWER = 0,

        /// <summary>
        /// Viewer functions + ability to apply control modes
        /// </summary>
        OPERATOR = 1,

        /// <summary>
        /// Operator functions +add site
        /// </summary>
        INSTALLER = 2,

        /// <summary>
        /// Operator functions +add, edit or delete site, allocate zone and link OB device to site. Remove OB device and replace with new OB device on a site.
        /// </summary>
        COMMISSIONER = 3,

        /// <summary>
        /// Commissioner functions + Manage users (reset password, firstname, lastname, mobile number)
        /// </summary>
        ADMINISTRATOR = 4,

        /// <summary>
        /// View Inventory of all OB devices. Allocate OB device to customer. Superuser role
        /// </summary>
        CONFIGURATOR = 5,
    }
    public enum SortDirection
    {
        ASC,
        DESC
    }
    public enum ReportFrequency
    {
        Daily = 1,
        Weekly = 7,
        Monthly = 30
    }
}