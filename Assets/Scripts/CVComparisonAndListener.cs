using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;  // Required for detecting clicks

public class CVComparisonAndListener : MonoBehaviour, IPointerClickHandler
{
    // Define the correct CV values
    private string requiredSkills = "Programming, Leadership, Communication";
    private string requiredExperience = "3 years";
    private string requiredEducation = "Bachelor's";

    // Reference to the TextMeshPro component (the clicked text object)
    private TMP_Text textObject;

    // This method is called when the script starts
    void Start()
    {
        // Set the reference to the TextMeshPro component (the text field this script is attached to)
        textObject = GetComponent<TMP_Text>();

        if (textObject == null)
        {
            Debug.LogError("CVComparisonAndListener needs to be attached to a TMP_Text component.");
            return;
        }

        // Initialize the correct values when the scene starts
        InitializeValues();
    }

    // This method initializes the required values based on the text object name
    private void InitializeValues()
    {
        if (textObject != null)
        {
            if (textObject.name == "SkillsText")  // Check if it's the Skills Text field
            {
                textObject.text = requiredSkills;
            }
            else if (textObject.name == "ExperienceText")  // Check if it's the Experience Text field
            {
                textObject.text = requiredExperience;
            }
            else if (textObject.name == "EducationText")  // Check if it's the Education Text field
            {
                textObject.text = requiredEducation;
            }
        }
    }

    // This method is triggered when the text is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // If the text is already colored green or red, reset to default
        if (textObject.color == Color.green || textObject.color == Color.red)
        {
            textObject.color = Color.white;  // Reset to normal (white)
            Debug.Log(textObject.name + " color reset to normal.");
        }
        else
        {
            // Compare the text based on the section (Skills, Experience, Education)
            if (textObject.name == "SkillsText" && textObject.text == requiredSkills)
            {
                CheckCV(textObject, requiredSkills);
            }
            else if (textObject.name == "ExperienceText" && textObject.text == requiredExperience)
            {
                CheckCV(textObject, requiredExperience);
            }
            else if (textObject.name == "EducationText" && textObject.text == requiredEducation)
            {
                CheckCV(textObject, requiredEducation);
            }
            else
            {
                // In case of incorrect or unmatching text, call CheckCV
                CheckCV(textObject, "Incorrect");
            }
        }
    }

    // This method compares the clicked text with the required value and highlights the color
    private void CheckCV(TMP_Text textObject, string requiredValue)
    {
        if (textObject.text == requiredValue)
        {
            textObject.color = Color.green;  // Correct
            Debug.Log(textObject.name + " is correct!");
        }
        else
        {
            textObject.color = Color.red;    // Incorrect
            Debug.Log(textObject.name + " is incorrect!");
        }
    }
}
