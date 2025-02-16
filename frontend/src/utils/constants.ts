import { UserSettings } from '../types/UserSettings';

export const API_ENDPOINTS = {
    USER_MANAGEMENT: '/users',
    TRANSACTION_HISTORY: '/transactions',
    SEND: '/send',
    RECEIVE: '/receive',
    CONVERT: '/convert',
    KYC: '/kyc', // KYC/AML verification endpoint
};

export const NOTIFICATION_PREFERENCES = {
    EMAIL: 'email',
    SMS: 'sms',
};

export const CURRENCY_OPTIONS = [
    { label: 'USD', value: 'usd' },
    { label: 'EUR', value: 'eur' },
    { label: 'GBP', value: 'gbp' },
    // Add more currency options as needed
];

export const DEFAULT_SETTINGS: UserSettings = {
    userId: '',
    username: '',
    email: '',
    phoneNumber: undefined,
    isKYCCompleted: false,
    preferredCurrency: 'USD',
    notificationPreferences: {
        email: true,
        sms: false,
    },
    twoFactorAuth: false,
    emailNotifications: true,
    kycStatus: 'pending',
};
