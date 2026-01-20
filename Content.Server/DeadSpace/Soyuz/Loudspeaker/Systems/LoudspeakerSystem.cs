// Мёртвый Космос, Licensed under custom terms with restrictions on public hosting and commercial use, full text: https://raw.githubusercontent.com/dead-space-server/space-station-14-fobos/master/LICENSE.TXT

using Content.Shared.Actions;
using Content.Shared.Hands;
using Content.Server.Actions;

namespace Content.Server.DeadSpace.Loudspeaker;

public sealed class LoudspeakerSystem : EntitySystem
{
    [Dependency] private readonly ActionsSystem _actions = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LoudspeakerComponent, LoudspeakerArmorBuffActionEvent>(OnArmorAction);
        SubscribeLocalEvent<LoudspeakerComponent, LoudspeakerHealingBuffActionEvent>(OnHealingAction);
        SubscribeLocalEvent<LoudspeakerComponent, LoudspeakerSpeedBuffActionEvent>(OnSpeedAction);
    }

    private void OnArmorAction(EntityUid uid, LoudspeakerComponent component, LoudspeakerArmorBuffActionEvent args)
    {
        if (args.Handled)
            return;

        args.Handled = true;
    }

    private void OnHealingAction(EntityUid uid, LoudspeakerComponent component, LoudspeakerHealingBuffActionEvent args)
    {
        if (args.Handled)
            return;

        args.Handled = true;
    }

    private void OnSpeedAction(EntityUid uid, LoudspeakerComponent component, LoudspeakerSpeedBuffActionEvent args)
    {
        if (args.Handled)
            return;

        args.Handled = true;
    }
}