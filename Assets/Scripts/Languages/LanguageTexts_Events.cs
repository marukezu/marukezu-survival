using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Events
{
    private static void Register_Event_Siege_Texts()
    {
        LanguageManager.Register("Event Siege Announcement", 
            "Um cerco se formou a sua volta, tome cuidado!", 
            "A siege has formed around you, be careful!");

        LanguageManager.Register("Event Siege Finished", 
            "O cerco terminou.", 
            "The siege has finished.");
    }
    private static void Register_Event_Boss_Texts()
    {
        LanguageManager.Register("Event Boss Announcement", 
            "Um inimigo poderoso entrou para o combate, tome cuidado!", 
            "A powerful enemy has entered the fight, be careful!");
    }
    private static void Register_Event_DoubleSpawnRate_Texts()
    {
        LanguageManager.Register(
            "Event DoubleSpawnRate Announcement",
            "A taxa de spawn dos monstros aumentou! Prepare-se!",
            "The monster spawn rate has increased! Get ready!"
        );

        LanguageManager.Register(
            "Event DoubleSpawnRate Finished",
            "A taxa de spawn dos monstros retornou ao normal",
            "The monster spawn rate has returned to normal."
        );
    }

    // ========================================================
    // MÉTODO REGISTRAR TODOS TEXTOS
    // ========================================================
    public static void RegisterAll()
    {

        // Evento Siege
        Register_Event_Siege_Texts();

        // Evento Boss
        Register_Event_Boss_Texts();

        // Evento Double Spawn Rate
        Register_Event_DoubleSpawnRate_Texts();
    }
}

