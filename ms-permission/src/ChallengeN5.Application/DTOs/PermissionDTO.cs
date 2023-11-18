namespace ChallengeN5.Application.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int TypeId { get; set; }
        public string TypeDescription { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}
