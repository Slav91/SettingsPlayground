// Copyright Slav Povstianoj 2026

console.log('app.js loaded');

window.settingsPlayground = {
    applyTheme: function (theme, accent, density, corners, highContrast, reduceMotion, fontScale) {
        try {
            console.log('=== Applying theme ===');
            console.log('Theme:', theme);
            console.log('Accent:', accent);
            console.log('Density:', density);
            console.log('Corners:', corners);
            console.log('Font Scale:', fontScale);
            
            const html = document.documentElement;
            console.log('HTML element:', html);
            
            html.setAttribute('data-theme', theme);
            html.setAttribute('data-accent', accent);
            html.setAttribute('data-density', density);
            html.setAttribute('data-corners', corners);
            html.setAttribute('data-high-contrast', highContrast);
            html.setAttribute('data-reduce-motion', reduceMotion);
            html.style.setProperty('--font-scale', fontScale);
            
            // Log the attributes to verify they were set
            console.log('Attributes set:');
            console.log('  data-theme:', html.getAttribute('data-theme'));
            console.log('  data-accent:', html.getAttribute('data-accent'));
            console.log('  --font-scale:', html.style.getPropertyValue('--font-scale'));
            
            console.log('=== Theme applied successfully ===');
            return true;
        } catch (e) {
            console.error('ERROR applying theme:', e);
            return false;
        }
    },

    getSystemTheme: function () {
        try {
            const isDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
            const theme = isDark ? 'dark' : 'light';
            console.log('System theme detected:', theme);
            return theme;
        } catch (e) {
            console.error('Error getting system theme:', e);
            return 'light';
        }
    },

    test: function () {
        console.log('Test function called - JavaScript is working!');
        return 'JavaScript is working!';
    }
};

console.log('settingsPlayground object created:', window.settingsPlayground);

