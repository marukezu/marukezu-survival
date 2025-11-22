using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class MonsterList
{
    // ================================================================
    // =================== FLORESTA DO DESESPERO ======================
    // ================================================================
    // Normais
    public static Skeleton Skeleton = new Skeleton();
    public static Bat Bat = new Bat();
    public static Spider Spider = new Spider();
    public static Wolf Wolf = new Wolf();
    public static Zombie Zombie = new Zombie();
    public static DeadTree DeadTree = new DeadTree();

    // Bosses
    public static Skeleton_Boss Skeleton_Boss = new Skeleton_Boss();
    public static Bat_Boss Bat_Boss = new Bat_Boss();
    public static Spider_Boss Spider_Boss = new Spider_Boss();
    public static Wolf_Boss Wolf_Boss = new Wolf_Boss();
    public static Zombie_Boss Zombie_Boss = new Zombie_Boss();
    public static Zombie_Boss_Summon Zombie_Boss_Summon = new Zombie_Boss_Summon();
    public static DeadTree_Boss DeadTree_Boss = new DeadTree_Boss();

    // ================================================================
    // ====================== DESERTO VENTOSO =========================
    // ================================================================
    // Normais
    public static Snake Snake = new Snake();
    public static Mummy Mummy = new Mummy();
    public static Camelo Camelo = new Camelo();
    public static Caixao Caixao = new Caixao();
    public static Djinn Djinn = new Djinn();

    // Bosses
    public static Snake_Boss Snake_Boss = new Snake_Boss();
    public static Mummy_Boss Mummy_Boss = new Mummy_Boss();
    public static Camelo_Boss Camelo_Boss = new Camelo_Boss();
    public static Caixao_Boss Caixao_Boss = new Caixao_Boss();
    public static Djinn_Boss Djinn_Boss = new Djinn_Boss();

    public static List<Monster> AllMonsters => Monster.AllMonsters;
}


