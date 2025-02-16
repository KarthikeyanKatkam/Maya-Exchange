import { UserSettings } from '../types/UserSettings';

// utils/formatters.ts
export function formatCurrency(value: string, decimals: number): string {
    const num = parseFloat(value);
    if (isNaN(num)) {
      return 'Invalid Number';
    }
    return num.toLocaleString('en-US', {
      style: 'currency',
      currency: 'USD',
      minimumFractionDigits: decimals,
      maximumFractionDigits: decimals,
    });
  }

// Function to format user settings for display
export const formatUserSettings = (settings: UserSettings): string => {
    return `User: ${settings.username}, Email: ${settings.email}, Preferred Currency: ${settings.preferredCurrency}`;
};

// Function to format KYC status
export const formatKYCStatus = (isKYCCompleted: boolean): string => {
    return isKYCCompleted ? 'KYC Completed' : 'KYC Pending';
};
