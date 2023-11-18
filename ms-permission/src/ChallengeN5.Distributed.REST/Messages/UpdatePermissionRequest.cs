namespace ChallengeN5.Distributed.REST.Messages
{
    public class UpdatePermissionRequest
    {
        public required string Forename { get; set; }
        public required string Surname { get; set; }
        public required int Type { get; set; }
    }
}
