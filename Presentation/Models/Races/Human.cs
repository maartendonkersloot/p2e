using Presentation.Models.Enums;

namespace Presentation.Models.Races;

public class Human : BaseRace
{
    public Human()
    {
        HitPoints = 8;
        Size = CharacterSize.Medium;
        Speed = 25;
        Gender = "Male";
        Alignment = "Neutral";
        Experience = 0;
        Level = 1;
        AttributeBoosts =
        [
            CharacterAttribute.Constitution,
            CharacterAttribute.Intelligence
        ];
        LanguagesList = 
        [
            Language.Gnomish
        ];
        Attributes = CalculateAttributes(Attributes, AttributeFlaws, AttributeBoosts);
    }
}