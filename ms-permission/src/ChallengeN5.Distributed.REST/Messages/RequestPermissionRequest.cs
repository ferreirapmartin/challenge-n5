﻿namespace ChallengeN5.Distributed.REST.Messages
{
    public class RequestPermissionRequest
    {
        public required string Forename { get; set; }
        public required string Surname { get; set; }
        public required int Type { get; set; }
    }
}