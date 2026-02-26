using System;

public static class LanguageTexts_Spells
{
    public enum SpellWords
    {
        // ZEPHYR - FIRE
        Fireball_Name, Fireball_Desc,
        Explosion_Name, Explosion_Desc,
        FireElemental_Name, FireElemental_Desc,
        Meteor_Name, Meteor_Desc,
        IgnisArrow_Name, IgnisArrow_Desc,

        // ZEPHYR - ICE
        Icicle_Name, Icicle_Desc,
        TornadoFury_Name, TornadoFury_Desc,
        Blizzard_Name, Blizzard_Desc,
        IceTotem_Name, IceTotem_Desc,

        // ZEPHYR - THUNDER
        Thunder_Name, Thunder_Desc,
        ThunderPulse_Name, ThunderPulse_Desc,
        ThunderBall_Name, ThunderBall_Desc,
        Thundera_Name, Thundera_Desc,
        ThunderBarrier_Name, ThunderBarrier_Desc,

        // KAEL - PHYSICAL
        Shuriken_Name, Shuriken_Desc,
        PierceDagger_Name, PierceDagger_Desc,
        TheEightKunais_Name, TheEightKunais_Desc,
        PoisonKunai_Name, PoisonKunai_Desc,
        Agility_Name, Agility_Desc,

        // KAEL - DISTANCE
        Arrow_Name, Arrow_Desc,
        RainOfArrows_Name, RainOfArrows_Desc,
        MultipleShot_Name, MultipleShot_Desc,
        ExplosiveArrow_Name, ExplosiveArrow_Desc,
        ScatterArrow_Name, ScatterArrow_Desc,

        // BROGHAR
        AxeThrow_Name, AxeThrow_Desc,
        CircularCuts_Name, CircularCuts_Desc,
        Earthquake_Name, Earthquake_Desc,
        ShieldThrow_Name, ShieldThrow_Desc,
        Cyclone_Name, Cyclone_Desc,

        // PASSIVAS
        Gauntlet_Name, Gauntlet_Desc,
        Clock_Name, Clock_Desc,
        Boots_Name, Boots_Desc,
        TheHand_Name, TheHand_Desc,
        Heart_Name, Heart_Desc,

        // ESPECIAIS
        Money_Name, Money_Desc,
    }

