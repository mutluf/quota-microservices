using EventBus.Messages.Events;
using MassTransit;
using Quota.Aggregator.Services;

namespace Quota.Aggregator.Consumers
{
    public class QuoteCreatedConsumer : IConsumer<QuoteCreatedEvent>
    {
        private readonly IUserQuoteService _userQuoteService;

        public QuoteCreatedConsumer(IUserQuoteService userQuoteService)
        {
            _userQuoteService = userQuoteService;
        }

        public async Task Consume(ConsumeContext<QuoteCreatedEvent> context)
        {
            QuoteCreatedEvent data = context.Message;

            await _userQuoteService.PostQuoteAsync(new()
            {
                QuoteId = data.QuoteId,
                Username = "deneme"
            });
        }
    }
}
