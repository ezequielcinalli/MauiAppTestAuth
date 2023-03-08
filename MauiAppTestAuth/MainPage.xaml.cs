namespace MauiAppTestAuth;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        await Auth();
    }

    private async Task Auth()
    {
        try
        {
            WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
                // new Uri("https://mysite.com/mobileauth/Microsoft"),
                new Uri("https://www.eternet.com.ar/"),
                new Uri("myapp://"));

            string accessToken = authResult?.AccessToken;

            // Do something with the token
        }
        catch (TaskCanceledException e)
        {
            // Use stopped auth
        }
    }
}

