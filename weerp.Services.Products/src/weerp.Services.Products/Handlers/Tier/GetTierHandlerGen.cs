using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.Mongo;
using System.Threading.Tasks;
using weerp.domain.tiers.Dto;
using weerp.domain.tiers.Queries;
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
    /// Get Tier Handler
    /// </summary>
    public partial class GetTierHandler :  IQueryHandler<GetTier, TierDto>
    {
        

        #region Constructors
        public GetTierHandler(
            IBrowseTierRepository repository,
             IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        #endregion

        #region public properties
        public IBrowseTierRepository Repository{get;}
        public IMapper Mapper{get;}
        #endregion

        #region public functions
        /// <summary>
        ///  Handle the command with context
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <param name="context">The correlation context</param>
        /// <returns></returns>
        public async Task<TierDto> HandleAsync(GetTier query)
        {
            var model = await Repository.GetAsync(query.Id);

            return model == null ? null : Mapper.Map<TierDto>(model);

        }
        #endregion
    }
}