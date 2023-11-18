using Confluent.Kafka;

namespace ChallengeN5.Infr.EventStore.Config
{
    public class EventStoreConfig : ProducerConfig
    {
        public string TopicName { get; set; }
    }
}
