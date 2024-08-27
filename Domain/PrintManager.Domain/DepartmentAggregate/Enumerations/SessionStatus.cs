using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.DepartmentAggregate.Enumerations;

public class SessionStatus : Enumeration
{
    public static SessionStatus SUCCESS = new(1, "Успешно завершено");
    public static SessionStatus IN_PROGRESS = new(2, "Выполняется");
    public static SessionStatus FAILURE = new(3, "Произошла Ошибка");

    private SessionStatus() { }

    public SessionStatus(int id, string value)
        : base(id, value) { }

    public static SessionStatus GetStatus(int code)
    {
        return code switch
        {
            1 => SUCCESS,
            2 => IN_PROGRESS,
            3 => FAILURE,
            _ => throw new Exception($"Unknown status code: {code}")
        };
    }
}
