import { UserSettings } from '../types/UserSettings';

export const formatCurrency = (amount: number, currency: string): string => {
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: currency,
    }).format(amount);
};

export const isKYCCompleted = (userSettings: UserSettings): boolean => {
    return userSettings.isKYCCompleted;
};

export const getNotificationPreferences = (userSettings: UserSettings): string[] => {
    const preferences: string[] = [];
    if (userSettings.notificationPreferences.email) {
        preferences.push('Email Notifications');
    }
    if (userSettings.notificationPreferences.sms) {
        preferences.push('SMS Notifications');
    }
    return preferences;
};
