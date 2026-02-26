public static class LanguageTexts_Enemy
{
    public enum EnemyWords
    {
        // ==========================================
        // Fase 01 (Floresta)
        // ==========================================

        Bat_Name, Bat_Desc,
        Bat_Boss_Name, Bat_Boss_Desc,

        Wolf_Name, Wolf_Desc,
        Wolf_Boss_Name, Wolf_Boss_Desc,

        DeadTree_Name, DeadTree_Desc,
        DeadTree_Boss_Name, DeadTree_Boss_Desc,

        Spider_Name, Spider_Desc,
        Spider_Boss_Name, Spider_Boss_Desc,

        Skeleton_Name, Skeleton_Desc,
        Skeleton_Boss_Name, Skeleton_Boss_Desc,

        Zombie_Name, Zombie_Desc,
        Zombie_Boss_Name, Zombie_Boss_Desc,


        // ==========================================
        // Fase 02 (Deserto)
        // ==========================================

        Caixao_Name, Caixao_Desc,
        Caixao_Boss_Name, Caixao_Boss_Desc,

        Camelo_Name, Camelo_Desc,
        Camelo_Boss_Name, Camelo_Boss_Desc,

        Djinn_Name, Djinn_Desc,
        Djinn_Boss_Name, Djinn_Boss_Desc,

        Mummy_Name, Mummy_Desc,
        Mummy_Boss_Name, Mummy_Boss_Desc,

        Snake_Name, Snake_Desc,
        Snake_Boss_Name, Snake_Boss_Desc,
    }


    public static readonly LangEntry<EnemyWords>[] Entries =
    {
        // ======================
        // FLORESTA
        new(EnemyWords.Bat_Name, "Morcego Sombrio", "Shadow Bat"),
        new(EnemyWords.Bat_Desc,
            "Criatura ágil das copas escuras, ataca em investidas rápidas e imprevisíveis. Seus olhos brilham antes do ataque.",
            "An agile creature of the dark treetops, striking in fast and unpredictable dives. Its eyes glow just before attacking."),

        new(EnemyWords.Wolf_Name, "Lobo Selvagem", "Wild Wolf"),
        new(EnemyWords.Wolf_Desc,
            "Predador feroz que caça em investidas rápidas. Seus ataques são precisos e brutais.",
            "A fierce predator that hunts in swift charges. Its attacks are precise and brutal."),

        new(EnemyWords.DeadTree_Name, "Árvore Amaldiçoada", "Cursed Tree"),
        new(EnemyWords.DeadTree_Desc,
            "Uma árvore retorcida que ganhou vida nas trevas. Seus galhos funcionam como garras afiadas.",
            "A twisted tree brought to life by dark forces. Its branches act as sharp claws."),

        new(EnemyWords.Spider_Name, "Aranha Sombria", "Shadow Spider"),
        new(EnemyWords.Spider_Desc,
            "Movimenta-se silenciosamente pelo chão, aguardando o momento ideal para atacar com rapidez venenosa.",
            "Moves silently across the ground, waiting for the perfect moment to strike with venomous speed."),

        new(EnemyWords.Skeleton_Name, "Esqueleto Guerreiro", "Warrior Skeleton"),
        new(EnemyWords.Skeleton_Desc,
            "Restos animados por magia obscura. Avança lentamente, mas nunca para até ser destruído.",
            "Remains animated by dark magic. Moves slowly but never stops until destroyed."),

        new(EnemyWords.Zombie_Name, "Zumbi Errante", "Wandering Zombie"),
        new(EnemyWords.Zombie_Desc,
            "Corpo apodrecido que caminha sem descanso. Sua resistência é maior do que aparenta.",
            "A decaying body that walks endlessly. More resilient than it appears."),

        // ======================
        // BOSSES - FLORESTA

        new(EnemyWords.Bat_Boss_Name, "Morcego Abissal", "Abyssal Bat"),
        new(EnemyWords.Bat_Boss_Desc,
            "Uma criatura colossal das trevas que domina os céus da floresta. Seus mergulhos são devastadores e sua presença envolve o campo em sombras.",
            "A colossal creature of darkness that dominates the forest skies. Its dives are devastating and its presence shrouds the battlefield in shadows."),

        new(EnemyWords.Wolf_Boss_Name, "Alfa da Tempestade", "Storm Alpha"),
        new(EnemyWords.Wolf_Boss_Desc,
            "O líder supremo da matilha. Seus uivos fortalecem aliados e suas investidas são imparáveis.",
            "The supreme leader of the pack. Its howls empower allies and its charges are unstoppable."),

        new(EnemyWords.DeadTree_Boss_Name, "Guardião Ancestral", "Ancient Guardian"),
        new(EnemyWords.DeadTree_Boss_Desc,
            "Uma árvore colossal possuída por magia obscura. Seus galhos esmagam o solo e invocam raízes vivas para prender inimigos.",
            "A colossal tree possessed by dark magic. Its branches crush the ground and summon living roots to entangle foes."),

        new(EnemyWords.Spider_Boss_Name, "Matriarca Sombria", "Shadow Matriarch"),
        new(EnemyWords.Spider_Boss_Desc,
            "A rainha das teias. Move-se com velocidade sobrenatural e espalha veneno mortal por todo o campo.",
            "The queen of webs. Moves with unnatural speed and spreads deadly venom across the battlefield."),

        new(EnemyWords.Skeleton_Boss_Name, "Senhor dos Ossos", "Bone Lord"),
        new(EnemyWords.Skeleton_Boss_Desc,
            "Um guerreiro ancestral reanimado por magia profana. Cada golpe ecoa como o som de ossos se partindo.",
            "An ancient warrior reanimated by profane magic. Every strike echoes like the cracking of bones."),

        new(EnemyWords.Zombie_Boss_Name, "Colosso Putrefato", "Putrid Colossus"),
        new(EnemyWords.Zombie_Boss_Desc,
            "Uma massa grotesca de carne corrompida. Avança lentamente, esmagando tudo em seu caminho.",
            "A grotesque mass of corrupted flesh. Moves slowly but crushes everything in its path."),


        // ======================
        // DESERTO
        new(EnemyWords.Caixao_Name, "Caixão Profano", "Profane Coffin"),
        new(EnemyWords.Caixao_Desc,
            "Um caixão selado que se move sozinho pelo deserto. Algo dentro dele luta para escapar.",
            "A sealed coffin that moves across the desert on its own. Something inside struggles to break free."),

        new(EnemyWords.Camelo_Name, "Camelo Selvagem", "Wild Camel"),
        new(EnemyWords.Camelo_Desc,
            "Criatura resistente das dunas, investe com força bruta quando ameaçada.",
            "A resilient creature of the dunes that charges with brute force when threatened."),

        new(EnemyWords.Djinn_Name, "Djinn das Areias", "Sand Djinn"),
        new(EnemyWords.Djinn_Desc,
            "Entidade mística envolta em energia arcana. Move-se flutuando e ataca com poder elemental.",
            "A mystical entity wrapped in arcane energy. Floats across the battlefield and attacks with elemental power."),

        new(EnemyWords.Mummy_Name, "Múmia Ancestral", "Ancient Mummy"),
        new(EnemyWords.Mummy_Desc,
            "Envolta em faixas antigas, desperta para proteger segredos enterrados sob a areia.",
            "Wrapped in ancient bandages, awakened to protect secrets buried beneath the sands."),

        new(EnemyWords.Snake_Name, "Serpente do Deserto", "Desert Serpent"),
        new(EnemyWords.Snake_Desc,
            "Rasteja silenciosamente pelas dunas, atacando com rapidez e presas envenenadas.",
            "Slithers silently through the dunes, striking quickly with venomous fangs."),

        // ======================
        // BOSSES - DESERTO

        new(EnemyWords.Caixao_Boss_Name, "Sarcófago Profano", "Profane Sarcophagus"),
        new(EnemyWords.Caixao_Boss_Desc,
            "Um antigo relicário amaldiçoado que libera ondas de energia sombria. Algo terrível habita em seu interior.",
            "An ancient cursed relic that releases waves of dark energy. Something terrible dwells within."),

        new(EnemyWords.Camelo_Boss_Name, "Titã das Dunas", "Dune Titan"),
        new(EnemyWords.Camelo_Boss_Desc,
            "Uma criatura gigantesca que atravessa o campo como uma tempestade de areia viva.",
            "A gigantic beast that crosses the battlefield like a living sandstorm."),

        new(EnemyWords.Djinn_Boss_Name, "Sultão dos Ventos", "Sultan of Winds"),
        new(EnemyWords.Djinn_Boss_Desc,
            "Um espírito ancestral do deserto que manipula tempestades e energia elemental com maestria.",
            "An ancient desert spirit who commands storms and elemental energy with mastery."),

        new(EnemyWords.Mummy_Boss_Name, "Faraó Esquecido", "Forgotten Pharaoh"),
        new(EnemyWords.Mummy_Boss_Desc,
            "Desperto após eras de sono, governa com maldições antigas e poder necromântico.",
            "Awakened after ages of slumber, rules with ancient curses and necromantic power."),

        new(EnemyWords.Snake_Boss_Name, "Serpente Imperial", "Imperial Serpent"),
        new(EnemyWords.Snake_Boss_Desc,
            "Uma serpente colossal que desliza pelas areias com velocidade assustadora, atacando com veneno letal.",
            "A colossal serpent that glides through the sands with terrifying speed, striking with lethal venom."),

    };
}
