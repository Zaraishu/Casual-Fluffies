
using UnityEngine;

/**
 * <summary>
 * Abstract base class for seasons.
 */
public abstract class ASeason
{
    public int SeasonLength { get => seasonLength; }
    [SerializeField]
    public virtual string Name { get; }

    /**
     * <summary>
     * The length of each season, in days.
     * </summary>
     */
    private const int seasonLength = 3;

    public readonly string Music;

    public abstract PlantGrowthChances GetPlantGrowthChances();
    public abstract ASeason NextSeason();
}
