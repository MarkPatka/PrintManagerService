using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.Enumerations;

public class ConnectionType : Enumeration
{
    public static ConnectionType LocalConnection = new(1, "Локальное подключение");
    public static ConnectionType NetworkConnection = new(2, "Сетевое подключение");

    public ConnectionType(int id, string value) 
        : base(id, value) { }
}
