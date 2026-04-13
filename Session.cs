namespace Finance_Management_Sys
{
    public static class Session
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUserName { get; set; }
        public static string CurrentUserRole { get; set; }

        // 🔹 Event for balance update
        public static event Action<decimal> OnBalanceUpdated;

        // 🔹 Trigger method
        public static void RaiseBalanceUpdated(decimal newBalance)
        {
            OnBalanceUpdated?.Invoke(newBalance);
        }
    }
}