    public static readonly LangEntry<SpellWords>[] Entries =
    {
        // ZEPHYR - FIRE
        new(SpellWords.Fireball_Name, "Bola de Fogo", "Fireball"),
        new(SpellWords.Fireball_Desc,
            "O mago conjura uma enorme bola de fogo em direção a um inimigo aleatório, causa explosão ao contato, causa queimadura.",
            "The mage conjures a massive fireball towards a random enemy, exploding on contact and causing burn damage."),

        new(SpellWords.Explosion_Name, "Explosão", "Explosion"),
        new(SpellWords.Explosion_Desc,
            "O mago explode tudo à sua volta, causando dano massivo em alvos próximos.",
            "The mage detonates everything around him, dealing massive damage to all nearby enemies."),

        new(SpellWords.FireElemental_Name, "Elemental do Fogo", "Fire Elemental"),
        new(SpellWords.FireElemental_Desc,
            "O mago convoca do submundo um elemental de fogo, que replica todas suas magias, com um dano reduzido.",
            "The mage summons a fire elemental from the underworld that replicates all his spells with reduced damage."),

        new(SpellWords.Meteor_Name, "Meteoro", "Meteor"),
        new(SpellWords.Meteor_Desc,
            "O mago canaliza todo seu poder para conjurar um enorme meteoro em um inimigo aleatório.",
            "The mage channels all his power to summon a massive meteor that crashes down upon a random enemy."),

        new(SpellWords.IgnisArrow_Name, "Flecha Ignis", "Ignis Arrow"),
        new(SpellWords.IgnisArrow_Desc,
            "O mago conjura uma flecha de fogo que perfura e causa queimadura.",
            "The mage conjures a flaming arrow that pierces through enemies and inflicts burning damage over time."),

        // ZEPHYR - ICE
        new(SpellWords.Icicle_Name, "Lança de Gelo", "Icicle"),
        new(SpellWords.Icicle_Desc,
            "O mago conjura uma lança de gelo e arremessa em direção a um inimigo aleatório, congela o alvo.",
            "The mage conjures an icy spear and hurls it at a random enemy, freezing the target on impact."),

        new(SpellWords.TornadoFury_Name, "Fúria do Tornado", "Tornado Fury"),
        new(SpellWords.TornadoFury_Desc,
            "O mago conjura um enorme tornado em direção a um inimigo aleatório, atravessa os alvos.",
            "The mage summons a massive tornado towards a random enemy that tears through all targets in its path."),

        new(SpellWords.Blizzard_Name, "Nevasca", "Blizzard"),
        new(SpellWords.Blizzard_Desc,
            "O mago conjura uma intensa tempestade de gelo sobre o alvo, fazendo chover fragmentos congelantes que causam dano em área e congelam.",
            "The mage conjures an intense ice storm over the target, raining freezing shards that deal area damage and freeze enemies."),

        new(SpellWords.IceTotem_Name, "Totem Gélido", "Ice Totem"),
        new(SpellWords.IceTotem_Desc,
            "O mago conjura um enorme totem de gelo que explode após um curto período causando dano em área, explode alvos congelados.",
            "The mage summons a massive ice totem that explodes after a short delay, dealing area damage and detonating frozen targets."),

        // ZEPHYR - THUNDER
        new(SpellWords.Thunder_Name, "Trovão", "Thunder"),
        new(SpellWords.Thunder_Desc,
            "O mago conjura um raio de trovão em direção a um inimigo aleatório, salta entre os alvos.",
            "The mage calls forth a thunderbolt that strikes a random enemy and chains between multiple targets."),

        new(SpellWords.ThunderPulse_Name, "Pulso Elétrico", "Thunder Pulse"),
        new(SpellWords.ThunderPulse_Desc,
            "O mago conjura um pulso elétrico em um inimigo aleatório causando dano ao seu redor.",
            "The mage unleashes an electric pulse at a random enemy, dealing area damage around the impact point."),

        new(SpellWords.ThunderBall_Name, "Orbe do Trovão", "Thunder Ball"),
        new(SpellWords.ThunderBall_Desc,
            "O mago conjura um orbe eletrificado que pulsa eletricidade por todos alvos próximos.",
            "The mage conjures an electrified orb that continuously emits lightning, shocking all nearby enemies."),

        new(SpellWords.Thundera_Name, "Descarga Elétrica", "Thundera"),
        new(SpellWords.Thundera_Desc,
            "O mago exala eletricidade pura, pulsa rapidamente raios em alvos ao redor.",
            "The mage releases pure electricity, rapidly discharging bolts of lightning at nearby targets."),

        new(SpellWords.ThunderBarrier_Name, "Barreira do Trovão", "Thunder Barrier"),
        new(SpellWords.ThunderBarrier_Desc,
            "O mago usa toda sua energia para projetar uma barreira ao seu redor que protege 100% contra qualquer tipo de dano por alguns segundos.",
            "The mage channels all his energy to create a thunder barrier that grants full protection from all damage for a few seconds."),

        // KAEL - PHYSICAL
        new(SpellWords.Shuriken_Name, "Shurikem", "Shuriken"),
        new(SpellWords.Shuriken_Desc,
            "Shurikens orbitam o jogador, cada nível aumenta o número de shurikens",
            "Shurikens orbit the player, each level increases the number of shurikens"),

        new(SpellWords.PierceDagger_Name, "Adaga Perfurante", "Pierce Dagger"),
        new(SpellWords.PierceDagger_Desc,
            "Arremessa uma adaga em direção a um inimigo aleatório, perfura os alvos, cada nível aumenta o número de adagas arremessadas.",
            "Throw a dagger towards a random enemy, pierce the targets, each level increases the number of daggers thrown."),

        new(SpellWords.TheEightKunais_Name, "As oito kunais", "The Eight Kunais"),
        new(SpellWords.TheEightKunais_Desc,
            "Arremessa oito kunais em torno do jogador, cada dois níveis aumenta o número de arremessos.",
            "Throws eight kunais around the player, every two levels increases the number of throws."),

        new(SpellWords.PoisonKunai_Name, "Kunai Venenosa", "Poison Kunai"),
        new(SpellWords.PoisonKunai_Desc,
            "Arremessa uma kunai impregnada de veneno que busca o inimigo mais próximo, cada nível aumenta o número de kunais venenosas arremessadas.",
            "Throws a kunai impregnated with poison that seeks the closest enemy, each level increases the number of poisonous kunai thrown."),

        new(SpellWords.Agility_Name, "Agilidade", "Agility"),
        new(SpellWords.Agility_Desc,
            "Ativa periodicamente, concedendo velocidade de movimento adicional por alguns segundos.",
            "Periodically activates, granting additional movement speed for a few seconds."),

        // KAEL - DISTANCE
        new(SpellWords.Arrow_Name, "Flecha", "Arrow"),
        new(SpellWords.Arrow_Desc,
            "Dispara uma flecha em direção a um inimigo aleatório, cada nível aumenta o número de flechas disparadas",
            "Shoots an arrow towards a random enemy, each level increases the number of arrows fired"),

        new(SpellWords.RainOfArrows_Name, "Chuva de Flechas", "Rain Of Arrows"),
        new(SpellWords.RainOfArrows_Desc,
            "Dispara várias flechas para o alto que cai em um inimigo aleatório e causa dano em área, cada dois níveis aumenta o número de disparos.",
            "Fires several arrows into the air that fall on a random enemy and cause area damage, every two levels increases the number of shots."),

        new(SpellWords.MultipleShot_Name, "Tiro Multiplo", "Multiple Shot"),
        new(SpellWords.MultipleShot_Desc,
            "Dispara 5 flechas em formato de cone na direção de um inimigo, cada dois níveis aumenta o número de disparos.",
            "Fires 5 cone-shaped arrows towards an enemy, every two levels increases the number of shots."),

        new(SpellWords.ExplosiveArrow_Name, "Flecha Explosiva", "Explosive Arrow"),
        new(SpellWords.ExplosiveArrow_Desc,
            "Dispara uma flecha que explode ao atingir o alvo, causando dano em área e aplicando queimadura. Cada nível aumenta o dano da explosão e da queimadura.",
            "Fires an arrow that explodes upon impact, dealing area damage and applying burn. Each level increases the explosion and burn damage."),

        new(SpellWords.ScatterArrow_Name, "Flecha Estilhaçada", "Scatter Arrow"),
        new(SpellWords.ScatterArrow_Desc,
            "Dispara uma flecha que, ao colidir, se fragmenta em múltiplas flechas que se espalham em diferentes ângulos a partir do ponto de impacto. Cada nível aumenta o número de flechas geradas.",
            "Fires an arrow that fragments upon impact, releasing multiple arrows that spread at different angles from the collision point. Each level increases the number of generated arrows."),


        // BROGHAR
        new(SpellWords.AxeThrow_Name, "Machado Real", "Royal Axe"),
        new(SpellWords.AxeThrow_Desc,
            "Arremessa um enorme machado em direção a um inimigo aleatório, perfura os alvos, cada dois níveis aumenta o número de machados arremessados.",
            "Throws a huge axe towards a random enemy, pierces the targets, every two levels increases the number of axes thrown."),

        new(SpellWords.CircularCuts_Name, "Cortes Circulares", "Circular Cuts"),
        new(SpellWords.CircularCuts_Desc,
            "Disfere golpes rápidos ao seu redor, causando dano em toda a sua volta, cada nível aumenta a duração de tempo dos golpes.",
            "Distributes quick blows around you, causing damage all around you, each level increases the duration of the blows."),

        new(SpellWords.Earthquake_Name, "Terremoto", "Earthquake"),
        new(SpellWords.Earthquake_Desc,
            "Bate com os pés com tamanha força que desencadeia um terremoto ao redor do usuário, cada dois níveis aumenta o número de terremotos provocados.",
            "Hit your feet with such force that it triggers an earthquake around the user, every two levels increases the number of earthquakes caused."),

        new(SpellWords.ShieldThrow_Name, "Lançamento de Escudo", "Shield Throw"),
        new(SpellWords.ShieldThrow_Desc,
            "Arremessa o escudo contra um inimigo aleatório, salta entre alvos, cada nível aumenta o número de escudos arremessados.",
            "Throw the shield at a random enemy, jump between targets, each level increases the number of shields thrown."),

        new(SpellWords.Cyclone_Name, "Ciclone", "Cyclone"),
        new(SpellWords.Cyclone_Desc,
            "Gira com seu machado em formato de ciclone, causando dano em toda a sua volta, cada nível aumenta a duração do giro.",
            "Spin with your axe in the shape of a cyclone, causing damage all around you, each level increases the duration of the spin."),

        // PASSIVAS
        new(SpellWords.Gauntlet_Name, "Manopla", "Gauntlet"),
        new(SpellWords.Gauntlet_Desc,
            "Aumenta o dano base de todos os ataques em 10% por nível",
            "Increases the base damage of all attacks by 10% per level"),

        new(SpellWords.Clock_Name, "Relógio", "Clock"),
        new(SpellWords.Clock_Desc,
            "Reduz o tempo de recarga dos feitiços de tiro em 10% por nível.",
            "Reduces the cooldown of shooting spells by 10% per level."),

        new(SpellWords.Boots_Name, "Bota", "Boots"),
        new(SpellWords.Boots_Desc,
            "Aumenta a velocidade de movimento em 5% por nível.",
            "Increases movement speed by 5% per level."),

        new(SpellWords.TheHand_Name, "A Mão", "The Hand"),
        new(SpellWords.TheHand_Desc,
            "Aumenta o raio de coleta em 30% por nível.",
            "Increases pickup radius by 30% per level."),

        new(SpellWords.Heart_Name, "Coração", "Heart"),
        new(SpellWords.Heart_Desc,
            "Aumenta sua vida máxima em 20 por nível.",
            "Increases your max health by 20 per level."),

        // ESPECIAIS
        new(SpellWords.Money_Name, "Dinheiro", "Money"),
        new(SpellWords.Money_Desc,
            "Adiciona 25$ ao balanço.",
            "Add 25$ to balance."),
    };
}
