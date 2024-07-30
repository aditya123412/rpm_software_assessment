using System.ComponentModel;

namespace assessment_platform_developer.Models
{
    public enum Countries
    {
        Canada,
        [Description("United States")]
        UnitedStates
    }
    public enum USStates
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        [Description("New Hampshire")]
        NewHampshire,
        [Description("New Jersey")]
        NewJersey,
        [Description("New Mexico")]
        NewMexico,
        [Description("New York")]
        NewYork,
        [Description("North Carolina")]
        NorthCarolina,
        [Description("North Dakota")]
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        [Description("Rhode Island")]
        RhodeIsland,
        [Description("South Carolina")]
        SouthCarolina,
        [Description("South Dakota")]
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        [Description("West Virginia")]
        WestVirginia,
        Wisconsin,
        Wyoming
    }

    public enum CanadianProvinces
    {
        Alberta,
        [Description("British Columbia")]
        BritishColumbia,
        Manitoba,
        NewBrunswick,
        [Description("Newfoundland and Labrador")]
        NewfoundlandAndLabrador,
        [Description("Northwest Territories")]
        NovaScotia,
        Ontario,
        [Description("Prince Edward Island")]
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan,
        [Description("Yukon")]
        NorthwestTerritories,
        Nunavut,
        Yukon
    }
}