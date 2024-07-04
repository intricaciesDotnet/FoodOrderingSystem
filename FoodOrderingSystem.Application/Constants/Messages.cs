namespace FoodOrderingSystem.Application.Constants;

public static class Messages
{
    public const string EmailValidator = "Email is required";
    public const string InvalidEmailValidator = "Invalid Email";
    public const string NameValidator = "Name is required";
    public const string PasswordValidator = "Password is required";
    public const string PhoneValidator = "Phonenumber is required";


    public const int MinLen = 3;
    public const int MaxLen = 30;
}

public static class RegexPatterns
{
    public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
}
