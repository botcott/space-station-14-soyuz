// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use, full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT

using Robust.Shared.Prototypes;
using Content.Shared.Damage.Prototypes;

namespace Content.Server.DeadSpace.Loudspeaker;

[RegisterComponent]
public sealed partial class LoudspeakerArmorEffectComponent : Component
{
    public LoudspeakerArmorEffectComponent(float duration, ProtoId<DamageModifierSetPrototype> damageModifier)
    {
        DurationOfBuff = duration;
        DamageModifier = damageModifier;
    }

    [DataField]
    public float DurationOfBuff = 0f;

    public float Accumulator = 0f;

    [DataField]
    public ProtoId<DamageModifierSetPrototype> DamageModifier = default!;
}
