namespace ChallengeN5.Domain.AggregateRoots.Permission
{
    public class PermissionType
    {
        private PermissionType() { }

        public PermissionType(string description)
        {
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
