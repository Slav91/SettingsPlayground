// Copyright Slav Povstianoj 2026

using System.Text.Json;
using SettingsPlayground.Models;

namespace SettingsPlayground.Services;

public class SettingsStore
{
    private readonly string _settingsFilePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public SettingsStore()
    {
        _settingsFilePath = Path.Combine(FileSystem.AppDataDirectory, "settings.json");
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<UserSettings> LoadAsync()
    {
        try
        {
            if (!File.Exists(_settingsFilePath))
            {
                return UserSettings.GetDefaults();
            }

            var json = await File.ReadAllTextAsync(_settingsFilePath);
            var settings = JsonSerializer.Deserialize<UserSettings>(json, _jsonOptions);
            
            return settings ?? UserSettings.GetDefaults();
        }
        catch
        {
            return UserSettings.GetDefaults();
        }
    }

    public async Task SaveAsync(UserSettings settings)
    {
        try
        {
            var json = JsonSerializer.Serialize(settings, _jsonOptions);
            await File.WriteAllTextAsync(_settingsFilePath, json);
        }
        catch
        {
            // Handle save errors silently for now
        }
    }

    public async Task ResetAsync()
    {
        try
        {
            if (File.Exists(_settingsFilePath))
            {
                File.Delete(_settingsFilePath);
            }
        }
        catch
        {
            // Handle delete errors silently
        }
    }
}


