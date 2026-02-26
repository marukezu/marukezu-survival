using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    // Painel (Gameplay) Talentos.
    public static Action On_Panel_Talents_CancelChoise;
    public static Action<Hero_Talents.TalentType, bool> On_TalentHoverChanged;
}
