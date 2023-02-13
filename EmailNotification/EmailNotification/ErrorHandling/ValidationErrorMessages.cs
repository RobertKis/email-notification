namespace EmailNotification.ErrorHandling
{
    public static class ValidationErrorMessages
    {
        public static string GetErrorMessage(ValidationErrors error)
        {
            if (error == ValidationErrors.NoFrom)
                return "From field empty";

            if (error == ValidationErrors.NoTo)
                return "To field empty";

            if (error == ValidationErrors.NoSubject)
                return "Subject field empty";

            if (error == ValidationErrors.InvalidCC)
                return "One of the CCd emails is not in the correct format";

            if (error == ValidationErrors.NoData)
                return "No data submitted";

            if (error == ValidationErrors.InvalidImportance)
                return "Importance not specified correctly";

            if (error == ValidationErrors.InvalidFrom)
                return "From field email not valid";

            if (error == ValidationErrors.InvalidTo)
                return "To field email not vali";

            return "";
        }
    }
}
