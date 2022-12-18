using Sijl;

namespace UI.Helpers;

public static class ErrorMessageHelper
{
    public static string BuildError(Err err)
    {
        var message = string.Empty;
        const string please = "Please enter a valid ";
        switch (err)
        {
            case Err.Ok:
                break;
            case Err.GeneratingToken:
                message = "Something wrong happened";
                break;
            case Err.InvalidFirstName:
                message = please + "first name";
                break;
            case Err.InvalidLastName:
                message = please + "last name";
                break;
            case Err.InvalidEmail:
                message = please + "email address";
                break;
            case Err.InvalidAge:
                message = please + "age";
                break;
            case Err.InvalidUsername:
                message = please + "username";
                break;
            case Err.AlreadyUsedUsername:
                message = $"The username is already used, try to login instead";
                break;
            case Err.InvalidPassword:
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