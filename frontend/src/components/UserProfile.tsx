import React, { useState } from 'react';

const UserProfile: React.FC = () => {
  const [user, setUser] = useState({
    name: 'John Doe',
    email: 'johndoe@example.com',
    kycStatus: 'Verified',
  });

  return (
    <div className="user-profile">
      <h2>User Profile</h2>
      <div className="profile-info">
        <p>Name: {user.name}</p>
        <p>Email: {user.email}</p>
        <p>KYC Status: {user.kycStatus}</p>
      </div>
      <button>Edit Profile</button>
    </div>
  );
};

export default UserProfile;
