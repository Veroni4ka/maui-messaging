using System.Diagnostics;

namespace MessagingMAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnSendClicked(object sender, EventArgs e)
	{
        Evaluation.ModelInput input = new Evaluation.ModelInput()
        {
            Comment = MessageBox.Text.Trim(),
        };

        // Make a single prediction on the sample data and print results
        var predictionResult = Evaluation.Predict(input);

        if (predictionResult.Label == 1)
        {
            bool answer = await DisplayAlert("Attention! The message is rude!", "Would you like to send it anyway?", "Yes", "No");
            if (!answer)
            {
                MessageBox.Text = "";
                return;
            }
            //Debug.WriteLine("Answer: " + answer);
        }
        
        if (Sms.Default.IsComposeSupported)
        {
            string[] recipients = new[] { RecipientBox.Text.Trim() };

            var message = new SmsMessage(input.Comment, recipients);

            await Sms.Default.ComposeAsync(message);
        }
        
        // SemanticScreenReader.Announce(SendBtn.Text);
	}
}

