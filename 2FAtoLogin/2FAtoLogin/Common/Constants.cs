using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Common
{
    public static class Constants
    {
        public const string TokenHeader = "Token";
        public const string AdHocSyncRequest = "AdhocSync";
        public const string ScadaSessionId = "ScadaSessionId";
        public const string AdminNativeSesssion = "AdminNativeSesssion";
        public const string UserNativeSession = "UserNativeSesssion";
        public const string LoginSignature = "LoginSignature";
        public const string OneBoxCompareIgnoredFieldsForSync = "OneBoxId,SiteId,Site,OneBoxChangeHistory,Customer";
        public const string OneBoxCompareIgnoredFieldsForUpdate = "OneBoxId,SiteId,Site,OneBoxChangeHistory,Customer,CustomerId";
        public const string BlokaidDataCacheKey = "BlokaidData_";

        public const string SITE_REPORTS_TEXT = "Site Reports";
        public const string IOTA_FULL_NAME_TEXT = "Products.Footprint.IOTA";
        public const string CLASS_NAME_USERGROUP = "CDBUserGroup";
        public const int REPORT_SIMPLE_PERIOD_TYPE_VALUE = 0;
        public const int REPORT_MONTHLY_PERIOD_TYPE_VALUE = 3;
        public const int REPORT_RANDOM_DURATION = 180;
        public const string REPORT_WEEKLY_OFFSET_FORMAT = "{0} + 1D";
        public const string REPORT_SIMPLE_OFFSET_FORMAT = "{0} + 7H + {1}M";
        public const string REPORT_SIMPLE_INTERVAL_FORMAT = "{0}D";
        public const string PROPERTY_NAME_IN_SERVICE = "InService";
        public const int START_END_HOUR_LIST_FULLDAY_VALUE = 25;
        public const string REPORT_PARAMSTRING_PROPERTY = "String";

        //Footprint. Should map to folder name in SCADA
        public const string WaterMetersType = "Water Meter";
        public const string LevelSensorsType = "Level";
        public const string WaterMeterReadingsType = "Water Meter Reading";
        public const string ElectricityMetersType = "Electricity Meter";
        public const string GasMetersType = "Gas Meter";
        public const string FlowMeter = "Flow";
        public const string FlowRateMeter = "Flow Rate";
        public const string BatteryVolts = "Battery Volts";
        public const string Chlorine = "Chlorine";
        public const string DO = "DO";
        public const string Digital = "Digital";
        public const string EC = "EC";
        public const string Evapotranspiration = "Evapotranspiration";
        public const string OxidationReductionPotential = "ORP";
        public const string FreeChlorine = "Free Chlorine";
        public const string Humidity = "Humidity";
        public const string PH = "PH";
        public const string Pressure = "Pressure";
        public const string PumpRun1 = "PumpRun1";
        public const string RainTotal = "Rain Total";
        public const string SolarRadiation = "Solar Radiation";
        public const string Temp = "Temp";
        public const string Turbidity = "Turbidity";
        public const string Velocity = "Velocity";
        public const string WindDirection = "Wind Direction";
        public const string HS = "HS";
        public const string InstantaneousFlow = "Instantaneous Flow";

        public const string Electricity_Meters = "Electricity Meters";
        public const string TradeWaste = "Trade Waste";
        public const string Water_Meters = "Water Meters";
        public const string Gas_Meters = "Gas Meters";
        public const string Hydrographics = "Hydrographics";

        public const int ZERO = 0;
        public const string TEXT_NUMBER_ONE = "1";
        public const string TEXT_MAIN = "MAIN";
        public const string TEXT_MONTHLY = "MONTHLY";
        public const string TEXT_DAILY = "DAILY";
        public const string TEXT_TW_SITE_MONTHLY = "TW_SITE_MONTHLY";
        public const string TEXT_RAW = "RAW";
        public const string TEXT_MAIN_DAILY = "MAIN_DAILY";
        public const string TEXT_CUSTOM = "CUSTOM";
        public const string TEXT_CUSTOM_DAILY = "CUSTOM_DAILY";
        public const string TEXT_NOT_IN_SERVICE = "Not in Service";
        public const string TEXT_SEPARATOR = "___";
        public const string TEXT_WATER = "WATER";
        public const string TEXT_ELECTRICITY = "ELECTRICITY";
        public const string TEXT_GAS = "GAS";
        public const string TEXT_METER_COLLECTION = "METER_COLLECTION";
        public const string TEXT_YES = "Yes";
        public const string TEXT_NO = "No";
        public const string TEXT_ENABLED = "Enabled";
        public const string TEXT_DISABLED = "Disabled";
        public const string TEXT_REPORT_ID = "ReportId";
        public const string TEXT_REPORT_TITLE = "ReportTitle";
        public const string TEXT_CATEGORY = "Category";
        public const string TEXT_REPORT_TYPE = "ReportType";
        public const string TEXT_IS_COMBINED = "IsCombined";
        public const string TEXT_LAST_MODIFIED = "LastModified";
        public const string TEXT_STATUS = "Status";
        public const string TEXT_CUSTOMER_NAME = "CustomerName";
        public const string TEXT_APPLICATION_NAME = "ApplicationName";
        public const string TEXT_AVERAGE = "Average";
        public const string TEXT_AVERAGE_6to6 = "Average (6PM - 6AM)";
        public const string TEXT_TOTAL = "Total";
        public const string TEXT_MONTHLY_TOTAL = "Monthly Total";
        public const string TEXT_MONTHLY_FLOW = "Monthly Flow";
        public const string TEXT_TRADE_WASTE = "Trade Waste";
        public const string TEXT_HYDROGRAPHICS = "Hydrographics";
        public const string TEXT_COMBINED_CHARTS = "Combined Charts";
        public const string TEXT_MONDAY = "Monday";
        public const string TEXT_AVERAGE_7DAY = "7 Day Average";
        public const string TEXT_AVERAGE_30DAY = "30 Day Average";
        public const string TEXT_THIS_MONTH = "Last 30 Days";
        public const string TEXT_LAST_MONTH = "Last 30 - 60 Days";
        public const string TEXT_2MONTHS_AGO = "Last - 60 - 90 Days";
        public const string TEXT_DDS = "Daily Dissolved Solids";
        public const string TEXT_DATA_TABLES = "Data Tables";
        public const string TEXT_CLICK_FOR_DETAILS = "Click for details...";
        public const string TEXT_CLICK_FOR_SITE = "Click to open site...";
        public const string TEXT_SIGNED_OUT = "SIGNEDOUT";
        public const string TEXT_ISPT = "ISPT";
        public const string TEXT_SITE_INFO_PAGE = "Monthly Usage";
        public const string TEXT_POTABLE_VS_TRADE_WASTE = "Potable vs Trade Waste";
        public const string TEXT_MONTHLY_METER_COST = "Monthly Cost";
        public const string TEXT_SITE_REPORT = "Site Report";
        public const string TEXT_SITE_REPORT_COMBINED = "Site Report Combined";
        public const string TEXT_SCHEDULE = "Schedule";
        public const string TEXT_SCHEDULE_COMBINED = "Schedule Combined";
        public const string TEXT_EXPORT_DESTINATION_TO_ID = "ExportDestination.ToId";
        public const string TEXT_EXPORT_DESTINATION_SUBJECT = "ExportDestination.Subject";
        public const string TEXT_POST = "POST";
        public const string TEXT_ADMINISTRATOR = "Administrator";
        public const string TEXT_HOURS = "Hour(s)";
        public const string TEXT_DAYS = "Day(s)";
        public const string TEXT_MINUTES = "Min(s)";
        public const string TEXT_PVT_POTABLE = "PVT_POTABLE";
        public const string TEXT_PVT_TRADE_WASTE = "PVT_TRADE_WASTE";
        public const string TEXT_POTABLE = "Potable";
        public const string TEXT_TIMESTAMP_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string TEXT_READING_SUFFIX = "_reading";
        public const string TEXT_ENVIRONMENT_EXCEPTION_REPORT_PREFIX = "E_";
        public const string TEXT_CUSTOM_REPORT_PREFIX = "CUSTOM_";
        public const string TEXT_SUREPOINT = "SUREPOINT";
        public const string TEXT_ONEBOX = "OneBox";

        // Charts
        public const string CONFIG_KEY_COLOUR_WATER = "TREND_COLOUR_WATER";
        public const string CONFIG_KEY_COLOUR_ELECTRICITY = "TREND_COLOUR_ELECTRICITY";
        public const string CONFIG_KEY_COLOUR_GAS = "TREND_COLOUR_GAS";
        public const string CONFIG_KEY_COLOUR_EC = "TREND_COLOUR_EC";
        public const string CONFIG_KEY_COLOUR_FLOW = "TREND_COLOUR_FLOW";
        public const string CONFIG_KEY_COLOUR_PH = "TREND_COLOUR_PH";
        public const string CONFIG_KEY_COLOUR_TEMP = "TREND_COLOUR_TEMP";
        public const string CONFIG_KEY_COLOUR = "TREND_COLOUR_{0}";
        public const string CONFIG_KEY_COLOUR_DAILY = "TREND_COLOUR_DAILY";
        public const string CONFIG_KEY_COLOUR_DDS = "TREND_COLOUR_DDS";
        public const string CONFIG_KEY_COLOUR_COMPARISON_1 = "TREND_COLOUR_COMPARISON_1";
        public const string CONFIG_KEY_COLOUR_COMPARISON_2 = "TREND_COLOUR_COMPARISON_2";
        public const string CONFIG_KEY_COLOUR_COMPARISON_3 = "TREND_COLOUR_COMPARISON_3";
        public const string CONFIG_KEY_COLOUR_POTABLE_30_DAY = "TREND_COLOUR_POTABLE_30_DAY";
        public const string CONFIG_KEY_COLOUR_TRADE_WASTE_30_DAY = "TREND_COLOUR_TRADE_WASTE_30_DAY";
        public const string CONFIG_KEY_STATE_BASED_COMPANY_NAMES = "STATE_BASED_COMPANY_NAMES";
        public const string CONFIG_KEY_COMPANIES_WITH_SUMPS = "COMPANIES_WITH_SUMPS";
        public const string CONFIG_KEY_SITES_WITH_SUMPS = "SITES_WITH_SUMPS";
        public const string CONFIG_KEY_COMPANIES_WITH_RIVERS = "COMPANIES_WITH_RIVERS";
        public const string CONFIG_KEY_VERSION_NO = "VERSION_NO";
        public const string CONFIG_KEY_SMTP_HOST = "SMTP_HOST";
        public const string CONFIG_KEY_EMAIL_TO_ADDRESS = "EMAIL_TO_ADDRESS";
        public const string CONFIG_KEY_PORTAL_APPLICATIONS = "PORTAL_APPLICATIONS";

        public const string CONFIG_KEY_COLOUR_SUMMARY_SERIES_0 = "CONFIG_KEY_COLOUR_SUMMARY_SERIES_0";
        public const string CONFIG_KEY_COLOUR_SUMMARY_SERIES_1 = "CONFIG_KEY_COLOUR_SUMMARY_SERIES_1";
        public const string CONFIG_KEY_COLOUR_SUMMARY_SERIES_2 = "CONFIG_KEY_COLOUR_SUMMARY_SERIES_2";

        public const string CONFIG_KEY_COLOUR_NABERS_RATING_0 = "CONFIG_KEY_COLOUR_NABERS_RATING_0";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_1 = "CONFIG_KEY_COLOUR_NABERS_RATING_1";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_2 = "CONFIG_KEY_COLOUR_NABERS_RATING_2";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_3 = "CONFIG_KEY_COLOUR_NABERS_RATING_3";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_4 = "CONFIG_KEY_COLOUR_NABERS_RATING_4";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_4_5 = "CONFIG_KEY_COLOUR_NABERS_RATING_4_5";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_5 = "CONFIG_KEY_COLOUR_NABERS_RATING_5";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_5_5 = "CONFIG_KEY_COLOUR_NABERS_RATING_5_5";
        public const string CONFIG_KEY_COLOUR_NABERS_RATING_6 = "CONFIG_KEY_COLOUR_NABERS_RATING_6";

        public const string CONFIG_KEY_COLOUR_DETAILS_SERIES_0 = "CONFIG_KEY_COLOUR_DETAILS_SERIES_0";
        public const string CONFIG_KEY_COLOUR_DETAILS_SERIES_1 = "CONFIG_KEY_COLOUR_DETAILS_SERIES_1";

        public const string CONFIG_KEY_COLOUR_NABERS = "CONFIG_KEY_COLOUR_NABERS";

        public const string CONFIG_KEY_COLOUR_PORTFOLIO_0 = "CONFIG_KEY_COLOUR_PORTFOLIO_0";
        public const string CONFIG_KEY_COLOUR_PORTFOLIO_1 = "CONFIG_KEY_COLOUR_PORTFOLIO_1";
        public const string CONFIG_KEY_COLOUR_PORTFOLIO_2 = "CONFIG_KEY_COLOUR_PORTFOLIO_2";

        public const string CONFIG_KEY_DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
        public const string UNIT_WATER = "kL";
        public const string UNIT_ELECTRICITY = "kWh";
        public const string UNIT_GAS = "MJ";
        public const string UNIT_EC_1 = "Ms/cm";
        public const string UNIT_CM = "cm";
        public const string UNIT_EC_2 = "uS/cm";
        public const string UNIT_TEMP = "℃";
        public const string UNIT_HUMIDITY = "%";
        public const string UNIT_SOLAR_RADIATION = "w/M2";
        public const string UNIT_WIND_VELOCITY = "m/s";
        public const string UNIT_LTR_SEC = "ltr/s";
        public const string UNIT_LTR_MIN = "ltr/m";
        public const string UNIT_LTR_HR = "ltr/h";
        public const string UNIT_MH = "mH";
        public const string UNIT_MGL = "mg/L";  //This is for milligram per litre
        public const string UNIT_MEGALTR = "ML"; //This is for mega litre
        public const string UNIT_PRESSURE = "bar"; //Pressure

        public const string REPORT_CATEGORY_SUMMARY = "SUMMARY";
        public const string REPORT_CATEGORY_E_SUMMARY = "E_SUMMARY";
        public const string REPORT_CATEGORY_EXCEPTION = "EXCEPTION";
        public const string REPORT_CATEGORY_ENVIRONMENT_EXCEPTION = "E_EXCEPTION";
        public const string REPORT_CATEGORY_LEAK = "LEAK";
        public const string PROPERTY_NAME_USERGROUPIDS = "UserGroupIds";
        public const string METHOD_NAME_GET_USERS = "GetUsers";

        public const string MeterBrandNeedExtraConfigs = "Aegis";

        public const string FriendlySmartMeter = "Friendly";
        public const string LenticSmartMeter = "Lentic";
        public const string VodafoneSmartMeter = "Vodafone";
        public const string SmartMeterFlow = "Flow";
        public const string SmartMeterFlowAccumulated = "Flow Accumulated";

        /// <summary>
        /// Perform sync of: Customers and zones for all products. Sites for Footprint (not meters)
        /// </summary>
        public const string MainSyncJob = "MainDataSync";

        /// <summary>
        /// Perform legacy footprint meters sync
        /// </summary>
        public const string LegacyFootprintMetersSync = "LegacyFootprintMetersSync";

        /// <summary>
        /// Import data from the staging Database into ClearScada
        /// </summary>
        public const string SmartFootprintMetersDataImportSync = "SmartFootprintMetersDataImportSync";
    }
    public static class ConfigKey
    {
        public const string ScadaInvetoryZoneName = "ScadaInvetoryZoneName";
        public const string NewOneBoxTemplateId = "NewOneBoxTemplateId";
        public const string OneBoxCommandUpdateTimeOut = "OneBoxCommandUpdateTimeOut";
        public const string NewBlokaidTemplateId = "NewBlokaidTemplateId";
        public const string NewFootprintSiteTemplateId = "NewFootprintSiteTemplateId";
        public const string NewLegacyBlokaidTemplateId = "NewLegacyBlokaidTemplateId";
        public const string OneBoxCommsObjectId = "OneBoxCommsObjectId";
        public const string BlokaidCommsObjectId = "BlokaidCommsObjectId";

        public const string NewDnp3ChannelNamePrefix = "NewDnp3ChannelNamePrefix";
        public const string NewDnp3OutstationSetNamePrefix = "NewDnp3OutstationSetNamePrefix";
        public const string NewDnp3LineSpeed = "NewDnp3LineSpeed";
        public const string NewDnp3OutstationAddress = "NewDnp3OutstationAddress";
        public const string AdminUser = "AdminUser";
        public const string AdminPassword = "AdminPassword";
        public const string ScadaServer = "ScadaServer";
        public const string SuperUserRoleFullName = "SuperUserRoleFullName";
        public const string UsersGroupName = "UsersGroupName";
        public const string UsersFolderName = "UsersFolderName";
        public const string SyncOnStart = "SyncOnStart";
        public const string NetworkAddressSuffix = "NetworkAddressSuffix";
        public const string SmsEmailSuffix = "SmsEmailSuffix";
        public const string ConfigureAlarmLogic = "ConfigureAlarmLogic";
        public const string CalculationsLogicGroupName = "CalculationsLogicGroupName";
        public const string OneBoxCustomerFolderInScada = "OneBoxCustomerFolderInScada";
        public const string FootprintCustomerFolderInScada = "FootprintCustomerFolderInScada";
        public const string ScadaOneBoxCheckString = "ScadaOneBoxCheckString";
        public const string ScadaFootprintCheckString = "ScadaFootprintCheckString";
        public const string LegacyFootprintUsersGroups = "FootprintUsersGroup";
        public const string RequestThresholdInSeconds = "RequestThresholdInSeconds";
        public const string ScadaBlokaidCheckString = "ScadaBlokaidCheckString";
        public const string ClearScadaProxy = "ClearScadaProxy";
        public const string DuplexCutInLevelDifference = "DuplexCutInLevelDifference";
        public const string CheckSyncQueueFrequency = "CheckSyncQueueFrequency";
        public const string DataSyncSchedule = "DataSyncSchedule";
        public const string BackgroundTaskSchedule = "BackgroundTaskSchedule";
        public const string ScadaConnectionMethod = "ScadaConnectionMethod";
        public const string RollingFileLogLocation = "RollingFileLogLocation";
        public const string SyncTimeoutInMinute = "SyncTimeoutInMinute";

        // Blokaid
        public const string BlokaidCustomerFolderInScada = "BlokaidCustomerFolderInScada";
        public const string ChristchurchEmailBlokaidFolderId = "ChristchurchEmailBlokaidFolderId";
        public const string ChristchurchDefaultZoneNameForEmailBlokaid = "ChristchurchDefaultZoneNameForEmailBlokaid";
        public const string ChristchurchDefaultZoneIdForEmailBlokaid = "ChristchurchDefaultZoneIdForEmailBlokaid";
        public const string ChristchurchCustNameForEmailBlokaid = "ChristchurchCustNameForEmailBlokaid";
        public const string ChristchurchCustIdForEmailBlokaid = "ChristchurchCustIdForEmailBlokaid";
        public const string AdvancedBlokaidDnp3StationSetId = "AdvancedBlokaidDnp3StationSetId";
        public const string BlokaidConfigFileToDeviceLocation = "BlokaidConfigFileToDeviceLocation";
        public const string BlokaidConfigFileFromDeviceLocation = "BlokaidConfigFileFromDeviceLocation";
        public const string BlokaidConfigProcessedLocation = "BlokaidConfigProcessedLocation";
        public const string BlokaidConfigSyncFrequencyInDays = "BlokaidConfigSyncFrequencyInDays";

        public const string DataMeterSyncSchedule = "DataMeterSyncSchedule";
        public const string SmartMeterSyncSchedule = "SmartMeterSyncSchedule";

        public const string NewFootprintWaterMeterTemplateId = "NewFootprintWaterMeterTemplateId";
        public const string NewFootprintElectricityMeterTemplateId = "NewFootprintElectricityMeterTemplateId";
        public const string NewFootprintFriendlySmartMeterTemplateId = "NewFootprintFriendlySmartMeterTemplateId";
        public const string NewFootprintLenticSmartMeterTemplateId = "NewFootprintLenticSmartMeterTemplateId";
        public const string NewFootprintGasMeterTemplateId = "NewFootprintGasMeterTemplateId";
        public const string NewFootprintLevelSensorTemplateId = "NewFootprintLevelSensorTemplateId";
        public const string NewFootprintWaterMeterReadingTemplateId = "NewFootprintWaterMeterReadingTemplateId";
        public const string NewFootprintFlowTemplateId = "NewFootprintFlowTemplateId";
        public const string NewFootprintFlowRateTemplateId = "NewFootprintFlowRateTemplateId";
        public const string NewFootprintInstantaneousFlowTemplateId = "NewFootprintInstantaneousFlowTemplateId";
        public const string NewFootprintBatteryVoltsTemplateId = "NewFootprintBatteryVoltsTemplateId";
        public const string NewFootprintChlorineTemplateId = "NewFootprintChlorineTemplateId";
        public const string NewFootprintDOTemplateId = "NewFootprintDOTemplateId";
        public const string NewFootprintDigitalTemplateId = "NewFootprintDigitalTemplateId";
        public const string NewFootprintECTemplateId = "NewFootprintECTemplateId";
        public const string NewFootprintEvapotranspirationTemplateId = "NewFootprintEvapotranspirationTemplateId";
        public const string NewFootprintOxidationReductionPotentialTemplateId = "NewFootprintOxidationReductionPotentialTemplateId";
        public const string NewFootprintFreeChlorineTemplateId = "NewFootprintFreeChlorineTemplateId";
        public const string NewFootprintHumidityTemplateId = "NewFootprintHumidityTemplateId";
        public const string NewFootprintPHTemplateId = "NewFootprintPHTemplateId";
        public const string NewFootprintPressureTemplateId = "NewFootprintPressureTemplateId";
        public const string NewFootprintPumpRun1TemplateId = "NewFootprintPumpRun1TemplateId";
        public const string NewFootprintRainTotalTemplateId = "NewFootprintRainTotalTemplateId";
        public const string NewFootprintSolarRadiationTemplateId = "NewFootprintSolarRadiationTemplateId";
        public const string NewFootprintTempTemplateId = "NewFootprintTempTemplateId";
        public const string NewFootprintTurbidityTemplateId = "NewFootprintTurbidityTemplateId";
        public const string NewFootprintVelocityTemplateId = "NewFootprintVelocityTemplateId";
        public const string NewFootprintWindDirectionTemplateId = "NewFootprintWindDirectionTemplateId";
        public const string NewFootprintHSTemplateId = "NewFootprintHSTemplateId";

        public const string NewExceptionReportTemplateId = "NewExceptionReportTemplateId";
        public const string NewLeakReportTemplateId = "NewLeakReportTemplateId";
        public const string NewSummaryReportTemplateId = "NewSummaryReportTemplateId";
        public const string NewEnvExceptionReportTemplateId = "NewEnvExceptionReportTemplateId";
        public const string NewEnvSummaryReportTemplateId = "NewEnvSummaryReportTemplateId";

        public const string NewFootprintCustomerTemplateId = "NewFootprintCustomerTemplateId";
        public const string FriendServerClientSecret = "FriendServerClientSecret";
        public const string FriendServerScope = "FriendServerScope";
        public const string FriendServerClientId = "FriendServerClientId";
        public const string FriendServerRestApiHost = "FriendServerRestApiHost";
    }
}