declare module '../api/kycApi' {
    export const fetchKYCData: () => Promise<any>;
    export const submitKYCData: (data: any) => Promise<void>;
} 