using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterGen.DataTypes
{
    public interface IDataStructure
    {
        void AddCharacter(Character c);
        IEnumerable<Character> GetAllCharacters();
    }
}
