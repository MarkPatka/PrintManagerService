using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.Enumerations;

public class ConnectionType : Enumeration
{
    public static ConnectionType LOCAL_CONNECTION = new(1, "Локальное подключение");
    public static ConnectionType NETWORK_CONNECTION = new(2, "Сетевое подключение");

    public ConnectionType(int id, string value) 
        : base(id, value) { }
}
