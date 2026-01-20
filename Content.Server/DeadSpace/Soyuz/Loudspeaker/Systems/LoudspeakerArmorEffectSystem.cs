// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use, full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT
using Content.Shared.Damage.Components;
using Robust.Shared.Prototypes;

namespace Content.Server.DeadSpace.Loudspeaker;

public sealed class LoudspeakerArmorEffectSystem : EntitySystem
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LoudspeakerArmorEffectComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<LoudspeakerArmorEffectComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnInit(EntityUid uid, LoudspeakerArmorEffectComponent component, ComponentInit args)
    {
        if (!_prototypeManager.Resolve(component.DamageModifier, out var modifier))
            return;

        var buffComp = EnsureComp<DamageProtectionBuffComponent>(uid);
        if (!buffComp.Modifiers.ContainsKey(component.DamageModifier))
            buffComp.Modifiers.Add(component.DamageModifier, modifier);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var enumerator = EntityQueryEnumerator<LoudspeakerArmorEffectComponent>();

        while (enumerator.MoveNext(out var uid, out var comp))
        {
            comp.Accumulator += frameTime;

            if (comp.Accumulator < comp.DurationOfBuff)
                continue;

            RemComp<LoudspeakerArmorEffectComponent>(uid);
        }
    }

    private void OnShutdown(EntityUid uid, LoudspeakerArmorEffectComponent component, ComponentShutdown args)
    {
        if (!TryComp<DamageProtectionBuffComponent>(uid, out var buffComp))
            return;

        buffComp.Modifiers.Remove(component.DamageModifier);
        if (buffComp.Modifiers.Count == 0)
            RemComp<DamageProtectionBuffComponent>(uid);
    }
}