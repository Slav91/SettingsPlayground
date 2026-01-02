// Copyright Slav Povstianoj 2026

namespace SettingsPlayground
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Settings Playground" };
        }
    }
}
