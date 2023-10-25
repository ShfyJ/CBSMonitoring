namespace CBSMonitoring.Constants
{
    public enum PasswordUpdate
    {
        OldPasswordNotConfirmed = 0,
        NewAndOldPasswordIdentical = 1,
        NewPasswordTooWeak = 2,
        PasswordUpdateFailed = 3,
        PasswordUpdateSucceded = 4,
    }

    public static class PasswordUpdateMessage
    {
        public const string OldPasswordNotConfirmed = "Old password is not confirmed";
        public const string NewAndOldPasswordIdentical = "New and old passwords are identical";
        public const string NewPasswordTooWeak = "New password is too weak";
        public const string PasswordUpdateSuccceded = "Password is updateed successfully";
        public const string PasswordUpdateFailed = "Password update failed";
    }
}
