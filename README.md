# Settings Playground

**Copyright Slav Povstianoj 2026**

A MAUI Blazor Hybrid app demonstrating real-time UI customization with live preview.
=======
## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Architecture](#architecture)

---

## Overview

**Settings Playground** shows how UI settings affect the interface in real-time. Change themes, colors, fonts, and spacing while seeing instant previews of real components.

### Platform Support

- ✅ Android (API 21+)
- ✅ iOS (iOS 11+)
- ✅ Windows (Windows 10+)
- ✅ macOS (macOS 10.15+)

---

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 (17.8+) or JetBrains Rider
- Platform-specific SDKs (Android SDK, Xcode, Windows SDK)

## Features

- **Live Preview** - See settings changes instantly on real UI components
- **9 Settings** - Theme, accent color, font scale, density, corners, motion, contrast, confirmations, start page
- **Undo System** - Revert last 10 changes with one tap
- **Import/Export** - Share settings as JSON
- **Design Tokens** - CSS custom properties for consistent theming
- **Accessibility** - Reduced motion and high contrast modes

---

## Architecture

**Three-Layer Design:**

1. **UI Layer** - Blazor components and pages
2. **State Layer** - Services managing settings and theme
3. **Persistence Layer** - JSON file storage

**State Management:**
- `SettingsState` is the single source of truth
- All components subscribe to `SettingsChanged` event
- Changes are saved automatically
- Undo history tracks last 10 changes

**Design System:**
- CSS custom properties (`--accent`, `--font-scale`, etc.)
- All styling uses design tokens
- Theme changes update root HTML attributes
- JavaScript interop applies themes instantly

---

## Key Settings

### Appearance
- **Theme** - System, Light, or Dark mode
- **Accent Color** - Blue, Purple, Green, Orange, Red, Pink
- **Font Scale** - S (0.9), M (1.0), L (1.1), XL (1.25)
- **Density** - Compact or Comfortable spacing
- **Corner Radius** - Sharp or Rounded edges

### Accessibility
- **Reduce Motion** - Minimize animations
- **High Contrast** - Increase visibility

### Preferences
- **Confirm Deletes** - Show confirmation dialogs
- **Start Page** - Preview or Settings

---

## Technologies

- **.NET 8 MAUI** - Cross-platform framework
- **Blazor** - Web UI framework
- **C#** - Backend logic
- **CSS Custom Properties** - Design tokens
- **JSON** - Settings storage

---
**Version:** 1.0  
**Last Updated:** January 2026
