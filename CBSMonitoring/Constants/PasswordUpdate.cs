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
        public const string OldPasswordNotConfirmed = "Старый пароль не подтвержден";
        public const string NewAndOldPasswordIdentical = "Новый и старый пароли идентичны";
        public const string NewPasswordTooWeak = "Новый пароль слишком слабый";
        public const string PasswordUpdateSuccceded = "Пароль успешно обновлен";
        public const string PasswordUpdateFailed = "Обновление пароля не удалось";
    }
}
