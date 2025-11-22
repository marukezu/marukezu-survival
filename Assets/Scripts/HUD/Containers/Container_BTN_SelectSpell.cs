using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Container_BTN_SelectSpell : Panel
{
    [Header("====== Painel Pai ======")]
    private Panel PanelPai;

    [Header("====== Texts ======")]
    public TextMeshProUGUI TXT_SpellName;
    public TextMeshProUGUI TXT_SpellDescription;
    public TextMeshProUGUI TXT_SpellMainPotency; // Pode ser DanoBase, Tempo que dura uma barreira, é o valor principal de uma spell.
    public TextMeshProUGUI TXT_SpellRecasts;
    public TextMeshProUGUI TXT_SpellCooldown;

    [Header("====== Images ======")]
    public Image IMG_SpellIcon;
    public Image IMG_SpellElement;
    public Image IMG_SpellMainPotency; // Pode ser icone de dano, suporte, cura, oque essa magia faz, em baixo terá o texto com o valor desse atributo.
    public Image IMG_SpellRecasts; // Quantas vezes a spell recasta no máximo
    public Image IMG_SpellCondition; // Condição que a spell aplica
    public Image IMG_SpellCooldown;

    private Button BTN_ThisButton;

    private Spell spell;

    public override void AbrirPainel(object param1 = null, object param2 = null, object param3 = null)
    {
        this.spell = param1 as Spell;
        this.PanelPai = param2 as Panel;

        BTN_ThisButton = GetComponent<Button>();
        BTN_ThisButton.onClick.RemoveAllListeners();
        BTN_ThisButton.onClick.AddListener(BTN_ThisButton_Action);

        AtualizarContainer();
    }

    private void AtualizarContainer()
    {
        TXT_SpellName.text = spell.Name;
        TXT_SpellDescription.text = spell.Descricao;
        TXT_SpellMainPotency.text = spell.BaseDmg.ToString("F0");
        TXT_SpellRecasts.text = spell.MaxRecasts.ToString("F0");
        TXT_SpellCooldown.text = spell.BaseCooldown.ToString("F1");

        IMG_SpellIcon.sprite = spell.SpriteIcon;

        // Define Imagem do Elemento.
        switch (spell.SpellElement)
        {
            case Spell.Elemento.PASSIVE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Passive;
                break;

            case Spell.Elemento.PHYSICAL:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Physical;
                break;

            case Spell.Elemento.DISTANCE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Distance;
                break;

            case Spell.Elemento.FIRE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Fire;
                break;

            case Spell.Elemento.ICE:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Ice;
                break;

            case Spell.Elemento.THUNDER:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Thunder;
                break;

            case Spell.Elemento.POISON:
                IMG_SpellElement.sprite = SpritesManager.Instance.spellSprites.Spell_Element_Poison;
                break;

        }

        // Define Imagem do Tipo de Combate
        switch (spell.TypeCombat)
        {
            case Spell.CombatType.DAMAGE:
                IMG_SpellMainPotency.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Damage;
                break;

            case Spell.CombatType.HEALING:
                IMG_SpellMainPotency.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Healing;
                break;

            case Spell.CombatType.PROTECTION:
                IMG_SpellMainPotency.sprite = SpritesManager.Instance.spellSprites.Spell_CombatType_Protection;
                break;
        }

        // Define Imagem do Tipo de Target
        IMG_SpellRecasts.sprite = SpritesManager.Instance.spellSprites.Spell_Recasts;

        // Define Imagem do Tempo Cooldown
        IMG_SpellCooldown.sprite = SpritesManager.Instance.spellSprites.Spell_Cooldown;

        // Define Imagem da Spell Condition
        if (spell.statusBurn)
            IMG_SpellCondition.sprite = SpritesManager.Instance.conditionSprites.Condition_Burning;

        else if (spell.statusEletrify)
            IMG_SpellCondition.sprite = SpritesManager.Instance.conditionSprites.Condition_Eletrify;

        else if (spell.consumeEletrify)
            IMG_SpellCondition.sprite = SpritesManager.Instance.conditionSprites.Condition_ConsumeEletrify;

        else
            IMG_SpellCondition.gameObject.SetActive(false);
    }

    private void BTN_ThisButton_Action()
    {
        // Se o painel pai for o painel da seleção de spell inicial (Esse painel é filho do painel pai).
        if (PanelPai is Panel_MainMenu_Play_SelecaoSpellInicial painelSpellInicial)
        {
            MenuPrincipal_SelectSpell_Action(painelSpellInicial);
            painelSpellInicial.BTN_Avancar_Action();
            return;
        }

        // Se o painel pai for o painel da seleção de spell durante a gameplay, antigo painel level up (Esse painel é filho do painel pai).
        if (PanelPai is Panel_GamePlay_ChooseNewSpell painelChooseNewSpell)
        {
            GamePlay_SelectNewSpell_Action(painelChooseNewSpell);
            return;
        }
    }

    private void MenuPrincipal_SelectSpell_Action(Panel_MainMenu_Play_SelecaoSpellInicial painel)
    {
        HeroImage.active1 = spell;
        return;
    }

    private void GamePlay_SelectNewSpell_Action(Panel_GamePlay_ChooseNewSpell painel)
    {
        if (spell.isLevelMax)
            return;

        if (ChecaSpellEspecial(spell))
        {
            painel.FinalizarEscolha();
            return;
        }

        if (spell.SpellElement == Spell.Elemento.PASSIVE)
        {
            // Se a spell selecionada já tem no "leque" de spells do jogador.
            if (HeroImage.passive1 == spell || HeroImage.passive2 == spell || HeroImage.passive3 == spell)
            {
                // Aumenta o nível da spell selecionada e desbloqueia ela no bestiário.
                spell.AddSpellLevel();
                SpellsList.UnlockSpellBestiary(spell.TypeSpell);

                // Finaliza
                painel.FinalizarEscolha();
                return;
            }
            // Se o jogador ainda não tem essa magia no seu "leque" de spells.
            else
            {
                if (HeroImage.passive1 == null)
                    HeroImage.passive1 = spell;

                else if (HeroImage.passive2 == null)
                    HeroImage.passive2 = spell;

                else if (HeroImage.passive3 == null)
                    HeroImage.passive3 = spell;

                else
                    return;
            }
        }
        else
        {
            // Se a spell selecionada já tem no "leque" de spells do jogador.
            if (HeroImage.active1 == spell || HeroImage.active2 == spell || HeroImage.active3 == spell
                || HeroImage.active4 == spell || HeroImage.active5 == spell)
            {
                // Aumenta o nível da spell selecionada e desbloqueia ela no bestiário.
                spell.AddSpellLevel();
                SpellsList.UnlockSpellBestiary(spell.TypeSpell);

                painel.FinalizarEscolha();
                return;
            }
            // Se o jogador ainda não tem essa magia no seu "leque" de spells.
            else
            {
                if (HeroImage.active1 == null)
                    HeroImage.active1 = spell;

                else if (HeroImage.active2 == null)
                    HeroImage.active2 = spell;

                else if (HeroImage.active3 == null)
                    HeroImage.active3 = spell;

                else if (HeroImage.active4 == null)
                    HeroImage.active4 = spell;

                else if (HeroImage.active5 == null)
                    HeroImage.active5 = spell;

                  else
                    return;
            }
        }

        // Aumenta o nível da spell selecionada e desbloqueia ela no bestiário.
        spell.AddSpellLevel();
        SpellsList.UnlockSpellBestiary(spell.TypeSpell);
        painel.FinalizarEscolha();
    }

    private bool ChecaSpellEspecial(Spell spell)
    {
        if (spell.TypeSpell == Spell.SpellType.SPECIAL_MONEY)
        {
            PlayerImage.moneyFeito += 25;
            return true;
        }

        return false;
    }
}
