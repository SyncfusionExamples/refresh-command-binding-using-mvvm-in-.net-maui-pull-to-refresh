# refresh-command-binding-using-mvvm-in-.net-maui-pull-to-refresh
This example demonstrates about how to bind the RefreshCommand using MVVM in .NET MAUI PullToRefresh (SfPullToRefresh).

# How to refresh the .NET MAUI PullToRefresh from ViewModel?

`SfPullToRefresh` is fully MVVM compatible and can be refreshed by binding a property in the view model to the [SfPullToRefresh.IsRefreshing]() property.
`SfPullToRefresh` also provides support for [SfPullToRefresh.RefreshCommand]() that will be executed when the pulling is completed and the pointer is released.  You can also pass a desired object as parameter to the `SfPullToRefresh.RefreshCommand` using the [SfPullToRefresh.RefreshCommandParameter]().
The `SfPullToRefresh.RefreshCommand's` `CanExecute()` will be fired when the pulling action is performed. Returning `false` in the command's `CanExecute()` will cancel the pulling and the `SfPullToRefresh.RefreshCommand` will not be executed.

{% tabs %}
{% highlight xaml tabtittle="MainPage.xaml" hl_lines="2" %}

    <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="RefreshCommand.MainPage"
             xmlns:syncfusion="clr-namespace:Syncfusion.Maui.PullToRefresh;assembly=Syncfusion.Maui.PullToRefresh"
             xmlns:local="clr-namespace:RefreshCommand">

        <ContentPage.BindingContext>
            <local:ViewModel />
        </ContentPage.BindingContext>

        <ContentPage.Content>
            <syncfusion:SfPullToRefresh x:Name="pullToRefresh"
                                        IsRefreshing="{Binding IsRefreshing}"
                                        PullingThreshold="100"
                                        RefreshCommand="{Binding RefreshCommand}">
                <syncfusion:SfPullToRefresh.PullableContent>
                    <StackLayout BackgroundColor="#00AFF9"
                                Orientation="Vertical">
                        <Label Text="New York Temperature"
                            FontSize="Large"
                            TextColor="White"
                            HorizontalTextAlignment="Center"
                            Margin="20" />
                        <Label Text="{Binding Temperature}"
                            FontSize="Large"
                            TextColor="White"
                            HorizontalTextAlignment="Center"
                            Margin="20"
                            HeightRequest="100" />
                    </StackLayout>
                </syncfusion:SfPullToRefresh.PullableContent>
            </syncfusion:SfPullToRefresh>
        </ContentPage.Content>
    </ContentPage>

{% endhighlight %}
{% highlight c# tabtittle="ViewModel.cs" hl_lines="1" %}

    public class ViewModel : INotifyPropertyChanged
    {
        private bool isRefreshing;
        public ICommand RefreshCommand { get; set; }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                RaisePropertyChanged(nameof(IsRefreshing));
            }
        }

        public ViewModel()
        {
            RefreshCommand = new Command(Refresh);
        }

        async private void Refresh(object obj)
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            IsRefreshing = false;
            int index = random.Next(0, 6);
            Temperature = temperatureArray[index];
        }
    }

{% endhighlight %}
{% endtabs %}
