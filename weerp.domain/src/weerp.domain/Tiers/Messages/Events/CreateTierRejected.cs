using System;
/// <summary>
/// This file was generated by the yeoman generator "generator-micros"
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Sun May 31 2020 14:29:59 GMT+0200 (GMT+02:00)
/// </summary>
namespace weerp.domain.tiers.Messages.Events
{
    public class CreateTierRejected : TierBaseRejectedEvent
    {
        public CreateTierRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
