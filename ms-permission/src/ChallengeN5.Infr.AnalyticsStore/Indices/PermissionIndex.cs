using ChallengeN5.Domain.AggregateRoots.Permission;

namespace ChallengeN5.Infr.AnalyticsStore.Indices
{
    internal class PermissionIndex
    {
        internal PermissionIndex() { }
        internal PermissionIndex(Permission permission)
        {
            Id = permission.Id;
            CreatedDate = permission.CreatedDate;
            Forename = permission.Forename;
            Surname = permission.Surname;
            TypeId = permission.TypeId;
        }
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int TypeId { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}
