// formatCurrency.ts
export const formatCurrency = (amount: number, currency: string = 'USD'): string => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency,
    }).format(amount);
  };
  
  // Example usage of formatting for different currencies
  export const formatFiatCurrency = (amount: number): string => formatCurrency(amount, 'USD');
  export const formatCryptoCurrency = (amount: number): string => formatCurrency(amount, 'BTC');
  