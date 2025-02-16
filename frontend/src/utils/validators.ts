import { isEmail, isStrongPassword } from 'validator';

/**
 * Validates user input for registration.
 * @param {string} email - The email address to validate.
 * @param {string} password - The password to validate.
 * @returns {{ isValid: boolean, errors: { email?: string, password?: string } }} - An object containing validation results.
 */
export const validateRegistration = (email: string, password: string): { isValid: boolean, errors: { email?: string, password?: string } } => {
    const errors: { email?: string, password?: string } = {};

    if (!isEmail(email)) {
        errors.email = 'Invalid email address';
    }

    if (!isStrongPassword(password, { minLength: 8, minUppercase: 1, minNumbers: 1 })) {
        errors.password = 'Password must be at least 8 characters long and include at least one uppercase letter and one number';
    }

    return {
        isValid: Object.keys(errors).length === 0,
        errors,
    };
};

interface KYCData {
    firstName: string;
    lastName: string;
    documentNumber: string;
}

/**
 * Validates KYC information.
 * @param {KYCData} kycData - The KYC data to validate.
 * @returns {{ isValid: boolean, errors: { firstName?: string, lastName?: string, documentNumber?: string } }} - An object containing validation results.
 */
export const validateKYC = (kycData: KYCData): { isValid: boolean, errors: { firstName?: string, lastName?: string, documentNumber?: string } } => {
    const errors: { firstName?: string, lastName?: string, documentNumber?: string } = {};

    if (!kycData.firstName || kycData.firstName.trim() === '') {
        errors.firstName = 'First name is required';
    }

    if (!kycData.lastName || kycData.lastName.trim() === '') {
        errors.lastName = 'Last name is required';
    }

    if (!kycData.documentNumber || kycData.documentNumber.trim() === '') {
        errors.documentNumber = 'Document number is required';
    }

    return {
        isValid: Object.keys(errors).length === 0,
        errors,
    };
};
