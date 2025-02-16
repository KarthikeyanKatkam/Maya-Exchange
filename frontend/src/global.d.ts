declare module 'maya-exchange' {
  interface User {
    id: string;
    name: string;
    email: string;
    kycStatus: 'pending' | 'verified' | 'failed';
    accessibleFeatures: string[];
  }

  interface Transaction {
    id: string;
    userId: string;
    amount: number;
    currency: 'LCC' | 'CLC' | 'CC';
    type: 'send' | 'receive' | 'convert';
    timestamp: Date;
  }

  interface KYC {
    userId: string;
    documents: string[];
    status: 'pending' | 'approved' | 'rejected';
  }

  interface ApiResponse<T> {
    success: boolean;
    data?: T;
    error?: string;
  }

  export function getUser(userId: string): Promise<ApiResponse<User>>;
  export function createTransaction(transaction: Transaction): Promise<ApiResponse<Transaction>>;
  export function verifyKYC(kyc: KYC): Promise<ApiResponse<KYC>>;
}

declare global {
    interface Window {
        ethereum: any; // You can replace 'any' with a more specific type if needed
    }
}

export {};
