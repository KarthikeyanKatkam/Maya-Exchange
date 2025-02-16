import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import UserProfile from '../../src/components/User/UserProfile'; // Adjust the import path as necessary
import { fetchKYCStatus, fetchUserAccessibleFeatures } from '../../src/services/currencyConversion.service';
import '@testing-library/jest-dom';

jest.mock('../../src/services/currencyConversion.service', () => ({
  fetchKYCStatus: jest.fn(),
  fetchUserAccessibleFeatures: jest.fn(),
}));

describe('UserProfile Component', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('renders KYC verification status on UserProfile', async () => {
    (fetchKYCStatus as jest.Mock).mockResolvedValue({ status: 'verified' });

    render(<UserProfile userId="123" />);

    await waitFor(() => {
      expect(screen.getByText(/kyc status: verified/i)).toBeInTheDocument();
    });
  });

  test('displays error message on KYC fetch failure for UserProfile', async () => {
    (fetchKYCStatus as jest.Mock).mockRejectedValue(new Error('Failed to fetch KYC status'));

    render(<UserProfile userId="123" />);

    await waitFor(() => {
      expect(screen.getByText(/failed to fetch kyc status/i)).toBeInTheDocument();
    });
  });

  test('fetches user accessible features for UserProfile based on KYC status', async () => {
    (fetchKYCStatus as jest.Mock).mockResolvedValue({ status: 'verified' });
    (fetchUserAccessibleFeatures as jest.Mock).mockResolvedValue(['feature1', 'feature2']);

    render(<UserProfile userId="123" />);

    await waitFor(() => {
      expect(fetchUserAccessibleFeatures).toHaveBeenCalledWith("123");
      expect(screen.getByText(/feature1/i)).toBeInTheDocument();
      expect(screen.getByText(/feature2/i)).toBeInTheDocument();
    });
  });
});
