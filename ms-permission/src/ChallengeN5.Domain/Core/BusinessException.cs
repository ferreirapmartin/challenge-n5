﻿namespace ChallengeN5.Domain.Core
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
