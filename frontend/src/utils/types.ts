export interface UserAccessibleFeature {
    featureId: string; // Unique identifier for the feature
    featureName: string; // Name of the feature
    isEnabled: boolean; // Indicates if the feature is enabled for the user
    description?: string; // Optional description of the feature
}

export interface KYCStatus {
    userId: string; // User's unique identifier
    isKYCCompleted: boolean; // Indicates if the user has completed KYC
    verificationDate?: Date; // Optional date of KYC verification
    documentsSubmitted: boolean; // Indicates if documents have been submitted
}

export interface UserSettings {
    userId: string;
    isKYCCompleted: boolean;
    username: string;
    email: string;
    preferredCurrency: string;
    notificationPreferences: {
        email: boolean;
        sms: boolean;
    };
    // Add other required properties as needed
}
