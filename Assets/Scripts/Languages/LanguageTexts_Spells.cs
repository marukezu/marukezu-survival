using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageTexts_Spells
{
    private class SpellData
    {
        public string Key;          // Nome interno da spell
        public string NamePt;       // Nome em português
        public string NameEn;       // Nome em inglês
        public string DescPt;       // Descrição em português
        public string DescEn;       // Descrição em inglês

        public SpellData(string key, string namePt, string nameEn, string descPt, string descEn)
        {
            Key = key;
            NamePt = namePt;
            NameEn = nameEn;
            DescPt = descPt;
            DescEn = descEn;
        }
    }

    private static List<SpellData> spells = new List<SpellData>()
    {
        // ?? KAEL FIRE SPELLS
        new SpellData("Fireball", "Bola de Fogo", "Fireball",
            "O mago conjura uma enorme bola de fogo em direção a um inimigo aleatório, causa explosão ao contato, causa queimadura.",
            "The mage conjures a massive fireball towards a random enemy, exploding on contact and causing burn damage."),

        new SpellData("Explosao", "Explosão", "Explosion",
            "O mago explode tudo à sua volta, causando dano massivo em alvos próximos.",
            "The mage detonates everything around him, dealing massive damage to all nearby enemies."),

        new SpellData("Fire Elemental", "Elemental do Fogo", "Fire Elemental",
            "O mago convoca do submundo um elemental de fogo, que replica todas suas magias, com um dano reduzido.",
            "The mage summons a fire elemental from the underworld that replicates all his spells with reduced damage."),

        new SpellData("Meteor", "Meteoro", "Meteor",
            "O mago canaliza todo seu poder para conjurar um enorme meteoro em um inimigo aleatório.",
            "The mage channels all his power to summon a massive meteor that crashes down upon a random enemy."),

        new SpellData("Ignis Arrow", "Flecha Ignis", "Ignis Arrow",
            "O mago conjura uma flecha de fogo que perfura e causa queimadura.",
            "The mage conjures a flaming arrow that pierces through enemies and inflicts burning damage over time."),

        // ?? ZEPHYR ICE SPELLS
        new SpellData("Icicle", "Lança de Gelo", "Icicle",
            "O mago conjura uma lança de gelo e arremessa em direção a um inimigo aleatório, congela o alvo.",
            "The mage conjures an icy spear and hurls it at a random enemy, freezing the target on impact."),

        new SpellData("Tornado Fury", "Fúria do Tornado", "Tornado Fury",
            "O mago conjura um enorme tornado em direção a um inimigo aleatório, atravessa os alvos.",
            "The mage summons a massive tornado towards a random enemy that tears through all targets in its path."),

        new SpellData("Blizzard", "Nevasca", "Blizzard",
            "O mago conjura uma intensa tempestade de gelo sobre o alvo, fazendo chover fragmentos congelantes que causam dano em área e congelam.",
            "The mage summons a massive tornado towards a random enemy that tears through all targets in its path."),

        new SpellData("Ice Totem", "Totem Gélido", "Ice Totem",
            "O mago conjura um enorme totem de gelo que explode após um curto período causando dano em área, explode alvos congelados.",
            "The mage summons a massive ice totem that explodes after a short period, dealing area damage and detonating frozen targets.."),

        // ? ZEPHYR THUNDER SPELLS
        new SpellData("Thunder", "Trovão", "Thunder",
            "O mago conjura um raio de trovão em direção a um inimigo aleatório, salta entre os alvos.",
            "The mage calls forth a thunderbolt that strikes a random enemy and chains between multiple targets."),

        new SpellData("Thunder Pulse", "Pulso Elétrico", "Thunder Pulse",
            "O mago conjura um pulso elétrico em um inimigo aleatório causando dano ao seu redor.",
            "The mage unleashes an electric pulse at a random enemy, dealing area damage around the impact point."),

        new SpellData("Thunder Ball", "Orbe do Trovão", "Thunder Ball",
            "O mago conjura um orbe eletrificado que pulsa eletricidade por todos alvos próximos.",
            "The mage conjures an electrified orb that continuously emits lightning, shocking all nearby enemies."),

        new SpellData("Thundera", "Descarga Elétrica", "Thundera",
            "O mago exala eletricidade pura, pulsa rapidamente raios em alvos ao redor.",
            "The mage releases pure electricity, rapidly discharging bolts of lightning at nearby targets."),

        new SpellData("Thunder Barrier", "Barreira do Trovão", "Thunder Barrier",
            "O mago usa toda sua energia para projetar uma barreira ao seu redor que protege 100% contra qualquer tipo de dano por alguns segundos.",
            "The mage channels all his energy to create a thunder barrier that grants full protection from all damage for a few seconds."),


        // ======================
        // Kael Spells
        new SpellData("Shuriken", "Shurikem", "Shuriken",
            "Shurikens orbitam o jogador, cada nível aumenta o número de shurikens",
            "Shurikens orbit the player, each level increases the number of shurikens"),
        new SpellData("Arrow", "Flecha", "Arrow",
            "Dispara uma flecha em direção a um inimigo aleatório, cada nível aumenta o número de flechas disparadas",
            "Shoots an arrow towards a random enemy, each level increases the number of arrows fired"),
        new SpellData("Pierce Dagger", "Adaga Perfurante", "Pierce Dagger",
            "Arremessa uma adaga em direção a um inimigo aleatório, perfura os alvos, cada nível aumenta o número de adagas arremessadas.",
            "Throw a dagger towards a random enemy, pierce the targets, each level increases the number of daggers thrown."),
        new SpellData("Rain Of Arrow", "Chuva de Flechas", "Rain Of Arrows",
            "Dispara várias flechas para o alto que cai em um inimigo aleatório e causa dano em área, cada dois níveis aumenta o número de disparos.",
            "Fires several arrows into the air that fall on a random enemy and cause area damage, every two levels increases the number of shots."),
        new SpellData("The Eight Kunais", "As oito kunais", "The Eight Kunais",
            "Arremessa oito kunais em torno do jogador, cada dois níveis aumenta o número de arremessos.",
            "Throws eight kunais around the player, every two levels increases the number of throws."),
        new SpellData("Multiple Shot", "Tiro Multiplo", "Multiple Shot",
            "Dispara 5 flechas em formato de cone na direção de um inimigo, cada dois níveis aumenta o número de disparos.",
            "Fires 5 cone-shaped arrows towards an enemy, every two levels increases the number of shots."),
        new SpellData("Poison Kunai", "Kunai Venenosa", "Poison Kunai",
            "Arremessa uma kunai impregnada de veneno que busca o inimigo mais próximo, cada nível aumenta o número de kunais venenosas arremessadas.",
            "Throws a kunai impregnated with poison that seeks the closest enemy, each level increases the number of poisonous kunai thrown."),
        
        // ======================
        // Broghar Spells
        new SpellData("Axe Throw", "Machado Real", "Royal Axe",
            "Arremessa um enorme machado em direção a um inimigo aleatório, perfura os alvos, cada dois níveis aumenta o número de machados arremessados.",
            "Throws a huge axe towards a random enemy, pierces the targets, every two levels increases the number of axes thrown."),
        new SpellData("Circular Cuts", "Cortes Circulares", "Circular Cuts",
            "Disfere golpes rápidos ao seu redor, causando dano em toda a sua volta, cada nível aumenta a duração de tempo dos golpes.",
            "Distributes quick blows around you, causing damage all around you, each level increases the duration of the blows."),
        new SpellData("Terremoto", "Terremoto", "Earthquake",
            "Bate com os pés com tamanha força que desencadeia um terremoto ao redor do usuário, cada dois níveis aumenta o número de terremotos provocados.",
            "Hit your feet with such force that it triggers an earthquake around the user, every two levels increases the number of earthquakes caused."),
        new SpellData("Shield Throw", "Lançamento de Escudo", "Shield Throw",
            "Arremessa o escudo contra um inimigo aleatório, salta entre alvos, cada nível aumenta o número de escudos arremessados.",
            "Throw the shield at a random enemy, jump between targets, each level increases the number of shields thrown."),
        new SpellData("Cyclone", "Ciclone", "Cyclone",
            "Gira com seu machado em formato de ciclone, causando dano em toda a sua volta, cada nível aumenta a duração do giro.",
            "Spin with your axe in the shape of a cyclone, causing damage all around you, each level increases the duration of the spin."),

        // Passivas
        new SpellData("Gauntlet", "Manopla", "Gauntlet",
            "Aumenta o dano base de todos os ataques em 10% por nível",
            "Increases the base damage of all attacks by 10% per level"),
        new SpellData("Clock", "Relógio", "Clock",
            "Reduz o tempo de recarga dos feitiços de tiro em 10% por nível.",
            "Reduces the cooldown of shooting spells by 10% per level."),
        new SpellData("Boots", "Bota", "Boots",
            "Aumenta a velocidade de movimento em 5% por nível.",
            "Increases movement speed by 5% per level."),
        new SpellData("The Hand", "A Mão", "The Hand",
            "Aumenta o raio de coleta em 30% por nível.",
            "Increases pickup radius by 30% per level."),
        new SpellData("Heart", "Coração", "Heart",
            "Aumenta sua vida máxima em 20 por nível.",
            "Increases your max health by 20 per level."),

        // Especials
        new SpellData("Money", "Dinheiro", "Money",
            "Adiciona 25$ ao balanço.",
            "Add 25$ to balance."),
    };

    public static void RegisterAll()
    {
        foreach (SpellData spell in spells)
        {
            LanguageManager.Register(spell.Key + " Name", spell.NamePt, spell.NameEn);
            LanguageManager.Register(spell.Key + " Description", spell.DescPt, spell.DescEn);
        }
    }
}
