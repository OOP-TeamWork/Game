using System.Collections.Generic;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Interfaces
{
    public interface ITargetSpells
    {
        IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList);
    }
}
