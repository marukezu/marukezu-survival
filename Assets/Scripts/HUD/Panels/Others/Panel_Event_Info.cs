using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventInfo
{
    // Configurações de Texto
    public string Text = "";
    public bool UseText = false;
    
    public EventInfo(bool useText, string text)
    {
        UseText = useText;
        Text = text;
    }
}

public class Panel_Event_Info : Panel
{
    public override PanelType Type => PanelType.EVENT_INFO;

    public TextMeshProUGUI TXT_EventInfoText;
    private EventInfo eventInfo;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        base.AbrirPainel(param1, param2, param3);

        // Destroi esse painel automaticamente em 5 segundos.
        Destroy(gameObject, 5f); 

        // Recebe as informações desse evento por parâmetro.
        eventInfo = param1 as EventInfo;

        // Texto informativo, caso o evento use.
        if (eventInfo.UseText)
        {
            TXT_EventInfoText.text = eventInfo.Text;
        }
        else
        {
            TXT_EventInfoText.gameObject.SetActive(false);
        }
    }
}
