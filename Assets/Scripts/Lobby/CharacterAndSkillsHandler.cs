﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for character and skill handling.
/// </summary>
public class CharacterAndSkillsHandler : MonoBehaviour
{
    #region Data

    #region Text Fields

    public Text NameText;
    public Text InfoText;
    public Text AttributesText;

    #endregion

    #region Image Lists

    /// <summary>
    /// Lists of images set via Unity Editor.
    /// </summary>
    public List<Image> Characters = new List<Image>();
    public List<Image> ActiveSkills = new List<Image>();
    public List<Image> PassiveSkills = new List<Image>();

    #endregion

    private readonly CharacterSelection _characterSelection = new CharacterSelection();
    private readonly SkillSelection _skillSelection = new SkillSelection();

    #region Networking Variables

    private LobbyNetworking _lobbyNetworking = new LobbyNetworking();
    public PhotonView PhotonView;
    public List<Text> TeamMembersText = new List<Text>();

    #endregion

    #endregion

    #region Monobehaivor Methods

    public void Start()
    {
        _characterSelection.LoadImages();
        ResetCharacterSelection();
        EnablePassivSkillImages();
        _skillSelection.PreparePassiveSkills();
    }

    public void OnGUI()
    {
        //var players = PhotonNetwork.playerList;

        //var sortedPlayers = players.OrderBy(x => x.ID).ToArray();

        //for (var i = 0; i < sortedPlayers.Length; i++)
        //{
        //    TeamMembersText[i].text = sortedPlayers[i].name;
        //}
    }

    #endregion

