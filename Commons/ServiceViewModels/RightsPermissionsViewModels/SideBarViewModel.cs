namespace App.Wiz.Common.ServiceViewModels.RightsPermissionsViewModels
{
    public class SideBarViewModel
    {
        public class Child
        {
            public string? path { get; set; }
            public string? title { get; set; }
            public string? type { get; set; }
        }
        public class Root
        {
            public string? headTitle1 { get; set; }
            public string? path { get; set; }
            public string? icon { get; set; }
            public string? title { get; set; }
            public string? type { get; set; }
            public string? badgeType { get; set; }
            public string? badgeValue { get; set; }
            public bool? active { get; set; }
            public List<Child>? children { get; set; }
        }
    }
}
