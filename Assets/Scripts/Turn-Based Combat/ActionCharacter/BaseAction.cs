using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    public abstract class BaseAction : ScriptableObject
    {
        public abstract void DoAction(BaseUnit baseUnit);
    }
}