import crypto from 'crypto';

// Function to generate a secure random token
export const generateSecureToken = (length: number): string => {
    return crypto.randomBytes(length).toString('hex');
};

// Function to hash a password using SHA-256
export const hashPassword = (password: string): string => {
    return crypto.createHash('sha256').update(password).digest('hex');
};

// Function to verify a password against a hashed password
export const verifyPassword = (password: string, hashedPassword: string): boolean => {
    const hash = hashPassword(password);
    return hash === hashedPassword;
};

// Function to encrypt data using AES-256
export const encryptData = (data: string, key: string): string => {
    const iv = crypto.randomBytes(16);
    const cipher = crypto.createCipheriv('aes-256-cbc', Buffer.from(key), iv);
    let encrypted = cipher.update(data, 'utf8', 'hex');
    encrypted += cipher.final('hex');
    return iv.toString('hex') + ':' + encrypted;
};

// Function to decrypt data using AES-256
export const decryptData = (encryptedData: string, key: string): string => {
    const parts = encryptedData.split(':');
    const iv = Buffer.from(parts.shift()!, 'hex');
    const encryptedText = parts.join(':');
    const decipher = crypto.createDecipheriv('aes-256-cbc', Buffer.from(key), iv);
    let decrypted = decipher.update(encryptedText, 'hex', 'utf8');
    decrypted += decipher.final('utf8');
    return decrypted;
};
