namespace ChallengeN5.Infr.DataAccess.Configuration
{
    internal class DababaseSeed
    {
        public static IEnumerable<object> PermissionTypes { get; } = [
            new { Id = 1, Description = "ADMIN" },
            new { Id = 2, Description = "READ_WRITE" },
            new { Id = 3, Description = "WRITE" },
            new { Id = 4, Description = "READ" }
        ];

        public static IEnumerable<object> Permissions { get; } = [
            new { Id = 1, Forename = "Miguel", Surname = "Garcia", TypeId = 1, CreatedDate = new DateOnly(2023, 11, 14) },
            new { Id = 2, Forename = "Pedro", Surname = $"Pereira", TypeId = 3, CreatedDate = new DateOnly(2023, 11, 14) }
        ];

    }
}
