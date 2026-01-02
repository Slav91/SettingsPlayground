// Copyright Slav Povstianoj 2026

using Microsoft.JSInterop;
using SettingsPlayground.Models;

namespace SettingsPlayground.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ApplyThemeAsync(UserSettings settings)
    {
        try
        {
            // Determine actual theme based on system preference if needed
            var theme = settings.Theme == ThemeMode.System 
                ? await GetSystemThemeAsync() 
                : settings.Theme.ToString().ToLower();

            // Apply theme attributes to document root
            await _jsRuntime.InvokeVoidAsync(
                "settingsPlayground.applyTheme",
                theme,
                settings.AccentColour.ToString().ToLower(),
                settings.Density.ToString().ToLower(),
                settings.CornerRadius.ToString().ToLower(),
                settings.HighContrast.ToString().ToLower(),
                settings.ReduceMotion.ToString().ToLower(),
                settings.FontScale.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
            );
        }
        catch (Exception)
        {
            // Silently handle JS interop errors during initialization
        }
    }

    private async Task<string> GetSystemThemeAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>("settingsPlayground.getSystemTheme");
        }
        catch
        {
            return "light";
        }
    }
}


