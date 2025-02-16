import React, { useState, useEffect } from 'react';
import { fetchUserSettings, updateUserSettings } from '../services/apiService';
import './SecuritySettings.css';
import { UserSettings } from '../types/UserSettings';

const SecuritySettings = () => {
    const [settings, setSettings] = useState<UserSettings>({
        userId: '',
        username: '',
        email: '',
        phoneNumber: undefined,
        isKYCCompleted: false,
        preferredCurrency: '',
        notificationPreferences: {
            email: false,
            sms: false,
        },
        twoFactorAuth: false,
        emailNotifications: false,
        kycStatus: 'pending',
    });

    useEffect(() => {
        const loadSettings = async () => {
            const userSettings = await fetchUserSettings();
            setSettings(userSettings);
        };
        loadSettings();
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, checked } = e.target;
        setSettings((prevSettings) => ({
            ...prevSettings,
            [name]: checked,
        }));
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await updateUserSettings(settings);
        alert('Settings updated successfully!');
    };

    return (
        <div className="security-settings">
            <h2>Security Settings</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>
                        <input
                            type="checkbox"
                            name="twoFactorAuth"
                            checked={settings.twoFactorAuth}
                            onChange={handleChange}
                        />
                        Enable Two-Factor Authentication
                    </label>
                </div>
                <div>
                    <label>
                        <input
                            type="checkbox"
                            name="emailNotifications"
                            checked={settings.emailNotifications}
                            onChange={handleChange}
                        />
                        Enable Email Notifications
                    </label>
                </div>
                <div>
                    <p>KYC Status: {settings.kycStatus}</p>
                </div>
                <button type="submit">Save Settings</button>
            </form>
        </div>
    );
};

export default SecuritySettings;
