import React, { useState, useEffect } from 'react';
import { fetchUserSettings, updateUserSettings } from '../services/apiService';
import { UserSettings } from '../types/UserSettings';

const Settings: React.FC = () => {
    const [settings, setSettings] = useState<UserSettings | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadSettings = async () => {
            try {
                const userSettings = await fetchUserSettings();
                setSettings(userSettings);
            } catch (err) {
                setError('Failed to load settings');
            } finally {
                setLoading(false);
            }
        };

        loadSettings();
    }, []);

    const handleSave = async () => {
        if (settings) {
            try {
                await updateUserSettings(settings);
                alert('Settings updated successfully');
            } catch (err) {
                setError('Failed to update settings');
            }
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>{error}</div>;

    return (
        <div>
            <h1>User Settings</h1>
            {/* Render settings form here */}
            <button onClick={handleSave}>Save Settings</button>
        </div>
    );
};

export default Settings;
