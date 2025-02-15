import React, { useEffect, useState } from 'react';
import './UserProfile.css'; // Assuming you have a CSS file for styling

const UserProfile: React.FC = () => {
  const [userData, setUserData] = useState<any | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchUserData = async () => {
      setIsLoading(true);
      try {
        const response = await fetch('/api/users'); // Example API endpoint for user data
        if (!response.ok) {
          throw new Error('Failed to fetch user profile data');
        }
        const data = await response.json();
        setUserData(data);
      } catch (err: any) {
        setError(err.message || 'An error occurred while fetching user profile data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchUserData();
  }, []);

  return (
    <div className="userProfileContainer">
      <h1 className="userProfileHeader">User Profile</h1>
      {isLoading && <p>Loading user profile data...</p>}
      {error && <div className="errorIndicator">{error}</div>}
      {userData && (
        <div className="userDetails">
          <h2>{userData.name}</h2>
          <p>Email: {userData.email}</p>
          <p>Account Created: {new Date(userData.createdAt).toLocaleDateString()}</p>
          {/* Add more user details as needed */}
        </div>
      )}
    </div>
  );
};

export default UserProfile;
