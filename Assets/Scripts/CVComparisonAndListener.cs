using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;

public class CVComparisonAndListener : MonoBehaviour, IPointerClickHandler
{
    // Define the required CV values
    private string[] requiredSkills = { "Suomi", "Englanti" };
    private string[] requiredExperience = { "Rakennusalantyöt", "keikkatyöt", "kesätyöt" };
    private string requiredEducation = "Ammattikorkeakoulu";
    private string[] requiredCard = { "Työturvallisuuskortti", "ajokortti" };

    // Reference to the TextMeshPro component (the clicked text object)
    private TMP_Text textObject;

    // This method is called when the script starts
    void Start()
    {
        textObject = GetComponent<TMP_Text>();

        if (textObject == null)
        {
            Debug.LogError("CVComparisonAndListener needs to be attached to a TMP_Text component.");
            return;
        }

        InitializeValues();
    }

    private void InitializeValues()
    {
        if (textObject != null)
        {
            if (textObject.name == "SkillsText")
            {
                textObject.text = "Kielitaito: " + string.Join(", ", requiredSkills);
            }
            else if (textObject.name == "ExperienceText")
            {
                textObject.text = "Työkokemus: " + string.Join(", ", requiredExperience);
            }
            else if (textObject.name == "EducationText")
            {
                textObject.text = "Koulutus: " + requiredEducation;
            }
            else if (textObject.name == "CardText")
            {
                textObject.text = "Työkortit: " + string.Join(", ", requiredCard);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (textObject.color == Color.green || textObject.color == Color.red)
        {
            textObject.color = Color.white;  // Reset to normal
            Debug.Log(textObject.name + " color reset to normal.");
        }
        else
        {
            if (textObject.name == "SkillsText")
            {
                CheckSkills(textObject.text);
            }
            else if (textObject.name == "ExperienceText")
            {
                CheckExperience(textObject.text);
            }
            else if (textObject.name == "EducationText")
            {
                CheckEducation(textObject.text);
            }
            else if (textObject.name == "CardText")
            {
                CheckCards(textObject.text);
            }
        }
    }

    private void CheckSkills(string userInput)
    {
        string[] userSkills = ExtractContent(userInput);
        bool isMatch = requiredSkills.Any(skill => userSkills.Contains(skill));
        UpdateTextColor(isMatch);
    }

    private void CheckExperience(string userInput)
    {
        string[] userExperience = ExtractContent(userInput);
        bool isMatch = requiredExperience.Any(exp => userExperience.Contains(exp));
        UpdateTextColor(isMatch);
    }

    private void CheckEducation(string userInput)
    {
        bool isMatch = userInput.Contains(requiredEducation);
        UpdateTextColor(isMatch);
    }

    private void CheckCards(string userInput)
    {
        string[] userCards = ExtractContent(userInput);
        bool isMatch = requiredCard.Any(card => userCards.Contains(card));
        UpdateTextColor(isMatch);
    }

    private string[] ExtractContent(string input)
    {
        // Extract content after the colon (e.g., "Kielitaito: Suomi, Englanti" -> ["Suomi", "Englanti"])
        int colonIndex = input.IndexOf(":");
        if (colonIndex >= 0 && colonIndex < input.Length - 1)
        {
            return input.Substring(colonIndex + 1).Split(',').Select(item => item.Trim()).ToArray();
        }
        return new string[0];
    }

    private void UpdateTextColor(bool isMatch)
    {
        textObject.color = isMatch ? Color.green : Color.red;
        Debug.Log(textObject.name + (isMatch ? " matches the requirement!" : " does not match the requirement!"));
    }
}
