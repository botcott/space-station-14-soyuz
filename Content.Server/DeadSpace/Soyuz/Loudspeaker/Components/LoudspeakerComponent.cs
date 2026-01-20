// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use, full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT
using Content.Shared.Damage;
using Robust.Shared.Prototypes;
using Content.Shared.Damage.Prototypes;
using Content.Shared.EntityEffects.Effects;

namespace Content.Server.DeadSpace.Loudspeaker;

[RegisterComponent]
public sealed partial class LoudspeakerComponent : Component
{
    [DataField]
    public float DurationOfSpeedBuff = 0f;

    [DataField]
    public float DurationOfArmorBuff = 0f;

    [DataField(required: true)]
    public DamageSpecifier Damage = default!;

    [DataField(required: true)]
    public ProtoId<DamageModifierSetPrototype> LoudspeakerBuffModifier;

    [DataField(required: true)]
    public MovespeedModifier MovespeedModifierEffect = default!;

    public string BuffArmorActionId = "ActionLoudspeakerArmor";

    public string BuffHealActionId = "ActionLoudspeakerHeal";

    public string BuffSpeedActionId = "ActionLoudspeakerSpeed";

    public EntityUid? ArmorAction = default!;

    public EntityUid? SpeedAction = default!;

    public EntityUid? HealAction = default!;
}
