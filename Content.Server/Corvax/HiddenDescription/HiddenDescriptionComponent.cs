using Content.Shared.Roles;
using Content.Shared.Whitelist;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Server.Corvax.HiddenDescription;

/// <summary>
/// A component that shows players with specific roles or jobs additional information about entities
/// </summary>

[RegisterComponent, Access(typeof(HiddenDescriptionSystem))]
public sealed partial class HiddenDescriptionComponent : Component
{
    [DataField(required: true)]
    public List<HiddenDescriptionEntry> Entries = new();
}

[DataDefinition, Serializable]
public readonly partial record struct HiddenDescriptionEntry()
{
    /// <summary>
    /// loc string with secret description
    /// </summary>
    [DataField(required: true)]
    public LocId Label { get; init; } = default!;

    /// <summary>
    /// A player's mind must pass a whitelist check to receive hidden information
    /// </summary>
    [DataField]
    public EntityWhitelist WhitelistMind { get; init; } = new();

    /// <summary>
    /// The player's mind has to have some job role to access the hidden information
    /// </summary>
    [DataField]
    public List<ProtoId<JobPrototype>> JobRequired { get; init; } = new();

    /// <summary>
    /// If true, the player needs to go through and whitelist, and have some work to get scrutiny. By default, one of two successful checks is sufficient.
    /// </summary>
    [DataField]
    public bool NeedBoth { get; init; } = false;
}
