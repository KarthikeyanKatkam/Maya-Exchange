import React, { useEffect, useState } from 'react';
import { fetchKYCStatus, fetchUserAccessibleFeatures } from '../../services/currencyConversion.service';

interface KYCVerificationProps {
  userId: string;
}

const KYCVerification: React.FC<KYCVerificationProps> = ({ userId }) => {
  const [kycStatus, setKycStatus] = useState<string | null>(null);
  const [error, setError] = useState<string>('');
  const [accessibleFeatures, setAccessibleFeatures] = useState<string[]>([]);

  useEffect(() => {
    const getKYCStatus = async () => {
      try {
        const status = await fetchKYCStatus(userId);
        setKycStatus(status.status);
        const features = await fetchUserAccessibleFeatures(userId);
        setAccessibleFeatures(features);
      } catch (err: any) {
        setError(err.message || 'Failed to fetch KYC status');
      }
    };

    getKYCStatus();
  }, [userId]);

  return (
    <div>
      {error && <p className="text-danger">{error}</p>}
      {kycStatus && <p>KYC Status: {kycStatus}</p>}
      {accessibleFeatures.length > 0 && (
        <div>
          <h5>Accessible Features:</h5>
          <ul>
            {accessibleFeatures.map((feature, index) => (
              <li key={index}>{feature}</li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
};

export default KYCVerification;
