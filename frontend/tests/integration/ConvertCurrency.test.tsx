// tests/integration/ConvertCurrency.test.tsx
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import ConvertCurrency from '../../src/components/ConvertCurrency/ConvertCurrency'; // Adjust the import path as necessary
import { CurrencyConversionService } from '../../src/services/currencyConversion.service'; // Adjust the import path as necessary
import '@testing-library/jest-dom'; // Import jest-dom for additional matchers

// Mock the CurrencyConversionService
jest.mock('../../src/services/currencyConversion.service', () => ({
  CurrencyConversionService: {
    convertCurrency: jest.fn() as jest.Mock,
  },
}));

describe('ConvertCurrency Component', () => {
  beforeEach(() => {
    // Clear the mock implementation
    (CurrencyConversionService.convertCurrency as jest.Mock).mockClear();
  });

  test('renders ConvertCurrency component', () => {
    render(<ConvertCurrency />);
    expect(screen.getByText(/convert currency/i)).toBeInTheDocument();
  });

  test('calls convertCurrency on form submission', async () => {
    render(<ConvertCurrency />);

    fireEvent.change(screen.getByLabelText(/amount/i), { target: { value: '100' } });
    fireEvent.change(screen.getByLabelText(/from currency/i), { target: { value: 'USD' } });
    fireEvent.change(screen.getByLabelText(/to currency/i), { target: { value: 'EUR' } });

    fireEvent.click(screen.getByText(/convert/i));

    expect(CurrencyConversionService.convertCurrency).toHaveBeenCalledWith(100, 'USD', 'EUR');
  });

  test('displays error message on conversion failure', async () => {
    (CurrencyConversionService.convertCurrency as jest.Mock).mockRejectedValue(new Error('Conversion failed'));

    render(<ConvertCurrency />);

    fireEvent.change(screen.getByLabelText(/amount/i), { target: { value: '100' } });
    fireEvent.change(screen.getByLabelText(/from currency/i), { target: { value: 'USD' } });
    fireEvent.change(screen.getByLabelText(/to currency/i), { target: { value: 'EUR' } });

    fireEvent.click(screen.getByText(/convert/i));

    await waitFor(() => {
      expect(screen.getByText(/conversion failed/i)).toBeInTheDocument();
    });
  });
});