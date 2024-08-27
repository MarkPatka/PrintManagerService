using ErrorOr;

namespace PrintManager.Domain.Common.Errors;

public static partial class Errors
{
    public static class Installation
    {
        public static Error ValidationError => Error.Validation(
            code: "The installation data is invalid");

        public static Error Error => Error.Validation(
            code: "The request body is Empty");

        public static Error ServerError => Error.Failure(
            code: "Internal server error");

        public static Error DefaultDeviceDelete => Error.Conflict(
            code: "Unable to delete an installation of default device");
    }
}