    #region Networking

    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        Debug.Log("Player Connected " + player.name);
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        Debug.Log("Player Disconnected " + player.name);
    }

    public void HandleConfirmClick()
    {
        PhotonView.RPC("ConfirmSelections", PhotonTargets.All);
        //TODO
    }

    [RPC]
    public void ConfirmSelections()
    {
        if (PhotonView.isMine)
        {
            var playerId = PhotonNetwork.player.ID - 1;

            TeamMembersText[playerId].text = "Confirmed";
        }
    }

    #endregion

    #region Enable & Reset

    /// <summary>
    /// Resets the character selection and disables every activeskill-image.
    /// </summary>
    private void ResetCharacterSelection()
    {
        for (var i = 0; i < Characters.Count; i++)
        {
            Characters[i].sprite = _characterSelection.NormalSprites[i];
        }

        foreach (var activeSkill in ActiveSkills)
        {
            activeSkill.enabled = false;
        }

        ResetTextFields();
    }

    /// <summary>
    /// Resets the skill selection.
    /// </summary>
    private void ResetSkillSelection()
    {
        _skillSelection.ClearActiveSkillSelection();
    }

    /// <summary>
    /// Resets the text fields.
    /// </summary>
    private void ResetTextFields()
    {
        NameText.text = InfoText.text = AttributesText.text = String.Empty;
    }

    /// <summary>
    /// Enables every activeskill-image.
    /// </summary>
    private void EnableActiveSkillImages()
    {
        foreach (var activeSkill in ActiveSkills)
        {
            activeSkill.enabled = true;
        }
    }

    /// <summary>
    /// Enables every passiveskill-image.
    /// </summary>
    private void EnablePassivSkillImages()
    {
        foreach (var passiveSkill in PassiveSkills)
        {
            passiveSkill.enabled = true;
        }
    }

    #endregion

    #region Character Mouse Clicks

    /// <summary>
    /// Handles a mouse click on any character/element image/button.
    /// </summary>
    /// <param name="rectClicked"></param>
    public void HandleCharacterMouseClick(RectTransform rectClicked)
    {
        //Performs a click on relevant character/element.
        var characterId = rectClicked.GetComponent<CharacterId>().Character;
        switch (characterId)
        {
            case CharacterSelection.Characters.Waterbending:
                HandleWaterMouseClick();
                break;
            case CharacterSelection.Characters.Earthbending:
                HandleEarthMouseClick();
                break;
            case CharacterSelection.Characters.Firebending:
                HandleFireMouseClick();
                break;
            case CharacterSelection.Characters.Airbending:
                HandleAirMouseClick();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Handles mouse click for the Water image.
    /// </summary>
    private void HandleWaterMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleWaterCharacter())
        {
            Characters[_characterSelection.WaterbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.WaterbendingId];
        }
        else
        {
            Characters[_characterSelection.WaterbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.WaterbendingId];
            InfoText.text = "Water description goes here";
            DisplaySkillImages();
        }
    }

    /// <summary>
    /// Handles mouse click for the Earth image.
    /// </summary>
    private void HandleEarthMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleEarthCharacter())
        {
            Characters[_characterSelection.EarthbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.EarthbendingId];
        }
        else
        {
            Characters[_characterSelection.EarthbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.EarthbendingId];
            InfoText.text = "Earth description goes here";
            DisplaySkillImages();
        }
    }

    /// <summary>
    /// Handles mouse click for the Fire image.
    /// </summary>
    private void HandleFireMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleFireCharacter())
        {
            Characters[_characterSelection.FirebendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.FirebendingId];
        }
        else
        {
            Characters[_characterSelection.FirebendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.FirebendingId];
            InfoText.text = "Fire description goes here";
            DisplaySkillImages();
        }
    }

    /// <summary>
    /// Handles mouse click for the Air image.
    /// </summary>
    private void HandleAirMouseClick()
    {
        ResetCharacterSelection();

        if (_characterSelection.ToggleAirCharacter())
        {
            Characters[_characterSelection.AirbendingId].sprite =
                _characterSelection.NormalSprites[_characterSelection.AirbendingId];
        }
        else
        {
            Characters[_characterSelection.AirbendingId].sprite =
                _characterSelection.ClickedSprites[_characterSelection.AirbendingId];
            InfoText.text = "Air description goes here";
            DisplaySkillImages();
        }
    }

    #endregion

    #region Skill Mouse Clicks

    /// <summary>
    /// Handles a mouse click on any skill image/button.
    /// </summary>
    /// <param name="rectClicked"></param>
    public void HandleSkillMouseClick(RectTransform rectClicked)
    {
        //Checks if given RectTransform is either an active or passive skill and performs a click.
        var activeSkillId = rectClicked.GetComponent<ActiveSkillId>();
        if (activeSkillId != null)
        {
            HandleActiveSkillClick(activeSkillId.ActiveSkill);
        }
        else
        {
            var passiveSkillId = rectClicked.GetComponent<PassiveSkillId>();
            HandlePassiveSkillClick(passiveSkillId.PassiveSkills);
        }
    }

    /// <summary>
    /// Handles a single mouse click for an activeskill-image.
    /// Performs a click on said image and selects/deselects it.
    /// </summary>
    /// <param name="skill">The clicked skill.</param>
    private void HandleActiveSkillClick(ActiveSkillSelection.Skills skill)
    {
        var skillNumber = (int) skill;
        if (_skillSelection.PerformActiveSkillClick(skillNumber))
        {
            _skillSelection.SelectActiveSkill(skill, ActiveSkills[skillNumber]);
            DisplayActiveSkillInformation(skill);
        }
        else
        {
            _skillSelection.DeselectActiveSkill(skill, ActiveSkills[skillNumber]);
        }
    }

    /// <summary>
    /// Handles a single mouse click for an passiveskill-image.
    /// Performs a click on said image and selects/deselects it.
    /// </summary>
    /// <param name="skill">The clicked skill.</param>
    private void HandlePassiveSkillClick(PassiveSkillSelection.Skills skill)
    {
        var skillNumber = (int) skill;
        if (_skillSelection.PerformPassiveSkillClick(skillNumber))
        {
            _skillSelection.SelectPassiveSkill(skill, PassiveSkills[skillNumber]);
            DisplayPassiveSkillInformation(skill);
        }
        else
        {
            ResetSkillSelection();
            _skillSelection.DeselectPassiveSkill(skill, PassiveSkills[skillNumber]);
        }
    }

    #endregion

    #region Skill Mouse Hover

    /// <summary>
    /// Handles a mouse over on any skill image/button.
    /// </summary>
    /// <param name="rectHover"></param>
    public void HandleMouseHoverEnter(RectTransform rectHover)
    {
        if (rectHover.GetComponent<Image>().enabled == false)
        {
            return;
        }

        var activeSkillId = rectHover.GetComponent<ActiveSkillId>();
        if (activeSkillId != null)
        {
            DisplayActiveSkillInformation(activeSkillId.ActiveSkill);
        }
        else
        {
            var passiveSkillId = rectHover.GetComponent<PassiveSkillId>();
            DisplayPassiveSkillInformation(passiveSkillId.PassiveSkills);
        }
    }

    /// <summary>
    /// Handles mouse hover exit on  any skill image/button.
    /// </summary>
    public void HandleMouseHoverExit()
    {
        ResetTextFields();
    }

    #endregion

    #region Display Methods

    /// <summary>
    /// Displays skill images based on the selected character/element.
    /// </summary>
    private void DisplaySkillImages()
    {
        EnableActiveSkillImages();
        EnablePassivSkillImages();

        switch (_characterSelection.CurrentCharacter)
        {
            case CharacterSelection.Characters.Waterbending:
                _skillSelection.PrepareWaterSkills();
                _skillSelection.DisplayWaterSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Earthbending:
                _skillSelection.PrepareEarthSkills();
                _skillSelection.DisplayEarthSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Firebending:
                _skillSelection.PrepareFireSkills();
                _skillSelection.DisplayFireSkillImages(ActiveSkills);
                break;
            case CharacterSelection.Characters.Airbending:
                _skillSelection.PrepareAirSkills();
                _skillSelection.DisplayAirSkillImages(ActiveSkills);
                break;
        }
    }

    /// <summary>
    /// Displays the selected active skill in the text boxes.
    /// </summary>
    /// <param name="skill"></param>
    private void DisplayActiveSkillInformation(ActiveSkillSelection.Skills skill)
    {
        var skillNumber = (int) skill;

      // _skillSelection.SelectActiveSkill(skill, ActiveSkills[skillNumber]);

        NameText.text = _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill.Name;
        InfoText.text = _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill.Info;

        var attributeText = "Damage: " +
                            _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill
                                .DamageHealingPower
                            + "\nChi Cost: " +
                            _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill.ChiCost
                            + "\nCooldown: " +
                            _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill.Cooldown
                            + "\nRange: " +
                            _skillSelection.ActiveSkillSelection.ActiveSkills[skillNumber].ActiveSkill.Range;

        AttributesText.text = attributeText;
    }

    /// <summary>
    /// Displays the selected passive skill in the text boxes.
    /// </summary>
    /// <param name="skill"></param>
    private void DisplayPassiveSkillInformation(PassiveSkillSelection.Skills skill)
    {
        var skillNumber = (int) skill;

        NameText.text = _skillSelection.PassiveSkillSelection.PassiveSkills[skillNumber].PassiveSkill.Name;
        InfoText.text = "Cooldown: " +
                        _skillSelection.PassiveSkillSelection.PassiveSkills[skillNumber].PassiveSkill.Cooldown;
        AttributesText.text = String.Empty;
    }

    #endregion
}
