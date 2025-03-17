using Microsoft.EntityFrameworkCore;

namespace DI_webApiNotification_001.Data.Context;

public class NotificationContext(DbContextOptions options) : DbContext(options)
{
}
