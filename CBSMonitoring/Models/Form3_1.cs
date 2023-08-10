namespace CBSMonitoring.Models
{
    public class Form3_1 : OrgMonitoring //3.1
    {
        public bool? IsPasswProtectInWRooms { get; set; }
        public int? NumberOfWRoomsWithPasswProtection { get; set; }
        public string? FrequencyOfPasswUpdateInWRooms { get; set; }
        public bool? IsPasswProtectInSRooms { get; set; }
        public int? NumberOfSRoomsWithPasswProtection { get; set; }
        public string? FrequncyOfPasswUpdateInSRooms { get; set; }

    }
}
