using Presentation.Models.Enums;

namespace Presentation.Models.Races;

public abstract class BaseRace
{
    public Dictionary<CharacterAttribute, int> Attributes { get; set; } = new()
    {
        { CharacterAttribute.Strength, 0 }, 
        { CharacterAttribute.Dexterity, 0 }, 
        { CharacterAttribute.Constitution, 0 }, 
        { CharacterAttribute.Intelligence, 0 }, 
        { CharacterAttribute.Wisdom, 0 }, 
        { CharacterAttribute.Charisma, 0 }
    };
    
    public string? Gender { get; set; }
    
    public string? Alignment { get; set; }
    
    public string? Name { get; set; }
    
    public int Experience { get; set; }
    
    public int Level { get; set; }
    protected double Speed { get; set; }
    
    public int HitPoints { get; set; }
    
    public CharacterSize Size { get; set; }
    
    protected List<CharacterAttribute> AttributeFlaws { get; set; } = [];
    
    protected List<CharacterAttribute> AttributeBoosts { get; set; } = [];
    
    public List<Language> LanguagesList { get; set; } = [];

    public Dictionary<CharacterAttribute, int> CalculateAttributes(
        Dictionary<CharacterAttribute, int> currentAttributes,
        List<CharacterAttribute> attributeFlaws, 
        List<CharacterAttribute> attributeBoosts )
    {
        Dictionary<CharacterAttribute, int> newAttributeList = new Dictionary<CharacterAttribute, int>();
        foreach (var characterAttribute in currentAttributes)
        {
            var boostAttributeAmount = attributeBoosts.Count(x => x == characterAttribute.Key);
            var flawAttributeAmount = attributeFlaws.Count(x => x == characterAttribute.Key);
            var newAttributeValue = (characterAttribute.Value + boostAttributeAmount) - flawAttributeAmount;
            newAttributeList.Add(characterAttribute.Key, newAttributeValue);
        }
        return newAttributeList;
    }
    
    public double GetSpeedInImperial()
    {
        return Speed;   
    }

    public double GetSpeedInMeters()
    {
        return Speed * 0.3048;
    }
}