using Perrors;

namespace UI.Helpers;

public static class ErrorMessageHelper
{
    public static string BuildError(int n)
    {
        var message = string.Empty;
        var err = (Errors) n;
        const string please = "Please enter a valid ";
        switch (err)
        {
            case Errors.Ok:
                break;
            case Errors.GeneratingToken:
                message = "Something wrong happened";
                break;
            case Errors.InvalidFirstName:
                message = please + "first name";
                break;
            case Errors.InvalidLastName:
                message = please + "last name";
                break;
            case Errors.InvalidEmail:
                message = please + "email address";
                break;
            case Errors.InvalidAge:
                message = please + "age";
                break;
            case Errors.InvalidUsername:
                message = please + "username";
                break;
            case Errors.AlreadyUsedUsername:
                message = $"The username is already used, try to login instead";
                break;
            case Errors.InvalidPassword:
                message =
                    "The password you used is very weak, please add more special characters and different letter cases";
                break;
            default:
                message = "Something wrong happened";
                break;
        }

        return message;
    }
}