using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Types;
using MicroS_Common.Mongo;
using System.Threading.Tasks;
using weerp.domain.tiers.Domain;
using weerp.domain.tiers.Messages.Commands;
using weerp.domain.tiers.Messages.Events;
using weerp.Services.Products.Repositories;

/// <summary>
/// This file was generated by the yeoman generator "generator-micros"
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Sun May 31 2020 14:29:59 GMT+0200 (GMT+02:00)
/// </summary>
namespace weerp.Services.Products.Handlers
{
    /// <summary>
    /// Delete Tier Handler
    /// </summary>
    public partial class CreateTierHandler : DomainCommandHandler<CreateTier,Tier>
    {
        

        #region Constructors
        public CreateTierHandler(
            IBrowseTierRepository repository,
            IBusPublisher busPublisher,
            IMapper mapper):base(busPublisher,mapper,repository){}
        #endregion

        #region Protected Overrides functions
        /// <summary>
        /// Check if the model exist by Command
        /// </summary>
        /// <param name="command">The command in wich information can be use do check if the model exist in database</param>
        /// <returns>Nothing</returns>
        protected override async Task CheckExist(Tier domain)
        {
            if (await Repository.ExistsAsync(domain.Id))
            {
                throw new MicroSException("tier_already_exists",$"Tier: '{domain.Id}' already exists.");
            }
           
        }
        #endregion

        #region Public Overrides functions
        /// <summary>
        ///  Handle the command with context
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <param name="context">The correlation context</param>
        /// <returns></returns>
        public override async Task HandleAsync(CreateTier command, ICorrelationContext context)
        {

            await base.HandleAsync(command, context);

            var product = GetDomainObject(command);
            
            await Repository.AddAsync(product);

            await BusPublisher.PublishAsync(CreateEvent<TierCreated>(command), context);
        }
        #endregion
    }
}
