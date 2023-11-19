using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Exceptions
{
    public class NullOrEmptyException : BusinessException
    {
        public NullOrEmptyException(string property) : base($"{property} must not be null or empty.") { }
    }
}
