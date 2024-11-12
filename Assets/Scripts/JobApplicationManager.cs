using System.Collections;
using UnityEngine;
using TMPro;

public class JobApplicationManager : MonoBehaviour
{
    // UI references for displaying the application info and feedback
    public TextMeshProUGUI applicationText; // Text UI for displaying application info
    public TextMeshProUGUI feedbackText; // Text UI for displaying feedback
    public GameObject[] applicationCards; // Array of application cards (drag-and-dropable)

    private int currentApplicationIndex = 0; // Keep track of the current application
    private string[] applications = {
        "Applicant: John Doe\nExperience: 5 years\nEducation: Master's",
        "Applicant: Jane Smith\nExperience: 2 years\nEducation: Bachelor's",
        "Applicant: Alex Brown\nExperience: 7 years\nEducation: PhD"
    };

    void Start()
    {
        // Ensure applicationCards and UI references are set
        if (applicationText == null || feedbackText == null)
        {
            Debug.LogError("UI references are not set in the inspector.");
            return;
        }

        // Load the first application
        LoadCurrentApplication();
    }

    // Method to update the application text
    void LoadCurrentApplication()
    {
        if (currentApplicationIndex < applications.Length)
        {
            applicationText.text = applications[currentApplicationIndex];
            feedbackText.text = ""; // Clear any feedback when a new application is loaded
        }
        else
        {
            applicationText.text = "No more applications!";
            feedbackText.text = "";
        }
    }

    // Method to move to the next application after a delay
    public void AcceptCurrentApplication()
    {
        // You can call this method when the player accepts an application (add logic for correct/incorrect here)
        feedbackText.text = "Accepted the application.";
        StartCoroutine(MoveToNextApplicationAfterDelay(2f));  // 2 second delay
    }

    public void RejectCurrentApplication()
    {
        // You can call this method when the player rejects an application (add logic for correct/incorrect here)
        feedbackText.text = "Rejected the application.";
        StartCoroutine(MoveToNextApplicationAfterDelay(2f));  // 2 second delay
    }

    private IEnumerator MoveToNextApplicationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Check if there are more applications to show
        if (currentApplicationIndex < applications.Length - 1)
        {
            currentApplicationIndex++;
            LoadCurrentApplication();
        }
        else
        {
            applicationText.text = "No more applications!";
            feedbackText.text = "End of Applications.";
        }
    }
}
