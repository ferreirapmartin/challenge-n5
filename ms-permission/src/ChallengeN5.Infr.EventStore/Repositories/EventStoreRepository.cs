using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Core;
using ChallengeN5.Infr.EventStore.Config;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ChallengeN5.Infr.EventStore.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreConfig _config;

        public EventStoreRepository(IOptions<EventStoreConfig> config)
        {
            _config = config.Value;
        }

        public async Task SaveAsync(BaseEvent @event)
        {
            using (var producer = new ProducerBuilder<string, string>(_config).SetKeySerializer(Serializers.Utf8)
                                                                              .SetValueSerializer(Serializers.Utf8)
                                                                              .Build())
            {

                var eventMessage = new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = JsonSerializer.Serialize(new { Id = @event.EventId, NameOperation = @event.EventType })
                };

                var deliveryResult = await producer.ProduceAsync(_config.TopicName, eventMessage);

                if (deliveryResult.Status == PersistenceStatus.NotPersisted)
                {
                    throw new Exception($"Could not produce {@event.GetType().Name} message to topic - {_config.TopicName} due to the following reason: {deliveryResult.Message}.");
                }
            }
        }
    }
}
