import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import { fetchKYCStatus, fetchUserAccessibleFeatures } from '../../src/services/currencyConversion.service';
import UpiPayments from '../../src/components/UpiPayments/UpiPayments'; // Adjust the import path as necessary
import '@testing-library/jest-dom';

jest.mock('../../src/services/currencyConversion.service', () => ({
  fetchKYCStatus: jest.fn(),
  fetchUserAccessibleFeatures: jest.fn(),
}));

describe('UpiPayments Component', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('renders KYC verification status for UPI payments', async () => {
    (fetchKYCStatus as jest.Mock).mockResolvedValue({ status: 'verified' });

    render(<UpiPayments userId="123" />);

    await waitFor(() => {
      expect(screen.getByText(/kyc status: verified/i)).toBeInTheDocument();
    });
  });

  test('displays error message on KYC fetch failure for UPI payments', async () => {
    (fetchKYCStatus as jest.Mock).mockRejectedValue(new Error('Failed to fetch KYC status'));

    render(<UpiPayments userId="123" />);

    await waitFor(() => {
      expect(screen.getByText(/failed to fetch kyc status/i)).toBeInTheDocument();
    });
  });

  test('fetches user accessible features for UPI payments based on KYC status', async () => {
    (fetchKYCStatus as jest.Mock).mockResolvedValue({ status: 'verified' });
    (fetchUserAccessibleFeatures as jest.Mock).mockResolvedValue(['feature1', 'feature2']);

    render(<UpiPayments userId="123" />);

    await waitFor(() => {
      expect(fetchUserAccessibleFeatures).toHaveBeenCalledWith("123");
      expect(screen.getByText(/feature1/i)).toBeInTheDocument();
      expect(screen.getByText(/feature2/i)).toBeInTheDocument();
    });
  });
});
